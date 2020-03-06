using GameMaster.Forms.Editor;
using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        public Configuration game;

        public EditorForm()
        {
            InitializeComponent();
            game = FormHandler.MainForm().SelectedRuleset;
        }

        private void btActionDelete_Click(object sender, EventArgs e)
        {
        }

        private void ObjectListForm_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
            Hide();
        }

        // Should be tsEdit_Click
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormHandler.EditForm().Show();
            Hide();
        }

        // Should be btAddEvent_Click
        private void button4_Click_1(object sender, EventArgs e)
        {
            EditorWindow eventWindow = new EventList(game);
            eventWindow.FormClosed += OnClose;
            eventWindow.Show();
            Hide();
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.Show();
            UpdateLists();
        }

        // Should be tsSave_Click
        private void toolStripButton2_Click(object sender, EventArgs e) => Configuration.Save(game);

        // Should be tsClose_Click
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        public void UpdateLists()
        {
            foreach (LeftSide leftSideObject in game.LeftSideObjects)
            {
                listBox3.Items.Add(leftSideObject.Name);
            }
        }

        private void btTriggerDelete_Click(object sender, EventArgs e)
        {
        }
    }

    /// <summary>
    /// Parent class for all configurations windows opened by the EditorForm form.
    /// It holds a reference to the game currently being edited.
    /// </summary>
    public class EditorWindow : Form
    {
        protected Configuration game;

        public EditorWindow()
        {
        }
    }
}