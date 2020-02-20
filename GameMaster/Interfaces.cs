using GameMaster.Abstracts;
using GameMaster.Types;
using System.Windows.Forms;

namespace GameMaster.Interfaces
{
    public interface VirtualMachine
    {
        World CurrentWorld { get; }
    }

    public interface ProcessInterface
    {
        void ProcessStarted();

        void ProcessEnded();
    }

    public interface Input
    {
        void KeyEvent(Keys key);

        void AxisEvent(AxisEvent axisEvent);
    }

    public interface Tick
    {
        void registerObject(Action action);

        void unregisterObject(Action action);
    }
}