using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Geometry
{

    public class Circle : GeometricObject
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

        public void Draw()
        {
            Console.WriteLine($"circle at ({X},{Y}), radius={R}");
        }
        public void Intersect(Point obj)
        {
            obj.Intersect(this);
        }

        private void Intersect(Rec obj)
        {
            obj.Intersect(this);
        }

        private void Intersect(Line obj)
        {
            obj.Intersect(this);
        }

        private void IntersectCircleNCircle(Circle obj)
        {
            double d = (X - obj.X) * (X - obj.X) + (Y - obj.Y) * (Y - obj.Y);
            if (d <= (R + obj.R) * (R + obj.R) && d >= (R > obj.R ? R - obj.R : obj.R - R))
                Console.WriteLine("circle and circle have intersections");
            else
                Console.WriteLine("circle and circle do not have intersections");
        }
        public void Intersect(GeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                IntersectCircleNCircle((Circle)obj);
            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                Intersect((Line)obj);
            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                Intersect((Rec)obj);
            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                Intersect((Point)obj);
        }
    }
}
