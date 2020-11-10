using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Utilizatori;
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
using static BLL.iStomaLab.Clienti.BClientiComenziEtape;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuEtapaComanda : FormPersonalizat
    {

        #region Declaratii generale

        private BClientiComenziEtape lEtapa = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuEtapaComanda(BClientiComenziEtape pEtapa)
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
            this.lblGumaFindTehnician.DeschideEcranCautare += LblGumaFindTehnician_DeschideEcranCautare;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }

        private void initTextML()
        {
            this.Text = this.lEtapa.DenumireEtapa;
            this.lblTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
            this.lblDataInceput.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput);
            this.lblDataFinal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataFinal);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblStatus.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare);
            this.chkRefacere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
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

            this.lblGumaFindTehnician.FolosesteToString = true;

            if (this.lEtapa.IdTehnician > 0)
            {
                this.lblGumaFindTehnician.ObiectCorespunzator = BUtilizator.GetById(this.lEtapa.IdTehnician, null);
            }
            else
            {
                this.lblGumaFindTehnician.Goleste();
            }


            this.ctrlDataOraInceput.Initializeaza(this.lEtapa.DataInceput, CCL.UI.ComboBoxOra.EnumPas.JumatateDeOra);
            this.ctrlDataOraFinal.Initializeaza(this.lEtapa.DataFinal, CCL.UI.ComboBoxOra.EnumPas.JumatateDeOra);

            this.cboStatus.DataSource = BClientiComenziEtape.StructStareEtapa.GetList();
            this.cboStatus.SelectedIndex = Convert.ToInt32(this.lEtapa.Status);
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            this.chkRefacere.Checked = this.lEtapa.Refacere;

            this.txtObservatii.Text = this.lEtapa.Observatii;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (ActualizeazaDateEtapa())
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

        private void LblGumaFindTehnician_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator tehnician = FormListaUtilizatori.Afiseaza(this, EnumRol.Tehnician);
                if (tehnician != null)
                    this.lblGumaFindTehnician.ObiectCorespunzator = tehnician;

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

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lblGumaFindTehnician, this.lblTehnician);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlDataOraInceput, this.lblDataInceput);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlDataOraFinal, this.lblDataFinal);

            Control[] lstControale = { this.lblGumaFindTehnician, this.ctrlDataOraInceput, this.ctrlDataOraFinal };

            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        private bool ActualizeazaDateEtapa()
        {
            bool esteOk = this.ctrlDataOraInceput.AreValoare && this.ctrlDataOraFinal.AreValoare && this.lblGumaFindTehnician.IdObiectCorespunzator != 0;

            if (esteOk)
            {
                this.lEtapa.IdTehnician = this.lblGumaFindTehnician.IdObiectCorespunzator;
                this.lEtapa.DataInceput = this.ctrlDataOraInceput.DataAfisata;
                this.lEtapa.DataFinal = this.ctrlDataOraFinal.DataAfisata;
                this.lEtapa.Observatii = this.txtObservatii.Text;
                this.lEtapa.Status = (EnumStareEtapa)this.cboStatus.SelectedIndex;
                this.lEtapa.Refacere = this.chkRefacere.Checked;

                this.lEtapa.UpdateAll();
            }
            else
            {
                seteazaAlerta();
            }

            return esteOk;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClientiComenziEtape pEtapa)
        {
            using (FormDetaliuEtapaComanda ecran = new FormDetaliuEtapaComanda(pEtapa))
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
