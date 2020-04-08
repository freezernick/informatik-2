using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using GameMaster.Ruleset.Worlds;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster.Ruleset.Templates
{
    public static class TemplateHelper
    {
        public static ArrayList GetTemplateList()
        {
            ArrayList Templates = new ArrayList();
            Templates.Add(new Template2D());
            Templates.Add(new Template3D());
            Templates.Add(new Platformer());
            return Templates;
        }
    }

    public abstract class Template
    {
        public static string Name;
        protected bool ThirdDimension;
        protected List<World> Worlds;

        public Template()
        {
            Worlds = new List<World>();
            Worlds.Add(new StartupWorld());
        }
    }

    public class Template3D : Template
    {
        public Template3D()
        {
            Name = "3D Template";
            ThirdDimension = true;
        }
    }

    public class Template2D : Template
    {
        public Template2D()
        {
            Name = "2D Template";
            ThirdDimension = false;
        }
    }

    public class IdleGame : Template2D
    {
        public IdleGame()
        {
            Name = "Idle Game";
        }
    }

    public class Pong : Template2D
    {
        public Pong()
        {
            Name = "Pong";
        }
    }
    public class Platformer : Template2D
    {
        public Platformer()
        {
            Name = "Platformer";
        }
    }

    public class JumpAndRun : Platformer
    {
        public JumpAndRun()
        {
            Name = "Jump and Run";
        }
    }

    public class Racing : Template2D
    {
        public Racing()
        {
            Name = "Racing";
        }
    }

    public class TurnBased : Template2D
    {
        public TurnBased()
        {
            Name = "Turn Based";
        }
    }

    public class TicTacToe : Template2D
    {
        public TicTacToe()
        {
            Name = "TicTacToe";
        }
    }

    public class FourWins : Template2D
    {
        public FourWins()
        {
            Name = "Four Wins";
        }
    }
}