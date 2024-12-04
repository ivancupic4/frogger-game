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

    public enum Width
    {
        Short = 2,
        Medium = 3,
        Long = 4
    }

    public enum MovingObjectType
    {
        Log,
        Turtle,
        Vehicle
    }
}
