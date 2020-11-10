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
using BLL.iStomaLab.Referinta;
using DAL.iStomaLab.Referinta;
using CCL.UI;

namespace iStomaLab.Setari.Liste.Regiuni
{
    public partial class ControlAdaugareRegiune : UserControlPersonalizat
    {

        #region Declaratii generale

        private BRegiuni lRegiune = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdaugareRegiune()
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

        }

        private void initTextML()
        {
            this.lblDenumireRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblTaraRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tara);
            this.lblAbreviereRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Abreviere);
            this.lblPrefixTelefonicRegiune.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrefixTelefonic);
        }

        public void Initializeaza(BRegiuni pRegiune)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lRegiune = pRegiune;

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
                {
                    this.ctrlTara.Initializeaza(new StructIdDenumire(this.lRegiune.IdTara, BTari.getTara(this.lRegiune.Id, null).NumeScurt), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                }
            }



            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



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
            foreach(var control in lstFocus)
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
