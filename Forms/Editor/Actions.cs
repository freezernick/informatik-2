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
        public Actions() => InitializeComponent();

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
            IObjectRegister selectedObject = FormHandler.Get<EditorForm>().selectedObject as IObjectRegister;
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
