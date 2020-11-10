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
        private TablouDeBord.Clienti.ControlDetaliuClient lctrlDetaliuClient = null;
        private TablouDeBord.Clienti.ControlDosarClientComenzi lctrlDetaliuComenzi = null;
        private TablouDeBord.Clienti.ControlDosarClientPlati lctrlDetaliuPlati = null;
        private TablouDeBord.Clienti.ControlDosarClientReprezentanti lctrlDetaliuReprezentanti = null;
        private TablouDeBord.Clienti.ControlDosarClientListaPreturi lctrlDetaliuListaPreturi = null;
        private TablouDeBord.Clienti.ControlDosarClientCabinete lctrlDetaliuCabinete = null;

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
            this.btnEditareDosarClient.Click += BtnEditareDosarClient_Click;

            this.mnuBtnClientDate.Click += MnuBtnClient_Click;
            this.mnuBtnClientReprezentanti.Click += MnuBtnClient_Click;
            this.mnuBtnClientComenzi.Click += MnuBtnClient_Click;
            this.mnuBtnClientPlati.Click += MnuBtnClient_Click;
            this.mnuBtnClientListaPreturi.Click += MnuBtnClient_Click;
            this.mnuBtnClientCabinete.Click += MnuBtnClient_Click;
        }
        
        private void initTextML()
        {
            this.Text = this.lClient.Denumire;

            this.mnuBtnClientDate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Date);
            this.mnuBtnClientReprezentanti.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Reprezentanti);
            this.mnuBtnClientComenzi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comenzi);
            this.mnuBtnClientPlati.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Plati);
            this.mnuBtnClientListaPreturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaPreturi);
            this.mnuBtnClientCabinete.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cabinete);
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

            this.Maximizeaza();

            this.mnuBtnClientDate.Tag = CDefinitiiComune.EnumTipDosarClient.Date;
            this.mnuBtnClientReprezentanti.Tag = CDefinitiiComune.EnumTipDosarClient.Reprezentanti;
            this.mnuBtnClientCabinete.Tag = CDefinitiiComune.EnumTipDosarClient.Cabinete;
            this.mnuBtnClientComenzi.Tag = CDefinitiiComune.EnumTipDosarClient.Comenzi;
            this.mnuBtnClientPlati.Tag = CDefinitiiComune.EnumTipDosarClient.Plati;
            this.mnuBtnClientListaPreturi.Tag = CDefinitiiComune.EnumTipDosarClient.ListaPreturi;

            this.lblDosarNumeClient.Text = this.lClient.Denumire;
            incarcaOptiuneaSelectata(this.lOptiuneSelectata);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente
        
        private void BtnEditareDosarClient_Click(object sender, EventArgs e)
        {
            if (this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Date)
            {
                if (this.btnEditareDosarClient.TipButon == CCL.UI.ButtonPersonalizat.EnumTipButon.Editare)
                {
                    this.lctrlDetaliuClient.Salveaza();
                    this.btnEditareDosarClient.TipButon = CCL.UI.ButtonPersonalizat.EnumTipButon.LecturaModificare;
                }
            }
            else
            {

            }
        }

        private void MnuBtnClient_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                CDefinitiiComune.EnumTipDosarClient titluOptiune =(CDefinitiiComune.EnumTipDosarClient)(sender as ToolStripButton).Tag;

                incarcaOptiuneaSelectata(titluOptiune);

                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientDate, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Date);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientReprezentanti, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Reprezentanti);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientCabinete, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Cabinete);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientComenzi, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Comenzi);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientPlati, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.Plati);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnClientListaPreturi, this.lOptiuneSelectata == CDefinitiiComune.EnumTipDosarClient.ListaPreturi);
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
            if (this.lctrlDetaliuClient != null)
                this.lctrlDetaliuClient.Visible = false;
            if (this.lctrlDetaliuComenzi != null)
                this.lctrlDetaliuComenzi.Visible = false;
            if (this.lctrlDetaliuPlati != null)
                this.lctrlDetaliuPlati.Visible = false;
            if (this.lctrlDetaliuReprezentanti != null)
                this.lctrlDetaliuReprezentanti.Visible = false;
            if (this.lctrlDetaliuListaPreturi != null)
                this.lctrlDetaliuListaPreturi.Visible = false;
            if (this.lctrlDetaliuCabinete != null)
                this.lctrlDetaliuCabinete.Visible = false;

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
                case CDefinitiiComune.EnumTipDosarClient.Reprezentanti:
                    initControlReprezentantiClient();
                    break;
                case CDefinitiiComune.EnumTipDosarClient.ListaPreturi:
                    initControlListaPreturiClient();
                    break;
                case CDefinitiiComune.EnumTipDosarClient.Cabinete:
                    initControlCabineteClient();
                    break;
            }
        }

        private void initControlCabineteClient()
        {
            if (this.lctrlDetaliuCabinete == null)
            {
                this.lctrlDetaliuCabinete = new ControlDosarClientCabinete();
                adaugaControlInZonaUtila(this.lctrlDetaliuCabinete);
            }

            this.lctrlDetaliuCabinete.Initializeaza(this.lClient);
            this.lctrlDetaliuCabinete.Visible = true;
            this.lctrlDetaliuCabinete.BringToFront();
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
            if (this.lctrlDetaliuClient == null)
            {
                this.lctrlDetaliuClient = new ControlDetaliuClient();
                adaugaControlInZonaUtila(this.lctrlDetaliuClient);
            }

            this.lctrlDetaliuClient.Initializeaza(this.lClient);
            this.lctrlDetaliuClient.Visible = true;
            this.lctrlDetaliuClient.BringToFront();
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

            this.lctrlDetaliuPlati.Initializeaza();
            this.lctrlDetaliuPlati.Visible = true;
            this.lctrlDetaliuPlati.BringToFront();
        }

        private void initControlReprezentantiClient()
        {
            if (this.lctrlDetaliuReprezentanti == null)
            {
                this.lctrlDetaliuReprezentanti = new ControlDosarClientReprezentanti();
                adaugaControlInZonaUtila(this.lctrlDetaliuReprezentanti);
            }

            this.lctrlDetaliuReprezentanti.Initializeaza(this.lClient);
            this.lctrlDetaliuReprezentanti.Visible = true;
            this.lctrlDetaliuReprezentanti.BringToFront();
        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelDosarClient.Controls.Add(pControl);
            pControl.Size = this.panelDosarClient.Size;
            pControl.Dock = DockStyle.Fill;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
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
