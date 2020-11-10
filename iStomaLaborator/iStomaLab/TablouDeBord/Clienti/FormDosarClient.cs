using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDosarClient : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        private CDefinitiiComune.EnumTipDosarClient lOptiuneSelectata = CDefinitiiComune.EnumTipDosarClient.Date;
        private TablouDeBord.Clienti.ControlDateClinica lctrlDateClinica = null;
        private TablouDeBord.Clienti.ControlDosarClientComenzi lctrlDetaliuComenzi = null;
        private TablouDeBord.Clienti.ControlDosarClientPlati lctrlDetaliuPlati = null;
        private TablouDeBord.Clienti.ControlDosarClientListaPreturi lctrlDetaliuListaPreturi = null;

        #endregion

        #region Enumerari si Structuri

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDosarClient(BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.FormClosing += FormDosarClient_FormClosing;

            this.mnuBtnClientDate.Click += MnuZonaAfisaj_Click;
            this.mnuBtnClientComenzi.Click += MnuZonaAfisaj_Click;
            this.mnuBtnClientPlati.Click += MnuZonaAfisaj_Click;
            this.mnuBtnClientListaPreturi.Click += MnuZonaAfisaj_Click;
        }

        private void initTextML()
        {
            this.Text = this.lClient.Denumire;

            this.mnuBtnClientDate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Detalii);
            this.mnuBtnClientComenzi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Lucrari);
            this.mnuBtnClientPlati.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Plati);
            this.mnuBtnClientListaPreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaPreturi);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.mnuBtnClientDate.Tag = CDefinitiiComune.EnumTipDosarClient.Date;
            this.mnuBtnClientComenzi.Tag = CDefinitiiComune.EnumTipDosarClient.Comenzi;
            this.mnuBtnClientPlati.Tag = CDefinitiiComune.EnumTipDosarClient.Plati;
            this.mnuBtnClientListaPreturi.Tag = CDefinitiiComune.EnumTipDosarClient.ListaPreturi;

            incarcaOptiuneaSelectata(this.lOptiuneSelectata);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void FormDosarClient_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.lctrlDateClinica != null)
                    this.lctrlDateClinica.UpdateClinica();
                if (this.lctrlDetaliuPlati != null)
                    this.lctrlDetaliuPlati.UpdateDateFiscale();

                inchideEcranulOK();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void MnuZonaAfisaj_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                CDefinitiiComune.EnumTipDosarClient titluOptiune = (CDefinitiiComune.EnumTipDosarClient)(sender as ToolStripButton).Tag;

                incarcaOptiuneaSelectata(titluOptiune);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        #endregion

        #region Metode private

        private void incarcaOptiuneaSelectata(CDefinitiiComune.EnumTipDosarClient pOptiune)
        {
            this.lOptiuneSelectata = pOptiune;
            if (this.lctrlDateClinica != null)
                this.lctrlDateClinica.Visible = false;
            if (this.lctrlDetaliuComenzi != null)
                this.lctrlDetaliuComenzi.Visible = false;
            if (this.lctrlDetaliuPlati != null)
                this.lctrlDetaliuPlati.Visible = false;
            if (this.lctrlDetaliuListaPreturi != null)
                this.lctrlDetaliuListaPreturi.Visible = false;

            switch (pOptiune)
            {
                case CDefinitiiComune.EnumTipDosarClient.Date:
                    initControlDateClient();
                    break;
                case CDefinitiiComune.EnumTipDosarClient.Comenzi:
                    initControlComenziClient();
                    break;
                case CDefinitiiComune.EnumTipDosarClient.Plati:
                    initControlPlatiClient();
                    break;
                case CDefinitiiComune.EnumTipDosarClient.ListaPreturi:
                    initControlListaPreturiClient();
                    break;
            }

            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientDate, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Date);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientComenzi, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Comenzi);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientPlati, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Plati);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientListaPreturi, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.ListaPreturi);
        }

        private void initControlListaPreturiClient()
        {
            if (this.lctrlDetaliuListaPreturi == null)
            {
                this.lctrlDetaliuListaPreturi = new ControlDosarClientListaPreturi();
                adaugaControlInZonaUtila(this.lctrlDetaliuListaPreturi);
            }

            this.lctrlDetaliuListaPreturi.Initializeaza(this.lClient);
            this.lctrlDetaliuListaPreturi.Visible = true;
            this.lctrlDetaliuListaPreturi.BringToFront();
        }

        private void initControlDateClient()
        {
            if (this.lctrlDateClinica == null)
            {
                this.lctrlDateClinica = new ControlDateClinica();
                adaugaControlInZonaUtila(this.lctrlDateClinica);
            }

            this.lctrlDateClinica.Initializeaza(this.lClient);
            this.lctrlDateClinica.Visible = true;
            this.lctrlDateClinica.BringToFront();
        }

        private void initControlComenziClient()
        {
            if (this.lctrlDetaliuComenzi == null)
            {
                this.lctrlDetaliuComenzi = new ControlDosarClientComenzi();
                adaugaControlInZonaUtila(this.lctrlDetaliuComenzi);
            }

            this.lctrlDetaliuComenzi.Initializeaza(this.lClient);
            this.lctrlDetaliuComenzi.Visible = true;
            this.lctrlDetaliuComenzi.BringToFront();
        }

        private void initControlPlatiClient()
        {
            if (this.lctrlDetaliuPlati == null)
            {
                this.lctrlDetaliuPlati = new ControlDosarClientPlati();
                adaugaControlInZonaUtila(this.lctrlDetaliuPlati);
            }

            this.lctrlDetaliuPlati.Initializeaza(this.lClient);
            this.lctrlDetaliuPlati.Visible = true;
            this.lctrlDetaliuPlati.BringToFront();
        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelDosarClient.Controls.Add(pControl);
            pControl.Size = this.panelDosarClient.Size;
            pControl.Dock = DockStyle.Fill;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, int pIdClient)
        {
            if (pIdClient <= 0) return false;

            return Afiseaza(pEcranPariente, new BClienti(pIdClient));
        }

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            if (pClient == null) return false;

            using (FormDosarClient ecran = new FormDosarClient(pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
