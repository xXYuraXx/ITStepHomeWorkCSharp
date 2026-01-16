namespace _08_11_25_part_3_HW_Threads
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startTask1Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.endNumBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.startNumBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.countThreadsBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startTask4Btn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.clearConsoleBtn = new System.Windows.Forms.Button();
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThreadsBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.consoleRichTextBox);
            this.groupBox1.Controls.Add(this.clearConsoleBtn);
            this.groupBox1.Controls.Add(this.startTask1Btn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.endNumBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startNumBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.countThreadsBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task 1";
            // 
            // startTask1Btn
            // 
            this.startTask1Btn.Location = new System.Drawing.Point(61, 297);
            this.startTask1Btn.Name = "startTask1Btn";
            this.startTask1Btn.Size = new System.Drawing.Size(75, 23);
            this.startTask1Btn.TabIndex = 6;
            this.startTask1Btn.Text = "Start";
            this.startTask1Btn.UseVisualStyleBackColor = true;
            this.startTask1Btn.Click += new System.EventHandler(this.startTask1Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End num";
            // 
            // endNumBox
            // 
            this.endNumBox.Location = new System.Drawing.Point(44, 224);
            this.endNumBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.endNumBox.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.endNumBox.Name = "endNumBox";
            this.endNumBox.Size = new System.Drawing.Size(120, 20);
            this.endNumBox.TabIndex = 4;
            this.endNumBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start num";
            // 
            // startNumBox
            // 
            this.startNumBox.Location = new System.Drawing.Point(44, 159);
            this.startNumBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.startNumBox.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.startNumBox.Name = "startNumBox";
            this.startNumBox.Size = new System.Drawing.Size(120, 20);
            this.startNumBox.TabIndex = 2;
            this.startNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Count Threads";
            // 
            // countThreadsBox
            // 
            this.countThreadsBox.Location = new System.Drawing.Point(44, 97);
            this.countThreadsBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countThreadsBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countThreadsBox.Name = "countThreadsBox";
            this.countThreadsBox.Size = new System.Drawing.Size(120, 20);
            this.countThreadsBox.TabIndex = 0;
            this.countThreadsBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startTask4Btn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(429, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task 4";
            // 
            // startTask4Btn
            // 
            this.startTask4Btn.Location = new System.Drawing.Point(42, 221);
            this.startTask4Btn.Name = "startTask4Btn";
            this.startTask4Btn.Size = new System.Drawing.Size(75, 23);
            this.startTask4Btn.TabIndex = 7;
            this.startTask4Btn.Text = "Start";
            this.startTask4Btn.UseVisualStyleBackColor = true;
            this.startTask4Btn.Click += new System.EventHandler(this.startTask4Btn_Click);
            // 
            // clearConsoleBtn
            // 
            this.clearConsoleBtn.Location = new System.Drawing.Point(199, 19);
            this.clearConsoleBtn.Name = "clearConsoleBtn";
            this.clearConsoleBtn.Size = new System.Drawing.Size(75, 23);
            this.clearConsoleBtn.TabIndex = 8;
            this.clearConsoleBtn.Text = "Clear";
            this.clearConsoleBtn.UseVisualStyleBackColor = true;
            this.clearConsoleBtn.Click += new System.EventHandler(this.clearConsoleBtn_Click);
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.consoleRichTextBox.Location = new System.Drawing.Point(280, 16);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.ReadOnly = true;
            this.consoleRichTextBox.Size = new System.Drawing.Size(140, 431);
            this.consoleRichTextBox.TabIndex = 9;
            this.consoleRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThreadsBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown countThreadsBox;
        private System.Windows.Forms.Button startTask1Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown endNumBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startNumBox;
        private System.Windows.Forms.Button startTask4Btn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button clearConsoleBtn;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
    }
}

