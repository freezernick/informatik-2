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

        public GameMasterOverlay()
        {
            // it is important to set the window to visible (and topmost) if you want to see it!
            _window = new OverlayWindow(0, 0, 800, 600)
            {
                IsTopmost = true,
                IsVisible = true
            };

            // handle this event to resize your Graphics surface
            _window.SizeChanged += _window_SizeChanged;

            // initialize a new Graphics object
            // set everything before you call _graphics.Setup()
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
            // don't forget to free resources
            _graphics.Dispose();
            _window.Dispose();
        }

        public void Initialize()
        {
            // creates the window using the settings we applied to it in the constructor
            _window.CreateWindow();

            _graphics.WindowHandle = _window.Handle; // set the target handle before calling Setup()
            _graphics.Setup();

            // creates a simple font with no additional style
            _font = _graphics.CreateFont("Arial", 16);

            // colors for brushes will be automatically normalized. 0.0f - 1.0f and 0.0f - 255.0f is accepted!
            _black = _graphics.CreateSolidBrush(0, 0, 0);
            _gray = _graphics.CreateSolidBrush(0x24, 0x29, 0x2E);

            _red = _graphics.CreateSolidBrush(Color.Red); // those are the only pre defined Colors
            _green = _graphics.CreateSolidBrush(Color.Green);
            _blue = _graphics.CreateSolidBrush(Color.Blue);
        }
        private List<string> messages;
        public void Log(string Message)
        {
            if(messages == null)
            {
                messages = new List<string>();
            }
            messages.Add(Message);
        }
        public void Run()
        {
            var gfx = _graphics;
            gfx.BeginScene(); // call before you start any drawing
            gfx.ClearScene();
            if(messages != null)
            {
                for(int i = 0; i < messages.Count; i++)
                {
                    gfx.DrawTextWithBackground(_font, _red, _black, 10, 20*i, messages.ToArray()[i]);
                }
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
    }
}