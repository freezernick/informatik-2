using GameMaster.Interfaces;
using GameMaster.Ruleset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class MainForm : GameMasterForm, IProcessInterface
    {
        public Configuration SelectedRuleset;
        public List<Configuration> Games;
        private bool Running;
        public VM Vm { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            Games = new List<Configuration>();
            Tray.Icon = SystemIcons.Application;
            Tray.Click += Tray_MouseDoubleClick;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btEditRules_Click(object sender, EventArgs e)
        {
            FormHandler.Get<EditorForm>().Text = "Edit " + SelectedRuleset.Name;
            FormHandler.Get<EditorForm>().Show();
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

            if(listBox1.SelectedItem != null)
            {
                SelectedRuleset = Games[listBox1.SelectedIndex];
                if (SelectedRuleset.ValidAction() && !Running)
                {
                    btStart.Enabled = true;
                }
                else
                {
                    btStart.Enabled = false;
                }
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            SelectedRuleset = new Configuration();
            FormHandler.Get<EditForm>().Text = "New Config";
            FormHandler.Get<EditForm>().Show();
            Hide();
        }

        private void btEditProp_Click(object sender, EventArgs e)
        {
            FormHandler.Get<EditorForm>().Text = "Edit " + SelectedRuleset.Name;
            FormHandler.Get<EditorForm>().Show();
            Hide();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FormHandler.Get<DownloadForm>().Show();
            Hide();
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Configuration config in Games)
            {
                listBox1.Items.Add(config.Name);
            }
        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            Configuration.DiscoverRulesets();
            UpdateList();
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void btStart_Click(object sender, EventArgs e) => Vm = new VM(SelectedRuleset);

        private void Tray_MouseDoubleClick(object sender, EventArgs e)
        {
            Vm.Interrupt();
            FormHandler.Get<MainForm>().Show();
            Tray.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void SourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(GameMaster.Properties.Resources.Repository);

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            SelectedRuleset.Delete();
            SelectedRuleset = null;
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
            FormHandler.Get<MainForm>().Show();
            WindowState = FormWindowState.Normal;
            Tray.Visible = false;
            Vm = null;
        }
    }
}