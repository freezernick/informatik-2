using GameMaster.Ruleset.Rules.Abstracts;

namespace GameMaster.Ruleset.Rules.Worlds
{
    public class GameWorld : Abstracts.GameWorld
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