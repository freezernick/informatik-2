using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Worlds;
using System.Drawing;

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

    public interface IImageParmeter
    {
        void ClearReference();

        void UpdateReference(Bitmap image);
    }

    public interface IRecognizable
    {
        GameWorld.ScreenParameter Get();

        void Recognized(Rectangle match);
    }
}