using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public struct Ray
    {
        public Point Origin;
        public UnitVector Direction;

        public Point Follow(double distance)
        {
            return Origin + distance * Direction;
        }
    }
}
