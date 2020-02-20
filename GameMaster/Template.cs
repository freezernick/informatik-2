using System.Collections;
using GameMaster.Abstracts;

namespace GameMaster.Templates
{
    public class Template
    {
        public string Name;
        protected bool ThirdDimension;
        public ArrayList Worlds;

        public Template()
        {
            Worlds = new ArrayList();
        }
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
        public GameWorld.Player PlayerObject;
        public GameWorld.Goal GoalObject;
        public PlattformerTemplate()
        {

        }
    }
}