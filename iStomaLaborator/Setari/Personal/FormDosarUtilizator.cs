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
        private Setari.Personal.ControlDetaliuUtilizator lctrlDetaliuUtilizator = null;
        private Setari.Personal.ControlUtilizatorPontaj lctrlPontajUtilizator = null;

        #endregion

        #region Enumerari si Structuri

        enum EnumTipDosarUtilizator
        {
            Date = 0,
            Financiar = 1,
            Concedii = 2,
            Pontaj = 3,
            Etape = 4
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
        }

        private void initTextML()
        {

            this.Text = this.lUtilizator.Nume + " " + this.lUtilizator.Prenume;
            this.mnuBtnUtilizatorDate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Date);
            this.mnuBtnUtilizatorFinanciar.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Financiar);
            this.mnuBtnUtilizatorConcedii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Concedii);
            this.mnuBtnUtilizatorPontaj.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pontaj);
            this.mnuBtnUtilizatorEtape.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etape);
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

            this.mnuBtnUtilizatorDate.Tag = EnumTipDosarUtilizator.Date;
            this.mnuBtnUtilizatorFinanciar.Tag = EnumTipDosarUtilizator.Financiar;
            this.mnuBtnUtilizatorConcedii.Tag = EnumTipDosarUtilizator.Concedii;
            this.mnuBtnUtilizatorPontaj.Tag = EnumTipDosarUtilizator.Pontaj;
            this.mnuBtnUtilizatorEtape.Tag = EnumTipDosarUtilizator.Etape;

            incarcaOptiuneaSelectata(EnumTipDosarUtilizator.Date);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

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

            if (this.lctrlDetaliuUtilizator != null)
                this.lctrlDetaliuUtilizator.Visible = false;
            if (this.lctrlPontajUtilizator != null)
                this.lctrlPontajUtilizator.Visible = false;

            switch (pZona)
            {
                case EnumTipDosarUtilizator.Date:
                    initControlDate();
                    break;
                case EnumTipDosarUtilizator.Pontaj:
                    initControlPontaj();
                    break;
            }

        }

        private void initControlDate()
        {
            aplicaEfectVizual();

            if (this.lctrlDetaliuUtilizator == null)
            {
                this.lctrlDetaliuUtilizator = new ControlDetaliuUtilizator();
                this.lctrlDetaliuUtilizator.Name = "ctrlDateUtilizator";
                adaugaControlInZonaUtila(this.lctrlDetaliuUtilizator);
            }

            this.lctrlDetaliuUtilizator.Initializeaza(this.lUtilizator);
            this.lctrlDetaliuUtilizator.Visible = true;
            this.lctrlDetaliuUtilizator.BringToFront();
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
        }

        private void aplicaEfectVizual()
        {
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorDate, this.lZonaSelectata == EnumTipDosarUtilizator.Date);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorFinanciar, this.lZonaSelectata == EnumTipDosarUtilizator.Financiar);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorConcedii, this.lZonaSelectata == EnumTipDosarUtilizator.Concedii);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorPontaj, this.lZonaSelectata == EnumTipDosarUtilizator.Pontaj);
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnUtilizatorEtape, this.lZonaSelectata == EnumTipDosarUtilizator.Etape);
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
        }

        #endregion


    }
}
