using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockDataView_v2
{
    internal class objChartManager
    {
        //Data Properties
        #region Data Properties
        public List<objCandlestick> CandlestickData { get; set; }  //List to hold the candlestick data
        public Chart Chart { get; set; }  //Chart object to hold the chart data
        public string FilePath { get; set; }  //File path to the CSV file containing the candlestick data
        public List<int> PeakIndices { get; set; }  //List to hold the indices of the peaks in the candlestick data
        public List<int> ValleyIndices { get; set; }    //List to hold the indices of the valleys in the candlestick data
        public DateTime StartDate { get; set; }  //Start date for the chart
        public DateTime EndDate { get; set; }    //End date for the chart
        #endregion

        //Constructors
        #region Constructors
        public objChartManager() { }
        public objChartManager(Chart chart)
        {
            Chart = chart;
            CandlestickData = new List<objCandlestick>();
            PeakIndices = new List<int>();
            ValleyIndices = new List<int>();
        }
        #endregion

        //Functions
        #region Functions

        //Chart Creation-Functions
        #region Chart Creation
        /// <summary>
        /// Binds the list of candlestick objects to the Chart control and initializes the chart with the candlestick data.
        /// </summary>
        public void BindChartData(string path)
        {
            CandlestickData = ReadCandlestickDataFromCsv(path, true);   //reads the candlestick data from the CSV file into the CandlestickData list
            Chart.DataSource = new BindingList<objCandlestick>(CandlestickData);    //binds the list of candlestick objects to the Chart control
            InitializeChart();   //initializes the chart with the candlestick data
            Chart.DataBind();
        }
        #endregion

        //Annotations-Functions
        #region Annotations
        /// <summary>
        /// Creates annotations for the peaks and valleys in the candlestick data and adds them to the chart.
        /// </summary>
        public void PeakAndValleyAnnotations()
            {
                //set chart area and clear any existing annotations (avoids overlap)
                ChartArea mainArea = Chart.ChartAreas[0];
                Chart.Annotations.Clear();            
            }
        #endregion

        //Helpers
        #region Helpers
        #region Chart Creation-Helpers
        /// <summary>
        /// Checks if date is within the range of startDate and endDate.
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="startDate">The start date of the range</param>
        /// <param name="endDate">The end date of the range</param>
        /// <returns>Either true or false</returns>
        public bool DateInRange(DateTime date, DateTime startDate, DateTime endDate)
        {
            return startDate.Date <= date.Date && date.Date <= endDate.Date;    //returns true if date is within the range of startDate and endDate, otherwise returns false
        }

        /// <summary>
        /// <para>Formats the chartStockData control to display the candlestick data.</para>
        /// <para>Volume limited to bottom 20% of chart</para>
        /// </summary>
        private void FormatChart()
        {
            if (CandlestickData.Count > 0)
            {
                //Volume to bottom 20% of chart
                decimal maxVolume = CandlestickData.Max(c => c.Volume);  //finds the maximum volume in the candlestick data
                Chart.ChartAreas["AreaCandlesticks"].AxisY2.Minimum = 0;    //sets the minimum value of the secondary Y-axis to 0
                Chart.ChartAreas["AreaCandlesticks"].AxisY2.Maximum = (double)(maxVolume * 5);   //sets the maximum value of the secondary Y-axis to 5 times the maximum volume. Keeps the volume in the bottom 20% of the chart area

                //Candlesticks to top 80% of chart
                decimal maxPrice = CandlestickData.Max(c => c.High);   //finds the maximum high price in the candlestick data
                decimal minPrice = CandlestickData.Min(c => c.Low);    //finds the minimum low price in the candlestick data
                Chart.ChartAreas["AreaCandlesticks"].AxisY.Minimum = (int)(minPrice - (maxPrice - minPrice) * 0.4m) - 1;    //sets the minimum value of the primary Y-axis to 40% below the minimum low price (top 80% of chart), rounded down to the nearest integer to keep whole number intervals
            }
        }

        /// <summary>
        /// Identifies the peaks and valleys in the candlestick data and stores their indices in PeakIndices and ValleyIndices lists.
        /// </summary>
        private void IdentifyPeaksAndValleys()
        {
            for (int i = 1; i < CandlestickData.Count - 1; i++) //loops through the candlestick data starting from the second element and ending at the second to last element
            {
                if (CandlestickData[i].High > CandlestickData[i - 1].High && CandlestickData[i].High > CandlestickData[i + 1].High) //if the current candlestick's high is greater than the previous and next candlestick's high, it is a peak
                    PeakIndices.Add(i);

                if (CandlestickData[i].Low < CandlestickData[i - 1].Low && CandlestickData[i].Low < CandlestickData[i + 1].Low) //if the current candlestick's low is less than the previous and next candlestick's low, it is a valley
                    ValleyIndices.Add(i);
            }
        }

        /// <summary>
        /// <para>Reads the CSV file selected from openFileDialogSelectFile into a list of candlestick objects.</para>
        /// <para>Can apply date filtering from StartDate and EndDate.</para>
        /// </summary>
        /// <param name="filePath">The path to the CSV file</param>
        /// <param name="dateFilterOn">Indicates whether to apply date filtering</param>
        /// <returns>A list of candlestick objects</returns>
        private List<objCandlestick> ReadCandlestickDataFromCsv(string filePath, bool dateFilterOn = false)
        {
            var candlesticks = new List<objCandlestick>();  //initialize list of candlestick objects
            var lines = System.IO.File.ReadAllLines(filePath);  //array of all lines in the CSV file
            foreach (var line in lines.Skip(1)) //loops through each line while skipping the header line of CSV file
            {
                var currentCandlestick = new objCandlestick(line);  //creates a candlestick object from the data in each line
                if (!dateFilterOn || DateInRange(currentCandlestick.Date, StartDate, EndDate))  //if date filter is off or the date of the current candlestick is within the selected range, add it to the list
                    candlesticks.Add(currentCandlestick);   //adds the candlestick to the list
            }

            return candlesticks;    //returns the list of candlesticks
        }

        /// <summary>
        /// Initializes the chart by formatting it and identifying peaks and valleys in the candlestick data.
        /// </summary>
        private void InitializeChart()
        {
            FormatChart();    //formats the chart to display the candlestick data
            IdentifyPeaksAndValleys();   //identifies the peaks and valleys in the candlestick data
        }
        #endregion

        #region Annotations-Helpers
        
        #endregion
        #endregion
        #endregion
    }
}
