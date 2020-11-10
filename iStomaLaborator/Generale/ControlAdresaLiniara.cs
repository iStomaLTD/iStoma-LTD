using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab.Comune;
using CDL.iStomaLab;
using BLL.iStomaLab;
using CCL.iStomaLab;

namespace iStomaLab.Generale
{
    [System.ComponentModel.DefaultEvent("ModificareEfectuata")]
    public partial class ControlAdresaLiniara : UserControlPersonalizat
    {

        #region Declaratii generale

        public event System.EventHandler ModificareEfectuata;

        private int lIdAdresaDeclarant = 0;
        private CDL.iStomaLab.CDefinitiiComune.EnumTipObiect lTipProprietar = CDefinitiiComune.EnumTipObiect.Nedefinit;
        private int lIdProprietar = 0;
        private bool lGolesteTextDacaNuAreAdresa = false;
        private BAdrese lAdresaAfisata = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdresaLiniara()
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
            this.lgfDomiciliatIn.DeschideEcranCautare += lgfDomiciliatIn_DeschideEcranCautare;
        }

        private void initTextML()
        {

        }

        public void Initializeaza(ILL.BLL.General.IIdentitate pPosesorAdresa, bool pGolesteTextDacaNuAreAdresa)
        {
            base.InitializeazaVariabileleGenerale();

            this.lGolesteTextDacaNuAreAdresa = pGolesteTextDacaNuAreAdresa;

            incepeIncarcarea();

            if (pPosesorAdresa != null)
            {
                this.lTipProprietar = pPosesorAdresa.TipObiect;
                this.lIdProprietar = pPosesorAdresa.Id;

                initAdresa(pPosesorAdresa.GetAdresa(null));
            }
            finalizeazaIncarcarea();
        }

        public void Initializeaza(BAdrese pAdresa, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar)
        {
            base.InitializeazaVariabileleGenerale();

            this.lTipProprietar = pTipProprietar;
            this.lIdProprietar = pIdProprietar;
            this.lGolesteTextDacaNuAreAdresa = true;

            incepeIncarcarea();

            initAdresa(pAdresa);

            finalizeazaIncarcarea();
        }

        public void Initializeaza(ILL.BLL.General.IPosesorAdresa pPosesorAdresa, bool pGolesteTextDacaNuAreAdresa)
        {
            base.InitializeazaVariabileleGenerale();

            this.lGolesteTextDacaNuAreAdresa = pGolesteTextDacaNuAreAdresa;

            incepeIncarcarea();

            if (pPosesorAdresa != null)
            {
                this.lTipProprietar = pPosesorAdresa.TipObiect;
                this.lIdProprietar = pPosesorAdresa.Id;

                initAdresa(pPosesorAdresa.GetAdresa(null));
            }

            finalizeazaIncarcarea();
        }

        private void initAdresa(ILL.BLL.General.IAfisaj adresa)
        {
            if (adresa != null)
            {
                this.lIdAdresaDeclarant = adresa.Id;
                this.lgfDomiciliatIn.ObiectAfisajCorespunzator = adresa;
            }
            else
            {
                if (this.lGolesteTextDacaNuAreAdresa)
                    this.lgfDomiciliatIn.Goleste();
                else
                    this.lgfDomiciliatIn.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa);
            }

            this.lAdresaAfisata = adresa as BAdrese;

            this.lgfDomiciliatIn.AfiseazaButonCautare = false;// this.lTipAdresa != BAdrese.EnumTipAdresa.SediuSocial;
        }


        #endregion

        #region Evenimente

        private void lgfDomiciliatIn_AfiseazaDetaliiObiectAtasat(Control psender, object pxObiectExistent)
        {
            try
            {
                frmAfiseazaAdresa.AfiseazaEcran(this.GetFormParinte(), this.lgfDomiciliatIn.ObiectAfisajCorespunzator as BAdrese, this.lEcranInModificare);

                refreshAdresaAfisata();

                anuntaModificarea();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void lgfDomiciliatIn_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            try
            {
                cautaAdresaDeclarant();

                if (this.lgfDomiciliatIn.AreValoare())
                {
                    this.lIdAdresaDeclarant = this.lgfDomiciliatIn.IdObiectCorespunzator;
                }

                anuntaModificarea();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private

        private void anuntaModificarea()
        {
            if (this.ModificareEfectuata != null)
                ModificareEfectuata(this, null);
        }

        private void cautaAdresaDeclarant()
        {
            //Cautam adresa pe care o vom folosi

            BColectieAdrese listaAdrese = BAdrese.GetListByParam(1, this.lTipProprietar, this.lIdProprietar, CDefinitiiComune.EnumStare.Activa, null);

            BAdrese adresaDeclarant = null;
            if (CUtil.EsteListaVida<BAdrese>(listaAdrese))
            {
                adresaDeclarant = IHMUtile.AdaugaAdresa(this.GetFormParinte(), this.lTipProprietar, this.lIdProprietar);
            }
            else
            {
                adresaDeclarant = IHMUtile.GetAdresa(this.GetFormParinte(), this.lTipProprietar, this.lIdProprietar, true);
            }

            if (adresaDeclarant != null)
            {
                this.lgfDomiciliatIn.ObiectAfisajCorespunzator = adresaDeclarant;
            }
            else
            {
                refreshAdresaAfisata();
            }
        }

        private void refreshAdresaAfisata()
        {
            //Facem refresh la cea afisata
            if (this.lgfDomiciliatIn.ObiectAfisajCorespunzator != null)
            {
                BAdrese adr = this.lgfDomiciliatIn.ObiectAfisajCorespunzator as BAdrese;
                adr.Refresh(null);
                if (adr.EsteActiv)
                    this.lgfDomiciliatIn.ObiectAfisajCorespunzator = adr;
                else
                    this.lgfDomiciliatIn.Goleste();

                adr = null;
            }
        }

        #endregion

        #region Metode publice

        public void Goleste()
        {
            this.lgfDomiciliatIn.Goleste();
            this.lAdresaAfisata = null;
        }

        public bool EsteAdresaCompletata()
        {
            if (this.lAdresaAfisata != null && this.lAdresaAfisata.EsteCompletata())
            {
                return true;
            }

            return false;
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.lgfDomiciliatIn.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
