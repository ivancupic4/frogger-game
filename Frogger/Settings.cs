using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    internal static class Settings
    {
        public const int BoxSize = 50;
        public const int WindowWidth = 800; //BoxSize * 16
        public const int WindowHeight = 750; //BoxSize * 15
        public const int FrogStartingX = 400;
        public const int FrogStartingY = 700;
        public static string IconsFolder = "..\\..\\..\\Icons\\";
        public static Rectangle WaterAreaRect = new Rectangle(0, BoxSize, Settings.WindowWidth, 300);
        public static List<Rectangle> EndGameAreas = new List<Rectangle>
        {
            new Rectangle (BoxSize * 1, BoxSize, BoxSize * 2, BoxSize),
            new Rectangle (BoxSize * 4, BoxSize, BoxSize * 2, BoxSize),
            new Rectangle (BoxSize * 7, BoxSize, BoxSize * 2, BoxSize),
            new Rectangle (BoxSize * 10, BoxSize, BoxSize * 2, BoxSize),
            new Rectangle (BoxSize * 13, BoxSize, BoxSize * 2, BoxSize),
        };
    }
}
