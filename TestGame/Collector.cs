using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGame
{
    public partial class Collector : GameForm
    {
        private bool RunningDown = false;
        private bool RunningUp = false;
        private bool RunningLeft = false;
        private bool RunningRight = false;

        private Rectangle obstacle;
        private Rectangle Goal;
        private Random RDM = new Random();

        private int Score = 0;

        private bool CheckMovement(Point NextLocation)
        {
            if (NextLocation.X >= 586 || NextLocation.X < 0 || NextLocation.Y >= 449 || NextLocation.Y < 0)
            {
                label1.Text = "Fuck";
                return false;
            }
            if (obstacle.Contains(NextLocation))
                return false;

            if (Goal.Contains(NextLocation))
            {
                Point NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
                while (obstacle.Contains(NewLocation.X, NewLocation.Y))
                {
                    NewLocation = new Point(RDM.Next(0, this.Size.Width), RDM.Next(0, this.Size.Height));
                }
                panel3.Location = NewLocation;
                Goal = new Rectangle(
                   panel3.Location.X,
                   panel3.Location.Y,
                   panel3.Width,
                   panel3.Height
                );
                Score++;
            }
            return true;
        }

        public Collector()
        {
            InitializeComponent();
            KeyDown += KeyPress;
            KeyUp += KeyRelease;
            obstacle = new Rectangle(
                panel2.Location.X,
                panel2.Location.Y,
                panel2.Width,
                panel2.Height

            );
            Goal = new Rectangle(
               panel3.Location.X,
               panel3.Location.Y,
               panel3.Width,
               panel3.Height

            );
        }

        private void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = true;
            if (e.KeyCode == Keys.S)
                RunningDown = true;
            if (e.KeyCode == Keys.A)
                RunningLeft = true;
            if (e.KeyCode == Keys.D)
                RunningRight = true;
        }

        private void KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = false;
            if (e.KeyCode == Keys.S)
                RunningDown = false;
            if (e.KeyCode == Keys.A)
                RunningLeft = false;
            if (e.KeyCode == Keys.D)
                RunningRight = false;
        }

        private void GoUp()
        {
            Point NextLocation = new Point(panel1.Location.X, panel1.Location.Y - 3);
            if (CheckMovement(NextLocation))
                panel1.Location = NextLocation;
        }

        private void GoDown()
        {
            Point NextLocation = new Point(panel1.Location.X, panel1.Location.Y + 3);
            if (CheckMovement(new Point(NextLocation.X, NextLocation.Y + panel1.Height)))
                panel1.Location = NextLocation;
        }

        private void GoLeft()
        {
            Point NextLocation = new Point(panel1.Location.X - 3, panel1.Location.Y);
            if (CheckMovement(NextLocation))
                panel1.Location = NextLocation;
        }

        private void GoRight()
        {
            Point NextLocation = new Point(panel1.Location.X + 3, panel1.Location.Y);
            if (CheckMovement(new Point(NextLocation.X + panel1.Width, NextLocation.Y)))
                panel1.Location = NextLocation;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"Score: {Score.ToString()}";

            if (RunningUp == true)
                GoUp();
            if (RunningDown == true)
                GoDown();
            if (RunningLeft == true)
                GoLeft();
            if (RunningRight == true)
                GoRight();
        }
    }
}