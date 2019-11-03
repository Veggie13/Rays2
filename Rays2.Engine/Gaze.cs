using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public struct Gaze
    {
        public Gaze(Ray pointer, UnitVector up)
        {
            Pointer = pointer;
            Right = pointer.Direction.Cross(up).Unit;
            Up = Right.Cross(pointer.Direction).Unit;
        }

        public Ray Pointer;
        public UnitVector Up;
        public UnitVector Right;

        public Matrix3 Rotation
        {
            get
            {
                return new Matrix3(Right.X, -Up.X, Pointer.Direction.X, Right.Y, -Up.Y, Pointer.Direction.Y, Right.Z, -Up.Z, Pointer.Direction.Z);
            }
        }
    }
}
