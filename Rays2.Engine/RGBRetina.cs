using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public abstract class RGBRetina<TRGBColor> : IRetina<TRGBColor>
    {
        public TRGBColor this[LightSpectrum spectrum]
        {
            get
            {
                if (spectrum == null)
                {
                    return GetColor(0f, 0f, 0f);
                }
                else
                {
                    return GetColor(1f, 1f, 1f);
                }
            }
        }

        public abstract TRGBColor GetColor(float r, float g, float b);
    }
}
