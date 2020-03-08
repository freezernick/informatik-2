using System.Xml.Serialization;
using GameMaster.Ruleset.Abstracts;


namespace GameMaster.Ruleset.Events
{
    /// <summary>
    /// The Tick Event is called every update cycle. The cycle can be configured by the user.
    /// </summary>
    public class TickEvent : Event
    {
        public TickEvent()
        {
            Name = "Tick Event";
            Description = "This event is triggered after a set amount of miliseconds. Useful for recurring actions.";
        }
    }

    /// <summary>
    /// The Startup Event is called when the GameMaster recognizes a world
    /// </summary>
    public class StartupEvent : Event
    {
        public StartupEvent()
        {
            Name = "Startup Event";
            Description = "The Startup Event is called as soon as the world is being recognized by the GameMaster. Useful for initialization.";
        }
    }

    /// <summary>
    /// The Shutdown Request Event is triggered when the user wants to deactive the GameMaster.
    /// </summary>
    public class ShutdownRequestEvent : Event
    {
        public ShutdownRequestEvent()
        {
            Name = "Shutdown Request Event";
            Description = "The Shutdown Request Event is called when the user wants to end the GameMaster session. You could save the game in this event for example.";
        }
    }

    /// <summary>
    /// A Custom Event can be utilized by the user to group specific actions togehter and run them occasionally.
    /// </summary>
    public class CustomEvent : Event
    {
        public CustomEvent()
        {
            Name = "My Custom Event";
            Description = "A user defined event";
        }
    }
}