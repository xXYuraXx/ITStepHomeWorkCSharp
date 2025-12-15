namespace _29_11_25_HW
{
    public abstract class GeometryFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
    public class Triangle : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        private int _b;
        public int B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _b = value;
            }
        }
        private int _c;
        public int C
        {
            get { return _c; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _c = value;
            }
        }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
        public override double GetArea()
        {
            double hp = (A + B + C) / 2;
            return Math.Sqrt(hp * (hp - A) * (hp - B) * (hp - C));
        }
        public override double GetPerimeter()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return $"Triangle: A={A}, B={B}, C={C}";
        }
    }

    public class Square : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        public Square(int a)
        {
            A = a;
        }
        public override double GetArea()
        {
            return A * A;
        }
        public override double GetPerimeter()
        {
            return 4 * A;
        }

        public override string ToString()
        {
            return $"Square: A={A}";
        }
    }

    public class Romb : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        private int _h;
        public int H
        {
            get { return _h; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height must be positive");
                _h = value;
            }
        }
        public Romb(int a, int h)
        {
            A = a;
            H = h;
        }
        public override double GetArea()
        {
            return A * H;
        }
        public override double GetPerimeter()
        {
            return 4 * A;
        }

        public override string ToString()
        {
            return $"Romb: A={A}, H={H}";
        }
    }

    public class Rectangle : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        private int _b;
        public int B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _b = value;
            }
        }
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }
        public override double GetArea()
        {
            return A * B;
        }
        public override double GetPerimeter()
        {
            return 2 * (A + B);
        }
        public override string ToString()
        {
            return $"Rectangle: A={A}, B={B}";
        }
    }

    public class Paralelogram : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        private int _b;
        public int B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _b = value;
            }
        }
        private int _h;
        public int H
        {
            get { return _h; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height must be positive");
                _h = value;
            }
        }
        public Paralelogram(int a, int b, int h)
        {
            A = a;
            B = b;
            H = h;
        }
        public override double GetArea()
        {
            return A * H;
        }
        public override double GetPerimeter()
        {
            return 2 * (A + B);
        }

        public override string ToString()
        {
            return $"Paralelogram: A={A}, B={B}, H={H}";
        }
    }   

    public class Trapecia : GeometryFigure
    {
        private int _a;
        public int A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _a = value;
            }
        }
        private int _b;
        public int B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _b = value;
            }
        }
        private int _c;
        public int C
        {
            get { return _c; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _c = value;
            }
        }
        private int _d;
        public int D
        {
            get { return _d; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side len must be positive");
                _d = value;
            }
        }
        private int _h;
        public int H
        {
            get { return _h; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height must be positive");
                _h = value;
            }
        }
        public Trapecia(int a, int b, int c, int d, int h)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            H = h;
        }
        public override double GetArea()
        {
            return ((A + B) / 2) * H;
        }
        public override double GetPerimeter()
        {
            return A + B + C + D;
        }

        public override string ToString()
        {
            return $"Trapecia: A={A}, B={B}, C={C}, D={D}, H={H}";
        }
    }   

    public class Circle : GeometryFigure
    {
        private int _r;
        public int R
        {
            get { return _r; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius must be positive");
                _r = value;
            }
        }
        public Circle(int r)
        {
            R = r;
        }
        public override double GetArea()
        {
            return Math.PI * R * R;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * R;
        }

        public override string ToString()
        {
            return $"Circle: R={R}";
        }
    }

    public class MultyFigure
    {
        private GeometryFigure[] figures = [];
        public MultyFigure(params GeometryFigure[] figures)
        {
            foreach (var figure in figures)
            {
                AddFigure(figure);
            }
        }
        public void AddFigure(GeometryFigure figure)
        {
            figures = figures.Append(figure).ToArray();
        }
        public double GetTotalArea()
        {
            double totalArea = 0;
            foreach (var figure in figures)
            {
                totalArea += figure.GetArea();
            }
            return totalArea;
        }
        public double GetTotalPerimeter()
        {
            double totalPerimeter = 0;
            foreach (var figure in figures)
            {
                totalPerimeter += figure.GetPerimeter();
            }
            return totalPerimeter;
        }

        public void PrintAllFiguresInfo()
        {
            Console.WriteLine("MultyFigure contains:");
            Console.WriteLine("{");
            foreach (var figure in figures)
            {
                Console.WriteLine("\t{");
                Console.WriteLine("\t\t" + figure.ToString() + ',');
                Console.WriteLine("\t\t" + $"Area: {figure.GetArea()}" + ',');
                Console.WriteLine("\t\t" + $"Perimeter: {figure.GetPerimeter()}" + ',');
                Console.WriteLine("\t},\n");
            }
            Console.WriteLine("}");
        }
    }



    internal class Program
    {

        static void Main(string[] args)
        {
            Triangle tr = new Triangle(3, 4, 5);
            Square sq = new Square(4);
            Romb romb = new Romb(4, 5);
            Rectangle rect = new Rectangle(4, 5);
            Paralelogram par = new Paralelogram(4, 5, 6);
            Trapecia trap = new Trapecia(3, 4, 5, 6, 7);
            Circle cir = new Circle(5);
            MultyFigure mf = new MultyFigure(tr, sq, romb, rect, par, trap, cir);

            mf.PrintAllFiguresInfo();
            
        }
    }
}
