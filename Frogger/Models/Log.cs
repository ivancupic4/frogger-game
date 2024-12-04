using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Log : MovingObject
    {
        static Direction Direction = Direction.Right;
        Width Width;
        Image Icon2 = Image.FromFile(Settings.IconsFolder + "log-2.png");
        Image Icon4 = Image.FromFile(Settings.IconsFolder + "log-4.png");
        Image Icon6 = Image.FromFile(Settings.IconsFolder + "log-6.png");

        public Log(Width width, int startingX, int startingY, int speed)
            : base(startingX, startingY, speed, (int)width * Settings.BoxSize, Direction)
        {
            Width = width;
        }

        public override void Draw(Graphics g)
        {
            var icon = Width == Width.Short ? Icon2 :
                       Width == Width.Medium ? Icon4 :
                       Width == Width.Long ? Icon6 : null;
            base.Draw(g, icon);
        }
    }
}
