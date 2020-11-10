using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab.Utilizatori;
using CDL.iStomaLab;
using BLL.iStomaLab;
using CCL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;
using CCL.UI;
using iStomaLab.Generale;
using BLL.iStomaLab.Referinta;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlDetaliuUtilizator : Generale.UserControlPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUser = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuUtilizator()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.btnDosarPozaPersonal.Click += BtnDosarPozaPersonal_Click;
            this.btnStergePozaPersonal.Click += BtnStergePozaPersonal_Click;
            this.chkFemininPersonal.CheckedChanged += ChkFemininPersonal_CheckedChanged;
            this.chkMasculinPersonal.CheckedChanged += ChkMasculinPersonal_CheckedChanged;
            this.btnLocatieUtilizator.Click += BtnLocatieUtilizator_Click;
        }

        private void initTextML()
        {
            this.lblNumePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenumePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblSupranumePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Supranume);
            this.lblNumeDeFataPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeDeFata);
            this.lblSexPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.chkFemininPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.chkMasculinPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblStareCivilaPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StareCivila);
            this.lblNrCopiiPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrCopii);
            this.lblCnpPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP);
            this.lblSerieActPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Serie);
            this.lblNrActPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Numar);
            this.lblEducatiePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Educatie);
            this.lblScoalaPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Scoala);
            this.lblProfesiePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesie);
            this.lblDataNasteriiPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblTelefonMobilPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblTelefonFixPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix);
            this.lblFaxPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblEmailPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblContYMPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContYM);
            this.lblPaginaWebPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PaginaWeb);
            this.lblSkypePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblCuloarePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
            this.lblRolPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblDataAngajarePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataAngajare);
            this.lblContStomaPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cont);
            this.lblParolaPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Parola);
            this.lblObservatiiPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblTipContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipContract);
            this.lblNrOreNorma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrOreNorma);
            this.lblDataContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataContract);
            this.lblDataIncetareContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataIncetareContract);
            this.lblNrContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrContract);
        }

        public void Initializeaza(BUtilizator pUser)
        {
            base.InitializeazaVariabileleGenerale();
            AllowModification(true);

            this.lUser = pUser;

            incepeIncarcarea();
            initListe();
            this.txtSerieActPersonal.TotulCuMajuscule = true;

            if (this.lUser == null)
            {
                this.txtNumePersonal.Focus();
                this.txtNumePersonal.Goleste();
                this.txtPrenumePersonal.Goleste();
                this.txtSupranumePersonal.Goleste();
                this.chkFemininPersonal.Checked = false;
                this.chkMasculinPersonal.Checked = false;
                this.txtNumeDeFataPersonal.Goleste();
                this.txtNumeDeFataPersonal.Visible = false;
                this.lblNumeDeFataPersonal.Visible = false;
                this.txtCnpPersonal.Goleste();
                this.txtSerieActPersonal.Goleste();
                this.txtNrActPersonal.Goleste();
                this.txtScoalaPersonal.Goleste();
                this.ctrlProfesiePersonal.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                this.ctrlDataNasteriiPersonal.Goleste();
                this.txtTelefonMobilPersonal.Goleste();
                this.txtTelefonFixPersonal.Goleste();
                this.txtFaxPersonal.Goleste();
                this.txtEmailPersonal.Goleste();
                this.txtContYMPersonal.Goleste();
                this.txtPaginaWebPersonal.Goleste();
                this.txtSkypePersonal.Goleste();
                this.txtInfoContactPersonal.Goleste();
                this.ctrlCuloarePersonal.Goleste();
                this.ctrlDataAngajarePersonal.Goleste();
                this.txtContStomaPersonal.Goleste();
                this.txtParolaPersonal.Goleste();
                this.txtObservatiiPersonal.Goleste();
                this.txtNrOreNorma.Goleste();
                this.ctrlDataContract.Goleste();
                this.ctrlDataIncetareContract.Goleste();
                this.txtNrContract.Goleste();
            }
            else
            {

                this.txtNumePersonal.Text = lUser.Nume;
                this.cboTitulaturaPersonal.SelectedIndex = lUser.Titulatura;
                this.txtPrenumePersonal.Text = lUser.Prenume;
                this.txtSupranumePersonal.Text = lUser.Porecla;
                this.chkFemininPersonal.Checked = getSexPersonal(true);
                this.chkMasculinPersonal.Checked = getSexPersonal(false);
                seteazaVizibilitateNumeFata(getSexPersonal(true));
                this.cboStareCivilaPersonal.SelectedIndex = lUser.StareCivila;
                this.cboNrCopiiPersonal.SelectedIndex = lUser.NumarCopii;
                this.txtCnpPersonal.Text = lUser.CNP;
                this.cboTipActPersonal.SelectedIndex = lUser.TipActIdentitate;
                this.txtSerieActPersonal.Text = lUser.SerieActIdentitate;
                this.txtNrActPersonal.Text = lUser.NumarActIdentitate;
                this.cboTipEducatiePersonal.SelectedIndex = lUser.Educatie;
                this.txtScoalaPersonal.Text = lUser.Scoala;
                if (this.lUser.IdProfesie != 0)
                {
                    this.ctrlProfesiePersonal.Initializeaza(new StructIdDenumire(this.lUser.IdProfesie, BProfesii.getProfesie(this.lUser.IdProfesie, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }

                this.ctrlDataNasteriiPersonal.DataAfisata = lUser.DataNastere;
                //this.ctrlImaginePersonal.IdPoza = lUser.IdImagineCurenta;
                this.txtTelefonMobilPersonal.Text = lUser.TelefonMobil;
                this.txtTelefonFixPersonal.Text = lUser.TelefonFix;
                this.txtFaxPersonal.Text = lUser.Fax;
                this.txtEmailPersonal.Text = lUser.AdresaMail;
                this.txtContYMPersonal.Text = lUser.ContYM;
                this.txtPaginaWebPersonal.Text = lUser.PaginaWeb;
                this.txtSkypePersonal.Text = lUser.ContSkype;
                this.txtInfoContactPersonal.Text = lUser.InfoContact;
                this.ctrlCuloarePersonal.Initializeaza(lUser.Culoare);
                this.cboRolPersonal.SelectedIndex = lUser.Rol;
                this.ctrlDataAngajarePersonal.DataAfisata = lUser.DataAngajare;
                this.txtContStomaPersonal.Text = lUser.ContStoma;
                this.txtParolaPersonal.Text = lUser.ParolaStoma;
                this.txtObservatiiPersonal.Text = lUser.Observatii;
                this.cboTipContract.SelectedIndex = lUser.TipContract;
                this.txtNrOreNorma.Text = lUser.OreNorma.ToString();
                this.ctrlDataContract.DataAfisata = lUser.DataContract;
                this.ctrlDataIncetareContract.DataAfisata = lUser.DataIncetareContract;
                this.txtNrContract.Text = lUser.NumarContract;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void ChkMasculinPersonal_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkFemininPersonal.Checked = !chkMasculinPersonal.Checked;
                seteazaVizibilitateNumeFata(this.chkFemininPersonal.Checked);
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

        private void ChkFemininPersonal_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkMasculinPersonal.Checked = !chkFemininPersonal.Checked;
                seteazaVizibilitateNumeFata(this.chkFemininPersonal.Checked);
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

        private void BtnLocatieUtilizator_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormAdresaISTOMA.Afiseaza(this.GetFormParinte(), this.lUser);

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

        private void BtnStergePozaPersonal_Click(object sender, EventArgs e)
        {

        }

        private void BtnDosarPozaPersonal_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metode private

        private void initListe()
        {
            this.cboTitulaturaPersonal.DataSource = BDefinitiiGenerale.StructTitulatura.getListaTitulaturi();
            this.cboStareCivilaPersonal.DataSource = BDefinitiiGenerale.StructStareCivila.getListaStariCivile();
            this.cboNrCopiiPersonal.InitializeazaListaNumerica(0, 12, 1);
            this.cboTipActPersonal.DataSource = StructTipActIdentitate.GetList();
            this.cboTipEducatiePersonal.DataSource = BDefinitiiGenerale.StructNivelScolorizare.getListaNiveluriScolarizare();
            this.cboRolPersonal.DataSource = BDefinitiiGenerale.StructRol.getListaRol();
            this.cboTipContract.DataSource = BDefinitiiGenerale.StructTipContract.GetList();

            ComboBox[] lista = { this.cboTitulaturaPersonal, this.cboStareCivilaPersonal, this.cboNrCopiiPersonal, this.cboTipActPersonal, this.cboTipEducatiePersonal, this.cboRolPersonal, this.cboTipContract };
            foreach (var elem in lista)
            {
                elem.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void seteazaVizibilitateNumeFata(bool esteFeminin)
        {
            this.lblNumeDeFataPersonal.Visible = esteFeminin;
            this.txtNumeDeFataPersonal.Visible = esteFeminin;
            if (this.lUser != null)
                this.txtNumeDeFataPersonal.Text = this.lUser.NumeDeFata;
        }

        private bool getSexPersonal(bool pEsteFeminin)
        {
            if (this.lUser.Sex == 0)
                return false;
            return this.lUser.Sex == 1 ? !pEsteFeminin : pEsteFeminin;
        }

        private int getSexSelectat()
        {
            if (this.chkFemininPersonal.Checked)
                return 2;
            else if (this.chkMasculinPersonal.Checked)
                return 1;
            return 0;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNumePersonal, this.lblNumePersonal);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtPrenumePersonal, this.lblPrenumePersonal);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.cboRolPersonal, this.lblRolPersonal);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstAlta = { this.txtNumePersonal, this.txtPrenumePersonal, this.cboRolPersonal };

            foreach (var control in lstAlta)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }

        }

        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            bool esteValid = BUtilizator.SuntInformatiileNecesareCoerente(this.txtNumePersonal.Text, this.txtPrenumePersonal.Text, this.cboRolPersonal.SelectedIndex);

            if (this.lUser == null)
            {
                if (esteValid)
                {
                    BUtilizator.Add(this.txtNumePersonal.Text, this.txtPrenumePersonal.Text, this.txtCnpPersonal.Text, this.ctrlDataNasteriiPersonal.DataAfisata, getSexSelectat(), this.cboTitulaturaPersonal.SelectedIndex, this.txtNumeDeFataPersonal.Text, this.txtSupranumePersonal.Text, this.cboStareCivilaPersonal.SelectedIndex, this.cboNrCopiiPersonal.SelectedIndex, this.cboTipEducatiePersonal.SelectedIndex, this.txtScoalaPersonal.Text, 0, 0, 0, 0, this.cboRolPersonal.SelectedIndex, this.ctrlProfesiePersonal.IdObiectAfisajCorespunzator, this.txtObservatiiPersonal.Text, this.txtTelefonFixPersonal.Text, this.txtTelefonMobilPersonal.Text, this.txtFaxPersonal.Text, this.txtSkypePersonal.Text, this.txtContYMPersonal.Text, this.txtEmailPersonal.Text, this.txtPaginaWebPersonal.Text, this.txtInfoContactPersonal.Text, 0, this.txtContStomaPersonal.Text, this.txtParolaPersonal.Text, this.ctrlCuloarePersonal.CuloareARGB, this.cboTipActPersonal.SelectedIndex, this.txtSerieActPersonal.Text, this.txtNrActPersonal.Text, 0, 0, this.ctrlDataAngajarePersonal.DataAfisata, this.cboTipContract.SelectedIndex, this.ctrlDataContract.DataAfisata, this.ctrlDataIncetareContract.DataAfisata, CUtil.GetTextInt32(this.txtNrOreNorma.Text), this.txtNrContract.Text, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                lUser.Nume = this.txtNumePersonal.Text;
                lUser.Titulatura = this.cboTitulaturaPersonal.SelectedIndex;
                lUser.Prenume = this.txtPrenumePersonal.Text;
                lUser.Porecla = this.txtSupranumePersonal.Text;
                lUser.Sex = getSexSelectat();
                lUser.NumeDeFata = this.txtNumeDeFataPersonal.Text;
                lUser.StareCivila = this.cboStareCivilaPersonal.SelectedIndex;
                lUser.Educatie = this.cboTipEducatiePersonal.SelectedIndex;
                lUser.NumarCopii = this.cboNrCopiiPersonal.SelectedIndex;
                lUser.CNP = this.txtCnpPersonal.Text;
                lUser.TipActIdentitate = this.cboTipActPersonal.SelectedIndex;
                lUser.SerieActIdentitate = this.txtSerieActPersonal.Text;
                lUser.NumarActIdentitate = this.txtNrActPersonal.Text;
                lUser.Scoala = this.txtScoalaPersonal.Text;
                lUser.IdProfesie = this.ctrlProfesiePersonal.IdObiectAfisajCorespunzator;
                lUser.DataNastere = this.ctrlDataNasteriiPersonal.DataAfisata;
                //this.cboNationalitatePersonal.DataSource=BDefinitiiGenerale.nat
                // lUser.IdImagineCurenta = this.ctrlImaginePersonal.IdPoza;
                // this.txtTaraPersonal.Goleste();
                // this.txtJudetPersonal.Goleste();
                // this.txtLocalitatePersonal.Text = lUser.IdLocalitateNastere.ToString();
                lUser.TelefonMobil = this.txtTelefonMobilPersonal.Text;
                lUser.TelefonFix = this.txtTelefonFixPersonal.Text;
                lUser.Fax = this.txtFaxPersonal.Text;
                lUser.AdresaMail = this.txtEmailPersonal.Text;
                lUser.ContYM = this.txtContYMPersonal.Text;
                lUser.PaginaWeb = this.txtPaginaWebPersonal.Text;
                lUser.ContSkype = this.txtSkypePersonal.Text;
                lUser.InfoContact = this.txtInfoContactPersonal.Text;
                lUser.Culoare = this.ctrlCuloarePersonal.CuloareARGB;
                lUser.DataAngajare = this.ctrlDataAngajarePersonal.DataAfisata;
                lUser.ContStoma = this.txtContStomaPersonal.Text;
                lUser.ParolaStoma = this.txtParolaPersonal.Text;
                lUser.Observatii = this.txtObservatiiPersonal.Text;
                lUser.Rol = this.cboRolPersonal.SelectedIndex;
                lUser.TipContract = this.cboTipContract.SelectedIndex;
                lUser.DataContract = this.ctrlDataContract.DataAfisata;
                lUser.DataIncetareContract = this.ctrlDataIncetareContract.DataAfisata;
                lUser.OreNorma = CUtil.GetTextInt32(this.txtNrOreNorma.Text);
                lUser.NumarContract = this.txtNrContract.Text;
                if (esteValid)
                {
                    this.lUser.UpdateAll();
                }
                else
                {
                    seteazaAlerta();
                }
            }
            return esteValid;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtNumePersonal.AllowModification(this.lEcranInModificare);
            this.cboTitulaturaPersonal.AllowModification(this.lEcranInModificare);
            this.txtPrenumePersonal.AllowModification(this.lEcranInModificare);
            this.txtSupranumePersonal.AllowModification(this.lEcranInModificare);
            this.chkFemininPersonal.AllowModification(this.lEcranInModificare);
            this.chkMasculinPersonal.AllowModification(this.lEcranInModificare);
            this.txtNumeDeFataPersonal.AllowModification(this.lEcranInModificare);
            this.txtNumeDeFataPersonal.AllowModification(this.lEcranInModificare);
            this.cboStareCivilaPersonal.AllowModification(this.lEcranInModificare);
            this.cboNrCopiiPersonal.AllowModification(this.lEcranInModificare);
            this.txtCnpPersonal.AllowModification(this.lEcranInModificare);
            this.cboTipActPersonal.AllowModification(this.lEcranInModificare);
            this.txtSerieActPersonal.AllowModification(this.lEcranInModificare);
            this.txtNrActPersonal.AllowModification(this.lEcranInModificare);
            this.cboTipEducatiePersonal.AllowModification(this.lEcranInModificare);
            this.txtScoalaPersonal.AllowModification(this.lEcranInModificare);
            this.ctrlProfesiePersonal.AllowModification(this.lEcranInModificare);
            this.ctrlDataNasteriiPersonal.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobilPersonal.AllowModification(this.lEcranInModificare);
            this.txtTelefonFixPersonal.AllowModification(this.lEcranInModificare);
            this.txtFaxPersonal.AllowModification(this.lEcranInModificare);
            this.txtEmailPersonal.AllowModification(this.lEcranInModificare);
            this.txtContYMPersonal.AllowModification(this.lEcranInModificare);
            this.txtPaginaWebPersonal.AllowModification(this.lEcranInModificare);
            this.txtSkypePersonal.AllowModification(this.lEcranInModificare);
            this.txtInfoContactPersonal.AllowModification(this.lEcranInModificare);
            this.ctrlCuloarePersonal.AllowModification(this.lEcranInModificare);
            this.cboRolPersonal.AllowModification(this.lEcranInModificare);
            this.ctrlDataAngajarePersonal.AllowModification(this.lEcranInModificare);
            this.txtContStomaPersonal.AllowModification(this.lEcranInModificare);
            this.txtParolaPersonal.AllowModification(this.lEcranInModificare);
            this.txtObservatiiPersonal.AllowModification(this.lEcranInModificare);
            this.btnDosarPozaPersonal.AllowModification(this.lEcranInModificare);
            this.btnStergePozaPersonal.AllowModification(this.lEcranInModificare);
            this.cboTipContract.AllowModification(this.lEcranInModificare);
            this.ctrlDataContract.AllowModification(this.lEcranInModificare);
            this.ctrlDataIncetareContract.AllowModification(this.lEcranInModificare);
            this.txtNrContract.AllowModification(this.lEcranInModificare);
            this.txtNrOreNorma.AllowModification(this.lEcranInModificare);
        }


        #endregion


    }
}
