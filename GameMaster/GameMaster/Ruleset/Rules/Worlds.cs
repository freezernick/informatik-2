using GameMaster.Ruleset.Abstracts;


namespace GameMaster.Ruleset.Worlds
{
    public class GameWorld : AbstractGameWorld
    {
        public GameWorld() => Name = "Game World";

        public GameWorld(bool init) => 

        public class Player : WorldParameter
        {
            public Player() => Name = "Player";
        }

        public class Goal : WorldParameter
        {
            public Goal() => Name = "Goal";
        }

        public ImageRecognition WorldReference;
    }

    /// <summary>
    /// This is a "pseudo" world that is active by default. It can be used (for example in instantly loaded games).
    /// </summary>
    public class StartupWorld : World
    {
        public StartupWorld() => Name = "Startup World";
    }
}