using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CautaPoza")]
    public partial class controlImagineAtasata : UserControlComun
    {

        #region Declaratii generale

        public event CEvenimente.CautaPozaHandler CautaPoza;
        public event CEvenimente.EventIdHandlerCuConfirmareExterna StergePoza;
        public event ImagineHandler ImagineSelectata;
        public event System.EventHandler ControlSelectat;

        public delegate void ImagineHandler(controlImagineAtasata pSender, Tuple<int, Bitmap> pImagineSelectata);

        private Tuple<int, Bitmap> lImagineAtasata;
        private bool lPermiteActiuni = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public int IdPoza
        {
            get
            {
                if (this.lImagineAtasata != null)
                    return this.lImagineAtasata.Item1;
                return 0;
            }
        }

        #endregion

        #region Constructor si Initializare

        public controlImagineAtasata()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        public void Initializeaza(Tuple<int, Bitmap> pImagine, bool pPermiteActiuni)
        {
            base.InitializeazaVariabileleGenerale();
            this.lImagineAtasata = pImagine;
            this.lPermiteActiuni = pPermiteActiuni;

            incepeIncarcarea();

            incarcaImaginea();
            this.btnCautaPoza.Visible = this.lPermiteActiuni;
            this.btnStergeImagine.Visible = this.lPermiteActiuni;
            this.picPoza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void picPoza_MouseEnter(object sender, EventArgs e)
        {
            Selecteaza();
        }

        private void picPoza_MouseLeave(object sender, EventArgs e)
        {
            Deselecteaza();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Deselecteaza();
            base.OnMouseLeave(e);
        }

        private void picPoza_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Rectangle chenar = new Rectangle(this.picPoza.DisplayRectangle.X + 1, this.picPoza.DisplayRectangle.Y + 1,
                                                    this.picPoza.DisplayRectangle.Width - 2, this.picPoza.DisplayRectangle.Height - 2);

                if (this.lImagineAtasata != null)
                {
                    RectangleF chenarImagine = RectangleF.Empty;
                    SizeF marimeImagine = SizeF.Empty;

                    //Daca imaginea este mica o vom afisa centrata
                    if (this.lImagineAtasata.Item2.Width < this.Width && this.lImagineAtasata.Item2.Height < this.Height)
                    {
                        marimeImagine = new SizeF(this.lImagineAtasata.Item2.Width, this.lImagineAtasata.Item2.Height);
                    }
                    else
                    {
                        if (this.lImagineAtasata.Item2.Width < this.lImagineAtasata.Item2.Height)
                        {
                            //Avem o imagine verticala
                            marimeImagine = new SizeF(chenar.Height * this.lImagineAtasata.Item2.Width / this.lImagineAtasata.Item2.Height, chenar.Height);
                        }
                        else
                        {
                            //Avem o imagine orizontala
                            marimeImagine = new SizeF(chenar.Width, chenar.Width * this.lImagineAtasata.Item2.Height / this.lImagineAtasata.Item2.Width);
                        }
                    }

                    chenarImagine = new RectangleF(chenar.X + (chenar.Width - marimeImagine.Width) / 2,
                                                   chenar.Y + (chenar.Height - marimeImagine.Height) / 2,
                                                   marimeImagine.Width,
                                                   marimeImagine.Height);

                    g.DrawImage(this.lImagineAtasata.Item2, chenarImagine);
                }
                else
                {
                    g.FillRectangle(Brushes.Transparent, chenar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picPoza_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                anuntaSelectia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCautaPoza_Click(object sender, EventArgs e)
        {
            try
            {
                cereImagine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStergeImagine_Click(object sender, EventArgs e)
        {
            try
            {
                cereStergereImagine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private

        private void anuntaSelectareaControlului()
        {
            if (this.ControlSelectat != null)
                ControlSelectat(this, null);
        }

        private void anuntaSelectia()
        {
            if (this.ImagineSelectata != null)
                ImagineSelectata(this, this.lImagineAtasata);
        }

        private void cereStergereImagine()
        {
            if (this.StergePoza != null)
                StergePoza(this, this.IdPoza);
        }

        private void incarcaImaginea()
        {
            this.picPoza.Invalidate();
        }

        private void cereImagine()
        {
            if (CautaPoza != null)
            {
                Tuple<int, Bitmap> pozaGasita = CautaPoza(this);
                if (pozaGasita != null)
                {
                    this.lImagineAtasata = pozaGasita;
                    incarcaImaginea();
                }
            }
        }

        #endregion

        #region Metode publice

        public void Selecteaza()
        {
            if (!this.lPermiteActiuni)
            {
                this.picPoza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                anuntaSelectareaControlului();
            }
        }

        public void Deselecteaza()
        {
            if (!this.lPermiteActiuni)
                picPoza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        public void Goleste()
        {
            Initializeaza(null, true);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.btnCautaPoza.Visible = this.lPermiteActiuni && pPermiteModificarea;
            this.btnStergeImagine.Visible = this.lPermiteActiuni && pPermiteModificarea;
        }

        #endregion

    }
}
