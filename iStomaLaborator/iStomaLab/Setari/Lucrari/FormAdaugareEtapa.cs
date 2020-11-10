using BLL.iStomaLab;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using CCL.UI;
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

namespace iStomaLab.Setari.Lucrari
{
    public partial class FormAdaugareEtapa : FormPersonalizat
    {

        #region Declaratii generale

        private BEtape lEtapa = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdaugareEtapa(BEtape pEtapa)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lEtapa = pEtapa;

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
            this.ctrlValidareAnulareEtapa.Validare += CtrlValidareAnulareEtapa_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDenumireEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblDurataEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Durata);
            this.lblMinuteEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Minute);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                //AllowModification(true);
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

            this.txtMinuteEtapa.MaxLength = 3;
            this.txtDenumireEtapa.CapitalizeazaPrimaLitera = true;

            if (this.lEtapa == null)
            {
                this.txtDenumireEtapa.Goleste();
                this.txtMinuteEtapa.Goleste();
            }
            else
            {
                this.txtDenumireEtapa.Text = this.lEtapa.Denumire;
                this.txtMinuteEtapa.Text = this.lEtapa.DurataMedieMinute.ToString();
            }

            if (this.lEtapa != null && !this.lEtapa.EsteActiv)
                AllowModification(false);
            else
                AllowModification(true);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareEtapa_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                if (Salveaza())
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

        #endregion

        #region Metode private

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                if (Salveaza())
                    inchideEcranulOK();
            }

            return base.ProcessDialogKey(keyData);
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireEtapa, this.lblDenumireEtapa);
            this.txtDenumireEtapa.Focus();
        }

        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            bool esteValid = BEtape.SuntInformatiileNecesareCoerente(this.txtDenumireEtapa.Text);

            if (this.lEtapa == null)
            {
                if (esteValid)
                    BEtape.Add(this.txtDenumireEtapa.Text, CUtil.GetTextInt32(this.txtMinuteEtapa.Text), null);
                else
                    seteazaAlerta();
            }
            else
            {
                this.lEtapa.Denumire = this.txtDenumireEtapa.Text;
                this.lEtapa.DurataMedieMinute = CUtil.GetTextInt32(this.txtMinuteEtapa.Text);
                if (esteValid)
                    this.lEtapa.UpdateAll();
                else
                    seteazaAlerta();
            }

            return esteValid;
        }

        public static bool Afiseaza(Form pEcranPariente, BEtape pEtapa)
        {
            using (FormAdaugareEtapa ecran = new FormAdaugareEtapa(pEtapa))
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

            this.txtDenumireEtapa.AllowModification(this.lEcranInModificare);
            this.ctrlValidareAnulareEtapa.AllowModification(this.lEcranInModificare);
            this.txtMinuteEtapa.AllowModification(this.lEcranInModificare);
        }


        #endregion


    }
}
