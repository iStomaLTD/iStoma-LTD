using BLL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Caramizi
{
    public partial class FormSelecteazaDate : Generale.FormPersonalizat
    {

        #region Declaratii generale

        private DateTime lDataInceput;
        private DateTime lDataSfarsit;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormSelecteazaDate(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lDataInceput = pDataInceput;
            this.lDataSfarsit = pDataSfarsit;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += FormSelecteazaDate_Load;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblDataInceput.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataInceput);
            this.lblDataSfarsit.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataSfarsit);
        }

        void FormSelecteazaDate_Load(object sender, EventArgs e)
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

            this.ctrlDataInceput.DataAfisata = this.lDataInceput;
            this.ctrlDataSfarsit.DataAfisata = this.lDataSfarsit;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            inchideEcranul(DialogResult.OK);
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static Tuple<DateTime, DateTime> Afiseaza(Form pEcranParinte, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            using (FormSelecteazaDate ecran = new FormSelecteazaDate(pDataInceput, pDataSfarsit))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, ecran))
                {
                    if (ecran.ctrlDataInceput.AreValoare() && ecran.ctrlDataSfarsit.AreValoare())
                    {
                        return new Tuple<DateTime, DateTime>(ecran.ctrlDataInceput.DataAfisata, ecran.ctrlDataSfarsit.DataAfisata);
                    }
                    else
                        return null;
                }
            }

            return null;
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
