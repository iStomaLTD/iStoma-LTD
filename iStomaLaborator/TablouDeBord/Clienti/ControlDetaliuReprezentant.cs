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
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Referinta;
using CCL.UI;

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class ControlDetaliuReprezentant : UserControlPersonalizat
    {

        #region Declaratii generale

        private BClientiReprezentanti lReprezentant = null;
        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuReprezentant()
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
            this.chkFemininReprezentant.CheckedChanged += ChkFemininReprezentant_CheckedChanged;
            this.chkMasculinReprezentant.CheckedChanged += ChkMasculinReprezentant_CheckedChanged;
        }
        
        private void initTextML()
        {
            this.lblNumeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenumeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblSupranumeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Supranume);
            this.lblNumeDeFataReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NumeDeFata);
            this.lblSexReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.chkFemininReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.chkMasculinReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblStareCivilaReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StareCivila);
            this.lblNrCopiiReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NrCopii);
            this.lblScoalaReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Scoala);
            this.lblProfesieReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesie);
            this.lblDataNasteriiReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblNationalitateReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nationalitate);
            this.lblTaraReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
            this.lblJudetReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Judet);
            this.lblLocalitateReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitate);
            this.lblCnpReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP);
            this.lblRolReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblTelefonMobilReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.txtTelefonFixReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix);
            this.lblFaxReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fax);
            this.lblEmailReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblContYMReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContYM);
            this.lblSkypeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Skype);
            this.lblObservatiiReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);

        }

        public void Initializeaza(BClientiReprezentanti pReprezentant, BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lReprezentant = pReprezentant;
            this.lClient = pClient;

            this.txtNumeReprezentant.CapitalizeazaPrimaLitera = true;
            this.txtPrenumeReprezentant.CapitalizeazaPrimaLitera = true;

            initListe();

            this.txtNumeReprezentant.Focus();

            if (this.lReprezentant == null)
            {

                this.txtNumeReprezentant.Goleste();
                this.txtPrenumeReprezentant.Goleste();
                this.txtSupranumeReprezentant.Goleste();
                this.txtNumeDeFataReprezentant.Goleste();
                this.chkFemininReprezentant.Checked = false;
                this.chkMasculinReprezentant.Checked = false;
                this.txtScoalaReprezentant.Goleste();
                this.ctrlDataNasteriiReprezentant.Goleste();
                this.ctrlProfesie.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                this.ctrlTara.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                //this.ctrlLocalitate.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                //this.cboNationalitateReprezentant.DataSource=
                // this.cboJudetReprezentant.DataSource=
                this.txtCnpReprezentant.Goleste();
                this.txtTelefonMobilReprezentant.Goleste();
                this.txtTelefonFixReprezentant.Goleste();
                this.txtFaxReprezentant.Goleste();
                this.txtEmailReprezentant.Goleste();
                this.txtContYMReprezentant.Goleste();
                this.txtSkypeReprezentant.Goleste();
                this.txtObservatiiReprezentant.Goleste();
            }
            else
            {
                this.cboTitulaturaReprezentant.SelectedIndex = lReprezentant.Titulatura;
                this.txtNumeReprezentant.Text = lReprezentant.Nume;
                this.txtPrenumeReprezentant.Text = lReprezentant.Prenume;
                this.txtSupranumeReprezentant.Text = lReprezentant.Porecla;
                this.txtNumeDeFataReprezentant.Text = lReprezentant.NumeDeFata;
                this.chkFemininReprezentant.Checked = getSexPersonal(true);
                this.chkMasculinReprezentant.Checked = getSexPersonal(false);
                seteazaVizibilitateNumeFata(getSexPersonal(true));
                this.cboStareCivilaReprezentant.SelectedIndex = lReprezentant.StareCivila;
                this.cboNrCopiiReprezentant.SelectedIndex = lReprezentant.NumarCopii;
                this.txtScoalaReprezentant.Text = lReprezentant.Scoala;
                if (this.lReprezentant.IdProfesie != 0)
                {
                    this.ctrlProfesie.Initializeaza(new StructIdDenumire(this.lReprezentant.IdProfesie, BProfesii.getProfesie(this.lReprezentant.IdProfesie, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }else
                {
                    this.ctrlProfesie.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }
                this.ctrlDataNasteriiReprezentant.DataAfisata = lReprezentant.DataNastere;
                if (this.lReprezentant.IdTaraNastere != 0)
                {
                    this.ctrlTara.Initializeaza(new StructIdDenumire(this.lReprezentant.IdTaraNastere, BTari.getTara(this.lReprezentant.IdTaraNastere, null).NumeScurt), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }else
                {
                    this.ctrlTara.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }
                
                //this.cboNationalitateReprezentant.DataSource=
                // this.cboJudetReprezentant.DataSource=
                //this.cboLocalitateReprezentant.DataSource=
                this.txtCnpReprezentant.Text = lReprezentant.CNP;
                this.cboRolReprezentant.SelectedIndex = this.lReprezentant.Rol;
                this.txtTelefonMobilReprezentant.Text = lReprezentant.TelefonMobil;
                this.txtTelefonFixReprezentant.Text = lReprezentant.TelefonFix;
                this.txtFaxReprezentant.Text = lReprezentant.Fax;
                this.txtEmailReprezentant.Text = lReprezentant.AdresaMail;
                this.txtContYMReprezentant.Text = lReprezentant.ContYM;
                this.txtSkypeReprezentant.Text = lReprezentant.ContSkype;
                this.txtObservatiiReprezentant.Text = lReprezentant.Observatii;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void ChkMasculinReprezentant_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkFemininReprezentant.Checked = !chkMasculinReprezentant.Checked;
                seteazaVizibilitateNumeFata(this.chkFemininReprezentant.Checked);
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

        private void ChkFemininReprezentant_CheckedChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkMasculinReprezentant.Checked = !chkFemininReprezentant.Checked;
                seteazaVizibilitateNumeFata(this.chkFemininReprezentant.Checked);
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
        
        private void seteazaVizibilitateNumeFata(bool esteFeminin)
        {
            this.lblNumeDeFataReprezentant.Visible = esteFeminin;
            this.txtNumeDeFataReprezentant.Visible = esteFeminin;
            if (this.lReprezentant != null)
                this.txtNumeDeFataReprezentant.Text = this.lReprezentant.NumeDeFata;
        }

        private bool getSexPersonal(bool pEsteFeminin)
        {
            if (this.lReprezentant.Sex == 0)
                return false;
            return this.lReprezentant.Sex == 1 ? !pEsteFeminin : pEsteFeminin;
        }

        private int getSexSelectat()
        {
            if (this.chkFemininReprezentant.Checked)
                return 2;
            else if (this.chkMasculinReprezentant.Checked)
                return 1;
            return 0;
        }

        private void initListe()
        {
            this.cboTitulaturaReprezentant.DataSource = BDefinitiiGenerale.StructTitulatura.getListaTitulaturi();
            this.cboStareCivilaReprezentant.DataSource = BDefinitiiGenerale.StructStareCivila.getListaStariCivile();
            this.cboNrCopiiReprezentant.InitializeazaListaNumerica(0, 12, 1);
            this.cboRolReprezentant.DataSource = BDefinitiiGenerale.StructRol.getListaRol();

            ComboBox[] lista = { this.cboTitulaturaReprezentant, this.cboStareCivilaReprezentant, this.cboNrCopiiReprezentant, this.cboRolReprezentant };
            foreach (var elem in lista)
            {
                elem.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNumeReprezentant, this.lblNumeReprezentant);
            if (string.IsNullOrEmpty(this.txtNumeReprezentant.Text))
            {
                this.txtNumeReprezentant.Focus();
            }
        }

        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            bool esteValid = BClientiReprezentanti.SuntInformatiileNecesareCoerente(this.lClient.Id, this.txtNumeReprezentant.Text);

            if (this.lReprezentant == null)
            {
                if (esteValid)
                {
                    BClientiReprezentanti.Add(this.lClient.Id, this.txtCnpReprezentant.Text, this.txtNumeReprezentant.Text, this.txtPrenumeReprezentant.Text, this.ctrlDataNasteriiReprezentant.DataAfisata, getSexSelectat(), this.cboTitulaturaReprezentant.SelectedIndex, this.txtNumeDeFataReprezentant.Text, this.txtSupranumeReprezentant.Text, this.txtTelefonMobilReprezentant.Text, this.txtTelefonFixReprezentant.Text, this.txtFaxReprezentant.Text, this.txtSkypeReprezentant.Text, this.txtContYMReprezentant.Text, this.txtEmailReprezentant.Text, this.cboRolReprezentant.SelectedIndex, this.cboStareCivilaReprezentant.SelectedIndex, this.cboNrCopiiReprezentant.SelectedIndex, this.txtScoalaReprezentant.Text, 0, this.ctrlTara.IdObiectAfisajCorespunzator, 0, 0, this.ctrlProfesie.IdObiectAfisajCorespunzator, this.txtObservatiiReprezentant.Text, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                lReprezentant.Titulatura = this.cboTitulaturaReprezentant.SelectedIndex;
                lReprezentant.Nume = this.txtNumeReprezentant.Text;
                lReprezentant.Prenume = this.txtPrenumeReprezentant.Text;
                lReprezentant.Porecla = this.txtSupranumeReprezentant.Text;
                lReprezentant.NumeDeFata = this.txtNumeDeFataReprezentant.Text;
                lReprezentant.Sex = getSexSelectat();
                lReprezentant.StareCivila = this.cboStareCivilaReprezentant.SelectedIndex;
                lReprezentant.NumarCopii = this.cboNrCopiiReprezentant.SelectedIndex;
                lReprezentant.Scoala = this.txtScoalaReprezentant.Text;
                lReprezentant.IdProfesie = this.ctrlProfesie.IdObiectAfisajCorespunzator;
                lReprezentant.DataNastere = this.ctrlDataNasteriiReprezentant.DataAfisata;
                //this.cboNationalitateReprezentant.DataSource=
                lReprezentant.IdTaraNastere = this.ctrlTara.IdObiectAfisajCorespunzator;
                // this.cboJudetReprezentant.DataSource=
                //this.cboLocalitateReprezentant.DataSource=
                lReprezentant.CNP = this.txtCnpReprezentant.Text;
                lReprezentant.Rol = this.cboRolReprezentant.SelectedIndex;
                lReprezentant.TelefonMobil = this.txtTelefonMobilReprezentant.Text;
                lReprezentant.TelefonFix = this.txtTelefonFixReprezentant.Text;
                lReprezentant.Fax = this.txtFaxReprezentant.Text;
                lReprezentant.AdresaMail = this.txtEmailReprezentant.Text;
                lReprezentant.ContYM = this.txtContYMReprezentant.Text;
                lReprezentant.ContSkype = this.txtSkypeReprezentant.Text;
                lReprezentant.Observatii = this.txtObservatiiReprezentant.Text;
                if (esteValid)
                {
                    this.lReprezentant.UpdateAll();
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
            this.cboTitulaturaReprezentant.AllowModification(this.lEcranInModificare);
            this.txtNumeReprezentant.AllowModification(this.lEcranInModificare);
            this.txtPrenumeReprezentant.AllowModification(this.lEcranInModificare);
            this.txtSupranumeReprezentant.AllowModification(this.lEcranInModificare);
            this.txtNumeDeFataReprezentant.AllowModification(this.lEcranInModificare);
            this.chkFemininReprezentant.AllowModification(this.lEcranInModificare);
            this.chkMasculinReprezentant.AllowModification(this.lEcranInModificare);
            this.cboStareCivilaReprezentant.AllowModification(this.lEcranInModificare);
            this.cboNrCopiiReprezentant.AllowModification(this.lEcranInModificare);
            this.txtScoalaReprezentant.AllowModification(this.lEcranInModificare);
            this.ctrlProfesie.AllowModification(this.lEcranInModificare);
            this.ctrlDataNasteriiReprezentant.AllowModification(this.lEcranInModificare);
            this.cboNationalitateReprezentant.AllowModification(this.lEcranInModificare);
            this.ctrlTara.AllowModification(this.lEcranInModificare);
            this.cboJudetReprezentant.AllowModification(this.lEcranInModificare);
            this.ctrlLocalitate.AllowModification(this.lEcranInModificare);
            this.txtCnpReprezentant.AllowModification(this.lEcranInModificare);
            this.cboRolReprezentant.AllowModification(this.lEcranInModificare);
            this.txtTelefonMobilReprezentant.AllowModification(this.lEcranInModificare);
            this.txtTelefonFixReprezentant.AllowModification(this.lEcranInModificare);
            this.txtFaxReprezentant.AllowModification(this.lEcranInModificare);
            this.txtEmailReprezentant.AllowModification(this.lEcranInModificare);
            this.txtContYMReprezentant.AllowModification(this.lEcranInModificare);
            this.txtSkypeReprezentant.AllowModification(this.lEcranInModificare);
            this.txtObservatiiReprezentant.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
