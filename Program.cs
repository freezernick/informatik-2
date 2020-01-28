using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SUCC;

namespace GameMaster
{
    public class Game
    {
        public Game()
        {
            Version = 1;
        }

        public static Game ConfigToGame(Game GameObject, DataFile config)
        {
            GameObject.Name = config.Get<string>("Name");
            GameObject.ID = config.Get<string>("ID");
            GameObject.Categories = config.Get<string[]>("Categories");
            GameObject.StartAction = config.Get<string>("StartAction", "");
            GameObject.Author = config.Get<string>("Author", "");
            GameObject.LastChanged = config.Get<DateTime>("LastChanged");
            GameObject.FriendlyVersion = config.Get<string>("FriendlyVersion", "");
            GameObject.Version = config.Get<int>("Version", 1);
            GameObject.AssociatedConfig = config;
            return GameObject;
        }

        public void Save()
        {
            AssociatedConfig.Set<string>("Name", Name);
            AssociatedConfig.Set<string>("ID", ID);
            AssociatedConfig.Set<string[]>("Categories", Categories);
            AssociatedConfig.Set<string>("StartAction", StartAction);
            AssociatedConfig.Set<string>("Author", Author);
            AssociatedConfig.Set<DateTime>("LastChanged", LastChanged);
            AssociatedConfig.Set<string>("FriendlyVersion", FriendlyVersion);
            AssociatedConfig.Set<int>("Version", Version);
            AssociatedConfig.SaveAllData();
        }

        public String Name;
        public String ID;
        public String[] Categories;
        public String StartAction;
        public String Author;
        public DateTime LastChanged;
        public String FriendlyVersion;
        private int Version;
        private DataFile AssociatedConfig;
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
