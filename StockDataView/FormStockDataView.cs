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

namespace WindowsFormsApp1
{
    public partial class FormStockDataView : Form
    {
        //Initialization
        #region Initialization
        public FormStockDataView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            Text = openFileDialogSelectFile.FileName;   //sets the title of the form to the selected file name
            candlestickData = ReadCandlestickDataFromCsv(openFileDialogSelectFile.FileName, true);  //reads the CSV file into a list of candlestick objects, applying date filtering

            dataGridViewStockData.DataSource = new BindingList<objCandlestick>(candlestickData);    //binds the list of candlestick objects to the DataGridView control
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
