namespace StockDataView_v2
{
    partial class FormSelector
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
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialogSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(9, 24);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(55, 13);
            this.labelStartDate.TabIndex = 0;
            this.labelStartDate.Text = "Start Date";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(9, 84);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelEndDate.TabIndex = 1;
            this.labelEndDate.Text = "End Date";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(249, 24);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(109, 54);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Select File(s)";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(249, 84);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(109, 51);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Visible = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(12, 40);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePickerStartDate.TabIndex = 4;
            this.dateTimePickerStartDate.Value = new System.DateTime(2026, 6, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(12, 100);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePickerEndDate.TabIndex = 5;
            this.dateTimePickerEndDate.Value = new System.DateTime(2026, 9, 18, 0, 0, 0, 0);
            // 
            // openFileDialogSelectFile
            // 
            this.openFileDialogSelectFile.DefaultExt = "csv";
            this.openFileDialogSelectFile.FileName = "NVDA_daily.csv";
            this.openFileDialogSelectFile.Filter = "CSV files|*.csv|Daily|*_daily.csv|Weekly|*_weekly.csv|Monthly|*_monthly.csv";
            this.openFileDialogSelectFile.InitialDirectory = "C:\\Users\\mudki\\OneDrive\\Documents\\USF\\Fall 26\\Software System Development (COP436" +
    "5)\\Dev\\Stock Data";
            this.openFileDialogSelectFile.Multiselect = true;
            this.openFileDialogSelectFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSelectFile_FileOk);
            // 
            // FormSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 157);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Name = "FormSelector";
            this.Text = "FormSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectFile;
    }
}