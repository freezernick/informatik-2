namespace GameMaster.Types
{
    public enum MouseAxis
    {
        MouseX,
        MouseY
    }

    public enum Axis
    {
        X,
        Y,
        Z
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