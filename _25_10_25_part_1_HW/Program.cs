using System.Text;

namespace _25_10_25_part_1_HW
{
    internal class Program
    {
        static void Task5(string text, int position)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (position > 0 && position <= words.Length)
            {
                string word = words[position - 1];
                Console.WriteLine($"Word at {position}: {word}");
                Console.WriteLine($"First letter: {word[0]}");
            }
            else
            {
                Console.WriteLine("Wrong position.");
            }
        }

        static void Task6(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string newText = string.Join("*", words);
            Console.WriteLine("New text: " + newText);
        }

        static void Task7()
        {
            StringBuilder result = new StringBuilder();
            Console.WriteLine("Enter words (enter '.' in the end to stop): ");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.EndsWith('.'))
                {
                    result.Append(input);
                    break;
                }
                else
                {
                    result.Append(input + ", ");
                }
            }

            Console.WriteLine("Total text: " + result.ToString());
        }

        static void Main(string[] args)
        {
            string task5Input = "This is a senteeeencce tesst";
            int pos = 4;
            Console.WriteLine($"\"{task5Input}\", pos: {pos}");
            Task5(task5Input, pos);

            string task6Input = "   My   sen   ten   ce   ";
            Console.WriteLine($"\"{task6Input}\"");
            Task6(task6Input);

            Task7();
        }
    }
}
