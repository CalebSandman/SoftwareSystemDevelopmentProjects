using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataView_v2
{
    internal class objChartManager
    {
        //Data Properties
        #region Data Properties
        public List<objCandlestick> CandlestickData { get; set; }  //List to hold the candlestick data
        public List<int> PeakIndices { get; set; }  //List to hold the indices of the peaks in the candlestick data
        public List<int> ValleyIndices { get; set; }    //List to hold the indices of the valleys in the candlestick data
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
        #endregion
    }
}
