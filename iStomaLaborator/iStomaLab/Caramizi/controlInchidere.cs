using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILL.BLL.General;
using BLL.iStomaLab;
using CDL.iStomaLab;
using CCL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Caramizi
{
    public partial class controlInchidere : Generale.UserControlPersonalizat
    {
        #region Declaratii generale

        public event System.EventHandler ModificareInchidere;
        public event System.EventHandler Stergere;

        private IInchidere lDetaliiInchidere;
        private string lMesajInchidere;
        private string lMesajReactivare;
        private CCL.UI.CEnumerariComune.EnumTipDeschidere lTipDeschidere;
        private bool lPermiteStergerea = false;
        private bool lGestiuneInterna = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        [Description("Tipul de deschidere al calendarului asociat")]
        [Category("iDava")]
        public CCL.UI.CEnumerariComune.EnumTipDeschidere TipDeschidereLista
        {
            get { return this.lTipDeschidere; }
            set { lTipDeschidere = value; }
        }

        public bool EsteInchis
        {
            get { return this.chkDezactiveaza.Checked; }
        }

        #endregion

        #region Constructor si Initializare

        public controlInchidere()
        {
            InitializeComponent();
            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.lblDataInchidere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Acum);
                this.chkDezactiveaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere);
                this.lblMotivulInchiderii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MotivulInchiderii);

                this.btnDeschideListaMotiveInchidere.Visible = false;
            }
        }

        public void Initializeaza(IInchidereCuMesaj pDetaliiInchidere)
        {
            Initializeaza(pDetaliiInchidere, false, true);
        }

        public void Initializeaza(IInchidereCuMesaj pDetaliiInchidere, bool pPermiteStergerea, bool pGestiuneInterna)
        {
            this.lPermiteStergerea = pPermiteStergerea;
            this.lGestiuneInterna = pGestiuneInterna;
            Initializeaza(pDetaliiInchidere, pDetaliiInchidere.getMesajInchidere(), pDetaliiInchidere.getMesajReactivare());
        }

        public void Initializeaza(IInchidere pDetaliiInchidere, string pMesajInchidere, string pMesajReactivare)
        {
            this.lEcranInModificare = false;
            this.lMesajInchidere = pMesajInchidere;
            this.lMesajReactivare = pMesajReactivare;
            this.lDetaliiInchidere = pDetaliiInchidere;

            incepeIncarcarea();
            //Vom afisa in tooltip cine a inchis elementul
            if (this.lDetaliiInchidere.DataInchidere == CConstante.DataNula)
            {
                this.chkDezactiveaza.Checked = false;
                this.lblDataInchidere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Acum);
                this.lblDataInchidere.ToolTipActiv = false;
            }
            else
            {
                this.chkDezactiveaza.Checked = true;
                this.lblDataInchidere.Text = this.lDetaliiInchidere.DataInchidere.ToString("dd/MM/yyyy HH:mm");
                this.lblDataInchidere.ToolTipActiv = true;
                this.lblDataInchidere.ToolTipText = this.lDetaliiInchidere.UtilizatorInchidereNumeComplet;
            }
            this.txtMotivInchidere.Text = this.lDetaliiInchidere.MotivInchidere;
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void btnSterge_Click(object sender, EventArgs e)
        {
            cereStergerea();
        }

        private void txtMotivInchidere_ZonaModificata(Control sender, string sNumeProprietateAtasata, object sNouaValoare)
        {
            try
            {
                if (!this.lSeIncarca)
                {
                    CUtil.SetProperty(this.lDetaliiInchidere, sNumeProprietateAtasata, sNouaValoare);
                    this.lDetaliiInchidere.UpdateAll(null);
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }

        }

        private void chkDezactiveaza_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.lSeIncarca)
                {
                    if (this.chkDezactiveaza.Checked && !this.lGestiuneInterna)
                        anuntaModificareaInchiderii();
                    else
                    {
                        string sMesajConfirmare = (chkDezactiveaza.Checked) ? this.lMesajInchidere : this.lMesajReactivare;
                        string sTitluConfirmare = (chkDezactiveaza.Checked) ? BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere) : BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reactivare);
                        if (Mesaj.Afiseaza(this.GetFormParinte(), sMesajConfirmare, sTitluConfirmare, Mesaj.EnumButoane.DaNu) == DialogResult.Yes)
                        {
                            string MotivInchidere = this.txtMotivInchidere.Text.Trim();

                            if (!this.chkDezactiveaza.Checked)
                            {
                                this.txtMotivInchidere.Goleste();
                                MotivInchidere = string.Empty;
                            }

                            this.lDetaliiInchidere.Close(chkDezactiveaza.Checked, MotivInchidere, null);
                            this.txtMotivInchidere.AllowModification(this.lEcranInModificare && !this.lDetaliiInchidere.EsteActiv);

                            anuntaModificareaInchiderii();

                            this.txtMotivInchidere.Focus();
                        }
                        else
                        {
                            this.lSeIncarca = true;
                            this.txtMotivInchidere.Text = string.Empty;
                            this.chkDezactiveaza.Checked = !this.chkDezactiveaza.Checked;
                            this.lSeIncarca = false;
                            AllowModification(this.lEcranInModificare);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        private void btnDeschideListaMotiveInchidere_Click(object sender, EventArgs e)
        {
            try
            {
                //Determinam locatia de deschidere a listei parametrabile
                int leftPos = 0;
                int topPos = 40;
                System.Windows.Forms.Control parent = this;
                while (parent != null)
                {
                    leftPos += parent.Left;
                    topPos += parent.Top;
                    parent = parent.Parent;
                }
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private

        private void cereStergerea()
        {
            if (this.Stergere != null)
                Stergere(this, null);
        }

        private void anuntaModificareaInchiderii()
        {
            if (this.ModificareInchidere != null)
                ModificareInchidere(this, null);
        }

        #endregion

        #region Metode publice


        #endregion

        #region IControlDava Members

        public void AllowModification(bool bPermiteModificarea)
        {
            if (this.lDetaliiInchidere == null)
                this.lEcranInModificare = false;
            else
            {
                this.lEcranInModificare = bPermiteModificarea;
                this.Visible = this.lEcranInModificare || !this.lDetaliiInchidere.EsteActiv;
            }
            this.chkDezactiveaza.Enabled = this.lEcranInModificare;
            this.txtMotivInchidere.AllowModification(this.lEcranInModificare && (this.lDetaliiInchidere != null && this.lDetaliiInchidere.DataInchidere != CConstante.DataNula));
            this.btnDeschideListaMotiveInchidere.Visible = false;// (this.lEcranInModificare && this.lDetaliiInchidere.ListaMotiveInchidere != CDefinitiiComune.EnumTipLista.Nedefinita);

            this.btnSterge.Visible = this.lEcranInModificare && this.lPermiteStergerea;
        }

        #endregion

    }
}
