using System;
using System.Drawing;
using Rays2.Engine;

namespace Rays2.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var scene = new Scene();
            scene.Objects.Add(new SphereObject()
            {
                Center = Engine.Point.Origin,
                Radius = 10,
                Material = new LightMaterial()
                {
                    GlowSpectrum = new LightSpectrum()
                }
            });

            var eye = new PixelEye<Color>()
            {
                Width = 100,
                Height = 100,
                HorizontalFieldOfView = Math.PI / 2,
                VerticalFieldOfView = Math.PI / 2,
                Retina = new DrawingColorRetina(),
                Gaze = new Gaze(new Ray()
                {
                    Origin = new Engine.Point(0, 0, -70),
                    Direction = UnitVector.K
                }, -UnitVector.J)
            };

            var tracer = new RayTracer()
            {
                Scene = scene,
                Eye = eye
            };

            tracer.TraceRays();

            var image = new Bitmap(eye.Width, eye.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    image.SetPixel(x, y, eye[x, y]);
                }
            }
            image.Save(@"..\..\..\..\tester.png");
        }
    }
}
