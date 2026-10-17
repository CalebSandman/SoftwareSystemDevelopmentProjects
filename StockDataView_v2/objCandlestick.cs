using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace StockDataView_v2
{
    internal class objCandlestick
    {
        //Data Properties
        #region Data Properties
        public DateTime Date { get; set; }  // Date of the candlestick
        public Decimal Open { get; set; }   // Open price of the candlestick
        public Decimal High { get; set; }   // High price of the candlestick
        public Decimal Low { get; set; }    // Low price of the candlestick
        public Decimal Close { get; set; }  // Close price of the candlestick
        public ulong Volume { get; set; }   // Volume of the candlestick

        public bool IsPeak { get; set; }  // Indicates if the candlestick is a peak
        public bool IsValley { get; set; }    // Indicates if the candlestick is a valley
        #endregion

        //Constructors
        #region Constructors
        #region Unused Constructors
        public objCandlestick(DateTime date, Decimal open, Decimal high, Decimal low, Decimal close, ulong volume)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }
        public objCandlestick(string date, string open, string high, string low, string close, string volume)
        {
            Date = DateTime.Parse(date);
            Open = Decimal.Parse(open);
            High = Decimal.Parse(high);
            Low = Decimal.Parse(low);
            Close = Decimal.Parse(close);
            Volume = ulong.Parse(volume);
        }
        public objCandlestick(string[] values)
        {
            if (values.Length != 6)
                throw new ArgumentException("Values must have length 6");
            Date = DateTime.Parse(values[0]);
            Open = Decimal.Parse(values[1]);
            High = Decimal.Parse(values[2]);
            Low = Decimal.Parse(values[3]);
            Close = Decimal.Parse(values[4]);
            Volume = ulong.Parse(values[5]);
        }
        #endregion

        /// <summary>
        /// Constructor that takes a single string, csvLine, containing all the stock data and splits it on commas and quotes.
        /// </summary>
        /// <param name="csvLine">A string containing the stock data in CSV format </param>
        public objCandlestick(string csvLine)
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
        
        public objCandlestick() { }
        #endregion
    }
}
