using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public interface IEye
    {
        IEnumerable<RayTrace> Traces { get; }
    }
}
