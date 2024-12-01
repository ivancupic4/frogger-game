using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Frog
    {
        const string FrogImageName = "frog.png";
        const string FrogDeadImageName = "frog-dead.png";
        public int X = Settings.FrogStartingX;
        public int Y = Settings.FrogStartingY;
        public bool Dead = false;
        public Image UpIcon;
        public Image DownIcon;
        public Image LeftIcon;
        public Image RightIcon;
        public Image UpDeadIcon;
        public Image DownDeadIcon;
        public Image LeftDeadIcon;
        public Image RightDeadIcon;
        public Image Icon;
        public Direction Direction;

        public Frog()
        {
            UpIcon = Image.FromFile(Settings.IconsFolder + FrogImageName);
            LeftIcon = (Image)UpIcon.Clone();
            LeftIcon.RotateFlip(RotateFlipType.Rotate270FlipNone);
            RightIcon = (Image)UpIcon.Clone();
            RightIcon.RotateFlip(RotateFlipType.Rotate90FlipNone);
            DownIcon = (Image)UpIcon.Clone();
            DownIcon.RotateFlip(RotateFlipType.RotateNoneFlipY);

            UpDeadIcon = Image.FromFile(Settings.IconsFolder + FrogDeadImageName);
            LeftDeadIcon = (Image)UpDeadIcon.Clone();
            LeftDeadIcon.RotateFlip(RotateFlipType.Rotate270FlipNone);
            RightDeadIcon = (Image)UpDeadIcon.Clone();
            RightDeadIcon.RotateFlip(RotateFlipType.Rotate90FlipNone);
            DownDeadIcon = (Image)UpDeadIcon.Clone();
            DownDeadIcon.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Icon = UpIcon;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Icon, X, Y, Settings.BoxSize, Settings.BoxSize);
        }

        public void MoveUp()
        {
            Icon = UpIcon;
            Direction = Direction.Up;
            if (Y - Settings.BoxSize >= 0)
                Y -= Settings.BoxSize;
        }
        public void MoveDown()
        {
            Icon = DownIcon;
            Direction = Direction.Down;
            if (Y + Settings.BoxSize < Settings.WindowHeight)
                Y += Settings.BoxSize;
        }
        public void MoveLeft()
        {
            Icon = LeftIcon;
            Direction = Direction.Left;
            if (X - Settings.BoxSize < 0)
                X = 0;
            else
                X -= Settings.BoxSize;
        }
        public void MoveRight() 
        { 
            Icon = RightIcon;
            Direction = Direction.Right;
            if (X + Settings.BoxSize * 2 > Settings.WindowWidth)
                X = Settings.WindowWidth - Settings.BoxSize;
            else
                X += Settings.BoxSize;
        }

        public Rectangle Rect() => new Rectangle(X, Y, Settings.BoxSize, Settings.BoxSize);

        public void Kill()
        {
            Dead = true;

            switch (Direction)
            {
                case Direction.Up: Icon = UpDeadIcon; break; 
                case Direction.Down: Icon = DownDeadIcon; break;
                case Direction.Left: Icon = LeftDeadIcon; break;
                case Direction.Right: Icon = RightDeadIcon; break;
            }
        }

        public void Reset()
        {
            Dead = false;
            X = Settings.FrogStartingX;
            Y = Settings.FrogStartingY;
            Icon = UpIcon;
        }

        public void MoveWithLog(Log log)
        {
            if (!Dead)
                X += log.Speed;
        }
    }
}