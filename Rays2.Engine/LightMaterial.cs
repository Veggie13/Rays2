using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public class LightMaterial : IMaterial
    {
        public LightSpectrum GlowSpectrum { get; set; }

        public void CompleteTrace(RayTracer tracer, RayTrace incidentTrace, Ray intersectionNormal)
        {
            incidentTrace.Spectrum = GlowSpectrum;
            incidentTrace.Terminator = intersectionNormal.Origin;
        }
    }
}
