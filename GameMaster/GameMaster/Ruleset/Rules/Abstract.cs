using GameMaster.Interfaces;
using GameMaster.Ruleset.Events;
using GameMaster.Ruleset.Types;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Xml.Serialization;

namespace GameMaster.Ruleset.Abstracts
{
    /// <summary>
    /// Class for major ruleset classes (worlds & events)
    /// </summary>
    public abstract class LeftSide
    {
        public string Name;
    }

    /// <summary>
    /// Class for minor ruleset classes (actions)
    /// </summary>
    public abstract class RightSide
    {
        public string Name;

        public abstract void EventExecute(Event eventReference);
    }

    /// <summary>
    /// Events are used to group the execution of multiple actions
    /// </summary>
    public abstract class Event : LeftSide, IObjectRegister
    {
        public List<RightSide> EventObjects = new List<RightSide>();

        public Event() => Name = "Event";

        public void Execute()
        {
            foreach (RightSide eventObject in EventObjects)
                eventObject.EventExecute(this);
        }

        public void RegisterObject(RightSide eventObject) => EventObjects.Add(eventObject);

        public void UnregisterObject(RightSide eventObject) => EventObjects.Remove(eventObject);
    }

    public abstract class World : LeftSide
    {
        public List<Event> WorldEvents;

        public World() => Name = "World";

        public World(bool initialize)
        {
            if (initialize)
            {
                WorldEvents = new List<Event>();
                WorldEvents.Add(new StartupEvent());
                WorldEvents.Add(new TickEvent());
                WorldEvents.Add(new ShutdownRequestEvent());
            }
        }

        public abstract class ScreenParameter
        {
            public string Name;
            public ScreenLocation ScreenLocation;
            public Vector2 Size;
        }

        public class TextRecognition : ScreenParameter
        {
            public string TextToRecognize;
        }

        public abstract class ShapeRecognition : ScreenParameter
        {
            public Color[] Colors;
        }

        public class RectangleRecognition : ShapeRecognition
        {
            public Rectangle Shape;

            public RectangleRecognition() => Name = "Rectangle Recognition";
        }

        public class ImageRecognition : ScreenParameter, IImageParmeter
        {
            public ReferenceParameters reference;

            [XmlIgnore]
            public Bitmap image { get; internal set; }

            public ImageRecognition() => reference = new ReferenceParameters();

            public void UpdateReference(Bitmap Image)
            {
                if (File.Exists(Utility.ImageDirectory + $@"\{reference.Name}"))
                    File.Delete(Utility.ImageDirectory + $@"\{reference.Name}");

                if (Image == null)
                    return;

                Image.Save(Utility.ImageDirectory + $@"\{reference.Name}");
                image = Image;
                reference = new ReferenceParameters(Utility.GenerateSlug(Name), image.Width, image.Height);
            }
        }
    }

    public abstract class AbstractGameWorld : World
    {
        public AbstractGameWorld()
        {
        }

        public AbstractGameWorld(bool edit) : base(edit)
        {
        }

        public struct Rotation
        {
            public float Roll;
            public float Yaw;
            public float Pitch;

            public Rotation(float yaw = 0.0f, float pitch = 0.0f, float roll = 0.0f)
            {
                Roll = roll;
                Yaw = yaw;
                Pitch = pitch;
            }
        }

        public abstract class WorldObject
        {
            public Vector3 WorldLocation;
            public Vector3 Size;
            public Rotation WorldRotation;
        }

        public abstract class WorldParameter : WorldObject
        {
            public string Name;
            public ScreenLocation ScreenLocation;
        }
    }
}