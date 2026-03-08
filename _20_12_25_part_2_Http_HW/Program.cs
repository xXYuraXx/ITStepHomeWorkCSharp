using System.Text;

namespace _20_12_25_part_2_Http_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("== Додаток для завантаження зображень ==");
            while (true)
            {
                Task.Run(DownloadImg).Wait();
            }
            
        }

        public static async Task DownloadImg()
        {
            HttpClient client = new HttpClient();

            byte[] bytes;
            while (true)
            {
                try
                {
                    Console.Write("Введіть посилання на зображення: ");
                    string url = Console.ReadLine();
                    Console.WriteLine("Зчитуємо..");
                    bytes = await client.GetByteArrayAsync(url);
                    Console.WriteLine("Готово!");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Помилка: не вдалось зчитати зображення :(");
                }
            }
            if (bytes == null)
            {
                Console.WriteLine("Помилка: не вдалось видобути зображення :(");
                return;
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.Write($"Шлях збереження: (по замовчуванню {path}): ");
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp) && Directory.Exists(inp))
            {
                path = inp;
            }
            string name = $"image_{new Random().Next(1000000, 9999999)}.jpg";
            Console.Write($"Назва файлу: (по замовчуванню {name}): ");
            inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp) && Path.HasExtension(inp))
            {
                name = inp;
            }
            try
            {
                string file_path = Path.Combine(path, name);
                await File.WriteAllBytesAsync(file_path, bytes);
                Console.WriteLine($"Збережено в {file_path}!");
            }
            catch (Exception)
            {
                Console.WriteLine("Не вдалося зберегти..");
            }
            
        }
    }
}
