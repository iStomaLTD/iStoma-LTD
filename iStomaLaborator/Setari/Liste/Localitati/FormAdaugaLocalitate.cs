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

namespace iStomaLab.Setari.Liste.Localitati
{
    public partial class FormAdaugaLocalitate : FormPersonalizat
    {

        #region Declaratii generale

        BLocalitati lLocalitate = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdaugaLocalitate(BLocalitati pLocalitati)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lLocalitate = pLocalitati;

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
            this.ctrlValidareAnulareLocalitate.Validare += CtrlValidareAnulareLocalitate_Validare;
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
            this.ctrlAdaugaLocalitate.Initializeaza(this.lLocalitate);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulareLocalitate_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.ctrlAdaugaLocalitate.Salveaza())
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



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BLocalitati pLocalitate)
        {
            using (FormAdaugaLocalitate ecran = new FormAdaugaLocalitate(pLocalitate))
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
