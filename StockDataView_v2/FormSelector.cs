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
        public FormSelector()
        {
            InitializeComponent();
        }

        //From Events
        #region Form Events
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
                FormStockDataView stockDataViewForm = new FormStockDataView();
                stockDataViewForm.Text = name;
                stockDataViewForm.Show();
            }
        }
        #endregion
    }
}
