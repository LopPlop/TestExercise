using GeometryLib.SomeMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Geometry
{
    // Класс окружности
    public class Circle : IGeometricObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public Circle(double x, double y, double r)
        {
            X = x;
            Y = y;
            R = r;
        }


        // Метод, который выводи информацию об объекте в консоль
        public override string? ToString()
        {
            return $"circle at ({X},{Y}), radius={R}";
        }


        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (obj is Circle)
                CircleIntersections.IntersectCircleNCircle((Circle)obj, this);


            if (obj is Line)
                obj.Intersect(this);


            if (obj is Rec)
                obj.Intersect(this);


            if (obj is Point)
                obj.Intersect(this);
        }
    }
}
