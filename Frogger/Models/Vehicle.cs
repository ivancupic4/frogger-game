using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public abstract class Vehicle : MovingObject
    {
        public Vehicle(int startingX, int startingY, int width, int speed, Direction direction) 
            : base(startingX, startingY, width, speed, direction) { }

        public abstract void Draw(Graphics g);
    }

    public class Car1 : Vehicle
    {
        static int Speed = 6;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile(Settings.IconsFolder + "car-1.png");

        public Car1(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
            => Draw(g, Icon);
    }

    public class Car2 : Vehicle
    {
        static int Speed = 7;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile(Settings.IconsFolder + "car-2.png");

        public Car2(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
            => Draw(g, Icon);
    }

    public class SportCar1 : Vehicle
    {
        static int Speed = 10;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile(Settings.IconsFolder + "sport-car-1.png");

        public SportCar1(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
            => Draw(g, Icon);
    }

    public class SportCar2 : Vehicle
    {
        static int Speed = 11;
        static int Width = Settings.BoxSize;
        Image Icon = Image.FromFile(Settings.IconsFolder + "sport-car-2.png");

        public SportCar2(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
            => Draw(g, Icon);
    }

    public class Truck : Vehicle
    {
        static int Speed = 5;
        static int Width = Settings.BoxSize * 2;
        Image Icon = Image.FromFile(Settings.IconsFolder + "truck.png");

        public Truck(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g) 
            => Draw(g, Icon);
    }

    public class Bus : Vehicle
    {
        static int Speed = 6;
        static int Width = Settings.BoxSize * 2;
        Image Icon = Image.FromFile(Settings.IconsFolder + "bus.png");

        public Bus(Direction direction, int startingX, int startingY) 
            : base(startingX, startingY, Speed, Width, direction)
        {
            FlipIfDirectionLeft(direction, Icon);
        }

        public override void Draw(Graphics g)
            => Draw(g, Icon);
    }
}
