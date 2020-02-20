using GameMaster.Types;
using System.Numerics;

namespace GameMaster.Abstracts
{
    public class Event
    {
        public string Name;

        public virtual void Execute()
        {
        }
    }

    public class Action
    {
        public string Name;

        public virtual void Run()
        {
        }
    }

    public class Click : Action
    {
        public ScreenLocation ClickLocation;

        public Click()
        {
            Name = "Click";
        }
    }

    public class World
    {
        public string Name;

        public class UIParameter
        {
            public string Name;
            public ScreenLocation ScreenLocation;
        }

        public class Trigger
        {
            public string Name;
            public bool Unique;
        }
    }

    public class StartupWorld : World
    {
        public StartupWorld()
        {
            Name = "StartupWorld";
        }
    }

    public class GameWorld : World
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

        public class WorldParameter : WorldObject
        {
            public string Name;
            public Action ToDo;
            public ScreenLocation ScreenLocation;
        }

        public class Player : WorldParameter
        {
            public Player()
            {
                Name = "Player";
            }
        }

        public class Goal : WorldParameter
        {
            public Goal()
            {
                Name = "Goal";
            }
        }

        public class WorldObject
        {
            public Vector3 WorldLocation;
            public Vector3 Size;
            public Rotation WorldRotation;
        }

        public class Avoid : Action
        {
            public WorldObject ObjectToAvoid;
            public WorldObject Self;
            public float Spacing;

            public override void Run()
            {
                if (Self.WorldLocation.X + ObjectToAvoid.WorldLocation.X < Spacing)
                {
                }

                if (Self.WorldLocation.Y + ObjectToAvoid.WorldLocation.Y < Spacing)
                {
                }

                if (Self.WorldLocation.Z + ObjectToAvoid.WorldLocation.Z < Spacing)
                {
                }
            }
        }

        public class Move : Action
        {
            public WorldObject Self;
            private bool isMoving;
            private Vector3 OldLocation;
            private int Offset;
            private Axis Axis;

            public bool IsMoving()
            {
                return isMoving;
            }

            public Move(WorldObject worldObject, Axis MovementAxis, int offset)
            {
                OldLocation = worldObject.WorldLocation;
                Axis = MovementAxis;
                Offset = offset;
            }
        }
    }
}