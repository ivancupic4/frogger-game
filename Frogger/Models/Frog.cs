using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Frog
    {
        public int X = Settings.FrogStartingX;
        public int Y = Settings.FrogStartingY;
        public bool Dead = false;
        Image AliveIcon = Image.FromFile("..\\..\\..\\Icons\\frog.png");
        Image DeadIcon = Image.FromFile("..\\..\\..\\Icons\\frog-dead.png");
        Image Icon = null;

        public Frog() 
        {
            Icon = AliveIcon;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Icon, X, Y, Settings.BoxSize, Settings.BoxSize);
        }

        public void Kill()
        {
            Dead = true;
            Icon = DeadIcon;
        }

        public void Reset()
        {
            Dead = false;
            X = Settings.FrogStartingX;
            Y = Settings.FrogStartingY;
            Icon = AliveIcon;
        }
    }
}
