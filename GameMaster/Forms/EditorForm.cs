using GameMaster.Forms.Editor;
using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;
using System.Collections.Generic;
using GameMaster.Ruleset.Worlds;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        public Configuration game;
        public LeftSide selectedObject;
        public Dictionary<string, LeftSide> dict;
        TreeNode rootnode;

        public EditorForm()
        {
            InitializeComponent();
            game = MainFormHelper.Get().SelectedRuleset;
            EditorHelper._editor = this;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e) => Configuration.Save(game);

        private void ToolStripButton3_Click(object sender, EventArgs e) => Close();

        private void EditorForm_Load(object sender, EventArgs e)
        {
            dict = new Dictionary<string, LeftSide>();
            rootnode = treeView1.Nodes.Add(game.Name);
            foreach(LeftSide leftSide in game.LeftSideObjects)
            {
                dict.Add(leftSide.Name, leftSide);
                rootnode.Nodes.Add(leftSide.Name);
            }

            treeView1.ExpandAll();
        }

        private void BtTriggerDelete_Click(object sender, EventArgs e)
        {
            game.LeftSideObjects.Remove(selectedObject);
            treeView1.SelectedNode.Remove();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == game.Name)
            {
                eventStuff.Hide();
                return;
            }

            selectedObject = dict[e.Node.Text];
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new EventList().FormClosed += ToolClosure;
            Disable();
        }

        private void ToolClosure(object sender, EventArgs e) => Enabled = true;

        private void Button1_Click(object sender, EventArgs e)
        {
            GameWorld world = new GameWorld(true);
            dict.Add(world.Name, world);
            TreeNode node = rootnode.Nodes.Add(world.Name);
            foreach(Event @event in world.WorldEvents)
            {
                dict.Add(@event.Name, @event);
                node.Nodes.Add(@event.Name);
            }
            game.LeftSideObjects.Add(world);
        }

        private void Disable() => Enabled = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = true;
                return;
            }
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeftSide leftSide = dict[treeView1.SelectedNode.Text];
            leftSide.Name = textBox1.Text;
            dict.Remove(treeView1.SelectedNode.Text);
            dict.Add(textBox1.Text, leftSide);
            treeView1.SelectedNode.Text = textBox1.Text;
        }

        private void RulesetStuff_Enter(object sender, EventArgs e)
        {

        }

        //private void btSave_Click(object sender, EventArgs e)
        //{
        //    currentGame.Name = tbName.Text;
        //    currentGame.Executable = tbStartAction.Text;
        //    Configuration.Save(currentGame);
        //    if (!MainFormHelper.Get().Games.Contains(currentGame))
        //    {
        //        MainFormHelper.Get().Games.Add(currentGame);
        //        MainFormHelper.Get().UpdateList();
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e) => openFileDialog1.ShowDialog();

        //private void EditForm_Load(object sender, EventArgs e)
        //{
        //    openFileDialog1.Filter = "Executables|*.exe";
        //    openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
        //}

        //private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) => tbStartAction.Text = openFileDialog1.FileName;
    }

    public class EditorWindow : Form
    {
        public Configuration game;

        public EditorWindow() => Show();
    }

    public static class EditorHelper
    {
        public static EditorForm _editor;
    }
}