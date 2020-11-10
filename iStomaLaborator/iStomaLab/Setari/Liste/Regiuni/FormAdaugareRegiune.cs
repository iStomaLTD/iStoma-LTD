using BLL.iStomaLab;
using BLL.iStomaLab.Referinta;
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

namespace iStomaLab.Setari.Liste.Regiuni
{
    public partial class FormAdaugareRegiune : FormPersonalizat
    {

        #region Declaratii generale

        private BRegiuni lRegiune = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdaugareRegiune(BRegiuni pRegiune)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lRegiune = pRegiune;

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
            this.ctrlValidareAnulareRegiune.Validare += CtrlValidareAnulareRegiune_Validare;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiuni);
            this.lblDenumireRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblTaraRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
            this.lblAbreviereRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere);
            this.lblPrefixTelefonicRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic);
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

            if (this.lRegiune == null)
            {
                this.txtDenumireRegiune.Goleste();
                this.txtAbreviereRegiune.Goleste();
                this.txtPrefixTelefonicRegiune.Goleste();
                this.ctrlTara.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            }
            else
            {
                this.txtDenumireRegiune.Text = this.lRegiune.Nume;
                this.txtAbreviereRegiune.Text = this.lRegiune.Abreviere;
                this.txtPrefixTelefonicRegiune.Text = this.lRegiune.PrefixTelefon;
                if (this.lRegiune.IdTara != 0)
                {                                                  //  lore ----aici era   this.lRegiune.Numetara 
                    this.ctrlTara.Initializeaza(new StructIdDenumire(this.lRegiune.IdTara, this.lRegiune.NumeTara), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                    this.ctrlTara.AllowModification(false);
                }
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareRegiune_Validare(object sender, EventArgs e)
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

        #endregion

        #region Metode private
        
        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtDenumireRegiune, this.lblDenumireRegiune);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlTara.IdObiectAfisajCorespunzator, this.lblTaraRegiune);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstFocus = { this.txtDenumireRegiune, this.ctrlTara };
            foreach (var control in lstFocus)
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

        public static bool Afiseaza(Form pEcranPariente, BRegiuni pRegiune)
        {
            using (FormAdaugareRegiune ecran = new FormAdaugareRegiune(pRegiune))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            bool esteValid = BRegiuni.SuntInformatiileNecesareCoerente(this.ctrlTara.IdObiectAfisajCorespunzator, this.txtDenumireRegiune.Text);
            if (this.lRegiune == null)
            {
                if (esteValid)
                {
                    BRegiuni.Add(this.ctrlTara.IdObiectAfisajCorespunzator, this.txtDenumireRegiune.Text, this.txtAbreviereRegiune.Text, this.txtPrefixTelefonicRegiune.Text, 1, 1, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                this.lRegiune.Nume = this.txtDenumireRegiune.Text;
                this.lRegiune.IdTara = this.ctrlTara.IdObiectAfisajCorespunzator;
                this.lRegiune.PrefixTelefon = this.txtPrefixTelefonicRegiune.Text;
                this.lRegiune.Abreviere = this.txtAbreviereRegiune.Text;
                if (esteValid)
                {
                    this.lRegiune.UpdateAll();
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
            this.txtDenumireRegiune.AllowModification(this.lEcranInModificare);
            this.ctrlTara.AllowModification(this.lEcranInModificare);
            this.txtAbreviereRegiune.AllowModification(this.lEcranInModificare);
            this.txtPrefixTelefonicRegiune.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
