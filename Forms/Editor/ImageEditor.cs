using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace GameMaster.Forms.Editor
{
    public partial class ImageEditor : Form
    {
        public ImageEditor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.FileOk += fileSelected;
        }

        private Image image;

        private void fileSelected(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileInfo(openFileDialog1.FileName).OpenRead();
            image = Image.FromStream(fs);
            pictureBox1.Image = Utility.ResizeImage(image, pictureBox1.Width, pictureBox1.Height);
            fs.Close();
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
        }
    }
}