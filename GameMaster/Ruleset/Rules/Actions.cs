using GameMaster.Logging;
using System.Numerics;
using GameMaster.Ruleset.Types;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Worlds;

namespace GameMaster.Ruleset.Actions
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
        public GameWorld.WorldObject ObjectToAvoid;
        public GameWorld.WorldObject Self;
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
        public GameWorld.WorldObject Self;
        private bool isMoving;
        private Vector3 OldLocation;
        private int Offset;
        private Axis Axis;

        public bool IsMoving()
        {
            return isMoving;
        }

        public Move(GameWorld.WorldObject worldObject, Axis MovementAxis, int offset)
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

    public class Log : Action
    {
        public string message;

        public Log()
        {
            Name = "Log";
        }

        public override void Run()
        {
            FormHandler.MainForm().vm.Log(message);
        }
    }

    public class OverlayLog : Action
    {
        public string message;

        public OverlayLog()
        {
            Name = "Overlay Log";
        }

        public override void Run()
        {
            LogHelper.OverlayLog(message);
        }
    }
}