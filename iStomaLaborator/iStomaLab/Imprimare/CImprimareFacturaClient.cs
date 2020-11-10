using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Locatii;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab.Imprimare
{
    class CImprimareFacturaClient
    {
        private static int lLatimePagina;
        private static int lInaltimePagina;
        private static int lMargineStanga;
        private static int lMargineSus;
        private static int lMargineDreapta;
        private static int lMargineJos;
        private static bool lHeaderDesenat = false;

        private static int nrOrdine = 1;
        private static int hLinie = 0;
        private static int indexInterventieDesenata = 0;

        private static BColectieClientiComenzi lLiniiRegistru = null;
        private static BClientiFacturi lFactura = null;
        private static BLocatii lLocatieFiscala = null;

        private static PrintDocument SetupThePrinting(Form pEcranParinte, string pNumeDocument)
        {
            using (PrintDialog MyPrintDialog = new PrintDialog())
            {
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;
                if (!CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, MyPrintDialog))
                {
                    return null;
                }

                PrintDocument _SPrintDocument = creazaPrintDocument();

                _SPrintDocument.DocumentName = pNumeDocument;
                _SPrintDocument.PrinterSettings =
                                    MyPrintDialog.PrinterSettings;
                _SPrintDocument.DefaultPageSettings =
                MyPrintDialog.PrinterSettings.DefaultPageSettings;
                _SPrintDocument.DefaultPageSettings.Margins =
                                 new Margins(10, 10, 10, 10);

                if (!_SPrintDocument.DefaultPageSettings.Landscape)
                {
                    lLatimePagina = Convert.ToInt32(_SPrintDocument.DefaultPageSettings.PrintableArea.Width);
                    lInaltimePagina = Convert.ToInt32(_SPrintDocument.DefaultPageSettings.PrintableArea.Height);
                }
                else
                {
                    lInaltimePagina = Convert.ToInt32(_SPrintDocument.DefaultPageSettings.PrintableArea.Width);
                    lLatimePagina = Convert.ToInt32(_SPrintDocument.DefaultPageSettings.PrintableArea.Height);
                }

                // Calculating the page margins
                lMargineStanga = Convert.ToInt32(Math.Max(_SPrintDocument.DefaultPageSettings.HardMarginX, _SPrintDocument.DefaultPageSettings.Margins.Left));
                lMargineSus = Convert.ToInt32(Math.Max(_SPrintDocument.DefaultPageSettings.HardMarginY, _SPrintDocument.DefaultPageSettings.Margins.Top));
                lMargineDreapta = Convert.ToInt32(Math.Max(_SPrintDocument.DefaultPageSettings.HardMarginX, _SPrintDocument.DefaultPageSettings.Margins.Right));
                lMargineJos = Convert.ToInt32(Math.Max(_SPrintDocument.DefaultPageSettings.HardMarginY, _SPrintDocument.DefaultPageSettings.Margins.Bottom));

                //Lasam o marja de 2 pixeli in dreapta pentru chenar
                lMargineDreapta = lMargineDreapta + 2;

                lHeaderDesenat = false;

                return _SPrintDocument;
            }
        }

        private static PrintDocument creazaPrintDocument()
        {
            PrintDocument _SPrintDocument = new PrintDocument();
            _SPrintDocument.PrintPage += document_PrintPage;
            _SPrintDocument.EndPrint += document_EndPrint;
            _SPrintDocument.BeginPrint += _SPrintDocument_BeginPrint;
            return _SPrintDocument;
        }

        static void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.HasMorePages = Deseneaza(e.Graphics, 1, false);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(null, ex);
            }
        }

        static void document_EndPrint(object sender, PrintEventArgs e)
        {
        }

        static void _SPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            initVariabileDesenare();
        }

        private static void initVariabileDesenare()
        {
            lHeaderDesenat = false;
            nrOrdine = 1;
            hLinie = 0;
            indexInterventieDesenata = 0;
        }

        static private bool Deseneaza(Graphics g, int pPrinterResolution, bool pPentruEmail)
        {
            try
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            }
            catch (Exception)
            {
            }

            int mulRezolutie = pPrinterResolution;// 1;// e.PageSettings.PrinterResolution.X;
            int multiplu = mulRezolutie / 96;

            int spatiuComfort = 0;

            if (multiplu <= 0)
            {
                mulRezolutie = 1;
                multiplu = 1;
            }

            int latimePagina = lLatimePagina * multiplu;
            int inaltimePagina = lInaltimePagina * multiplu;
            int margineStanga = lMargineStanga * multiplu;
            int margineDreapta = lMargineDreapta * multiplu;
            int margineSus = lMargineSus * multiplu;
            int margineJos = lMargineJos * multiplu;

            int latime = latimePagina - (margineStanga + margineDreapta);
            int inaltime = inaltimePagina - (margineSus + margineJos);
            int x = margineStanga + 5 * multiplu;
            int y = margineSus;
            bool morePages = false;

            Font fontText = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font fontIngrosat = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int distantaLinii = 1 * multiplu;
            int distantaGrupuri = 5 * multiplu;

            spatiuComfort = Convert.ToInt32(g.MeasureString("H", fontText).Height);

            //Capul tabelului
            string nrCrt = "#";
            string dataPrimire = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Data);
            string pacient = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pacient);
            string lucrare = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrare);
            string nrElem = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrElem);
            string pret = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pret);

            int wNrCrt = Convert.ToInt32(Math.Ceiling(Math.Max(g.MeasureString("999", fontText, latime).Width, g.MeasureString(nrCrt, fontText, latime).Width)));
            int wDataPrimire = Convert.ToInt32(Math.Ceiling(g.MeasureString("13.02.1983 13", fontText, latime).Width));
            int wPret = Convert.ToInt32(Math.Ceiling(g.MeasureString("999.999,00", fontText, latime).Width));
            int wNrElem = Convert.ToInt32(Math.Ceiling(g.MeasureString(nrElem, fontText, latime).Width));
            int wPacient = Convert.ToInt32(Math.Ceiling(g.MeasureString("BOTOROGEANU Ionut Richard", fontText, latime).Width));
            int wLucrare = latime - (wNrCrt + wDataPrimire + wPret + wNrElem + wPacient);

            int xNrCrt = x;
            int xDataPrimire = x + wNrCrt + 1;
            int xPacient = xDataPrimire + wDataPrimire + 1;
            int xLucrare = xPacient + wPacient + 1;
            int xNrElem = xLucrare + wLucrare + 1;
            int xPret = xNrElem + wNrElem + 1;

            bool listaCompletDesenata = true;

            using (Brush pensulaPrescriptie = new SolidBrush(Color.Black))
            {
                int wLatimeParti = (latime - (margineStanga + lMargineDreapta)) / 2 - 65 * multiplu;

                //if (!this.lHeaderDesenat)
                //{
                //    //Desenam logo
                //    try
                //    {
                //        float wDisponibil = (this.lLatimePagina - this.lMargineDreapta) - this.lMargineStanga;
                //        using (Image lImagineLogo = getLogoSediu())
                //        {
                //            if (lImagineLogo != null)
                //            {
                //                RectangleF dreptunghiLogo = new RectangleF(this.lMargineStanga, y, wDisponibil, lImagineLogo.Height * wDisponibil / lImagineLogo.Width);
                //                g.DrawImage(lImagineLogo, dreptunghiLogo);

                //                y += Convert.ToInt32(dreptunghiLogo.Height) + spatiuComfort; //lasam un spatiu intre logo si continut
                //            }
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        //Nu este tragedie daca nu se deseneaza logo-ul
                //    }
                //}

                //In stanga sus desenam unitatea
                g.DrawString(lLocatieFiscala.DenumireFiscala, fontText, pensulaPrescriptie, x, y);

                string textTemp = string.Empty;
                SizeF marimeTemp = SizeF.Empty;

                //In dreapta sus numele clientului
                textTemp = lFactura.GetClient(null).GetDenumireFiscala();

                //string.Format("{0}: {1} {2}: {3} {4}: {5}",                    BMultiLingv.getElementById(BMultiLingv.EnumDictionar.zi).ToUpper(), lFactura.DataFactura.Day,                    BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Luna).ToUpper(), lFactura.DataFactura.Month,                    BMultiLingv.getElementById(BMultiLingv.EnumDictionar.An).ToUpper(), lFactura.DataFactura.Year);

                marimeTemp = g.MeasureString(textTemp, fontIngrosat, latime);
                CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaPrescriptie, new RectangleF(x, y, latime, marimeTemp.Height), textTemp, fontText);

                y += spatiuComfort;

                if (!lHeaderDesenat)
                {
                    //Titlul
                    if (lFactura.EsteFiscalizata())
                        textTemp = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura).ToUpper();
                    else
                        textTemp = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Proforma).ToUpper();

                    marimeTemp = g.MeasureString(textTemp, fontIngrosat, latime);

                    CCL.UI.IHMUtile.ScrieInCentru(g, pensulaPrescriptie, new RectangleF(x, y, latime, marimeTemp.Height), textTemp, fontIngrosat);
                    y += Convert.ToInt32(marimeTemp.Height);

                    //Data
                    if (lFactura.EsteFiscalizata())
                        textTemp = string.Format("{0} {1}/{2}", lFactura.SerieFactura, lFactura.NumarFactura, lFactura.DataFactura.ToString(CConstante.FORMAT_DATA));
                    else
                        textTemp = lFactura.DataFactura.ToString(CConstante.FORMAT_DATA);

                    marimeTemp = g.MeasureString(textTemp, fontText, latime);

                    CCL.UI.IHMUtile.ScrieInCentru(g, pensulaPrescriptie, new RectangleF(x, y, latime, marimeTemp.Height), textTemp, fontText);
                    y += Convert.ToInt32(marimeTemp.Height) + spatiuComfort / 2;

                    lHeaderDesenat = true;
                }
                else
                    y += spatiuComfort / 2;

                //Trasam tabelul
                g.DrawLine(Pens.Black, x, y, x + latime, y);
                int yInceputTabel = y;

                y += spatiuComfort / 3;

                //Desenam antetul
                //Nr crt
                int hMax = 0;
                SizeF marimeNecesaraAntet = g.MeasureString(nrCrt, fontText, wNrCrt);
                CCL.UI.IHMUtile.ScrieInCentru(g, pensulaPrescriptie, new RectangleF(xNrCrt, y, wNrCrt, marimeNecesaraAntet.Height), nrCrt, fontText);
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                //Data primire
                marimeNecesaraAntet = g.MeasureString(dataPrimire, fontText, wDataPrimire);
                g.DrawString(dataPrimire, fontText, pensulaPrescriptie, new RectangleF(xDataPrimire, y, marimeNecesaraAntet.Width, marimeNecesaraAntet.Height));
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                //Pacient
                marimeNecesaraAntet = g.MeasureString(pacient, fontText, wPacient);
                g.DrawString(pacient, fontText, pensulaPrescriptie, new RectangleF(xPacient, y, marimeNecesaraAntet.Width, marimeNecesaraAntet.Height));
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                //Lucrare
                marimeNecesaraAntet = g.MeasureString(lucrare, fontText, wLucrare);
                g.DrawString(lucrare, fontText, pensulaPrescriptie, new RectangleF(xLucrare, y, marimeNecesaraAntet.Width, marimeNecesaraAntet.Height));
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                //Nr Elem
                marimeNecesaraAntet = g.MeasureString(nrElem, fontText, wNrElem);
                CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaPrescriptie, new RectangleF(xNrElem, y, wNrElem, marimeTemp.Height), nrElem, fontText);
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                //Pret
                marimeNecesaraAntet = g.MeasureString(pret, fontText, wPret);
                CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaPrescriptie, new RectangleF(xPret, y, wPret, marimeTemp.Height), pret, fontText);
                if (hMax < marimeNecesaraAntet.Height)
                    hMax = Convert.ToInt32(Math.Ceiling(marimeNecesaraAntet.Height));

                y += hMax + spatiuComfort / 3;

                //Aici se termina antetul
                g.DrawLine(Pens.Black, x, y, x + latime, y);

                y += spatiuComfort / 3;

                ////De aici incepem desenarea liniilor
                //g.DrawLine(Pens.Black, x, y, x + latime, y);

                int indexActual = indexInterventieDesenata;
                BClientiComenzi interventie = null;

                int inaltimeNecesaraFooter = Convert.ToInt32(2 * g.MeasureString("TOTAL", fontText).Height);
                int hNecesar = 0;
                string nrCrtTemp = string.Empty;
                string dataPrimireTemp = string.Empty;
                string pacientTemp = string.Empty;
                string lucrareTemp = string.Empty;
                string nrElemTemp = string.Empty;
                string pretTemp = string.Empty;

                if (indexActual > 0)
                    indexActual += 1;

                for (int i = indexActual; i < lLiniiRegistru.Count; i++)
                {
                    interventie = lLiniiRegistru[i];

                    nrCrtTemp = (i + 1).ToString();
                    dataPrimireTemp = interventie.DataPrimire.ToString(CConstante.FORMAT_DATA);
                    pacientTemp = interventie.GetNumePrenumePacient();
                    lucrareTemp = interventie.DenumireLucrare;
                    nrElemTemp = Convert.ToString(interventie.NrElemente);
                    pretTemp = Convert.ToString(interventie.GetValoareMoneda(lFactura.MonedaFactura, lFactura.CursBNR));

                    hNecesar = getInaltimeNecesaraRandFactura(g, interventie, fontText, wNrCrt, wDataPrimire, wPacient, wLucrare, wNrElem, wPret, xNrCrt, xDataPrimire, xPacient, xLucrare, xNrElem, xPret, nrCrtTemp, dataPrimireTemp, pacientTemp, lucrareTemp, nrElemTemp, pretTemp);

                    if (3 * hNecesar + y > inaltime)
                    {
                        listaCompletDesenata = false;
                        morePages = true;
                        break;
                    }

                    //Desenam linia
                    deseneazaLinieFactura(g, interventie, fontText, pensulaPrescriptie, y, wNrCrt, wDataPrimire, wPacient, wLucrare, wNrElem, wPret, xNrCrt, xDataPrimire, xPacient, xLucrare, xNrElem, xPret, nrCrtTemp, dataPrimireTemp, pacientTemp, lucrareTemp, nrElemTemp, pretTemp);

                    y += hNecesar;

                    indexInterventieDesenata = i;
                }

                y += spatiuComfort / 2;

                //Am terminat interventiile pe pagina sau toate
                g.DrawLine(Pens.Black, x, y, x + latime, y);

                y += spatiuComfort / 2;

                if (listaCompletDesenata)
                    textTemp = string.Format("TOTAL: {0} (Moneda: {1} | Curs BNR: {2})", lLiniiRegistru.GetTotal(lFactura.MonedaFactura, lFactura.CursBNR), CStructuriComune.StructTipMoneda.GetStringByEnum(lFactura.MonedaFactura), lFactura.CursBNR);
                else
                    textTemp = "Se continuă pe pagina următoare ...";

                marimeNecesaraAntet = g.MeasureString(textTemp, fontText, latime);
                g.DrawString(textTemp, fontText, pensulaPrescriptie, new RectangleF(xNrCrt, y, marimeNecesaraAntet.Width, marimeNecesaraAntet.Height));

                y += Convert.ToInt32(marimeNecesaraAntet.Height / 2);

                //Am terminat interventiile pe pagina sau toate
                //g.DrawLine(Pens.Black, x, y, x + latime, y);
            }

            fontText.Dispose();
            fontText = null;
            fontIngrosat.Dispose();
            fontIngrosat = null;

            return morePages;
        }

        private static void deseneazaLinieFactura(Graphics g, BClientiComenzi interventie, Font fontText, Brush pensulaText, int yActual, int wNrCrt, int wDataPrimire, int wPacient, int wLucrare, int wNrElem, int wPret, int xNrCrt, int xDataPrimire, int xPacient, int xLucrare, int xNrElem, int xPret, string nrCrtTemp, string dataPrimireTemp, string pacientTemp, string lucrareTemp, string nrElemTemp, string pretTemp)
        {
            SizeF marimeTemp = SizeF.Empty;

            if (!string.IsNullOrEmpty(nrCrtTemp))
            {
                marimeTemp = g.MeasureString(nrCrtTemp, fontText, wNrCrt);
                CCL.UI.IHMUtile.ScrieInCentru(g, pensulaText, new RectangleF(xNrCrt, yActual, wNrCrt, marimeTemp.Height), nrCrtTemp, fontText);
            }

            if (!string.IsNullOrEmpty(dataPrimireTemp))
            {
                marimeTemp = g.MeasureString(dataPrimireTemp, fontText, wDataPrimire);
                g.DrawString(dataPrimireTemp, fontText, pensulaText, new RectangleF(xDataPrimire, yActual, wDataPrimire, marimeTemp.Height));
            }

            if (!string.IsNullOrEmpty(pacientTemp))
            {
                marimeTemp = g.MeasureString(pacientTemp, fontText, wPacient);
                g.DrawString(pacientTemp, fontText, pensulaText, new RectangleF(xPacient, yActual, wPacient, marimeTemp.Height));
                //  CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaText, new RectangleF(xPacient, yActual, wPacient, marimeTemp.Height), pacientTemp, fontText);
            }

            if (!string.IsNullOrEmpty(lucrareTemp))
            {
                marimeTemp = g.MeasureString(lucrareTemp, fontText, wLucrare);
                g.DrawString(lucrareTemp, fontText, pensulaText, new RectangleF(xLucrare, yActual, wLucrare, marimeTemp.Height));
            }

            if (!string.IsNullOrEmpty(nrElemTemp))
            {
                marimeTemp = g.MeasureString(nrElemTemp, fontText, wLucrare);
                CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaText, new RectangleF(xNrElem, yActual, wNrElem, marimeTemp.Height), nrElemTemp, fontText);
            }

            if (!string.IsNullOrEmpty(pretTemp))
            {
                marimeTemp = g.MeasureString(pretTemp, fontText, wPret);
                CCL.UI.IHMUtile.ScrieInDreapta(g, pensulaText, new RectangleF(xPret, yActual, wPret, marimeTemp.Height), pretTemp, fontText);
            }
        }

        private static int getInaltimeNecesaraRandFactura(Graphics g, BClientiComenzi interventie, Font fontText, int wNrCrt, int wDataPrimire, int wPacient, int wLucrare, int wNrElem, int wPret, int xNrCrt, int xDataPrimire, int xPacient, int xLucrare, int xNrElem, int xPret, string nrCrtTemp, string dataPrimireTemp, string pacientTemp, string lucrareTemp, string nrElemTemp, string pretTemp)
        {
            return Convert.ToInt32(Math.Ceiling(Math.Max(g.MeasureString(pacientTemp, fontText, wPacient).Height, g.MeasureString(lucrareTemp, fontText, wLucrare).Height)));
        }

        public static void Imprima(Form pEcranParinte, BClientiFacturi pFactura)
        {
            if (pFactura == null) return;

            lFactura = pFactura;
            lLocatieFiscala = BLocatii.GetLocatieCurenta();

            //Selectam imprimanta
            using (PrintDocument imprimanta = SetupThePrinting(pEcranParinte, pFactura.ToStringImprimare()))
            {
                if (imprimanta != null)
                {
                    lLiniiRegistru = pFactura.GetListaLucrari(null);

                    using (PrintPreviewDialog ppDialog = new PrintPreviewDialog())
                    {
                        ppDialog.ShowIcon = false;
                        ppDialog.Document = imprimanta;

                        CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ppDialog);
                    }
                }
            }
        }
    }
}
