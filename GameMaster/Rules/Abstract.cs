using GameMaster.Types;
using System.Drawing;
using System.Numerics;

namespace GameMaster.Rules.Abstracts
{
    public abstract class Event
    {
        public string Name;

        public abstract void Execute();
    }

    public abstract class Action
    {
        public string Name;

        public abstract void Run();
    }

    public abstract class World
    {
        public string Name;

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

    public abstract class GameWorld : World
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
            public Action ToDo;
            public ScreenLocation ScreenLocation;
        }
    }
}