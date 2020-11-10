using BLL.iStomaLab;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
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
using static BLL.iStomaLab.Comune.BAdrese;
using static CDL.iStomaLab.CDefinitiiComune;
//using static iStomaLab.Setari.Personal.ControlCreareUtilizator;

namespace iStomaLab.Setari.Personal
{
    public partial class FormCreareUtilizator : FormPersonalizat
    {

        #region Declaratii generale

        public static EnumPanelDeAfisat _SPanelDeAfisat = EnumPanelDeAfisat.ParteaI;

        #endregion

        #region Enumerari si Structuri
        public enum EnumPanelDeAfisat
        {
            ParteaI,
            ParteaII,
            ParteaIII
        }
        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreareUtilizator()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.chkSeConecteaza.CheckedChanged += ChkSeConecteaza_CheckedChanged;
        }
        
        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblCnp.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP);
            this.rbBI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.BI);
            this.rbCI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CI);
            this.lblSerie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Serie);
            this.lblNr.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nr);
            this.lblMobil.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Telefon);
            this.lblEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblRol.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblEmisDe.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EmisDe);
            this.lblValabilitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ValabilitateAct);
            this.chkSeConecteaza.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SeConecteaza);
            this.lblContUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContUtilizator);
            this.lblParola.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola);
            this.lblNrContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrContract);
            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblOreNorma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.OreNorma);
            this.lblZileConcediu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ZileConcediu);
            this.lblDataContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataContract);
            this.lblDataInceputContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput);
            this.lblIban.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IBAN);
            this.lblBanca.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca);
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
            
            _SPanelDeAfisat = EnumPanelDeAfisat.ParteaI;

            this.panelCreareParteaI.Visible = true;
            this.panelCreareParteaI.BringToFront();

            AllowModification(true);

            this.txtNume.Goleste();
            this.txtPrenume.Goleste();
            this.txtCnp.Goleste();
            this.txtSerie.Goleste();
            this.txtNr.Goleste();
            this.rbBI.Checked = false;
            this.rbCI.Checked = false;
            this.txtMobil.Goleste();
            this.txtEmail.Goleste();
            this.txtObservatii.Goleste();
            this.txtEmisDe.Goleste();
            this.txtContUtilizator.Goleste();
            this.txtParola.Goleste();
            this.txtNrContract.Goleste();
            this.txtOreNorma.Goleste();
            this.txtZileConcediu.Goleste();
            this.txtIban.Goleste();
            this.ctrlCautareBanca.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);

            this.txtNume.Focus();
            this.txtNume.CapitalizeazaPrimaLitera = true;
            this.txtPrenume.CapitalizeazaPrimaLitera = true;
            this.txtEmisDe.CapitalizeazaPrimaLitera = true;
            this.txtSerie.TotulCuMajuscule = true;
            this.panelSeConecteaza.Visible = false;

            this.cboRol.BeginUpdate();
            this.cboRol.DataSource = BDefinitiiGenerale.StructRol.getListaRol();
            this.cboRol.EndUpdate();

            this.cboTitulatura.DataSource = BDefinitiiGenerale.StructTitulatura.getListaTitulaturiCuEmpty();
            this.cboTipContract.DataSource = BDefinitiiGenerale.StructTipContract.GetList();

            this.cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTitulatura.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipContract.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ctrlAdresa.Initializeaza(EnumTipObiect.Adrese, 0, true, false);
            
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

                if (this.StabilestePanelDeAfisat())
                {
                    inchideEcranulOK();
                }
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

        private void ChkSeConecteaza_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.chkSeConecteaza.Checked)
                    this.panelSeConecteaza.Visible = true;
                else
                    this.panelSeConecteaza.Visible = false;
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

        private bool esteValidaParteaI()
        {
            return !string.IsNullOrEmpty(this.txtNume.Text) && this.cboRol.SelectedIndex != 0;
        }

        private int getCuloareInitiala()
        {
            return -1296;
        }

        private int getTipAct()
        {
            if (this.rbBI.Checked)
                return 1;
            else if (this.rbCI.Checked)
                return 2;
            return 0;
        }

        private void seteazaAlerte()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNume, this.lblNume);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.cboRol, this.lblRol);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstControale = { this.txtNume, this.cboRol };

            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        private int getIdAdresa(int pIdUtilizator)
        {
            StructDetaliiAdresa detaliiAdresa = this.ctrlAdresa.DetaliiAdresa;

            int id = BAdrese.Add(EnumTipAdresa.Principala, detaliiAdresa.NumeStrada, detaliiAdresa.Numar, detaliiAdresa.Bloc, detaliiAdresa.Scara, detaliiAdresa.Etaj, detaliiAdresa.Apartament, detaliiAdresa.CodInterfon, detaliiAdresa.IdTara, detaliiAdresa.IdRegiune, detaliiAdresa.IdLocalitate, detaliiAdresa.IdCodPostal.ToString(), detaliiAdresa.Comentariu, EnumTipObiect.Utilizator, pIdUtilizator, null);

            return id;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormCreareUtilizator ecran = new FormCreareUtilizator())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }
        
        internal bool StabilestePanelDeAfisat()
        {
            if (FormCreareUtilizator._SPanelDeAfisat == EnumPanelDeAfisat.ParteaI)
            {
                if (esteValidaParteaI())
                {
                    this.panelCreareParteaII.Visible = true;
                    this.panelCreareParteaII.BringToFront();
                    FormCreareUtilizator._SPanelDeAfisat = EnumPanelDeAfisat.ParteaII;
                }
                else
                {
                    seteazaAlerte();
                }
            }
            else if (FormCreareUtilizator._SPanelDeAfisat == EnumPanelDeAfisat.ParteaII)
            {
                FormCreareUtilizator._SPanelDeAfisat = EnumPanelDeAfisat.ParteaIII;
                if (Salveaza())
                    return true;
            }
            return false;
        }

        internal bool Salveaza()
        {
            bool esteValid = BUtilizator.SuntInformatiileNecesareCoerente(this.txtNume.Text, getRol());

            if (esteValid)
            {
                string eroare = string.Empty;
                EnumSex sex = EnumSex.Nedefinit;
                DateTime dataNasterii = CConstante.DataNula;
                int codJudet = 0;
                int codLocalitate = 0;
                EnumTitulatura titulatura = EnumTitulatura.Nedefinit;
                bool nascutInRomania = false;
                CCL.iStomaLab.CUtil.ObtineInformatiiCNP(this.txtCnp.Text, ref eroare, ref sex, ref dataNasterii, ref codJudet, ref codLocalitate, ref titulatura, ref nascutInRomania);

                int id = BUtilizator.Add(this.txtNume.Text, this.txtPrenume.Text, this.txtCnp.Text, dataNasterii, sex, titulatura, string.Empty, string.Empty, 0, 0, 0, string.Empty, 0, 0, codJudet, codLocalitate, getRol(), 0, this.txtObservatii.Text, string.Empty, this.txtMobil.Text, string.Empty, string.Empty, string.Empty, this.txtEmail.Text, string.Empty, string.Empty, 0, this.txtContUtilizator.Text, this.txtParola.Text, getCuloareInitiala(), getTipAct(), this.txtSerie.Text, this.txtNr.Text, 0, CUtil.GetAsInt32(this.txtZileConcediu.Text), this.ctrlDataContract.DataAfisata, this.cboTipContract.SelectedIndex, this.ctrlDataContract.DataAfisata, CConstante.DataNula, CUtil.GetAsInt32(this.txtOreNorma.Text), CUtil.GetAsInt32(this.txtNrContract.Text), this.txtEmisDe.Text, this.ctrlValabilitateInceput.DataAfisata, this.ctrlValabilitateSfarsit.DataAfisata, this.txtIban.Text, this.ctrlCautareBanca.IdObiectAfisajCorespunzator,
                    0, null);

                BUtilizator utilizator = BUtilizator.GetById(id, null);
                utilizator.IdAdresa = getIdAdresa(utilizator.Id);
                utilizator.UpdateAll();
            }
            return esteValid;
        }

        private EnumRol getRol()
        {
            if (this.cboRol.SelectedItem == null)
                return EnumRol.Tehnician;

            return ((BDefinitiiGenerale.StructRol)this.cboRol.SelectedItem).Id;
        }
        
        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;          
            this.ctrlAdresa.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
