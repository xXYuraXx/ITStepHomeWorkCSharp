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

namespace _15_11_25_HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string SelectedPath { get; private set; }

        private void choosePathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowserDialog.SelectedPath;
                directoryPathTextBox.Text = SelectedPath;
            }
        }

        private void processCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedPath))
            {
                MessageBox.Show("Please select a directory");
                return;
            }

            if (!Directory.Exists(SelectedPath))
            {
                MessageBox.Show("Selected directory don't exist");
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(SelectedPath);
            FileInfo[] textFiles = dirInfo.GetFiles("*.txt");

            LinkedList<Thread> threads = new LinkedList<Thread>();
            TextFilesInfo textFilesInfo = new TextFilesInfo();

            foreach (FileInfo file in textFiles)
            {
                FileInfo cur_file = file;
                Thread t = new Thread(() => ProcessFile(file, textFilesInfo));
                threads.AddLast(t);
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
            filesInfoGridView.Rows.Clear();
            filesInfoGridView.Rows.Add(textFilesInfo.Words, textFilesInfo.Lines, textFilesInfo.Punctuation);
        }

        void ProcessFile(FileInfo fileInfo, TextFilesInfo textFileInfo)
        {
            try
            {
                string text = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);

                string temp_text_1space = text;
                int prev_len = temp_text_1space.Length;
                do
                {
                    temp_text_1space.Replace("  ", " ");
                } while (prev_len != temp_text_1space.Length);
                int c_words = temp_text_1space.Split(' ', '\n', '\t').Length;

                int c_lines = text.Count(c => c == '\n') + 1;

                string punctuations = ".,;:–—‒…!?\"\'«»(){}[]<>/";
                int c_punctuation = text.Count(c => punctuations.Contains(c));

                Interlocked.Add(ref textFileInfo.Words, c_words);
                Interlocked.Add(ref textFileInfo.Lines, c_lines);
                Interlocked.Add(ref textFileInfo.Punctuation, c_punctuation);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        class TextFilesInfo
        {
            public TextFilesInfo()
            {
                Words = 0;
                Lines = 0;
                Punctuation = 0;
            }

            public int Words;
            public int Lines;
            public int Punctuation;
        }
    }
}
