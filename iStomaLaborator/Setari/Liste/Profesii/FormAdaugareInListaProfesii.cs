using BLL.iStomaLab.Referinta;
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

            this.ctrlAdaugareInListaProfesie.Initializeaza(this.lProfesie);

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

                if (this.ctrlAdaugareInListaProfesie.Salveaza())
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
                if (this.ctrlAdaugareInListaProfesie.Salveaza())
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

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
