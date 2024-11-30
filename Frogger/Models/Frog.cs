using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class Frog
    {
        const string FrogImageName = "frog.png";
        const string FrogDeadImageName = "frog-dead.png";
        public int X = Settings.FrogStartingX;
        public int Y = Settings.FrogStartingY;
        public bool Dead = false;
        public Image AliveIcon = Image.FromFile(Settings.IconsFolder + FrogImageName);
        public Image EndGameIcon;
        Image DeadIcon = Image.FromFile(Settings.IconsFolder + FrogDeadImageName);
        Image Icon = null;

        public Frog()
        {
            Icon = AliveIcon;
            EndGameIcon = Image.FromFile(Settings.IconsFolder + FrogImageName);
            EndGameIcon.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Icon, X, Y, Settings.BoxSize, Settings.BoxSize);
        }

        public Rectangle Rect()
            => new Rectangle(X, Y, Settings.BoxSize, Settings.BoxSize);

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

        public void MoveWithLog(Log log)
        {
            if (Dead)
                return;
            X += log.Speed;
        }
    }
}
