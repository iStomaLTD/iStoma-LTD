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
using CCL.UI;

namespace iStomaLab.Setari.Liste
{
    public partial class ControlAdaugareInLista : UserControlPersonalizat
    {

        #region Declaratii generale

        BProfesii lProfesie = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdaugareInLista()
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
            this.lblDenumireProfesie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Denumire);
            this.lblCodCorProfesie.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CodCOR);
        }

        public void Initializeaza(BProfesii pProfesie)
        {
            base.InitializeazaVariabileleGenerale();

            this.lProfesie = pProfesie;
            incepeIncarcarea();

            if (this.lProfesie == null)
            {
                this.txtDenumireProfesie.Goleste();
                this.txtCodCorProfesie.Goleste();
            }else
            {
                this.txtDenumireProfesie.Text = lProfesie.Denumire;
                this.txtCodCorProfesie.Text = lProfesie.CodCOR;
            }

            
            		
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        internal bool Salveaza()
        {
            if (this.lProfesie == null)
            {

                if (BProfesii.SuntInformatiileNecesareCoerente(this.txtDenumireProfesie.Text))
                {
                    BProfesii.Add(this.txtDenumireProfesie.Text, this.txtCodCorProfesie.Text, null);
                }else
                {
                    IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());
                    this.txtDenumireProfesie.Focus();
                    this.lblDenumireProfesie.ForeColor = Color.Red;
                }

                
            }else
            {
                this.lProfesie.Denumire = this.txtDenumireProfesie.Text;
                this.lProfesie.CodCOR = this.txtCodCorProfesie.Text;
                if (BProfesii.SuntInformatiileNecesareCoerente(this.txtDenumireProfesie.Text))
                {
                    this.lProfesie.UpdateAll();
                }else
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
