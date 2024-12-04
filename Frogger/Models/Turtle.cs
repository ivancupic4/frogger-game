using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Turtle : MovingObject
    {
        static Direction Direction = Direction.Left;
        Width Width;
        Image Icon = Image.FromFile(Settings.IconsFolder + "turtle.png");

        public Turtle(Width width, int x, int y, int speed) 
            : base(x, y, speed, (int)width * Settings.BoxSize, Direction)
        {
            Width = width;
            FlipIfDirectionLeft(Direction, Icon);
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < (int)Width; i++)
            {
                g.DrawImage(Icon, X + i * Settings.BoxSize, Y, Settings.BoxSize, Settings.BoxSize);
            }
        }
    }
}
