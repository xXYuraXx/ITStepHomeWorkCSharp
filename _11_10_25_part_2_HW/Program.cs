namespace _11_10_25_part_2_HW
{
    internal class Program
    {
        static void PrintFibNumbers(int from, int to)
        {
            if (from > to)
            {
                Console.WriteLine("Invalid range");
                return;
            }

            int a = 0, b = 1;

            if (a >= from && a <= to)
            {
                Console.Write(a + " ");
            }
            if (b >= from && b <= to)
            {
                Console.Write(b + " ");
            }

            int c = a + b;
            while (c <= to)
            {
                if (c >= from)
                {
                    Console.Write(c + " ");
                }
                a = b;
                b = c;
                c = a + b;
            }
            Console.WriteLine();
        }

        static void PrintNumsFromAtoB(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine("Invalid range");
                return;
            }
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintLine(int len, char ch, char orientation)
        {
            if (len <= 0)
            {
                Console.WriteLine("Invalid length");
                return;
            }
            if (orientation == 'h')
            {
                for (int i = 0; i < len; i++)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
            else if (orientation == 'v')
            {
                for (int i = 0; i < len; i++)
                {
                    Console.WriteLine(ch);
                }
            }
            else
            {
                Console.WriteLine("Invalid orientation");
            }
        }

        static void Main(string[] args)
        {
            PrintFibNumbers(0, 100);
            PrintFibNumbers(50, 200);
            PrintNumsFromAtoB(3, 7);
            PrintNumsFromAtoB(15, 16);
            PrintLine(10, '*', 'h');
            PrintLine(5, '#', 'v');

            int fib_start, fib_end;
            Console.WriteLine("Fib nums from: ");
            fib_start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To: ");
            fib_end = Convert.ToInt32(Console.ReadLine());
            PrintFibNumbers(fib_start, fib_end);

            int num_start, num_end;
            Console.WriteLine("Nums from: ");
            num_start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To: ");
            num_end = Convert.ToInt32(Console.ReadLine());
            PrintNumsFromAtoB(num_start, num_end);

            int line_len;
            char line_ch, line_orient;
            Console.WriteLine("Line len: ");
            line_len = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Line char: ");
            line_ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Line orientation (h, v): ");
            line_orient = Convert.ToChar(Console.ReadLine());
            PrintLine(line_len, line_ch, line_orient);


        }
    }
}
