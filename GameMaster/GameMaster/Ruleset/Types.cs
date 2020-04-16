namespace GameMaster.Ruleset.Types
{
    public enum MouseAxis
    {
        MouseX,
        MouseY
    }

    public enum Axis
    {
        PlusX,
        MinusX,
        PlusY,
        MinusY
    }

    public struct ScreenLocation
    {
        public int X;
        public int Y;
    }

    public struct AxisEvent
    {
        public MouseAxis Axis;
        public float InputValue;

        public AxisEvent(MouseAxis axis, float value)
        {
            Axis = axis;
            InputValue = value;
        }
    }
}