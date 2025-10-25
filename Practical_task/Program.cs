namespace Practical_task
{
    class Freezer
    {
        public static int FreezerCount { get; private set; }
        public static int Voltage { get; } = 220;


        public string Model { get; set; }

        public string Color { get; set; }

        private double _minTemperature;
        public double MinTemperature
        {
            get { return _minTemperature; }
            set {
                if (value < -30 || value > 0)
                {
                    _minTemperature = -18;
                    Console.WriteLine("Invalid min temperature");
                }
                else
                {
                    _minTemperature = value;
                }
            }
        }

        private double _maxTemperature;
        public double MaxTemperature
        {
            get { return _maxTemperature; }
            set
            {
                if (value < -30 || value > 0)
                {
                    _maxTemperature = -7;
                    Console.WriteLine("Invalid max temperature");
                }
                else
                {
                    _maxTemperature = value;
                }
            }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0.5)
                {
                    _height = 0.5;
                    Console.WriteLine("Invalid height");
                }
                else
                {
                    _height = value;
                }
            }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                if (value < 0.5)
                {
                    _width = 0.5;
                    Console.WriteLine("Invalid width");
                }
                else
                {
                    _width = value;
                }
            }
        }


        public Freezer(string model, string color, double minTemperature, double maxTemperature, double height, double width)
        {
            Model = model;
            Color = color;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Height = height;
            Width = width;

            FreezerCount++;
        }

        static Freezer()
        {
            FreezerCount = 0;
        }

        public override string ToString()
        {
            return $"Model: {Model}; Color: {Color}; Min Temperature: {MinTemperature}; Max Temperature: {MaxTemperature}; Height: {Height}; Width: {Width}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer freezer1 = new Freezer("ModelA", "White", -20, -5, 1.8, 0.7);
            Console.WriteLine(freezer1.ToString());
            Console.WriteLine("Count of freezers: " + Freezer.FreezerCount);
            Console.WriteLine("Voltage: " + Freezer.Voltage);
        }
    }
}
