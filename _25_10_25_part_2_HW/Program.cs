namespace _25_10_25_part_2_HW
{

    partial class Freezer
    {
        public int Id { get; protected set; }
        public string Model { get; protected set; }
        public double Capacity { get; protected set; }
        public bool IsAvaible { get; protected set; }
        public char EnergyClass { get; protected set; }

        public static int FreezerCount { get; private set; } = 0;
        public static string CompanyName { get; private set; } = "Best Freezers Inc.";

        static Freezer()
        {
            FreezerCount = 0;
        }

        public Freezer()
        {
            FreezerCount++;
            Id = FreezerCount;
            Model = "Default Model";
            Capacity = 100.0;
            IsAvaible = true;
            EnergyClass = 'A';
        }
        public Freezer(string model, double capacity) : this()
        {
            Model = model;
            Capacity = capacity;
        }

        public Freezer(string model, double capacity, bool isAvaible, char energyClass) : this(model, capacity)
        {
            IsAvaible = isAvaible;
            EnergyClass = energyClass;
        }
    }

    partial class Freezer
    {
        public void ToggleAvailability()
        {
            IsAvaible = !IsAvaible;
        }

        public override string ToString()
        {
            return $"Freezer ID: {Id}, Model: {Model}, Capacity: {Capacity}L, Available: {IsAvaible}, Energy Class: {EnergyClass}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezers =
            {
                new Freezer("Model A", 70),
                new Freezer("Model B", 120, false, 'B'),
                new Freezer(),
                new Freezer("Model C", 200, true, 'A'),
                new Freezer("Model D", 150, false, 'C')
            };

            foreach (var freezer in freezers)
            {
                Console.WriteLine(freezer.ToString());
            }
        }
    }
}
