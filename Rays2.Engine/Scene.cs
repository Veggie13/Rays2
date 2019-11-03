using System;
using System.Collections.Generic;
using System.Text;

namespace Rays2.Engine
{
    public class Scene
    {
        public ICollection<IObject> Objects { get; } = new List<IObject>();
    }
}
