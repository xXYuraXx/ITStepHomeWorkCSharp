using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace _01_11_25_part_2_HW
{
    public partial class Form1 : Form
    {
        Timer refreshTimer;

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            OffProcessButtons();
        }

        void InitTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += (e, a) => RefreshProcessList();
            refreshTimer.Start();
        }

        void RefreshProcessList()
        {
            var cur_processes = Process.GetProcesses();

            int i = 0;
            foreach (var p in cur_processes)
            {

                string startTime = "Unknown";
                string priority = "Unknown";
                string status = "Unknown";
                try { startTime = p.StartTime.ToString(); } catch { }
                try { priority = p.PriorityClass.ToString(); } catch { }
                try { status = p.HasExited.ToString(); } catch { }

                if (dataGridView1.Rows.Count <= i)
                    dataGridView1.Rows.Add(p.ProcessName, p.Id, startTime, priority, status);
                else
                    dataGridView1.Rows[i].SetValues(p.ProcessName, p.Id, startTime, priority, status);

                i++;
            }
            while (dataGridView1.Rows.Count > cur_processes.Length)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }

        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInterval.SelectedItem == null) return;
            string val = comboBoxInterval.SelectedItem.ToString();
            if (val.ToLower().Equals("off"))
            {
                if (refreshTimer.Enabled == true)
                    refreshTimer.Stop();
            }
            else
            {
                int interval = 1;
                if (int.TryParse(val, out interval))
                {
                    refreshTimer.Interval = interval * 1000;
                    if (refreshTimer.Enabled == false)
                        refreshTimer.Start();
                }
            }

        }

        void OffProcessButtons()
        {
            killBtn.Enabled = false;
            infoBtn.Enabled = false;
        }

        void OnProcessButtons()
        {
            killBtn.Enabled = true;
            infoBtn.Enabled = true;
        }

        private void killBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            int pid = (int)row.Cells[1].Value;
            try
            {
                Process p = Process.GetProcessById(pid);
                p.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't kill process {pid}: {ex.Message}");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                OffProcessButtons();
            }
            else
            {
                OnProcessButtons();
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            int pid = (int)row.Cells[1].Value;
            try
            {
                Process p = Process.GetProcessById(pid);
                StringBuilder info = new StringBuilder();
                info.AppendLine($"Process Name: {p.ProcessName}");
                info.AppendLine($"Id: {p.Id}");
                try { info.AppendLine($"Start Time: {p.StartTime}"); } catch { }
                try { info.AppendLine($"Total Processor Time: {p.TotalProcessorTime}"); } catch { }
                try { info.AppendLine($"Priority Class: {p.PriorityClass}"); } catch { }
                try { info.AppendLine($"Threads: {p.Threads.Count}"); } catch { }
                MessageBox.Show(info.ToString(), "Process Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't get info for process {pid}: {ex.Message}");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text.Trim('\"');

            if (!File.Exists(path))
            {
                MessageBox.Show("File not found: " + path);
                return;
            }
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't start process: {ex.Message}");
            }
        }
    }
}
