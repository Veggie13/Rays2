using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public interface IMaterial
    {
        void CompleteTrace(RayTracer tracer, RayTrace incidentTrace, Ray intersectionNormal);
    }
}
