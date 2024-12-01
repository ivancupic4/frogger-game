using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum LogWidth
    {
        Short = Settings.BoxSize * 2,
        Medium = Settings.BoxSize * 4,
        Long = Settings.BoxSize * 6
    }
}
