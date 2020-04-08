﻿using GameMaster.Forms.Editor;
using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        public Configuration game;
        public LeftSide selectedObject;

        public EditorForm()
        {
            InitializeComponent();
            game = MainFormHelper.Get().SelectedRuleset;
        }

        private void ObjectListForm_Load(object sender, EventArgs e) => UpdateList();

        private void btExit_Click(object sender, EventArgs e)
        {
            MainFormHelper.Show();
            Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new EditForm().Show();
            Close();
        }

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
            MainFormHelper.Show();
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
                TreeNode node = treeView1.Nodes.Add(leftSideObject.Name);
                if(leftSideObject is World)
                {
                    foreach(Event @event in ((World)leftSideObject).WorldEvents)
                    {
                        if (@event is CustomEvent)
                        {
                            CustomEvent customEvent = (CustomEvent)@event;
                            node.Nodes.Add(customEvent.Alias);
                            continue;
                        }
                        TreeNode subnode = node.Nodes.Add(@event.Name);

                        foreach(RightSide rightSide in @event.EventObjects)
                        {
                            subnode.Nodes.Add(rightSide.Name);
                        }
                    }
                }

                if(leftSideObject is Event)
                {
                    Event @event = (Event) leftSideObject;
                    if (@event is CustomEvent)
                    {
                        CustomEvent customEvent = (CustomEvent)@event;
                        node.Nodes.Add(customEvent.Alias);
                        continue;
                    }
                    TreeNode subnode = node.Nodes.Add(@event.Name);

                    foreach (RightSide rightSide in @event.EventObjects)
                    {
                        subnode.Nodes.Add(rightSide.Name);
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

            Actions actions = new Actions(selectedObject);
            actions.FormClosed += ActionList_Closed;
            actions.game = game;
            actions.Show();
            Hide();
        }

        private void ActionList_Closed(object sender, EventArgs e) => Show();

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ImageEditor editor = new ImageEditor();
            Hide();
            editor.FormClosed += imageeditor_closed;
            editor.Show();
        }

        private void imageeditor_closed(object sender, EventArgs e)
        {
            Show();
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