

using System.Net;
using System.Text;
using System.Xml.Linq;

namespace _10_01_26_Linq_HW
{
    class Firma
    {
        public string Name { get; set; } = string.Empty;
        public DateTime FoundationDate { get; set; } = DateTime.Now;
        public string BusinessProfile { get; set; } = string.Empty;
        public string DirectorFullname { get; set; } = string.Empty;
        public int CountWorkers { get; set; } = 0;

        public List<Worker> Workers { get; set; } = new List<Worker>();
        public string Address { get; set; } = string.Empty;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Foundation Date: {FoundationDate}");
            sb.AppendLine($"Business Profile: {BusinessProfile}");
            sb.AppendLine($"Director Fullname: {DirectorFullname}");
            sb.AppendLine($"Count Workers: {CountWorkers}");
            sb.AppendLine($"Workers: {string.Join(", ", Workers.Select(w => w.Fullname))}");
            sb.AppendLine($"Address: {Address}");
            return sb.ToString();
        }
    }
    class Worker
    {
        public string Fullname { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Salary { get; set; } = 0;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fullname: {Fullname}");
            sb.AppendLine($"Position: {Position}");
            sb.AppendLine($"Phone Number: {PhoneNumber}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Salary: {Salary}");
            return sb.ToString();
        }
    }


    internal class Program
    {
        static void PrintFirms(IEnumerable<Firma>? firms, string header)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(header);
            Console.ResetColor();
            Console.WriteLine();

            if (firms == null)
            {
                Console.WriteLine("No firms");
                return;
            }
            Console.WriteLine(string.Join('\n', firms));
        }
        static void PrintWorkers(IEnumerable<Worker>? workers, string header)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(header);
            Console.ResetColor();
            Console.WriteLine();

            if (workers == null)
            {
                Console.WriteLine("No workers");
                return;
            }
            Console.WriteLine(string.Join('\n', workers));
        }




        static void Main(string[] args)
        {
            List<Firma> firms = new List<Firma>
            {
                new Firma
                {
                    Name = "White Food Ltd",
                    FoundationDate = new DateTime(2020, 3, 10),
                    BusinessProfile = "Food",
                    DirectorFullname = "John White",
                    CountWorkers = 50,
                    Address = "London",
                    Workers = new List<Worker>
                    {
                        new Worker { Fullname="Lionel Smith", Position="Manager", PhoneNumber="231234", Email="di.smith@mail.com", Salary=2500 },
                        new Worker { Fullname="Anna Brown", Position="Cook", PhoneNumber="451234", Email="anna@mail.com", Salary=1800 },
                        new Worker { Fullname="David Green", Position="Accountant", PhoneNumber="239876", Email="david@mail.com", Salary=2200 }
                    }
                },

                new Firma
                {
                    Name = "Tech IT Solutions",
                    FoundationDate = new DateTime(2018, 7, 1),
                    BusinessProfile = "IT",
                    DirectorFullname = "Robert Black",
                    CountWorkers = 110,
                    Address = "New York",
                    Workers = new List<Worker>
                    {
                        new Worker { Fullname="Lionel Messi", Position="Developer", PhoneNumber="231111", Email="di.messi@mail.com", Salary=4000 },
                        new Worker { Fullname="Tom Hardy", Position="Manager", PhoneNumber="781234", Email="tom@mail.com", Salary=3500 },
                        new Worker { Fullname="Kate Wilson", Position="Tester", PhoneNumber="991234", Email="kate@mail.com", Salary=2700 }
                    }
                },

                new Firma
                {
                    Name = "Global Marketing Group",
                    FoundationDate = new DateTime(2025, 1, 15),
                    BusinessProfile = "Marketing",
                    DirectorFullname = "Alice White",
                    CountWorkers = 500,
                    Address = "London",
                    Workers = new List<Worker>
                    {
                        new Worker { Fullname="Daniel Craig", Position="Manager", PhoneNumber="231555", Email="di.craig@mail.com", Salary=3100 },
                        new Worker { Fullname="Sophia Turner", Position="Analyst", PhoneNumber="551234", Email="sophia@mail.com", Salary=2000 },
                        new Worker { Fullname="Mike Johnson", Position="Designer", PhoneNumber="231999", Email="mike@mail.com", Salary=2400 }
                    }
                },

                new Firma
                {
                    Name = "Black White Marketing",
                    FoundationDate = new DateTime(2019, 11, 5),
                    BusinessProfile = "Marketing",
                    DirectorFullname = "George Black",
                    CountWorkers = 200,
                    Address = "Berlin",
                    Workers = new List<Worker>
                    {
                        new Worker { Fullname="Lionel Brown", Position="Manager", PhoneNumber="231777", Email="di.brown@mail.com", Salary=3300 },
                        new Worker { Fullname="Emma Stone", Position="Marketer", PhoneNumber="451777", Email="emma@mail.com", Salary=2100 },
                        new Worker { Fullname="Chris Evans", Position="Manager", PhoneNumber="231888", Email="chris@mail.com", Salary=2900 }
                    }
                }
            };

            // Task 1
            var q1 = from f in firms
                     select f;
            PrintFirms(q1, "Querry 1");

            var q2 = from f in firms
                     where f.Name.Contains("Food")
                     select f;
            PrintFirms(q2, "Querry 2");

            var q3 = from f in firms
                     where f.BusinessProfile.ToLower() == "marketing"
                     select f;
            PrintFirms(q3, "Querry 3");

            var q4 = from f in firms
                     where f.BusinessProfile.ToLower() == "marketing"
                     || f.BusinessProfile.ToLower() == "it"
                     select f;
            PrintFirms(q4, "Querry 4");

            var q5 = from f in firms
                     where f.CountWorkers > 100
                     select f;
            PrintFirms(q5, "Querry 5");

            var q6 = from f in firms
                     where f.CountWorkers >= 100 && f.CountWorkers <= 300
                     select f;
            PrintFirms(q6, "Querry 6");

            var q7 = from f in firms
                     where f.Address.ToLower().Contains("london")
                     select f;
            PrintFirms(q7, "Querry 7");

            var q8 = from f in firms
                     where f.DirectorFullname.ToLower().Contains("white")
                     select f;
            PrintFirms(q8, "Querry 8");

            var q9 = from f in firms
                     where (DateTime.Now - f.FoundationDate).TotalDays >= 730
                     select f;
            PrintFirms(q9, "Querry 9");

            var q10 = from f in firms
                     where (DateTime.Now - f.FoundationDate).TotalDays >= 123
                     select f;
            PrintFirms(q10, "Querry 10");

            var q11 = from f in firms
                     where f.DirectorFullname.ToLower().Contains("black")
                     && f.Name.ToLower().Contains("white")
                     select f;
            PrintFirms(q11, "Querry 11");


            // Task 2
            var qm = firms.Select(f => f);
            PrintFirms(qm, "Querry 1 (analog)");
            qm = firms.Where(f => f.Name.Contains("Food"));
            PrintFirms(qm, "Querry 2 (analog)");
            qm = firms.Where(f => f.BusinessProfile.ToLower() == "marketing");
            PrintFirms(qm, "Querry 3 (analog)");
            qm = firms.Where(f => f.BusinessProfile.ToLower() == "marketing" || f.BusinessProfile.ToLower() == "it");
            PrintFirms(qm, "Querry 4 (analog)");
            qm = firms.Where(f => f.CountWorkers > 100);
            PrintFirms(qm, "Querry 5 (analog)");
            qm = firms.Where(f => f.CountWorkers >= 100 && f.CountWorkers <= 300);
            PrintFirms(qm, "Querry 6 (analog)");
            qm = firms.Where(f => f.Address.ToLower().Contains("london"));
            PrintFirms(qm, "Querry 7 (analog)");
            qm = firms.Where(f => f.DirectorFullname.ToLower().Contains("white"));
            PrintFirms(qm, "Querry 8 (analog)");
            qm = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays >= 730);
            PrintFirms(qm, "Querry 9 (analog)");
            qm = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays >= 123);
            PrintFirms(qm, "Querry 10 (analog)");
            qm = firms.Where(f => f.DirectorFullname.ToLower().Contains("black") && f.Name.ToLower().Contains("white"));
            PrintFirms(qm, "Querry 11 (analog)");


            // Task 3

            var qw = from w in firms.First(f => f.Name == "Tech IT Solutions").Workers
                     select w;
            PrintWorkers(qw, "Querry 1 Workers");

            qw = from w in firms.SelectMany(f => f.Workers)
                 where w.Salary > 3000
                     select w;
            PrintWorkers(qw, "Querry 2 Workers");

            qw = from w in firms.SelectMany(f => f.Workers)
                 where w.Position.ToLower().Contains("manager")
                     select w;
            PrintWorkers(qw, "Querry 3 Workers");

            qw = from w in firms.SelectMany(f => f.Workers)
                 where w.PhoneNumber.StartsWith("23")
                     select w;
            PrintWorkers(qw, "Querry 4 Workers");

            qw = from w in firms.SelectMany(f => f.Workers)
                 where w.Email.StartsWith("di")
                     select w;
            PrintWorkers(qw, "Querry 5 Workers");

            qw = from w in firms.SelectMany(f => f.Workers)
                 where w.Fullname.ToLower().Contains("lionel")
                     select w;
            PrintWorkers(qw, "Querry 6 Workers");


            


        }
    }
}
