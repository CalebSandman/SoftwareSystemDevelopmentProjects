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
        DataPoint startDataPoint;   //the data point at the start of the drag
        bool isDragging = false;    //indicates whether the user is currently dragging the mouse
        Rectangle trendBox; //the rectangle that represents the trend box
        private Point startPoint;   //starting point of the drag
        private Point endPoint; //ending point of the drag
        double xValuePixel, yValuePixel;    //the pixel coordinates of the data point at the start of the drag
        int startIndex; //the index of the data point at the start of the drag

        private void chartStockData_MouseDown(object sender, MouseEventArgs e)
        {
            startDataPoint = chartManager.FindClosestPeakOrValley(e, out startIndex, out xValuePixel, out yValuePixel); //find the closest peak or valley to the mouse and get its index and pixel coordinates
            if (startDataPoint == null)
                return;

            startPoint = new Point((int)Math.Round(xValuePixel), (int)Math.Round(yValuePixel));   //round instead of truncate
            endPoint = startPoint;
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
                Math.Max(0, Math.Min(e.Y, chartStockData.Height - 1))); //calculate and keep endPoint within the chart

            trendBox = GetNormalizedRectangle(startPoint, endPoint);    //calculate the rectangle with normalized coordinates
            
            chartStockData.Invalidate();    //invalidate the chart to trigger repaint
        }
        
        private void chartStockData_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (!isDragging || trendBox.IsEmpty)
                return;

            bool draggingLeft = endPoint.X < startPoint.X;  //right-to-left drags are always invalid
            bool isUptrend = endPoint.Y < startPoint.Y; //only used for left-to-right, so "end higher than start"

            //pens for uptrend, downtrend, and invalid trend boxes
            using (Pen penUpTrend = new Pen(Color.Lime, 1.5f))
            using (Pen penDownTrend = new Pen(Color.Red, 1.5f))
            using (Pen penInvalid = new Pen(Color.Gray, 1.5f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                Graphics g = e.ChartGraphics.Graphics;  //get the graphics object from the chart event args

                if (!chartManager.IsTrendBoxValid(trendBox) || draggingLeft)    //if the trend box is invalid or the user is dragging right-to-left, draw a dashed gray rectangle
                {
                    g.DrawRectangle(penInvalid, trendBox);
                }
                else  //else, draw a solid rectangle and line connecting start and end point. Green for uptrend, red for downtrend
                {
                    Pen pen = isUptrend ? penUpTrend : penDownTrend;
                    g.DrawRectangle(pen, trendBox);
                    g.DrawLine(pen, startPoint, endPoint);

                    Point[] fibonacciPoints = GetFibonacciPoints(trendBox);
                    foreach (Point fibPoint in fibonacciPoints)
                        g.DrawLine(pen, fibPoint.X, fibPoint.Y, trendBox.Right, fibPoint.Y);
                }
            }
        }

        /// <summary>
        /// Creates a rectangle, always taking the smaller X and Y as the top-left and the larger X and Y as the bottom-right to avoid negative width or height.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return Rectangle.FromLTRB(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Max(p1.X, p2.X),
                Math.Max(p1.Y, p2.Y));
        }

        private Point[] GetFibonacciPoints(Rectangle trendBox)
        {
            Point[] points = new Point[5];
            double[] fibonacciRatios = { 0.236, 0.382, 0.5, 0.618, 0.786 };
            for (int i = 0; i < fibonacciRatios.Length; i++)
            {
                int y = (int)(trendBox.Top + fibonacciRatios[i] * trendBox.Height);
                points[i] = new Point(trendBox.Left, y);
            }
            return points;
        }
        #endregion
    }
}
