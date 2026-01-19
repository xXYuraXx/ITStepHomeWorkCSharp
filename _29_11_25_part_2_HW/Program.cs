using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace _29_11_25_part_2_HW
{
    class Task1
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Task1");
            Task t1 = new Task(() => PrintTime("new Task()"));
            t1.Start();
            Task t2 = Task.Factory.StartNew(() => PrintTime("Task.Factory.StartNew()"));
            Task t3 = Task.Run(() => PrintTime("Task.Run()"));

            t1.Wait();
            t2.Wait();
            t3.Wait();

            Program.PressAnyKeyToContinue();
            
        }

        static void PrintTime(string task)
        {
            var now = DateTime.Now;
            Console.WriteLine($"{task, -30} - {now}.{now.Millisecond}.{now.Microsecond}.{now.Nanosecond}");
        }
    }

    class Task2
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Task2");
            Task t = Task.Run(PrintPrimeNums0_1000);
            t.Wait();
            Program.PressAnyKeyToContinue();


        }

        static void PrintPrimeNums0_1000()
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (IsPrime(i))
                    Console.WriteLine(i);
            }
        }

        public static bool IsPrime(int num)
        {
            if (num <= 1)
                return false;
            
            for (int i = 2; i <= Math.Sqrt(num); ++i)
            {
                if (num == i) continue;

                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }

    class Task3
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Task3");
            int start = 0, end = 0;
            Console.Write("Початкове число пошуку простих чисел: ");
            int.TryParse(Console.ReadLine(), out start);
            Console.Write("Кінцеве число пошуку простих чисел: ");
            int.TryParse(Console.ReadLine(), out end);
            Task<int> t = Task.Run(() => { return PrintPrimeNumsInRange(start, end); });
            Console.WriteLine($"Кількість простих чисел {t.Result}");
            Program.PressAnyKeyToContinue();

        }

        public static int PrintPrimeNumsInRange(int start, int end)
        {
            start = Math.Max(2, start);

            int counter = 0;
            for (int i = start; i <= end; ++i)
            {
                if (Task2.IsPrime(i))
                {
                    Console.WriteLine(i);
                    counter++;
                }
            }

            return counter;
        }
    }

    class Task4
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Task4");
            List<int> list = new List<int>(200);
            for (int i = 0; i < list.Capacity; ++i)
                list.Add(Program.random.Next());
            Console.WriteLine("Масив створено!");

            Task<int> t_min = Task.Run(() => { return list.Min(); });
            Task<int> t_max = Task.Run(() => { return list.Max(); });
            Task<double> t_avg = Task.Run(() => { return list.Average(); });
            Task<long> t_sum = Task.Run(() => { return list.Sum(n => (long)n); });

            Console.WriteLine($"Min {t_min.Result}");
            Console.WriteLine($"Max {t_max.Result}");
            Console.WriteLine($"Avg {t_avg.Result}");
            Console.WriteLine($"Sum {t_sum.Result}");

            Program.PressAnyKeyToContinue();

        }


    }

    class Task5
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Task5");
            List<int> list = new List<int>(200);
            for (int i = 0; i < list.Capacity; ++i)
                list.Add(Program.random.Next());
            Console.WriteLine("Масив створено!");

            Task<int> t = Task.Run(list.Distinct)
                .ContinueWith(prev => list.Sort())
                .ContinueWith(prev => list.BinarySearch(list[27]));

            Console.WriteLine($"Індекс шуканого елемента {t.Result} (необхідний результат 27)");
            Program.PressAnyKeyToContinue();

        }
    }

    internal class Program
    {
        public static Random random = new Random();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    if (ShowMenu()) return;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Помилка: " + e.Message);
                    PressAnyKeyToContinue();
                }
            }
        }
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Натисніть на будь-яку клавішу щоб продовжити...");
            Console.ReadKey();
        }

        static int GetChoise(int min, int max)
        {
            while (true)
            {
                int choise = 0;
                Console.WriteLine(">> ");
                bool isSuccess = int.TryParse(Console.ReadLine(), out choise);
                if (isSuccess && choise >= min && choise <= max)
                {
                    return choise;
                }
            }
        }

        static bool ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Task1 - Поточна дата та час");
            Console.WriteLine("2. Task2 - Прості числа від 0 до 1000");
            Console.WriteLine("3. Task3 - Прості числа від вдосконалине");
            Console.WriteLine("4. Task4 - Пошук у масиві");
            Console.WriteLine("5. Task5 - Робота з масивом");
            Console.WriteLine("0. Вийти");

            int choise = GetChoise(0, 5);

            switch (choise)
            {
                case 1:
                    Task1.Start();
                    break;
                case 2:
                    Task2.Start();
                    break;
                case 3:
                    Task3.Start();
                    break;
                case 4:
                    Task4.Start();
                    break;
                case 5:
                    Task5.Start();
                    break;
                default:
                    return true;
            }

            return false;
        }
    }
}
