using GameMaster.Overlay;
using GameMaster.Ruleset;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Worlds;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace GameMaster
{
    public class VM
    {
        private Process GameProcess;
        private GameMasterOverlay Overlay;
        private KeyboardHook hook = new KeyboardHook();
        private int LogIterationCount = 0;
        private AutoResetEvent autoEvent = new AutoResetEvent(false);
        private Timer timer;
        private Configuration configuration;
        private World currentWorld;

        public VM(Configuration game)
        {
            configuration = game;
            hook.KeyPressed += InputHandling;
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F3);
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F4);
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F5);
            GameProcess = Process.Start(game.Executable);
            GameProcess.EnableRaisingEvents = true;
            GameProcess.Exited += p_Exited;
            StartLogging();
            Log("Process started");
            FormHandler.MainForm().ProcessStarted();
            Overlay = new GameMasterOverlay();
            Overlay.Initialize();
            Overlay.Run();
            Log("Overlay started");
            StartUpdates();
            currentWorld = configuration.LeftSideObjects.OfType<StartupWorld>().First<StartupWorld>();
        }

        private void StartUpdates()
        {
            Log("Starting Updates");
            timer = new Timer(this.CheckStatus, autoEvent, 250, 250);
        }

        private void Update()
        {
            Overlay.Run();
        }

        public void Interrupt()
        {
            hook.Dispose();
            Log("Interrupt signal");
            GameProcess.Kill();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            timer.Dispose();
            StopLogging();
            Overlay.Clear();
            Overlay = null;
            FormHandler.MainForm().ProcessEnded();
        }

        /// <summary>
        /// Helper for the internal timer
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            LogIterationCount++;
            if (LogIterationCount == 16)
            {
                FlushLog();
                Overlay.UpdateLog();
                LogIterationCount = 0;
            }
            Update();
        }

        private void SaveReferencePicture() => GetDesktopImage().Save(Path.Combine(AppContext.BaseDirectory, $"{configuration.ID}_reference_{DateTime.Now.ToString("yyyy-MM-dd-THH-mm-ss")}.bmp"));

        private void InputHandling(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F3)
            {
                Interrupt();
            }

            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F4)
            {
                SaveReferencePicture();
            }

            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F5)
            {
            }
        }

        // Logging

        private StreamWriter LogWriter;

        private void StartLogging() => LogWriter = new StreamWriter(Path.Combine(AppContext.BaseDirectory, "log.txt"));

        public void Log(string message)
        {
            if (LogWriter == null) { return; }
            LogWriter.WriteLine("{0} : " + message, DateTime.Now.ToLongTimeString());
        }

        public void OverlayLog(string message)
        {
            if (Overlay != null) { Overlay.Log(message); }
        }

        /// <summary>
        /// Saves the current log status
        /// </summary>
        private void FlushLog() => LogWriter.Flush();

        /// <summary>
        /// Stops the logger and saves the current log
        /// </summary>
        private void StopLogging()
        {
            FlushLog();
            LogWriter.Close();
        }

        protected static IntPtr m_HBitmap;

        public Bitmap GetDesktopImage()
        {
            //In size variable we shall keep the size of the screen.
            SIZE size;

            //Variable to keep the handle to bitmap.
            IntPtr hBitmap;

            //Here we get the handle to the desktop device context.
            IntPtr hDC = PlatformInvokeUSER32.GetDC
                          (PlatformInvokeUSER32.GetDesktopWindow());

            //Here we make a compatible device context in memory for screen
            //device context.
            IntPtr hMemDC = PlatformInvokeGDI32.CreateCompatibleDC(hDC);

            //We pass SM_CXSCREEN constant to GetSystemMetrics to get the
            //X coordinates of the screen.
            size.cx = PlatformInvokeUSER32.GetSystemMetrics
                      (PlatformInvokeUSER32.SM_CXSCREEN);

            //We pass SM_CYSCREEN constant to GetSystemMetrics to get the
            //Y coordinates of the screen.
            size.cy = PlatformInvokeUSER32.GetSystemMetrics
                      (PlatformInvokeUSER32.SM_CYSCREEN);

            //We create a compatible bitmap of the screen size and using
            //the screen device context.
            hBitmap = PlatformInvokeGDI32.CreateCompatibleBitmap
                        (hDC, size.cx, size.cy);

            //As hBitmap is IntPtr, we cannot check it against null.
            //For this purpose, IntPtr.Zero is used.
            if (hBitmap != IntPtr.Zero)
            {
                //Here we select the compatible bitmap in the memeory device
                //context and keep the refrence to the old bitmap.
                IntPtr hOld = (IntPtr)PlatformInvokeGDI32.SelectObject
                                       (hMemDC, hBitmap);
                //We copy the Bitmap to the memory device context.
                PlatformInvokeGDI32.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC,
                                           0, 0, PlatformInvokeGDI32.SRCCOPY);
                //We select the old bitmap back to the memory device context.
                PlatformInvokeGDI32.SelectObject(hMemDC, hOld);
                //We delete the memory device context.
                PlatformInvokeGDI32.DeleteDC(hMemDC);
                //We release the screen device context.
                PlatformInvokeUSER32.ReleaseDC(PlatformInvokeUSER32.
                                               GetDesktopWindow(), hDC);
                //Image is created by Image bitmap handle and stored in
                //local variable.
                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap);
                //Release the memory to avoid memory leaks.
                PlatformInvokeGDI32.DeleteObject(hBitmap);
                //This statement runs the garbage collector manually.
                GC.Collect();
                //Return the bitmap
                return bmp;
            }
            //If hBitmap is null, retun null.
            return null;
        }

        //This structure shall be used to keep the size of the screen.
        public struct SIZE
        {
            public int cx;
            public int cy;
        }
    }

    /// <summary>
    /// This class shall keep the GDI32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeGDI32
    {
        public const int SRCCOPY = 13369376;

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest,
            int yDest, int wDest, int hDest, IntPtr hdcSource,
            int xSrc, int ySrc, int RasterOp);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
            int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
    }

    /// <summary>
    /// This class shall keep the User32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeUSER32
    {
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
    }
}