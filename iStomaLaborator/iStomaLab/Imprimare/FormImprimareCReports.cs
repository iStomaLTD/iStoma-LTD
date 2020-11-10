using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab.Utile;
using CDL.iStomaLab;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace iStomaLab.Imprimare
{
    public partial class FormImprimareCReports : FormPersonalizat
    {
        #region Declaratii generale
       
        /* private string lRptImprimare = string.Empty;
        private BUtilizator lUtilizator = null;
        private DateTime lDataInceput = CConstante.DataNula;
        private DateTime lDataFinal = CConstante.DataNula;
        private ReportDocument lRptDoc = new ReportDocument(); */
        private CrystalDecisions.Shared.ParameterFields lParametrii = new CrystalDecisions.Shared.ParameterFields();

        private StructParametriiRaport lStruct = new StructParametriiRaport();

        public struct StructParametriiRaport
        {
            public string lRptImprimare { get; set; }
            public BUtilizator lUtilizator { get; set; }
            public BClientiFacturi lFactura { get; set; }
            public DateTime lDataInceput { get; set; }
            public DateTime lDataFinal { get; set; }
            public ReportDocument lRptDoc { get; set; }
        }

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        /// <summary>
        /// Gets the Current Parameter Fields
        /// </summary>
        public CrystalDecisions.Shared.ParameterFields CampuriParametrii
        {
            get
            {
                return lParametrii;
            }
        }


        #endregion

        #region Constructor si Initializare

        private FormImprimareCReports(StructParametriiRaport pStruct)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lStruct = pStruct;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        //private FormImprimareCReports(BUtilizator pUtilizator, DateTime pDataInceput, DateTime pDataFinal, string pRptImprimare)
        //{
        //    this.DoubleBuffered = true;
        //    InitializeComponent();

        //    this.lUtilizator = pUtilizator;
        //    this.lRptImprimare = pRptImprimare;
        //    this.lDataInceput = pDataInceput;
        //    this.lDataFinal = pDataFinal;

        //    if (!CCL.UI.IHMUtile.SuntemInDebug())
        //    {
        //        adaugaHandlere();
        //        initTextML();

        //        this.CentratCuDeplasare();
        //    }
        //}

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

            AfisareRaport();
          
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private

        private void AfisareRaport()
        {
            //trimitem parametrii de filtrare pe raport
            //lRptDoc.Load(this.lRptImprimare);
            //lRptDoc.SetParameterValue("@IdTehnician", this.lStruct.lUtilizator.Id);
            //lRptDoc.SetParameterValue("NumeTehnician", this.lUtilizator.GetNumeCompletUtilizator());
            //lRptDoc.SetParameterValue("@DataInceput", this.lDataInceput);
            //lRptDoc.SetParameterValue("@DataSfarsit", this.lDataFinal);

            //this.lStruct.lRptDoc.Load(this.lStruct.lRptImprimare);

            //SetareParametrii();
            crvImprimare.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crvImprimare.ReuseParameterValuesOnRefresh = true;
          
            IHMUtile.seteazaConexiuneRaport(this.lStruct.lRptDoc);

            crvImprimare.ReportSource = this.lStruct.lRptDoc;
            crvImprimare.Refresh();
        }



        private void SetareParametrii()
        {
            try
            {
                if (this.CampuriParametrii.Count > 0)
                {
                    //Setam parametrii
                    this.crvImprimare.ParameterFieldInfo = this.CampuriParametrii;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a discrete parameteer value
        /// </summary>
        /// <param name="ParameterName">The namee of the parameter to set</param>
        /// <param name="value">The value of the parameter</param>
        public void AddDiscreteValue(string ParameterName, object value)
        {
            try
            {
                //Create a new Parameter Field
                CrystalDecisions.Shared.ParameterField oParameterField = new CrystalDecisions.Shared.ParameterField();
                oParameterField.Name = ParameterName;

                //Create a new Discrete Value
                CrystalDecisions.Shared.ParameterDiscreteValue oParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                oParameterDiscreteValue.Value = value;

                //Add the value
                oParameterField.CurrentValues.Add(oParameterDiscreteValue);

                //Add the parameter field
                this.CampuriParametrii.Add(oParameterField);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, StructParametriiRaport pStruct) 
        {
            using (FormImprimareCReports ecran = new FormImprimareCReports(pStruct)) 
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        //public static bool Afiseaza(Form pEcranPariente, BUtilizator pUtilizator, DateTime pDataInceput, DateTime pDataSfarsit, string pRptImprimare) 
        //{
        //    using (FormImprimareCReports ecran = new FormImprimareCReports(pUtilizator, pDataInceput, pDataSfarsit, pRptImprimare))
        //    {
        //        ecran.AplicaPreferinteleUtilizatorului();
        //        return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
        //    }
        //}

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
