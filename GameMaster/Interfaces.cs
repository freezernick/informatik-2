using GameMaster.Rules.Abstracts;
using GameMaster.Types;
using System.Windows.Forms;

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
    /// Interface for registering or unregistering objects to a specific event
    /// </summary>
    public interface EventRegister
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