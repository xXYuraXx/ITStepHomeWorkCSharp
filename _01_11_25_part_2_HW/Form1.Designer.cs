namespace _01_11_25_part_2_HW
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.refreshIntervallabel = new System.Windows.Forms.Label();
            this.killBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.Id,
            this.startTime,
            this.priority,
            this.status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(740, 309);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Name";
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // startTime
            // 
            this.startTime.HeaderText = "Start Time";
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            // 
            // priority
            // 
            this.priority.HeaderText = "Priority";
            this.priority.Name = "priority";
            this.priority.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "Off"});
            this.comboBoxInterval.Location = new System.Drawing.Point(491, 350);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInterval.TabIndex = 1;
            this.comboBoxInterval.Text = "1";
            this.comboBoxInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterval_SelectedIndexChanged);
            // 
            // refreshIntervallabel
            // 
            this.refreshIntervallabel.AutoSize = true;
            this.refreshIntervallabel.Location = new System.Drawing.Point(491, 331);
            this.refreshIntervallabel.Name = "refreshIntervallabel";
            this.refreshIntervallabel.Size = new System.Drawing.Size(82, 13);
            this.refreshIntervallabel.TabIndex = 2;
            this.refreshIntervallabel.Text = "Refresh Interval";
            // 
            // killBtn
            // 
            this.killBtn.Location = new System.Drawing.Point(13, 320);
            this.killBtn.Name = "killBtn";
            this.killBtn.Size = new System.Drawing.Size(75, 23);
            this.killBtn.TabIndex = 3;
            this.killBtn.Text = "Kill Selected";
            this.killBtn.UseVisualStyleBackColor = true;
            this.killBtn.Click += new System.EventHandler(this.killBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(94, 321);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(75, 23);
            this.infoBtn.TabIndex = 4;
            this.infoBtn.Text = "View Details";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(49, 393);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(276, 20);
            this.textBoxPath.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(331, 393);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.killBtn);
            this.Controls.Add(this.refreshIntervallabel);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.Label refreshIntervallabel;
        private System.Windows.Forms.Button killBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonStart;
    }
}

