using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Log
    {
        public int X;
        public int Y;
        public int Speed;
        public int Width;
        Direction Direction;
        

        public Log(Direction direction, int startingX, int startingY, int width, int speed)
        {
            X = startingX;
            Y = startingY;
            Speed = speed;
            Width = width;
            Direction = direction;
        }

        public void Draw(Graphics g)
        {
            //var icon = ;
            //g.DrawImage(icon, X, Y, Width, Settings.BoxSize);
        }

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
    }
}
