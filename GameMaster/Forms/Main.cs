using GameMaster.Interfaces;
using GameMaster.Ruleset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class MainForm : Form, IProcessInterface
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

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
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

            if (listBox1.SelectedItem != null)
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

        private void BtNew_Click(object sender, EventArgs e)
        {
            SelectedRuleset = new Configuration();
            SelectedRuleset.LeftSideObjects.Add(new Ruleset.Worlds.StartupWorld(true));
            OpenEditor();
            Hide();
        }

        private void BtEditProp_Click(object sender, EventArgs e)
        {
            OpenEditor().Text = $"Edit {SelectedRuleset.Name}";
            Hide();
        }

        private EditorForm OpenEditor()
        {
            EditorForm editor = new EditorForm();
            editor.Show();
            editor.FormClosed += EditorClosed;
            return editor;
        }

        private void EditorClosed(object sender, EventArgs e) => Show();

        private void BtAdd_Click(object sender, EventArgs e)
        {
            new DownloadForm().Show();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Configuration.DiscoverRulesets();
            UpdateList();
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void BtStart_Click(object sender, EventArgs e) => Vm = new VM(SelectedRuleset);

        private void Tray_MouseDoubleClick(object sender, EventArgs e)
        {
            Vm.Interrupt();
            MainFormHelper.Show();
            Tray.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void SourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(GameMaster.Properties.Resources.Repository);

        private void Button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this ruleset? This cannot be undone!", "Confirmation needed", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                SelectedRuleset.Delete();
                SelectedRuleset = null;
            }
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
            MainFormHelper.Show();
            WindowState = FormWindowState.Normal;
            Tray.Visible = false;
            Vm = null;
        }
    }

    public static class MainFormHelper
    {
        private static MainForm _main;

        public static void Show()
        {
            if (_main == null) { _main = new MainForm(); }
            _main.Show();
        }

        public static MainForm Get()
        {
            if (_main == null) { _main = new MainForm(); }
            return _main;
        }
    }
}