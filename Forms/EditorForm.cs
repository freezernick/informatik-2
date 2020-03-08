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
        public LeftSide selectedObject;

        public EditorForm()
        {
            InitializeComponent();
            game = FormHandler.MainForm().SelectedRuleset;
        }

        private void btActionDelete_Click(object sender, EventArgs e)
        {
        }

        private void ObjectListForm_Load(object sender, EventArgs e) => UpdateList();

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
            UpdateList();
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

        public void UpdateList()
        {
            treeView1.Nodes.Clear();
            foreach (LeftSide leftSideObject in game.LeftSideObjects)
            {
                TreeNode node = treeView1.Nodes.Add(leftSideObject.ToString());
                if(leftSideObject is World)
                {
                    foreach(Event @event in ((World)leftSideObject).WorldEvents)
                    {
                        node.Nodes.Add(@event.ToString());
                    }
                }
            }
        }

        private void btTriggerDelete_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(selectedObject == null)
            {
                return;
            }

            Actions actions = new Actions();
            actions.FormClosed += ActionList_Closed;
            actions.game = game;
            actions.Show();
            Hide();
        }

        private void ActionList_Closed(object sender, EventArgs e)
        {
            Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }

    /// <summary>
    /// Parent class for all configurations windows opened by the EditorForm form.
    /// It holds a reference to the game currently being edited.
    /// </summary>
    public class EditorWindow : Form
    {
        public Configuration game;

        public EditorWindow()
        {
        }
    }
}