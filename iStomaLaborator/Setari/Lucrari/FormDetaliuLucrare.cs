using BLL.iStomaLab.Preturi;
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

namespace iStomaLab.Setari.Lucrari
{
    public partial class FormDetaliuLucrare : FormPersonalizat
    {

        #region Declaratii generale

        private BListaPreturiStandard lLucrare = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuLucrare(BListaPreturiStandard pLucrare)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lLucrare = pLucrare;

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
            this.ctrlValidareAnulareLucrare.Validare += CtrlValidareAnulareLucrare_Validare;
            this.FormClosed += FormDetaliuLucrare_FormClosed;
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

            this.ctrlDetaliuLucrare.Initializeaza(this.lLucrare);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void FormDetaliuLucrare_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormListaCategorii._SCategorie = null;
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this, ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        private void CtrlValidareAnulareLucrare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.ctrlDetaliuLucrare.Salveaza())
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

        public static bool Afiseaza(Form pEcranPariente, BListaPreturiStandard pLucrare)
        {
            using (FormDetaliuLucrare ecran = new FormDetaliuLucrare(pLucrare))
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
