using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public struct UnitVector
    {
        public static readonly UnitVector I = new UnitVector() { X = 1, Y = 0, Z = 0 };
        public static readonly UnitVector J = new UnitVector() { X = 0, Y = 1, Z = 0 };
        public static readonly UnitVector K = new UnitVector() { X = 0, Y = 0, Z = 1 };

        public UnitVector(Vector v)
        {
            var unit = v / v.Magnitude;
            X = unit.X;
            Y = unit.Y;
            Z = unit.Z;
        }

        public double X;
        public double Y;
        public double Z;

        public static implicit operator Vector(UnitVector uv)
        {
            return new Vector()
            {
                X = uv.X,
                Y = uv.Y,
                Z = uv.Z
            };
        }

        public static UnitVector operator -(UnitVector uv)
        {
            return new UnitVector()
            {
                X = -uv.X,
                Y = -uv.Y,
                Z = -uv.Z
            };
        }

        public static Vector operator *(double scalar, UnitVector uv)
        {
            return scalar * (Vector)uv;
        }

        public Vector Cross(Vector rhs)
        {
            return ((Vector)this).Cross(rhs);
        }

        public double Dot(Vector rhs)
        {
            return ((Vector)this).Dot(rhs);
        }

        public Vector ProjectedOn(Vector rhs)
        {
            return ((Vector)this).ProjectedOn(rhs);
        }

        public Point ProjectedOn(Ray r)
        {
            return ((Vector)this).ProjectedOn(r);
        }

        public override string ToString()
        {
            return $"U({X},{Y},{Z})";
        }
    }
}
