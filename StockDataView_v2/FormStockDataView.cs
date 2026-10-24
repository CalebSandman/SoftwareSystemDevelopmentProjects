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

        //Form Events
        #region Form Events
        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            chartManager.BindChartData(Text);  //binds the chart data to the chart manager using the text of the form as the file path
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