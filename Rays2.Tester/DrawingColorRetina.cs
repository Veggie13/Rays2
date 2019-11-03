using Rays2.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Rays2.Tester
{
    class DrawingColorRetina : RGBRetina<Color>
    {
        public override Color GetColor(float r, float g, float b)
        {
            return Color.FromArgb(255, (int)(255 * r), (int)(255 * g), (int)(255 * b));
        }
    }
}
