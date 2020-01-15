using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMaster
{
    public class Game
    {
        public Game()
        {
            Version = 1;
        }

        public String Name;
        public String ID;
        public String[] Categories;
        public String StartAction;
        public String Author;
        public DateTime LastChanged;
        public String FriendlyVersion;
        private int Version;

        public bool Start()
        {
            return true;
        }
    }
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
