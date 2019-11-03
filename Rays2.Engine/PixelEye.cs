using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public class PixelEye<TPixelColor> : IEye
    {
        private RayTrace[,] _traces = new RayTrace[1,1];

        public IEnumerable<RayTrace> Traces
        {
            get
            {
                double halfWidth = Width / 2.0;
                double halfHeight = Height / 2.0;
                double horizontalTanHalf = Math.Tan(HorizontalFieldOfView / 2);
                double verticalTanHalf = Math.Tan(VerticalFieldOfView / 2);
                double horizontalInc = horizontalTanHalf / halfWidth;
                double verticalInc = verticalTanHalf / halfHeight;
                var gazeRotation = Gaze.Rotation;
                for (int x = 0; x < Width; x++)
                {
                    double xx = ((x + 0.5) - halfWidth) * horizontalInc;
                    for (int y = 0; y < Height; y++)
                    {
                        double yy = ((y + 0.5) - halfHeight) * verticalInc;
                        var unrotatedPointer = new Vector(xx, yy, 1);
                        var trace = new RayTrace()
                        {
                            Ray = new Ray()
                            {
                                Origin = Gaze.Pointer.Origin,
                                Direction = (gazeRotation * unrotatedPointer).Unit
                            }
                        };
                        _traces[x, y] = trace;
                        yield return trace;
                    }
                }
            }
        }

        public IRetina<TPixelColor> Retina { get; set; }

        public Gaze Gaze { get; set; }

        public int Width
        {
            get { return _traces.GetLength(0); }
            set
            {
                _traces = new RayTrace[value, _traces.GetLength(1)];
            }
        }
        public int Height
        {
            get { return _traces.GetLength(1); }
            set
            {
                _traces = new RayTrace[_traces.GetLength(0), value];
            }
        }

        public double HorizontalFieldOfView { get; set; }
        public double VerticalFieldOfView { get; set; }

        public TPixelColor this[int x, int y]
        {
            get { return Retina[_traces[x, y].Spectrum]; }
        }
    }
}
