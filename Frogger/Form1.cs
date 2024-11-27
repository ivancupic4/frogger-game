using System;
using Frogger.Models;

namespace Frogger
{
    public partial class Form1 : Form
    {
        Brush Green = Brushes.DarkGreen;
        Brush Blue = Brushes.DarkBlue;
        Brush Gray = Brushes.DarkGray;
        HashSet<Keys> PressedKeys = new HashSet<Keys>();
        Frog Frog = new Frog();
        VehicleManager VehicleManager = new VehicleManager();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Frogger by IvanWolf94";
            this.BackColor = Color.Black;
            this.ClientSize = new Size(Settings.WindowWidth, Settings.WindowHeight); // 16 x 15 grid
            this.DoubleBuffered = true; // To reduce flickering during rendering

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
            Frog.Draw(g);
            VehicleManager.DrawAndUpdateVehicles(g);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (PressedKeys.Contains(e.KeyCode))
                return;

            PressedKeys.Add(e.KeyCode);

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Frog.Y - Settings.BoxSize >= 0)
                        Frog.Y -= Settings.BoxSize;
                    break;
                case Keys.Down:
                    if (Frog.Y + Settings.BoxSize < Settings.WindowHeight)
                        Frog.Y += Settings.BoxSize;
                    break;
                case Keys.Left:
                    if (Frog.X - Settings.BoxSize >= 0)
                        Frog.X -= Settings.BoxSize;
                    break;
                case Keys.Right:
                    if (Frog.X + Settings.BoxSize < Settings.WindowWidth)
                        Frog.X += Settings.BoxSize;
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            PressedKeys.Remove(e.KeyCode);
        }

        public void DrawMap(Graphics g)
        {
            g.FillRectangle(Green, 0, 0, Settings.WindowWidth, Settings.BoxSize);

            g.FillRectangle(Green, 0, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize*2, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 3, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.BoxSize * 4, Settings.BoxSize, Settings.BoxSize * 2, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 6, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.BoxSize * 7, Settings.BoxSize, Settings.BoxSize * 2, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 9, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.BoxSize * 10, Settings.BoxSize, Settings.BoxSize * 2, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 12, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.BoxSize * 13, Settings.BoxSize, Settings.BoxSize * 2, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 15, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);

            g.FillRectangle(Blue, 0, Settings.BoxSize * 2, Settings.WindowWidth, 250);

            g.FillRectangle(Gray, 0, Settings.WindowHeight - Settings.BoxSize * 8, Settings.WindowWidth, Settings.BoxSize);
            g.FillRectangle(Gray, 0, Settings.WindowHeight - Settings.BoxSize, Settings.WindowWidth, Settings.BoxSize);
        }
    }
}