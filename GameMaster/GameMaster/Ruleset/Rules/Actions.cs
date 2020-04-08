using GameMaster.Logging;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Types;
using GameMaster.Ruleset.Worlds;
using System.Numerics;
using System.Windows.Forms;

namespace GameMaster.Ruleset.Actions
{
    public class Click : Action
    {
        public ScreenLocation ClickLocation;

        public Click()
        {
            Name = "Click";
        }

        public override void EventExecute(Event eventReference)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Avoid : Action
    {
        public GameWorld.WorldObject ObjectToAvoid;
        public GameWorld.WorldObject Self;
        public float Spacing;

        public override void EventExecute(Event eventReference)
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
        public bool isMoving;
        public Vector3 OldLocation;
        public int Offset;
        public Axis Axis;

        public bool IsMoving()
        {
            return isMoving;
        }

        public Move()
        {
        }

        public Move(GameWorld.WorldObject worldObject, Axis MovementAxis, int offset)
        {
            OldLocation = worldObject.WorldLocation;
            Axis = MovementAxis;
            Offset = offset;
        }

        public override void EventExecute(Event eventReference)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ExecuteCustomEvent : Action
    {
        public Event eventReference;

        public override void EventExecute(Event caller)
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

        public override void EventExecute(Event eventReference)
        {
            MainFormHelper.Get().Vm.Log(message);
        }
    }

    public class OverlayLog : Action
    {
        public string message;
        public bool useLogfile = false;

        public OverlayLog()
        {
            Name = "Overlay Log";
        }

        public override void EventExecute(Event eventReference)
        {
            LogHelper.OverlayLog(message, useLogfile);
        }
    }

    public class Keypress : Action
    {
        public Keys key;

        public override void EventExecute(Event eventReference)
        {
            SendKeys.Send(key.ToString());
        }
    }
}