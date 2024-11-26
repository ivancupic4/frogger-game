using System;

namespace Frogger
{
    public partial class Form1 : Form
    {
        int BoxSize = 50;
        int FrogPositionX = 400;
        int FrogPositionY = 700;
        int WindowWidth = 800;
        int WindowHeight = 750;
        Brush Green = Brushes.DarkGreen;
        Brush Blue = Brushes.DarkBlue;
        Brush Purple = Brushes.Gray;
        private Image FrogImage;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Frogger by IvanWolf94";
            this.BackColor = Color.Black;
            this.ClientSize = new Size(WindowWidth, WindowHeight); // 16 x 15 grid
            this.DoubleBuffered = true; // To reduce flickering during rendering
            FrogImage = Image.FromFile("..\\..\\..\\icons\\frog-icon.png");

            var gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 16; // Approximately 60 FPS
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            Invalidate(); // Triggers a redraw
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            DrawMap(g);
            DrawFrog(g);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (FrogPositionY - BoxSize >= 0)
                        FrogPositionY -= BoxSize;
                    break;
                case Keys.Down:
                    if (FrogPositionY + BoxSize < WindowHeight)
                        FrogPositionY += BoxSize;
                    break;
                case Keys.Left:
                    if (FrogPositionX - BoxSize >= 0)
                        FrogPositionX -= BoxSize;
                    break;
                case Keys.Right:
                    if (FrogPositionX + BoxSize < WindowWidth)
                        FrogPositionX += BoxSize;
                    break;
            }
        }

        public void DrawFrog(Graphics g)
        {
            g.DrawImage(FrogImage, FrogPositionX, FrogPositionY, BoxSize, BoxSize);
        }

        public void DrawMap(Graphics g)
        {
            g.FillRectangle(Green, 0, 0, WindowWidth, BoxSize);

            g.FillRectangle(Green, 0, BoxSize, BoxSize, BoxSize);
            g.FillRectangle(Blue, BoxSize, BoxSize, BoxSize*2, BoxSize);
            g.FillRectangle(Green, BoxSize * 3, BoxSize, BoxSize, BoxSize);
            g.FillRectangle(Blue, BoxSize * 4, BoxSize, BoxSize * 2, BoxSize);
            g.FillRectangle(Green, BoxSize * 6, BoxSize, BoxSize, BoxSize);
            g.FillRectangle(Blue, BoxSize * 7, BoxSize, BoxSize * 2, BoxSize);
            g.FillRectangle(Green, BoxSize * 9, BoxSize, BoxSize, BoxSize);
            g.FillRectangle(Blue, BoxSize * 10, BoxSize, BoxSize * 2, BoxSize);
            g.FillRectangle(Green, BoxSize * 12, BoxSize, BoxSize, BoxSize);
            g.FillRectangle(Blue, BoxSize * 13, BoxSize, BoxSize * 2, BoxSize);
            g.FillRectangle(Green, BoxSize * 15, BoxSize, BoxSize, BoxSize);

            g.FillRectangle(Blue, 0, BoxSize * 2, WindowWidth, 250);

            g.FillRectangle(Purple, 0, WindowHeight - BoxSize * 8, WindowWidth, BoxSize);
            g.FillRectangle(Purple, 0, WindowHeight - BoxSize, WindowWidth, BoxSize);
        }
    }
}