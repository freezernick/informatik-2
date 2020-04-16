using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Types;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace GameMaster.Interfaces
{
    /// <summary>
    /// Interface between the MainForm and the VM
    /// </summary>
    public interface IProcessInterface
    {
        void ProcessStarted();

        void ProcessEnded();
    }

    /// <summary>
    /// Interface for registering or unregistering objects to a specific left side object
    /// </summary>
    public interface IObjectRegister
    {
        void RegisterObject(RightSide eventObject);

        void UnregisterObject(RightSide eventObject);
    }

    public interface ITickEventInterface
    {
        void OnTickEvent();
    }

    public interface IInput
    {
        void KeyEvent(Keys key);

        void AxisEvent(AxisEvent axisEvent);
    }

    public interface IImageParmeter
    {
        void ClearReference();
        void UpdateReference(Bitmap image);
    }
}