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
        public bool Hold = false;

        public Click() => Name = "Click";

        public override void EventExecute(Event eventReference)
        {
            uint X = (uint)ClickLocation.X;
            uint Y = (uint)ClickLocation.Y;
            API.mouse_event(Utility.MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            if(!Hold)
                API.mouse_event(Utility.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
    }

    public class ClickParameter : Click
    {
        public World.ImageRecognition Parameter = new World.ImageRecognition();
    }

    public class Avoid : RightSide
    {
        public GameWorld.WorldObject ObjectToAvoid;
        public GameWorld.WorldObject Self;
        public float Spacing;

        public override void EventExecute(Event eventReference)
        {
            if (Self.ScreenLocation.X - ObjectToAvoid.ScreenLocation.X < Spacing)
                new Move(Self, Axis.MinusX).EventExecute(new ActionEvent());
            else if(ObjectToAvoid.ScreenLocation.X - Self.ScreenLocation.X < Spacing)
                new Move(Self, Axis.PlusX).EventExecute(new ActionEvent());
            if (Self.ScreenLocation.Y - ObjectToAvoid.ScreenLocation.Y < Spacing)
                new Move(Self, Axis.MinusY).EventExecute(new ActionEvent());
            else if (Self.ScreenLocation.Y - ObjectToAvoid.ScreenLocation.Y < Spacing)
                new Move(Self, Axis.PlusY).EventExecute(new ActionEvent());
        }
    }

    public class Move : RightSide
    {
        public GameWorld.WorldObject Self;
        public bool isMoving;
        public Vector2 OldLocation;
        public Axis Axis;

        public bool IsMoving()
        {
            return isMoving;
        }

        public Move()
        {
        }

        public Move(GameWorld.WorldObject worldObject, Axis MovementAxis)
        {
            OldLocation = worldObject.ScreenLocation;
            Axis = MovementAxis;
        }

        public override void EventExecute(Event eventReference)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ExecuteCustomEvent : RightSide
    {
        public Event eventReference;

        public override void EventExecute(Event eventReference) => this.eventReference.Execute();
    }

    public class Log : RightSide
    {
        public string message;

        public Log() => Name = "Log";

        public Log(string message) => this.message = message;

        public override void EventExecute(Event eventReference) => MainFormHelper.Get().Vm.Log(message);
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
        public Keys key = Keys.D;

        public override void EventExecute(Event eventReference) => SendKeys.Send(key.ToString());
    }
}