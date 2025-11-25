namespace Practical_task
{
    class Worker
    {
        private string _lastName;
        private string _initials;
        private int _age;
        private decimal _salary;
        private DateTime _hireDate;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Last name can't be null or empty");
                _lastName = value;
            }
        }

        public string Initials
        {
            get { return _initials; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Initials can't be null or empty");
                _initials = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 1 || value > 120)
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 120");
                _age = value;
            }
        }
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary can't be negative");
                _salary = value;
            }
        }
        public DateTime HireDate
        {
            get { return _hireDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Hire date can't be bigger than current time");
                _hireDate = value;
            }
        }
        public int GetYearsWorkExperiance()
        {
            return (DateTime.Now - _hireDate).Days / 365;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int WORKER_COUNT = 5;
            Worker[] workers = new Worker[WORKER_COUNT];

            int answ;
            Console.Write("Use template data? (1 - Yes, 0 - No): ");
            answ = int.Parse(Console.ReadLine());

            if (answ == 1)
            {
                workers[0] = new Worker() { LastName = "Doe", Initials = "J.D.", Age = 30, Salary = 20000, HireDate = new DateTime(2015, 11, 11) };
                workers[1] = new Worker() { LastName = "Joe", Initials = "J.D.", Age = 35, Salary = 30000, HireDate = new DateTime(2018, 11, 11) };
                workers[2] = new Worker() { LastName = "Aoe", Initials = "J.D.", Age = 40, Salary = 10000, HireDate = new DateTime(2010, 11, 20) };
                workers[3] = new Worker() { LastName = "Coe", Initials = "J.D.", Age = 20, Salary = 15000, HireDate = new DateTime(2012, 11, 30) };
                workers[4] = new Worker() { LastName = "Boe", Initials = "J.D.", Age = 15, Salary = 40000, HireDate = new DateTime(2019, 11, 11) };
            }
            else
            {
                for (int i = 0; i < WORKER_COUNT; i++)
                {
                    workers[i] = new Worker();
                    Console.WriteLine($"== Enter data for worker {i + 1} ==");
                    Console.Write("Last Name: ");
                    workers[i].LastName = Console.ReadLine();
                    Console.Write("Initials: ");
                    workers[i].Initials = Console.ReadLine();
                    Console.Write("Age: ");
                    workers[i].Age = int.Parse(Console.ReadLine());
                    Console.Write("Salary: ");
                    workers[i].Salary = decimal.Parse(Console.ReadLine());
                    Console.Write("Hire Date (YYYY-MM-DD): ");
                    workers[i].HireDate = DateTime.Parse(Console.ReadLine());
                }
            }

            Array.Sort(workers, (w1, w2) => string.Compare(w1.LastName, w2.LastName));
            Console.Write("Enter minimum experiance in years: ");
            int minExperiance = int.Parse(Console.ReadLine());
            Console.WriteLine("== Workers with experiance greater than " + minExperiance + " years ==");
            foreach (var worker in workers)
            {
                if (worker.GetYearsWorkExperiance() > minExperiance)
                {
                    Console.WriteLine(worker.LastName);
                }
            }
        }
    }
}