namespace StockDataView_v2
{
    partial class FormStockDataView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialogSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewStockData = new System.Windows.Forms.DataGridView();
            this.objCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonUpdateData = new System.Windows.Forms.Button();
            this.chartStockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objCandlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStockData)).BeginInit();
            this.SuspendLayout();
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
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(290, 373);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(100, 65);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Open File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "";
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(12, 418);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 4;
            this.dateTimePickerStartDate.Value = new System.DateTime(2026, 6, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(588, 418);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 5;
            this.dateTimePickerEndDate.Value = new System.DateTime(2026, 9, 18, 0, 0, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridViewStockData
            // 
            this.dataGridViewStockData.AutoGenerateColumns = false;
            this.dataGridViewStockData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockData.DataSource = this.objCandlestickBindingSource;
            this.dataGridViewStockData.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewStockData.Name = "dataGridViewStockData";
            this.dataGridViewStockData.Size = new System.Drawing.Size(776, 343);
            this.dataGridViewStockData.TabIndex = 6;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(12, 402);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(55, 13);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "Start Date";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(585, 402);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date";
            // 
            // buttonUpdateData
            // 
            this.buttonUpdateData.Location = new System.Drawing.Point(432, 373);
            this.buttonUpdateData.Name = "buttonUpdateData";
            this.buttonUpdateData.Size = new System.Drawing.Size(100, 65);
            this.buttonUpdateData.TabIndex = 9;
            this.buttonUpdateData.Text = "Update Data";
            this.buttonUpdateData.UseVisualStyleBackColor = true;
            this.buttonUpdateData.Visible = false;
            this.buttonUpdateData.Click += new System.EventHandler(this.buttonUpdateData_Click);
            // 
            // chartStockData
            // 
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY2.LabelStyle.Enabled = false;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.AxisY2.MajorTickMark.Enabled = false;
            chartArea3.Name = "AreaCandlesticks";
            this.chartStockData.ChartAreas.Add(chartArea3);
            this.chartStockData.DataSource = this.objCandlestickBindingSource;
            legend3.Name = "Legend1";
            this.chartStockData.Legends.Add(legend3);
            this.chartStockData.Location = new System.Drawing.Point(12, 12);
            this.chartStockData.Name = "chartStockData";
            series5.ChartArea = "AreaCandlesticks";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series5.Legend = "Legend1";
            series5.Name = "SeriesOHLC";
            series5.XValueMember = "Date";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YValueMembers = "High, Low, Open, Close";
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "AreaCandlesticks";
            series6.Legend = "Legend1";
            series6.Name = "SeriesVolume";
            series6.XValueMember = "Date";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series6.YValueMembers = "Volume";
            series6.YValuesPerPoint = 4;
            this.chartStockData.Series.Add(series5);
            this.chartStockData.Series.Add(series6);
            this.chartStockData.Size = new System.Drawing.Size(776, 343);
            this.chartStockData.TabIndex = 10;
            this.chartStockData.Text = "chart1";
            // 
            // FormStockDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartStockData);
            this.Controls.Add(this.buttonUpdateData);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dataGridViewStockData);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.buttonSelectFile);
            this.Name = "FormStockDataView";
            this.Text = "Stock Data View v2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objCandlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStockData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectFile;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridViewStockData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource objCandlestickBindingSource;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonUpdateData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStockData;
    }
}

