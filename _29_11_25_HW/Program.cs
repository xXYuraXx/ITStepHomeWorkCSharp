namespace _29_11_25_HW
{
    public abstract class GeometryFigure
    {
        protected abstract double GetArea();
        protected abstract double GetPerimeter();
    }
    public abstract class _3SideFigure : GeometryFigure
    {
        public abstract double A { get; set; }
        public abstract double B { get; set; }
        public abstract double C { get; set; }
    }
    public class Triangle
    {
        private double _a;

        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side length must be positive");
                _a = value;
            }
        }

        public Triangle(double a, double b, double c)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
        }
    }
}
