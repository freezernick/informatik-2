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
using System.Diagnostics;

namespace GameMaster
{
    public partial class MainForm : Form
    {
        public Game SelectedGame;
        public List<Game> Games;
        private Process process;
        private bool Running;
        public MainForm()
        {
            InitializeComponent();
            Games = new List<Game>();
            Tray.Icon = SystemIcons.Application;
            CheckForIllegalCrossThreadCalls = true;
        }

        private void btEditRules_Click(object sender, EventArgs e)
        {
            FormHandler.EditorForm().Text = "Edit " + SelectedGame.Name;
            FormHandler.EditorForm().Show();
            Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGame = Games[listBox1.SelectedIndex];
            lNameValue.Text = SelectedGame.Name;
            lAuthorValue.Text = SelectedGame.Author;
            lVersionValue.Text = SelectedGame.FriendlyVersion;
            lLastChangedValue.Text = SelectedGame.LastChanged.ToString();
            if(SelectedGame.ValidAction() && !Running)
            {
                btStart.Enabled = true;
            }
            else
            {
                btStart.Enabled = false;
            }

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            FormHandler.EditForm().SetEditMode(false);
            FormHandler.EditForm().Text = "New config";
            FormHandler.EditForm().Show();
            Hide();
        }

        private void btEditProp_Click(object sender, EventArgs e)
        {
            FormHandler.EditForm().SetEditMode(true);
            FormHandler.EditForm().Text = "Edit " + SelectedGame.Name;
            FormHandler.EditForm().Show();
            Hide();      
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FormHandler.DownloadForm().Show();
            Hide();
        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            // Check if rulesets directory exists
            if (!Directory.Exists(AppContext.BaseDirectory + @"\rulesets\"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\rulesets\");
            }

            // Cleans the temporary directory
            if(Directory.Exists(AppContext.BaseDirectory + @"\temp\"))
            {
                Directory.Delete(AppContext.BaseDirectory + @"\temp\", true);
            }

            foreach (string dir in Directory.GetDirectories(AppContext.BaseDirectory + @"\rulesets\"))
            {
                string[] subStrings = dir.Split('\\');
                listBox1.Items.Add(subStrings.Last());
                DataFile dataFile = new DataFile(Path.Combine(dir, "ruleset"));
                Game CurrentGame = new Game();
                Games.Add(Game.ConfigToGame(CurrentGame, dataFile));
            }

            btEditProp.Enabled = true;
            btEditRules.Enabled = true;
            listBox1.SetSelected(0, true);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            process = Process.Start(SelectedGame.StartAction);
            process.EnableRaisingEvents = true;
            process.Exited += p_Exited;
            Running = true;
            Tray.Visible = true;
            Hide();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            Running = false;
            Show();
            WindowState = FormWindowState.Normal;
            Tray.Visible = false;
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            Tray.Visible = false;
            WindowState = FormWindowState.Normal;
        }
    }
}
