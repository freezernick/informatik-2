using GameMaster.Overlay;
using GameMaster.Ruleset;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Worlds;
using System;
using System.Diagnostics;
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
        private IntPtr processHandle;

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
            FormHandler.Get<MainForm>().ProcessStarted();
            Overlay = new GameMasterOverlay();
            Overlay.Initialize();
            Overlay.Run();
            Log("Overlay started");
            StartUpdates();
            currentWorld = configuration.LeftSideObjects.OfType<StartupWorld>().First<StartupWorld>();
            GameProcess.Refresh();
            processHandle = GameProcess.MainWindowHandle;
        }

        private void StartUpdates()
        {
            Log("Starting Updates");
            timer = new Timer(this.CheckStatus, autoEvent, 250, 250);
        }

        private void Update()
        {
            foreach(LeftSide leftSide in configuration.LeftSideObjects)
            {
                if(leftSide is Event)
                {
                    if ((Event)leftSide != null)
                    {
                        ((Event)leftSide).Execute();
                    }
                }
            }
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
            FormHandler.Get<MainForm>().ProcessEnded();
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

        private void SaveReferencePicture()
        {
            GameProcess.Refresh();
            processHandle = GameProcess.MainWindowHandle;
            Utility.CaptureWindow(processHandle).Save(Path.Combine(AppContext.BaseDirectory, $"{configuration.ID}_reference_{DateTime.Now.ToString("yyyy-MM-dd-THH-mm-ss")}.bmp"));
        }

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

    }
}