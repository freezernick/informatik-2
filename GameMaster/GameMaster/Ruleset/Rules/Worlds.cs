using GameMaster.Ruleset.Abstracts;
using System.Collections.Generic;
using GameMaster.Interfaces;
using System.Drawing;

namespace GameMaster.Ruleset.Worlds
{
    public class GameWorld : AbstractGameWorld, IRecognizable
    {
        public List<WorldObject> WorldObjects = new List<WorldObject>();
        
        public GameWorld() => Name = "Game World";

        public GameWorld(bool edit) : base(edit)
        {
            Name = "Game World";
        }

        public class Player : WorldObject
        {
            public Player() => Name = "Player";
        }

        public class Goal : WorldObject
        {
            public Goal() => Name = "Goal";
        }

        public class Obstacle : WorldObject
        {
            public Obstacle() => Name = "Obstacle";
        }

        public ImageRecognition WorldReference = new ImageRecognition();

        public ScreenParameter Get()
        {
            return WorldReference;
        }

        public void Recognized(Rectangle match) => new Actions.Log($"Name recognized").EventExecute(new RightSide.ActionEvent());
    }

    /// <summary>
    /// This is a "pseudo" world that is active by default. It can be used (for example in instantly loaded games).
    /// </summary>
    public class StartupWorld : World
    {
        public StartupWorld() => Name = "Startup World";

        public StartupWorld(bool init) : base(init) => Name = "Startup World";
    }
}