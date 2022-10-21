using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Geometry
{
    public class Rec : GeometricObject
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public Rec(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public void Draw()
        {
            Console.WriteLine($"rect at ({X1},{Y1}),({X2},{Y2})");
        }


        private void Intersect(Point obj)
        {
            obj.Intersect(this);
        }

        private void Intersect(Rec obj)
        {
            if (
                  (
                    X1 >= obj.X1 && X1 <= obj.X2 || X2 >= obj.X1 && X2 <= obj.X2
                  ) && (
                    Y1 >= obj.Y1 && Y1 <= obj.Y2 || Y2 >= obj.Y1 && Y2 <= obj.Y2
                  )
                 ||
                  (
                    obj.X1 >= X1 && obj.X1 <= X2 || obj.X2 >= X1 && obj.X2 <= X2
                  ) && (
                    obj.Y1 >= Y1 && obj.Y1 <= Y2 || obj.Y2 >= Y1 && obj.Y2 <= Y2
                  )

               ||

                  (
                    X1 >= obj.X1 && X1 <= obj.X2 || X2 >= obj.X1 && X2 <= obj.X2
                  ) && (
                    obj.Y1 >= Y1 && obj.Y1 <= Y2 || obj.Y2 >= Y1 && obj.Y2 <= Y2
                  )
                 ||
                  (
                    obj.X1 >= X1 && obj.X1 <= X2 || obj.X2 >= X1 && obj.X2 <= X2
                  ) && (
                    Y1 >= obj.Y1 && Y1 <= obj.Y2 || Y2 >= obj.Y1 && Y2 <= obj.Y2
                  )

              )
            {
                Console.WriteLine("Rect and Rec have intersections");
            }
            else
                Console.WriteLine("Rect and Rec do not  have intersections");
        }

        private void Intersect(Line obj)
        {
            obj.Intersect(this);
        }

        private void Intersect(Circle obj)
        {
            if (obj.Y < Y1)
            {
                if (obj.X < X1 && (obj.X - X1) * (obj.X - X1) + (obj.Y - Y1) * (obj.Y - Y1) <= obj.R * obj.R) { Console.WriteLine($"Rect and circle have intersections"); return; }

                if (obj.X > X2 && (obj.X - X2) * (obj.X - X2) + (obj.Y - Y1) * (obj.Y - Y1) <= obj.R * obj.R) { Console.WriteLine($"Rect and circle have intersections"); return; }
                if (Y1 - obj.Y <= obj.R) { Console.WriteLine($"Rect and circle have intersections"); return; }
            }
            if (obj.Y > Y2)
            {
                if (obj.X < X1 && (obj.X - X1) * (obj.X - X1) + (obj.Y - Y2) * (obj.Y - Y2) <= obj.R * obj.R) { Console.WriteLine($"rectangle and circle have intersections"); return; }
                if (obj.X > X2 && (obj.X - X2) * (obj.X - X2) + (obj.Y - Y2) * (obj.Y - Y2) <= obj.R * obj.R) { Console.WriteLine($"rectangle and circle have intersections"); return; }
                if (obj.Y - Y2 <= obj.R) { Console.WriteLine($"Rect and circle have intersections"); return; }
            }
            if (obj.X < X1 && X1 - obj.X <= obj.R) { Console.WriteLine($"rectangle and circle have intersections"); return; }
            if (obj.X > X2 && obj.X - X2 <= obj.R) { Console.WriteLine($"rectangle and circle have intersections"); return; }
            if (obj.X - X1 <= obj.R || X2 - obj.X <= obj.R || obj.Y - Y1 <= obj.R || Y2 - obj.Y <= obj.R) { Console.WriteLine($"Rect and circle have intersections"); return; }
            Console.WriteLine($"Rect and circle do not have intersections");
        }
        public void Intersect(GeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                Intersect((Circle)obj);
            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                Intersect((Line)obj);
            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                Intersect((Rec)obj);
            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                Intersect((Point)obj);
        }
    }
}
