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

        public override string? ToString()
        {
            return $"point at ({X},{Y})";
        }


        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (obj is Circle)
                PointIntersections.PointIntersectCircle((Circle)obj, this);


            if (obj is Line)
                obj.Intersect(this);


            if (obj is Rec)
                PointIntersections.PointIntersectRectangle((Rec)obj, this);


            if (obj is Point)
                PointIntersections.PointIntersectPoint(this, (Point)obj);
        }
    }

}
