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
            this.lblEmailPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblSkypePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblCuloarePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Culoare);
            this.lblRolPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblDataAngajarePersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataAngajare);
            this.lblContStomaPersonal.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cont);
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
                this.txtEmailPersonal.Goleste();
                this.txtSkypePersonal.Goleste();
                this.ctrlCuloarePersonal.Goleste();
                this.ctrlDataAngajarePersonal.Goleste();
                this.txtContStomaPersonal.Goleste();
                this.txtObservatiiPersonal.Goleste();
                this.txtNrOreNorma.Goleste();
                this.ctrlDataContract.Goleste();
                this.ctrlDataIncetareContract.Goleste();
                this.txtNrContract.Goleste();
            }
            else
            {

                this.txtNumePersonal.Text = lUser.Nume;
                //this.cboTitulaturaPersonal.SelectedIndex = lUser.Titulatura;
                this.txtPrenumePersonal.Text = lUser.Prenume;
                this.txtSupranumePersonal.Text = lUser.Porecla;
                this.chkFemininPersonal.Checked = lUser.Sex == EnumSex.Femeiesc;
                this.chkMasculinPersonal.Checked = lUser.Sex == EnumSex.Barbatesc;
                seteazaVizibilitateNumeFata(lUser.Sex == EnumSex.Femeiesc);
                this.cboStareCivilaPersonal.SelectedItem = lUser.StareCivila;
                this.cboNrCopiiPersonal.SelectedIndex = lUser.NumarCopii;
                this.txtCnpPersonal.Text = lUser.CNP;
                this.cboTipActPersonal.SelectedIndex = lUser.TipActIdentitate;
                this.txtSerieActPersonal.Text = lUser.SerieActIdentitate;
                this.txtNrActPersonal.Text = lUser.NumarActIdentitate;
                this.cboTipEducatiePersonal.SelectedValue = Convert.ToString(Convert.ToInt32(lUser.Educatie));
                this.txtScoalaPersonal.Text = lUser.Scoala;
                if (this.lUser.IdProfesie != 0)
                {
                    this.ctrlProfesiePersonal.Initializeaza(new StructIdDenumire(this.lUser.IdProfesie, BProfesii.getProfesie(this.lUser.IdProfesie, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }

                this.ctrlDataNasteriiPersonal.DataAfisata = lUser.DataNastere;
                //this.ctrlImaginePersonal.IdPoza = lUser.IdImagineCurenta;
                this.txtTelefonMobilPersonal.Text = lUser.TelefonMobil;
                this.txtTelefonFixPersonal.Text = lUser.TelefonFix;
                this.txtEmailPersonal.Text = lUser.AdresaMail;
                this.txtSkypePersonal.Text = lUser.ContSkype;
                this.ctrlCuloarePersonal.Initializeaza(lUser.Culoare);
                this.cboRolPersonal.SelectedValue = Convert.ToString(Convert.ToInt32(lUser.Rol));
                this.ctrlDataAngajarePersonal.DataAfisata = lUser.DataAngajare;
                this.txtContStomaPersonal.Text = lUser.ContStoma;
                this.txtObservatiiPersonal.Text = lUser.Observatii;
                this.cboTipContract.SelectedValue = Convert.ToString(Convert.ToInt32(lUser.TipContract));
                this.txtNrOreNorma.Text = lUser.OreNorma.ToString();
                this.ctrlDataContract.DataAfisata = lUser.DataContract;
                this.ctrlDataIncetareContract.DataAfisata = lUser.DataIncetareContract;
                this.txtNrContract.Text = lUser.NumarContract.ToString();
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
        }

        private void seteazaVizibilitateNumeFata(bool esteFeminin)
        {
            this.lblNumeDeFataPersonal.Visible = esteFeminin;
            this.txtNumeDeFataPersonal.Visible = esteFeminin;
            if (this.lUser != null)
                this.txtNumeDeFataPersonal.Text = this.lUser.NumeDeFata;
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

        private CDefinitiiComune.EnumSex getSexSelectat()
        {
            if (this.chkFemininPersonal.Checked)
                return EnumSex.Femeiesc;

            if (this.chkMasculinPersonal.Checked)
                return EnumSex.Barbatesc;

            return EnumSex.Nedefinit;
        }

        private CDefinitiiComune.EnumTitulatura getTitulatura()
        {
            if (this.cboTitulaturaPersonal.SelectedItem == null)
                return EnumTitulatura.Nedefinit;

            return ((BDefinitiiGenerale.StructTitulatura)this.cboTitulaturaPersonal.SelectedItem).Id;
        }

        private CDefinitiiComune.EnumStareCivila getStareCivila()
        {
            if (this.cboStareCivilaPersonal.SelectedItem == null)
                return EnumStareCivila.Nespecificat;

            return ((BDefinitiiGenerale.StructStareCivila)this.cboStareCivilaPersonal.SelectedItem).Id;
        }

        internal bool Salveaza()
        {
            bool esteValid = BUtilizator.SuntInformatiileNecesareCoerente(this.txtNumePersonal.Text, getRol());

            if (this.lUser == null)
            {
                if (esteValid)
                {
                    BUtilizator.Add(this.txtNumePersonal.Text, this.txtPrenumePersonal.Text, this.txtCnpPersonal.Text, this.ctrlDataNasteriiPersonal.DataAfisata, getSexSelectat(), getTitulatura(), this.txtNumeDeFataPersonal.Text, this.txtSupranumePersonal.Text, getStareCivila(), this.cboNrCopiiPersonal.SelectedIndex, this.cboTipEducatiePersonal.SelectedIndex, this.txtScoalaPersonal.Text, 0, 0, 0, 0, getRol(), this.ctrlProfesiePersonal.IdObiectAfisajCorespunzator, this.txtObservatiiPersonal.Text, this.txtTelefonFixPersonal.Text, this.txtTelefonMobilPersonal.Text, string.Empty, this.txtSkypePersonal.Text, string.Empty, this.txtEmailPersonal.Text, string.Empty, string.Empty, 0, this.txtContStomaPersonal.Text, string.Empty, this.ctrlCuloarePersonal.CuloareARGB, this.cboTipActPersonal.SelectedIndex, this.txtSerieActPersonal.Text, this.txtNrActPersonal.Text, 0, 0, this.ctrlDataAngajarePersonal.DataAfisata, this.cboTipContract.SelectedIndex, this.ctrlDataContract.DataAfisata, this.ctrlDataIncetareContract.DataAfisata, CUtil.GetTextInt32(this.txtNrOreNorma.Text), CUtil.GetTextInt32(this.txtNrContract.Text), null, DateTime.Today, DateTime.Today, null, 0, 0, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                lUser.Nume = this.txtNumePersonal.Text;
                lUser.Titulatura = getTitulatura();// this.cboTitulaturaPersonal.SelectedIndex;
                lUser.Prenume = this.txtPrenumePersonal.Text;
                lUser.Porecla = this.txtSupranumePersonal.Text;
                lUser.Sex = getSexSelectat();
                lUser.NumeDeFata = this.txtNumeDeFataPersonal.Text;
                lUser.StareCivila = getStareCivila();
                lUser.Educatie = (EnumNivelScolorizare)this.cboTipEducatiePersonal.GetSelectedValueAsInt32();
                lUser.NumarCopii = this.cboNrCopiiPersonal.SelectedIndex;
                lUser.CNP = this.txtCnpPersonal.Text;
                lUser.TipActIdentitate = this.cboTipActPersonal.SelectedIndex;
                lUser.SerieActIdentitate = this.txtSerieActPersonal.Text;
                lUser.NumarActIdentitate = this.txtNrActPersonal.Text;
                lUser.Scoala = this.txtScoalaPersonal.Text;
                lUser.IdProfesie = this.ctrlProfesiePersonal.IdObiectAfisajCorespunzator;
                lUser.DataNastere = this.ctrlDataNasteriiPersonal.DataAfisata;
                lUser.TelefonMobil = this.txtTelefonMobilPersonal.Text;
                lUser.TelefonFix = this.txtTelefonFixPersonal.Text;
                lUser.AdresaMail = this.txtEmailPersonal.Text;
                lUser.ContSkype = this.txtSkypePersonal.Text;
                lUser.Culoare = this.ctrlCuloarePersonal.CuloareARGB;
                lUser.DataAngajare = this.ctrlDataAngajarePersonal.DataAfisata;
                lUser.ContStoma = this.txtContStomaPersonal.Text;
                lUser.Observatii = this.txtObservatiiPersonal.Text;
                lUser.Rol = getRol(); //this.cboRolPersonal.GetAs<BDefinitiiGenerale.StructRol>(BDefinitiiGenerale.StructRol.Empty).Id;
                lUser.TipContract = (BDefinitiiGenerale.EnumTipContract)this.cboTipContract.GetSelectedValueAsInt32();
                lUser.DataContract = this.ctrlDataContract.DataAfisata;
                lUser.DataIncetareContract = this.ctrlDataIncetareContract.DataAfisata;
                lUser.OreNorma = CUtil.GetTextInt32(this.txtNrOreNorma.Text);
                lUser.NumarContract = CUtil.GetTextInt32(this.txtNrContract.Text);
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

        private EnumRol getRol()
        {
            if (this.cboRolPersonal.SelectedItem == null)
                return EnumRol.Tehnician;

            return ((BDefinitiiGenerale.StructRol)this.cboRolPersonal.SelectedItem).Id;
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
            this.txtEmailPersonal.AllowModification(this.lEcranInModificare);
            this.txtSkypePersonal.AllowModification(this.lEcranInModificare);
            this.ctrlCuloarePersonal.AllowModification(this.lEcranInModificare);
            this.cboRolPersonal.AllowModification(this.lEcranInModificare);
            this.ctrlDataAngajarePersonal.AllowModification(this.lEcranInModificare);
            this.txtContStomaPersonal.AllowModification(this.lEcranInModificare);
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
