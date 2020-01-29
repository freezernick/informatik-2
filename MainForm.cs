using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SUCC;
using System.Net;

namespace GameMaster
{
    public partial class MainForm : Form
    {
        public Game PseudoGame; // @F2P: Remove

        public Game SelectedGame;
        public List<Game> Games;
        public MainForm()
        {
            InitializeComponent();
            Games = new List<Game>();
        }

        private void btEditRules_Click(object sender, EventArgs e)
        {
            EditorForm Newwindow = new EditorForm();
            Newwindow.Text = "Edit " + SelectedGame.Name;
            Newwindow.Show();
            this.Hide();
 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGame = Games[listBox1.SelectedIndex];
            lNameValue.Text = SelectedGame.Name;
            lAuthorValue.Text = SelectedGame.Author;
            lVersionValue.Text = SelectedGame.FriendlyVersion;
            lLastChangedValue.Text = SelectedGame.LastChanged.ToString();

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            EditForm NewWindow = new EditForm(false,this);
            NewWindow.Text = "New Config";
            NewWindow.Show();
            this.Hide();
        }

        private void btEditProp_Click(object sender, EventArgs e)
        {
            EditForm EditWindow = new EditForm(true,this);
            EditWindow.SelectedGame = SelectedGame;
            EditWindow.Text = "Edit " + SelectedGame.Name;
            EditWindow.Show();
            this.Hide();      
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DownloadForm DownloadWindow = new DownloadForm(this);
            DownloadWindow.Show();
            this.Hide();
        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            /* Kontrolle, ob das ruleset-Directory existiert */
            if (!Directory.Exists(AppContext.BaseDirectory + @"\rulesets\"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\rulesets\");
            }

            if(Directory.Exists(AppContext.BaseDirectory + @"\temp\"))
            {
                Directory.Delete(AppContext.BaseDirectory + @"\temp\", true);
            }

            foreach (string dir in Directory.GetDirectories(AppContext.BaseDirectory + @"\rulesets\"))
            {
                string[] subStrings = dir.Split('\\');
                int LastIndex = subStrings.Length - 1;
                listBox1.Items.Add(subStrings[LastIndex]);
                DataFile dataFile = new DataFile(Path.Combine(dir, subStrings[LastIndex]));
                Game CurrentGame = new Game();
                Games.Add(Game.ConfigToGame(CurrentGame, dataFile));
            }

            /* Zumindest btStart sollte langfristig in die IndexChanged, damit wir da kontrollieren, ob ein Start denkbar ist */
            btEditProp.Enabled = true;
            btEditRules.Enabled = true;
            btStart.Enabled = true;
            listBox1.SetSelected(0, true);
        }
    }
}
