using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Geometry
{
    

    public class Line : GeometricObject
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

        public void Draw()
        {
            Console.WriteLine($"line at ({X1},{Y1},{X2},{Y2})");
        }


        private void IntersectPoint(Point obj)
        {
            double diffX = X2 - X1;
            double diffY = Y2 - Y1;

            double a = diffX / diffY;
            double b = X1 * a;

            if (obj.Y == a * obj.X + b)
                Console.WriteLine("point and line have intersections");
            else
                Console.WriteLine("point and line do not have intersections");
        }

        private void Intersect(Rec obj)
        {
            if
            (
            MinorMathMethods.LineIntersectsLine(X1, Y1, X2, Y2, obj.X1, obj.Y1, obj.X1, obj.Y2) ||
            MinorMathMethods.LineIntersectsLine(X1, Y1, X2, Y2, obj.X1, obj.Y2, obj.X2, obj.Y2) ||
            MinorMathMethods.LineIntersectsLine(X1, Y1, X2, Y2, obj.X2, obj.Y2, obj.X2, obj.Y1) ||
            MinorMathMethods.LineIntersectsLine(X1, Y1, X2, Y2, obj.X2, obj.Y1, obj.X1, obj.Y1)
            )
                Console.WriteLine("Rec and line have intersections");
            else
                Console.WriteLine("Rec and line do not have intersections");

        }

        private void IntersectLine(Line obj)
        {
            double n;
            if (Y2 - Y1 != 0)
            {
                double q = (X2 - X1) / (Y1 - Y2);
                double sn = obj.X1 - obj.X2 + (obj.Y1 - obj.Y2) * q;
                double fn = obj.X1 - X1 + (obj.Y1 - Y1) * q;
                n = fn / sn;
                if (sn != 0) { Console.WriteLine("line and line do not have intersections"); }
            }
            else
            {
                if (obj.Y1 - obj.Y2 != 0) { Console.WriteLine("line and line do not have intersections"); }
                n = (obj.Y1 - Y1) / (obj.Y1 - obj.Y2);
            }

            Console.WriteLine($"line and line have intersections ({obj.X1 + (obj.X2 - obj.X1) * n},{obj.Y1 + (obj.Y2 - obj.Y1) * n})");
        }
        private void IntersectCircle(Circle obj)
        {
            double diffX = X2 - X1;
            double diffY = Y2 - Y1;

            double a = diffX / diffY;
            double b = X1 * a;

            double k, l, m;
            k = Math.Pow(a, 2.0) + 1;
            l = 2 * a * (b - obj.Y) - 2 * obj.X;
            m = Math.Pow(obj.X, 2.0) - Math.Pow(obj.R, 2.0) + Math.Pow(b - obj.Y, 2.0);
            double D = Math.Pow(l, 2.0) - 4.0 * k * m;
            if (D >= 0)
            {
                double _x1 = (-l - Math.Sqrt(D)) / (2.0 * k);
                double _y1 = a * X1 + b;
                double _x2 = (-l + Math.Sqrt(D)) / (2.0 * k);
                double _y2 = a * X2 + b;
                Console.WriteLine($"line and circle have intersections at ({_x1},{_y1}),({_x2}{_y2})");
            }
            else
                Console.WriteLine($"circle and line do not have intersections");
        }
        public void Intersect(GeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                IntersectCircle((Circle)obj);
            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                IntersectLine((Line)obj);
            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                Intersect((Rec)obj);
            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                IntersectPoint((Point)obj);
        }

    }
}
