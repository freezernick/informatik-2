using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGame
{
    public partial class Collector : Form
    {
        private readonly MainForm Main;

        private bool RunningDown = false;
        private bool RunningUp = false;
        private bool RunningLeft = false;
        private bool RunningRight = false;

        private Rectangle Obstalce;
        private Rectangle Goal;
        private readonly Random Random = new Random();

        private int Score = 0;

        public Collector(MainForm main)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
            KeyDown += KeyPress;
            KeyUp += KeyRelease;
            Obstalce = new Rectangle(
                ObstaclePanel.Location.X,
                ObstaclePanel.Location.Y,
                ObstaclePanel.Width,
                ObstaclePanel.Height

            );
            Goal = new Rectangle(
               GoalPanel.Location.X,
               GoalPanel.Location.Y,
               GoalPanel.Width,
               GoalPanel.Height

            );

            Main = main;
        }

        private bool CheckMovement(Point NextLocation)
        {
            if (NextLocation.X >= 586 || NextLocation.X < 0 || NextLocation.Y >= 449 || NextLocation.Y < 0)
                return false;

            if (Obstalce.Contains(NextLocation))
                return false;

            if (Goal.Contains(NextLocation))
            {
                Point NewLocation = new Point(Random.Next(0, this.Size.Width - GoalPanel.Width), Random.Next(0, this.Size.Height - GoalPanel.Height));
                while (Obstalce.Contains(NewLocation.X, NewLocation.Y))
                {
                    NewLocation = new Point(Random.Next(0, this.Size.Width), Random.Next(0, this.Size.Height));
                }
                GoalPanel.Location = NewLocation;
                Goal = new Rectangle(
                   GoalPanel.Location.X,
                   GoalPanel.Location.Y,
                   GoalPanel.Width,
                   GoalPanel.Height
                );
                Score++;
            }
            return true;
        }

        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                RunningUp = true;
            if (e.KeyCode == Keys.S)
                RunningDown = true;
            if (e.KeyCode == Keys.A)
                RunningLeft = true;
            if (e.KeyCode == Keys.D)
                RunningRight = true;
            if (e.KeyCode == Keys.OemMinus)
                Environment.Exit(1);

            if (e.KeyCode == Keys.Oemplus)
            {
                Close();
                Main.Show();
            }
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
            Point NextLocation = new Point(PlayerPanel.Location.X, PlayerPanel.Location.Y - 3);
            if (CheckMovement(NextLocation))
                PlayerPanel.Location = NextLocation;
        }

        private void GoDown()
        {
            Point NextLocation = new Point(PlayerPanel.Location.X, PlayerPanel.Location.Y + 3);
            if (CheckMovement(new Point(NextLocation.X, NextLocation.Y + PlayerPanel.Height)))
                PlayerPanel.Location = NextLocation;
        }

        private void GoLeft()
        {
            Point NextLocation = new Point(PlayerPanel.Location.X - 3, PlayerPanel.Location.Y);
            if (CheckMovement(NextLocation))
                PlayerPanel.Location = NextLocation;
        }

        private void GoRight()
        {
            Point NextLocation = new Point(PlayerPanel.Location.X + 3, PlayerPanel.Location.Y);
            if (CheckMovement(new Point(NextLocation.X + PlayerPanel.Width, NextLocation.Y)))
                PlayerPanel.Location = NextLocation;
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