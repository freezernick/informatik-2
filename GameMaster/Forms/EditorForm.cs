﻿using GameMaster.Forms.Editor;
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
            EditorHelper._editor = this;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e) => Configuration.Save(game);

        private void ToolStripButton3_Click(object sender, EventArgs e) => Close();

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

        private void BtTriggerDelete_Click(object sender, EventArgs e)
        {
            game.LeftSideObjects.Remove(selectedObject);
            treeView1.SelectedNode.Remove();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e) => selectedObject = dict[e.Node.Text];

        private void Button4_Click(object sender, EventArgs e)
        {
            new EventList().FormClosed += ToolClosure;
            Disable();
        }

        private void ToolClosure(object sender, EventArgs e) => Enabled = true;

        private void Button1_Click(object sender, EventArgs e)
        {
            new WorldList().FormClosed += ToolClosure;
            Disable();
        }

        private void Disable() => Enabled = false;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new EditForm().FormClosed += ToolClosure;
            Disable();
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