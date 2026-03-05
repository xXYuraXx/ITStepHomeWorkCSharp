using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06_12_25_part_2_TCP_HW
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);
            
            server.Bind(ipEnd);

            server.Listen(5);

            var client = server.Accept();
            Console.WriteLine($"{client.RemoteEndPoint} connected");

            string text = "Hi client!";
            var sendText = Encoding.UTF8.GetBytes(text);

            client.Send(sendText);

            byte[] recvBuffer = new byte[1024];
            int lenRecv = client.Receive(recvBuffer);
            string? ip_str = client.RemoteEndPoint?.ToString();
            string asnw = Encoding.UTF8.GetString(recvBuffer, 0, lenRecv);

            Console.WriteLine($"In {DateTime.Now.ToShortTimeString()} from {ip_str} recive string: {asnw}");

            recvBuffer = new byte[1024];
            lenRecv = client.Receive(recvBuffer);
            asnw = Encoding.UTF8.GetString(recvBuffer, 0, lenRecv);
            switch (asnw)
            {
                case "1": // Дата
                    text = DateTime.Now.ToString("d");
                    break;
                case "2": // Час
                    text = DateTime.Now.ToString("t");
                    break;
                default:
                    text = "Unknown command";
                    break;
            }
            sendText = Encoding.UTF8.GetBytes(text);
            client.Send(sendText);

            Console.WriteLine("Programm end...");
            Console.ReadLine();
            client.Close();
        }
    }
}
