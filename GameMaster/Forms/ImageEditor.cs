using GameMaster.Ruleset.Abstracts;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameMaster.Ruleset.Worlds;

namespace GameMaster.Forms.Editor
{
    public partial class ImageEditor : Form
    {
        private object Object;
        private World.ImageRecognition item;
        private Image loadedImage;
        private Bitmap @new;
        private int x;
        private int y;
        private int width;
        private int height;
        private Pen CropPen = new Pen(Color.Red);
        private bool cropping = false;

        public ImageEditor(object selectedObject = null)
        {
            InitializeComponent();
            Object = selectedObject;
        }

        ~ImageEditor()
        {
            CropPen.Dispose();
            loadedImage.Dispose();
            @new.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.FileOk += fileSelected;
        }

        private void fileSelected(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileInfo(openFileDialog1.FileName).OpenRead();
            loadedImage = Image.FromStream(fs);
            pictureBox1.Image = Utility.ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height);
            fs.Close();
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Utility.RulesetDirectory;
            cropWindow = pictureBox1.CreateGraphics();

            if(Object is GameWorld)
            {
                GameWorld world = (GameWorld)Object;
                if (world.WorldReference.reference.Name != "")
                {
                    Bitmap OldImage = new Bitmap(Utility.ImageDirectory + world.WorldReference.reference.Name);
                    if(OldImage == null)
                        return;

                    pictureBox1.Image = Utility.ResizeImage(OldImage, pictureBox1.Width, pictureBox1.Height);
                    pictureBox2.Image = Utility.ResizeImage(OldImage, pictureBox2.Width, pictureBox2.Height);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //item.UpdateReference(@new);
            pictureBox2.Image = pictureBox2.Image;
            pictureBox3.Image = null;
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            cropping = true;
        }

        private Rectangle Selection;

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (loadedImage == null)
                return;

            width = e.X - x;
            height = e.Y - y;
            if (width > 0 && height > 0)
            {
                Selection = new Rectangle(x, y, width, height);
                Bitmap test = Utility.ResizeImage(new Bitmap(loadedImage), pictureBox1.Width, pictureBox1.Height);
                @new = test.Clone(Selection, loadedImage.PixelFormat);
                pictureBox3.Image = @new;
            }
            Reset();
        }

        private void Reset()
        {
            cropping = false;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
        }

        private Graphics cropWindow;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cropping && loadedImage != null)
            {
                cropWindow = pictureBox1.CreateGraphics();
                cropWindow.DrawImage(Utility.ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height), new Point(0, 0));
                width = e.X - x;
                height = e.Y - y;
                cropWindow.DrawRectangle(CropPen, x, y, width, height);
            }
        }
    }
}