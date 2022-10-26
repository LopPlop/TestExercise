using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.SomeMath
{
    public class PointIntersections
    {
        public static void PointIntersectPoint(Point point1, Point point2)
        {
            if (point1.X == point2.X && point1.Y == point2.Y)
                Console.WriteLine($"point and point have intersections({point1.X},{point1.Y})");
            else
                Console.WriteLine("point and point do not have intersections");
        }

        public static void PointIntersectRectangle(Rec rec, Point point)
        {
            double p1, p2, p3, p4;
            p1 = MinorMathMethods.Product(point.X, point.Y, rec.X1, rec.Y1, rec.X1, rec.Y2);
            p2 = MinorMathMethods.Product(point.X, point.Y, rec.X1, rec.Y2, rec.X2, rec.Y2);
            p3 = MinorMathMethods.Product(point.X, point.Y, rec.X2, rec.Y2, rec.X2, rec.Y1);
            p4 = MinorMathMethods.Product(point.X, point.Y, rec.X2, rec.Y1, rec.X1, rec.Y1);

            if ((rec.X1 == point.X && rec.Y1 == point.Y) |
               (rec.X2 == point.X && rec.Y2 == point.Y) |
               (rec.X1 == point.X && rec.Y2 == point.Y) |
               (rec.X2 == point.X && rec.Y1 == point.Y))
            {
                Console.WriteLine($"Rec and point have intersections({point.X},{point.Y})");
                return;
            }

            if (p1 < 0 && p2 < 0 && p3 < 0 && p4 < 0 ||
                p1 > 0 && p2 > 0 && p3 > 0 && p4 > 0)
                Console.WriteLine($"Rec and point have intersections({point.X},{point.Y})");
            else
                Console.WriteLine("Rec and point do not have intersections");
        }

        public static void PointIntersectCircle(Circle circle, Point point)
        {
            if (Math.Pow(circle.R, 2) == Math.Pow(point.X + circle.X, 2) + Math.Pow(point.Y + circle.Y, 2))
                Console.WriteLine($"point and circle have intersections({point.X},{point.Y})");
            else
                Console.WriteLine("point and circle do not have intersections");
        }
    }

}
