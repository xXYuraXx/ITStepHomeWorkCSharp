using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace _20_12_25_part_2_HttpJSON_HW
{
    class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public override string ToString()
        {
            return string.Join('\n', userId, id, title, body);
        }
    }
    class Comment
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
        public override string ToString()
        {
            return string.Join('\n', userId, id, name, email, body);
        }
    }
    class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public override string ToString()
        {
            return string.Join('\n', userId, id, title);
        }
    }
    class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public override string ToString()
        {
            return string.Join('\n', albumId, id, title, url, thumbnailUrl);
        }
    }
    class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public override string ToString()
        {
            return string.Join('\n', userId, id, title, completed);
        }
    }
    class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
        public override string ToString()
        {
            return string.Join('\n', id, name, username, email, address, phone, website, company.ToString());
        }
    }
    class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
        public override string ToString()
        {
            return string.Join('\n', street, suite, city, zipcode, geo.ToString());
        }
    }
    class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public override string ToString()
        {
            return string.Join('\n', lat, lng);
        }
    }
    class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        public override string ToString()
        {
            return string.Join('\n', name, catchPhrase, bs);
        }
    }


    internal class Program
    {

        static async Task ShowJSONPage<T>(string page, int startIdx = 0, int? endIdx = null)
        {
            page = page.ToLower();
            const string baseUrl = @"https://jsonplaceholder.typicode.com";
            string url = baseUrl + "/" + page;
            HttpClient client = new HttpClient();
            string rawJson = await client.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<List<T>>(rawJson);
            
            int start = Math.Max(startIdx, 0);
            int end;
            if (endIdx != null)
            {
                end = Math.Min((int)endIdx, data == null ? 0 : data.Count);
            }
            else
            {
                end = data == null ? 0 : data.Count;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; ++i)
            {
                sb.AppendLine(data?[i]?.ToString());
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

        }

        static async Task App()
        {

        }

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("== Додаток для звертання до API ==");

                Console.WriteLine("1. Posts");
                Console.WriteLine("2. Comments");
                Console.WriteLine("3. Albums");
                Console.WriteLine("4. Photos");
                Console.WriteLine("5. Todos");
                Console.WriteLine("6. Users");
                Console.WriteLine("0. Exit");
                Console.Write("> ");

                bool isChoosen = false;
                while (!isChoosen)
                {
                    isChoosen = true;
                    int choise = -1;
                    int.TryParse(Console.ReadLine(), out choise);
                    switch (choise)
                    {
                        case 1:
                            await ShowJSONPage<Post>("posts", 0, 20);
                            break;
                        case 2:
                            await ShowJSONPage<Comment>("comments", 0, 20);
                            break;
                        case 3:
                            await ShowJSONPage<Album>("albums", 0, 20);
                            break;
                        case 4:
                            await ShowJSONPage<Photo>("photos", 0, 20);
                            break;
                        case 5:
                            await ShowJSONPage<Todo>("todos", 0, 20);
                            break;
                        case 6:
                            await ShowJSONPage<User>("users", 0, 20);
                            break;
                        case 0:
                            return;
                        default:
                            isChoosen = false;
                            break;
                    }
                }
            }



        }
    }
}
