using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public interface IRetina<TColor>
    {
        TColor this[LightSpectrum spectrum] { get; }
    }
}
