using System;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.BLL.General;


namespace CCL.UI
{
    [DefaultEvent("PozitieSchimbata")]
    public partial class ControlGestiuneNumarOrdine : CCL.UI.Caramizi.PanelContainerCCL
    {

        #region Declaratii generale

        public event CEvenimente.AfiseazaExceptieHandler AfiseazaExceptieAparuta;
        public event PozitieSchimbataHandler PozitieSchimbata;

        public delegate void PozitieSchimbataHandler(Control pSender, int pNouaPozitie);

        private IColectieElementePozitionate lListaElemente = null;
        private int lPozitieActuala;
        private int lNumarElementeAfisate;
        private bool lPermiteOrdonareaAlfabetica = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlGestiuneNumarOrdine()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
         ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Se foloseste la schimbarea selectiei
        /// </summary>
        /// <param name="pEcranInModificare"></param>
        /// <param name="pPozitieActuala"></param>
        public void Initializeaza(bool pEcranInModificare, int pPozitieActuala)
        {
            Initializeaza(pEcranInModificare,this.lNumarElementeAfisate, this.lListaElemente, pPozitieActuala);
        }

        /// <summary>
        /// Se foloseste la construierea dgv-ului
        /// </summary>
        /// <param name="pEcranInModificare"></param>
        /// <param name="pListaElemente"></param>
        public void Initializeaza(bool pEcranInModificare, int pNumarElementeAfisate, IColectieElementePozitionate pListaElemente)
        {
            Initializeaza(pEcranInModificare, pNumarElementeAfisate, pListaElemente, -1);
        }

        /// <summary>
        /// Initializam variabilele si zonele ecranului
        /// </summary>
        /// <param name="pEcranInModificare"></param>
        /// <param name="pListaElemente"></param>
        /// <param name="pPozitieActuala"></param>
        public void Initializeaza(bool pEcranInModificare, int pNumarElementeAfisate, IColectieElementePozitionate pListaElemente, int pPozitieActuala)
        {
            this.SuspendLayout();

            this.lListaElemente = pListaElemente;
            this.lPozitieActuala = pPozitieActuala;
            this.lNumarElementeAfisate = pNumarElementeAfisate;

            this.lSeIncarca = true;
            if (this.lPozitieActuala <= 0)
            {
                this.txtNumarOrdine.Text = string.Empty;
            }
            else
            {
                this.txtNumarOrdine.Text = this.lPozitieActuala.ToString();
                AllowModification(pEcranInModificare);
            }
            this.lSeIncarca = false;


            this.ResumeLayout();
        }

        #endregion

        #region Evenimente

        private void btnSortareAlfabetica_Click(object sender, EventArgs e)
        {
            try
            {
                this.lListaElemente.SorteazaAlfabeticInBaza();
                GenereazaEventPozitieSchimbata(-1); //Noua pozitie nu se cunoaste
            }
            catch (Exception ex)
            {
                GenereazaEventAfisareExceptie(ex);
            }
        }

        private void txtNumarOrdine_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            try
            {
                if (!this.lSeIncarca)
                {
                    int NouaValoare = -1;
                    if (!string.IsNullOrEmpty(sNouaValoare))
                    {
                        NouaValoare = Convert.ToInt32(sNouaValoare);
                        if (NouaValoare <= 0 || NouaValoare > this.lNumarElementeAfisate)
                            NouaValoare = -1;
                    }

                    if (NouaValoare <= 0)
                    {
                        this.lSeIncarca = true;
                        this.txtNumarOrdine.Text = this.lPozitieActuala.ToString();
                        this.lSeIncarca = false;
                    }
                    else
                    {
                        //Modificarea are sens doar daca noua pozitie poate exista in lista
                        this.lListaElemente.SchimbaDirectPozitieElement(this.lPozitieActuala, NouaValoare);
                        GenereazaEventPozitieSchimbata(Convert.ToInt16(NouaValoare));
                    }
                }
            }
            catch (Exception ex)
            {
                GenereazaEventAfisareExceptie(ex);
            }
        }

        private void btnSus_Click(object sender, EventArgs e)
        {
            try
            {
                this.lListaElemente.InterschimbaPozitieElemente(this.lPozitieActuala, true);
                GenereazaEventPozitieSchimbata(Convert.ToInt16(this.lPozitieActuala - 1));
            }
            catch (Exception ex)
            {
                GenereazaEventAfisareExceptie(ex);
            }
        }

        private void btnJos_Click(object sender, EventArgs e)
        {
            try
            {
                this.lListaElemente.InterschimbaPozitieElemente(this.lPozitieActuala, false);
                GenereazaEventPozitieSchimbata(Convert.ToInt16(this.lPozitieActuala + 1));
            }
            catch (Exception ex)
            {
                GenereazaEventAfisareExceptie(ex);
            }
        }

        #endregion

        #region Metode private

        private void GenereazaEventAfisareExceptie(Exception pExceptie)
        {
            if (this.AfiseazaExceptieAparuta != null)
            {
                AfiseazaExceptieAparuta(this, pExceptie);
            }
        }

        private void GenereazaEventPozitieSchimbata(short pNouaPozitie)
        {
            if (this.PozitieSchimbata != null)
            {
                PozitieSchimbata(this, pNouaPozitie);
            }
        }

        #endregion

        #region Metode publice

        public void SePermiteSortareaAlfabetica(bool pSePermite)
        {
            this.lPermiteOrdonareaAlfabetica = pSePermite;
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            if (this.lListaElemente == null || this.lListaElemente.Count == 0 || this.lNumarElementeAfisate == 0)
                this.lEcranInModificare = false;

            //Sortarea alfabetica are sens doar daca avem mai multe elemente in lista
            this.btnSortareAlfabetica.Visible = this.lPermiteOrdonareaAlfabetica && (this.lEcranInModificare && this.lNumarElementeAfisate > 1);
            this.txtNumarOrdine.Visible = this.lPozitieActuala > 0;
            this.txtNumarOrdine.AllowModification(this.lEcranInModificare && this.lNumarElementeAfisate > 1);
            this.btnSus.Visible = (this.lEcranInModificare && this.lPozitieActuala > 1);
            this.btnJos.Visible = (this.lEcranInModificare && this.lPozitieActuala < this.lNumarElementeAfisate && this.lPozitieActuala > 0);
        }

        #endregion

    }
}
