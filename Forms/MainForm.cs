using GameMaster.Config;
using GameMaster.Interfaces;
using SUCC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class MainForm : Form, ProcessInterface
    {
        public Game SelectedGame;
        public List<Game> Games;
        private bool Running;
        private VM vm;

        public MainForm()
        {
            InitializeComponent();
            Games = new List<Game>();
            Tray.Icon = SystemIcons.Application;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btEditRules_Click(object sender, EventArgs e)
        {
            FormHandler.EditorForm().Text = "Edit " + SelectedGame.Name;
            FormHandler.EditorForm().Show();
            Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checks if there are items in the box
            if (listBox1.Items.Count == 0)
            {
                btStart.Enabled = false;
                btEditProp.Enabled = false;
                btDelete.Enabled = false;
                return;
            }

            btEditProp.Enabled = true;
            btDelete.Enabled = true;
            SelectedGame = Games[listBox1.SelectedIndex];
            if (SelectedGame.ValidAction() && !Running)
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
            FormHandler.EditForm().Text = "New Config";
            FormHandler.EditForm().Show();
            Hide();
        }

        private void btEditProp_Click(object sender, EventArgs e)
        {
            FormHandler.EditorForm().Text = "Edit " + SelectedGame.Name;
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
            if (Directory.Exists(AppContext.BaseDirectory + @"\temp\"))
            {
                Directory.Delete(AppContext.BaseDirectory + @"\temp\", true);
            }

            // Loops over each directory inside the ruleset directory...
            foreach (string dir in Directory.GetDirectories(AppContext.BaseDirectory + @"\rulesets\"))
            {
                // ...and adds the found rulesets to the list...
                string[] subStrings = dir.Split('\\');
                listBox1.Items.Add(subStrings.Last());

                // ...and loads the actual config...
                DataFile dataFile = new DataFile(Path.Combine(dir, "ruleset"));
                dataFile.AutoSave = false;

                //...and adds the game to the list
                Game CurrentGame = new Game();
                Games.Add(Game.ConfigToGame(CurrentGame, dataFile));
            }

            // Select the first game in the list by default if it exists
            if (listBox1.Items.Count > 0)
            {
                listBox1.SetSelected(0, true);
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // Creates a new instance of the VM class holding information for the actual GameMaster
            vm = new VM(SelectedGame);
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            Tray.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void SourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(GameMaster.Properties.Resources.Repository);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            SelectedGame.Delete();
            SelectedGame = null;
        }

        /// <summary>
        /// Called when the game process is started
        /// </summary>
        public void ProcessStarted()
        {
            Running = true;
            Tray.Visible = true;
            Hide();
        }

        /// <summary>
        /// Called when the game process has been terminated
        /// </summary>
        public void ProcessEnded()
        {
            Running = false;
            FormHandler.MainForm().Show();
            WindowState = FormWindowState.Normal;
            Tray.Visible = false;
            vm = null;
        }
    }
}