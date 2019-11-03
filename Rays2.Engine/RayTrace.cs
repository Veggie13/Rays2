using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public class RayTrace
    {
        public Ray Ray { get; set; }

        private Point? _terminator;
        public Point? Terminator
        {
            get { return _terminator; }
            set
            {
                _terminator = value;
                Terminated(this);
            }
        }

        public LightSpectrum Spectrum { get; set; }

        public event Action<RayTrace> Terminated = (t) => { };
    }
}
