using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Types;

namespace GameMaster.Interfaces
{
    public interface VirtualMachine
    {
        World CurrentWorld { get; }
    }

    /// <summary>
    /// Interface between the MainForm and the VM
    /// </summary>
    public interface ProcessInterface
    {
        void ProcessStarted();

        void ProcessEnded();
    }

    /// <summary>
    /// Interface for registering or unregistering objects to a specific left side object
    /// </summary>
    public interface ObjectRegister
    {
        void RegisterObject(RightSide eventObject);

        void UnregisterObject(RightSide eventObject);
    }

    public interface TickEventInterface
    {
        void OnTickEvent();
    }

    public interface Input
    {
        void KeyEvent(Keys key);

        void AxisEvent(AxisEvent axisEvent);
    }
}