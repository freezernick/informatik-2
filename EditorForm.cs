using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
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
            MainForm NewWindow = new MainForm();
            NewWindow.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
