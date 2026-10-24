using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockDataView_v2
{
    public partial class FormSelector : Form
    {
        //Initialization
        #region Initialization
        public FormSelector()
        {
            InitializeComponent();
        }
        #endregion

        //From Events
        #region Form Events
        /// <summary>
        /// Opens the openFileDialogSelectFile dialog to select a CSV file when buttonSelectFile is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialogSelectFile.ShowDialog();  //shows the open file dialog to select a CSV file
        }

        /// <summary>
        /// Opens a new FormStockDataView for each selected file in the OpenFileDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            foreach (string name in openFileDialogSelectFile.FileNames)
            {
                FormStockDataView stockDataViewForm = new FormStockDataView(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);    //creates a new instance of FormStockDataView for each selected file
                stockDataViewForm.Text = name;  //sets the title of the FormStockDataView to the name of the selected file
                stockDataViewForm.Show();   //shows the FormStockDataView
            }
        }

        /// <summary>
        /// Shows the Open File button after a file(s) has been selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data for the file selection completion.</param>
        private void openFileDialogSelectFile_FileOk(object sender, CancelEventArgs e)
        {
            buttonOpenFile.Visible = true;  //makes the buttonOpenFile visible after files are selected
        }
        #endregion
    }
}
