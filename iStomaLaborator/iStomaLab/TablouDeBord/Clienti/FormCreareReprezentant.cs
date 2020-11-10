using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Reprezentanti;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormCreareReprezentant : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCreareReprezentant(BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                this.AcceptButton = this.ctrlValidareAnulare.ButonValidare;

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblNume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nume);
            this.lblPrenume.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prenume);
            this.lblTelefon.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Telefon);
            this.lblClinica.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clinica);
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
            if (this.lClient == null)
            {
                this.ctrlCautaClinica.Initializeaza(StructIdDenumire.Empty, CEnumerariComune.EnumTipDeschidere.DreaptaJos);
            }
            else
            {
                this.ctrlCautaClinica.Initializeaza(new StructIdDenumire(this.lClient), CEnumerariComune.EnumTipDeschidere.DreaptaJos);
                this.ctrlCautaClinica.AllowModification(false);
            }

            this.txtNume.Goleste();
            this.txtPrenume.Goleste();
            this.txtTelefon.Goleste();

            this.txtNume.CapitalizeazaPrimaLitera = true;
            this.txtPrenume.CapitalizeazaPrimaLitera = true;

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

                if (this.Salveaza())
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

        #endregion

        #region Metode private

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlCautaClinica.TextBox, this.lblClinica);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNume, this.lblNume);
            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstControale = { this.ctrlCautaClinica.TextBox, this.txtNume };

            foreach (var control in lstControale)
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

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            using (FormCreareReprezentant ecran = new FormCreareReprezentant(pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }
        internal bool Salveaza()
        {
            bool esteOk = false;

            if (this.ctrlCautaClinica.AreValoare())
            {
                esteOk = BClientiReprezentanti.SuntInformatiileNecesareCoerente(this.ctrlCautaClinica.IdObiectAfisajCorespunzator, this.txtNume.Text);

                if (esteOk)
                {
                    BClientiReprezentanti.Add(this.ctrlCautaClinica.IdObiectAfisajCorespunzator, this.txtNume.Text, this.txtPrenume.Text, this.txtTelefon.Text, null);
                }
                else
                {
                    seteazaAlerta();
                }
            }
            else
            {
                seteazaAlerta();
            }
            return esteOk;
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
