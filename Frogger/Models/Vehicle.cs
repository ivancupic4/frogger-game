using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public abstract class Vehicle
    {
        public int X;
        public int Y;
        public int Speed;
        public int Width;
        Direction Direction;

        public Vehicle(Direction direction, int startingX, int startingY, int width, int speed)
        {
            X = startingX;
            Y = startingY;
            Speed = speed;
            Width = width;
            Direction = direction;
        }

        public abstract void Draw(Graphics g);

        public void DrawImage(Graphics g, Image icon)
        {
            g.DrawImage(icon, X, Y, Width, Settings.BoxSize);
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

        public void FlipIfDirectionLeft(Direction direction, Image icon)
        {
            if (direction == Direction.Left)
                icon.RotateFlip(RotateFlipType.Rotate180FlipY);
        }
    }

    public class Car1 : Vehicle
    {
        static int Speed = 6;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\car-1.png");

        public Car1(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }

    public class Car2 : Vehicle
    {
        static int Speed = 7;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\car-2.png");

        public Car2(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }

    public class SportCar1 : Vehicle
    {
        static int Speed = 10;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\sport-car-1.png");

        public SportCar1(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }

    public class SportCar2 : Vehicle
    {
        static int Speed = 11;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\sport-car-2.png");

        public SportCar2(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }

    public class Truck : Vehicle
    {
        static int Speed = 5;
        static int Width = Settings.BoxSize * 2;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\truck.png");

        public Truck(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }

    public class Bus : Vehicle
    {
        static int Speed = 6;
        static int Width = Settings.BoxSize * 2;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\bus.png");

        public Bus(Direction direction, int startingX, int startingY) : base(direction, startingX, startingY, Width, Speed)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
        {
            base.DrawImage(g, Icon);
        }
    }
}
