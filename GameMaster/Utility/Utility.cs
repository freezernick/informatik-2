using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;

namespace GameMaster
{
    //This structure shall be used to keep the size of the screen.
    public struct SIZE
    {
        public int cx;
        public int cy;
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    public struct ReferenceParameters
    {
        public string Name;
        public int Width;
        public int Height;
        public ReferenceParameters(string name, int x, int y)
        {
            Name = name;
            Width = x;
            Height = y;
        }
    }

    /// <summary>
    /// Class containing static utility functions and static variables
    /// </summary>
    public static class Utility
    {
        public static string RulesetDirectory = Path.Combine(AppContext.BaseDirectory, "rulesets");
        public static string DownloadDirectory = Path.Combine(AppContext.BaseDirectory, "downloads");
        public static string TempDirectory = Path.Combine(AppContext.BaseDirectory + "temp");
        public static string ImageDirectory = (MainFormHelper.Get().SelectedRuleset == null) ? "" : RulesetDirectory + $@"\{MainFormHelper.Get().SelectedRuleset.Name}\images\";

        public static IEnumerable<Type> FindSubClassesOf<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = baseType.Assembly;

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        ///
        /// <3 https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static string GenerateSlug(string phrase) => phrase.ToLower().Replace(' ', '-');

        /// <summary>
        /// Creates a screenshot of the specified window
        ///
        /// <3 https://ourcodeworld.com/articles/read/195/capturing-screenshots-of-different-ways-with-c-and-winforms
        /// </summary>
        /// <param name="handle">The main window's handle</param>
        /// <returns>The screenshot</returns>
        public static Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = API.GetWindowDC(handle);
            // get the size
            RECT windowRect = new RECT();
            API.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = API.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = API.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = API.SelectObject(hdcDest, hBitmap);
            // bitblt over
            API.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, API.SRCCOPY);
            // restore selection
            API.SelectObject(hdcDest, hOld);
            // clean up
            API.DeleteDC(hdcDest);
            API.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            API.DeleteObject(hBitmap);
            return img;
        }

        /// <summary>
        /// Simulates a keystroke
        /// </summary>
        /// <param name="a"></param>
        public static void Send(ScanCodeShort a)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = a;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[0] = Input;
            API.SendInput(1, Inputs, INPUT.Size);
        }
    }
}