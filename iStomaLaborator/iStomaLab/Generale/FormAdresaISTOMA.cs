using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Utilizatori;
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
    public partial class FormAdresaISTOMA : FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BUtilizator lUtilizator = null;
        private BClientiCabinete lCabinet = null;
        static EnumTipProprietar _STipProprietar = EnumTipProprietar.Client;

        #endregion

        #region Enumerari si Structuri

        private enum EnumTipProprietar
        {
            Client,
            Utilizator,
            Cabinet
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormAdresaISTOMA(BClienti pClient)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private FormAdresaISTOMA(BUtilizator pUtilizator)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lUtilizator = pUtilizator;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private FormAdresaISTOMA(BClientiCabinete pCabinet)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lCabinet = pCabinet;

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

            incarcaAdresaPentruTipProprietar(_STipProprietar);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private

        private void incarcaAdresaPentruTipProprietar(EnumTipProprietar pTipProprietar)
        {
            pTipProprietar = _STipProprietar;
            switch (pTipProprietar)
            {
                case EnumTipProprietar.Client:
                    if (this.lClient != null)
                    {
                        this.ctrlAdresa.Initializeaza(BAdrese.getAdresaByIdProprietar(this.lClient.Id, null), CDL.iStomaLab.CDefinitiiComune.EnumTipObiect.Clienti, this.lClient.Id, BAdrese.EnumTipAdresa.Nedefinit);
                    }
                    break;
                case EnumTipProprietar.Utilizator:
                    if (this.lUtilizator != null)
                    {
                        this.ctrlAdresa.Initializeaza(BAdrese.getAdresaByIdProprietar(this.lUtilizator.Id, null), CDL.iStomaLab.CDefinitiiComune.EnumTipObiect.Utilizator, this.lUtilizator.Id, BAdrese.EnumTipAdresa.Nedefinit);
                    }
                    break;
                case EnumTipProprietar.Cabinet:
                    if (this.lCabinet != null)
                    {
                        this.ctrlAdresa.Initializeaza(BAdrese.getAdresaByIdProprietar(this.lCabinet.Id, null), CDL.iStomaLab.CDefinitiiComune.EnumTipObiect.ClientiCabinete, this.lCabinet.Id, BAdrese.EnumTipAdresa.Nedefinit);
                    }
                    break;
            }
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            _STipProprietar = EnumTipProprietar.Client;

            using (FormAdresaISTOMA ecran = new FormAdresaISTOMA(pClient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        public static bool Afiseaza(Form pEcranPariente, BUtilizator pUtilizator)
        {
            _STipProprietar = EnumTipProprietar.Utilizator;

            using (FormAdresaISTOMA ecran = new FormAdresaISTOMA(pUtilizator))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        public static bool Afiseaza(Form pEcranPariente, BClientiCabinete pCabinet)
        {
            _STipProprietar = EnumTipProprietar.Cabinet;

            using (FormAdresaISTOMA ecran = new FormAdresaISTOMA(pCabinet))
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
