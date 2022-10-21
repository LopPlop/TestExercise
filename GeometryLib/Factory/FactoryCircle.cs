using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Factory
{
    public class FactoryCircle : Factory
    {
        public FactoryCircle(string str) : base(str)
        {
        }

        public override GeometricObject Create()
        {
            int x, y, r;
            GetCoordinatesByStr(out x, out y, out r);
            return new Circle(x, y, r);
        }

        private void GetCoordinatesByStr(out int x, out int y, out int r)
        {
            string tmpStr = null;
            int i = Str.IndexOf(" ") + 1;
            while (Str[i] != ' ')
            {
                tmpStr += Str[i];
                if (i != Str.Length - 1)
                    i++;
            }
            i += 1;
            x = int.Parse(tmpStr);
            tmpStr = null;
            while (Str[i] != ' ')
            {
                tmpStr += Str[i];
                if (i != Str.Length - 1)
                    i++;
                else
                    break;
            }
            i += 1;
            y = int.Parse(tmpStr);
            tmpStr = null;
            while (Str[i] != ' ')
            {
                tmpStr += Str[i];
                if (i != Str.Length - 1)
                    i++;
                else
                    break;
            }
            r = int.Parse(tmpStr);
        }
    }
}
