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

        private void UpdateGroup()
        {
            HideAll();
            if (treeView1.SelectedNode == rootnode)
                ShowRulesetProperties();
            else if (selectedObject is Event)
                ShowEventProperties();
        }

        // General Stuff

        private void ToolStripButton2_Click(object sender, EventArgs e) => Configuration.Save(game);

        private void ToolStripButton3_Click(object sender, EventArgs e) => Close();

        private void EditorForm_Load(object sender, EventArgs e)
        {
            HideAll();
            StartActionSelector.InitialDirectory = AppContext.BaseDirectory;

            dict = new Dictionary<string, LeftSide>();
            rootnode = treeView1.Nodes.Add(game.Name);
            foreach(LeftSide leftSide in game.LeftSideObjects)
            {
                dict.Add(leftSide.Name, leftSide);
                rootnode.Nodes.Add(leftSide.Name);
            }

            treeView1.ExpandAll();
            treeView1.SelectedNode = rootnode;
        }

        private void BtTriggerDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == rootnode)
                return;

            if((selectedObject is Event && game.LeftSideObjects.Contains(selectedObject)) || selectedObject is World)
            {
                game.LeftSideObjects.Remove(selectedObject);
                treeView1.SelectedNode.Remove();
                return;
            }

            // Events that are inside a world
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == game.Name)
            {
                ShowRulesetProperties();
                return;
            }

            selectedObject = dict[e.Node.Text];
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
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
            if(leftSide is CustomEvent)
            {
                game.CustomEvents.Find(x => x.Name == leftSide.Name).Name = EventName.Text;
            }
            leftSide.Name = textBox1.Text;
            dict.Remove(treeView1.SelectedNode.Text);
            dict.Add(textBox1.Text, leftSide);
            treeView1.SelectedNode.Text = textBox1.Text;
        }

        private void HideAll()
        {
            eventStuff.Hide();
            eventStuff.SendToBack();
            EventList.Hide();
            EventList.SendToBack();
            RulesetStuff.Hide();
            RulesetStuff.SendToBack();
        }

        // World Stuff

        private void ShowWorldProperties()
        {
            HideAll();
        }

        // Event Stuff

        private void ShowEventProperties()
        {
            HideAll();
        }

        // Custom Event Stuff

        private void button5_Click(object sender, EventArgs e)
        {
            HideAll();
            EventList.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            game.CustomEvents.Add(new CustomEvent { Name = EventName.Text });
            UpdateGroup();
        }
        private void button8_Click(object sender, EventArgs e) => UpdateGroup();

        private void button6_Click(object sender, EventArgs e)
        {
            CustomEvent customEvent = new CustomEvent { Name = EventName.Text };
            game.CustomEvents.Add(customEvent);
            if (selectedObject == null)
            {
                game.LeftSideObjects.Add(game.CustomEvents[game.CustomEvents.LastIndexOf(customEvent)]);
                rootnode.Nodes.Add(customEvent.Name);
            }
        }

        // Ruleset Stuff

        private void ShowRulesetProperties()
        {
            HideAll();
            RulesetStuff.Show();
        }

        private void tbName_TextChanged(object sender, EventArgs e) => game.Name = tbName.Text;

        private void tbStartAction_TextChanged(object sender, EventArgs e) => game.Executable = tbStartAction.Text;

        private void button3_Click(object sender, EventArgs e) => StartActionSelector.ShowDialog();

        private void StartActionSelector_FileOK(object sender, System.ComponentModel.CancelEventArgs e) => tbStartAction.Text = StartActionSelector.FileName;

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
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