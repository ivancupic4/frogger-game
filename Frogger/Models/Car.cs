using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class Car
    {
        public int X = 0;
        public int Y = 0;
        public int Speed = 5;
        Direction Direction;
        Image CarImage = Image.FromFile("..\\..\\..\\Icons\\car-icon.png");

        public Car(Direction direction, int startingY) 
        {
            Y = startingY;
            Direction = direction;
            if (direction == Direction.Right)
            {
                X = -Settings.BoxSize;
            }
            else
            {
                X = Settings.WindowWidth;
                CarImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(CarImage, X, Y, Settings.BoxSize, Settings.BoxSize);
        }

        public void Update()
        {
            if (Direction == Direction.Right)
            {
                X += Speed;
                if (X > Settings.WindowWidth)
                    X = -Settings.BoxSize;
            }
            if (Direction == Direction.Left)
            {
                X -= Speed;
                if (X < -Settings.BoxSize)
                    X = Settings.WindowWidth;
            }

        }
    }
}
