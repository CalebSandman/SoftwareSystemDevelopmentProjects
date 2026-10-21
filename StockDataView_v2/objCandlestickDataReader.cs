using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataView_v2
{
    internal class objCandlestickDataReader
    {
        //Data Properties
        #region Data Properties
        DateTime StartDate { get; set; }  //Start date for filtering candlestick data
        DateTime EndDate { get; set; }    //End date for filtering candlestick data
        #endregion

        //Constructors
        #region Constructors
        public objCandlestickDataReader() { }

        public objCandlestickDataReader(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;  //sets the start date for filtering candlestick data
            EndDate = endDate;      //sets the end date for filtering candlestick data
        }
        #endregion

        //Functions
        #region Functions
        /// <summary>
        /// <para>Reads the CSV file selected from openFileDialogSelectFile into a list of candlestick objects.</para>
        /// <para>Can apply date filtering from dateTimePickerStartDate and dateTimePickerEndDate.</para>
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

            //Helpers
            #region Helpers
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
            #endregion
        #endregion
    }
}
