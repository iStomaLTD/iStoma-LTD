using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL.UI.FormulareComune
{
    public partial class FormContinutFisierText : frmCuHeaderSiValidare
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormContinutFisierText(string pContinut)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = true;
            this.PermiteRedimensionarea = true;

            this.txtContinut.ReadOnly = true;
            this.txtContinut.ScrollBars = ScrollBars.Both;
            this.txtContinut.TabStop = false;
            this.txtContinut.Text = pContinut;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();

                this.CenterToScreen();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += FormContinutFisierText_Load;
            this.btnValidare.Click += BtnValidare_Click;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
        }

        void FormContinutFisierText_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);

                this.btnValidare.Focus();
            }
            catch (Exception ex)
            {
                IHMUtile.AfiseazaEroare(this, ex.Message, string.Empty, true);
            }
        }

        public void Initializeaza()
        {

            incepeIncarcarea();
            //TODO			
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnValidare_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranParinte, System.IO.FileInfo pFisier)
        {
            if (pFisier == null || !pFisier.Exists) return false;

            return Afiseaza(pEcranParinte, System.IO.File.ReadAllText(pFisier.FullName));
        }

        public static bool Afiseaza(Form pEcranParinte, string pContinut)
        {
            using (FormContinutFisierText ecran = new FormContinutFisierText(pContinut))
            {
                return CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
        }

        #endregion

    }
}
