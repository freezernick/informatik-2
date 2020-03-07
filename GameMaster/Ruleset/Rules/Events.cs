using System.Xml.Serialization;
using GameMaster.Ruleset.Abstracts;


namespace GameMaster.Ruleset.Events
{
    public class TickEvent : GlobalEvent
    {
        public TickEvent()
        {
            Name = "Tick Event";
            Description = "This event is triggered after a set amount of miliseconds. Useful for recurring actions. Timeframe can be changed in the template settings.";
        }
    }

    public class WorldStartupEvent : WorldEvent
    {
        public WorldStartupEvent()
        {
            Name = "World Startup Event";
            Description = "The World Startup Event is called as soon as the world is being recognized by the GameMaster. Useful for initialization.";
        }
    }

    /// <summary>
    /// The ShutdownRequestEvent is triggered when the user wants to deactive the GameMaster.
    /// </summary>
    public class GlobalShutdownRequestEvent : GlobalEvent
    {
        public GlobalShutdownRequestEvent()
        {
            Name = "Global Shutdown Request Event";
            Description = "The Global Shutdown Request Event is called when the user wants to end the GameMaster session. You could save the game in this event for example.";
        }
    }

    /// <summary>
    /// The ShutdownRequestEvent is triggered when the user wants to deactive the GameMaster.
    /// </summary>
    public class WorldShutdownRequestEvent : WorldEvent
    {
        public WorldShutdownRequestEvent()
        {
            Name = "World Shutdown Request Event";
            Description = "The World Shutdown Request Event is called when the user wants to end the GameMaster session. You could save the game in this event for example.";
        }
    }

    public class CustomGlobalEvent : GlobalEvent
    {
        public CustomGlobalEvent()
        {
            Name = "My Custom Global Event";
            Description = "A user defined global event";
        }
    }

    public class CustomWorldEvent : WorldEvent
    {
        public CustomWorldEvent()
        {
            Name = "My Custom World Event";
            Description = "A user defined world event";
        }
    }
}