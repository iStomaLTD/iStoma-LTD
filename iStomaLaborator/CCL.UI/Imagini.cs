using System;
using System.Drawing;
using System.Windows.Forms;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI
{

    public static class Imagini
    {
        private static System.Drawing.Icon _SIconita = null;
        private static System.Drawing.Image _SLogoAplicatie = null;
        private static System.Drawing.Image _SLogoTextAplicatie = null;
        private static string _SDenumireAplicatie = "iStoma";
        private static string _SWebSiteAplicatie = "www.iStomaLTD.ro";
        private static System.Drawing.Color _SCuloareAplicatie = System.Drawing.Color.Green;

        public static Icon GetIconAplicatie()
        {
            return Properties.Resources.iStoma;
        }

        public static Image GetLogoAplicatie()
        {
            return Properties.Resources.LogoIStomaMar256;
        }

        public static Image GetLogoTextAplicatie()
        {
            return Properties.Resources.LogoIStomaMar256;
        }

        public static string GetDenumireAplicatie()
        {
            return _SDenumireAplicatie;
        }

        public static string GetWebSiteAplicatie()
        {
            return _SWebSiteAplicatie;
        }

        public static Color GetCuloareAplicatie()
        {
            return _SCuloareAplicatie;
        }

        public static void SetIdentitateAplicatie(Icon pIconita, Image pLogoAplicatie, Image pLogoTextAplicatie, string pDenumireAplicatie, string pWebSiteAplicatie, bool pEsteICLINIC, System.Drawing.Color pCuloareAplicatie, int pTipAplicatie)
        {
            _SIconita = pIconita;
            _SLogoAplicatie = pLogoAplicatie;
            _SLogoTextAplicatie = pLogoTextAplicatie;
            _SDenumireAplicatie = pDenumireAplicatie;
            _SWebSiteAplicatie = pWebSiteAplicatie;
            _SCuloareAplicatie = pCuloareAplicatie;

            CCL.iStomaLab.Utile.CGestiuneIO.SetTipAplicatieInRegistri(pTipAplicatie);
        }

        public static bool EsteCuloareInchisa(Color pCuloareTest)
        {
            return CUtil.EsteCuloareInchisa(pCuloareTest);
            //return Brightness(pCuloareTest) < 130;
            //return (384 - pCuloareTest.R - pCuloareTest.G - pCuloareTest.B) > 0;
        }

        public static Color GetCuloareText(Color pCuloareFundal)
        {
            if (EsteCuloareInchisa(pCuloareFundal))
                return Color.White;
            else
                return Color.Black;
        }

        //private static int Brightness(Color c)
        //{
        //    return (int)Math.Sqrt(
        //       c.R * c.R * .241 +
        //       c.G * c.G * .691 +
        //       c.B * c.B * .068);
        //}

        public static bool EsteSpreRosu(Color pCuloareTest)
        {
            return pCuloareTest.R > pCuloareTest.G + pCuloareTest.B;
        }

        public static Bitmap getBitmap(int pLatime, int pInaltime)
        {
            try
            {
                return new Bitmap(pLatime, pInaltime, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            }
            catch (Exception)
            {
                return new Bitmap(pLatime, pInaltime);
            }
        }

        public static Image GetThumbnailImage(Bitmap pImaginePrincipala, int pLatime, int pInaltime)
        {
            return GetThumbnailImage(pImaginePrincipala, pLatime, pInaltime, false);
        }

        public static Image GetThumbnailImage(Bitmap pImaginePrincipala, int pLatime, int pInaltime, bool pPastreazaRaportWH)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image imagineRetur = null;

            if (pImaginePrincipala != null)
            {
                if (pPastreazaRaportWH)
                {
                    if (pImaginePrincipala.Width >= pImaginePrincipala.Height)
                    {
                        //Este o imagine orizontala/patratoasa  
                        pInaltime = Convert.ToInt32(Convert.ToDecimal(pLatime) * (Convert.ToDecimal(pImaginePrincipala.Height) / Convert.ToDecimal(pImaginePrincipala.Width)));
                    }
                    else
                    {
                        //Este o imagine verticala
                        pLatime = Convert.ToInt32(Convert.ToDecimal(pInaltime) * (Convert.ToDecimal(pImaginePrincipala.Width) / Convert.ToDecimal(pImaginePrincipala.Height)));
                    }
                }

                //imagineRetur = new Bitmap(pLatime, pInaltime);
                //imagineRetur.SetResolution(pImaginePrincipala.HorizontalResolution, pImaginePrincipala.VerticalResolution);
                //using (Graphics gr = Graphics.FromImage(imagineRetur))
                //{
                //    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //    gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //    gr.DrawImage(pImaginePrincipala, new Rectangle(0, 0, pLatime, pInaltime));
                //}
                //return imagineRetur;

                imagineRetur = pImaginePrincipala.GetThumbnailImage(pLatime, pInaltime, myCallback, IntPtr.Zero);
            }

            return imagineRetur;
        }

        public static Image GetThumbnailImage(Image pImaginePrincipala, int pLatime, int pInaltime, bool pPastreazaRaportWH)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image imagineRetur = null;

            if (pImaginePrincipala != null)
            {
                if (pPastreazaRaportWH)
                {
                    if (pImaginePrincipala.Width >= pImaginePrincipala.Height)
                    {
                        //Este o imagine orizontala/patratoasa  
                        pInaltime = Convert.ToInt32(Convert.ToDecimal(pLatime) * (Convert.ToDecimal(pImaginePrincipala.Height) / Convert.ToDecimal(pImaginePrincipala.Width)));
                    }
                    else
                    {
                        //Este o imagine verticala
                        pLatime = Convert.ToInt32(Convert.ToDecimal(pInaltime) * (Convert.ToDecimal(pImaginePrincipala.Width) / Convert.ToDecimal(pImaginePrincipala.Height)));
                    }
                }

                //imagineRetur = new Bitmap(pLatime, pInaltime);
                //imagineRetur.SetResolution(pImaginePrincipala.HorizontalResolution, pImaginePrincipala.VerticalResolution);
                //using (Graphics gr = Graphics.FromImage(imagineRetur))
                //{
                //    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //    gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //    gr.DrawImage(pImaginePrincipala, new Rectangle(0, 0, pLatime, pInaltime));
                //}
                //return imagineRetur;

                imagineRetur = pImaginePrincipala.GetThumbnailImage(pLatime, pInaltime, myCallback, IntPtr.Zero);
            }

            return imagineRetur;
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }

        public static Bitmap RotesteImaginea(Bitmap pImagineSursa)
        {
            return RotesteImaginea(pImagineSursa, 10);
        }

        public static Bitmap RotesteImaginea(Bitmap pImagineSursa, float pUnghiRotire)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(pImagineSursa.Width, pImagineSursa.Height);
            returnBitmap.SetResolution(pImagineSursa.HorizontalResolution, pImagineSursa.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);

            //move rotation point to center of image
            g.TranslateTransform((float)pImagineSursa.Width / 2, (float)pImagineSursa.Height / 2);

            //rotate
            g.RotateTransform(pUnghiRotire);

            //move image back
            g.TranslateTransform(-(float)pImagineSursa.Width / 2, -(float)pImagineSursa.Height / 2);

            //draw passed in image onto graphics object
            g.DrawImage(pImagineSursa, new Point(0, 0));

            return returnBitmap;
        }

        public static Bitmap SuprapuneImagini(Bitmap pImaginePrincipala, Bitmap pImagineSecundara)
        {

            Bitmap rez = new Bitmap(Math.Max(pImaginePrincipala.Width, pImagineSecundara.Width), Math.Max(pImaginePrincipala.Height, pImagineSecundara.Height));

            using (Graphics g = Graphics.FromImage(rez))
            {

                g.DrawImage(pImaginePrincipala, 0, 0, rez.Width, rez.Height);

                g.DrawImage(pImagineSecundara, 0, 0, rez.Width, rez.Height);

                g.Save();
            }

            return rez;
        }

        public static Bitmap getImagineAlbNegru(Bitmap pImagineSursa)
        {
            Bitmap imgSursa = pImagineSursa;
            for (int i = 0; i < imgSursa.Width; i++)
            {
                for (int j = 0; j < imgSursa.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = imgSursa.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11));

                    //create the color object
                    Color newColor = Color.FromArgb(originalColor.A, grayScale, grayScale, grayScale);

                    //set the new image's pixel to the grayscale version
                    imgSursa.SetPixel(i, j, newColor);
                }
            }

            return imgSursa;
        }

        public static Bitmap TaieInX(Bitmap imgDinte, Color pCuloare)
        {
            using (Graphics g = Graphics.FromImage(imgDinte))
            {
                using (Pen pensula = new Pen(pCuloare, Math.Max(3, Convert.ToSingle(imgDinte.Width * 0.05))))
                {
                    g.DrawLine(pensula, new Point(0, 0), new Point(imgDinte.Width, imgDinte.Height));
                    g.DrawLine(pensula, new Point(0, imgDinte.Height), new Point(imgDinte.Width, 0));
                }
            }

            return imgDinte;
        }

        public static Bitmap SchimbaNuantaImagine(Bitmap pImagineSursa, Color pNouaCuloare)
        {
            Bitmap imgSursa = pImagineSursa;
            Color oldColorInThisPixel = Color.Empty;
            for (int i = 0; i < imgSursa.Width; i++)
            {
                for (int j = 0; j < imgSursa.Height; j++)
                {
                    oldColorInThisPixel = imgSursa.GetPixel(i, j);

                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(oldColorInThisPixel.A,
                        oldColorInThisPixel.R + (byte)((1 - oldColorInThisPixel.R / 255.0) * pNouaCuloare.R),
                        oldColorInThisPixel.G + (byte)((1 - oldColorInThisPixel.G / 255.0) * pNouaCuloare.G),
                        oldColorInThisPixel.B + (byte)((1 - oldColorInThisPixel.B / 255.0) * pNouaCuloare.B)
                        ));
                }
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaImagine(Bitmap pImagineSursa, Color pNouaCuloare)
        {
            return ColoreazaPortiuneImagine(pImagineSursa, pNouaCuloare, 0, 100);
        }

        public static Bitmap ColoreazaPortiuneImagine(Bitmap pImagineSursa, Color pNouaCuloare, int h1Procent, int h2Procent)
        {
            Bitmap imgSursa = pImagineSursa;
            for (int i = 0; i < imgSursa.Width; i++)
            {
                for (int j = imgSursa.Height * h1Procent / 100; j < imgSursa.Height * h2Procent / 100; j++)
                {
                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                }
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaDreptunghiImagineCuChenar(Bitmap pImagineSursa, Color pNouaCuloare, int x1, int y1, int x2, int y2, int pProcentLatimeChenar, Color pCuloareChenar, EnumMargine pMargini)
        {
            Bitmap imgSursa = pImagineSursa;
            bool suntemInChenar = false;
            int inaltime = y2 - y1;
            int procentInaltime = inaltime * pProcentLatimeChenar / 100;
            int latime = x2 - x1;
            int procentLatime = latime * pProcentLatimeChenar / 100;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    suntemInChenar = false;
                    switch (pMargini)
                    {
                        case EnumMargine.Sus:
                            if (j - y1 < procentInaltime)
                                suntemInChenar = true;
                            break;
                        case EnumMargine.Jos:
                            if (y2 - j < procentInaltime)
                                suntemInChenar = true;
                            break;
                        case EnumMargine.Stanga:
                            if (i - x1 < procentLatime)
                                suntemInChenar = true;
                            break;
                        case EnumMargine.Dreapta:
                            if (x2 - i < procentLatime)
                                suntemInChenar = true;
                            break;
                        case EnumMargine.StangaJosDreapta:
                            if (i - x1 < procentLatime || y2 - j < procentInaltime || x2 - i < procentLatime)
                                suntemInChenar = true;
                            break;
                        case EnumMargine.StangaSusDreapta:
                            if (i - x1 < procentLatime || j - y1 < procentInaltime || x2 - i < procentLatime)
                                suntemInChenar = true;
                            break;
                    }

                    if (!suntemInChenar)
                    {
                        //setam culoare pixelului ca cea noua
                        //folosim componenta A de la pixel pentru a pastra transparenta
                        imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                    }
                    else
                    {
                        imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pCuloareChenar.R, pCuloareChenar.G, pCuloareChenar.B));
                    }
                }
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaDreptunghiImagine(Bitmap pImagineSursa, Color pNouaCuloare, int x1, int y1, int x2, int y2)
        {
            Bitmap imgSursa = pImagineSursa;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                }
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaMODImagine(Bitmap pImagineSursa, Color pNouaCuloare, int x1, int y1, int x2, int y2, int x3, int y3, int x4, bool pJos)
        {
            Bitmap imgSursa = pImagineSursa;
            for (int i = x1; i < x4; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    if (pJos)
                    {
                        if (i > x2 && i < x3 && j > y3) continue;
                    }
                    else
                    {
                        if (i > x2 && i < x3 && j < y3) continue;
                    }

                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                }
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaTriunghiImagine(Bitmap pImagineSursa, Color pNouaCuloare, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Bitmap imgSursa = pImagineSursa;
            using (Graphics g = Graphics.FromImage(imgSursa))
            {
                using (Brush pensula = new SolidBrush(pNouaCuloare))
                {
                    Point[] triunghi = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                    g.FillPolygon(pensula, triunghi);
                }
                g.Save();
            }

            return imgSursa;
        }

        public static Bitmap ColoreazaMarginiVerticale(Bitmap pImagineSursa, Color pNouaCuloare, int pProcent, int pHMax)
        {
            return ColoreazaMarginiVerticale(pImagineSursa, pNouaCuloare, pProcent, 0, pHMax);
        }

        public static Bitmap ColoreazaMarginiVerticale(Bitmap pImagineSursa, Color pNouaCuloare, int pProcent, int pProcentYMin, int pProcentYMax)
        {
            Bitmap imgSursa = pImagineSursa;
            int x1 = imgSursa.Width * pProcent / 100;
            int x2 = imgSursa.Width - x1;
            int y1 = imgSursa.Height * pProcentYMin / 100;
            int y2 = imgSursa.Height * pProcentYMax / 100;
            for (int i = 0; i < x1; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                }
            }

            for (int i = x2; i < imgSursa.Width; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(imgSursa.GetPixel(i, j).A, pNouaCuloare.R, pNouaCuloare.G, pNouaCuloare.B));
                }
            }

            return imgSursa;
        }

        public static Bitmap DecupeazaPortiuneVerticala(Bitmap pImagineSursa, Color pNouaCuloare, int pH)
        {
            return DecupeazaPortiuneVerticala(pImagineSursa, pNouaCuloare, 0, pH);
        }

        public static Bitmap DecupeazaPortiuneVerticala(Bitmap pImagineSursa, Color pNouaCuloare, int pProcentYMin, int pProcentYMax)
        {
            Bitmap imgSursa = pImagineSursa;
            int yInceput = imgSursa.Height * pProcentYMin / 100;
            int yLimita = imgSursa.Height * pProcentYMax / 100;
            Color oldColorInThisPixel = Color.Empty;

            for (int i = 0; i < imgSursa.Width; i++)
            {
                for (int j = 0; j < yInceput; j++)
                {
                    imgSursa.SetPixel(i, j, Color.Transparent);
                }
                for (int j = yInceput; j < yLimita; j++)
                {
                    oldColorInThisPixel = imgSursa.GetPixel(i, j);

                    //setam culoare pixelului ca cea noua
                    //folosim componenta A de la pixel pentru a pastra transparenta
                    imgSursa.SetPixel(i, j, Color.FromArgb(oldColorInThisPixel.A,
                        oldColorInThisPixel.R + (byte)((1 - oldColorInThisPixel.R / 255.0) * pNouaCuloare.R),
                        oldColorInThisPixel.G + (byte)((1 - oldColorInThisPixel.G / 255.0) * pNouaCuloare.G),
                        oldColorInThisPixel.B + (byte)((1 - oldColorInThisPixel.B / 255.0) * pNouaCuloare.B)
                        ));
                }
                for (int j = yLimita; j < imgSursa.Height; j++)
                {
                    imgSursa.SetPixel(i, j, Color.Transparent);
                }
            }
            return imgSursa;
        }

        public static Color getCuloare(Form pEcranParinte, Color pCuloareSelectata)
        {
            using (ColorDialog cul = new ColorDialog())
            {
                cul.Color = pCuloareSelectata;
                if (IHMUtile.DeschideEcran(pEcranParinte, cul))
                    return cul.Color;
            }

            return Color.Empty;
        }

        public static Color getColorFromARGB(int pARGB)
        {
            return System.Drawing.Color.FromArgb(pARGB);
        }

        public static int getARGBFromColor(Color pCuloare)
        {
            return pCuloare.ToArgb();
        }

        public static Image getImagineInvizibila()
        {
            return Properties.Resources.imagineVida16;
        }

        public static Image getImagineIdava()
        {
            return CCL.UI.Properties.Resources.iD;
        }

        public static Image getImagineValidare()
        {
            return CCL.UI.Properties.Resources.Validare;
        }

        public static Image getImagineAnulare()
        {
            return CCL.UI.Properties.Resources.Anulare;
        }

        public static Image getImagineDeschideDocument()
        {
            return CCL.UI.Properties.Resources.OpenDocument16;
        }

        public static Image getImagineAdaugaDocument()
        {
            return CCL.UI.Properties.Resources.folder_add;
        }

        public static Image getImagineMyDocuments(bool pCuDocumente)
        {
            if (pCuDocumente)
                return CCL.UI.Properties.Resources.MyDocuments16Verde;

            return CCL.UI.Properties.Resources.MyDocuments16;
        }

        public static Image getImagineToolTip()
        {
            return CCL.UI.Properties.Resources.ToolTip16;
        }

        public static Image getImagineDeschideInPopUp()
        {
            return CCL.UI.Properties.Resources.ToolTip16;
        }

        public static Image getImagineAlerta()
        {
            return CCL.UI.Properties.Resources.important22;
        }

        public static object getImagineAlertaMica()
        {
            return CCL.UI.Properties.Resources.Alerta16;
        }

        public static object getImagineImportant()
        {
            return CCL.UI.Properties.Resources.important22;
        }

        public static Image getImagineInformatii()
        {
            return CCL.UI.Properties.Resources.ic_informations;
        }

        public static Image getImagineInformatiiInexistente()
        {
            return CCL.UI.Properties.Resources.infoInexistenta;
        }

        public static Image getImagineAtentie()
        {
            return CCL.UI.Properties.Resources.alert_24x24;
        }

        public static Image getImagineSemnalizare(ToolTipIcon pTipIconita)
        {
            //Pentru a afisa corespunzator continutul unui ToolTip
            switch (pTipIconita)
            {
                case ToolTipIcon.Error:
                    return getImagineAlerta();
                case ToolTipIcon.Warning:
                    return getImagineAtentie();
            }

            return getImagineInformatii();
        }

        public static Image getImagineButonEditareElement(bool pEcranInModificare)
        {
            if (pEcranInModificare)
                return getImagineEditare();

            return getImagineToolTip();
        }

        public static Image getImagineEditare()
        {
            return CCL.UI.Properties.Resources.edit16x16;
        }

        public static Image getImagineSelectieUnica()
        {
            return CCL.UI.Properties.Resources.Validare;
        }

        public static Image getImagineEmailTrimise()
        {
            return CCL.UI.Properties.Resources.email_go;
        }

        public static Image getImagineEmailPrimite()
        {
            return CCL.UI.Properties.Resources.email_in;
        }

        public static Image getImagineEmail()
        {
            return CCL.UI.Properties.Resources.email;
        }

        public static Image getImagineStergere()
        {
            return CCL.UI.Properties.Resources.deleteGri2;
        }

        public static Image getImagineStop()
        {
            return CCL.UI.Properties.Resources.Stop;
        }

        public static Image getImagineOK()
        {
            return CCL.UI.Properties.Resources.OK;
        }

        public static Image getImagineNOK()
        {
            return CCL.UI.Properties.Resources.NOK;
        }

        public static Image getImagineCosDeGunoi()
        {
            return CCL.UI.Properties.Resources.NOK;
        }

        public static Bitmap getImagineVida()
        {
            return CCL.UI.Properties.Resources.imagineVida16;
        }

        public static Image getImagineZoom(bool pZoomIn)
        {
            if (pZoomIn)
                return CCL.UI.Properties.Resources.zoomIn;
            else
                return CCL.UI.Properties.Resources.zoomOut;
        }

        public static Image getImagineCalculatorLink()
        {
            return CCL.UI.Properties.Resources.calculator_link;
        }

        public static Image getImagineCalendar()
        {
            return CCL.UI.Properties.Resources.calendarIcon;
        }

        public static Image getImagineIstoric()
        {
            return CCL.UI.Properties.Resources.istoricModificari;
        }

        public static Image getImaginePlus()
        {
            return CCL.UI.Properties.Resources.plus;
        }

        public static Image getImagineMinus()
        {
            return CCL.UI.Properties.Resources.minus;
        }

        public static object getImagineIntrare()
        {
            return CCL.UI.Properties.Resources.Dreapta24;
        }

        public static object getImagineIesire()
        {
            return CCL.UI.Properties.Resources.Stanga24;
        }

        public static Image getImagineHelp()
        {
            return Properties.Resources.help;
        }

        public static Image getImagineImprimanta()
        {
            return Properties.Resources.printer;
        }

        public static Image getImagineExportCSV()
        {
            return Properties.Resources.ExportCSV;
        }

        public static Image GetImaginePin()
        {
            return Properties.Resources.sageataJos;
        }

        public static Image GetImagineSetari()
        {
            return Properties.Resources.settings;
        }

        public static Image GetImagineAdauga()
        {
            return Properties.Resources.Adauga;
        }

        public static Image GetImagineInainte()
        {
            return Properties.Resources.Inainte;
        }

        public static Image GetImaginePrimul()
        {
            return Properties.Resources.Primul;
        }

        public static Image GetImagineInapoi()
        {
            return Properties.Resources.Inapoi;
        }

        public static Image GetImagineUltimul()
        {
            return Properties.Resources.Ultimul;
        }

        public static Image GetImagineAfisareLista()
        {
            return Properties.Resources.AfisareLista;
        }

        public static Image GetImagineCopy()
        {
            return Properties.Resources.Text_copy;
        }

        public static Image GetImagineCut()
        {
            return Properties.Resources.Text_cut;
        }

        public static Image GetImaginePaste()
        {
            return Properties.Resources.Text_paste;
        }

        public static Image GetImagineGuma()
        {
            return Properties.Resources.Text_erase;
        }

        public static Image GetImagineMaiMulte()
        {
            return Properties.Resources.menu;
        }

        public static Image GetImagineCalculator()
        {
            return Properties.Resources.calculator2;
        }

        public static Image GetImagineSageataStanga()
        {
            return Properties.Resources.Inapoi;
        }

        public static Image GetImagineSageataDreapta()
        {
            return Properties.Resources.Inainte;
        }

        public static Image GetImagineSageataSus()
        {
            return Properties.Resources.Sus24;
        }

        public static Image GetImagineSageataJos()
        {
            return Properties.Resources.Jos24;
        }
    }
}
