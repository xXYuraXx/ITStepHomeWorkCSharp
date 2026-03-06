using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace _20_12_25_part_1_Files_HW
{
    class FileManager
    {
        private string _currentDir;

        public string CurrentDir
        {
            get { return _currentDir; }
            set
            {
                if (Directory.Exists(value))
                {
                    SelectedContentIdx = 0;
                    _currentDir = Path.TrimEndingDirectorySeparator(value);
                }
                else
                {
                    throw new Exception("No such directory");
                }
            }
        }

        public string[] CurFiles { get; set; }
        public string[] CurDirs { get; set; }
        public string[] CurContent { get; set; }


        public string SelectedObj
        {
            get { return CurContent[SelectedContentIdx]; }
        }

        private int _selectedContentIdx;

        public int SelectedContentIdx
        {
            get { return _selectedContentIdx; }
            set
            {
                if (CurContent == null)
                {
                    _selectedContentIdx = 0;
                    return;
                }

                if (value >= 0 && value < CurContent.Length)
                {
                    _selectedContentIdx = value;
                }
            }
        }





        public FileManager()
        {
            CurrentDir = AppContext.BaseDirectory;


        }

        public void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Update();
        }

        public void PrintDirContent()
        {

            var dirs = Directory.GetDirectories(CurrentDir);
            var files = Directory.GetFiles(CurrentDir);
            var content = dirs.Concat(files).ToArray();
            int startIdx = Math.Max(SelectedContentIdx - 4, 0);
            int endIdx = Math.Min(startIdx + 8, content.Length-1);
            for (int i = startIdx; i <= endIdx; ++i)
            {
                var item = content[i];
                if (File.Exists(item))
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                if (i == SelectedContentIdx)
                    Console.Write("> ");
                else
                    Console.Write("  ");
                Console.WriteLine(Path.GetFileName(item));
            }
            if (endIdx < content.Length - 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("...");
            }


            Console.ResetColor();
            
        }

        public void UpdateContent()
        {
            CurDirs = Directory.GetDirectories(CurrentDir);
            CurFiles = Directory.GetFiles(CurrentDir);
            CurContent = CurDirs.Concat(CurFiles).ToArray();
        }

        public void Update()
        {
            while (true)
            {
                UpdateContent();
                Console.Clear();
                Console.WriteLine($"{CurrentDir}>");
                PrintDirContent();


                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.H:
                        Help();
                        break;
                    case ConsoleKey.LeftArrow:
                        PreviousDir();
                        break;
                    case ConsoleKey.RightArrow:
                        EnterDir();
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedContentIdx -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedContentIdx += 1;
                        break;
                    case ConsoleKey.Enter:
                        Enter();
                        break;
                    case ConsoleKey.Backspace:
                        Delete();
                        break;
                }


            }
        }
        public void Help()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("== HELP ==");
            sb.AppendLine("- Клавіши для керування");
            sb.AppendLine("H - Допомога");
            sb.AppendLine("LeftArrow - Попередня директорія");
            sb.AppendLine("RightArrow - Зайти у вибрану директорію");
            sb.AppendLine("Enter - Відкрити файл (або перейти у вибрану директорію)");
            sb.AppendLine("Backspace - Видалити файл");
            Console.Clear();
            Console.WriteLine(sb.ToString());
            PressAnyKeyToContinue();

        }

        public void PreviousDir()
        {
            var prevDir = Directory.GetParent(CurrentDir);

            if (prevDir == null) return;

            try
            {
                CurrentDir = prevDir.FullName;
            }
            catch (Exception)
            {
                Console.WriteLine("Помилка програми, неможливо піти назад");
                PressAnyKeyToContinue();
            }
            
        }

        public void EnterDir()
        {
            if (File.Exists(SelectedObj))
            {
                Console.WriteLine("Це не папка, ви хочете відкрити цей файл?");
                Console.WriteLine("Esc - Ні, Enter - Так");
                while (true)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        EnterFile();
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        return;
                    }
                }
            }
            try
            {
                CurrentDir = SelectedObj;
            }
            catch (Exception)
            {
                Console.WriteLine("Помилка програми, неможливо зайти в директорію");
                PressAnyKeyToContinue();
            }
            
        }

        public void EnterFile()
        {
            if (File.Exists(SelectedObj))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(SelectedObj) { UseShellExecute = true });
                }
                catch (Exception)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo("notepad.exe", SelectedObj) { UseShellExecute = true });
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Неможливо відкрити файл");
                        PressAnyKeyToContinue();
                    }
                }
            }
        }

        public void Enter()
        {
            if (File.Exists(SelectedObj))
            {
                EnterFile();
            }
            else if (Directory.Exists(SelectedObj))
            {
                EnterDir();
            }
        }

        public void Delete()
        {
            Console.WriteLine($"Ви дійсно хочете видалити вибраний файл/папку ? - {Path.GetFileName(SelectedObj)}");
            Console.WriteLine("Esc - ні, Enter - так");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
                return;
            else if (key == ConsoleKey.Enter)
            {
                if (File.Exists(SelectedObj))
                {
                    File.Delete(SelectedObj);
                }
                else if (Directory.Exists(SelectedObj))
                {
                    Directory.Delete(SelectedObj);
                }
            }
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }


    internal class Program
    {


        static void Main(string[] args)
        {
            FileManager manager = new FileManager();
            manager.Start();
        }
    }
}
