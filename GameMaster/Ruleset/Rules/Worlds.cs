using GameMaster.Ruleset.Abstracts;


namespace GameMaster.Ruleset.Worlds
{
    public class GameWorld : AbstractGameWorld
    {
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
    }

    public class StartupWorld : World
    {
        public StartupWorld()
        {
            Name = "StartupWorld";
        }
    }
}