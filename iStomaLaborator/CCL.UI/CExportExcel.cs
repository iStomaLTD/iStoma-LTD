using CarlosAg.ExcelXmlWriter;
using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL.UI
{
    public static class CExportExcel
    {
        public static void Test()
        {
            string numefisier = string.Concat("C:\\COSTEA\\", DateTime.Now.ToString("yyyyMMddHHmmss"), ".xls");
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets.Add("iDava");
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add("Hello World");
            book.Save(numefisier);
            Process.Start(numefisier);
        }

        public static void Exporta(Form pEcranParinte, string pNumeFila, List<string> listaHeader, List<List<string>> listaValori)
        {
            string fisierSalvare = CCL.UI.IHMUtile.GetCaleSalvareFisier(pEcranParinte, ".xls");

            if (!string.IsNullOrEmpty(fisierSalvare))
            {
                string numefisier = fisierSalvare;// string.Concat("C:\\COSTEA\\", DateTime.Now.ToString("yyyyMMddHHmmss"), ".xls");

                string idStilHeader = "idSHeader";
                WorksheetStyle stilHeader = new WorksheetStyle(idStilHeader);
                stilHeader.Font.Bold = true;
                stilHeader.Interior.Pattern = StyleInteriorPattern.Solid;
                stilHeader.Interior.Color = "#FFFFCC";

                string idStilHeaderVertical = "idSHeaderVertical";
                WorksheetStyle stilHeaderVertical = new WorksheetStyle(idStilHeaderVertical);
                stilHeaderVertical.Alignment.Rotate = 90;
                stilHeaderVertical.Font.Bold = true;
                stilHeaderVertical.Interior.Pattern = StyleInteriorPattern.Solid;
                stilHeaderVertical.Interior.Color = "#FFFFCC";

                string idStilPrimaColoana = "idSPrimaColoana";
                WorksheetStyle stilPrimaColoana = new WorksheetStyle(idStilPrimaColoana);
                stilPrimaColoana.Font.Bold = true;
                stilPrimaColoana.Interior.Pattern = StyleInteriorPattern.Solid;
                stilPrimaColoana.Interior.Color = "#99CC00";

                string idStilNormal = "idSNormal";
                WorksheetStyle stilNormal = new WorksheetStyle(idStilNormal);

                Workbook book = new Workbook();
                book.Styles.Add(stilHeader);
                book.Styles.Add(stilHeaderVertical);
                book.Styles.Add(stilPrimaColoana);
                book.Styles.Add(stilNormal);

                Worksheet sheet = book.Worksheets.Add(pNumeFila);

                WorksheetRow rowHeader = sheet.Table.Rows.Add();
                for (int i = 0; i < listaHeader.Count; i++)
                {
                    rowHeader.Cells.Add(listaHeader[i], DataType.String, i > 0 ? idStilHeaderVertical : idStilHeader);
                }

                //sheet.Options.FreezePanes = true;

                foreach (var item in listaValori)
                {
                    WorksheetRow rowValoare = sheet.Table.Rows.Add();
                    int index = 0;
                    foreach (var celula in item)
                    {
                        if (index == 0)
                        {
                            rowValoare.Cells.Add(celula, DataType.String, idStilPrimaColoana);
                        }
                        else
                            rowValoare.Cells.Add(celula, DataType.String, idStilNormal);

                        index += 1;
                    }
                }

                book.Save(numefisier);
                Process.Start(numefisier);
            }
        }

        public static void Exporta(DataGridViewPersonalizat dGV, List<string> pListaColoaneImprimare, string pEtichetaTotal, string pFisier, bool pDeschideDupaCreare)
        {
            string fisierSalvare = pFisier;

            DataType tipCelula = DataType.String;

            if (string.IsNullOrEmpty(fisierSalvare))
                fisierSalvare = CCL.UI.IHMUtile.GetCaleSalvareFisier(CCL.UI.IHMUtile.GetFormParinte(dGV), ".xls");

            if (string.IsNullOrEmpty(fisierSalvare))
                return;

            string idStilHeader = "idSHeader";
            WorksheetStyle stilHeader = new WorksheetStyle(idStilHeader);
            stilHeader.Font.Bold = true;
            stilHeader.Interior.Pattern = StyleInteriorPattern.Solid;
            stilHeader.Interior.Color = "#c0c0c0";

            string idStilTotal = "idSTotal";
            WorksheetStyle stilTotal = new WorksheetStyle(idStilTotal);
            stilTotal.Font.Bold = true;
            stilTotal.Interior.Pattern = StyleInteriorPattern.Solid;
            stilTotal.Interior.Color = "#80ff80";

            string idStilNormal = "idSNormal";
            WorksheetStyle stilNormal = new WorksheetStyle(idStilNormal);

            Workbook book = new Workbook();
            book.Styles.Add(stilHeader);
            book.Styles.Add(stilNormal);
            book.Styles.Add(stilTotal);

            Worksheet sheet = book.Worksheets.Add("iDava");

            List<string> listaNumeColoaneExportabile = new List<string>();
            Dictionary<string, DataType> dictColoaneTipuri = new Dictionary<string, DataType>();
            string valoareCelula = string.Empty;
            WorksheetRow rowHeader = sheet.Table.Rows.Add();
            foreach (string numeColoana in pListaColoaneImprimare)
            {
                if (dGV.Columns[numeColoana].Visible && !dGV.SeIgnoraColoanaLaImprimare(numeColoana))
                {
                    listaNumeColoaneExportabile.Add(numeColoana); //pentru a exporta datele coloanelor pretabile pentru export
                    dictColoaneTipuri.Add(numeColoana, getDataType(dGV.Columns[numeColoana]));

                    valoareCelula = CUtil.InlocuiesteDiacritice(dGV.Columns[numeColoana].HeaderText);
                    rowHeader.Cells.Add(valoareCelula, dictColoaneTipuri[numeColoana], idStilHeader);
                }
            }

            List<DataGridViewRow> listaLiniiSelectate = dGV.GetListaLiniiSelectate();
            bool existaValoareNumerica = false;
            double totalValoareNumerica = 0;
            foreach (DataGridViewRow linie in listaLiniiSelectate)
            {
                if (linie.Tag == null) continue; //in Tag-ul tuturor liniilor din aplicatie salvam obiectul corespunzator liniei respective; lipsa acestuia implica ignorarea liniei

                WorksheetRow rowValoare = sheet.Table.Rows.Add();
                foreach (string numeColoane in pListaColoaneImprimare)
                {
                    if (listaNumeColoaneExportabile.Contains(numeColoane))
                    {
                        if (linie.Cells[numeColoane].Tag != null && linie.Cells[numeColoane].Tag is String)
                            valoareCelula = CUtil.ConvertObjectToString(linie.Cells[numeColoane].Tag, true);
                        else
                            valoareCelula = CUtil.ConvertObjectToString(linie.Cells[numeColoane].EditedFormattedValue, true);

                        if (dGV.esteColoanaNumericaExport(numeColoane))
                        {
                            existaValoareNumerica = true;
                            totalValoareNumerica += CUtil.GetAsDouble(valoareCelula);
                            rowValoare.Cells.Add(valoareCelula, dictColoaneTipuri[numeColoane], idStilNormal);
                        }
                        else
                            rowValoare.Cells.Add(valoareCelula, dictColoaneTipuri[numeColoane], idStilNormal);
                    }
                }
            }

            if (existaValoareNumerica)
            {
                WorksheetRow rowValoare = sheet.Table.Rows.Add();
                int indexCelula = 0;
                foreach (string numeColoane in pListaColoaneImprimare)
                {
                    if (listaNumeColoaneExportabile.Contains(numeColoane))
                    {
                        if (dGV.esteColoanaNumericaExport(numeColoane))
                        {
                            rowValoare.Cells.Add(Convert.ToString(Math.Round(totalValoareNumerica, 2)), dictColoaneTipuri[numeColoane], idStilTotal);
                        }
                        else
                        {
                            if (indexCelula == 0)
                                rowValoare.Cells.Add(pEtichetaTotal, tipCelula, idStilTotal);
                            else
                                rowValoare.Cells.Add(string.Empty, tipCelula, idStilTotal);

                            indexCelula += 1;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(fisierSalvare))
            {
                book.Save(fisierSalvare);

                if (pDeschideDupaCreare)
                    Process.Start(fisierSalvare);
            }
        }

        private static DataType getDataType(DataGridViewColumn col)
        {
            if (col.CellType == typeof(DateTime))
            {
                return DataType.DateTime;
            }
            else if (col.CellType == typeof(string))
            {
                return DataType.String;
            }
            else if (col.CellType == typeof(sbyte)
                || col.CellType == typeof(byte)
                || col.CellType == typeof(short)
                || col.CellType == typeof(ushort)
                || col.CellType == typeof(int)
                || col.CellType == typeof(uint)
                || col.CellType == typeof(long)
                || col.CellType == typeof(ulong)
                || col.CellType == typeof(float)
                || col.CellType == typeof(double)
                || col.CellType == typeof(decimal)
                )
            {
                return DataType.Number;
            }
            else
            {
                return DataType.String;
            }
        }
    }
}
