using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using CCL.UI;
using ILL.iStomaLab;
using static CDL.iStomaLab.CStructuriComune;
using CCL.iStomaLab;

/// <summary>
/// http://www.codeproject.com/Articles/13678/The-DataGridViewPrinter-Class
/// 
/// The Class Constructor : 
/// 
/// aDataGridView: The DataGridView control which will be printed.
/// aPrintDocument: The PrintDocument to be used for printing.
/// CenterOnPage: Determines if the report will be printed in the top-center of the page.
/// WithTitle: Determines if the page contains a title text.
/// aTitleText: The title text to be printed in each page (if WithTitle is set to true).
/// aTitleFont: The font to be used with the title text (if WithTitle is set to true).
/// aTitleColor: The color to be used with the title text (if WithTitle is set to true).
/// WithPaging: Determine if the page number will be printed.
/// </summary>
class DataGridViewPrinter
{
    private DataGridViewPersonalizat lDGVdePrintat; // The DataGridView Control which will be printed
    private PrintDocument ThePrintDocument; // The PrintDocument to be used for printing
    private bool IsCenterOnPage; // Determine if the report will be printed in the Top-Center of the page
    private bool IsWithTitle; // Determine if the page contain title text
    private bool lImprimaTitlulPeFiecarePagina;
    private string TheTitleText; // The title text to be printed in each page (if IsWithTitle is set to true)
    private Font TheTitleFont; // The font to be used with the title text (if IsWithTitle is set to true)
    private Color TheTitleColor; // The color to be used with the title text (if IsWithTitle is set to true)
    private bool IsWithPaging; // Determine if paging is used

    static int CurrentRow; // A static parameter that keep track on which Row (in the DataGridView control) that should be printed

    static int PageNumber;

    private int PageWidth;
    private int PageHeight;
    private int LeftMargin;
    private int TopMargin;
    private int RightMargin;
    private int BottomMargin;

    private float CurrentY; // A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate

    private float RowHeaderHeight;
    private Dictionary<int, float> RowsHeight; //index, inaltime
    private Dictionary<int, float> ColumnsWidth; //index, latime
    private float TheDataGridViewWidth;

    // Maintain a generic list to hold start/stop points for the column printing
    // This will be used for wrapping in situations where the DataGridView will not fit on a single page
    private List<int[]> mColumnPoints;
    private List<float> mColumnPointsWidth;
    private List<string> lListaColoaneImprimare = null;
    private int mColumnPoint;
    private StructPaletaDGV lPaleta = StructPaletaDGV.Empty;
    private Image lLogo = null;
    private string lHeader;
    private string lFooter;

    // The class constructor
    public DataGridViewPrinter(DataGridViewPersonalizat pDGV, StructPaletaDGV pPaleta, PrintDocument aPrintDocument, bool CenterOnPage, bool WithTitle, string aTitleText, bool pImprimaTitlulPeFiecarePagina, Font aTitleFont, Color aTitleColor, bool WithPaging, List<string> pListaColoane, Image logo, string pHeader, string pFooter)
    {
        this.lDGVdePrintat = pDGV;
        this.lPaleta = pPaleta;
        this.ThePrintDocument = aPrintDocument;
        this.IsCenterOnPage = CenterOnPage;
        this.IsWithTitle = WithTitle;
        this.TheTitleText = aTitleText;
        this.TheTitleFont = aTitleFont;
        this.TheTitleColor = aTitleColor;
        this.IsWithPaging = WithPaging;
        this.lImprimaTitlulPeFiecarePagina = pImprimaTitlulPeFiecarePagina;
        this.lLogo = logo;
        this.lHeader = pHeader;
        this.lFooter = pFooter;

        if (CUtil.EsteListaVida<string>(pListaColoane))
        {
            this.lListaColoaneImprimare = new List<string>();

            foreach (DataGridViewColumn coloana in pDGV.Columns)
            {
                if (!pDGV.SeIgnoraColoanaLaImprimare(coloana.Name))
                    this.lListaColoaneImprimare.Add(coloana.Name);
            }
        }
        else
            this.lListaColoaneImprimare = pListaColoane;

        PageNumber = 0;

        RowsHeight = new Dictionary<int, float>();
        ColumnsWidth = new Dictionary<int, float>();

        mColumnPoints = new List<int[]>();
        mColumnPointsWidth = new List<float>();

        // Claculating the PageWidth and the PageHeight
        if (!ThePrintDocument.DefaultPageSettings.Landscape)
        {
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
        }
        else
        {
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
        }

        // Calculating the page margins
        LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
        TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
        RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;
        BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;

        //Fie cele bifate, fie toate
        listaLiniiSelectate = lDGVdePrintat.GetListaLiniiSelectate();
        listaIndecsiColoanePrint = new List<int>();
        listaIndecsiLiniiSelectate = new List<int>();
        foreach (DataGridViewRow linie in listaLiniiSelectate)
        {
            listaIndecsiLiniiSelectate.Add(linie.Index);
        }
        // First, the current row to be printed is the first row in the DataGridView control
        CurrentRow = 0;
    }
    List<int> listaIndecsiColoanePrint = null; //lista de coloane imprimabile
    List<int> listaIndecsiLiniiSelectate = null; //lista de coloane imprimabile
    List<DataGridViewRow> listaLiniiSelectate = null;

    // The function that calculate the height of each row (including the header row), the width of each column (according to the longest text in all its cells including the header cell), and the whole DataGridView width
    private void Calculate(Graphics g, Font pFontText)
    {
        if (PageNumber == 0) // Just calculate once
        {
            SizeF tmpSize = new SizeF();
            float tmpWidth;

            TheDataGridViewWidth = 0;
            using (Font fontAntet = new System.Drawing.Font(pFontText, FontStyle.Bold))
            {
                //for (int i = 0; i < this.lDGVdePrintat.Columns.Count; i++)
                for (int i = 0; i < this.lListaColoaneImprimare.Count; i++)
                {
                    string numeColoana = this.lListaColoaneImprimare[i];
                    if (!this.lDGVdePrintat.Columns[numeColoana].Visible) continue; // Anumite coloane sunt ascunse cu un scop

                    //Vom ignora coloanele de selectie (printre altele)
                    //string numeColoana = this.lDGVdePrintat.Columns[i].Name;
                    if (this.lDGVdePrintat.SeIgnoraColoanaLaImprimare(numeColoana) || !this.lListaColoaneImprimare.Contains(numeColoana)) continue;

                    //tmpFont = this.lDGVdePrintat.ColumnHeadersDefaultCellStyle.Font;
                    //if (tmpFont == null) // If there is no special HeaderFont style, then use the default DataGridView font style
                    //    tmpFont = this.lDGVdePrintat.DefaultCellStyle.Font;

                    tmpSize = g.MeasureString(this.lDGVdePrintat.Columns[numeColoana].HeaderText, fontAntet);
                    tmpWidth = tmpSize.Width;
                    RowHeaderHeight = tmpSize.Height;

                    foreach (DataGridViewRow linie in listaLiniiSelectate)
                    {
                        //tmpFont = linie.DefaultCellStyle.Font;
                        //if (tmpFont == null) // If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                        //    tmpFont = lDGVdePrintat.DefaultCellStyle.Font;

                        tmpSize = g.MeasureString("Anything", fontAntet);
                        if (!RowsHeight.ContainsKey(linie.Index))
                            RowsHeight.Add(linie.Index, tmpSize.Height);

                        tmpSize = g.MeasureString(linie.Cells[numeColoana].EditedFormattedValue.ToString(), pFontText);
                        if (tmpSize.Width > tmpWidth)
                            tmpWidth = tmpSize.Width;
                    }

                    TheDataGridViewWidth += tmpWidth;
                    ColumnsWidth.Add(i, tmpWidth);

                    listaIndecsiColoanePrint.Add(i);
                }
            }

            // Define the start/stop column points based on the page width and the DataGridView Width
            // We will use this to determine the columns which are drawn on each page and how wrapping will be handled
            // By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
            int k;

            int mStartPoint = listaIndecsiColoanePrint[0];
            //for (k = 0; k < lDGVdePrintat.Columns.Count; k++)
            //    if (lDGVdePrintat.Columns[k].Visible)
            //    {
            //        mStartPoint = k;
            //        break;
            //    }

            int mEndPoint = listaIndecsiColoanePrint[listaIndecsiColoanePrint.Count - 1] + 1; //pentru a putea afisa si ultima coloana
            //    = lDGVdePrintat.Columns.Count;
            //for (k = lDGVdePrintat.Columns.Count - 1; k >= 0; k--)
            //    if (lDGVdePrintat.Columns[k].Visible)
            //    {
            //        mEndPoint = k + 1;
            //        break;
            //    }

            float mTempWidth = TheDataGridViewWidth;
            float mTempPrintArea = (float)PageWidth - (float)LeftMargin - (float)RightMargin;

            // We only care about handling where the total datagridview width is bigger then the print area
            if (TheDataGridViewWidth > mTempPrintArea)
            {
                mTempWidth = 0.0F;

                for (k = 0; k < listaIndecsiColoanePrint.Count; k++)
                {
                    mTempWidth += ColumnsWidth[listaIndecsiColoanePrint[k]];
                    // If the width is bigger than the page area, then define a new column print range
                    if (mTempWidth > mTempPrintArea)
                    {
                        mTempWidth -= ColumnsWidth[listaIndecsiColoanePrint[k]];
                        mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                        mColumnPointsWidth.Add(mTempWidth);
                        mStartPoint = listaIndecsiColoanePrint[k];
                        mTempWidth = ColumnsWidth[listaIndecsiColoanePrint[k]];
                    }
                    // Our end point is actually one index above the current index
                    if (listaIndecsiColoanePrint.Count > k + 1)
                        mEndPoint = listaIndecsiColoanePrint[k + 1];
                    else
                        mEndPoint = listaIndecsiColoanePrint[k] + 1;
                }
            }
            // Add the last set of columns
            mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
            mColumnPointsWidth.Add(mTempWidth);
            mColumnPoint = 0;
        }
    }

    // The funtion that print the title, page number, and the header row
    private void DrawHeader(Graphics g, Font fontText, bool pPrimaPagina)
    {
        CurrentY = (float)TopMargin;

        if (this.lLogo != null)
        {
            float latime = PageWidth - LeftMargin - RightMargin;
            RectangleF dreptunghiLogo = new RectangleF(this.LeftMargin, CurrentY, latime, lLogo.Height * latime / lLogo.Width);
            g.DrawImage(lLogo, dreptunghiLogo);

            CurrentY += Convert.ToInt32(dreptunghiLogo.Height) + 5; //lasam un spatiu intre logo si continut
        }

        // Printing the page number (if isWithPaging is set to true)
        PageNumber++;
        if (IsWithPaging)
        {
            string PageString = string.Format("{0} {1}", IHMUtile.getText(1424), PageNumber);

            StringFormat PageStringFormat = new StringFormat();
            PageStringFormat.Trimming = StringTrimming.Word;
            PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            PageStringFormat.Alignment = StringAlignment.Far;

            using (Font PageStringFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF PageStringRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(PageString, PageStringFont).Height);

                g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);

                CurrentY += g.MeasureString(PageString, PageStringFont).Height;
            }
        }

        // Printing the title (if IsWithTitle is set to true)
        if (IsWithTitle)
        {
            //Imprimam titlul in functie de preferintele utilizatorului
            //Titlul este centrat daca tabelul este centrat
            if (this.lImprimaTitlulPeFiecarePagina || pPrimaPagina)
            {
                using (StringFormat TitleFormat = new StringFormat())
                {
                    TitleFormat.Trimming = StringTrimming.Word;
                    TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    if (IsCenterOnPage)
                        TitleFormat.Alignment = StringAlignment.Center;
                    else
                        TitleFormat.Alignment = StringAlignment.Near;

                    RectangleF TitleRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height);

                    SizeF marimeNecesara = g.MeasureString(TheTitleText, TheTitleFont, PageWidth);

                    using (Brush brushTitlu = new SolidBrush(TheTitleColor))
                    {                        
                            g.DrawString(TheTitleText, TheTitleFont, brushTitlu, new PointF((PageWidth - marimeNecesara.Width) / 2, CurrentY));
                    }

                    CurrentY += 2 * marimeNecesara.Height;
                }
            }
        }

        if (pPrimaPagina)
        {
            if (!string.IsNullOrEmpty(this.lHeader))
            {
                RectangleF HeaderRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(this.lHeader, fontText).Height);

                SizeF marimeNecesara = g.MeasureString(this.lHeader, fontText, PageWidth);

                using (Brush brushTitlu = new SolidBrush(TheTitleColor))
                {
                    g.DrawString(this.lHeader, fontText, brushTitlu, HeaderRectangle);
                }

                CurrentY += marimeNecesara.Height;
            }
        }

        // Calculating the starting x coordinate that the printing process will start from
        float CurrentX = (float)LeftMargin;
        if (IsCenterOnPage)
            CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

        // Setting the HeaderFore style
        //Color HeaderForeColor = lDGVdePrintat.ColumnHeadersDefaultCellStyle.ForeColor;
        //if (HeaderForeColor.IsEmpty) // If there is no special HeaderFore style, then use the default DataGridView style
        //    HeaderForeColor = lDGVdePrintat.DefaultCellStyle.ForeColor;
        // Setting the HeaderBack style
        //Color HeaderBackColor = lDGVdePrintat.ColumnHeadersDefaultCellStyle.BackColor;
        //if (HeaderBackColor.IsEmpty) // If there is no special HeaderBack style, then use the default DataGridView style
        //    HeaderBackColor = lDGVdePrintat.DefaultCellStyle.BackColor;
        //SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);
        // Setting the HeaderFont style
        //Font HeaderFont = lDGVdePrintat.ColumnHeadersDefaultCellStyle.Font;
        //    if (HeaderFont == null) // If there is no special HeaderFont style, then use the default DataGridView font style
        //        HeaderFont = lDGVdePrintat.DefaultCellStyle.Font;
        using (SolidBrush HeaderForeBrush = new SolidBrush(this.lPaleta.CuloareTextAntet), HeaderBackBrush = new SolidBrush(this.lPaleta.CuloareFundalAntet))
        {
            // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            using (Pen TheLinePen = new Pen(this.lPaleta.CuloareTrasareLiniiTabel, 1))
            {
                // Setting the HeaderFont style
                using (Font HeaderFont = new System.Drawing.Font(fontText, FontStyle.Bold))
                {
                    // Calculating and drawing the HeaderBounds        
                    RectangleF HeaderBounds = new RectangleF(CurrentX, CurrentY, mColumnPointsWidth[mColumnPoint], RowHeaderHeight);
                    g.FillRectangle(HeaderBackBrush, HeaderBounds);

                    // Setting the format that will be used to print each cell of the header row
                    using (StringFormat CellFormat = new StringFormat())
                    {
                        CellFormat.Trimming = StringTrimming.Word;
                        CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

                        // Printing each visible cell of the header row
                        RectangleF CellBounds;
                        float ColumnWidth;
                        bool primaColoana = true;
                        bool ultimaColoana = false;
                        for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
                        {
                            if (!listaIndecsiColoanePrint.Contains(i)) continue;

                            ColumnWidth = ColumnsWidth[i];
                            ultimaColoana = (i == Convert.ToInt32(mColumnPoints[mColumnPoint].GetValue(1)) - 1);

                            // Check the CurrentCell alignment and apply it to the CellFormat
                            if (this.lDGVdePrintat.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                                CellFormat.Alignment = StringAlignment.Far;
                            else if (this.lDGVdePrintat.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                                CellFormat.Alignment = StringAlignment.Center;
                            else
                                CellFormat.Alignment = StringAlignment.Near;

                            CellBounds = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);

                            // Printing the cell text
                            g.DrawString(this.lDGVdePrintat.Columns[this.lListaColoaneImprimare[i]].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);

                            // Drawing the cell bounds
                            if (this.lDGVdePrintat.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None) // Draw the cell border only if the HeaderBorderStyle is not None
                            {
                                deseneazaCelula(g, TheLinePen, new RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight), primaColoana, ultimaColoana, CurrentX, ColumnWidth, RowHeaderHeight);
                                //g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);
                            }

                            CurrentX += ColumnWidth;
                            primaColoana = false;
                        }
                    }

                    CurrentY += RowHeaderHeight;
                }
            }
        }
    }

    private void deseneazaCelula(Graphics g, Pen penChenar, RectangleF chenarCelula, bool primaColoana, bool ultimaColoana, float CurrentX, float ColumnWidth, float pInaltime)
    {
        if (this.lPaleta.DeseneazaSeparatoriColoane)
            g.DrawRectangle(penChenar, CurrentX, CurrentY, ColumnWidth, pInaltime);
        else
        {
            //sus
            g.DrawLine(penChenar, chenarCelula.Location, new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y));

            if (primaColoana)
            {
                //stanga
                g.DrawLine(penChenar, chenarCelula.Location, new PointF(chenarCelula.X, chenarCelula.Y + chenarCelula.Height));
            }

            //jos
            g.DrawLine(penChenar, new PointF(chenarCelula.X, chenarCelula.Y + chenarCelula.Height), new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y + chenarCelula.Height));

            if (ultimaColoana)
            {
                //dreapta
                g.DrawLine(penChenar, new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y), new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y + chenarCelula.Height));
            }
        }
    }

    // The function that print a bunch of rows that fit in one page
    // When it returns true, meaning that there are more rows still not printed, so another PagePrint action is required
    // When it returns false, meaning that all rows are printed (the CureentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
    private bool DrawRows(Graphics g, Font RowFont)
    {
        // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        using (Pen penChenar = new Pen(this.lPaleta.CuloareTrasareLiniiTabel, 1))
        {
            // The style paramters that will be used to print each cell
            using (SolidBrush RowForeBrush = new SolidBrush(this.lPaleta.CuloareTextTabel),
                    RowBackBrush = new SolidBrush(Color.White),
                    RowAlternatingBackBrush = new SolidBrush(this.lPaleta.CuloareFundalLinieAlternanta),
                    RowAlternatingForeBrush = new SolidBrush(this.lPaleta.CuloareTextLinieAlternanta))
            {
                // Setting the format that will be used to print each cell
                StringFormat CellFormat = new StringFormat();
                CellFormat.Trimming = StringTrimming.Word;
                CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

                // Printing each visible cell
                RectangleF RowBounds;
                float CurrentX;
                float ColumnWidth;
                int indexLinie = 0;
                bool liniePara = false;
                bool primaColoana = false;
                bool ultimaColoana = false;
                while (CurrentRow < listaIndecsiLiniiSelectate.Count)// lDGVdePrintat.Rows.Count)
                {
                    indexLinie = listaIndecsiLiniiSelectate[CurrentRow];
                    liniePara = CurrentRow % 2 == 1;
                    primaColoana = true;
                    ultimaColoana = false;
                    //if (lDGVdePrintat.Rows[CurrentRow].Visible) // Print the cells of the CurrentRow only if that row is visible
                    //{
                    // Setting the row font style
                    //RowFont = lDGVdePrintat.Rows[indexLinie].DefaultCellStyle.Font;
                    //if (RowFont == null) // If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                    //    RowFont = lDGVdePrintat.DefaultCellStyle.Font;

                    //// Setting the RowFore style
                    //RowForeColor = lDGVdePrintat.Rows[indexLinie].DefaultCellStyle.ForeColor;
                    //if (RowForeColor.IsEmpty) // If the there is no special RowFore style of the CurrentRow, then use the default one associated with the DataGridView control
                    //    RowForeColor = lDGVdePrintat.DefaultCellStyle.ForeColor;
                    //RowForeBrush = new SolidBrush(RowForeColor);

                    //// Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                    //RowBackColor = lDGVdePrintat.Rows[indexLinie].DefaultCellStyle.BackColor;
                    //if (RowBackColor.IsEmpty) // If the there is no special RowBack style of the CurrentRow, then use the default one associated with the DataGridView control
                    //{
                    //    RowBackBrush = new SolidBrush(lDGVdePrintat.DefaultCellStyle.BackColor);
                    //    RowAlternatingBackBrush = new SolidBrush(lDGVdePrintat.AlternatingRowsDefaultCellStyle.BackColor);
                    //}
                    //else // If the there is a special RowBack style of the CurrentRow, then use it for both the RowBack and the RowAlternatingBack styles
                    //{
                    //    RowBackBrush = new SolidBrush(RowBackColor);
                    //    RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                    //}

                    // Calculating the starting x coordinate that the printing process will start from
                    CurrentX = (float)LeftMargin;
                    if (IsCenterOnPage)
                        CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

                    // Calculating the entire CurrentRow bounds                
                    RowBounds = new RectangleF(CurrentX, CurrentY, mColumnPointsWidth[mColumnPoint], RowsHeight[listaIndecsiLiniiSelectate[CurrentRow]]);

                    // Filling the back of the CurrentRow
                    if (liniePara)
                        g.FillRectangle(RowAlternatingBackBrush, RowBounds);
                    else
                        g.FillRectangle(RowBackBrush, RowBounds);

                    // Printing each visible cell of the CurrentRow   
                    for (int CurrentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); CurrentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); CurrentCell++)
                    {
                        //if (!lDGVdePrintat.Columns[CurrentCell].Visible) continue; // If the cell is belong to invisible column, then ignore this iteration
                        if (!listaIndecsiColoanePrint.Contains(CurrentCell)) continue;

                        ultimaColoana = (CurrentCell == Convert.ToInt32(mColumnPoints[mColumnPoint].GetValue(1)) - 1);

                        // Check the CurrentCell alignment and apply it to the CellFormat
                        if (this.lDGVdePrintat.Columns[this.lListaColoaneImprimare[CurrentCell]].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                            CellFormat.Alignment = StringAlignment.Far;
                        else if (this.lDGVdePrintat.Columns[this.lListaColoaneImprimare[CurrentCell]].DefaultCellStyle.Alignment.ToString().Contains("Center"))
                            CellFormat.Alignment = StringAlignment.Center;
                        else
                            CellFormat.Alignment = StringAlignment.Near;

                        ColumnWidth = ColumnsWidth[CurrentCell];
                        RectangleF chenarCelula = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowsHeight[indexLinie]);

                        // Printing the cell text
                        g.DrawString(CUtil.ConvertObjectToString(this.lDGVdePrintat.Rows[indexLinie].Cells[this.lListaColoaneImprimare[CurrentCell]].EditedFormattedValue, false), RowFont, (liniePara ? RowAlternatingForeBrush : RowForeBrush), chenarCelula, CellFormat);

                        // Drawing the cell bounds
                        if (lDGVdePrintat.CellBorderStyle != DataGridViewCellBorderStyle.None) // Draw the cell border only if the CellBorderStyle is not None
                        {
                            deseneazaCelula(g, penChenar, chenarCelula, primaColoana, ultimaColoana, CurrentX, chenarCelula.Width, RowsHeight[indexLinie]);
                            //if (this.lPaleta.DeseneazaSeparatoriColoane)
                            //    g.DrawRectangle(penChenar, CurrentX, CurrentY, ColumnWidth, RowsHeight[indexLinie]);
                            //else
                            //{
                            //    //sus
                            //    g.DrawLine(penChenar, chenarCelula.Location, new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y));

                            //    if (primaColoana)
                            //    {
                            //        //stanga
                            //        g.DrawLine(penChenar, chenarCelula.Location, new PointF(chenarCelula.X, chenarCelula.Y + chenarCelula.Height));
                            //    }

                            //    //jos
                            //    g.DrawLine(penChenar, new PointF(chenarCelula.X, chenarCelula.Y + chenarCelula.Height), new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y + chenarCelula.Height));

                            //    if (ultimaColoana)
                            //    {
                            //        //dreapta
                            //        g.DrawLine(penChenar, new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y), new PointF(chenarCelula.X + chenarCelula.Width, chenarCelula.Y + chenarCelula.Height));
                            //    }
                            //}
                        }

                        CurrentX += ColumnWidth;
                        primaColoana = false;
                    }
                    CurrentY += RowsHeight[indexLinie];

                    // Checking if the CurrentY is exceeds the page boundries
                    // If so then exit the function and returning true meaning another PagePrint action is required
                    if ((int)CurrentY > (PageHeight - TopMargin - BottomMargin))
                    {
                        CurrentRow++;
                        return true;
                    }
                    //}
                    CurrentRow++;
                }

                CurrentRow = 0;
                mColumnPoint++; // Continue to print the next group of columns

                if (!string.IsNullOrEmpty(this.lFooter))
                {
                    RectangleF HeaderRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(this.lFooter, RowFont).Height);

                    SizeF marimeNecesara = g.MeasureString(this.lFooter, RowFont, PageWidth);

                    using (Brush brushTitlu = new SolidBrush(TheTitleColor))
                    {
                        g.DrawString(this.lFooter, RowFont, brushTitlu, HeaderRectangle);
                    }

                    CurrentY += 2 * marimeNecesara.Height;
                }

                if (mColumnPoint == mColumnPoints.Count) // Which means all columns are printed
                {
                    mColumnPoint = 0;
                    return false;
                }
                else
                    return true;
            }
        }
    }

    // The method that calls all other functions
    public bool DrawDataGridView(Graphics g, bool pPrimaPagina)
    {
        try
        {
            using (Font fontText = new Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point))
            {
                Calculate(g, fontText);
                DrawHeader(g, fontText, pPrimaPagina);
                bool bContinue = DrawRows(g, fontText);
                return bContinue;
            }
        }
        catch (Exception ex)
        {
            IHMUtile.AfiseazaEroare(IHMUtile.GetFormParinte(lDGVdePrintat), ex.Message.ToString(), IHMUtile.getText(605), true);
            return false;
        }
    }
}
