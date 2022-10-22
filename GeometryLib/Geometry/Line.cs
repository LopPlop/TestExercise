using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLib.SomeMath;

namespace GeometryLib.Geometry
{
    // Класс линии
    public class Line : IGeometricObject
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }


        // Метод, который выводи информацию об объекте в консоль
        public void Draw()
        {
            Console.WriteLine($"line at ({X1},{Y1},{X2},{Y2})");
        }


        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                LineIntersections.LineIntersectCircle((Circle)obj, this);


            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                LineIntersections.IntersectLine((Line)obj, this);


            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                LineIntersections.LineIntersectRec((Rec)obj, this);


            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                LineIntersections.LineIntersectPoint((Point)obj, this);
        }


    }
}
