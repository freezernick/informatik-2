using Emgu.CV;
using Emgu.CV.Structure;
using GameMaster.Overlay;
using GameMaster.Ruleset;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;
using GameMaster.Ruleset.Worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;
using GameMaster.Interfaces;
using GameMaster.Exception;

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
            if (currentWorld == null)
                UpdateWorld((StartupWorld)configuration.LeftSideObjects.Find(x => x.GetType() == typeof(StartupWorld)));

            foreach (LeftSide leftSide in configuration.LeftSideObjects)
            {
                if (leftSide is TickEvent)
                {
                    if ((TickEvent)leftSide != null)
                        ((TickEvent)leftSide).Execute();
                }
                else if (leftSide is GameWorld && leftSide != currentWorld)
                {
                    GameWorld world = (GameWorld)leftSide;
                    if (world != null && world.WorldReference.reference.Name != null)
                    {
                        Rectangle match;
                        if (Recognize(world.WorldReference, out match))
                            UpdateWorld(world);
                    }
                }
            }

            if (currentWorld is GameWorld)
            {
                GameWorld world = (GameWorld)currentWorld;
                if (world.WorldObjects.Count > 0)
                {
                    foreach (GameWorld.WorldObject worldObject in world.WorldObjects)
                    {
                        if (worldObject is IRecognizable)
                        {
                            Rectangle match;
                            IRecognizable worldObj = (IRecognizable)worldObject;
                            if(worldObj.Get() is World.ImageRecognition)
                            {
                                World.ImageRecognition reference = (World.ImageRecognition)worldObj.Get();
                                if (Recognize(reference, out match))
                                    worldObj.Recognized(match);
                            }
                            else if(worldObj.Get() is World.TextRecognition)
                            {
                                // TODO
                            }
                            else if(worldObj.Get() is World.ShapeRecognition)
                            {
                                // TODO
                            }
                            else if(worldObj.Get() is World.ScreenParameter)
                            {
                                // TODO
                            }
                            else if(worldObj.Get() is World.RectangleRecognition)
                            {
                                // TODO
                            }
                        }
                    }
                }
            }

            Overlay.Run();
        }

        /// <summary>
        /// https://stackoverflow.com/questions/16406958/emgu-finding-image-a-in-image-b
        /// </summary>
        private bool Recognize(World.ImageRecognition recognition, out Rectangle match)
        {
            if(!File.Exists(configuration.Folder + $"\\images\\{recognition.Name}"))
            {
                GMException.Throw($"Tried to recognize {recognition.Name} but no image was found!", Severity.Medium);
                match = new Rectangle();
                return false;
            }
            Image<Bgr, byte> source = BitmapExtension.ToImage<Bgr, Byte>(Utility.CaptureWindow(ProcessHandle()));
            Image<Bgr, byte> template = new Image<Bgr, byte>(configuration.Folder + $"\\images\\{recognition.Name}");
            bool found = false;
            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.9)
                {
                    match = new Rectangle(maxLocations[0], template.Size);
                    found = true;
                }
                else
                    match = new Rectangle();
            }
            source.Dispose();
            template.Dispose();
            return found;
        }

        private void UpdateWorld(World world)
        {
            currentWorld = world;
            currentWorld.WorldEvents.Find(x => x.GetType() == typeof(StartupEvent)).Execute();
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