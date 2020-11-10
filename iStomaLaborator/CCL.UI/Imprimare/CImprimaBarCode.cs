using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO.Compression;
using System.IO;
using System.Drawing;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using CCL.iStomaLab.Utile;
using CCL.iStomaLab;

namespace CCL.UI.Imprimare
{
    public static class CImprimaBarCode
    {
        private static int _SWidthInchSutimi = 157;
        private static int _SHeightInchSutimi = 118;
        private static string _SNume = string.Empty;
        private static string _SCod = string.Empty;

        public static bool Imprima(string pNume, string pCod)
        {
            try
            {
                _SNume = pNume;
                _SCod = CUtil.AdaugaZeroPentruMinimCaractere(pCod, 4); 

                //1. Verificam in config daca avem o imprimanta preferata pentru codurile de bare
                string cheiePrinter = CGestiuneIO.GetValoareDupaTipCheie(CGestiuneIO.EnumTipCheie.BCPRINTER);
                string printerName = string.Empty;

                if (string.IsNullOrEmpty(cheiePrinter))
                {
                    //2.2. Daca nu avem atunci deschidem fereastra de selectie a imprimantei si apoi o vom retine in config pentru utilizarile ulterioare
                    using (PrintDialog PrintDialog = new PrintDialog())
                    {
                        PrintDialog.ShowDialog();
                        printerName = PrintDialog.PrinterSettings.PrinterName;

                        if (!string.IsNullOrEmpty(printerName))
                            CGestiuneIO.SeteazaCheiePrinter(printerName);
                    }
                }
                else
                {
                    //2.1. Daca avem  key = "BCPRINTER" atunci o selectam si o folosim pentru imprimare
                    printerName = cheiePrinter;
                }

                //3. Setam preferintele de imprimare
                if (!string.IsNullOrEmpty(printerName))
                {
                    using (PrintDocument pd = new PrintDocument())
                    {
                        pd.PrinterSettings.PrinterName = printerName;
                        PaperSize paperSize = new PaperSize("Barcode", _SWidthInchSutimi, _SHeightInchSutimi);
                        pd.DefaultPageSettings.PaperSize = paperSize;
                        pd.DefaultPageSettings.Margins = new Margins(3, 3, 3, 3);

                        //4. Imprimam efectiv
                        pd.PrintPage += Document_PrintPage;
                        pd.EndPrint += Pd_EndPrint;
                        pd.BeginPrint += Pd_BeginPrint;
                        pd.Print();

                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        private static void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }

        private static void Pd_EndPrint(object sender, PrintEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }

        private static void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            string nume = _SNume;
            string cod = _SCod;

            using (Font fontText = new Font("Times New Roman", 7, FontStyle.Bold))
            {
                using (SolidBrush br = new SolidBrush(Color.Black))
                {
                    float inaltime = e.PageSettings.PrintableArea.Height;
                    float latime = e.PageSettings.PrintableArea.Width;

                    float margineStanga = e.PageSettings.Margins.Left;
                    float margineSus = e.PageSettings.Margins.Top;

                    float inaltimeRand = inaltime / 5;

                    float xCurent = margineStanga;
                    float yCurent = inaltimeRand;

                    SizeF marimeNume = e.Graphics.MeasureString(nume, fontText);

                    //Numele
                    if (marimeNume.Width < latime)
                    {
                        //Centrat
                        e.Graphics.DrawString(nume, fontText, br, (xCurent + latime - marimeNume.Width) / 2, yCurent);
                    }
                    else
                    {
                        //Din stanga
                        e.Graphics.DrawString(nume, fontText, br, new RectangleF(xCurent, yCurent, latime - 2 * margineStanga, marimeNume.Height));
                    }

                    yCurent += marimeNume.Height + inaltimeRand / 2;

                    //Codul de bare
                    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    var barcodeImage = barcode.Draw(cod, Convert.ToInt32(inaltimeRand));

                    marimeNume = new SizeF(barcodeImage.Width, barcodeImage.Height);
                    if (marimeNume.Width < latime)
                    {
                        //Centrat
                        e.Graphics.DrawImage(barcodeImage, (xCurent + latime - marimeNume.Width) / 2, yCurent);
                    }
                    else
                    {
                        //Din stanga
                        e.Graphics.DrawImage(barcodeImage, xCurent, yCurent);
                    }

                    yCurent += marimeNume.Height + inaltimeRand / 4;

                    //Codul in cifre
                    marimeNume = e.Graphics.MeasureString(cod, fontText);
                    if (marimeNume.Width < latime)
                    {
                        //Centrat
                        e.Graphics.DrawString(cod, fontText, br, (xCurent + latime - marimeNume.Width) / 2, yCurent);
                    }
                    else
                    {
                        //Din stanga
                        e.Graphics.DrawString(cod, fontText, br, xCurent, yCurent);
                    }

                    barcode = null;
                    e.HasMorePages = false;
                }
            }
        }

    }
}
