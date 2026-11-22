using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace StockDataView_v3
{
    public partial class FormStockDataView : Form
    {
        //Initialization
        #region Initialization
        #region Constructors
        objChartManager chartManager;  //chart manager object to manage the chartStockData chart
        public FormStockDataView()
        {
            InitializeComponent();
            chartManager = new objChartManager(chartStockData);  //initialize chart manager object with the chartStockData chart
        }

        public FormStockDataView(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            chartManager = new objChartManager(chartStockData);  //initialize chart manager object with the chartStockData chart
            dateTimePickerStartDate.Value = startDate;  //sets the value of the start date picker to the specified start date
            dateTimePickerEndDate.Value = endDate;  //sets the value of the end date picker to the specified end date
        }
        #endregion

        /// <summary>
        /// Initializes the chart date range and binds the stock data for the form.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void FormStockDataView_Load(object sender, EventArgs e)
        {
            chartManager.StartDate = dateTimePickerStartDate.Value;  //sets the start date of the chart manager to the value of the start date picker
            chartManager.EndDate = dateTimePickerEndDate.Value;  //sets the end date of the chart manager to the value of the end date picker
            chartManager.BindChartData(Text);  //binds the chart data to the chart manager using the text of the form as the file path
            chartManager.DrawPeakAndValleyMarkers();    //draws the markers for peaks and valleys
        }
        #endregion

        //Form Events
        #region Form Events
        /// <summary>
        /// Updates the chart date range and refreshes the chart data for the selected period.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            chartManager.StartDate = dateTimePickerStartDate.Value;  //sets the start date of the chart manager to the value of the start date picker
            chartManager.EndDate = dateTimePickerEndDate.Value;  //sets the end date of the chart manager to the value of the end date picker
            chartManager.BindChartData(Text);  //binds the chart data to the chart manager using the text of the form as the file path
            chartManager.DrawPeakAndValleyMarkers();    //draws the markers for peaks and valleys
        }
        #endregion







/*
* Ignore the below code.
* It is for future development.
*/

        //Timer (Unused)
        #region Timer (Unused)
        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            Text = $"Counter: {counter}";
        }
        #endregion

        //Rubberbanding
        #region Rubberbanding
        DataPoint startDataPoint;
        bool isDragging = false;
        Rectangle trendBox;
        private Point startPoint;
        private Point endPoint;
        double xValuePixel, yValuePixel;

        private void chartStockData_MouseDown(object sender, MouseEventArgs e)
        {          
            string selectedSeries;
            startDataPoint = chartManager.FindClosestPeakOrValley(e, out selectedSeries, out xValuePixel, out yValuePixel);

            startPoint = new Point((int)xValuePixel, (int)(yValuePixel));
            endPoint = e.Location;
            trendBox = Rectangle.Empty;
            isDragging = true;
        }

        private void chartStockData_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging)
                return;

            isDragging = false;

            // Ignore tiny accidental drags (plain clicks)
            if (trendBox.Width < 3 || trendBox.Height < 3)
                trendBox = Rectangle.Empty;

            // trendBox now holds the final selection in chart pixel coordinates.
            // startDataPoint / endDataPoint hold the closest peak/valley at each end.
            // Do your trend calculation here if needed.

            //trendBox = Rectangle.Empty;    // remove this line if you want the box to stay visible
            //chartStockData.Invalidate();
        }

        private void chartStockData_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
                return;
            
            endPoint = new Point(
                Math.Max(0, Math.Min(e.X, chartStockData.Width - 1)),
                Math.Max(0, Math.Min(e.Y, chartStockData.Height - 1)));

            trendBox = GetNormalizedRectangle(startPoint, endPoint);
            chartStockData.Invalidate();
        }
        
        private void chartStockData_PostPaint(object sender, ChartPaintEventArgs e)
        {
            // Only draw the box when there is something to draw
            if (!isDragging || trendBox.IsEmpty)
                return;

            using (Pen penUpTrend = new Pen(Color.LimeGreen, (float)1.5) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid })
            using (Pen penDownTrend = new Pen(Color.Red, (float)1.5) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid })
            using (Pen penInvalid = new Pen(Color.Gray, (float)1.5) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            //using (Brush fill = new SolidBrush(Color.FromArgb(40, Color.DodgerBlue)))
            {
                //e.ChartGraphics.Graphics.FillRectangle(fill, trendBox);
                e.ChartGraphics.Graphics.DrawRectangle(penInvalid, trendBox);
            }
        }

        private Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return Rectangle.FromLTRB(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Max(p1.X, p2.X),
                Math.Max(p1.Y, p2.Y));
        }
        #endregion
    }
}
