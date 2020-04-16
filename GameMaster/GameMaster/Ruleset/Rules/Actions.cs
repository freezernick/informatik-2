using GameMaster.Logging;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Types;
using GameMaster.Ruleset.Worlds;
using System.Numerics;
using System.Windows.Forms;

namespace GameMaster.Ruleset.Actions
{
    public class Click : RightSide
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

    public class Avoid : RightSide
    {
        public GameWorld.WorldObject ObjectToAvoid;
        public GameWorld.WorldObject Self;
        public float Spacing;

        public override void EventExecute(Event eventReference)
        {
            if (Self.ScreenLocation.X + ObjectToAvoid.ScreenLocation.X < Spacing)
            {
            }

            if (Self.ScreenLocation.Y + ObjectToAvoid.ScreenLocation.Y < Spacing)
            {
            }
        }
    }

    public class Move : RightSide
    {
        public GameWorld.WorldObject Self;
        public bool isMoving;
        public Vector2 OldLocation;
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
            OldLocation = worldObject.ScreenLocation;
            Axis = MovementAxis;
            Offset = offset;
        }

        public override void EventExecute(Event eventReference)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ExecuteCustomEvent : RightSide
    {
        public Event eventReference;

        public override void EventExecute(Event eventReference)
        {
            this.eventReference.Execute();
        }
    }

    public class Log : RightSide
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

    public class OverlayLog : RightSide
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

    public class Keypress : RightSide
    {
        public Keys key;

        public override void EventExecute(Event eventReference)
        {
            SendKeys.Send(key.ToString());
        }
    }
}