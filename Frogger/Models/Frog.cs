using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class Frog
    {
        public int X = 400;
        public int Y = 700;
        Image FrogImage = Image.FromFile("..\\..\\..\\Icons\\frog.png");
        Image FrogDeadImage = Image.FromFile("..\\..\\..\\Icons\\frog-dead.png");

        public void Draw(Graphics g)
        {
            g.DrawImage(FrogImage, X, Y, Settings.BoxSize, Settings.BoxSize);
        }
    }
}
