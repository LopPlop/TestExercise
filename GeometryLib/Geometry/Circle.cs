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
        public void Draw()
        {
            Console.WriteLine($"circle at ({X},{Y}), radius={R}");
        }


        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (this.GetType() == obj.GetType())
                CircleIntersections.IntersectCircleNCircle((Circle)obj, this);


            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);


            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);


            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);
        }
    }
}
