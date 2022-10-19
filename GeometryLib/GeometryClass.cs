namespace GeometryLib
{
    public abstract class GeometricObject
    {
        public abstract void Draw();
        public abstract void Intersect(Point obj);
        public abstract void Intersect(Rec obj);
        public abstract void Intersect(Line obj);
        public abstract void Intersect(Circle obj);
    }

    public class Point : GeometricObject
    {
        public double x { get; set; }
        public double y { get; set; }


        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Draw()
        {
            System.Console.WriteLine($"point at ({x},{y})");
        }

        public override void Intersect(Point obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Rec obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Line obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Circle obj)
        {
            throw new NotImplementedException();
        }
    }
    public class Rec : GeometricObject
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public Rec(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void Draw()
        {
            System.Console.WriteLine($"rect at ({x1},{y1}),({x2},{y2})");
        }


        public override void Intersect(Point obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Rec obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Line obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Circle obj)
        {
            throw new NotImplementedException();
        }
    }
    public class Line : GeometricObject
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public Line(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void Draw()
        {
            System.Console.WriteLine($"line at ({x1},{y1},{x2},{y2})");
        }

       
        public override void Intersect(Point obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Rec obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Line obj)
        {
            throw new NotImplementedException();
        }
        public override void Intersect(Circle obj)
        {
            double diffX = x2 - x1;
            double diffY = y2 - y1;

            double a = diffX / diffY;
            double b = x1 * a;

            double k, l, m;
            k = Math.Pow(a, 2.0) + 1;
            l = 2 * a * (b - obj.y) - 2 * obj.x;
            m = Math.Pow(obj.x, 2.0) - Math.Pow(obj.r, 2.0) + Math.Pow(b - obj.y, 2.0);
            double D = Math.Pow(l, 2.0) - 4.0 * k * m;
            if (D >= 0)
            {
                double _x1 = (-l - Math.Sqrt(D)) / (2.0 * k);
                double _y1 = a * x1 + b;
                double _x2 = (-l + Math.Sqrt(D)) / (2.0 * k);
                double _y2 = a * x2 + b;
                Console.WriteLine($"line and circle have intersection at ({_x1},{_y1}),({_x2}{_y2})");
            }
            else
                Console.WriteLine($"circle and line do not have intersections");
        }

    }
    public class Circle : GeometricObject
    {
        public double x { get; set; }
        public double y { get; set; }
        public double r { get; set; }
        public Circle(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public override void Draw()
        {
            System.Console.WriteLine($"circle at ({x},{y}), radius={r}");
        }

        public override void Intersect(Point obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Rec obj)
        {
            throw new NotImplementedException();
        }

        public override void Intersect(Line obj)
        {
            double diffX = obj.x2 - obj.x1;
            double diffY = obj.y2 - obj.y1;

            double a = diffX / diffY;
            double b = obj.x1 * a;

            double k, l, m;
            k = Math.Pow(a, 2.0) + 1;
            l = 2 * a * (b - y) - 2 * x;
            m = Math.Pow(x, 2.0) - Math.Pow(r, 2.0) + Math.Pow(b - y, 2.0);
            double D = Math.Pow(l, 2.0) - 4.0 * k * m;
            if (D >= 0)
            {
                double _x1 = (-l - Math.Sqrt(D)) / (2.0 * k);
                double _y1 = a * obj.x1 + b;
                double _x2 = (-l + Math.Sqrt(D)) / (2.0 * k);
                double _y2 = a * obj.x2 + b;
                Console.WriteLine($"line and circle have intersection at ({_x1},{_y1}),({_x2}{_y2})");
            }
            else
                Console.WriteLine($"circle and line do not have intersections");
        }

        public override void Intersect(Circle obj)
        {
            throw new NotImplementedException();
        }
    }
}