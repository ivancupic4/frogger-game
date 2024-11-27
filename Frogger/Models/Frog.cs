using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class Frog
    {
        public int X = Settings.FrogStartingX;
        public int Y = Settings.FrogStartingY;
        Image Icon = Image.FromFile("..\\..\\..\\Icons\\frog.png");
        public bool Dead = false;

        public void Draw(Graphics g)
        {
            g.DrawImage(Icon, X, Y, Settings.BoxSize, Settings.BoxSize);
        }

        public void Kill()
        {
            Dead = true;
            Icon = Image.FromFile("..\\..\\..\\Icons\\frog-dead.png");
        }

        public void Reset()
        {
            Dead = false;
            X = Settings.FrogStartingX;
            Y = Settings.FrogStartingY;
            Icon = Image.FromFile("..\\..\\..\\Icons\\frog.png");
        }
    }
}
