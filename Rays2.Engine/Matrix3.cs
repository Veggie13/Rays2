using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public struct Matrix3
    {
        private double[,] _cells;

        public Matrix3(double cell00, double cell01, double cell02, double cell10, double cell11, double cell12, double cell20, double cell21, double cell22)
        {
            _cells = new double[3, 3]
            {
                { cell00, cell01, cell02 },
                { cell10, cell11, cell12 },
                { cell20, cell21, cell22 }
            };
        }

        public double this[int row, int col]
        {
            get { return _cells[row, col]; }
        }

        public static Vector operator *(Matrix3 m, Vector v)
        {
            return new Vector()
            {
                X = m[0, 0] * v.X + m[0, 1] * v.Y + m[0, 2] * v.Z,
                Y = m[1, 0] * v.X + m[1, 1] * v.Y + m[1, 2] * v.Z,
                Z = m[2, 0] * v.X + m[2, 1] * v.Y + m[2, 2] * v.Z
            };
        }
    }
}
