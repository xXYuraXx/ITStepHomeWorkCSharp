using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _13_12_25_part_2_TCPListener_HW
{
    internal class Program
    {
        static string GetRandQuote()
        {
            string[] quotes =
            {
                "The only way to do great work is to love what you do.",
                "Talk is cheap. Show me the code.",
                "Programs must be written for people to read.",
                "First, solve the problem. Then, write the code.",
                "Experience is the name everyone gives to their mistakes.",
                "In order to be irreplaceable, one must always be different.",
                "Knowledge is power.",
                "Stay hungry, stay foolish.",
                "Simplicity is the soul of efficiency.",
                "Before software can be reusable it first has to be usable.",
                "Make it work, make it right, make it fast.",
                "Any fool can write code that a computer can understand.",
                "Code never lies, comments sometimes do.",
                "Fix the cause, not the symptom.",
                "The best error message is the one that never shows up."
            };
            Random random = new Random();
            return quotes[random.Next(0, quotes.Length)];

        }

        static void HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            Console.WriteLine($"{DateTime.Now.ToString()} {client.Client.RemoteEndPoint} connected.");

            while (true)
            {
                byte[] buffer = new byte[1024];
                int count = stream.Read(buffer, 0, buffer.Length);
                string answ = Encoding.UTF8.GetString(buffer, 0, count);
                if (answ == "quote")
                {
                    string q = GetRandQuote();
                    Console.WriteLine($"{DateTime.Now.ToString()} {client.Client.RemoteEndPoint} get quote: \"{q}\"");
                    stream.Write(Encoding.UTF8.GetBytes(q));
                }
                else if (answ == "exit")
                {
                    Console.WriteLine($"{DateTime.Now.ToString()} {client.Client.RemoteEndPoint} disconected.");
                    client.Close();
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();


            Console.WriteLine("Server started!");
            while (true)
            {
                Console.WriteLine("Wait for client...");
                TcpClient client = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    try
                    {
                        HandleClient(client);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()} Error occured with {client?.Client?.RemoteEndPoint}");
                    }
                });
            }
        }
    }
}
