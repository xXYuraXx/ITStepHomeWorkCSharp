using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_11_25_part_3_HW_Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string task1Str = "";

        private void startTask1Btn_Click(object sender, EventArgs e)
        {
            int count_threads = (int)countThreadsBox.Value;
            int start = (int)startNumBox.Value;
            int end = (int)endNumBox.Value;
            PrintNums(count_threads, start, end);


        }

        void PrintTextBoxConsole(object text)
        {
            if (text == null) return;

            string str = text.ToString();
            consoleRichTextBox.AppendText(str + '\n');
        }
        void PrintNums(int count_threads = 1, int start = 0, int end = 50)
        {
            if (count_threads <= 0) return;
            if (start > end) return;

            task1Str = "";

            Thread[] threads = new Thread[count_threads];

            for (int i = 0; i < count_threads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = start; j <= end; j++)
                    {
                        task1Str += j.ToString() + "\n";
                        
                    }
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            PrintTextBoxConsole(task1Str);
        }



        private void startTask4Btn_Click(object sender, EventArgs e)
        {
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }


            int maxValue = arr[0];
            Thread maxThread = new Thread(() =>
            {
                foreach (var num in arr)
                {
                    if (num > maxValue)
                    {
                        maxValue = num;
                    }
                }
            });
            maxThread.Start();

            

            int minValue = arr[0];
            Thread minThread = new Thread(() =>
            {
                foreach (var num in arr)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }
            });
            minThread.Start();

            

            int avgValue = 0;
            Thread avgThread = new Thread(() =>
            {
                long sum = 0;
                foreach (var num in arr)
                {
                    sum += num;
                }
                avgValue = (int)(sum / arr.Length);
            });
            avgThread.Start();



            maxThread.Join();
            minThread.Join();
            avgThread.Join();


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Thread writeFileThread = new Thread(() =>
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Max: " + maxValue);
                        writer.WriteLine("Min: " + minValue);
                        writer.WriteLine("Avg: " + avgValue);
                    }
                });
                writeFileThread.Start();
            }
        }

        private void clearConsoleBtn_Click(object sender, EventArgs e)
        {
            consoleRichTextBox.Clear();
            task1Str = "";
        }
    }
}
