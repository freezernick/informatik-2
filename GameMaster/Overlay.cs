using GameMaster.Logging;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using System;
using System.Collections.Generic;

namespace GameMaster.Overlay
{
    public class GameMasterOverlay
    {
        private readonly OverlayWindow _window;
        private readonly Graphics _graphics;

        private Font _font;

        private SolidBrush _black;
        private SolidBrush _gray;
        private SolidBrush _red;
        private SolidBrush _green;
        private SolidBrush _blue;

        internal List<LogMessage> logMessages = new List<LogMessage>();

        public GameMasterOverlay()
        {
            _window = new OverlayWindow(0, 0, 1920, 1080)
            {
                IsTopmost = true,
                IsVisible = true
            };

            _window.SizeChanged += _window_SizeChanged;

            _graphics = new Graphics
            {
                Height = _window.Height,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true,
                UseMultiThreadedFactories = false,
                VSync = true,
                Width = _window.Width,
                WindowHandle = IntPtr.Zero
            };
        }

        ~GameMasterOverlay()
        {
            _graphics.Dispose();
            _window.Dispose();
        }

        public void Initialize()
        {
            _window.CreateWindow();

            _graphics.WindowHandle = _window.Handle;
            _graphics.Setup();

            _font = _graphics.CreateFont("Arial", 16);

            _black = _graphics.CreateSolidBrush(0, 0, 0);
            _gray = _graphics.CreateSolidBrush(0x24, 0x29, 0x2E);

            _red = _graphics.CreateSolidBrush(Color.Red);
            _green = _graphics.CreateSolidBrush(Color.Green);
            _blue = _graphics.CreateSolidBrush(Color.Blue);
        }

        /// <summary>
        /// Refreshes the overlay
        /// </summary>
        public void Run()
        {
            var gfx = _graphics;
            gfx.BeginScene();
            gfx.ClearScene();
            for (int i = 0; i < logMessages.Count - 1; i++)
            {
                gfx.DrawTextWithBackground(_font, 16f, _red, _black, new Point(100, i * 25), logMessages[i].message);
            }
            gfx.EndScene();
        }

        private void _window_SizeChanged(object sender, OverlaySizeEventArgs e)
        {
            if (_graphics == null) return;

            if (_graphics.IsInitialized)
            {
                // after the Graphics surface is initialized you can only use the Resize method in order to enqueue a size change
                _graphics.Resize(e.Width, e.Height);
            }
            else
            {
                // otherwise just set its members
                _graphics.Width = e.Width;
                _graphics.Height = e.Height;
            }
        }

        /// <summary>
        /// Clears the screen from the overlay
        /// </summary>
        public void Clear()
        {
            _graphics.BeginScene();
            _graphics.ClearScene();
            _graphics.EndScene();
        }

        // Logging

        /// <summary>
        /// Adds a log message to the screen
        /// </summary>
        /// <param name="Message"></param>
        public void Log(string Message) => logMessages.Add(new LogMessage(Message));

        /// <summary>
        /// Will update the remove timers for all log messages
        /// </summary>
        public void UpdateLog()
        {
            for (int i = 0; i < logMessages.Count - 1; i++)
            {
                LogMessage message = logMessages[i];
                message.clockCount++;
                if (message.clockCount == 4)
                {
                    logMessages.Remove(message);
                }
            }
        }
    }
}