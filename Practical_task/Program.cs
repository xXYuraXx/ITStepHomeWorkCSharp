using System.Diagnostics;
using System.Threading;

namespace Practical_task
{
    
    internal class Program
    {
        static object writeLock = new object();
        static ManualResetEvent w_nr_event = new ManualResetEvent(true);

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread writeThread = new Thread(WriteDo);
                Thread readThread = new Thread(ReadDo);
                writeThread.Start();
                readThread.Start();
            }
        }

        static void WriteDo()
        {
            w_nr_event.Reset();
            Monitor.Enter(writeLock);
            Console.WriteLine("Writing...");
            Thread.Sleep(2000);
            Console.WriteLine("Write complete.");
            Monitor.Exit(writeLock);
            w_nr_event.Set();
        }

        static void ReadDo()
        {
            w_nr_event.WaitOne();
            Console.WriteLine("Reading...");
            Thread.Sleep(1000);
            Console.WriteLine("Read complete.");
        }
    }
}