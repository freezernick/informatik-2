using GameMaster.Rules.Abstracts;
using GameMaster.Rules.Worlds;
using GameMaster.Interfaces;
using GameMaster.Overlay;
using GameMaster.Templates;
using GameMaster.Types;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameMaster
{
    public class VM
    {
        private World CurrentWorld;
        private InputHandler InputHandler;
        private Process GameProcess;
        private Template LoadedTemplate;
        private GameMasterOverlay Overlay;

        public VM(Game game)
        {
            InputHandler = new InputHandler();
            CurrentWorld = new StartupWorld();
            GameProcess = Process.Start(game.StartAction);
            GameProcess.EnableRaisingEvents = true;
            GameProcess.Exited += p_Exited;
            FormHandler.MainForm().ProcessStarted();
            Overlay = new GameMasterOverlay();
            Overlay.Initialize();
            Overlay.Run();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            FormHandler.MainForm().ProcessEnded();
        }
    }

    public class InputHandler : Input
    {
        public InputHandler()
        {
            AxisEvents = new ArrayList();
            KeyEvents = new ArrayList();
        }

        public ArrayList AxisEvents;
        public ArrayList KeyEvents;

        public void AxisEvent(AxisEvent axisEvent)
        {
            AxisEvents.Add(axisEvent);
        }

        public void KeyEvent(Keys key)
        {
            KeyEvents.Add(key);
        }

        public void OnTick()
        {
            ArrayList localAxis = AxisEvents;
            AxisEvents.Clear();
            ArrayList localKeys = KeyEvents;
            KeyEvents.Clear();
            foreach (Keys key in localKeys)
            {
            }

            foreach (AxisEvent axisEvent in localAxis)
            {
                switch (axisEvent.Axis)
                {
                    case MouseAxis.MouseX:

                        break;

                    case MouseAxis.MouseY:

                        break;
                }
            }
        }
    }
}