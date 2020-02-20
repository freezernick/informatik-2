using System.Collections;
using System.Collections.Generic;
using GameMaster.Rules.Abstracts;
using GameMaster.Rules.Worlds;

namespace GameMaster.Templates
{
    public static class TemplateHelper
    {
        public static ArrayList GetTemplateList()
        {
            ArrayList Templates = new ArrayList();
            Templates.Add(new Platformer());
            Templates.Add(new Pong());
            Templates.Add(new FourWins());
            Templates.Add(new TicTacToe());
            Templates.Add(new TurnBased());
            return Templates;
        }
    }
    public abstract class Template
    {
        public string Name;
        protected bool ThirdDimension;
        protected List<World> Worlds;

        public Template()
        {
            Worlds = new List<World>();
            Worlds.Add(new StartupWorld());
        }
    }

    public abstract class Template3D : Template
    {
        public Template3D()
        {
            Name = "3D Template";
            ThirdDimension = true;
        }
    }

    public abstract class Template2D : Template
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