using BLL.iStomaLab;
using BLL.iStomaLab.Comune;
using CDL.iStomaLab;
using ILL.BLL.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class frmAfiseazaAdresa : FormPersonalizat
    {

        #region Declaratii generale

        //private IProprietar lProprietar = null;
        private CDefinitiiComune.EnumTipObiect lTipProprietar = CDefinitiiComune.EnumTipObiect.Nedefinit;
        private int lIdProprietar = 0;
        private BAdrese.EnumTipAdresa lTipAdresa = BAdrese.EnumTipAdresa.Nedefinit;
        private bool lModSelectie = false;
        private BAdrese lAdresaSelectata = null;
       
        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public frmAfiseazaAdresa()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.ctrlAdresa.SelectieEfectuata += ctrlAdresa_SelectieEfectuata;
            this.ctrlAdresa.InchideEcranPopUp += ctrlAdresa_InchideEcranPopUp;
            this.PermiteDeplasareaEcranului = true;
            this.PermiteMaximizareaEcranului = false;
            this.PermiteRedimensionarea = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmAfiseazaAdresa(BAdrese pAdresa, bool pEcranInModificare)
            : this()
        {
            this.lAdresaSelectata = pAdresa;
            this.lEcranInModificare = pEcranInModificare;

            if (this.lAdresaSelectata != null)
                this.lTipAdresa = this.lAdresaSelectata.TipAdresa;

            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa);
        }

        public frmAfiseazaAdresa(CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, bool pModCreare, bool pModSelectie, bool pEcranInModificare)
            : this()
        {
            this.lTipProprietar = pTipProprietar;
            this.lIdProprietar = pIdProprietar;
            this.lModSelectie = pModSelectie;
            this.lEcranInModificare = pEcranInModificare;
            this.lTipAdresa = BAdrese.EnumTipAdresa.Principala;

            this.Text = string.Empty;
        }

        public frmAfiseazaAdresa(IProprietar pProprietar, bool pModCreare, bool pModSelectie, bool pEcranInModificare)
            : this()
        {
            //this.lProprietar = pProprietar;
            this.lModCreare = pModCreare;
            this.lModSelectie = pModSelectie;
            this.lEcranInModificare = pEcranInModificare;

            if (pProprietar == null)
                this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa);
            else
            {
                this.lTipProprietar = pProprietar.TipObiect;
                this.lIdProprietar = pProprietar.Id;
                this.Text = string.Format("{0} - {1}", pProprietar.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Adresa));
            }
        }

        private void frmAfiseazaAdresa_Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            incepeIncarcarea();

            if (this.lAdresaSelectata == null)
            {
                //this.ctrlAdresa.Initializeaza(this.lProprietar, this.lModCreare, this.lModSelectie);
                this.lAdresaSelectata = this.ctrlAdresa.Initializeaza(this.lTipProprietar, this.lIdProprietar, this.lModCreare, this.lModSelectie);
                this.ctrlAdresa.AllowModification(this.lEcranInModificare);
            }
            else
            {
                this.ctrlAdresa.Initializeaza(this.lAdresaSelectata, this.lAdresaSelectata.TipProprietar, this.lAdresaSelectata.IdProprietar, this.lTipAdresa);
                this.ctrlAdresa.AllowModification(this.lEcranInModificare);
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        void ctrlAdresa_InchideEcranPopUp(object sender, EventArgs e)
        {
            try
            {
                this.lAdresaSelectata = null;
                inchideEcranul();
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        void ctrlAdresa_SelectieEfectuata(BAdrese pElemSelectionat)
        {
            try
            {          
                this.lAdresaSelectata = pElemSelectionat;
                inchideEcranul(System.Windows.Forms.DialogResult.OK);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static BAdrese AfiseazaEcran(Form pEcranParinte, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, BAdrese.EnumTipAdresa pTipAdresa, bool pModCreare, bool pModSelectie, bool pEcranInModificare)
        {
            using (frmAfiseazaAdresa ecran = new frmAfiseazaAdresa(pTipProprietar, pIdProprietar, pModCreare, pModSelectie, pEcranInModificare))
            {
                ecran.AplicaPreferinteleUtilizatorului();

                CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);

                return ecran.lAdresaSelectata;

                //return null;
            }
        } 

        public static BAdrese AfiseazaEcran(Form pEcranParinte, IProprietar pProprietar, bool pModCreare, bool pModSelectie, bool pEcranInModificare)
        {
            using (frmAfiseazaAdresa ecran = new frmAfiseazaAdresa(pProprietar, pModCreare, pModSelectie, pEcranInModificare))
            {
                ecran.AplicaPreferinteleUtilizatorului();

                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran))
                    return ecran.lAdresaSelectata;

                return null;
            }
        }

        //public static void AfiseazaEcran(Form pEcranParinte, BAdrese pAdresa, bool pEcranInModificare)
        //{
        //    using (frmAfiseazaAdresa ecran = new frmAfiseazaAdresa(pAdresa, pEcranInModificare))
        //    {
        //        if (!ecran.IsDisposed)
        //        {
        //            ecran.AplicaPreferinteleUtilizatorului();
        //            CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
        //        }
        //    }
        //}

        public static void AfiseazaEcran(Form pEcranParinte, BAdrese pAdresa, bool pEcranInModificare)
        {
            using (frmAfiseazaAdresa ecran = new frmAfiseazaAdresa(pAdresa, pEcranInModificare))
            {
                if (!ecran.IsDisposed)
                {
                    ecran.AplicaPreferinteleUtilizatorului();
                    ecran.lEcranInModificare = pEcranInModificare;
                    CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran);
                }
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
