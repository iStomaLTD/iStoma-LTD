using CCL.UI.ControaleSpecializate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class frmAfiseazaImagine : frmCuHeader, IDisposable
    {

        #region Declaratii generale

        private ToolTip ctrlToolTip = null;

        private Image lPoza = null;
        private Bitmap lPozaModificata = null;
        private int zoomFactor = 0;
        private int zoomFactorMax = 10;
        private Size marimeInitiala = Size.Empty;
        private Point lPunctClic = Point.Empty;
        private Point lLocatiePoza = Point.Empty;

        //Pentru print
        private int lNumarPaginaCurenta;
        private int lLatimePagina;
        private int lInaltimePagina;
        private int lMargineStanga;
        private int lMargineSus;
        private int lMargineDreapta;
        private int lMargineJos;

        private bool lPermiteImprimarea = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmAfiseazaImagine(string pTitluEcran)
        {
            InitializeComponent();

            this.ctrlToolTip = new ToolTip();
            this.ctrlToolTip.ToolTipIcon = ToolTipIcon.None;

            this.DoubleBuffered = true;

            this.Text = pTitluEcran;

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;

            this.panelImagine.BackColor = Color.Black;
            this.panelContinut.BackColor = Color.Black;
            this.flpPreview.BackColor = Color.Black;

            this.picZonaImagine.SizeMode = PictureBoxSizeMode.Zoom;
            this.picZonaImagine.MouseWheel += new MouseEventHandler(picZonaImagine_MouseWheel);
            this.picZonaImagine.MouseHover += new System.EventHandler(picZonaImagine_MouseHover);
        }

        public frmAfiseazaImagine(List<Image> pListaImagini, List<string> pListaDenumiri, string pTitluEcran, bool pPermiteImprimarea)
            : this(pTitluEcran)
        {
            bool afiseazaListaImagini = pListaImagini.Count > 1;
            this.lPermiteImprimarea = pPermiteImprimarea;

            this.splitGlobal.Panel2Collapsed = !afiseazaListaImagini && !this.lPermiteImprimarea;

            this.lPoza = pListaImagini[0];
            Size marimeNecesara = new Size(this.lPoza.Width, this.lPoza.Height + this.lblTitluEcran.Height);
            if (afiseazaListaImagini)
                marimeNecesara.Height += this.flpPreview.Height;

            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            Rectangle zonaDeLucru = ecranCurent.WorkingArea;
            if (zonaDeLucru.Width < marimeNecesara.Width || zonaDeLucru.Height < marimeNecesara.Height)
                marimeNecesara = new Size(zonaDeLucru.Width - 50, zonaDeLucru.Height - 50);

            this.Size = marimeNecesara;

            if (afiseazaListaImagini)
                incarcaPreview(pListaImagini, pListaDenumiri);

            this.picZonaImagine.Image = this.lPoza;

            this.btnPrint.Visible = pPermiteImprimarea;
        }

        public frmAfiseazaImagine(string pLocatieImagine, string pTitluEcran)
            : this(pTitluEcran)
        {
            this.splitGlobal.Panel2Collapsed = true;

            this.lPoza = new Bitmap(pLocatieImagine);
            Size marimeNecesara = new Size(this.lPoza.Width, this.lPoza.Height + this.lblTitluEcran.Height);

            Screen ecranCurent = Screen.FromControl(this); //this is the Form class

            if (ecranCurent == null)
                ecranCurent = Screen.PrimaryScreen;

            Rectangle zonaDeLucru = ecranCurent.WorkingArea;
            if (zonaDeLucru.Width < marimeNecesara.Width || zonaDeLucru.Height < marimeNecesara.Height)
                marimeNecesara = new Size(zonaDeLucru.Width - 50, zonaDeLucru.Height - 50);

            this.Size = marimeNecesara;

            this.picZonaImagine.Image = this.lPoza;
        }

        private void frmAfiseazaImagine_Load(object sender, EventArgs e)
        {
            setCulori();
        }

        private void picZonaImagine_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom(e.Delta > 0);
            //Size vecheaMarime = picZonaImagine.Size;
            //zoomFactor = zoomFactor + ((e.Delta > 0) ? +1 : -1);

            //if (zoomFactor < 0)
            //    zoomFactor = 0;
            //else
            //    if (zoomFactor > zoomFactorMax)
            //        zoomFactor = zoomFactorMax;

            //Size nouaMarime = new Size(marimeInitiala.Width + zoomFactor * marimeInitiala.Width / 2,
            //                                    marimeInitiala.Height + zoomFactor * marimeInitiala.Height / 2);

            //int catArRamanePeX = nouaMarime.Width - Math.Abs(this.picZonaImagine.Left);
            //int catArRamanePeY = nouaMarime.Height - Math.Abs(this.picZonaImagine.Top);

            ////Repozitionam imaginea pentru a fi centrati pe punctul pe care am facut zoom
            //this.panelImagine.SuspendLayout();
            //this.picZonaImagine.SuspendLayout();

            //if (zoomFactor == 0)
            //{
            //    reseteazaValori();
            //}
            //else
            //{
            //    this.picZonaImagine.Size = nouaMarime;

            //    int distantaStanga = this.picZonaImagine.Left - (nouaMarime.Width - vecheaMarime.Width) / 2;
            //    int distantaSus = this.picZonaImagine.Top - (nouaMarime.Height - vecheaMarime.Height) / 2;

            //    //if (catArRamanePeX < this.panelImagine.Width)
            //    //    distantaStanga = this.picZonaImagine.Left + this.panelImagine.Width - catArRamanePeX;
            //    //else
            //    //    distantaStanga = this.picZonaImagine.Left - ((nouaMarime.Width - vecheaMarime.Width) / 2 - (this.panelImagine.Width / 2 - e.X));

            //    //if (catArRamanePeY < this.panelImagine.Height)
            //    //    distantaSus = this.picZonaImagine.Top + (this.panelImagine.Height - catArRamanePeY);
            //    //else
            //    //    distantaSus = this.picZonaImagine.Top - ((nouaMarime.Height - vecheaMarime.Height) / 2 - (this.panelImagine.Height / 2 - e.Y));

            //    //if (distantaStanga > 0 && nouaMarime.Width > this.panelImagine.Width)
            //    //    distantaStanga = 0;
            //    //if (distantaStanga < 0 && (distantaStanga * (-1) > nouaMarime.Width))
            //    //    distantaStanga = 0;

            //    //if (distantaSus > 0 && nouaMarime.Height > this.panelImagine.Height)
            //    //    distantaSus = 0;
            //    //if (distantaSus < 0 && (distantaSus * (-1) > nouaMarime.Height))
            //    //    distantaSus = 0;

            //    this.picZonaImagine.Left = distantaStanga;
            //    this.picZonaImagine.Top = distantaSus;
            //}

            //this.picZonaImagine.ResumeLayout();
            //this.panelImagine.ResumeLayout();
        }

        private void zoom(bool pIn)
        {
            Size vecheaMarime = picZonaImagine.Size;
            zoomFactor = zoomFactor + (pIn ? +1 : -1);

            if (zoomFactor < 0)
                zoomFactor = 0;
            else
                if (zoomFactor > zoomFactorMax)
                zoomFactor = zoomFactorMax;

            Size nouaMarime = new Size(marimeInitiala.Width + zoomFactor * marimeInitiala.Width / 2,
                                                marimeInitiala.Height + zoomFactor * marimeInitiala.Height / 2);

            int catArRamanePeX = nouaMarime.Width - Math.Abs(this.picZonaImagine.Left);
            int catArRamanePeY = nouaMarime.Height - Math.Abs(this.picZonaImagine.Top);

            //Repozitionam imaginea pentru a fi centrati pe punctul pe care am facut zoom
            this.panelImagine.SuspendLayout();
            this.picZonaImagine.SuspendLayout();

            if (zoomFactor == 0)
            {
                reseteazaValori();
            }
            else
            {
                this.picZonaImagine.Size = nouaMarime;

                int distantaStanga = this.picZonaImagine.Left - (nouaMarime.Width - vecheaMarime.Width) / 2;
                int distantaSus = this.picZonaImagine.Top - (nouaMarime.Height - vecheaMarime.Height) / 2;

                //if (catArRamanePeX < this.panelImagine.Width)
                //    distantaStanga = this.picZonaImagine.Left + this.panelImagine.Width - catArRamanePeX;
                //else
                //    distantaStanga = this.picZonaImagine.Left - ((nouaMarime.Width - vecheaMarime.Width) / 2 - (this.panelImagine.Width / 2 - e.X));

                //if (catArRamanePeY < this.panelImagine.Height)
                //    distantaSus = this.picZonaImagine.Top + (this.panelImagine.Height - catArRamanePeY);
                //else
                //    distantaSus = this.picZonaImagine.Top - ((nouaMarime.Height - vecheaMarime.Height) / 2 - (this.panelImagine.Height / 2 - e.Y));

                //if (distantaStanga > 0 && nouaMarime.Width > this.panelImagine.Width)
                //    distantaStanga = 0;
                //if (distantaStanga < 0 && (distantaStanga * (-1) > nouaMarime.Width))
                //    distantaStanga = 0;

                //if (distantaSus > 0 && nouaMarime.Height > this.panelImagine.Height)
                //    distantaSus = 0;
                //if (distantaSus < 0 && (distantaSus * (-1) > nouaMarime.Height))
                //    distantaSus = 0;

                this.picZonaImagine.Left = distantaStanga;
                this.picZonaImagine.Top = distantaSus;
            }

            this.picZonaImagine.ResumeLayout();
            this.panelImagine.ResumeLayout();
        }

        private void picZonaImagine_MouseHover(object sender, EventArgs e)
        {
            this.picZonaImagine.Focus(); //important pentru scroll
        }

        #endregion

        #region Evenimente

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelBrightness.Visible = false;
                this.panelContrast.Visible = false;
                this.tbBrightness.Value = 0;
                this.tbContrast.Value = 0;

                if (this.lPozaModificata != null)
                    this.lPozaModificata.Dispose();

                this.lPozaModificata = null;
                this.picZonaImagine.Image = this.lPoza;


                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lPozaModificata == null)
                {
                    this.lPozaModificata = (Bitmap)this.lPoza.Clone();
                }

                Tools.Negate(this.lPozaModificata);

                //Lenta
                //Tools.Invert(this.lPozaModificata);

                this.picZonaImagine.Image = this.lPozaModificata;
                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (this.lPozaModificata != null)
                {
                    this.lPozaModificata.Dispose();
                    this.lPozaModificata = null;
                }

                //this.lPozaModificata = (Bitmap)this.lPoza.Clone();
                this.lPozaModificata = Tools.AdjustContrast((Bitmap)this.lPoza, this.tbContrast.Value);

                this.picZonaImagine.Image = this.lPozaModificata;
                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (this.lPozaModificata != null)
                {
                    this.lPozaModificata.Dispose();
                    this.lPozaModificata = null;
                }

                //this.lPozaModificata = (Bitmap)this.lPoza.Clone();
                //Tools.Brightness(this.lPozaModificata, this.tbBrightness.Value);

                this.lPozaModificata = Tools.AdjustBrightness((Bitmap)this.lPoza, this.tbBrightness.Value);

                this.picZonaImagine.Image = this.lPozaModificata;
                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelContrast.Visible = !this.panelContrast.Visible;
                this.panelBrightness.Visible = false;

                //valoare -= 1;
                //brightness();
                //this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrightness_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelBrightness.Visible = !this.panelBrightness.Visible;
                this.panelContrast.Visible = false;
                //valoare += 1;
                //brightness();
                //this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRotesteDreapta_Click(object sender, EventArgs e)
        {
            try
            {
                this.picZonaImagine.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRotesteStanga_Click(object sender, EventArgs e)
        {
            try
            {
                this.picZonaImagine.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.picZonaImagine.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalveazaPeDisc_Click(object sender, EventArgs e)
        {
            if (this.picZonaImagine.Image == null) return;
            try
            {
                using (SaveFileDialog save = new SaveFileDialog())
                {
                    save.FileName = this.Text;
                    save.Filter = "Image(*.jpg; *.jpeg; *.gif; *.bmp; *.ico; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.ico; *.png";
                    if (IHMUtile.DeschideEcran(this, save))
                    {
                        this.picZonaImagine.Image.Save(save.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool lImprimaDoarImagineaCurenta = false;
        private void btnImprimaImaginea_Click(object sender, EventArgs e)
        {
            if (this.picZonaImagine.Image == null) return;
            try
            {
                this.lImprimaDoarImagineaCurenta = true;
                imprima();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.lImprimaDoarImagineaCurenta = false;
                imprima();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void imprima()
        {
            //Alegem imprimanta
            using (PrintDocument lPrintDocument = SetupThePrinting(CCL.iStomaLab.CUtil.getText(13041)))
            {
                if (lPrintDocument == null)
                    return;

                using (PrintPreviewDialog ppDialog = new PrintPreviewDialog())
                {
                    ppDialog.ShowIcon = false;
                    ppDialog.Document = lPrintDocument;
                    IHMUtile.DeschideEcran(this, ppDialog);
                }
            }
        }

        private PrintDocument SetupThePrinting(string pNumeDocument)
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
                if (!IHMUtile.DeschideEcran(this, MyPrintDialog))
                    return null;

                PrintDocument lPrintDocument = creazaPrintDocument();

                lPrintDocument.DocumentName = pNumeDocument;
                lPrintDocument.PrinterSettings =
                                    MyPrintDialog.PrinterSettings;
                lPrintDocument.DefaultPageSettings =
                MyPrintDialog.PrinterSettings.DefaultPageSettings;
                lPrintDocument.DefaultPageSettings.Margins =
                                 new Margins(40, 40, 40, 40);

                if (!lPrintDocument.DefaultPageSettings.Landscape)
                {
                    lLatimePagina = Convert.ToInt32(lPrintDocument.DefaultPageSettings.PrintableArea.Width);
                    lInaltimePagina = Convert.ToInt32(lPrintDocument.DefaultPageSettings.PrintableArea.Height);
                }
                else
                {
                    lInaltimePagina = Convert.ToInt32(lPrintDocument.DefaultPageSettings.PrintableArea.Width);
                    lLatimePagina = Convert.ToInt32(lPrintDocument.DefaultPageSettings.PrintableArea.Height);
                }

                float margineStanga = 0;
                float margineDreapta = 0;
                float margineSus = 0;
                float margineJos = 0;

                try
                {
                    margineStanga = lPrintDocument.DefaultPageSettings.HardMarginX;
                    margineSus = lPrintDocument.DefaultPageSettings.HardMarginY;

                    if (margineStanga < lPrintDocument.DefaultPageSettings.Margins.Left)
                        margineStanga = lPrintDocument.DefaultPageSettings.Margins.Left;

                    if (margineSus < lPrintDocument.DefaultPageSettings.Margins.Top)
                        margineSus = lPrintDocument.DefaultPageSettings.Margins.Top;

                    margineDreapta = margineStanga;
                    margineJos = margineSus;
                }
                catch (Exception)
                {
                    margineStanga = lPrintDocument.DefaultPageSettings.Margins.Left;
                    margineSus = lPrintDocument.DefaultPageSettings.Margins.Top;

                    margineDreapta = lPrintDocument.DefaultPageSettings.Margins.Right;
                    margineJos = lPrintDocument.DefaultPageSettings.Margins.Bottom;
                }

                // Calculating the page margins
                initVariabilePrint(lLatimePagina, lInaltimePagina,
                    Convert.ToInt32(margineStanga),
                    Convert.ToInt32(margineSus),
                    Convert.ToInt32(margineDreapta),
                    Convert.ToInt32(margineJos));

                return lPrintDocument;
            }
        }

        private void initVariabilePrint(int pLatime, int pInaltime, int pMargineStanga, int pMargineSus, int pMargineDreapta, int pMargineJos)
        {
            this.lLatimePagina = pLatime;
            this.lInaltimePagina = pInaltime;
            this.lMargineStanga = pMargineStanga;
            this.lMargineSus = pMargineSus;
            this.lMargineDreapta = pMargineDreapta;
            this.lMargineJos = pMargineJos;

            this.lNumarPaginaCurenta = 1;
        }

        private PrintDocument creazaPrintDocument()
        {
            PrintDocument lPrintDocument = new PrintDocument();

            lPrintDocument.PrintPage += _PrintDocument_PrintPage;
            lPrintDocument.BeginPrint += lPrintDocument_BeginPrint;

            return lPrintDocument;
        }

        void lPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            this.lNumarPaginaCurenta = 0;
        }

        private void _PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                bool more = DrawImagini(e.Graphics);
                if (more == true)
                {
                    this.lNumarPaginaCurenta += 1;
                    e.HasMorePages = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DrawImagini(Graphics g)
        {
            if (this.lImprimaDoarImagineaCurenta)
            {
                g.DrawImage(this.picZonaImagine.Image, 0, 0);

                return false;
            }
            else
            {
                g.DrawImage((this.flpPreview.Controls[this.lNumarPaginaCurenta] as PictureBoxPreview).Image, new Point(0, 0));

                return this.flpPreview.Controls.Count > this.lNumarPaginaCurenta + 1;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool baseResult = base.ProcessCmdKey(ref msg, keyData);
            if (this.flpPreview.Controls.Count > 1)
            {
                int indexSelectat = 0;
                int noulIndexSelectat = 0;
                for (int i = 0; i < this.flpPreview.Controls.Count; i++)
                {
                    if ((this.flpPreview.Controls[i] as PictureBoxPreview).Selectat)
                    {
                        indexSelectat = i;
                        break;
                    }
                }

                switch (keyData)
                {
                    case Keys.Left:
                        //Imaginea din stanga
                        noulIndexSelectat = indexSelectat - 1;
                        if (noulIndexSelectat < 0)
                            noulIndexSelectat = this.flpPreview.Controls.Count - 1;
                        break;
                    case Keys.Right:
                        //Imaginea din dreapta
                        noulIndexSelectat = indexSelectat + 1;
                        if (noulIndexSelectat >= this.flpPreview.Controls.Count)
                            noulIndexSelectat = 0;
                        break;
                    case Keys.Up:
                        //Prima imagine din lista
                        noulIndexSelectat = 0;
                        break;
                    case Keys.Down:
                        //Ultima imagine din lista
                        noulIndexSelectat = this.flpPreview.Controls.Count - 1;
                        break;
                }

                (this.flpPreview.Controls[indexSelectat] as PictureBoxPreview).EsteSelectata(false);
                (this.flpPreview.Controls[noulIndexSelectat] as PictureBoxPreview).EsteSelectata(true);

                this.lPoza = (this.flpPreview.Controls[noulIndexSelectat] as PictureBoxPreview).Image;
                this.picZonaImagine.Image = this.lPoza;
                reseteazaValori();
            }

            return baseResult;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                zoom(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                zoom(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void picPreview_Afiseaza(PictureBoxPreview pSender, Image pImagine)
        {
            try
            {
                this.lPoza = pImagine;
                this.picZonaImagine.Image = this.lPoza;

                if (pSender.Tag != null)
                    this.Text = Convert.ToString(pSender.Tag);

                //Pentru a indica imaginea afisata
                foreach (PictureBoxPreview picPreview in this.flpPreview.Controls)
                {
                    picPreview.EsteSelectata(pSender.Name.Equals(picPreview.Name));
                }

                reseteazaValori();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this, ex.Message);
            }
        }

        private void frmAfiseazaImagine_SizeChanged(object sender, EventArgs e)
        {
            reseteazaValori();
        }

        private void picZonaImagine_MouseDown(object sender, MouseEventArgs e)
        {
            this.lPunctClic = e.Location;
            this.lLocatiePoza = this.picZonaImagine.Location;
        }

        private void picZonaImagine_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //facem drag
                int nouX = this.picZonaImagine.Left - (this.lPunctClic.X - e.Location.X);
                int nouY = this.picZonaImagine.Top - (this.lPunctClic.Y - e.Location.Y);
                if (nouX < 0 && this.picZonaImagine.Width - Math.Abs(nouX) > this.panelImagine.Width)
                    this.picZonaImagine.Left = this.picZonaImagine.Left - (this.lPunctClic.X - e.Location.X);

                if (nouY <= 0 && this.picZonaImagine.Height - Math.Abs(nouY) > this.panelImagine.Height)
                    this.picZonaImagine.Top = this.picZonaImagine.Top - (this.lPunctClic.Y - e.Location.Y);
            }
        }

        private void picZonaImagine_MouseUp(object sender, MouseEventArgs e)
        {
            this.lLocatiePoza = this.picZonaImagine.Location;
        }

        private void picZonaImagine_DoubleClick(object sender, EventArgs e)
        {
            reseteazaValori();
        }

        #endregion

        #region Metode private

        private void reseteazaValori()
        {
            marimeInitiala = new Size(this.Width - 2, this.Height - this.lblTitluEcran.Height);
            zoomFactor = 0;
            this.picZonaImagine.Size = this.panelImagine.Size;
            this.picZonaImagine.Location = new Point(0, 0);
            this.picZonaImagine.Focus();
        }

        private void incarcaPreview(List<Image> pListaImagini, List<string> pListaDenumiri)
        {
            this.flpPreview.Visible = false;
            PictureBoxPreview picPreview = null;
            int nrControale = 0;
            int marime = this.flpPreview.Height - 2;
            int i = 0;
            foreach (var imagine in pListaImagini)
            {
                nrControale = this.flpPreview.Controls.Count;

                picPreview = new PictureBoxPreview();
                picPreview.Name = string.Concat("picPreview", nrControale);
                picPreview.Image = imagine;
                picPreview.Size = new System.Drawing.Size(marime, marime);
                picPreview.Margin = new System.Windows.Forms.Padding(2, 1, 2, 0);
                picPreview.EsteSelectata(nrControale == 0); //primul din lista este selectat din oficiu

                if (pListaDenumiri != null && pListaDenumiri.Count > i)
                {
                    picPreview.Tag = pListaDenumiri[i];
                    this.ctrlToolTip.SetToolTip(picPreview, pListaDenumiri[i]);
                }

                picPreview.Afiseaza += picPreview_Afiseaza;

                this.flpPreview.Controls.Add(picPreview);

                i += 1;
            }
            this.flpPreview.Visible = true;
        }

        #endregion

        #region Metode publice

        void IDisposable.Dispose()
        {
            Control.ControlCollection listaPoze = this.flpPreview.Controls;
            this.flpPreview.Controls.Clear();

            foreach (PictureBoxPreview poza in listaPoze)
            {
                poza.Afiseaza -= picPreview_Afiseaza;
                if (poza.Image != null)
                {
                    poza.Image.Dispose();
                    poza.Image = null;
                }

                poza.Dispose();
            }

            listaPoze.Clear();
            listaPoze = null;

            if (this.lPozaModificata != null)
            {
                this.lPozaModificata.Dispose();
                this.lPozaModificata = null;
            }
        }

        private void setCulori()
        {
            this.panelOptiuni.BackColor = Color.Black;
            this.panelContrast.BackColor = Color.Black;
            this.panelBrightness.BackColor = Color.Black;
            this.tbContrast.BackColor = Color.Black;
            this.tbBrightness.BackColor = Color.Black;
        }

        public static void Afiseaza(Form pEcranParinte, string pLocatieImagine, string pTitlu)
        {
            using (frmAfiseazaImagine ecran = new frmAfiseazaImagine(pLocatieImagine, pTitlu))
            {
                ecran.MinimumSize = new Size(500, 500);
                ecran.setCulori();
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
            }
        }

        public static void Afiseaza(Form pEcranParinte, List<Image> pListaImagini, List<string> pListaDenumiri, string pTitlu, bool pPermiteImprimarea, bool pDistrugeImaginile)
        {
            using (frmAfiseazaImagine ecran = new frmAfiseazaImagine(pListaImagini, pListaDenumiri, pTitlu, pPermiteImprimarea))
            {
                ecran.MinimumSize = new Size(500, 500);
                ecran.setCulori();
                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);

                if (pDistrugeImaginile)
                {
                    //Eliberam memoria
                    if (pListaImagini != null)
                    {
                        for (int i = 0; i < pListaImagini.Count; i++)
                        {
                            pListaImagini[i].Dispose();
                        }

                        pListaImagini = null;
                    }
                }
            }
        }

        #endregion

    }
}
