using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Geometry
{
    // Класс прямоугольника
    public class Rec : IGeometricObject
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


        // Метод, который выводи информацию об объекте в консоль
        public void Draw()
        {
            Console.WriteLine($"rect at ({X1},{Y1}),({X2},{Y2})");
        }

        // Метод, который находит пересения с различными геометрическими объектами
        public void Intersect(IGeometricObject obj)
        {
            if (typeof(Circle).IsAssignableFrom(obj.GetType()))
                RecIntersectCircle((Circle)obj);


            if (typeof(Line).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);


            if (typeof(Rec).IsAssignableFrom(obj.GetType()))
                RecIntersectRec((Rec)obj);


            if (typeof(Point).IsAssignableFrom(obj.GetType()))
                obj.Intersect(this);
        }


        private void RecIntersectRec(Rec obj)
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
                Console.WriteLine("Rectangles have intersections");
            }
            else
                Console.WriteLine("Rectangles do not  have intersections");
        }



        private void RecIntersectCircle(Circle obj)
        {
            if (obj.Y < Y1)
            {
                if (obj.X < X1 && 
                   (obj.X - X1) * (obj.X - X1) + 
                   (obj.Y - Y1) * (obj.Y - Y1) <= obj.R * obj.R
                   )
                { Console.WriteLine($"Rect and circle have intersections"); return; }


                if (obj.X > X2 && 
                    (obj.X - X2) * (obj.X - X2) + 
                    (obj.Y - Y1) * (obj.Y - Y1) <= obj.R * obj.R
                    ) 
                { Console.WriteLine($"Rect and circle have intersections"); return; }


                if (Y1 - obj.Y <= 
                    obj.R
                    ) 
                { Console.WriteLine($"Rect and circle have intersections"); return; }
            }


            if (obj.Y > Y2)
            {
                if (obj.X < X1 && 
                    (obj.X - X1) * (obj.X - X1) + 
                    (obj.Y - Y2) * (obj.Y - Y2) <= obj.R * obj.R
                    ) 
                { Console.WriteLine($"rectangle and circle have intersections"); return; }


                if (obj.X > X2 && 
                    (obj.X - X2) * (obj.X - X2) + 
                    (obj.Y - Y2) * (obj.Y - Y2) <= obj.R * obj.R
                    ) 
                { Console.WriteLine($"rectangle and circle have intersections"); return; }


                if (obj.Y - Y2 <= obj.R
                    ) 
                { Console.WriteLine($"Rect and circle have intersections"); return; }
            }


            if (obj.X < X1 && 
                X1 - obj.X <= obj.R
                ) 
            { Console.WriteLine($"rectangle and circle have intersections"); return; }


            if (obj.X > X2 && 
                obj.X - X2 <= obj.R
                ) 
            { Console.WriteLine($"rectangle and circle have intersections"); return; }


            if (obj.X - X1 <= obj.R || 
                X2 - obj.X <= obj.R || 
                obj.Y - Y1 <= obj.R || 
                Y2 - obj.Y <= obj.R
                ) 
            { Console.WriteLine($"Rect and circle have intersections"); return; }


            Console.WriteLine($"Rect and circle do not have intersections");
        }
    }
}
