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
        public List<int> PeakIndices { get; set; }  //List to hold the indices of the peaks in the candlestick data
        public List<int> ValleyIndices { get; set; }    //List to hold the indices of the valleys in the candlestick data
        public Chart Chart { get; set; }  //Chart object to hold the chart data
        #endregion

        //Constructors
        #region Constructors
        public objChartManager() { }

        public objChartManager(List<objCandlestick> candlestickData)
        {
            CandlestickData = candlestickData;
            PeakIndices = new List<int>();
            ValleyIndices = new List<int>();
        }
        #endregion

        //Functions
        #region Functions

        //Chart Creation-Functions
        #region Chart Creation

        public void BindChartData()
        {
            Chart.DataSource = new BindingList<objCandlestick>(CandlestickData);    //binds the list of candlestick objects to the Chart control
            InitializeChart();   //initializes the chart with the candlestick data
        }
        #endregion

        //Annotations-Functions
        #region Annotations
        public void IdentifyPeaksAndValleys()
            {
                for (int i = 1; i < CandlestickData.Count - 1; i++)
                {
                    if (CandlestickData[i].High > CandlestickData[i - 1].High && CandlestickData[i].High > CandlestickData[i + 1].High)
                        PeakIndices.Add(i);
               
                    if (CandlestickData[i].Low < CandlestickData[i - 1].Low && CandlestickData[i].Low < CandlestickData[i + 1].Low)
                        ValleyIndices.Add(i);
                }
            }

            public void LineAnnotations()
            {
                //set chart area and clear any existing annotations (avoids overlap)
                ChartArea mainArea = Chart.ChartAreas[0];
                Chart.Annotations.Clear();

                PeakToLowAnnotations(mainArea);
                ValleyToHighAnnotations(mainArea);
            
            }
        #endregion

        //Helpers
        #region Helpers
        #region Chart Creation-Helpers
        /// <summary>
        /// <para>Formats the chartStockData control to display the candlestick data.</para>
        /// <para>Volume limited to bottom 20% of chart</para>
        /// </summary>
        private void FormatChart()
        {
            if (CandlestickData.Count > 0)
            {
                double maxVolume = (double)CandlestickData.Max(c => c.Volume);  //finds the maximum volume in the candlestick data
                Chart.ChartAreas["AreaCandlesticks"].AxisY2.Minimum = 0;    //sets the minimum value of the secondary Y-axis to 0
                Chart.ChartAreas["AreaCandlesticks"].AxisY2.Maximum = maxVolume * 5;   //sets the maximum value of the secondary Y-axis to 5 times the maximum volume. Keeps the volume in the bottom 20% of the chart area
            }
        }

        private void InitializeChart()
        {
            FormatChart();    //formats the chart to display the candlestick data
            IdentifyPeaksAndValleys();   //identifies the peaks and valleys in the candlestick data
        }
        #endregion

        #region Annotations-Helpers
        private void PeakToLowAnnotations(ChartArea chart)
        {
            foreach(int peakIndex in PeakIndices)
            {
                objCandlestick nextCandlestick = CandlestickData[peakIndex + 1];
                objCandlestick currentCandlestick = CandlestickData[peakIndex];
                /*
                 * Requirements for valid trend:
                 * 1. 
                 */
            }
        }

        private void ValleyToHighAnnotations(ChartArea chart)
        {

        }
        #endregion
        #endregion
        #endregion
    }
}
