using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Factory
{
    public class FactoryPoint : Factory
    {
        public FactoryPoint(string str) : base(str)
        {
        }

        // Абстрактный метод, служащий для производства объектов
        public override IGeometricObject Create()
        {
            int x, y;
            GetCoordinatesByStr(out x, out y);
            return new Point(x, y);
        }

        private void GetCoordinatesByStr(out int x, out int y)
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
            y = int.Parse(tmpStr);
        }
    }
}
