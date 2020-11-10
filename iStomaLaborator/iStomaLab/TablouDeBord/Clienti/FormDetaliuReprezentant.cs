using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuReprezentant : FormPersonalizat
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

        private FormDetaliuReprezentant(BClientiReprezentanti pReprezentant, BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lReprezentant = pReprezentant;
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
            this.ctrlValidareAnulareReprezentant.Validare += CtrlValidareAnulareReprezentant_Validare;
            this.chkFemininReprezentant.CheckedChanged += ChkFemininReprezentant_CheckedChanged;
            this.chkMasculinReprezentant.CheckedChanged += ChkMasculinReprezentant_CheckedChanged;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNumeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenumeReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblSexReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sex);
            this.chkFemininReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin);
            this.chkMasculinReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin);
            this.lblDataNasteriiReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataNasterii);
            this.lblCnpReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CNP);
            //this.lblRolReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rol);
            this.lblTelefonMobilReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil);
            this.lblEmailReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email);
            this.lblObservatiiReprezentant.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
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
        
            this.txtNumeReprezentant.CapitalizeazaPrimaLitera = true;
            this.txtPrenumeReprezentant.CapitalizeazaPrimaLitera = true;

            initListe();

            this.txtNumeReprezentant.Focus();

            if (this.lReprezentant == null)
            {
                this.txtNumeReprezentant.Goleste();
                this.txtPrenumeReprezentant.Goleste();
                this.chkFemininReprezentant.Checked = false;
                this.chkMasculinReprezentant.Checked = false;
                this.ctrlDataNasteriiReprezentant.Goleste();
                this.txtCnpReprezentant.Goleste();
                this.txtTelefonMobilReprezentant.Goleste();
                this.txtEmailReprezentant.Goleste();
                this.txtObservatiiReprezentant.Goleste();
            }
            else
            {
                this.cboTitulaturaReprezentant.SelectedIndex = lReprezentant.Titulatura;
                this.txtNumeReprezentant.Text = lReprezentant.Nume;
                this.txtPrenumeReprezentant.Text = lReprezentant.Prenume;
                this.chkFemininReprezentant.Checked = getSexPersonal(true);
                this.chkMasculinReprezentant.Checked = getSexPersonal(false);
                //if (this.lReprezentant.IdProfesie != 0)
                //{
                //    this.ctrlProfesie.Initializeaza(new StructIdDenumire(this.lReprezentant.IdProfesie, BProfesii.getProfesie(this.lReprezentant.IdProfesie, null).Denumire), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                //}else
                //{
                //    this.ctrlProfesie.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                //}
                this.ctrlDataNasteriiReprezentant.DataAfisata = lReprezentant.DataNastere;

                this.txtCnpReprezentant.Text = lReprezentant.CNP;
                //this.cboRolReprezentant.SelectedIndex = this.lReprezentant.Rol;
                this.txtTelefonMobilReprezentant.Text = lReprezentant.TelefonMobil;
                this.txtEmailReprezentant.Text = lReprezentant.AdresaMail;
                this.txtObservatiiReprezentant.Text = lReprezentant.Observatii;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareReprezentant_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.Salveaza())
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

        private void ChkMasculinReprezentant_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkFemininReprezentant.Checked = !chkMasculinReprezentant.Checked;
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
            this.cboTitulaturaReprezentant.DataSource = BDefinitiiGenerale.StructTitulatura.getListaTitulaturiCuEmpty();
            //this.cboRolReprezentant.DataSource = BDefinitiiGenerale.StructRol.getListaRol();

            //ComboBox[] lista = { this.cboTitulaturaReprezentant, this.cboRolReprezentant };
            //foreach (var elem in lista)
            //{
            //    elem.DropDownStyle = ComboBoxStyle.DropDownList;
            //}
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

        public static bool Afiseaza(Form pEcranPariente, BClientiReprezentanti pReprezentant, BClienti pClient)
        {
            using (FormDetaliuReprezentant ecran = new FormDetaliuReprezentant(pReprezentant, pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            bool esteValid = BClientiReprezentanti.SuntInformatiileNecesareCoerente(this.lClient.Id, this.txtNumeReprezentant.Text);

            if (this.lReprezentant == null)
            {
                if (esteValid)
                {
                    BClientiReprezentanti.Add(this.lClient.Id, this.txtCnpReprezentant.Text, this.txtNumeReprezentant.Text, this.txtPrenumeReprezentant.Text, this.ctrlDataNasteriiReprezentant.DataAfisata, getSexSelectat(), this.cboTitulaturaReprezentant.SelectedIndex, string.Empty, string.Empty, this.txtTelefonMobilReprezentant.Text, string.Empty, string.Empty, string.Empty, string.Empty, this.txtEmailReprezentant.Text, CDefinitiiComune.EnumRol.MedicTitular, 0, 0, string.Empty, 0, 0, 0, 0, 0, this.txtObservatiiReprezentant.Text, null);
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
                lReprezentant.Sex = getSexSelectat();
                lReprezentant.DataNastere = this.ctrlDataNasteriiReprezentant.DataAfisata;
                lReprezentant.CNP = this.txtCnpReprezentant.Text;
                //lReprezentant.Rol = this.cboRolReprezentant.SelectedIndex;
                lReprezentant.TelefonMobil = this.txtTelefonMobilReprezentant.Text;
                lReprezentant.AdresaMail = this.txtEmailReprezentant.Text;
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
        }


        #endregion

    }
}
