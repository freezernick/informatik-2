using System.Collections;
using GameMaster.Rules.Abstracts;

namespace GameMaster.Templates
{
    public static class TemplateHelper
    {
        public static ArrayList GetTemplateList()
        {
            ArrayList Templates = new ArrayList();
            Templates.Add(new Template3D());
            Templates.Add(new Template2D());
            //Templates.Add(new PlatformerTemplate());
            return Templates;
        }
    }

    public class Template
    {
        public string Name;
        protected bool ThirdDimension;
        protected ArrayList Triggers;
        protected ArrayList Objects;
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

    //public class PlatformerTemplate : Template2D
    //{
    //    public GameWorld.Player PlayerObject;
    //    public GameWorld.Goal GoalObject;
    //}
}