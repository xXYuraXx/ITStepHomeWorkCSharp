using System.Drawing;

namespace _06_12_25_part_1_Delegates_HW
{
    class ArrayMethods
    {
        public delegate bool NumberPredicat(int n);

        public static int[] GetArrayWithPredicat(int[] arr, NumberPredicat np)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (var item in arr)
            {
                if (np(item))
                {
                    list.AddLast(item);
                }
            }
            return list.ToArray();
        }
        public static void PrintArr(int[] arr)
        {
            foreach (var el in arr)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public static bool IsOdd(int n)
        {
            return n % 2 != 0;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i * i <= n; ++i)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static bool IsFibonaci(int n)
        {
            if (n < 0) return false;

            int n1 = 0, n2 = 1;
            while (n1 <= n)
            {
                if (n1 == n || n2 == n) return true;
                (n1, n2) = (n2, n2 + n1);
            }
            return false;
        }

        
    }


    internal class Program
    {
        public static void PrintCurTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
        public static void PrintCurDate()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy.MM.dd"));
        }
        public static void PrintDayOfWeek()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
        public static double GetAreaOfTriangle(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }
        public static double GetAreaOfRectangle(double a, double b)
        {
            return a * b;
        }



        static void Task1()
        {
            Console.WriteLine("Task1");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            ArrayMethods.PrintArr(ArrayMethods.GetArrayWithPredicat(arr, ArrayMethods.IsEven));
            ArrayMethods.PrintArr(ArrayMethods.GetArrayWithPredicat(arr, ArrayMethods.IsOdd));
            ArrayMethods.PrintArr(ArrayMethods.GetArrayWithPredicat(arr, ArrayMethods.IsPrime));
            ArrayMethods.PrintArr(ArrayMethods.GetArrayWithPredicat(arr, ArrayMethods.IsFibonaci));
        }

        static void Task2()
        {
            Action[] myActions = { PrintCurTime, PrintCurDate, PrintDayOfWeek };
            foreach (var act in myActions)
                act();
            Func<double, double, double, double> math3arg = GetAreaOfTriangle;
            Func<double, double, double> math2arg = GetAreaOfRectangle;
            Console.WriteLine(math3arg(5,6,8));
            Console.WriteLine(math2arg(5.4, 10));
        }

        static void Task3()
        {
            Func<string, Tuple<byte, byte, byte>> getRGB = (colorName) =>
            {
                Color color = Color.FromName(colorName);

                if (!color.IsKnownColor) throw new Exception("Unknown color");

                return new Tuple<byte, byte, byte>(color.R, color.G, color.B);

            };

            var rgb1 = getRGB("Red");
            Console.WriteLine($"Red = ({rgb1.Item1}, {rgb1.Item2}, {rgb1.Item3})");
        }

        static void Task4()
        {
            Func<int[], int, int, int> countNumsInDiapasone = (arr, minD, maxD) =>
            {
                return arr.Count((val) =>
                {
                    return val >= minD && val <= maxD;
                });
            };
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Console.WriteLine(countNumsInDiapasone(arr, 4, 7));
            Console.WriteLine(countNumsInDiapasone(arr, 1, 25));
        }

        static void Task5()
        {
            Func<string, string, int> countWordsInText = (text, word) =>
            {
                word = word.ToLower();
                text = text.ToLower();
                int cnt = 0;
                int startIdx = 0;
                while (true)
                {
                    int pos = text.IndexOf(word, startIdx);
                    if (pos == -1)
                        break;
                    startIdx = pos+1;
                    cnt++;
                }
                return cnt;
            };

            string text = "word My long text word, and some word... la la wordla word";
            Console.WriteLine(text);
            string word = "word";
            Console.WriteLine(word);
            Console.WriteLine(countWordsInText(text, word));
            word = "la";
            Console.WriteLine(word);
            Console.WriteLine(countWordsInText(text, word));


        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();


        }
    }
}
