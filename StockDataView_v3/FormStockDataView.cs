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
            chartManager.DrawPeakAndValleyAnnotations();    //draws the annotations for peaks and valleys
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
            chartManager.DrawPeakAndValleyAnnotations();    //draws the annotations for peaks and valleys
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
        private void chartStockData_MouseDown(object sender, MouseEventArgs e)
        {
            Text = "aaaaaaaa";
        }

        private void chartStockData_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void chartStockData_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
