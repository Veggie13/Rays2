using System;

namespace Rays2.Engine
{
    public struct Vector
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X;
        public double Y;
        public double Z;

        public double Magnitude
        {
            get { return Math.Sqrt(Dot(this)); }
        }

        public double SqrMagnitude
        {
            get { return Dot(this); }
        }

        public UnitVector Unit
        {
            get { return new UnitVector(this); }
        }

        public static Vector operator *(double scalar, Vector v)
        {
            return new Vector()
            {
                X = v.X * scalar,
                Y = v.Y * scalar,
                Z = v.Z * scalar
            };
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return scalar * v;
        }

        public static Vector operator /(Vector v, double denominator)
        {
            return (1 / denominator) * v;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X + b.Y,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z
            };
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X - b.Y,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z
            };
        }

        public static Vector operator -(Vector v)
        {
            return new Vector()
            {
                X = -v.X,
                Y = -v.Y,
                Z = -v.Z
            };
        }

        public Vector Cross(Vector rhs)
        {
            return new Vector()
            {
                X = Y * rhs.Z - Z * rhs.Y,
                Y = Z * rhs.X - X * rhs.Z,
                Z = X * rhs.Y - Y * rhs.X
            };
        }

        public double Dot(Vector rhs)
        {
            return X * rhs.X + Y * rhs.Y + Z * rhs.Z;
        }

        public Vector ReflectedIn(UnitVector normal)
        {
            return this - (2 * Dot(normal)) * normal;
        }

        public Vector ProjectedOn(Vector rhs)
        {
            return Dot(rhs) * rhs.Unit;
        }

        public Point ProjectedOn(Ray r)
        {
            return r.Origin + ProjectedOn(r.Direction);
        }

        public override string ToString()
        {
            return $"V({X},{Y},{Z})";
        }
    }
}
