using GameMaster.Ruleset.Abstracts;
using System.Windows.Forms;


namespace GameMaster.Ruleset.Events
{
    /// <summary>
    /// The Tick Event is called every update cycle. The cycle can be configured by the user.
    /// </summary>
    public class TickEvent : Event
    {
        public TickEvent() => Name = "Tick Event";
    }

    /// <summary>
    /// The Startup Event is called when the GameMaster recognizes a world
    /// </summary>
    public class StartupEvent : Event
    {
        public StartupEvent() => Name = "Startup Event";
    }

    /// <summary>
    /// The Shutdown Request Event is triggered when the user wants to deactive the GameMaster.
    /// </summary>
    public class ShutdownRequestEvent : Event
    {
        public ShutdownRequestEvent() => Name = "Shutdown Request Event";
    }

    /// <summary>
    /// A Custom Event can be utilized by the user to group specific actions togehter and run them occasionally.
    /// </summary>
    public class CustomEvent : Event
    {
        public string Alias;

        public CustomEvent() => Name = "Custom Event";
    }

    public class KeyPressEvent : Event
    {
        public Keys key;
        public KeyPressEvent()
        {
            key = Keys.None;
            Name = "Keypress Event";
        }
    }
}