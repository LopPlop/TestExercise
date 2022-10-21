using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Factory
{


    public class FactoryLine : Factory
    {
        public FactoryLine(string str) : base(str)
        {
        }
        public override GeometricObject Create()
        {
            int x1, y1, x2, y2;
            GetCoordinatesByStr(out x1, out y1, out x2, out y2);
            return new Line(x1, y1, x2, y2);
        }

        private void GetCoordinatesByStr(out int x1, out int y1, out int x2, out int y2)
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
            x1 = int.Parse(tmpStr);
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
            y1 = int.Parse(tmpStr);
            tmpStr = null;
            while (Str[i] != ' ')
            {
                tmpStr += Str[i];
                if (i != Str.Length - 1)
                    i++;
            }
            i += 1;
            x2 = int.Parse(tmpStr);
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
            y2 = int.Parse(tmpStr);
        }
    }
}
