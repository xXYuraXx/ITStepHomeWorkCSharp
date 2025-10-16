namespace _11_10_25_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's easy to win forgiveness for being wrong;\nbeing right is what gets you into real trouble.\nBjarne Stroustrup");


            double a, b, c, d, e;
            Console.WriteLine("Enter five numbers:");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            d = Convert.ToDouble(Console.ReadLine());
            e = Convert.ToDouble(Console.ReadLine());

            double sum = a + b + c + d + e;
            double biggest, smallest;
            biggest = Math.Max(Math.Max(a, b), Math.Max(Math.Max(c, d), e));
            smallest = Math.Min(Math.Min(a, b), Math.Min(Math.Min(c, d), e));
            double mult = a * b * c * d * e;
            Console.WriteLine($"Sum: {sum}\nBiggest: {biggest}\nSmallest: {smallest}\nMult: {mult}");

            Console.WriteLine("Enter 6 digits number:");
            int userNumber = Convert.ToInt32(Console.ReadLine());
            int dig1 = userNumber / 100000;
            int dig2 = (userNumber / 10000) % 10;
            int dig3 = (userNumber / 1000) % 10;
            int dig4 = (userNumber / 100) % 10;
            int dig5 = (userNumber / 10) % 10;
            int dig6 = userNumber % 10;

            Console.WriteLine($"{dig6}{dig5}{dig4}{dig3}{dig2}{dig1}");

        }
    }
}
