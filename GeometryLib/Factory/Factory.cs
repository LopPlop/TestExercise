using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLib.Geometry;

namespace GeometryLib.Factory
{
    public abstract class Factory
    {
        public string Str { get; set; }

        public Factory(string str) => this.Str = str;

        public abstract GeometricObject Create();
    }
}
