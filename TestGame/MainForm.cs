using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            Hide();
            FormHandler.Collector().Show();
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
