using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06_12_25_part_2_TCP_Client_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);

            client.Connect(ipEnd);

            byte[] recvBuffer = new byte[1024];
            int lenRecv = client.Receive(recvBuffer);

            Console.WriteLine($"In {DateTime.Now.ToShortTimeString()} from {client.RemoteEndPoint?.ToString()} recive string: {Encoding.UTF8.GetString(recvBuffer, 0, lenRecv)}");

            string text = "Hi server!";
            var textSend = Encoding.UTF8.GetBytes(text);
            client.Send(textSend);

            Console.WriteLine("Choose command on server");
            Console.WriteLine("1 - Date");
            Console.WriteLine("2 - Time");
            textSend = Encoding.UTF8.GetBytes(Console.ReadLine());
            client.Send(textSend);

            recvBuffer = new byte[1024];
            lenRecv = client.Receive(recvBuffer);

            Console.WriteLine(Encoding.UTF8.GetString(recvBuffer, 0, lenRecv));

            Console.WriteLine("Programm end...");
            Console.ReadLine();
        }
    }
}
