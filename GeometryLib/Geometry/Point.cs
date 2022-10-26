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


        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                PointIntersections.PointIntersectCircle((Circle)obj, this);


            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);


            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                PointIntersections.PointIntersectRectangle((Rec)obj, this);


            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                PointIntersections.PointIntersectPoint(this, (Point)obj);
        }
    }

}
