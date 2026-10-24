using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataView_v2
{
    internal class objCandlestickExtrema : objCandlestick
    {
        //Data Properties
        #region Data Properties
        public bool IsPeak { get; set; }  //Indicates whether the candlestick is a peak
        public bool IsValley { get; set; }    //Indicates whether the candlestick is a valley
        #endregion

        //Constructors
        #region Constructors
        /// <summary>
        /// Constructor that takes a single string, csvLine, containing all the stock data and splits it on commas and quotes.
        /// </summary>
        /// <param name="csvLine">A string containing the stock data in CSV format </param>
        public objCandlestickExtrema(string csvLine)
        {
            char[] separators = new char[] { ',', '"' };    //characters to split string on. Commas and quotes
            string[] values = csvLine.Split(separators, StringSplitOptions.RemoveEmptyEntries); //splits the string on specified characters and removes empty entries
            this.Date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null); //parse date from values
            this.Open = Decimal.Parse(values[1]);   //parse open from values
            this.High = Decimal.Parse(values[2]);   //parse high from values
            this.Low = Decimal.Parse(values[3]);    //parse low from values
            this.Close = Decimal.Parse(values[4]);  //parse close from values
            this.Volume = ulong.Parse(values[5]);   //parse volume from values
        }

        public objCandlestickExtrema() { }
        #endregion
    }
}
