using System.IO;

namespace _08_11_25_part_1_HW
{
    internal class CreditCard
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set {
                if (value.Length != 16 || !value.All(char.IsDigit))
                    throw new ArgumentException("Credit card number must be 16 digits");
                _number = value;
            }
        }
        private string _cardholderName;
        public string CardholderName
        {
            get { return _cardholderName; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Cardholder name can't be empty");
                _cardholderName = value;
            }
        }
        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set {
                if (value <= DateTime.Now)
                    throw new ArgumentException("Expiration date must be in the future");
                _expirationDate = value;
            }
        }
        private string _cvv;
        public string CVV
        {
            get { return _cvv; }
            set {
                if (value.Length != 3 || !value.All(char.IsDigit))
                    throw new ArgumentException("CVV must be 3 digits");
                _cvv = value;
            }
        }
        public CreditCard(string number, string cardholderName, DateTime expirationDate, string cvv)
        {
            Number = number;
            CardholderName = cardholderName;
            ExpirationDate = expirationDate;
            CVV = cvv;
        }
        public override string ToString()
        {
            return $"Number: {Number}, CardholderName: {CardholderName}, ExpirationDate: {ExpirationDate.ToShortDateString()}, CVV: {CVV}";
        }
    }

    internal class MultCalculator
    {
        static public int CalculateMultiplyExpr(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
                throw new ArgumentException("Expression can't be null or empty");

            string[] nums = expr.Split('*');

            int multRes = 1;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (!nums[i].All(c => char.IsDigit(c) || c.CompareTo('-') == 0))
                    throw new FormatException("Expression can contain only digits and '*' symbol");
                int a = int.Parse(nums[i]);
                multRes *= a;
            }

            
            return multRes;
        }
    }
    internal class Program
    {

        static int ConvertToInt(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input can't be null or empty");

            input = input.TrimStart('0');
            if (string.IsNullOrEmpty(input))
                return 0;

            bool isAllDigits = input.All(char.IsDigit);
            if (!isAllDigits)
                throw new FormatException("Input can't contains non digit chars");

            if (input.Length > 10 || (input.Length == 10 && string.Compare(input, "2147483647") > 0))
                throw new OverflowException("Input is out of range for Int32");

            return int.Parse(input);
        }

        static void Task1()
        {
            string userInput = "";
            Console.Write("Enter number (you can use only chars 0-9): ");
            userInput = Console.ReadLine();
            try
            {
                Console.WriteLine("You entered: " + userInput);
                int convertedValue = ConvertToInt(userInput);
                Console.WriteLine("Converted to int: " + convertedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Task2()
        {
            try
            {
                Console.WriteLine("Creating card1...");
                CreditCard card1 = new CreditCard("1234123412341234", "Andiy Petritsuk", new DateTime(2025, 12, 31), "123");
                Console.WriteLine(card1.ToString());
                Console.WriteLine("Creating card2...");
                CreditCard card2 = new CreditCard("5678567", "Sasha Kozhemiakin", new DateTime(2023, 6, 30), "456");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating credit card: " + ex.Message);
            }
        }

        static void Task3()
        {
            string expr;
            Console.Write("Enter multiplication expression (like 2*3*4): ");
            expr = Console.ReadLine();
            try
            {
                int result = MultCalculator.CalculateMultiplyExpr(expr);
                Console.WriteLine("Mult result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}
