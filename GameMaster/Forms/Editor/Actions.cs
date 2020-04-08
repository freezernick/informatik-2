using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameMaster.Interfaces;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster.Forms.Editor
{
    public partial class Actions : GameMaster.EditorWindow
    {
        private LeftSide selected;
        public Actions(LeftSide selectedObject)
        {
            InitializeComponent();
            selected = selectedObject;
        }

        private void Actions_Load(object sender, EventArgs e)
        {
            foreach(Type action in Utility.FindSubClassesOf<RightSide>())
            {
                listBox1.Items.Add(action);
            }
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            IObjectRegister selectedObject = selected as IObjectRegister;
            if (selectedObject != null)
            {
                RightSide rightSideObject = (RightSide) Activator.CreateInstance((Type)listBox1.SelectedItem);
                if(rightSideObject == null)
                {
                    return;
                }
                selectedObject.RegisterObject(rightSideObject);
            }
        }
    }
}
