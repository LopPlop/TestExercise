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
            if (obj.x == x && obj.y == y)
                Console.WriteLine("Line and line have interseption");
            else
                Console.WriteLine("Line and line do not have interseption");
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

            if (y == a * x + b)
                Console.WriteLine("rectangle and circle have intersection");
            else
                Console.WriteLine($"rectangle and circle do not have intersection");
        }

        public override void Intersect(Circle obj)
        {
            if (Math.Pow(obj.r, 2) == Math.Pow(x + obj.x, 2) + Math.Pow(y + obj.y, 2))
                Console.WriteLine("rectangle and circle have intersection");
            else
                Console.WriteLine("rectangle and circle do not have intersection");

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
            if (obj.y < y1)
            {
                if (obj.x < x1 && ((obj.x - x1) * (obj.x - x1) + (obj.y - y1) * (obj.y - y1)) <= obj.r * obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }

                if (obj.x > x2 && ((obj.x - x2) * (obj.x - x2) + (obj.y - y1) * (obj.y - y1)) <= obj.r * obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if ((y1 - obj.y) <= obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            }
            if (obj.y > y2)
            {
                if (obj.x < x1 && ((obj.x - x1) * (obj.x - x1) + (obj.y - y2) * (obj.y - y2)) <= obj.r * obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if (obj.x > x2 && ((obj.x - x2) * (obj.x - x2) + (obj.y - y2) * (obj.y - y2)) <= obj.r * obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if ((obj.y - y2) <= obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            }

            if (obj.x < x1 && (x1 - obj.x) <= obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            if (obj.x > x2 && (obj.x - x2) <= obj.r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            if (((obj.x - x1) <= obj.r || (x2 - obj.x) <= obj.r || (obj.y - y1) <= obj.r || (y2 - obj.y) <= obj.r)) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            Console.WriteLine($"rectangle and circle do not have intersection");
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
            double diffX = x2 - x1;
            double diffY = y2 - y1;

            double a = diffX / diffY;
            double b = x1 * a;

            if (obj.y == a * obj.x + b)
                Console.WriteLine("rectangle and circle have intersection");
            else
                Console.WriteLine($"rectangle and circle do not have intersection");
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
            if (Math.Pow(r, 2) == Math.Pow(obj.x + x, 2) + Math.Pow(obj.y + y, 2))
                Console.WriteLine("rectangle and circle have intersection");
            else
                Console.WriteLine("rectangle and circle do not have intersection");
        }

        public override void Intersect(Rec obj)
        {
            if (y < obj.y1)
            {
                if (x < obj.x1 && ((x - obj.x1) * (x - obj.x1) + (y - obj.y1) * (y - obj.y1)) <= r * r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if (x > obj.x2 && ((x - obj.x2) * (x - obj.x2) + (y - obj.y1) * (y - obj.y1)) <= r * r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if ((obj.y1 - y) <= r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            }
            if (y > obj.y2)
            {
                if (x < obj.x1 && ((x - obj.x1) * (x - obj.x1) + (y - obj.y2) * (y - obj.y2)) <= r * r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if (x > obj.x2 && ((x - obj.x2) * (x - obj.x2) + (y - obj.y2) * (y - obj.y2)) <= r * r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
                if ((y - obj.y2) <= r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            }
            if (x < obj.x1 && (obj.x1 - x) <= r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            if (x > obj.x2 && (x - obj.x2) <= r) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            if (((x - obj.x1) <= r || (obj.x2 - x) <= r || (y - obj.y1) <= r || (obj.y2 - y) <= r)) { Console.WriteLine($"rectangle and circle have intersection"); return; }
            Console.WriteLine($"rectangle and circle do not have intersection");
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
                Console.WriteLine($"line and circle do not have intersections");
        }

        public override void Intersect(Circle obj)
        {
            double d = (x - obj.x) * (x - obj.x) + (y - obj.y) * (y - obj.y);
            if (d <= (r + obj.r) * (r + obj.r) && d >= (r > obj.r ? r - obj.r : obj.r - r))
                Console.WriteLine($"circle and circle have intersections");
            else
                Console.WriteLine($"circle and circle do not have intersections");
        }
    }
}