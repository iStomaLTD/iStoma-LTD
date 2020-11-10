using CCL.iStomaLab;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("PaginaSchimbata")]
    public partial class ControlPaginatie : UserControl
    {
        public event System.EventHandler PaginaSchimbata;

        private int lNrPaginaCurenta = 0;
        private int lPagini = 0;
        private int lNrElementePePagina = 0;
        private int lNrElemente = 0;
        private bool lAfiseazaListaCompleta = false;

        public ControlPaginatie()
        {
            InitializeComponent();

            if(!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.btnListaCompleta.Text = CUtil.getText(884);
            }
        }

        public void Initializeaza(int pNrElemente, int pNrElementePePagina)
        {
            this.lNrElemente = pNrElemente;
            this.lNrElementePePagina = pNrElementePePagina;
            this.lNrPaginaCurenta = 0;
            if (this.lNrElementePePagina > 0)
                this.lPagini = Convert.ToInt32(Math.Ceiling((double)this.lNrElemente / this.lNrElementePePagina));
            else
                this.lPagini = 0;

            this.lAfiseazaListaCompleta = false;

            this.Visible = (this.lNrElemente > this.lNrElementePePagina);

            verificaCoerentaIndecsi();

            afiseazaNrPaginii();
        }

        private void afiseazaNrPaginii()
        {
            this.lblNrPagina.Text = string.Format("{0}/{1}", this.lNrPaginaCurenta + 1, this.lPagini);
        }

        private void verificaCoerentaIndecsi()
        {
            if (this.lNrPaginaCurenta < 0)
                this.lNrPaginaCurenta = 0;

            if (this.lNrPaginaCurenta >= this.lPagini)
                this.lNrPaginaCurenta = this.lPagini - 1;
        }

        private void anuntaSchimbarea()
        {
            if (this.PaginaSchimbata != null)
                PaginaSchimbata(this, null);
        }

        private void btnStanga_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lNrPaginaCurenta > 0)
                {
                    this.lNrPaginaCurenta -= 1;
                    verificaCoerentaIndecsi();
                    afiseazaNrPaginii();
                    anuntaSchimbarea();
                }
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        private void btnDreapta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lNrPaginaCurenta < this.lPagini - 1)
                {
                    this.lNrPaginaCurenta += 1;
                    verificaCoerentaIndecsi();
                    afiseazaNrPaginii();
                    anuntaSchimbarea();
                }
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        private void btnListaCompleta_Click(object sender, EventArgs e)
        {
            try
            {
                this.lNrPaginaCurenta = 0;
                verificaCoerentaIndecsi();
                this.Visible = false;
                this.lAfiseazaListaCompleta = true;
                anuntaSchimbarea();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(IHMUtile.GetFormParinte(this), ex.Message);
            }
        }

        public int getIndexStart()
        {
            if (this.lAfiseazaListaCompleta)
                return 0;
            else
                return this.lNrPaginaCurenta * this.lNrElementePePagina;
        }

        public int getIndexStop()
        {
            if (this.lAfiseazaListaCompleta)
                return this.lNrElemente;
            else
                return Math.Min(this.lNrElemente, (this.lNrPaginaCurenta + 1) * this.lNrElementePePagina);
        }

        public bool SuntTotiVizibili()
        {
            return this.lAfiseazaListaCompleta || this.lPagini <= 1;
        }
    }
}
