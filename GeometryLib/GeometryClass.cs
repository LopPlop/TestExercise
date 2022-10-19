namespace GeometryLib
{
        public abstract class  GeometricObject
        {
            public abstract void Draw();
            public abstract void Intersect();
        }

        public class Point : GeometricObject
        {
            private double x { get; set; }
            private double y { get; set; }
            

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Draw()
            {
                System.Console.WriteLine($"point at ({x},{y})");
            }

            public override void Intersect()
            {
                throw new NotImplementedException();
            }
        }
        public class Rec : GeometricObject
        {
            private double x1 { get; set; }
            private double y1 { get; set; }
            private double x2 { get; set; }
            private double y2 { get; set; }
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

            public override void Intersect()
            {
                throw new NotImplementedException();
            }
        }
        public class Line : GeometricObject
        {
            private double x1 { get; set; }
            private double y1 { get; set; }
            private double x2 { get; set; }
            private double y2 { get; set; }
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

            public override void Intersect()
            {
                throw new NotImplementedException();
            }
        }
        public class Circle : GeometricObject
        {
            private double x { get; set; }
            private double y { get; set; }
            private double r { get; set; }
            public Circle(double x, double y, double r)
            {
                this.x = x;
                this.y = y;
                this.r = r;
            }

            public override void Draw()
            {
                System.Console.WriteLine($"circle at ({x},{y}), radius ({r})");
            }

            public override void Intersect()
            {
                throw new NotImplementedException();
            }
        }
}