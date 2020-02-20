namespace GameMaster
{
    public class World
    {
        public string Name;
        public Origin CoordinateOrigin;
    }

    public class Trigger
    {
        public string Name;
        public bool Unique;
    }

    public class Action
    {
        public string Name;
    }

    public struct ScreenLocation
    {
        public int X;
        public int Y;
    }

    public class UIParameter
    {
        public string Name;
        public ScreenLocation ScreenLocation;
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

    public struct Location
    {
        public float X;
        public float Y;
        public float Z;

        public Location(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

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

    public class WorldObject
    {
        public Location WorldLocation;
        public Rotation WorldRotation;
    }

    public class Origin : WorldObject
    {

    }

    public class Template
    {
        public string Name;
        protected bool ThirdDimension;
    }
    
    public class Template3D : Template
    {
        public Template3D()
        {
            ThirdDimension = true;
        }
    }

    public class Template2D : Template
    {
        public Template2D()
        {
            ThirdDimension = false;
        }
    }

    public class PlattformerTemplate : Template2D
    {
        public Player PlayerObject;
    }
}