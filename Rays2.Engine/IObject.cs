using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public interface IObject
    {
        IMaterial Material { get; }

        bool TryIntersectWith(Ray ray, out Ray intersectionNormal);
    }
}
