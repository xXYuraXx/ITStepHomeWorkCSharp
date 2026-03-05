using System.Net.Http.Headers;
using System.Text;

namespace _13_12_25_part_1_Generic_HW
{
    class ENUA_Dict
    {
        private Dictionary<string, LinkedList<string>> _dict; // English, Ukraine - words
        public ENUA_Dict()
        {
            _dict = new Dictionary<string, LinkedList<string>>();
        }

        public bool AddTranslate(string eng_word, string ukr_word)
        {
            if (string.IsNullOrEmpty(eng_word) || string.IsNullOrEmpty(ukr_word)) return false;

            eng_word = eng_word.ToLower();
            ukr_word = ukr_word.ToLower();

            if (!_dict.ContainsKey(eng_word))
                _dict.Add(eng_word, new LinkedList<string>());

            if (_dict[eng_word].Contains(ukr_word)) return true;

            _dict[eng_word].AddLast(ukr_word);

            return true;
        }

        public bool RemoveTranslate(string eng_word, string ukr_word)
        {
            if (string.IsNullOrEmpty(eng_word) || string.IsNullOrEmpty(ukr_word)) return false;

            eng_word = eng_word.ToLower();
            ukr_word = ukr_word.ToLower();

            if (!_dict.ContainsKey(eng_word)) return false;
            return _dict[eng_word].Remove(ukr_word);
        }

        public bool RemoveTranslate(string eng_word)
        {
            if (string.IsNullOrEmpty(eng_word)) return false;

            eng_word = eng_word.ToLower();

            return _dict.Remove(eng_word);
        }

        public bool ChangeTranslate(string eng_word, string from_ukr_word, string to_ukr_word)
        {
            if (string.IsNullOrEmpty(eng_word)
                || string.IsNullOrEmpty(from_ukr_word)
                || string.IsNullOrEmpty(to_ukr_word)) return false;

            eng_word = eng_word.ToLower();
            from_ukr_word = from_ukr_word.ToLower();
            to_ukr_word= to_ukr_word.ToLower();

            if (!_dict.ContainsKey(eng_word)) return false;
            var node = _dict[eng_word].Find(from_ukr_word);
            if (node == null) return false;
            node.ValueRef = to_ukr_word;
            return true;
        }

        public LinkedList<string>? GetTranslate(string eng_word)
        {
            if (string.IsNullOrEmpty(eng_word)) return null;
            if (!_dict.ContainsKey(eng_word)) return null;
            return _dict[eng_word];
        }
        public string GetTranslateString(string eng_word)
        {
            LinkedList<string>? words = GetTranslate(eng_word);
            if (words == null)
                return "No Translate";
            return string.Join(", ", words.ToArray());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _dict)
            {
                sb.AppendLine($"{item.Key} - {GetTranslateString(item.Key)}");
            }
            return sb.ToString().Trim();
        }
    }


    internal class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Task 1
            int a = 1, b = 2;
            Console.WriteLine($"a = {a}, b = {b}");
            Swap<int>(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            // Task 2
            ENUA_Dict myDict = new ENUA_Dict();
            Console.WriteLine("== English - Ukrainian Dict ==");
            myDict.AddTranslate("word", "слово");
            myDict.AddTranslate("worD", "Слівце");
            myDict.AddTranslate("worD", "TEST");
            myDict.AddTranslate("apple", "Яблуко");
            myDict.AddTranslate("apple", "компанія \"Apple\"");
            Console.WriteLine(myDict.ToString());
            Console.WriteLine();
            Console.WriteLine("Прибираю з word переклад test");
            Console.WriteLine();
            myDict.RemoveTranslate("woRd", "test");
            Console.WriteLine(myDict.ToString());


        }
    }
}
