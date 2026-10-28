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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonUpdateData = new System.Windows.Forms.Button();
            this.chartStockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStockData)).BeginInit();
            this.SuspendLayout();
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
            this.buttonUpdateData.Location = new System.Drawing.Point(257, 373);
            this.buttonUpdateData.Name = "buttonUpdateData";
            this.buttonUpdateData.Size = new System.Drawing.Size(275, 65);
            this.buttonUpdateData.TabIndex = 9;
            this.buttonUpdateData.Text = "Update Data";
            this.buttonUpdateData.UseVisualStyleBackColor = true;
            this.buttonUpdateData.Click += new System.EventHandler(this.buttonUpdateData_Click);
            // 
            // chartStockData
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.Name = "AreaCandlesticks";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 70F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            chartArea2.AlignWithChartArea = "AreaCandlesticks";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.LabelStyle.Format = "#,##0,,\\M";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "AreaVolume";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 25F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 75F;
            this.chartStockData.ChartAreas.Add(chartArea1);
            this.chartStockData.ChartAreas.Add(chartArea2);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartStockData.Legends.Add(legend1);
            this.chartStockData.Location = new System.Drawing.Point(12, 12);
            this.chartStockData.Name = "chartStockData";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "AreaCandlesticks";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Black;
            series1.CustomProperties = "PriceUpColor=Lime, PriceDownColor=Red";
            series1.Legend = "Legend1";
            series1.Name = "SeriesOHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High, Low, Open, Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "AreaVolume";
            series2.Legend = "Legend1";
            series2.Name = "SeriesVolume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            series2.YValuesPerPoint = 4;
            this.chartStockData.Series.Add(series1);
            this.chartStockData.Series.Add(series2);
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
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Name = "FormStockDataView";
            this.Text = "Stock Data View v2";
            this.Load += new System.EventHandler(this.FormStockDataView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStockData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonUpdateData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStockData;
    }
}

