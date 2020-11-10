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

namespace iStomaLab.Setari.Liste.Banci
{
    public partial class FormDetaliiBanca : FormPersonalizat
    {

        #region Declaratii generale

        private BBanci lBanca = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliiBanca(BBanci pBanca)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lBanca = pBanca;

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
            this.ctrlValidareAnulareBanca.Validare += CtrlValidareAnulareBanca_Validare;
        }
        
        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDenumire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblInfoSuplimentare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformatiiSuplimentare);
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
                      
            if (this.lBanca == null)
            {
                this.txtDenumireBanca.Goleste();
                this.txtInfoSuplimentare.Goleste();
            }
            else
            {
                this.txtDenumireBanca.Text = this.lBanca.Denumire;
                this.txtInfoSuplimentare.Text = this.lBanca.InformatiiComplementare;
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareBanca_Validare(object sender, EventArgs e)
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



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BBanci pBanca)
        {
            using (FormDetaliiBanca ecran = new FormDetaliiBanca(pBanca))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }
        
        internal bool Salveaza()
        {
            if (this.lBanca == null)
            {
                if (BBanci.SuntInformatiileNecesareCoerente(this.txtDenumireBanca.Text))
                {
                    BBanci.Add(this.txtDenumireBanca.Text, this.txtInfoSuplimentare.Text, null);
                }
                else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireBanca.Focus();
                    this.lblDenumire.ForeColor = Color.Red;
                }
            }
            else
            {
                this.lBanca.Denumire = this.txtDenumireBanca.Text;
                this.lBanca.InformatiiComplementare = this.txtInfoSuplimentare.Text;

                if (BBanci.SuntInformatiileNecesareCoerente(this.txtDenumireBanca.Text))
                {
                    this.lBanca.UpdateAll();
                }
                else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireBanca.Focus();
                    this.lblDenumire.ForeColor = Color.Red;
                }
            }
            return BBanci.SuntInformatiileNecesareCoerente(this.txtDenumireBanca.Text);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtDenumireBanca.AllowModification(this.lEcranInModificare);
            this.txtInfoSuplimentare.AllowModification(this.lEcranInModificare);
        }

        #endregion


    }
}
