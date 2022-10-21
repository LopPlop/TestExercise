using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public class MinorMathMethods
    {
        public static double Product(double Px, double Py, double Ax, double Ay, double Bx, double By)
        {
            return (Bx - Ax) * (Py - Ay) - (By - Ay) * (Px - Ax);
        }

        public static bool LineIntersectsLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double q = (y1 - y3) * (x4 - x3) - (x1 - x3) * (y4 - y3);
            double d = (x2 - x1) * (y4 - y3) - (y2 - y1) * (x4 - x3);

            if (d == 0)
            {
                return false;
            }

            double r = q / d;

            q = (y1 - y3) * (x2 - x1) - (x1 - x3) * (y2 - y1);
            double s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
        }







    }
}
