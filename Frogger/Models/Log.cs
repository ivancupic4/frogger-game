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
        LogWidth WidthEnum;
        Image Icon2 = Image.FromFile(Settings.IconsFolder + "log-2.png");
        Image Icon4 = Image.FromFile(Settings.IconsFolder + "log-4.png");
        Image Icon6 = Image.FromFile(Settings.IconsFolder + "log-6.png");

        public Log(LogWidth width, int startingX, int startingY, int speed)
            : base(startingX, startingY, speed, (int)width, Direction)
        {
            WidthEnum = width;
        }

        public void Draw(Graphics g)
        {
            var icon = WidthEnum == LogWidth.Short ? Icon2 :
                       WidthEnum == LogWidth.Medium ? Icon4 : 
                       WidthEnum == LogWidth.Long ? Icon6 : null;
            base.Draw(g, icon);
        }
    }
}
