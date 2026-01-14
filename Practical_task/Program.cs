using System.Diagnostics;

namespace Practical_task
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var cur_processes = Process.GetProcesses();
            for (int i = 0; i < cur_processes.Length; i++)
            {
                Console.WriteLine($"{cur_processes[i].ProcessName} - ID: {cur_processes[i].Id}");
            }
        }
    }
}