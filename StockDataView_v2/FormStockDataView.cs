using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StockDataView_v2
{
    public partial class FormStockDataView : Form
    {
        //Initialization
        #region Initialization
        public FormStockDataView()
        {
            InitializeComponent();
            objChartManager chartManager = new objChartManager();  //initialize chart manager object
        }

        public FormStockDataView(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            objChartManager chartManager = new objChartManager();  //initialize chart manager object
            dateTimePickerStartDate.Value = startDate;
            dateTimePickerEndDate.Value = endDate;
        }
        #endregion

        //File Selection
        #region File Selection
        /// <summary>
        /// <para>Handles the Click event of the buttonSelectFile control.</para>
        /// <para>Opens the openFileDialogSelectFile dialog to select a CSV file.</para>
        /// </summary>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialogSelectFile.ShowDialog();  //shows the open file dialog to select a CSV file
        }
        #endregion

        //Candlestick Creation
        #region Candlestick Creation
        List<objCandlestick> candlestickData = new List<objCandlestick>();  //initialize list of candlestick objects
        /// <summary>
        /// Handles the FileOk event of the openFileDialogSelectFile control.
        /// </summary>
        private void openFileDialogSelectFile_FileOk(object sender, CancelEventArgs e)
        {
            //TESTING
            foreach(string name in openFileDialogSelectFile.FileNames)
            {
                TEST_Form testForm = new TEST_Form();
                testForm.Text = name;
                testForm.Show();
            }
            return;


            Text = openFileDialogSelectFile.FileName;   //sets the title of the form to the selected file name
            candlestickData = ReadCandlestickDataFromCsv(openFileDialogSelectFile.FileName, true);  //reads the CSV file into a list of candlestick objects, applying date filtering

            #region DataGridView Creation
            dataGridViewStockData.DataSource = new BindingList<objCandlestick>(candlestickData);    //binds the list of candlestick objects to the DataGridView control
            #endregion

            #region Chart Creation
            FormatChart();
            chartStockData.DataSource = new BindingList<objCandlestick>(candlestickData);    //binds the list of candlestick objects to the Chart control
            #endregion

            buttonUpdateData.Visible = true;    //makes the buttonUpdateData button visible
        }
        
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
                if (!dateFilterOn || DateInRange(currentCandlestick.Date, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value))  //if date filter is off or the date of the current candlestick is within the selected range, add it to the list
                    candlesticks.Add(currentCandlestick);   //adds the candlestick to the list
            }

            return candlesticks;    //returns the list of candlesticks
        }

        /// <summary>
        /// <para>Handles the click event for the buttonUpdateData button.</para>
        /// <para>Updates the DataGridView control with the filtered candlestick data based on the selected date range.</para>
        /// </summary>
        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            dataGridViewStockData.DataSource = new BindingList<objCandlestick>(ReadCandlestickDataFromCsv(openFileDialogSelectFile.FileName, true));

            candlestickData = ReadCandlestickDataFromCsv(openFileDialogSelectFile.FileName, true);  //reads the CSV file into a list of candlestick objects, applying date filtering
            FormatChart();
            chartStockData.DataSource = new BindingList<objCandlestick>(candlestickData);    //binds the list of candlestick objects to the Chart control
        }

        #endregion

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

        /// <summary>
        /// <para>Formats the chartStockData control to display the candlestick data.</para>
        /// <para>Volume limited to bottom 20% of chart</para>
        /// </summary>
        public void FormatChart()
        {
            if (candlestickData.Count > 0)
            {
                double maxVolume = (double)candlestickData.Max(c => c.Volume);  //finds the maximum volume in the candlestick data
                chartStockData.ChartAreas["AreaCandlesticks"].AxisY2.Minimum = 0;    //sets the minimum value of the secondary Y-axis to 0
                chartStockData.ChartAreas["AreaCandlesticks"].AxisY2.Maximum = maxVolume * 5;   //sets the maximum value of the secondary Y-axis to 5 times the maximum volume. Keeps the volume in the bottom 20% of the chart area
            }
        }
        #endregion

        //Timer (Unused)
        #region Timer (Unused)
        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            Text = $"Counter: {counter}";
        }
        #endregion
    }
}
/*
 * TODO:Incomporate trendlines using annotations
 *      Create rectangle annotations covering the rectangle made by each trendline
 *      Peaks and valleys are defined as the high/low values being higher or lower than the candlesticks to either side. A candlestick can be both a peak and a valley
 *          (Use a new class derived from objCandlestick, peakValley finder)?
 *      Trendlines point from peaks to a low or valley to a high. Trends are valid if no candlesticks in the rectangle pierce it
 *          IDEA: trends go from peaks to valleys and vice versa only if there is not a higher/lower peak inbetween
 *          
 *      
 *      
 *      Start with a form that lets you select multiple files
 *      Opens all files in their own form with chart
 *          Each form has date selectors and update button. NO open file button
 *      Mark peaks and valleys
 *      Change candlestick colors to red and green for down and up days
 *      
 *      "internal class" to "public Static class"
 */