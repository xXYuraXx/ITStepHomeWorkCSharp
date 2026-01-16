namespace _15_11_25_HW
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
            this.directoryPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.choosePathBtn = new System.Windows.Forms.Button();
            this.processCalculate = new System.Windows.Forms.Button();
            this.filesInfoGridView = new System.Windows.Forms.DataGridView();
            this.countWords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPunctuationMarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.filesInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // directoryPathTextBox
            // 
            this.directoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryPathTextBox.Location = new System.Drawing.Point(135, 12);
            this.directoryPathTextBox.Name = "directoryPathTextBox";
            this.directoryPathTextBox.ReadOnly = true;
            this.directoryPathTextBox.Size = new System.Drawing.Size(251, 20);
            this.directoryPathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Directory path";
            // 
            // choosePathBtn
            // 
            this.choosePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.choosePathBtn.Location = new System.Drawing.Point(403, 12);
            this.choosePathBtn.Name = "choosePathBtn";
            this.choosePathBtn.Size = new System.Drawing.Size(75, 23);
            this.choosePathBtn.TabIndex = 2;
            this.choosePathBtn.Text = "Choose";
            this.choosePathBtn.UseVisualStyleBackColor = true;
            this.choosePathBtn.Click += new System.EventHandler(this.choosePathBtn_Click);
            // 
            // processCalculate
            // 
            this.processCalculate.Location = new System.Drawing.Point(54, 52);
            this.processCalculate.Name = "processCalculate";
            this.processCalculate.Size = new System.Drawing.Size(75, 23);
            this.processCalculate.TabIndex = 3;
            this.processCalculate.Text = "Process";
            this.processCalculate.UseVisualStyleBackColor = true;
            this.processCalculate.Click += new System.EventHandler(this.processCalculate_Click);
            // 
            // filesInfoGridView
            // 
            this.filesInfoGridView.AllowUserToAddRows = false;
            this.filesInfoGridView.AllowUserToDeleteRows = false;
            this.filesInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countWords,
            this.countLines,
            this.countPunctuationMarks});
            this.filesInfoGridView.Location = new System.Drawing.Point(54, 110);
            this.filesInfoGridView.Name = "filesInfoGridView";
            this.filesInfoGridView.ReadOnly = true;
            this.filesInfoGridView.Size = new System.Drawing.Size(424, 121);
            this.filesInfoGridView.TabIndex = 4;
            // 
            // countWords
            // 
            this.countWords.HeaderText = "Count Words";
            this.countWords.Name = "countWords";
            this.countWords.ReadOnly = true;
            // 
            // countLines
            // 
            this.countLines.HeaderText = "Count Lines";
            this.countLines.Name = "countLines";
            this.countLines.ReadOnly = true;
            // 
            // countPunctuationMarks
            // 
            this.countPunctuationMarks.HeaderText = "Count Punctuation Marks";
            this.countPunctuationMarks.Name = "countPunctuationMarks";
            this.countPunctuationMarks.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 450);
            this.Controls.Add(this.filesInfoGridView);
            this.Controls.Add(this.processCalculate);
            this.Controls.Add(this.choosePathBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.directoryPathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.filesInfoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directoryPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choosePathBtn;
        private System.Windows.Forms.Button processCalculate;
        private System.Windows.Forms.DataGridView filesInfoGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn countWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn countLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn countPunctuationMarks;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

