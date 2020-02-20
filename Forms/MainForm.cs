using SUCC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            if(listBox1.Items.Count > 0)
            {
                btEditProp.Enabled = true;
                btEditRules.Enabled = true;
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
            else
            {
                btStart.Enabled = false;
                btEditProp.Enabled = false;
                btEditRules.Enabled = false;
                btDelete.Enabled = false;
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
            if (Directory.Exists(AppContext.BaseDirectory + @"\temp\"))
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

            if (listBox1.Items.Count > 0)
            {
                listBox1.SetSelected(0, true);
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            process = Process.Start(SelectedGame.StartAction);
            process.EnableRaisingEvents = true;
            process.Exited += p_Exited;
            GameMasterOverlay Overlay = new GameMasterOverlay();
            Overlay.Initialize();
            Overlay.Run();
            Running = true;
            Tray.Visible = true;
            Hide();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            Running = false;
            FormHandler.MainForm().Show();
            WindowState = FormWindowState.Normal;
            Tray.Visible = false;
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
            SelectedGame.Delete();
            listBox1.ClearSelected();
            listBox1.Items.Remove(SelectedGame);
            SelectedGame = null;
        }
    }
}