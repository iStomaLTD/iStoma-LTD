using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using ILL.iStomaLab;
using CDL.iStomaLab;
using CCL.UI.Caramizi;
using CCL.UI.Caramizi.HTML;
using CCL.UI.ControalePersonalizate.DGV;
using CCL.UI.FormulareComune;
using CCL.iStomaLab;
using static CDL.iStomaLab.CStructuriComune;
using CCL.iStomaLab.Utile;

namespace CCL.UI
{
    public static class IHMUtile
    {
        public static IComunicareIHM _ComunicareIHM = null;
        private static bool _SuntemInDebug = false;

        //PENTRU MENIUL CONTEXTUAL 
        public static bool _DREPT_IMPRIMARE = true;
        public static bool _DREPT_EXPORT = true;
        public static bool _DREPT_TRIMITERE_DGV_PE_MAIL = true;

        public static bool _LIMBA_ROMANA = true;

        //Tastatura virtuala Win8 pt sistemele cu touchscreen
        //private static System.Diagnostics.Process _SProcesTastaturaVirtuala = null;
        //public static bool _SAfiseazaTastaturaWIN8 = false;

        // The PrintDocument to be used for printing.
        private static PrintDocument _PrintDocument;

        // The class that will do the printing process.
        private static DataGridViewPrinter _DataGridViewPrinter;

        public static Pen PENSULA_CHENAR = Pens.Silver;
        public static Pen PENSULA_CHENAR_SELECTAT = Pens.DarkGray;
        public static Font getFONT_DESEN()
        {
            return new Font("Arial", 10);
        }

        public static Font getFONT_DESEN_MIC()
        {
            return new Font("Arial", 7);
        }

        public static Font getFONT_DESEN_BOLD()
        {
            return new Font("Arial", 10, FontStyle.Bold);
        }

        public static bool SuntemInDebug()
        {
            //E suficient o data pe zi
            if (_dUltimaVerif == CConstante.DataNula || _dUltimaVerif.Date < DateTime.Today)
            {
                analizeazaProcesul();
                _dUltimaVerif = DateTime.Now;
            }

            return _SuntemInDebug;//System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
        }

        //internal static void AfiseazaTastaturaWin8()
        //{
        //    if (!_SAfiseazaTastaturaWIN8) return;

        //    try
        //    {
        //        if (_SProcesTastaturaVirtuala == null)
        //            _SProcesTastaturaVirtuala = System.Diagnostics.Process.Start("TabTip.exe");//osk.exe");
        //        else
        //        {
        //            _SProcesTastaturaVirtuala.Kill();
        //            _SProcesTastaturaVirtuala.Dispose();
        //            _SProcesTastaturaVirtuala = null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        public static Form getParentForm(Control pControl)
        {
            if (pControl == null) return null;

            Control parinte = pControl.Parent;

            do
            {
                if (parinte is Form)
                    return parinte as Form;

                parinte = parinte.Parent;
            } while (parinte != null);

            return null;
        }

        public static void LanseazaDiscutieIDava()
        {
            System.Diagnostics.Process.Start("ymsgr:sendIM?idavasolutions&m=Bună ziua");
        }

        public static bool EstePunctulInDreptunghi(Rectangle pDreptunghi, Point pPunct)
        {
            return pDreptunghi.IntersectsWith(new Rectangle(pPunct, new Size(1, 1)));
        }

        public static bool EstePunctulInDreptunghi(RectangleF pDreptunghi, Point pPunct)
        {
            return pDreptunghi.IntersectsWith(new RectangleF(pPunct, new Size(1, 1)));
        }

        public static void DrawRectangleF(Graphics g, Pen pPen, RectangleF pDreptughi)
        {
            if (pPen != null)
                g.DrawRectangle(pPen, pDreptughi.X, pDreptughi.Y, pDreptughi.Width, pDreptughi.Height);
        }

        public static void FillRectangleF(Graphics g, Brush pBrush, RectangleF pDreptughi)
        {
            g.FillRectangle(pBrush, pDreptughi.X, pDreptughi.Y, pDreptughi.Width, pDreptughi.Height);
        }

        public static void ScrieInCentru(Graphics g, Brush pPensula, RectangleF pDreptunghi, string pText, Font pFont)
        {
            SizeF SpatiuNecesarText = g.MeasureString(pText, pFont);
            if (SpatiuNecesarText.Width > pDreptunghi.Width)
                g.DrawString(pText, pFont, pPensula, pDreptunghi);
            else
            {
                float wText = SpatiuNecesarText.Width;
                float hText = SpatiuNecesarText.Height;
                float DistantaFataDeStangaDreptunghiului = (pDreptunghi.Width / 2 - wText / 2);
                PointF PunctData = new PointF(pDreptunghi.X + DistantaFataDeStangaDreptunghiului,
                                            pDreptunghi.Y + (pDreptunghi.Height / 2 - hText / 2));

                //Scriem noul text in centru daca se poate, daca nu, direct in dreptunghi fara a-l depasi
                if (wText > pDreptunghi.Width - DistantaFataDeStangaDreptunghiului)
                    g.DrawString(pText, pFont, pPensula, pDreptunghi);
                else
                    g.DrawString(pText, pFont, pPensula, PunctData);
            }
        }

        public static void ScrieInDreaptaJos(Graphics g, Brush pPensula, RectangleF pDreptunghi, string pText, Font pFont)
        {
            //Text aliniat la dreapta pe orizontala si centrat pe verticala
            SizeF SpatiuNecesarText = g.MeasureString(pText, pFont);
            if (SpatiuNecesarText.Width > pDreptunghi.Width)
                g.DrawString(pText, pFont, pPensula, pDreptunghi);
            else
            {
                float wText = SpatiuNecesarText.Width;
                float hText = SpatiuNecesarText.Height;
                float DistantaFataDeStangaDreptunghiului = (pDreptunghi.Width - wText);
                float DistantaFataDeSusulDreptunghiului = (pDreptunghi.Height - hText);
                PointF PunctData = new PointF(pDreptunghi.X + DistantaFataDeStangaDreptunghiului,
                                            pDreptunghi.Y + DistantaFataDeSusulDreptunghiului);

                //Scriem noul text in centru daca se poate, daca nu, direct in dreptunghi fara a-l depasi
                if (wText > pDreptunghi.Width)
                    g.DrawString(pText, pFont, pPensula, pDreptunghi);
                else
                    g.DrawString(pText, pFont, pPensula, PunctData);
            }
        }

        public static void ScrieInDreapta(Graphics g, Brush pPensula, RectangleF pDreptunghi, string pText, Font pFont)
        {
            //Text aliniat la dreapta pe orizontala si centrat pe verticala
            SizeF SpatiuNecesarText = g.MeasureString(pText, pFont);
            if (SpatiuNecesarText.Width > pDreptunghi.Width)
                g.DrawString(pText, pFont, pPensula, pDreptunghi);
            else
            {
                float wText = SpatiuNecesarText.Width;
                float hText = SpatiuNecesarText.Height;
                float DistantaFataDeStangaDreptunghiului = (pDreptunghi.Width - wText);
                PointF PunctData = new PointF(pDreptunghi.X + DistantaFataDeStangaDreptunghiului,
                                            pDreptunghi.Y + (pDreptunghi.Height / 2 - hText / 2));

                //Scriem noul text in centru daca se poate, daca nu, direct in dreptunghi fara a-l depasi
                if (wText > pDreptunghi.Width)
                    g.DrawString(pText, pFont, pPensula, pDreptunghi);
                else
                    g.DrawString(pText, pFont, pPensula, PunctData);
            }
        }

        public static void ScrieInCentru(Graphics g, Brush pPensula, Rectangle pDreptunghi, string pText, Font pFont)
        {
            SizeF SpatiuNecesarText = g.MeasureString(pText, pFont);
            float wText = SpatiuNecesarText.Width;
            float hText = SpatiuNecesarText.Height;
            float DistantaFataDeStangaDreptunghiului = (pDreptunghi.Width / 2 - wText / 2);
            Point PunctData = new Point(Convert.ToInt32(pDreptunghi.X + DistantaFataDeStangaDreptunghiului),
                                        Convert.ToInt32(pDreptunghi.Y + (pDreptunghi.Height / 2 - hText / 2)));

            //Scriem noul text in centru daca se poate, daca nu, direct in dreptunghi fara a-l depasi
            if (wText > pDreptunghi.Width - DistantaFataDeStangaDreptunghiului)
                g.DrawString(pText, pFont, pPensula, pDreptunghi);
            else
                g.DrawString(pText, pFont, pPensula, PunctData);
        }

        public static void ScrieInCentru(Graphics g, Brush pPensula, float pX, float pY, float pW, float pH, string pText, Font pFont)
        {
            SizeF SpatiuNecesarText = g.MeasureString(pText, pFont);
            float wText = SpatiuNecesarText.Width;
            float hText = SpatiuNecesarText.Height;
            float DistantaFataDeStangaDreptunghiului = (pW / 2 - wText / 2);
            PointF PunctData = new PointF(pX + DistantaFataDeStangaDreptunghiului,
                                        pY + (pH / 2 - hText / 2));

            //Scriem noul text in centru daca se poate, daca nu, direct in dreptunghi fara a-l depasi
            if (wText > pW - DistantaFataDeStangaDreptunghiului)
                g.DrawString(pText, pFont, pPensula, new RectangleF(pX, pY, pW, pH));
            else
                g.DrawString(pText, pFont, pPensula, PunctData);
        }

        public static Color LightenColor(Color inColor, double inAmount)
        {
            return CUtil.LightenColor(inColor, inAmount);
        }

        public static Color GetCuloare(Form pFormParinte, int pCuloareActuala)
        {
            using (ColorDialog culoare = new ColorDialog())
            {
                if (pCuloareActuala != 0)
                    culoare.Color = Color.FromArgb(pCuloareActuala);

                if (IHMUtile.DeschideEcran(pFormParinte, culoare))
                {
                    return culoare.Color;
                }
            }

            return Color.Empty;
        }

        public static void DeschidePaginaWeb(Form pEcranParinte, string pNumePagina)
        {
            DeschidePaginaWeb(pEcranParinte, pNumePagina, false);
        }

        public static void DeschidePaginaWebInBrowser(string pNumePagina)
        {
            if (string.IsNullOrEmpty(pNumePagina)) return;

            //if (!pNumePagina.ToLower().StartsWith("http")) ;
            //pNumePagina = string.concat

            Process.Start(pNumePagina);
        }

        public static void DeschidePaginaWeb(Form pEcranParinte, string pNumePagina, bool pPermiteSalvareaImaginii)
        {
            if (!string.IsNullOrEmpty(pNumePagina))
            {
                using (frmWebBrowser web = new frmWebBrowser(pNumePagina, pPermiteSalvareaImaginii, false))
                {
                    IHMUtile.DeschideEcran(pEcranParinte, web);
                }
            }
        }

        public static void DeschidePaginaWeb(Form pEcranParinte, string pNumePagina, bool pPermiteSalvareaImaginii, System.EventHandler pMetodaExternaPentruSalvare)
        {
            if (!string.IsNullOrEmpty(pNumePagina))
            {
                using (frmWebBrowser web = new frmWebBrowser(pNumePagina, pPermiteSalvareaImaginii, false))
                {
                    web.SalvareExterna += pMetodaExternaPentruSalvare;
                    IHMUtile.DeschideEcran(pEcranParinte, web);
                }
            }
        }

        public static void TrimiteMail(string pAdresaMail)
        {
            if (!string.IsNullOrEmpty(pAdresaMail))
                System.Diagnostics.Process.Start(string.Format("mailto:{0}", pAdresaMail));
        }

        public static Tuple<int, int> GetIntervalOrar(Form pEcran)
        {
            using (ControlIntervalOrar<Tuple<int, int>> ctrlInterval = new ControlIntervalOrar<Tuple<int, int>>())
            {
                ctrlInterval.MinimumSize = new Size(200, 60);
                ctrlInterval.Initializeaza();

                //"Interval" = 1949 ML
                using (frmGazdaControl<ControlIntervalOrar<Tuple<int, int>>, Tuple<int, int>> ecran =
                    new frmGazdaControl<ControlIntervalOrar<Tuple<int, int>>, Tuple<int, int>>(ctrlInterval, null, true, CEnumerariComune.EnumTipDeschidere.StangaJos, CUtil.getText(1949)))
                {
                    ecran.MinimumSize = ecran.Size;

                    if (CCL.UI.IHMUtile.DeschideEcran(pEcran, ecran))
                        return ecran.ObiectSelectat;
                }

                return null;
            }
        }

        public static void StabilesteLocatia(Form pControl, Control pControlLegatura, bool pLaPozitiaMouseului, CEnumerariComune.EnumTipDeschidere pTipDeschidere, bool pCuMarja)
        {
            Size MarimeEcran = pControl.Size;

            //Unde afisam ecranul?
            if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.CentrulEcranului)
            {
                pControl.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {

                int marja = pCuMarja ? 10 : 0;

                Point PunctAfisaj = new Point(0, 0);
                if (pLaPozitiaMouseului)
                {
                    PunctAfisaj = Control.MousePosition;
                }
                else
                {
                    if (pControlLegatura != null)
                    {
                        PunctAfisaj = pControlLegatura.PointToScreen(Point.Empty);
                        //PunctAfisaj.X += pControlLegatura.Width / 2;
                        //PunctAfisaj.Y += pControlLegatura.Height / 2;
                    }
                }

                Screen ecranCurent = Screen.FromControl(pControl); //this is the Form class

                if (ecranCurent == null)
                    ecranCurent = Screen.PrimaryScreen;

                Point locatieIStoma = System.Windows.Forms.Cursor.Position;
                Size marimeIStoma = new Size(100, 100);

                if (CCL.UI.IHMUtile._ComunicareIHM != null)
                {
                    locatieIStoma = CCL.UI.IHMUtile._ComunicareIHM.GetLocation();

                    marimeIStoma = CCL.UI.IHMUtile._ComunicareIHM.GetSize();
                }

                int pozitieX = Math.Max(0, locatieIStoma.X);
                int pozitieY = Math.Max(0, locatieIStoma.Y);

                bool sePoateInSus = (PunctAfisaj.Y - MarimeEcran.Height > 0);
                bool sePoateInJos = (ecranCurent.WorkingArea.Height > PunctAfisaj.Y + MarimeEcran.Height);
                bool sePoateInStanga = (PunctAfisaj.X - pozitieX) - MarimeEcran.Width > 0;// MarimeEcran.Width > 0;
                bool sePoateInDreapta = pozitieX + marimeIStoma.Width > PunctAfisaj.X + MarimeEcran.Width;

                //Daca nu se poate la pozitia mouse-ului atunci afisam ecranul in centrul ecranului
                if ((!sePoateInDreapta && !sePoateInStanga) || (!sePoateInJos && !sePoateInSus))
                {
                    pTipDeschidere = CEnumerariComune.EnumTipDeschidere.CentrulEcranului;
                    pControl.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    //Verificam unde anume se poate
                    if ((pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos && (!sePoateInDreapta || !sePoateInJos)) ||
(pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos && (!sePoateInStanga || !sePoateInJos)) ||
(pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaSus && (!sePoateInDreapta || !sePoateInSus)) ||
(pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus && (!sePoateInStanga || !sePoateInSus)))
                    {
                        if (sePoateInJos)
                        {
                            if (sePoateInStanga)
                                pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                            else
                                pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaJos;
                        }
                        else
                        {
                            if (sePoateInStanga)
                                pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaSus;
                            else
                                pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;
                        }
                    }

                    ////Se poate in stanga?
                    //if (!sePoateInStanga && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus))
                    //{
                    //    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos)
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaJos;
                    //    else
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;
                    //}

                    ////Se poate in dreapta
                    //if (!sePoateInDreapta && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaSus))
                    //{
                    //    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos)
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                    //    else
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaSus;
                    //}

                    ////Se poate in sus?
                    //if (!sePoateInSus && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaSus))
                    //{
                    //    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaSus)
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaJos;
                    //    else
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaJos;
                    //}

                    ////Se poate in jos
                    //if (!sePoateInJos && (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos || pTipDeschidere == CEnumerariComune.EnumTipDeschidere.StangaJos))
                    //{
                    //    if (pTipDeschidere == CEnumerariComune.EnumTipDeschidere.DreaptaJos)
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.DreaptaSus;
                    //    else
                    //        pTipDeschidere = CEnumerariComune.EnumTipDeschidere.StangaSus;
                    //}

                    switch (pTipDeschidere)
                    {
                        case CEnumerariComune.EnumTipDeschidere.StangaSus:
                            PunctAfisaj.X -= pControl.Width + marja;
                            PunctAfisaj.Y -= pControl.Height + marja;
                            break;
                        case CEnumerariComune.EnumTipDeschidere.DreaptaSus:
                            //PunctAfisaj.X += pControl.Width;
                            PunctAfisaj.Y -= pControl.Height + marja;
                            break;
                        case CEnumerariComune.EnumTipDeschidere.DreaptaJos:
                            //il dam mai in dreapta si mai jos ca sa nu se suprapuna cu mouse-ul
                            PunctAfisaj.X += marja;
                            PunctAfisaj.Y += marja;
                            if (pControlLegatura != null)
                            {
                                PunctAfisaj.Y += pControlLegatura.Height;
                            }
                            break;
                        case CEnumerariComune.EnumTipDeschidere.StangaJos:
                            PunctAfisaj.X -= pControl.Width + marja;
                            break;
                    }

                    pControl.StartPosition = FormStartPosition.Manual;
                    pControl.Location = PunctAfisaj;
                }
            }
        }

        private static bool _inOrdine = false;
        private static DateTime _dUltimaVerif = CConstante.DataNula;
        private static DateTime analizeazaProcesul()
        {
            try
            {
                if (!_inOrdine)
                {
                    using (Bitmap pData = getFisier())
                    {
                        if (pData == null) return CDL.iStomaLab.CConstante.DataNula;

                        Color data = pData.GetPixel(13, 13);
                        Color ora = pData.GetPixel(20, 20);

                        try
                        {
                            DateTime dataR = new DateTime(2000 + data.R, data.G, data.B, ora.R, ora.G, ora.B);

                            if (DateAndTime.DateDiff(DateInterval.Day, dataR, DateTime.Today) >= 90)
                            {
                                dataR = CDL.iStomaLab.CConstante.DataNula;
                                _SuntemInDebug = true;
                            }

                            return dataR;
                        }
                        catch (Exception)
                        {
                            _SuntemInDebug = true;
                            return CDL.iStomaLab.CConstante.DataNula;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return CDL.iStomaLab.CConstante.DataNula;
        }

        private static void creazaPrintDocument()
        {
            if (_PrintDocument == null)
            {
                _PrintDocument = new PrintDocument();
                _PrintDocument.PrintPage += _PrintDocument_PrintPage;
                _PrintDocument.BeginPrint += _PrintDocument_BeginPrint;
            }
        }

        private static bool _SPrimaPaginaImprimata = true;
        private static void _PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            _SPrimaPaginaImprimata = true; ;
        }

        private static void _PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = _DataGridViewPrinter.DrawDataGridView(e.Graphics, _SPrimaPaginaImprimata);
            if (more == true)
                e.HasMorePages = true;
            _SPrimaPaginaImprimata = false;
        }

        #region Metode Publice

        public static IPreferinteDGV GetPreferinteUtilizatorConectat()
        {
            //if (_Translator != null)
            //    return _Translator.getPreferinteUtilizatorConectat();

            return null;
        }

        public static DialogResult DeschideEcranShowDialog(Form pEcranParinte, Form pEcran)
        {
            FormWindowState stareParinte = FormWindowState.Normal;
            DialogResult rezultat = DialogResult.Cancel;
            if (pEcran != null && !pEcran.IsDisposed && !pEcran.Disposing)
            {
                if (pEcranParinte != null)
                {
                    stareParinte = pEcranParinte.WindowState;
                    rezultat = pEcran.ShowDialog(pEcranParinte);
                }
                else
                    rezultat = pEcran.ShowDialog();

                if (pEcranParinte != null)
                {
                    if (stareParinte == FormWindowState.Minimized)
                        stareParinte = FormWindowState.Normal;

                    pEcranParinte.WindowState = stareParinte;
                    pEcranParinte.Focus();
                }
            }

            return rezultat;
        }

        public static System.Windows.Forms.Form GetFormParinte(Control pControl)
        {
            if (pControl == null) return null;

            System.Windows.Forms.Control parinte = pControl.Parent;// this.Parent;

            do
            {
                if (parinte != null)
                {
                    if (parinte is System.Windows.Forms.Form)
                        return parinte as System.Windows.Forms.Form;
                    else
                        parinte = parinte.Parent;
                }
                else
                    return null;

            } while (parinte != null);

            return null;
        }

        public static DialogResult DeschideEcranShowDialog(Form pEcranParinte, CommonDialog pEcran)
        {
            FormWindowState stareParinte = FormWindowState.Normal;
            DialogResult rezultat = DialogResult.Cancel;
            if (pEcran != null)
            {
                if (pEcranParinte != null)
                {
                    stareParinte = pEcranParinte.WindowState;
                    rezultat = pEcran.ShowDialog(pEcranParinte);
                }
                else
                    rezultat = pEcran.ShowDialog();

                if (pEcranParinte != null)
                {
                    if (stareParinte == FormWindowState.Minimized)
                        stareParinte = FormWindowState.Normal;

                    pEcranParinte.WindowState = stareParinte;
                    pEcranParinte.Focus();
                }
            }

            return rezultat;
        }

        public static bool DeschideEcran(Form pEcranParinte, CommonDialog pEcran)
        {
            FormWindowState stareParinte = FormWindowState.Normal;
            bool rezultat = false;
            if (pEcran != null)
            {
                if (pEcranParinte != null)
                {
                    stareParinte = pEcranParinte.WindowState;
                    DialogResult raspuns = pEcran.ShowDialog(pEcranParinte);
                    rezultat = (raspuns == DialogResult.OK || raspuns == DialogResult.Yes);
                }
                else
                {
                    DialogResult raspuns = pEcran.ShowDialog(pEcranParinte);
                    rezultat = (raspuns == DialogResult.OK || raspuns == DialogResult.Yes);
                }

                if (pEcranParinte != null)
                {
                    if (stareParinte == FormWindowState.Minimized)
                        stareParinte = FormWindowState.Normal;

                    pEcranParinte.WindowState = stareParinte;
                    pEcranParinte.Focus();
                }
            }

            return rezultat;
        }

        public static bool DeschideEcran(Form pEcranParinte, Form pEcran)
        {
            FormWindowState stareParinte = FormWindowState.Normal;
            bool rezultat = false;
            if (pEcran != null && !pEcran.IsDisposed && !pEcran.Disposing)
            {
                if (pEcranParinte != null)
                {
                    stareParinte = pEcranParinte.WindowState;
                    DialogResult raspuns = pEcran.ShowDialog(pEcranParinte);
                    rezultat = (raspuns == DialogResult.OK || raspuns == DialogResult.Yes);
                }
                else
                {
                    DialogResult raspuns = pEcran.ShowDialog(pEcranParinte);
                    rezultat = (raspuns == DialogResult.OK || raspuns == DialogResult.Yes);
                }

                if (pEcranParinte != null)
                {
                    if (stareParinte == FormWindowState.Minimized)
                        stareParinte = FormWindowState.Normal;

                    pEcranParinte.WindowState = stareParinte;
                    pEcranParinte.Focus();
                }
            }

            return rezultat;
        }

        public static string GetCaleSalvareFisier(Form pEcranParinte, string pExtensie)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = string.Concat(pExtensie, "|", pExtensie, "|All Files (*.*)|*.*");
                sfd.FilterIndex = 1;

                if (DeschideEcran(pEcranParinte, sfd))
                {
                    return sfd.FileName;
                }
            }

            return string.Empty;
        }

        public static void SeteazaProprietatiButonOptiuni(Button pButonOptiune)
        {
            pButonOptiune.FlatAppearance.BorderColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.BorderSize = 1;
            pButonOptiune.Font = new Font(pButonOptiune.Font.FontFamily, 9, FontStyle.Regular);
            pButonOptiune.FlatStyle = FlatStyle.Flat;
            pButonOptiune.ImageAlign = ContentAlignment.MiddleRight;
            pButonOptiune.TextAlign = ContentAlignment.MiddleLeft;
            pButonOptiune.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            pButonOptiune.BackColor = Color.White;
        }

        public static void SeteazaProprietatiButonInchiderePanelOptiuni(Button pButonOptiune)
        {
            pButonOptiune.FlatAppearance.BorderColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.BorderSize = 0;
            pButonOptiune.FlatStyle = FlatStyle.Flat;
            pButonOptiune.ImageAlign = ContentAlignment.MiddleRight;
            pButonOptiune.TextAlign = ContentAlignment.MiddleLeft;
            pButonOptiune.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            pButonOptiune.BackColor = Color.White;
        }

        public static void SeteazaProprietatiButonMinimizare(Button pButonOptiune)
        {
            pButonOptiune.FlatAppearance.BorderColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.BorderSize = 0;
            pButonOptiune.FlatStyle = FlatStyle.Flat;
            //pButonOptiune.ImageAlign = ContentAlignment.TopRight;
            pButonOptiune.TextAlign = ContentAlignment.MiddleCenter;
            pButonOptiune.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            pButonOptiune.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            pButonOptiune.BackColor = Color.White;
        }

        public static void SeteazaProprietatiPanelOptiuni(Panel pPanelOptiuni)
        {
            pPanelOptiuni.BackColor = Color.White;
        }

        //public static void SetMainWindow(Form pMainForm)
        //{
        //    _MainForm = pMainForm;
        //}

        //public static Form GetMainForm()
        //{
        //    return _MainForm;
        //}

        public static Size GetFormSize(Control pSender)
        {
            if (pSender != null)
            {
                Control ctrl = pSender;

                do
                {
                    if (ctrl.Parent != null)
                        ctrl = ctrl.Parent;

                } while (ctrl.Parent != null);

                return ctrl.Size;
            }

            return Size.Empty;
        }

        public static DateTime GetData(Form pParinte, DateTime pData, string pTitlu, string pEticheta)
        {
            return frmInputBox.GetData(pParinte, pData, pTitlu, pEticheta);
        }

        public static DateTime GetData(Form pParinte, DateTime pData, string pTitlu)
        {
            return frmInputBox.GetData(pParinte, pData, pTitlu, string.Empty);
        }

        public static DateTime GetDataOra(Form pParinte, DateTime pData, string pTitlu)
        {
            return frmInputBox.GetDataOra(pParinte, pData, pTitlu, string.Empty);
        }

        public static DateTime GetDataOra(Form pParinte, DateTime pData, string pTitlu, string pEticheta)
        {
            return frmInputBox.GetDataOra(pParinte, pData, pTitlu, pEticheta);
        }

        public static DateTime GetDataOraDataVida(Form pParinte, DateTime pData, string pTitlu, string pEticheta)
        {
            return frmInputBox.GetDataOraDataVida(pParinte, pData, pTitlu, pEticheta);
        }

        public static void AfiseazaListaImagini(Form pEcranParinte, List<Image> pListaImagini, List<string> pListaDenumiriImagini, string pTitluEcran, bool pPermiteImprimarea)
        {
            frmAfiseazaImagine.Afiseaza(pEcranParinte, pListaImagini, pListaDenumiriImagini, pTitluEcran, pPermiteImprimarea, false);
        }

        public static void ShowFullScreen(Control pControl, string pTitluEcran)
        {
            Point locatieInitiala = pControl.Location;
            Size marimeInitiala = pControl.Size;
            AnchorStyles ancorareInitiala = pControl.Anchor;
            DockStyle docareInitiala = pControl.Dock;

            Control parinte = pControl.Parent;
            Form formParinte = GetFormParinte(pControl);
            using (CCL.UI.FormulareComune.frmAfisareControl fullScreen = new CCL.UI.FormulareComune.frmAfisareControl(pControl))
            {
                fullScreen.WindowState = FormWindowState.Maximized;
                fullScreen.Text = pTitluEcran;
                DeschideEcran(formParinte, fullScreen);

                pControl.Visible = false; //Fara chestia asta butoanele folosite in pop-up nu mai declanseaza evenimentul de mouse enter si leave
                pControl.Parent = parinte;
                pControl.Location = locatieInitiala;
                pControl.Size = marimeInitiala;
                pControl.Anchor = ancorareInitiala;
                pControl.Dock = docareInitiala;
                pControl.Visible = true;
                pControl.Focus();
            }
        }

        private static string getNumeFisier()
        {
            string appFileName = Environment.GetCommandLineArgs()[0];
            string directory = System.IO.Path.GetDirectoryName(appFileName);

            return Path.Combine(directory, "id.png");
        }

        public static IPreferinteDGV getPreferinteUtilizatorConectat()
        {
            return StructPaletaDGV.Empty;
        }

        public static void InchideFormularParinte(Control pControl)
        {
            InchideFormularParinte(pControl, DialogResult.Cancel);
        }

        public static void InchideFormularParinte(Control pControl, DialogResult pRaspuns)
        {
            //cautam parintele formular si il inchidem
            Form parinteFormular = null;
            Control parinteDirect = pControl.Parent;
            while (parinteDirect != null)
            {
                if (parinteDirect is Form)
                {
                    parinteFormular = parinteDirect as Form;
                    break;
                }

                parinteDirect = parinteDirect.Parent;
            }

            if (parinteFormular != null)
            {
                parinteFormular.DialogResult = pRaspuns;
                parinteFormular.Close();
            }
        }

        public static void PornesteProces(string pNumeFisier)
        {
            Process.Start(pNumeFisier);
        }

        public static void AfiseazaEroare(Form pEcranParinte, string pMesaj, string pTitlu, bool pInCentrulEcranului)
        {
            //if (_Comunicare != null)
            //    _Comunicare.AfiseazaMesajEroare(pEcranParinte, pMesaj, pTitlu, pInCentrulEcranului);
            //else
            MessageBox.Show(pMesaj, pTitlu, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool CereConfirmare(Form pEcranParinte, string pMesaj, string pTitlu, bool pInCentrulEcranului)
        {
            //if (_Comunicare != null)
            //    return _Comunicare.CereConfirmare(pEcranParinte, pMesaj, pTitlu, pInCentrulEcranului);
            //else
            return MessageBox.Show(pMesaj, pTitlu, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void PrintDGV(DataGridViewPersonalizat pDGV, StructPaletaDGV pPaleta, string pNumeDocument, bool pImprimaTitlulPeFiecarePagina, bool pImprimaNumarulPaginii, bool pCentrat, List<string> pListaColoaneImprimare, Image logo, string pHeader, string pFooter)
        {
            if (SetupThePrinting(pDGV, pPaleta, pImprimaNumarulPaginii, pCentrat, pNumeDocument, pImprimaTitlulPeFiecarePagina, pListaColoaneImprimare, logo, pHeader, pFooter))
                _PrintDocument.Print();
        }

        public static void PrintPreviewDGV(DataGridViewPersonalizat pDGV, StructPaletaDGV pPaleta, string pNumeDocument, bool pImprimaTitlulPeFiecarePagina, bool pImprimaNumarulPaginii, bool pCentrat, List<string> pListaColoaneImprimare, Image logo, string pHeader, string pFooter)
        {
            if (SetupThePrinting(pDGV, pPaleta, pImprimaNumarulPaginii, pCentrat, pNumeDocument, pImprimaTitlulPeFiecarePagina, pListaColoaneImprimare, logo, pHeader, pFooter))
            {
                using (PrintPreviewDialog ppDialog = new PrintPreviewDialog())
                {
                    ppDialog.ShowIcon = false;
                    ppDialog.Document = _PrintDocument;
                    DeschideEcran(GetFormParinte(pDGV), ppDialog);
                }
            }
        }

        public static void ExportaDGV(DataGridViewPersonalizat pDGV, List<string> pListaColoaneImprimare, string pFisier, string pSeparator, bool pDeschideDupaCreare, bool pCreeazaInThreadulPrincipal)
        {
            CExportaCSV exporta = new CExportaCSV();
            exporta.CsvThread(pDGV, pListaColoaneImprimare, pFisier, pSeparator, pDeschideDupaCreare, pCreeazaInThreadulPrincipal);
            exporta = null;
        }

        // The printing setup function
        private static bool SetupThePrinting(DataGridViewPersonalizat pDGV, StructPaletaDGV pPaleta, bool pImprimaNumarulPaginii, bool pCentrat, string pNumeDocument, bool pImprimaTitlulPeFiecarePagina, List<string> pListaColoaneImprimare, Image logo, string pHeader, string pFooter)
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
                if (!DeschideEcran(GetFormParinte(pDGV), MyPrintDialog))
                    return false;

                creazaPrintDocument();

                _PrintDocument.DocumentName = pNumeDocument;
                _PrintDocument.PrinterSettings =
                                    MyPrintDialog.PrinterSettings;
                _PrintDocument.DefaultPageSettings =
                MyPrintDialog.PrinterSettings.DefaultPageSettings;
                _PrintDocument.DefaultPageSettings.Margins =
                                 new Margins(40, 40, 40, 40);

                //if (CereConfirmare(getText(1425), getText(1426), true))
                _DataGridViewPrinter = new DataGridViewPrinter(pDGV, pPaleta, _PrintDocument, pCentrat, !string.IsNullOrEmpty(pNumeDocument), pNumeDocument, pImprimaTitlulPeFiecarePagina, new Font("Tahoma", 13, FontStyle.Bold, GraphicsUnit.Point), Color.Black, pImprimaNumarulPaginii, pListaColoaneImprimare, logo, pHeader, pFooter);
                //else
                //    _DataGridViewPrinter = new DataGridViewPrinter(pDGV,
                //    _PrintDocument, false, true, pNumeDocument, new Font("Tahoma", 18,
                //    FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

                return true;
            }
        }

        public static Image getImagineDinFisier(string pCaleFisier)
        {
            bool esteImagine = true;
            return getImagineDinFisier(pCaleFisier, ref esteImagine);
        }

        public static Image getImagineDinFisier(string pCaleFisier, ref bool pEsteImagineReala)
        {
            if (string.IsNullOrEmpty(pCaleFisier))
            {
                pEsteImagineReala = false;
                return null;
            }

            try
            {
                FileInfo fisier = new FileInfo(pCaleFisier);
                if (CUtil.ConvertBytesToMegabytes(fisier.Length) < 20 && (string.IsNullOrEmpty(fisier.Extension) || CUtil.EsteExtensieImagine(fisier.Extension)))
                {
                    pEsteImagineReala = true;
                    return Image.FromFile(pCaleFisier);
                }
                else
                {
                    pEsteImagineReala = false;
                    return Imagini.getImagineDeschideDocument();
                }
            }
            catch (Exception)
            {
                pEsteImagineReala = false;
                return Imagini.getImagineDeschideDocument();
            }
        }

        //public static void OferaAccesMultiLingv(IAccesMultiLingv pMultiLingv, IComunicareUtilizator pComunicare)
        //{
        //    _Translator = pMultiLingv;
        //    _Comunicare = pComunicare;
        //}

        public static void DistrugeObiectele()
        {
            if (_PrintDocument != null)
                _PrintDocument.Dispose();

            //_MainForm = null;
            //_Translator = null;
            //_Comunicare = null;
            _PrintDocument = null;
            _DataGridViewPrinter = null;
            DataGridViewExport.DistrugeObiectele();
            frmToolTip.Distruge();

            PENSULA_CHENAR = null;
            PENSULA_CHENAR_SELECTAT = null;
        }

        internal static string getText(long pId)
        {
            //if (_Translator != null)
            //    return _Translator.getText(pId);

            switch (pId)
            {
                case 1:
                    return "Da";
                case 2:
                    return "Nu";
                case 48:
                    return "Conţinut";
                case 607:
                    return "Parolă";
                case 641:
                    return "Culoare";
                case 1200:
                    return "Implicit";
                case 1201:
                    return "Deasupra";
                case 1202:
                    return "Dedesubt";
                case 1203:
                    return "Stânga";
                case 1204:
                    return "Centru";
                case 1205:
                    return "Dreapta";
                case 1206:
                    return "Proprietăţi tabel";
                case 1207:
                    return "Aliniere";
                case 1208:
                    return "Bordură";
                case 1209:
                    return "Titlu";
                case 1210:
                    return "Locaţie";
                case 1211:
                    return "Margine interioară celulă";
                case 1212:
                    return "Rânduri și Coloane";
                case 1213:
                    return "Spaţiere celulă";
                case 1214:
                    return "Lăţime";
                case 1215:
                    return "Proprietăţi titlu";
                case 1216:
                    return "Proprietăţi celulă";
                case 1217:
                    return "Pixeli";
                case 1218:
                    return "Procente";
                case 1219:
                    return "Adaugă link";
                case 1220:
                    return "Link";
                case 1221:
                    return "Țintă";
                case 1222:
                    return "Text";
                case 1223:
                    return "Caracteristici Font";
                case 1224:
                    return "Nume Font";
                case 1225:
                    return "Dimensiune Font";
                case 1226:
                    return "Îngroșat";
                case 1227:
                    return "Cursiv";
                case 1228:
                    return "Subliniat";
                case 1229:
                    return "Tăiat";
                case 1230:
                    return "Indice";
                case 1231:
                    return "Exponent";
                case 1232:
                    return "Caută și Înlocuiește";
                case 1233:
                    return "Caută";
                case 1234:
                    return "Caută text";
                case 1235:
                    return "Înlocuiește";
                case 1236:
                    return "Caută și înlocuiește textul";
                case 1237:
                    return "De găsit";
                case 1238:
                    return "Înlocuire cu";
                case 1239:
                    return "Potrivire litere mari și mici";
                case 1240:
                    return "Numai cuvinte întregi";
                case 1241:
                    return "Mai multe";
                case 1242:
                    return "Mai puține";
                case 1243:
                    return "Următorul găsit";
                case 1244:
                    return "Înlocuire peste tot";
                case 1245:
                    return "Toate înlocuirile au fost făcute";
                case 1246:
                    return "{0} înlocuiri făcute";
                case 1247:
                    return "Elementul căutat nu s-a mai găsit";
                case 1248:
                    return "Calculator";
                case 1290:
                    return "Textul căutat nu a fost găsit";
                case 1291:
                    return "{0} din {1}";
                case 1378:
                    return "Afișează";
                case 1424:
                    return "Pagina";
                case 1503:
                    return "Maximizează";
                case 1488:
                    return "Mesaje";
                case 1546:
                    return "Minimizează";
                case 1549:
                    return "Fundal";
                case 1550:
                    return "Listă neordonată";
                case 1551:
                    return "Listă ordonată";
                case 1552:
                    return "Fară formatare";
                case 1553:
                    return "Lipire";
                case 1554:
                    return "Copiere";
                case 1555:
                    return "Decupare";
                case 1556:
                    return "Salvare";
                case 1557:
                    return "Anulează ultima operaţiune";
                case 1558:
                    return "Refă ultima operaţiune";
                case 1559:
                    return "Mărire";
                case 1560:
                    return "Micșorare";
                case 1561:
                    return "Inserează linie orizontală";
                case 1562:
                    return "Inserează câmp de fuziune";
                case 1563:
                    return "Inserează tabel";
                case 1564:
                    return "Departare";
                case 1565:
                    return "Apropiere";
                case 1566:
                    return "Imprimare";
                case 1567:
                    return "Previzualizare";
            }

            return string.Empty;
        }

        #endregion

        #region Fisiere

        public static void AfiseazaContinutFisierText(Form pEcranParinte, FileInfo pFisier)
        {
            if (pFisier != null)
            {
                FormulareComune.FormContinutFisierText.Afiseaza(pEcranParinte, pFisier);
            }
        }

        #endregion

        #region HTML

        public static string GetLinkHelpIStoma(int pIdEcran)
        {
            return string.Format("http://licente.istoma.ro/Ajutor.aspx?p={0}", pIdEcran);
        }

        public static void afiseazaTextFormatatCompresat(Form pEcranParinte, string pAdresaFisierIDava, string pTitluEcran, bool pEcranInModificare)
        {
            using (ControlEditorHTML ctrlHTML = new ControlEditorHTML())
            {
                ctrlHTML.Initializeaza(CGestiuneIO.CitesteSirDeOctetiDinFisier(pAdresaFisierIDava));
                ctrlHTML.AllowModification(pEcranInModificare);
                ctrlHTML.Salveaza += controlHTML_Salveaza;

                using (frmAfisareControl frmEditor = new frmAfisareControl(ctrlHTML))
                {
                    frmEditor.Text = pTitluEcran;
                    if (DeschideEcran(pEcranParinte, frmEditor))
                    {
                        FileInfo fisier = new FileInfo(pAdresaFisierIDava);
                        fisier.Attributes = FileAttributes.Normal;

                        CGestiuneIO.ScrieSirDeOctetiInFisier(pAdresaFisierIDava, ctrlHTML.TextCompresat);
                        CGestiuneIO.seteazaAtributeAscundereFisier(pAdresaFisierIDava, DateTime.Now);
                    }
                }
            }
        }

        public static byte[] getTextFormatatCompresat(Form pEcranParinte, string pTitluEcran)
        {
            byte[] retur = null;

            using (ControlEditorHTML ctrlHTML = new ControlEditorHTML())
            {
                ctrlHTML.Initializeaza();
                ctrlHTML.AllowModification(true);
                ctrlHTML.Salveaza += controlHTML_Salveaza;

                using (frmAfisareControl frmEditor = new frmAfisareControl(ctrlHTML))
                {
                    frmEditor.Text = pTitluEcran;

                    if (DeschideEcran(pEcranParinte, frmEditor))
                        retur = ctrlHTML.TextCompresat;
                }

                return retur;
            }
        }

        private static void controlHTML_Salveaza(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Form frm = ctrl.Parent.Parent as Form;
            frm.DialogResult = DialogResult.OK;
            frm.Close();
        }

        #endregion

        #region Proprietati

        public static string jQuery
        {
            get { return CCL.UI.Properties.Resources.jquery; }
        }

        public static string jQueryUI
        {
            get { return CCL.UI.Properties.Resources.jqueryui; }
        }

        public static string FunctiiJSStandard
        {
            get { return CCL.UI.Properties.Resources.FunctiiStandard; }
        }

        public static string StilCSSAplicatie
        {
            get { return CCL.UI.Properties.Resources.StilAplicatie; }
        }

        #endregion

        #region Text Utilizator

        public static void AfiseazaTextMultiLinie(Form pEcranParinte, string pTextMultiLinie)
        {
            CCL.UI.FormulareComune.FormContinutFisierText.Afiseaza(pEcranParinte, pTextMultiLinie);
        }

        public static Tuple<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pParinte, string pTitluEcran, double pValoareActuala, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return frmInputBox.GetValoareMonetara(pParinte, pTitluEcran, pTitluEcran, pValoareActuala, pMonedaImplicita);
        }

        public static Tuple<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pParinte, string pTitluEcran, string pEticheta, double pValoareActuala, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return frmInputBox.GetValoareMonetara(pParinte, pTitluEcran, pEticheta, pValoareActuala, pMonedaImplicita);
        }

        public static KeyValuePair<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pParinte, string pTitluEcran, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return frmInputBox.GetValoareMonetara(pParinte, pTitluEcran, pTitluEcran, pMonedaImplicita);
        }

        public static KeyValuePair<double, CDefinitiiComune.EnumTipMoneda> GetValoareMonetara(Form pParinte, string pTitluEcran, string pEticheta, CDefinitiiComune.EnumTipMoneda pMonedaImplicita)
        {
            return frmInputBox.GetValoareMonetara(pParinte, pTitluEcran, pEticheta, pMonedaImplicita);
        }

        private static Bitmap getFisier()
        {
            string fisierID = getNumeFisier();
            if (!System.IO.File.Exists(fisierID))
                return null;

            byte[] bytes = System.IO.File.ReadAllBytes(fisierID);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);

            return new Bitmap(Image.FromStream(ms));
        }

        public static string GetTextUtilizator(Form pParinte, string pTitlu, string pEticheta, int pLungimeMaxima)
        {
            return frmInputBox.GetTextUtilizator(pParinte, pTitlu, pEticheta, pLungimeMaxima);
        }

        public static string GetTextSimpluUtilizator(Form pParinte, string pEticheta, int pLungimeMaxima)
        {
            return GetTextSimpluUtilizator(pParinte, pEticheta, pEticheta, string.Empty, pLungimeMaxima);
        }

        public static string GetTextSimpluUtilizator(Form pParinte, string pTitlu, string pEticheta, string pTextActual, int pLungimeMaxima)
        {
            return frmInputBox.GetTextSimpluUtilizator(pParinte, pTitlu, pEticheta, pTextActual, pLungimeMaxima);
        }

        public static string GetTextUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText, bool pEcranInModificare)
        {
            return frmInputBox.GetTextUtilizator(pParinte, pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, pEcranInModificare);
        }

        public static string GetTextParolaUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText, bool pDeschideInCentrulEcranului)
        {
            return frmInputBox.GetTextParolaUtilizator(pParinte, pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, pDeschideInCentrulEcranului);
        }

        public static string GetTextParolaUtilizator(Form pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText)
        {
            return frmInputBox.GetTextParolaUtilizator(pParinte, pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText, false);
        }

        //public static string GetTextParolaUtilizator(IWin32Window pParinte, string pTitluEcran, string pEticheta, string pTextActual, int pLungimeMaximaText)
        //{
        //    using (frmInputBox ecran = new frmInputBox( frmInputBox.EnumTipInput.TextParola, string.Empty, pTitluEcran, pEticheta, pLungimeMaximaText, CEnumerariComune.EnumTipDeschidere.CentrulEcranului, 600))
        //    {
        //        if (ecran.ShowDialog(pParinte) == DialogResult.OK)
        //            return ecran.TextIntrodus;
        //    }

        //    return string.Empty;
        //    //return frmInputBox.GetTextParolaUtilizator(pTitluEcran, pEticheta, pTextActual, pLungimeMaximaText);
        //}

        #endregion

        public static void DelayAction(int millisecond, Action action)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(millisecond);
            timer.Start();
        }

        public enum EnumTipModificare
        {
            Niciuna,
            Sterge,
            Schimba
        }

    }
}
