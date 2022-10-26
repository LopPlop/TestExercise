using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.SomeMath
{
    public class CircleIntersections
    {
        // Метод, который определяет, пересекаются ли две окружности
        public static void IntersectCircleNCircle(Circle circle1,Circle circle2 )
        {
            double d = (circle2.X - circle1.X) * (circle2.X - circle1.X) + (circle2.Y - circle1.Y) * (circle2.Y - circle1.Y);

            if (d <= (circle2.R + circle1.R) * (circle2.R + circle1.R) && d >= (circle2.R > circle1.R ? circle2.R - circle1.R : circle1.R - circle2.R))
                Console.WriteLine("circles have intersections");
            else
                Console.WriteLine("circles do not have intersections");
        }
    }
}
