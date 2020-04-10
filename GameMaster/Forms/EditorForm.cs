using GameMaster.Forms.Editor;
using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;
using System.Collections.Generic;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        public Configuration game;
        public LeftSide selectedObject;
        public Dictionary<string, LeftSide> dict;

        public EditorForm()
        {
            InitializeComponent();
            game = MainFormHelper.Get().SelectedRuleset;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) => Configuration.Save(game);

        private void toolStripButton3_Click(object sender, EventArgs e) => Close();

        private void EditorForm_Load(object sender, EventArgs e)
        {
            dict = new Dictionary<string, LeftSide>();
            TreeNode rootnode = treeView1.Nodes.Add(game.Name);
            foreach(LeftSide leftSide in game.LeftSideObjects)
            {
                dict.Add(leftSide.Name, leftSide);
                rootnode.Nodes.Add(leftSide.Name);
            }

            treeView1.ExpandAll();
        }

        private void btTriggerDelete_Click(object sender, EventArgs e)
        {
            game.LeftSideObjects.Remove(selectedObject);
            treeView1.SelectedNode.Remove();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) => selectedObject = dict[e.Node.Text];
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