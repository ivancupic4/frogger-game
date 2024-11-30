using System;
using Frogger.Models;

namespace Frogger
{
    public partial class Form1 : Form
    {
        Frog Frog = new Frog();
        HashSet<Keys> PressedKeys = new HashSet<Keys>();
        MovingObjectManager MovingObjectManager = new MovingObjectManager();
        List<Rectangle> RemainingEndGameAreas = new List<Rectangle> (Settings.EndGameAreas);
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Frogger by IvanWolf94";
            this.BackColor = Color.Black;
            this.ClientSize = new Size(Settings.WindowWidth, Settings.WindowHeight);
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
            g = e.Graphics;

            DrawMap(g);
            MovingObjectManager.DrawAndUpdateLogs(g);
            Frog.Draw(g);
            MovingObjectManager.DrawAndUpdateVehicles(g);

            DrawEndGameWaterLillyFrogs();
            CollisionCheck();
        }

        public void CollisionCheck()
        {
            foreach (var vehicle in MovingObjectManager.Vehicles.Where(v => v.Y == Frog.Y))
            {
                if (IsColliding(vehicle.Rect(), Frog.Rect()))
                     Frog.Kill();
            }

            var isFrogInWaterArea = IsColliding(Settings.WaterAreaRect, Frog.Rect());
            var isFrogOnLog = false;
            foreach (var log in MovingObjectManager.Logs.Where(l => l.Y == Frog.Y))
            {
                if (IsColliding(log.Rect(), Frog.Rect()))
                {
                    isFrogOnLog = true;
                    Frog.MoveWithLog(log);
                    break;
                }
            }

            var frogOutOfMapBounds = Frog.X + Settings.BoxSize / 2 > Settings.WindowWidth;
            if ((isFrogInWaterArea && !isFrogOnLog) || frogOutOfMapBounds)
                Frog.Kill();
        }

        public void EndGameAreaCheck()
        {
            foreach (var areaRect in RemainingEndGameAreas)
            {
                if (IsColliding(areaRect, Frog.Rect()))
                {
                    RemainingEndGameAreas.Remove(areaRect);
                    Frog.Reset();
                    break;
                }
            }
        }

        private void DrawEndGameWaterLillyFrogs()
        {
            var icon = new Frog().AliveIcon;
            icon.RotateFlip(RotateFlipType.Rotate180FlipX);
            var frogsOnWaterLillies = new List<Rectangle> (Settings.EndGameAreas);
            frogsOnWaterLillies.RemoveAll(RemainingEndGameAreas.Contains);
            foreach (var areaRect in frogsOnWaterLillies)
            {
                int middleOfEndGameRectangle = areaRect.X + (areaRect.Width / 2 - Settings.BoxSize / 2);
                g.DrawImage(icon, middleOfEndGameRectangle, areaRect.Y, Settings.BoxSize, Settings.BoxSize);
            }
        }

        private bool IsColliding(Rectangle rect1, Rectangle rect2)
            => rect1.X + rect1.Width > rect2.X &&
               rect2.X + rect2.Width > rect1.X &&
               rect1.Y + rect1.Height > rect2.Y &&
               rect2.Y + rect2.Height > rect1.Y;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Frog.Reset();

            if (PressedKeys.Contains(e.KeyCode) || Frog.Dead)
                return;

            base.OnKeyDown(e);

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
                    if (Frog.X - Settings.BoxSize < 0)
                        Frog.X = 0;
                    else
                        Frog.X -= Settings.BoxSize;
                    break;
                case Keys.Right:
                    if (Frog.X + Settings.BoxSize * 2 > Settings.WindowWidth)
                        Frog.X = Settings.WindowWidth - Settings.BoxSize;
                    else
                        Frog.X += Settings.BoxSize;
                    break;
            }

            EndGameAreaCheck();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            PressedKeys.Remove(e.KeyCode);
        }

        public void DrawMap(Graphics g)
        {
            Brush Green = Brushes.DarkGreen;
            Brush Blue = Brushes.DarkBlue;
            Brush Gray = Brushes.DarkGray;

            g.FillRectangle(Green, 0, 0, Settings.WindowWidth, Settings.BoxSize);
            g.FillRectangle(Blue, Settings.WaterAreaRect);

            g.FillRectangle(Green, 0, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 3, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 6, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 9, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 12, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);
            g.FillRectangle(Green, Settings.BoxSize * 15, Settings.BoxSize, Settings.BoxSize, Settings.BoxSize);

            g.FillRectangle(Gray, 0, Settings.WindowHeight - Settings.BoxSize * 8, Settings.WindowWidth, Settings.BoxSize);
            g.FillRectangle(Gray, 0, Settings.WindowHeight - Settings.BoxSize, Settings.WindowWidth, Settings.BoxSize);
        }
    }
}