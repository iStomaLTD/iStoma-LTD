using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetaliuClient : Generale.FormPersonalizat
    {

        #region Declaratii generale

        private BClienti lClient = null;
        private BAdrese lAdresa = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuClient(BClienti pClient, BAdrese pAdresa)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lClient = pClient;
            this.lAdresa = pAdresa;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
            this.ctrlDetaliuClient.Focus();
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.ctrlValidareAnulareClient.Validare += CtrlValidareAnulareClient_Click;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblTitluEcran.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Client);
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
            this.ctrlDetaliuClient.Initializeaza(this.lClient);			
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente


        private void CtrlValidareAnulareClient_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.ctrlDetaliuClient.Salveaza())
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

        public static bool Afiseaza(Form pEcranPariente, BClienti pClient)
        {
            using (FormDetaliuClient ecran = new FormDetaliuClient(pClient, null))
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
