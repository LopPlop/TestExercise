using GeometryLib.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.SomeMath
{
    public class RecIntersections
    {

        public static void RecIntersectRec(Rec rec1, Rec rec2)
        {
            if (
                  (
                    rec2.X1 >= rec1.X1 && rec2.X1 <= rec1.X2 || rec2.X2 >= rec1.X1 && rec2.X2 <= rec1.X2
                  ) && (
                    rec2.Y1 >= rec1.Y1 && rec2.Y1 <= rec1.Y2 || rec2.Y2 >= rec1.Y1 && rec2.Y2 <= rec1.Y2
                  )
                 ||
                  (
                    rec1.X1 >= rec2.X1 && rec1.X1 <= rec2.X2 || rec1.X2 >= rec2.X1 && rec1.X2 <= rec2.X2
                  ) && (
                    rec1.Y1 >= rec2.Y1 && rec1.Y1 <= rec2.Y2 || rec1.Y2 >= rec2.Y1 && rec1.Y2 <= rec2.Y2
                  )

               ||

                  (
                    rec2.X1 >= rec1.X1 && rec2.X1 <= rec1.X2 || rec2.X2 >= rec1.X1 && rec2.X2 <= rec1.X2
                  ) && (
                    rec1.Y1 >= rec2.Y1 && rec1.Y1 <= rec2.Y2 || rec1.Y2 >= rec2.Y1 && rec1.Y2 <= rec2.Y2
                  )
                 ||
                  (
                    rec1.X1 >= rec2.X1 && rec1.X1 <= rec2.X2 || rec1.X2 >= rec2.X1 && rec1.X2 <= rec2.X2
                  ) && (
                    rec2.Y1 >= rec1.Y1 && rec2.Y1 <= rec1.Y2 || rec2.Y2 >= rec1.Y1 && rec2.Y2 <= rec1.Y2
                  )

              )
            {
                Console.WriteLine("Rectangles have intersections");
            }
            else
                Console.WriteLine("Rectangles do not  have intersections");
        }



        public static void RecIntersectCircle(Circle circle, Rec rec)
        {
            if (circle.Y < rec.Y1)
            {
                if (circle.X < rec.X1 &&
                   (circle.X - rec.X1) * (circle.X - rec.X1) +
                   (circle.Y - rec.Y1) * (circle.Y - rec.Y1) <= circle.R * circle.R
                   )
                { Console.WriteLine($"Rect and circle have intersections"); return; }


                if (circle.X > rec.X2 &&
                    (circle.X - rec.X2) * (circle.X - rec.X2) +
                    (circle.Y - rec.Y1) * (circle.Y - rec.Y1) <= circle.R * circle.R
                    )
                { Console.WriteLine($"Rect and circle have intersections"); return; }


                if (rec.Y1 - circle.Y <=
                    circle.R
                    )
                { Console.WriteLine($"Rect and circle have intersections"); return; }
            }


            if (circle.Y > rec.Y2)
            {
                if (circle.X < rec.X1 &&
                    (circle.X - rec.X1) * (circle.X - rec.X1) +
                    (circle.Y - rec.Y2) * (circle.Y - rec.Y2) <= circle.R * circle.R
                    )
                { Console.WriteLine($"rectangle and circle have intersections"); return; }


                if (circle.X > rec.X2 &&
                    (circle.X - rec.X2) * (circle.X - rec.X2) +
                    (circle.Y - rec.Y2) * (circle.Y - rec.Y2) <= circle.R * circle.R
                    )
                { Console.WriteLine($"rectangle and circle have intersections"); return; }


                if (circle.Y - rec.Y2 <= circle.R
                    )
                { Console.WriteLine($"Rect and circle have intersections"); return; }
            }


            if (circle.X < rec.X1 &&
                rec.X1 - circle.X <= circle.R
                )
            { Console.WriteLine($"rectangle and circle have intersections"); return; }


            if (circle.X > rec.X2 &&
                circle.X - rec.X2 <= circle.R
                )
            { Console.WriteLine($"rectangle and circle have intersections"); return; }


            if (circle.X - rec.X1 <= circle.R ||
                rec.X2 - circle.X <= circle.R ||
                circle.Y - rec.Y1 <= circle.R ||
                rec.Y2 - circle.Y <= circle.R
                )
            { Console.WriteLine($"Rect and circle have intersections"); return; }


            Console.WriteLine($"Rect and circle do not have intersections");
        }
    }
}
