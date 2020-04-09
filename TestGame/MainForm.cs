using System;
using System.Windows.Forms;

namespace TestGame
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        private void BtStart_Click(object sender, EventArgs e)
        {
            Hide();
            new Collector(this).Show();
        }

        private void BtExit_Click(object sender, EventArgs e) => Close();
    }
}