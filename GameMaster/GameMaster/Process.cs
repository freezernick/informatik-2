using GameMaster.Overlay;
using GameMaster.Ruleset;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;
using GameMaster.Ruleset.Worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Timer = System.Threading.Timer;
using System.Drawing;

namespace GameMaster
{
    public class VM
    {
        private Process GameProcess;
        private GameMasterOverlay Overlay = new GameMasterOverlay();
        private KeyboardHook hook = new KeyboardHook();
        private int LogIterationCount = 0;
        private AutoResetEvent autoEvent = new AutoResetEvent(false);
        private Timer timer;
        private Configuration configuration;
        private World currentWorld;
        private List<World> worldList = new List<World>();
        private List<KeyPressEvent> KeyEvents = new List<KeyPressEvent>();
        private bool IncreasedLogging = false;

        public VM(Configuration game)
        {
            configuration = game;
            hook.KeyPressed += InputHandling;
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F3);
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F4);
            hook.RegisterHotKey(ModifierKeys.Control, Keys.F5);
            SetupKeyPressEvents();
            GameProcess = Process.Start(game.Executable);
            GameProcess.EnableRaisingEvents = true;
            GameProcess.Exited += P_Exited;
            StartLogging();
            Log("Process started");
            MainFormHelper.Get().ProcessStarted();
            Overlay.Initialize();
            Overlay.Run();
            Log("Overlay started");
            StartUpdates();
        }

        private void SetupKeyPressEvents()
        {
            foreach (LeftSide @object in configuration.LeftSideObjects)
            {
                KeyPressEvent @event = @object as KeyPressEvent;
                if (@event == null)
                    continue;

                Log(@event.Name);
                KeyEvents.Add(@event);
                hook.RegisterHotKey(ModifierKeys.None, @event.key);
            }
        }

        private void StartUpdates()
        {
            Log("Starting Updates");
            timer = new Timer(this.CheckStatus, autoEvent, 60, 250);
        }

        private void Update()
        {
            if(currentWorld == null)
            {
                currentWorld = (StartupWorld)configuration.LeftSideObjects.Find(x => x.GetType() == typeof(StartupWorld));
                currentWorld.WorldEvents.Find(x => x.GetType() == typeof(StartupEvent)).Execute();
            }

            foreach (LeftSide leftSide in configuration.LeftSideObjects)
            {
                if (leftSide is TickEvent)
                {
                    if ((TickEvent)leftSide != null)
                        ((TickEvent)leftSide).Execute();
                }
                else if(leftSide is GameWorld)
                {

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

        private void P_Exited(object sender, EventArgs e)
        {
            timer.Dispose();
            StopLogging();
            Overlay.Clear();
            Overlay = null;
            MainFormHelper.Get().ProcessEnded();
        }

        /// <summary>
        /// Helper for the internal timer
        /// </summary>
        public void CheckStatus(Object stateInfo)
        {
            LogIterationCount++;
            if (LogIterationCount == 16)
            {
                FlushLog();
                Overlay.UpdateLog();
                LogIterationCount = 0;
            }
            Update();
        }

        private IntPtr ProcessHandle()
        {
            GameProcess.Refresh();
            return GameProcess.MainWindowHandle;
        }

        private void SaveReferencePicture() => Utility.CaptureWindow(ProcessHandle()).Save(Path.Combine(Utility.RulesetDirectory,
            $"{configuration.Folder}\\{DateTime.Now.ToString("yyyy-MM-dd-THH-mm-ss")}.bmp"));

        private void InputHandling(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F3)
            {
                Interrupt();
                return;
            }

            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F4)
            {
                SaveReferencePicture();
                return;
            }

            if (e.Modifier == ModifierKeys.Control && e.Key == Keys.F5)
            {
                IncreasedLogging = true;
            }

            foreach (KeyPressEvent @event in KeyEvents)
            {
                if (@event.key != e.Key || e.Modifier != ModifierKeys.None)
                    continue;

                @event.Execute();
            }
        }

        // Logging

        private StreamWriter LogWriter;

        /// <summary>
        /// Starts the StreamWriter for the log
        /// </summary>
        private void StartLogging() => LogWriter = new StreamWriter(Path.Combine(Utility.RulesetDirectory, configuration.Folder) + "\\log.txt");

        /// <summary>
        /// Adds a message to the log
        /// </summary>
        /// <param name="message">The message to be logged</param>
        public void Log(string message)
        {
            if (LogWriter == null) { return; }
            LogWriter.WriteLine("{0} : " + message, DateTime.Now.ToLongTimeString());
            if (IncreasedLogging)
                OverlayLog(message);
        }

        /// <summary>
        /// Displays a message on the overlay
        /// </summary>
        /// <param name="message">The message to be displayed</param>
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