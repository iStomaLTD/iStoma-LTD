using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.iStomaLab.Utilizatori;
using iStomaLab.Generale;
using CDL.iStomaLab;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlCautaTehnician : Generale.UserControlPersonalizat
    {

        #region Declaratii generale

        public event System.EventHandler CerereUpdate;
        private CDefinitiiComune.EnumRol lRol = CDefinitiiComune.EnumRol.Nedefinit;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlCautaTehnician()
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
            this.lgfTehnician.CerereUpdate += LgfTehnician_CerereUpdate;
            this.lgfTehnician.DeschideEcranCautare += LgfTehnician_DeschideEcranCautare;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            Initializeaza(null, CDefinitiiComune.EnumRol.Tehnician);
        }

        public void Initializeaza(BUtilizator pTehnician)
        {
            Initializeaza(pTehnician, CDefinitiiComune.EnumRol.Tehnician);
        }

        public void Initializeaza(BUtilizator pTehnician, CDefinitiiComune.EnumRol pRol)
        {
            base.InitializeazaVariabileleGenerale();

            this.lRol = pRol;

            incepeIncarcarea();
            //Il afisam
            this.lgfTehnician.ObiectAfisajCorespunzator = pTehnician;		
            
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void LgfTehnician_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator tehnician = FormListaUtilizatori.Afiseaza(this.GetFormParinte(), this.lRol);
                if (tehnician != null)
                {
                    this.lgfTehnician.ObiectAfisajCorespunzator = tehnician;
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

        private void LgfTehnician_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            cereUpdate();
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
            this.lgfTehnician.AfiseazaButonGuma = pAfiseaza;
        }

        public void Goleste()
        {
            this.lgfTehnician.Goleste();
        }

        public int GetIdTehnician()
        {
            return this.lgfTehnician.IdObiectCorespunzator;
        }

        public void SelectieInteligenta(int pIdTehnician)
        {
            if(this.GetIdTehnician() == pIdTehnician)
            {
                this.Goleste();
            }
            else
            {
                this.lgfTehnician.ObiectAfisajCorespunzator = BUtilizator.GetById(pIdTehnician, null);
            }

            cereUpdate();
        }

        public BUtilizator GetTehnician()
        {
            return this.lgfTehnician.ObiectAfisajCorespunzator as BUtilizator;
        }

        public bool AreValoare()
        {
            return this.lgfTehnician.AreValoare();
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.lgfTehnician.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
