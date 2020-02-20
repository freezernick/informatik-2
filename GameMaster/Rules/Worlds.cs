using GameMaster.Rules.Abstracts;
using GameMaster.Types;
using System.Numerics;

namespace GameMaster.Rules.Worlds
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