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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MainForm NewWindow = new MainForm();
            NewWindow.Show();
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
          
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
