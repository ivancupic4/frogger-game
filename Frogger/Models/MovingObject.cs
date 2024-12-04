using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public abstract class MovingObject
    {
        public int X;
        public int Y;
        public int Speed;
        public int Width;
        public Direction Direction;

        public MovingObject(int x, int y, int speed, int width, Direction direction)
        {
            X = x;
            Y = y;
            Speed = speed;
            Width = width;
            Direction = direction;
        }

        public void Draw(Graphics g, Image icon)
        {
            g.DrawImage(icon, X, Y, Width, Settings.BoxSize);
        }

        public abstract void Draw(Graphics g);

        public Rectangle Rect() => new Rectangle(X, Y, Width, Settings.BoxSize);

        public void Move()
        {
            if (Direction == Direction.Right)
            {
                X += Speed;
                if (X > Settings.WindowWidth)
                    X = -Width;
            }
            if (Direction == Direction.Left)
            {
                X -= Speed;
                if (X < -Width)
                    X = Settings.WindowWidth;
            }
        }

        public void FlipIfDirectionLeft(Direction direction, Image icon)
        {
            if (direction == Direction.Left)
                icon.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
    }
}
