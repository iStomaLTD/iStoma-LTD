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

namespace iStomaLab.Setari.Liste
{
    public partial class FormAdaugareInLista : FormPersonalizat
    {

        #region Declaratii generale

        BProfesii lProfesie = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdaugareInLista(BProfesii pProfesie)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lProfesie = pProfesie;

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
            this.ctrlValidareAnulareProfesie.Validare += CtrlValidareAnulareProfesie_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDenumireProfesie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblCodCorProfesie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodCOR);
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

            if (this.lProfesie == null)
            {
                this.txtDenumireProfesie.Goleste();
                this.txtCodCorProfesie.Goleste();
            }
            else
            {
                this.txtDenumireProfesie.Text = lProfesie.Denumire;
                this.txtCodCorProfesie.Text = lProfesie.CodCOR;
            }
            
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareProfesie_Validare(object sender, EventArgs e)
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

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                if (this.Salveaza())
                {
                    inchideEcranulOK();
                }
            }
            else if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                inchideEcranulOK();
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BProfesii pProfesie)
        {
            using (FormAdaugareInLista ecran = new FormAdaugareInLista(pProfesie))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        internal bool Salveaza()
        {
            if (this.lProfesie == null)
            {
                if (BProfesii.SuntInformatiileNecesareCoerente(this.txtDenumireProfesie.Text))
                {
                    BProfesii.Add(this.txtDenumireProfesie.Text, this.txtCodCorProfesie.Text, null);
                }
                else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireProfesie.Focus();
                    this.lblDenumireProfesie.ForeColor = Color.Red;
                }
            }
            else
            {
                this.lProfesie.Denumire = this.txtDenumireProfesie.Text;
                this.lProfesie.CodCOR = this.txtCodCorProfesie.Text;
                if (BProfesii.SuntInformatiileNecesareCoerente(this.txtDenumireProfesie.Text))
                {
                    this.lProfesie.UpdateAll();
                }
                else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireProfesie.Focus();
                    this.lblDenumireProfesie.ForeColor = Color.Red;
                }
            }
            return BProfesii.SuntInformatiileNecesareCoerente(this.txtDenumireProfesie.Text);
        }
        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.txtDenumireProfesie.AllowModification(this.lEcranInModificare);
            this.txtCodCorProfesie.AllowModification(this.lEcranInModificare);
        }



        #endregion


    }
}
