using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Erori
{
    public partial class frmEroare : Generale.FormPersonalizat
    {

        #region Declaratii generale

        private Exception lExceptie = null;
        private bool lDetaliiAfisate = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private frmEroare(Exception pExceptie)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lExceptie = pExceptie;

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

            this.txtEroare.Text = this.lExceptie.Message;
            this.txtEroare.AllowModification(false);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void btnDetalii_Click(object sender, EventArgs e)
        {
            if (this.lDetaliiAfisate)
            {
                this.Size = new Size(502, 238);
            }
            else
            {
                this.Size = new Size(502, 424);
            }

            this.lDetaliiAfisate = !this.lDetaliiAfisate;
        }

        private void btnAnuntaIDava_Click(object sender, EventArgs e)
        {
            bool ok = true;
            try
            {
                //ok = IHMUtile._AccesTotal.SemnaleazaEroarea(string.Concat(this.txtEroare.Text, CDL.General.CConstante.LinieNouaHTML, "==================================", CDL.General.CConstante.LinieNouaHTML, this.txtDetalii.Text));
            }
            catch (Exception)
            {
            }
            finally
            {
                if (ok)
                {
                    this.TopMost = false;

                    //Inchidem ecranul dupa ce am semnalat eroarea
                    inchideEcranul();
                }
            }
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, Exception pExceptie)
        {
            using (frmEroare ecran = new frmEroare(pExceptie))
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
