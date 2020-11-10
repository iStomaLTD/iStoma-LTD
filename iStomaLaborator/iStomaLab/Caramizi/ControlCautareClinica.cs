using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Clienti;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlCautareClinica : UserControlPersonalizat
    {
        #region Declaratii generale

        public event System.EventHandler CerereUpdate;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautareClinica()
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
            this.lgfClinica.CerereUpdate += LgfLucrare_CerereUpdate;
            this.lgfClinica.DeschideEcranCautare += LgfLucrare_DeschideEcranCautare;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(BClienti pClient)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            //Afisam
            this.lgfClinica.ObiectAfisajCorespunzator = pClient;
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

                BClienti client = FormListaClinici.Afiseaza(this.GetFormParinte());
                if (client != null)
                {
                    this.lgfClinica.ObiectAfisajCorespunzator = client;
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
            this.lgfClinica.AfiseazaButonGuma = pAfiseaza;
        }

        public void Goleste()
        {
            this.lgfClinica.Goleste();
        }

        public int GetIdClient()
        {
            return this.lgfClinica.IdObiectCorespunzator;
        }

        public void SelectieInteligenta(int pIdClient)
        {
            if (this.GetIdClient() == pIdClient)
            {
                this.Goleste();
            }
            else
            {
                this.lgfClinica.ObiectAfisajCorespunzator = BClienti.getClient(pIdClient, null);
            }

            cereUpdate();
        }

        public BClienti GetClient()
        {
            return this.lgfClinica.ObiectAfisajCorespunzator as BClienti;
        }

        public bool AreValoare()
        {
            return this.lgfClinica.AreValoare();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.lgfClinica.AllowModification(this.lEcranInModificare);
        }

        #endregion
    }
}
