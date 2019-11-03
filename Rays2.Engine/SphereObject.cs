using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public class SphereObject : IObject
    {
        public IMaterial Material { get; set; }

        public Point Center { get; set; }
        public double Radius { get; set; }

        public bool TryIntersectWith(Ray ray, out Ray intersectionNormal)
        {
            var toCenter = (Center - ray.Origin);
            var closestApproach = toCenter.ProjectedOn(ray);
            var radial = closestApproach - Center;
            if (radial.Magnitude > Radius)
            {
                intersectionNormal = new Ray();
                return false;
            }

            var intersection = closestApproach.AtDistanceToward(ray.Origin, Math.Sqrt(Radius * Radius - radial.SqrMagnitude));
            intersectionNormal = new Ray()
            {
                Origin = intersection,
                Direction = (intersection - Center).Unit
            };
            return true;
        }
    }
}
