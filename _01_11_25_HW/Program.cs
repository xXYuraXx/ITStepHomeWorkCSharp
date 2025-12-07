namespace _01_11_25_HW
{
    class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Sub(double a, double b)
        {
            return a - b;
        }
        public static double Mul(double a, double b)
        {
            return a * b;
        }
        public static double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Denominator can't be zero");
            }
            return a / b;
        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            string charList = "(+, -, *, /)";
            bool isRunning = true;
            while (isRunning)
            {
                double num1, num2;
                char operation;
                try
                {
                    Console.Write("Enter num1: ");
                    num1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter num2: ");
                    num2 = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter num");
                    continue;
                }
                Console.Write($"Enter operation {charList}: ");
                string opInput = Console.ReadLine();
                if (string.IsNullOrEmpty(opInput) || opInput.Length != 1)
                {
                    Console.WriteLine($"Invalid operation. Please enter single char {charList}");
                    continue;
                }
                operation = opInput[0];
                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = Calculator.Add(num1, num2);
                        break;
                    case '-':
                        result = Calculator.Sub(num1, num2);
                        break;
                    case '*':
                        result = Calculator.Mul(num1, num2);
                        break;
                    case '/':
                    {
                        try
                        {
                            result = Calculator.Div(num1, num2);
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        break;
                    }
                    default:
                        Console.WriteLine($"Invalid operation. Please enter {charList}");
                        continue;
                }
                Console.WriteLine($"Result: {result}");

            }
        }
    }
}
