using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Preturi;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlCautareLucrare : UserControlPersonalizat
    {
        #region Declaratii generale

        public event System.EventHandler CerereUpdate;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautareLucrare()
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
            this.lgfLucrare.CerereUpdate += LgfLucrare_CerereUpdate;
            this.lgfLucrare.DeschideEcranCautare += LgfLucrare_DeschideEcranCautare;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza(BListaPreturiStandard pLucrare)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            //Afisam
            this.lgfLucrare.ObiectAfisajCorespunzator = pLucrare;
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void LgfLucrare_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            cereUpdate();
        }

        private void LgfLucrare_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BListaPreturiStandard lucrare = FormListaLucrari.Afiseaza(this.GetFormParinte(), null);
                if (lucrare != null)
                {
                    this.lgfLucrare.ObiectAfisajCorespunzator = lucrare;
                    cereUpdate();
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

        private void cereUpdate()
        {
            if (this.CerereUpdate != null)
                CerereUpdate(this, null);
        }

        #endregion

        #region Metode publice

        public void AfiseazaButonGuma(bool pAfiseaza)
        {
            this.lgfLucrare.AfiseazaButonGuma = pAfiseaza;
        }

        public void Goleste()
        {
            this.lgfLucrare.Goleste();
        }

        public int GetIdLucrare()
        {
            return this.lgfLucrare.IdObiectCorespunzator;
        }

        public void SelectieInteligenta(int pIdLucrare)
        {
            if (this.GetIdLucrare() == pIdLucrare)
            {
                this.Goleste();
            }
            else
            {
                this.lgfLucrare.ObiectAfisajCorespunzator = BListaPreturiStandard.getById(pIdLucrare, null);
            }

            cereUpdate();
        }

        public BListaPreturiStandard GetLucrare()
        {
            return this.lgfLucrare.ObiectAfisajCorespunzator as BListaPreturiStandard;
        }

        public bool AreValoare()
        {
            return this.lgfLucrare.AreValoare();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.lgfLucrare.AllowModification(this.lEcranInModificare);
        }

        #endregion
    }
}
