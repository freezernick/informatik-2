using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameMaster
{
    //This structure shall be used to keep the size of the screen.
    public struct SIZE
    {
        public int cx;
        public int cy;
    }

    /// <summary>
    /// Class containing static utility functions and static variables
    /// </summary>
    public static class Utility
    {
        public static string RulesetDirectory = AppContext.BaseDirectory + @"\rulesets\";

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
            API.RECT windowRect = new API.RECT();
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
    }

    /// <summary>
    /// Class for handling keypresses
    /// </summary>
    public sealed class KeyboardHook : IDisposable
    {

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window() => this.CreateHandle(new CreateParams());

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hotkey pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            public void Dispose() => this.DestroyHandle();
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                KeyPressed?.Invoke(this, args);
            };
        }

        /// <summary>
        /// Registers a hotkey in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hotkey.</param>
        /// <param name="key">The key itself that is associated with the hotkey.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId += 1;

            // register the hotkey.
            if (!API.RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hotkey.");
        }

        /// <summary>
        /// A hotkey has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Dispose()
        {
            // unregister all the registered hotkeys.
            for (int i = _currentId; i > 0; i--)
            {
                API.UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }
    }

    /// <summary>
    /// Event Args for the event that is fired after the hotkey has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
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
}