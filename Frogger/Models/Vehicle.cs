using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class Vehicle
    {
        public int X = 0;
        public int Y = 0;
        public int Width = Settings.BoxSize;
        public int Speed = 5;
        Direction Direction;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\car-1.png");

        public Vehicle(VehicleType type, Direction direction, int startingY)
        {
            Y = startingY;
            Direction = direction;
            LoadImageForType(type);
            if (direction == Direction.Right)
            {
                X = -Settings.BoxSize;
            }
            else
            {
                X = Settings.WindowWidth;
                Icon.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Icon, X, Y, Width, Settings.BoxSize);
        }

        public void Update()
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

        public void LoadImageForType(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car1:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\car-1.png");
                    break;
                case VehicleType.Car2:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\car-2.png");
                    break;
                case VehicleType.SportCar1:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\sport-car-1.png");
                    break;
                case VehicleType.SportCar2:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\sport-car-2.png");
                    break;
                case VehicleType.Truck:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\truck.png");
                    Width = Settings.BoxSize * 2;
                    break;
                case VehicleType.Bus:
                    Icon = Image.FromFile("..\\..\\..\\Icons\\bus.png");
                    Width = Settings.BoxSize * 2;
                    break;
            }
        }
    }
}
