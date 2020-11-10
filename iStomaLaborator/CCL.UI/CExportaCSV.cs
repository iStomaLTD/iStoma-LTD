using CCL.iStomaLab;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CCL.UI
{
    internal class CExportaCSV
    {
        private string lDenumireDocument = string.Empty;

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

        /// <summary>  
        /// Manages a new thread used to Export from DataGridView to a csv (comma separated value) file.  
        /// This method must be used in combination with the methods:  
        /// GetCsvReady().  
        /// ToCsV().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Name of csv file.</param>  
        public void CsvThread(DataGridViewPersonalizat dGV, List<string> pListaColoaneImprimare, string filename, string pSeparator, bool pDeschideDupaCreare, bool pCreeazaInThreadulPrincipal)
        {
            this.lDenumireDocument = string.Empty;
            if (dGV.Tag != null)
            {
                this.lDenumireDocument = Convert.ToString(dGV.Tag);

                if (!string.IsNullOrEmpty(this.lDenumireDocument))
                    this.lDenumireDocument = this.lDenumireDocument.Replace(pSeparator.Trim(), " ");
            }

            if (pCreeazaInThreadulPrincipal)
            {
                // Export Data.  
                GetCsvReady(dGV, pListaColoaneImprimare, filename, pSeparator, pDeschideDupaCreare);
            }
            else
            {
                Thread t1 = new Thread
                    (
                    delegate()
                    {
                        OnWorkStart(dGV, new EventArgs());

                        // Export Data.  
                        GetCsvReady(dGV, pListaColoaneImprimare, filename, pSeparator, pDeschideDupaCreare);

                        OnWorkFinished(dGV, new EventArgs());
                    }
                    );
                t1.Start();
            }
        }

        /// <summary>  
        /// Gets the new csv file name and path.  
        /// This method should be used with the methods:  
        /// CsvThread().  
        /// ToCsV().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Name of csv file.</param>  
        void GetCsvReady(DataGridViewPersonalizat dGV, List<string> pListaColoaneImprimare, string filename, string pSeparator, bool pDeschideDupaCreare)
        {
            if (string.IsNullOrEmpty(filename))
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
            } 

            // Export data.  
            ToCsV(dGV, pListaColoaneImprimare, filename, pSeparator, pDeschideDupaCreare);
        }

        /// <summary>  
        /// Export the DataGridView to Comma Separated Value file.  
        /// This method should be used with the methods:  
        /// CsvThread().  
        /// GetCsvReady().  
        /// </summary>  
        /// <param name="dGV">Extended DataGridView.</param>  
        /// <param name="filename">Full path & name of  the Name of csv file.</param>  
        void ToCsV(DataGridViewPersonalizat dGV, List<string> pListaColoaneImprimare, string filename, string pSeparator, bool pDeschideDupaCreare)
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
                List<string> listaNumeColoaneExportabile = new List<string>();
                //string[] culturiVirgula = {"ar-JO", "ar-SY", "az-Cyrl-AZ", "az-Latn-AZ", "zh-CN", 
                //               "zh-SG", "zh-TW", "nl-BE", "nl-NL", "en-BZ", "en-CA", 
                //               "en-NZ", "en-US", "fr-CA", "ms-BN",
                //               "ms-MY", "nb-NO", "nn-NO", "pt-BR", "sr-Cyrl-CS", 
                //               "sr-Latn-CS", "es-AR", "es-DO", "es-MX",  
                //               "es-ES_tradnl", "sv-FI", "sv-SE", "uz-Cyrl-UZ", "uz-Latn-UZ"};

                string separator = pSeparator;// "; ";
                //if (culturiVirgula.Contains<string>(CultureInfo.CurrentCulture.Name))
                //    separator = ", ";

                foreach (string numeColoana in pListaColoaneImprimare)
                {
                    if (dGV.Columns[numeColoana].Visible && !dGV.SeIgnoraColoanaLaImprimare(numeColoana))
                    {
                        valoareCelula = CUtil.InlocuiesteDiacritice(dGV.Columns[numeColoana].HeaderText);
                        //Pentru a nu strica csv-ul
                        valoareCelula = valoareCelula.Replace(separator.Trim(), " ");
                        sHeaders.Append(valoareCelula);
                        sHeaders.Append(separator);
                        listaNumeColoaneExportabile.Add(numeColoana); //pentru a exporta datele coloanelor pretabile pentru export
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
                    foreach (string numeColoane in pListaColoaneImprimare)
                    {
                        if (listaNumeColoaneExportabile.Contains(numeColoane))
                        {
                            valoareCelula = CUtil.ConvertObjectToString(linie.Cells[numeColoane].EditedFormattedValue, true);

                            //Pentru a nu strica csv-ul
                            valoareCelula = valoareCelula.Replace(separator.Trim(), " ");

                            stLine.Append(valoareCelula);
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

            if (pDeschideDupaCreare)
                IHMUtile.PornesteProces(filename);
        }

    }
}
