using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using CCL.UI;
using BLL.iStomaLab.Referinta;
using CCL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;
using BLL.iStomaLab.Comune;
using CDL.iStomaLab;
using System.IO;

namespace iStomaLab.Setari.Personal
{
    public partial class ControlDetaliuPersonal : UserControlPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuPersonal()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.picPozaPersonal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.ctrlSex.SexModificat += CtrlSex_SexModificat;
            this.txtCnp.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtContStoma.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtEmail.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtEmisDe.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtIban.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtNr.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtNrContract.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtNume.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtObservatii.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtOreNorma.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtPrenume.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtSerie.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtTelefonMobil.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.txtZileConcediu.AfterUpdate += TxtZonaUpdate_AfterUpdate;
            this.ctrlCautareBanca.CerereUpdate += CtrlCautareBanca_CerereUpdate;
            this.btnSchimbaParola.Click += BtnSchimbaParola_Click;
            this.btnDosarPozaPersonal.Click += BtnDosarPozaPersonal_Click;
            this.btnStergePozaPersonal.Click += BtnStergePozaPersonal_Click;
        }

        private void initTextML()
        {
            this.lblNume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblSex.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.lblDataNasterii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblCnp.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP);
            this.rbBI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.BI);
            this.rbCI.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CI);
            this.lblSerie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Serie);
            this.lblNr.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nr);
            this.lblEmisDe.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EmisDe);
            this.lblTelefonMobil.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblEmail.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblRol.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblContStoma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cont);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblTipContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TipContract);
            this.lblNrContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrContract);
            this.lblDataContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataContract);
            this.lblDataAngajare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataAngajare);
            this.lblDataIncetareContract.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataIncetareContract);
            this.lblOreNorma.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.OreNorma);
            this.lblZileConcediu.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ZileConcediu);
            this.lblIban.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.IBAN);
            this.lblBanca.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca);
            this.lblValabilitate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Valabilitate);
            this.lblAdresa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa);
            this.btnSchimbaParola.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SchimbaParola);
        }

        public void Initializeaza(BUtilizator pUtilizator)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lUtilizator = pUtilizator;

            initListe();

            this.cboTitulatura.SelectedItem = this.lUtilizator.Titulatura;
            this.txtNume.Text = this.lUtilizator.Nume;
            this.txtPrenume.Text = this.lUtilizator.Prenume;
            this.ctrlSex.Initializeaza(this.lUtilizator.Sex);
            this.ctrlDataNasterii.DataAfisata = this.lUtilizator.DataNastere;
            this.txtCnp.Text = this.lUtilizator.CNP;
            this.rbBI.Checked = this.lUtilizator.TipActIdentitate == 1;
            this.rbCI.Checked = this.lUtilizator.TipActIdentitate == 1;
            this.txtSerie.Text = this.lUtilizator.SerieActIdentitate;
            this.txtNr.Text = this.lUtilizator.NumarActIdentitate;
            this.txtEmisDe.Text = this.lUtilizator.EmisDe;
            this.ctrlValabilitateInceput.DataAfisata = this.lUtilizator.ValabilitateInceput;
            this.ctrlValabilitateSfarsit.DataAfisata = this.lUtilizator.ValabilitateSfarsit;
            this.txtTelefonMobil.Text = this.lUtilizator.TelefonMobil;
            this.txtEmail.Text = this.lUtilizator.AdresaMail;
            this.cboRol.SelectedItem = this.lUtilizator.Rol;
            this.txtContStoma.Text = this.lUtilizator.ContStoma;
            this.txtContStoma.ReadOnly = this.lUtilizator.EsteADMIN();
            this.txtObservatii.Text = this.lUtilizator.Observatii;
            this.cboTipContract.SelectedItem = this.lUtilizator.TipContract;
            this.txtNrContract.Text = this.lUtilizator.NumarContract.ToString();
            this.ctrlDataContract.DataAfisata = this.lUtilizator.DataContract;
            this.ctrlDataAngajare.DataAfisata = this.lUtilizator.DataAngajare;
            this.ctrlDataIncetareContract.DataAfisata = this.lUtilizator.DataIncetareContract;
            this.txtOreNorma.Text = this.lUtilizator.OreNorma.ToString();
            this.txtZileConcediu.Text = this.lUtilizator.NumarZileCOAgreate.ToString();
            this.txtIban.Text = this.lUtilizator.Iban;

            if (this.lUtilizator.IdAdresa == 0)
                this.ctrlAdresa.Initializeaza(null, EnumTipObiect.Utilizator, this.lUtilizator.Id, BAdrese.EnumTipAdresa.Principala);
            else
                this.ctrlAdresa.Initializeaza(BAdrese.getAdresa(this.lUtilizator.IdAdresa, null), EnumTipObiect.Utilizator, this.lUtilizator.Id, BAdrese.EnumTipAdresa.Principala);

            if (this.lUtilizator.IdBanca == 0)
                this.ctrlCautareBanca.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            else
                this.ctrlCautareBanca.Initializeaza(new StructIdDenumire(this.lUtilizator.IdBanca, BBanci.getBanca(this.lUtilizator.IdBanca, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);

            initDosarPozaPersonal();

            finalizeazaIncarcarea();
        }

        private void initDosarPozaPersonal()
        {
            Image poza = this.lUtilizator.GetDosarPozaPersonal(null);
            this.picPozaPersonal.Image = poza;

            this.btnStergePozaPersonal.Visible = poza != null;
        }


        #endregion

        #region Evenimente

        private void CtrlSex_SexModificat(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lUtilizator.Sex = getSexSelectat();
                this.lUtilizator.UpdateAll();
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

        private void BtnSchimbaParola_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                IHMUtile._AccesTotal.SchimbaParolaISTOMA(this.lUtilizator.Id);
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

        private void BtnDosarPozaPersonal_Click(object sender, EventArgs e)
        {
            FileInfo imagine = IHMUtile.GetFisierUnic(this.GetFormParinte());

            if (imagine != null)
            {
                this.lUtilizator.UpdateDosarPozaPersonal(imagine, null);
                initDosarPozaPersonal();
            }
        }

        private void BtnStergePozaPersonal_Click(object sender, EventArgs e)
        {
            if (this.picPozaPersonal.Image != null)
            {
                if (IHMUtile.ConfirmareStergere(this.GetFormParinte()))
                {
                    this.lUtilizator.StergeDosarPozaPersonal(null);
                    initDosarPozaPersonal();
                }
            }
        }

        #endregion

        #region Metode private

        private void CtrlCautareBanca_CerereUpdate(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                UpdateUtilizator();
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

        private void TxtZonaUpdate_AfterUpdate(Control sender, string sNumeProprietateAtasata, string sNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                UpdateUtilizator();
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


        private void initListe()
        {
            this.cboTitulatura.BeginUpdate();
            this.cboTitulatura.DataSource = BDefinitiiGenerale.StructTitulatura.getListaTitulaturi();
            this.cboTitulatura.EndUpdate();

            this.cboRol.BeginUpdate();
            this.cboRol.DataSource = BDefinitiiGenerale.StructRol.getListaRol();
            this.cboRol.EndUpdate();

            this.cboTipContract.BeginUpdate();
            this.cboTipContract.DataSource = BDefinitiiGenerale.StructTipContract.GetList();
            this.cboTipContract.EndUpdate();
        }

        private CDefinitiiComune.EnumSex getSexSelectat()
        {
            return this.ctrlSex.GetSex();
        }

        private CDefinitiiComune.EnumTitulatura getTitulatura()
        {
            if (this.cboTitulatura.SelectedItem == null)
                return EnumTitulatura.Nedefinit;

            return ((BDefinitiiGenerale.StructTitulatura)this.cboTitulatura.SelectedItem).Id;
        }

        #endregion

        #region Metode publice

        internal void UpdateUtilizator()
        {
            this.lUtilizator.Nume = this.txtNume.Text;
            this.lUtilizator.Prenume = this.txtPrenume.Text;
            this.lUtilizator.Titulatura = getTitulatura();// this.cboTitulatura.SelectedIndex;
            this.lUtilizator.Sex = getSexSelectat();// this.rbFeminin.Checked ? 1 : 0;
            this.lUtilizator.DataNastere = this.ctrlDataNasterii.DataAfisata;
            this.lUtilizator.CNP = this.txtCnp.Text;
            this.lUtilizator.TipActIdentitate = this.rbBI.Checked ? 1 : 0;
            this.lUtilizator.SerieActIdentitate = this.txtSerie.Text;
            this.lUtilizator.NumarActIdentitate = this.txtNr.Text;
            this.lUtilizator.EmisDe = this.txtEmisDe.Text;
            this.lUtilizator.TelefonMobil = this.txtTelefonMobil.Text;
            this.lUtilizator.AdresaMail = this.txtEmail.Text;
            this.lUtilizator.Rol = this.cboRol.GetAs<BDefinitiiGenerale.StructRol>(BDefinitiiGenerale.StructRol.Empty).Id;
            this.lUtilizator.ContStoma = this.txtContStoma.Text;
            this.lUtilizator.Observatii = this.txtObservatii.Text;
            this.lUtilizator.TipContract = this.cboTipContract.GetAs<BDefinitiiGenerale.StructTipContract>(BDefinitiiGenerale.StructTipContract.Empty).IdEnum;
            this.lUtilizator.NumarContract = CUtil.GetAsInt32(this.txtNrContract.Text);
            this.lUtilizator.DataContract = this.ctrlDataContract.DataAfisata;
            this.lUtilizator.DataAngajare = this.ctrlDataAngajare.DataAfisata;
            this.lUtilizator.DataIncetareContract = this.ctrlDataIncetareContract.DataAfisata;
            this.lUtilizator.OreNorma = CUtil.GetAsInt32(this.txtOreNorma.Text);
            this.lUtilizator.NumarZileCOAgreate = CUtil.GetAsInt32(this.txtZileConcediu.Text);
            this.lUtilizator.Iban = this.txtIban.Text;
            this.lUtilizator.IdBanca = this.ctrlCautareBanca.IdObiectAfisajCorespunzator;
            this.lUtilizator.ValabilitateInceput = this.ctrlValabilitateInceput.DataAfisata;
            this.lUtilizator.ValabilitateSfarsit = this.ctrlValabilitateSfarsit.DataAfisata;
            this.lUtilizator.IdImagineCurenta = CUtil.GetAsInt32(this.picPozaPersonal.ImageLocation);

            this.lUtilizator.UpdateAll();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;

            this.cboTitulatura.AllowModification(this.lEcranInModificare);
            this.txtNume.AllowModification(this.lEcranInModificare);
            this.txtPrenume.AllowModification(this.lEcranInModificare);
            this.txtCnp.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobil.AllowModification(this.lEcranInModificare);
            this.txtEmail.AllowModification(this.lEcranInModificare);
            this.cboRol.AllowModification(this.lEcranInModificare);
            this.txtContStoma.AllowModification(this.lEcranInModificare && !this.lUtilizator.EsteADMIN());
            this.txtObservatii.AllowModification(this.lEcranInModificare);
            this.cboTipContract.AllowModification(this.lEcranInModificare);
            this.txtNrContract.AllowModification(this.lEcranInModificare);
            this.ctrlDataContract.AllowModification(this.lEcranInModificare);
            this.ctrlDataAngajare.AllowModification(this.lEcranInModificare);
            this.ctrlDataIncetareContract.AllowModification(this.lEcranInModificare);
            this.txtZileConcediu.AllowModification(this.lEcranInModificare);
            this.txtOreNorma.AllowModification(this.lEcranInModificare);
            this.ctrlCautareBanca.AllowModification(this.lEcranInModificare);
            this.txtIban.AllowModification(this.lEcranInModificare);
            this.txtNr.AllowModification(this.lEcranInModificare);
            this.txtSerie.AllowModification(this.lEcranInModificare);
            this.rbCI.AllowModification(this.lEcranInModificare);
            this.rbBI.AllowModification(this.lEcranInModificare);
            this.txtEmisDe.AllowModification(this.lEcranInModificare);
            this.ctrlDataNasterii.AllowModification(this.lEcranInModificare);
            this.btnStergePozaPersonal.AllowModification(this.lEcranInModificare);
            this.btnDosarPozaPersonal.AllowModification(this.lEcranInModificare);
            this.ctrlValabilitateSfarsit.AllowModification(this.lEcranInModificare);
            this.ctrlValabilitateInceput.AllowModification(this.lEcranInModificare);
            this.ctrlAdresa.AllowModification(this.lEcranInModificare);
            this.ctrlSex.AllowModification(this.lEcranInModificare);
            this.btnSchimbaParola.Visible = this.lEcranInModificare;
            this.gbInfoCI.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
