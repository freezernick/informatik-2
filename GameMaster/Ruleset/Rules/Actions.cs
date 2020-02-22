using GameMaster.Ruleset.Rules.Abstracts;
using GameMaster.Ruleset.Types;
using System.Numerics;

namespace GameMaster.Ruleset.Rules.Actions
{
    public class Click : Action
    {
        public ScreenLocation ClickLocation;

        public Click()
        {
            Name = "Click";
        }

        public override void Run()
        {
        }
    }

    public class Avoid : Action
    {
        public Worlds.GameWorld.WorldObject ObjectToAvoid;
        public Worlds.GameWorld.WorldObject Self;
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
        public Worlds.GameWorld.WorldObject Self;
        private bool isMoving;
        private Vector3 OldLocation;
        private int Offset;
        private Axis Axis;

        public bool IsMoving()
        {
            return isMoving;
        }

        public Move(Worlds.GameWorld.WorldObject worldObject, Axis MovementAxis, int offset)
        {
            OldLocation = worldObject.WorldLocation;
            Axis = MovementAxis;
            Offset = offset;
        }

        public override void Run()
        {
        }
    }

    public class ExecuteCustomEvent : Action
    {
        public Event eventReference;

        public override void Run()
        {
            eventReference.Execute();
        }
    }
}