using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
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

namespace iStomaLab.Setari.Personal
{
    public partial class FormDosarUtilizator : FormPersonalizat
    {

        #region Declaratii generale
        private EnumTipDosarUtilizator lZonaSelectata = EnumTipDosarUtilizator.Date;
        private BUtilizator lUtilizator = null;
        private Setari.Personal.ControlDetaliuPersonal lctrlDetaliuPersonal = null;
        private Setari.Personal.ControlUtilizatorPontaj lctrlPontajUtilizator = null;
        private Setari.Personal.ControlUtilizatorDrepturi lctrlDrepturiUtilizator = null;
        private Setari.Personal.ControlUtilizatorFinanciar lctrlDrepturiFinanciar = null;
      
        #endregion

        #region Enumerari si Structuri

        enum EnumTipDosarUtilizator
        {
            Date = 0,
            Financiar = 1,
            Concedii = 2,
            Pontaj = 3,
            Etape = 4,
            Drepturi = 5
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDosarUtilizator(BUtilizator pUtilizator)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lUtilizator = pUtilizator;

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
            this.mnuBtnUtilizatorDate.Click += MnuBtnUtilizator_Click;
            this.mnuBtnUtilizatorFinanciar.Click += MnuBtnUtilizator_Click;
            this.mnuBtnUtilizatorConcedii.Click += MnuBtnUtilizator_Click;
            this.mnuBtnUtilizatorPontaj.Click += MnuBtnUtilizator_Click;
            this.mnuBtnUtilizatorEtape.Click += MnuBtnUtilizator_Click;
            this.mnuBtnUtilizatorDrepturi.Click += MnuBtnUtilizator_Click;
            this.FormClosing += FormDosarUtilizator_FormClosing;
        }
        
        private void initTextML()
        {

            this.Text = this.lUtilizator.GetNumeCompletUtilizator();
            this.mnuBtnUtilizatorDate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Date);
            this.mnuBtnUtilizatorFinanciar.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Financiar);
            this.mnuBtnUtilizatorConcedii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Concedii);
            this.mnuBtnUtilizatorPontaj.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pontaj);
            this.mnuBtnUtilizatorEtape.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape);
            this.mnuBtnUtilizatorDrepturi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Drepturi); 
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
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
            
            this.mnuBtnUtilizatorDate.Tag = EnumTipDosarUtilizator.Date;
            this.mnuBtnUtilizatorFinanciar.Tag = EnumTipDosarUtilizator.Financiar;
            this.mnuBtnUtilizatorConcedii.Tag = EnumTipDosarUtilizator.Concedii;
            this.mnuBtnUtilizatorPontaj.Tag = EnumTipDosarUtilizator.Pontaj;
            this.mnuBtnUtilizatorEtape.Tag = EnumTipDosarUtilizator.Etape;
            this.mnuBtnUtilizatorDrepturi.Tag = EnumTipDosarUtilizator.Drepturi;

            incarcaOptiuneaSelectata(EnumTipDosarUtilizator.Date);

            if (!this.lUtilizator.EsteActiv)
                AllowModification(false);
            else
                AllowModification(true);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void FormDosarUtilizator_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //this.ValidateChildren();

                this.lctrlDetaliuPersonal.UpdateUtilizator();

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

        private void MnuBtnUtilizator_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumTipDosarUtilizator zonaSelectata = (EnumTipDosarUtilizator)(sender as ToolStripButton).Tag;
                incarcaOptiuneaSelectata(zonaSelectata);
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

        private void incarcaOptiuneaSelectata(EnumTipDosarUtilizator pZona)
        {
            this.lZonaSelectata = pZona;

            if (this.lctrlDetaliuPersonal != null)
                this.lctrlDetaliuPersonal.Visible = false;
            if (this.lctrlPontajUtilizator != null)
                this.lctrlPontajUtilizator.Visible = false;
            if (this.lctrlDrepturiFinanciar != null)
                this.lctrlDrepturiFinanciar.Visible = false;

            switch (pZona)
            {
                case EnumTipDosarUtilizator.Date:
                    initControlDate();
                    break;
                case EnumTipDosarUtilizator.Pontaj:
                    initControlPontaj();
                    break;
                case EnumTipDosarUtilizator.Drepturi:
                    initControlDrepturi(); 
                    break;
                case EnumTipDosarUtilizator.Financiar:
                    initControlFinanciar();
                    break;
            }

        }

        private void initControlDate()
        {
            aplicaEfectVizual();

            if (this.lctrlDetaliuPersonal == null)
            {
                this.lctrlDetaliuPersonal = new ControlDetaliuPersonal();
                this.lctrlDetaliuPersonal.Name = "ctrlDateUtilizator";
                adaugaControlInZonaUtila(this.lctrlDetaliuPersonal);
            }

            this.lctrlDetaliuPersonal.Initializeaza(this.lUtilizator);
            this.lctrlDetaliuPersonal.Visible = true;
            this.lctrlDetaliuPersonal.BringToFront();

            this.lctrlDetaliuPersonal.AllowModification(this.lEcranInModificare);
        }

        private void initControlPontaj()
        {
            aplicaEfectVizual();

            if (this.lctrlPontajUtilizator == null)
            {
                this.lctrlPontajUtilizator = new ControlUtilizatorPontaj();
                this.lctrlPontajUtilizator.Name = "ctrlPontajUtilizator";
                adaugaControlInZonaUtila(this.lctrlPontajUtilizator);
            }

            this.lctrlPontajUtilizator.Initializeaza(this.lUtilizator);
            this.lctrlPontajUtilizator.Visible = true;
            this.lctrlPontajUtilizator.BringToFront();

            this.lctrlPontajUtilizator.AllowModification(this.lEcranInModificare);
        }

        private void initControlDrepturi() 
        {
            aplicaEfectVizual();

            if (this.lctrlDrepturiUtilizator == null)
            {
                this.lctrlDrepturiUtilizator = new ControlUtilizatorDrepturi();
                this.lctrlDrepturiUtilizator.Name = "ctrlDrepturiUtilizator";
                adaugaControlInZonaUtila(this.lctrlDrepturiUtilizator);
            }

            this.lctrlDrepturiUtilizator.Initializeaza(this.lUtilizator);
            this.lctrlDrepturiUtilizator.Visible = true;
            this.lctrlDrepturiUtilizator.BringToFront();

            this.lctrlDrepturiUtilizator.AllowModification(this.lEcranInModificare);
        }

        private void initControlFinanciar()
        {
            aplicaEfectVizual();

            if (this.lctrlDrepturiFinanciar == null)
            {
                this.lctrlDrepturiFinanciar = new ControlUtilizatorFinanciar();
                this.lctrlDrepturiFinanciar.Name = "ctrlFinanciarUtilizator";
                adaugaControlInZonaUtila(this.lctrlDrepturiFinanciar);
            }

            this.lctrlDrepturiFinanciar.Initializeaza(this.lUtilizator);
            this.lctrlDrepturiFinanciar.Visible = true;
            this.lctrlDrepturiFinanciar.BringToFront();

            this.lctrlDrepturiFinanciar.AllowModification(this.lEcranInModificare);
        }



        private void aplicaEfectVizual()
        {
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorDate, this.lZonaSelectata == EnumTipDosarUtilizator.Date);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorFinanciar, this.lZonaSelectata == EnumTipDosarUtilizator.Financiar);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorConcedii, this.lZonaSelectata == EnumTipDosarUtilizator.Concedii);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorPontaj, this.lZonaSelectata == EnumTipDosarUtilizator.Pontaj);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorEtape, this.lZonaSelectata == EnumTipDosarUtilizator.Etape);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorDrepturi, this.lZonaSelectata == EnumTipDosarUtilizator.Drepturi);
        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelDetaliuUtilizator.Controls.Add(pControl);
            pControl.Dock = DockStyle.Fill;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BUtilizator pUtilizator)
        {
            using (FormDosarUtilizator ecran = new FormDosarUtilizator(pUtilizator))
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

            if (this.lctrlDetaliuPersonal != null)
                this.lctrlDetaliuPersonal.AllowModification(this.lEcranInModificare);
            if (this.lctrlPontajUtilizator != null)
                this.lctrlPontajUtilizator.AllowModification(this.lEcranInModificare);
            if (this.lctrlDrepturiUtilizator != null)
                this.lctrlDrepturiUtilizator.AllowModification(this.lEcranInModificare);
            if (this.lctrlDrepturiFinanciar != null)
                this.lctrlDrepturiFinanciar.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
