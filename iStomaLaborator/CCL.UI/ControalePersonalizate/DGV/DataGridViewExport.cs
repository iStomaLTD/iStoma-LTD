using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ILL.iStomaLab;
using System.Globalization;
using CCL.iStomaLab;

namespace CCL.UI.ControalePersonalizate.DGV
{
    public class DataGridViewExport
    {
        private static DataGridViewExport _Instanta = null;
        private string lDenumireDocument = string.Empty;

        public static DataGridViewExport Instanta
        {
            get
            {
                if (_Instanta == null)
                    _Instanta = new DataGridViewExport();

                return _Instanta;
            }
        }

        public static void DistrugeObiectele()
        {
            _Instanta = null;
        }

        private DataGridViewExport()
        {

        }

        #region Export To Excel
        /// <summary>  
        /// Manages a new thread used to Export from DataGridView to an Excel worksheet.  
        /// This method must be used in combination with the methods:  
        /// GetExcelReady()  
        /// ToExcel()  
        /// </summary>  
        /// <param name="dGV">ExtendedDataGridView name.</param>  
        /// <param name="initialRow">Number of Excel row where to start copying DataGridView titles.</param>  
        /// <param name="initialCol">Number of Excel column where to start copying DataGridView titles.</param>  
        /// <param name="exportTitles">True if you want to export DGV titles.</param>  
        /// <param name="wksName">How do you want to name the new worksheet.</param>  
        //public void ExcelThread(ExtendedDataGridView dGV, int initialRow, int initialCol, bool exportTitles, string wksName)
        //{
        //    Thread t1 = new Thread
        //        (
        //        delegate()
        //        {
        //            OnWorkStart(dGV, new EventArgs());

        //            // If exportTitles is set to false, change initial row value.  
        //            if (!exportTitles) { initialRow = initialRow - 1; }

        //            // Export Data.  
        //            GetExcelReady(dGV, initialRow, initialCol, exportTitles, wksName);

        //            OnWorkFinished(dGV, new EventArgs());
        //        }
        //        );
        //    t1.Start();
        //}

        /// <summary>  
        /// Sets a new Excel object where to export DataGridView.  
        /// This method should be used with the methods:  
        /// ExcelThread().  
        /// ToExcel().  
        /// </summary>  
        /// <param name="dGV">ExtendedDataGridView name.</param>  
        /// <param name="initialRow">Number of Excel row where to start copying DataGridView titles.</param>  
        /// <param name="initialCol">Number of Excel column where to start copying DataGridView titles.</param>  
        /// <param name="exportTitles">True if you want to export DGV titles.</param>  
        /// <param name="wksName">How do you want to name the new worksheet.</param>  
        //void GetExcelReady(ExtendedDataGridView dGV, int initialRow, int initialCol, bool exportTitles, string wksName)
        //{
        //    // Declare missing object.  
        //    Object oMissing = System.Reflection.Missing.Value;

        //    // Change current thread culture to ("en-US").  
        //    // System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");  

        //    // Create a new Excel instance.  
        //    Excel.Application oExcel = new Excel.Application();

        //    // Set Excel workbook to open with only 1 worsheet.  
        //    oExcel.SheetsInNewWorkbook = 1;

        //    // Set the UserControl property so Excel won't shut down.  
        //    oExcel.UserControl = true;

        //    // Add a workbook.  
        //    Excel.Workbook oBook = oExcel.Workbooks.Add(oMissing);

        //    // Get worksheets collection   
        //    Excel.Sheets oSheetsColl = oExcel.Worksheets;

        //    // Get Worksheet number 1  
        //    Excel.Worksheet oSheet = (Excel.Worksheet)oSheetsColl.get_Item(1);
        //    oSheet.Name = wksName;

        //    // Export dGV columns To Excel worksheet.  
        //    ToExcel(dGV, initialRow, initialCol, exportTitles, oSheet);

        //    // Make Excel visible to the user.  
        //    oExcel.Visible = true;

        //    // Release the variables.  
        //    //oBook.Close(false, oMissing, oMissing);  
        //    oBook = null;

        //    //oExcel.Quit();  
        //    oExcel = null;

        //    // Collect garbage.  
        //    GC.Collect();
        //}

        /// <summary>  
        /// Export from DataGridView to Excel worksheet.  
        /// This method should be used in combination with the methods:  
        /// ExcelThread().  
        /// GetExcelReady().  
        /// </summary>  
        /// <param name="dGV">ExtendedDataGridView name.</param>  
        /// <param name="initialRow">Number of Excel row where to start copying DataGridView titles.</param>  
        /// <param name="initialCol">Number of Excel column where to start copying DataGridView titles.</param>  
        /// <param name="exportTitles">True if you want to export DGV titles.</param>  
        /// <param name="wksName">How do you want to name the new worksheet.</param>  
        /// <param name="oSheet"></param>  
        //void ToExcel(DataGridViewPersonalizat dGV, int initialRow, int initialCol, bool exportTitles, Excel.Worksheet oSheet)
        //{
        //    int colIndex = 0;
        //    foreach (DataGridViewColumn column in dGV.Columns)
        //    {
        //        // Export only visible columns.  
        //        //if (dGV.ExportVisibleColumnsOnly)
        //        //{
        //        if (column.Visible)
        //        {
        //            // Export.  
        //            if (exportTitles) { oSheet.Cells[initialRow, colIndex + initialCol] = column.HeaderText; }
        //            for (int row = initialRow; row < initialRow + dGV.Rows.Count - 1; row++)
        //            { oSheet.Cells[row + 1, colIndex + initialCol] = dGV[colIndex, row - initialRow].Value; }
        //            colIndex++;
        //        }
        //        //}
        //        //else
        //        //{
        //        //    // Export all columns.  
        //        //    if (exportTitles) { oSheet.Cells[initialRow, colIndex + initialCol] = column.HeaderText; }
        //        //    for (int row = initialRow; row < initialRow + dGV.Rows.Count - 1; row++)
        //        //    { oSheet.Cells[row + 1, colIndex + initialCol] = dGV[colIndex, row - initialRow].Value; }
        //        //    colIndex++;
        //        //}
        //    }
        //}
        #endregion

        #region Export To CSV file

        /// <summary>  
        /// Manages a new thread used to Export from DataGridView to a csv (comma separated value) file.  
        /// This method must be used in combination with the methods:  
        /// GetCsvReady().  
        /// ToCsV().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Name of csv file.</param>  
        public void CsvThread(DataGridViewPersonalizat dGV, string filename)
        {
            this.lDenumireDocument = filename;
            Thread t1 = new Thread
                (
                delegate()
                {
                    OnWorkStart(dGV, new EventArgs());

                    // Export Data.  
                    GetCsvReady(dGV, filename);

                    OnWorkFinished(dGV, new EventArgs());
                }
                );
            t1.Start();
        }

        /// <summary>  
        /// Gets the new csv file name and path.  
        /// This method should be used with the methods:  
        /// CsvThread().  
        /// ToCsV().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Name of csv file.</param>  
        void GetCsvReady(DataGridViewPersonalizat dGV, string filename)
        {
            dGV.Invoke
            (
                new MethodInvoker
                (
                    delegate
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Comma Separated Value (*.csv)|*.csv";
                        dialog.FileName = filename;
                        dialog.ValidateNames = true;

                        if (dialog.ShowDialog(dGV) == DialogResult.Cancel) { filename = null; }
                        else { filename = dialog.FileName; }

                        if (filename == null) { return; }

                    }
                )
            );

            // Export data.  
            ToCsV(dGV, filename);
        }

        /// <summary>  
        /// Export the DataGridView to Comma Separated Value file.  
        /// This method should be used with the methods:  
        /// CsvThread().  
        /// GetCsvReady().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Full path & name of  the Name of csv file.</param>  
        void ToCsV(DataGridViewPersonalizat dGV, string filename)
        {
            if (string.IsNullOrEmpty(filename)) return;

            string valoareCelula = string.Empty;
            using (StreamWriter myFile = new StreamWriter(filename, false, Encoding.Default))
            {
                //IMPORTANT!!! 
                //Separatorul CVS pentru tarile europene este ; si nu , care este rezervat pentru zecimale

                myFile.WriteLine(this.lDenumireDocument);

                // Export only visible columns.  
                //if (dGV.ExportVisibleColumnsOnly)
                //{
                // Export titles:  
                StringBuilder sHeaders = new StringBuilder();
                List<int> listaIndecsiColoaneExportabile = new List<int>();
                string[] culturiVirgula = {"ar-JO", "ar-SY", "az-Cyrl-AZ", "az-Latn-AZ", "zh-CN", 
                               "zh-SG", "zh-TW", "nl-BE", "nl-NL", "en-BZ", "en-CA", 
                               "en-NZ", "en-US", "fr-CA", "ms-BN",
                               "ms-MY", "nb-NO", "nn-NO", "pt-BR", "sr-Cyrl-CS", 
                               "sr-Latn-CS", "es-AR", "es-DO", "es-MX",  
                               "es-ES_tradnl", "sv-FI", "sv-SE", "uz-Cyrl-UZ", "uz-Latn-UZ"};

                string separator = "; ";
                if (culturiVirgula.Contains<string>(CultureInfo.CurrentCulture.Name))
                    separator = ", ";

                for (int j = 0; j < dGV.Columns.Count; j++)
                {
                    if (dGV.Columns[j].Visible && !dGV.SeIgnoraColoanaLaImprimare(dGV.Columns[j].Name))
                    {
                        valoareCelula = CUtil.InlocuiesteDiacritice(dGV.Columns[j].HeaderText);
                        sHeaders.Append(valoareCelula);
                        sHeaders.Append(separator);
                        listaIndecsiColoaneExportabile.Add(j); //pentru a exporta datele coloanelor pretabile pentru export
                    }
                }
                myFile.WriteLine(sHeaders);
                sHeaders = null;

                // Export data.  
                //Fie cele bifate, fie toate
                List<DataGridViewRow> listaLiniiSelectate = dGV.GetListaLiniiSelectate();
                foreach (DataGridViewRow linie in listaLiniiSelectate)
                {
                    if (linie.Tag == null) continue; //in Tag-ul tuturor liniilor din aplicatie salvam obiectul corespunzator liniei respective; lipsa acestuia implica ignorarea liniei

                    StringBuilder stLine = new StringBuilder();
                    for (int j = 0; j < linie.Cells.Count; j++)
                    {
                        if (listaIndecsiColoaneExportabile.Contains(j))
                        {
                            stLine.Append(CUtil.ConvertObjectToString(linie.Cells[j].EditedFormattedValue, true));
                            stLine.Append(separator);
                        }
                    }
                    myFile.WriteLine(stLine);
                }

                //}
                //else
                //{
                //    // Export titles:  
                //    string sHeaders = "";
                //    for (int j = 0; j < dGV.Columns.Count; j++) { sHeaders = sHeaders.ToString() + dGV.Columns[j].HeaderText + ", "; }
                //    myFile.WriteLine(sHeaders);

                //    // Export data.  
                //    for (int i = 0; i < dGV.RowCount - 1; i++)
                //    {
                //        string stLine = "";
                //        for (int j = 0; j < dGV.Rows[i].Cells.Count; j++) { stLine = stLine.ToString() + dGV.Rows[i].Cells[j].Value + ", "; }
                //        myFile.WriteLine(stLine);
                //    }
                //}
            }

            IHMUtile.PornesteProces(filename);
        }

        #endregion

        public virtual event EventHandler WorkStart;
        public virtual event EventHandler WorkFinished;

        // Events  
        public void OnWorkStart(object sender, EventArgs e)
        {
            if (WorkStart != null) { WorkStart(sender, e); }
        }

        public void OnWorkFinished(object sender, EventArgs e)
        {
            if (WorkFinished != null) { WorkFinished(sender, e); }
        }

    }
}
