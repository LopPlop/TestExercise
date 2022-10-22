using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.SomeMath
{
    public class LineIntersections
    {
        public static void LineIntersectPoint(Point point, Line line)
        {
            double diffX = line.X2 - line.X1;
            double diffY = line.Y2 - line.Y1;

            double a = diffX / diffY;
            double b = line.X1 * a;

            if (point.Y == a * point.X + b)
                Console.WriteLine("point and line have intersections");
            else
                Console.WriteLine("point and line do not have intersections");
        }

        public static void LineIntersectRec(Rec rec, Line line)
        {
            if
            (
            MinorMathMethods.LineIntersectsLine(line.X1, line.Y1, line.X2, line.Y2, rec.X1, rec.Y1, rec.X1, rec.Y2) ||
            MinorMathMethods.LineIntersectsLine(line.X1, line.Y1, line.X2, line.Y2, rec.X1, rec.Y2, rec.X2, rec.Y2) ||
            MinorMathMethods.LineIntersectsLine(line.X1, line.Y1, line.X2, line.Y2, rec.X2, rec.Y2, rec.X2, rec.Y1) ||
            MinorMathMethods.LineIntersectsLine(line.X1, line.Y1, line.X2, line.Y2, rec.X2, rec.Y1, rec.X1, rec.Y1)
            )
                Console.WriteLine("Rec and line have intersections");
            else
                Console.WriteLine("Rec and line do not have intersections");

        }

        public static void IntersectLine(Line line1, Line line2)
        {
            if (MinorMathMethods.LineIntersectsLine(line2.X1, line2.Y1, line2.X2, line2.Y2, line1.X1, line1.Y1, line1.X2, line1.Y2))
            {
                Console.WriteLine("lines are intersected");
            }
            else
                Console.WriteLine("line and line do not have intersections");
        }

        public static void LineIntersectCircle(Circle circle, Line line)
        {
            double diffX = line.X2 - line.X1;
            double diffY = line.Y2 - line.Y1;

            double a = diffX / diffY;
            double b = line.X1 * a;

            double k, l, m;
            k = Math.Pow(a, 2.0) + 1;
            l = 2 * a * (b - circle.Y) - 2 * circle.X;
            m = Math.Pow(circle.X, 2.0) - Math.Pow(circle.R, 2.0) + Math.Pow(b - circle.Y, 2.0);
            double D = Math.Pow(l, 2.0) - 4.0 * k * m;
            if (D >= 0)
            {
                double _x1 = (-l - Math.Sqrt(D)) / (2.0 * k);
                double _y1 = a * line.X1 + b;
                double _x2 = (-l + Math.Sqrt(D)) / (2.0 * k);
                double _y2 = a * line.X2 + b;
                Console.WriteLine($"line and circle have intersections at ({_x1},{_y1}),({_x2}{_y2})");
            }
            else
                Console.WriteLine($"circle and line do not have intersections");
        }
    }
}
