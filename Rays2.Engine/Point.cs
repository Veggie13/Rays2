using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public struct Point
    {
        public static readonly Point Origin = new Point(0, 0, 0);

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X;
        public double Y;
        public double Z;

        public static Point operator +(Point p, Vector v)
        {
            return new Point()
            {
                X = p.X + v.X,
                Y = p.Y + v.Y,
                Z = p.Z + v.Z
            };
        }

        public static Vector operator -(Point a, Point b)
        {
            return new Vector()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z
            };
        }

        public Ray RayThrough(Point p)
        {
            return new Ray()
            {
                Origin = this,
                Direction = (p - this).Unit
            };
        }

        public Point AtDistanceToward(Point p, double distance)
        {
            return this + distance * (p - this).Unit;
        }

        public override string ToString()
        {
            return $"P({X},{Y},{Z})";
        }
    }
}
