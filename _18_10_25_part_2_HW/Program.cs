namespace _18_10_25_part_2_HW
{
    internal class Program
    {
        static string Task1_InsertStringAt(string original, string toInsert, int idx)
        {
            if (idx < 0 || idx > original.Length)
            {
                return original;
            }
            return original.Substring(0, idx) + toInsert + original.Substring(idx);
        }

        static bool Task2_IsPalindrome(string text)
        {
            for (int i = 0; i < text.Length / 2; i++)
            {
                if (text[i] != text[text.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

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

        static void CheckIsPalindrome(string text)
        {
            Console.WriteLine($"{text} - is{(Task2_IsPalindrome(text) ? "" : " not")} Palindrom");
        }

        static void Main(string[] args)
        {
            string task1Original = "HelloWorld";
            string task1ToInsert = "Beautiful";
            int task1Idx = 5;
            Console.WriteLine($"Original: {task1Original}\nTo Insert: {task1ToInsert}\nIndex: {task1Idx}");
            string task1Result = Task1_InsertStringAt(task1Original, task1ToInsert, task1Idx);
            Console.WriteLine($"Result: {task1Result}");
            Console.WriteLine();

            string task2_1 = "madam";
            string task2_2 = "hello";
            
            CheckIsPalindrome(task2_1);
            CheckIsPalindrome(task2_2);
            Console.WriteLine();

            string task3Input = "Hello my World!";
            Console.WriteLine($"\"{task3Input}\"");
            Task3(task3Input);
            Console.WriteLine();

            string[] task4Input = { "example", "test", "ty", "programming", "apple" };
            int countSymbs = 3;
            Console.WriteLine(string.Join(", ", task4Input));
            Console.WriteLine("Count $: " + countSymbs);
            Task4(task4Input, countSymbs);
            Console.WriteLine();
        }
    }
}
