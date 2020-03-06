using GameMaster.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Xml.Serialization;
using GameMaster.Ruleset.Types;

namespace GameMaster.Ruleset.Abstracts
{
    public class GameWindow
    {
        public bool Fullscreen;
        public int Width;
        public int Height;
        public int X;
        public int Y;
    }

    /// <summary>
    /// Class used for objects that should be added to the left side of the ruleset editor
    /// </summary>
    public abstract class LeftSide
    {
        public string Name;
    }

    /// <summary>
    /// Class used for objects that should be added to the right side of the ruleset editor
    /// </summary>
    public abstract class RightSide
    {
        public abstract void EventExecute(Event eventReference);
    }

    /// <summary>
    /// Events are used to group the execution of multiple actions
    /// </summary>
    public abstract class Event : LeftSide, ObjectRegister
    {
        public string Description;
        public List<RightSide> EventObjects;

        public Event()
        {
            Name = "Event";
            Description = "Event description";
            EventObjects = new List<RightSide>();
        }

        public void Execute()
        {
            foreach (RightSide eventObject in EventObjects)
            {
                eventObject.EventExecute(this);
            }
        }

        public void RegisterObject(RightSide eventObject)
        {
            EventObjects.Add(eventObject);
        }

        public void UnregisterObject(RightSide eventObject)
        {
            EventObjects.Remove(eventObject);
        }
    }

    /// <summary>
    /// World Events are events bound to a specific world
    /// </summary>
    public abstract class WorldEvent : Event
    {
    }

    /// <summary>
    /// Global Events are executed ignoring which world is currently active
    /// </summary>
    public abstract class GlobalEvent : Event
    {
    }

    public abstract class Action : RightSide
    {
        public string Name;
    }

    public abstract class ObjectAction
    {
        public string Name;

        public abstract void Run();
    }

    public abstract class World : LeftSide
    {
        public List<WorldEvent> WorldEvents;

        public World()
        {
            WorldEvents = new List<WorldEvent>();
        }

        public abstract class ScreenParameter
        {
            public string Name;

            /// <summary>
            /// The top right corner of the are that should be observed
            /// </summary>
            public ScreenLocation ScreenLocation;

            /// <summary>
            /// The size of the area that should be observed
            /// </summary>
            public Vector2 Size;
        }

        public class TextRecognition : ScreenParameter
        {
            public string TextToRecognize;
        }

        public abstract class ShapeRecognition : ScreenParameter
        {
            /// <summary>
            /// The colors of the shape that should be looked for
            /// </summary>
            public Color[] Colors;
        }

        public class RectangleRecognition : ShapeRecognition
        {
            public Rectangle Shape;

            public RectangleRecognition()
            {
                Name = "Rectangle Recognition";
            }
        }
    }

    public abstract class AbstractGameWorld : World
    {
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
            public ObjectAction ToDo;
            public ScreenLocation ScreenLocation;
        }
    }
}