using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _13_12_25_part_2_TCPListener_Client_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 5000);
            var stream = client.GetStream();
            Console.WriteLine("Avaible commands: quote, exit.");
            while (true)
            {
                Console.Write("> ");
                string inp = Console.ReadLine().ToLower();
                stream.Write(Encoding.UTF8.GetBytes(inp));


                if (inp == "quote")
                {
                    byte[] buffer = new byte[1024];
                    int count = stream.Read(buffer);
                    string answ = Encoding.UTF8.GetString(buffer, 0, count);
                    Console.WriteLine($"Quote: \"{answ}\"");
                }
                else if (inp == "exit")
                {
                    Console.WriteLine("Bye!");
                    stream.Close();
                    client.Close();
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }

                
            }
        }
    }
}
