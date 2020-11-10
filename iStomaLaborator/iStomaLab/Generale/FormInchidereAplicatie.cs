using BLL.iStomaLab;
using CCL.UI.FormulareComune;
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
    public partial class FormInchidereAplicatie : FormPersonalizat
    {

        #region Declaratii generale

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormInchidereAplicatie()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

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
            this.lblTitluEcran.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inchidere);
            this.lblConfirmareInchidere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmareInchidere);
            this.lblAplicatieSeVaInchideAutomatIn.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AplicatieSeVaInchideAutomatIn);
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

            CCL.UI.IHMEfecteSpeciale.AplicaEfectWAIT(this, this.lblContorSecunde, 3);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        #endregion

        #region Metode private

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormInchidereAplicatie ecran = new FormInchidereAplicatie())
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
