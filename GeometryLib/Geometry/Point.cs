using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLib.SomeMath;

namespace GeometryLib.Geometry
{
    // Класс точки
    public class Point : IGeometricObject
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }


        // Метод, который выводи информацию об объекте в консоль
        public void Draw()
        {
            Console.WriteLine($"point at ({X},{Y})");
        }


        // Метод, который находит пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                PointIntersectCircle((Circle)obj);


            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);


            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                PointIntersectRectangle((Rec)obj);


            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                PointIntersectPoint((Point)obj);
        }


        private void PointIntersectPoint(Point obj)
        {
            if (obj.X == X && obj.Y == Y)
                Console.WriteLine($"point and point have intersections({X},{Y})");
            else
                Console.WriteLine("point and point do not have intersections");
        }


        private void PointIntersectRectangle(Rec obj)
        {
            double p1, p2, p3, p4;
            p1 = MinorMathMethods.Product(X, Y, obj.X1, obj.Y1, obj.X1, obj.Y2);
            p2 = MinorMathMethods.Product(X, Y, obj.X1, obj.Y2, obj.X2, obj.Y2);
            p3 = MinorMathMethods.Product(X, Y, obj.X2, obj.Y2, obj.X2, obj.Y1);
            p4 = MinorMathMethods.Product(X, Y, obj.X2, obj.Y1, obj.X1, obj.Y1);

            if ((obj.X1 == X && obj.Y1 == Y) |
               (obj.X2 == X && obj.Y2 == Y) |
               (obj.X1 == X && obj.Y2 == Y) |
               (obj.X2 == X && obj.Y1 == Y))
            {
                Console.WriteLine($"Rec and point have intersections({X},{Y})");
                return;
            }

            if (p1 < 0 && p2 < 0 && p3 < 0 && p4 < 0 ||
                p1 > 0 && p2 > 0 && p3 > 0 && p4 > 0)
                Console.WriteLine($"Rec and point have intersections({X},{Y})");
            else
                Console.WriteLine("Rec and point do not have intersections");
        }


        private void PointIntersectCircle(Circle obj)
        {
            if (Math.Pow(obj.R, 2) == Math.Pow(X + obj.X, 2) + Math.Pow(Y + obj.Y, 2))
                Console.WriteLine($"point and circle have intersections({X},{Y})");
            else
                Console.WriteLine("point and circle do not have intersections");

        }
    }

}
