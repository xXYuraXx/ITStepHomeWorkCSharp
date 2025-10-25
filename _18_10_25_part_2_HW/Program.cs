namespace _18_10_25_part_2_HW
{
    internal class Program
    {
        static void Task3(string text)
        {
            int uppeCount = 0, lowerCount = 0;

            foreach (char c in text)
            {
                if (char.IsUpper(c)) uppeCount++;
                else if (char.IsLower(c)) lowerCount++;
            }

            int totalLetters = uppeCount + lowerCount;
            if (totalLetters > 0)
            {
                double uppePercent = (double)uppeCount / totalLetters * 100;
                double lowerPercent = (double)lowerCount / totalLetters * 100;

                Console.WriteLine($"Upper letters: {Math.Round(uppePercent, 2)}%");
                Console.WriteLine($"Lower letters: {Math.Round(lowerPercent, 2)}%");
            }
            else
            {
                Console.WriteLine("No letters in text.");
            }
        }

        static void Task4(string[] words, int countSymbs)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, Math.Max(words[i].Length - countSymbs, 0)) + new string('$', Math.Min(countSymbs, words[i].Length));
            }

            Console.WriteLine("Modified words: " + string.Join(", ", words));
        }

        static void Main(string[] args)
        {
            string task3Input = "Hello my World!";
            Console.WriteLine($"\"{task3Input}\"");
            Task3(task3Input);

            string[] task4Input = { "example", "test", "ty", "programming", "apple" };
            int countSymbs = 3;
            Console.WriteLine(string.Join(", ", task4Input));
            Console.WriteLine("Count $: " + countSymbs);
            Task4(task4Input, countSymbs);
        }
    }
}
