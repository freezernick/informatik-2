using System;
using System.Windows.Forms;

namespace TestGame
{
    public class FormHandler
    {
        public static MainForm Main()
        {
            if (_main == null)
            {
                _main = new MainForm();
            }
            return _main;
        }

        public static Collector Collector()
        {
            if (_collector == null)
            {
                _collector = new Collector();
            }
            return _collector;
        }

        private static MainForm _main;
        private static Collector _collector;
    }

    public class GameForm : Form
    {
        public GameForm()
        {
            KeyDown += KeyPress;
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus)
            {
                Environment.Exit(1);
            }

            if (e.KeyCode == Keys.Oemplus)
            {
                Close();
                FormHandler.Main().Show();
            }
        }
    }

    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormHandler.Main());
        }
    }
}