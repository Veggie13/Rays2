using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rays2.Engine
{
    public class RayTracer
    {
        private Queue<RayTrace> _traces = new Queue<RayTrace>();

        public Scene Scene { get; set; }
        public IEye Eye { get; set; }

        public void AddTrace(RayTrace trace)
        {
            _traces.Enqueue(trace);
        }

        public void TraceRays()
        {
            _traces = new Queue<RayTrace>(Eye.Traces);

            while (_traces.TryDequeue(out RayTrace trace))
            {
                TraceRay(trace);
            }
        }

        void TraceRay(RayTrace trace)
        {
            double bestDistance = double.MaxValue;
            Ray bestIntersectionNormal = new Ray();
            IObject bestObj = null;
            foreach (var obj in Scene.Objects)
            {
                Ray intersectionNormal;
                if (!obj.TryIntersectWith(trace.Ray, out intersectionNormal))
                {
                    continue;
                }

                double objDistance = (intersectionNormal.Origin - trace.Ray.Origin).Magnitude;
                if (bestDistance > objDistance)
                {
                    bestObj = obj;
                    bestDistance = objDistance;
                    bestIntersectionNormal = intersectionNormal;
                }
            }

            if (bestObj != null)
            {
                bestObj.Material.CompleteTrace(this, trace, bestIntersectionNormal);
            }
        }
    }
}
