using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Clienti;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.iStomaLab.Clienti.BClientiComenziEtape;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea comenzilor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiComenzi : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BClientiComenzi> _lDictComenzi = new Dictionary<int, BClientiComenzi>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumePacientMaxLength = 50;
            public const int PrenumePacientMaxLength = 50;
            public const int MotivInchidereMaxLength = 500;
            public const int CuloareLucrareMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenzi.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        public int IdTehnician
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdTehnician.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdTehnician.ToString(), value); }
        }

        public string DenumireClinica
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tDenumire.ToString()); }
        }

        public string DenumireCabinet
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tDenumireCabinet.ToString()); }
        }

        public string NumeMedic
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tNumeMedic.ToString()); }
        }

        public string PrenumeMedic
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tPrenumeMedic.ToString()); }
        }

        public string NumeTehnician
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tNumeTehnician.ToString()); }
        }

        //public string CuloareLucrare
        //{
        //    get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString()); }
        //}

        public string DenumirePrescurtata
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tDenumirePrescurtata.ToString()); }
        }

        public string PrenumeTehnician
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tPrenumeTehnician.ToString()); }
        }

        public int IdEtapaSetari
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdEtapaSetari.ToString()); }
        }

        public EnumStareEtapa StatusEtapa
        {
            get { return (EnumStareEtapa)this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nStatusEtapa.ToString()); }
        }

        public string StatusEtapaEticheta
        {
            get { return StructStareEtapa.GetStructById(this.StatusEtapa).Denumire; }
        }

        public string DenumireEtapa
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tDenumireEtapa.ToString()); }
        }

        public DateTime DataInceputEtapa
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataInceputEtapa.ToString()); }
        }

        public DateTime DataSfarsitEtapa
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataSfarsitEtapa.ToString()); }
        }

        public string DenumireLucrare
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tDenumireLucrare.ToString()); }
        }

        public string ObservatiiEtapa
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tObservatiiEtapa.ToString()); }
        }

        public bool Refacere
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DClientiComenzi.EnumCampuriTabela.bRefacere.ToString()); }
        }

        public int CuloareTehnician
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nCuloareTehnician.ToString()); }
        }

        public DateTime DataFactura
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataFactura.ToString()); }
        }

        public string SerieFactura
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tSerieFactura.ToString()); }
        }

        public int NumarFactura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nNumarFactura.ToString()); }
        }

        public EnumTipMoneda MonedaFactura
        {
            get { return this.MyDataRowGetItemAsMoneda(DClientiComenzi.EnumCampuriTabela.nMonedaFactura.ToString()); }
        }

        public string ObservatiiFactura
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tObservatiiFactura.ToString()); }
        }

        [BExport("IdReprezentantClient", true, 1)]
        public int IdReprezentantClient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdReprezentantClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdReprezentantClient.ToString(), value); }
        }

        public string CodLucrare
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tCodLucrare.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.tCodLucrare.ToString(), value); }
        }


        [BExport("NumePacient", true, 1)]
        public string NumePacient
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tNumePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.tNumePacient.ToString(), value); }
        }


        [BExport("PrenumePacient", true, 1)]
        public string PrenumePacient
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tPrenumePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.tPrenumePacient.ToString(), value); }
        }

        [BExport("DataNasterePacient", true, 1)]
        public DateTime DataNasterePacient
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataNasterePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.dDataNasterePacient.ToString(), value); }
        }

        public int Varsta
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nVarsta.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nVarsta.ToString(), value); }
        }

        [BExport("SexPacient", true, 1)]
        public int SexPacient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nSexPacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nSexPacient.ToString(), value); }
        }

        [BExport("DataPrimire", true, 1)]
        public DateTime DataPrimire
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString(), value); }
        }

        [BExport("DataLaGata", true, 1)]
        public DateTime DataLaGata
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        [BExport("IdCabinet", true, 1)]
        public int IdCabinet
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdCabinet.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdCabinet.ToString(), value); }
        }

        [BExport("IdLucrare", true, 1)]
        public int IdLucrare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdLucrare.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdLucrare.ToString(), value); }
        }

        [BExport("ValoareInitiala", true, 1)]
        public double ValoareInitiala
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenzi.EnumCampuriTabela.nValoareInitiala.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nValoareInitiala.ToString(), value); }
        }

        [BExport("ValoareFinala", true, 1)]
        public double ValoareFinala
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenzi.EnumCampuriTabela.nValoareFinala.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nValoareFinala.ToString(), value); }
        }
        /// <lore 04.09.2019>
        [BExport("PretUnitarInitial", true, 1)]
        public double PretUnitarInitial
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenzi.EnumCampuriTabela.nPretUnitarInitial.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nPretUnitarInitial.ToString(), value); }
        }

        [BExport("PretUnitarFinal", true, 1)]
        public double PretUnitarFinal
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenzi.EnumCampuriTabela.nPretUnitarFinal.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nPretUnitarFinal.ToString(), value); }
        }
        ///////////        

        [BExport("IdFactura", true, 1)]
        public int IdFactura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdFactura.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdFactura.ToString(), value); }
        }

        public int IdEtapaCurenta
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.xnIdEtapaCurenta.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.xnIdEtapaCurenta.ToString(), value); }
        }

        [BExport("Moneda", true, 1)]
        public CDefinitiiComune.EnumTipMoneda Moneda
        {
            get { return this.MyDataRowGetItemAsMoneda(DClientiComenzi.EnumCampuriTabela.nMoneda.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nMoneda.ToString(), value); }
        }

        [BExport("Urgent", true, 1)]
        public bool Urgent
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DClientiComenzi.EnumCampuriTabela.bUrgent.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.bUrgent.ToString(), value); }
        }

        [BExport("NrElemente", true, 1)]
        public int NrElemente
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenzi.EnumCampuriTabela.nNrElemente.ToString()); }
            set
            {
                this.ValoareFinala = Math.Max(1, value) * this.GetPretUnitar();
                this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.nNrElemente.ToString(), value);
            }
        }

        [BExport("Culoare", true, 1)]
        public string Culoare
        {
            get { return this.MyDataRowGetItem(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString(), value); }
        }

        [BExport("Acceptata", true, 1)]
        public bool Acceptata
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DClientiComenzi.EnumCampuriTabela.bAcceptata.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenzi.EnumCampuriTabela.bAcceptata.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiComenziMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiComenzi; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiComenzi(int pId) : this(pId, null)
        {
        }

        public BClientiComenzi(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiComenzi>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiComenzi(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiComenzi>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiComenzi
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pIdReprezentantClient"></param>
        /// <param name="pNumePacient"></param>
        /// <param name="pPrenumePacient"></param>
        /// <param name="pDataNasterePacient"></param>
        /// <param name="pSexPacient"></param>
        /// <param name="pDataPrimire"></param>
        /// <param name="pDataLaGata"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pIdCabinet"></param>
        /// <param name="pIdLucrare"></param>
        /// <param name="pValoareInitiala"></param>
        /// <param name="pValoareFinala"></param>
        /// <param name="pPretUnitarInitial"></param>
        /// <param name="pPretUnitarFinal"></param>
        /// <param name="pIdFactura"></param>
        /// <param name="pMoneda"></param>
        /// <param name="pUrgent"></param>
        /// <param name="pNrElemente"></param>
        /// <param name="pCuloare"></param>
        /// <param name="pAcceptata"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static int Add(int pIdClient, int pIdReprezentantClient, string pNumePacient, string pPrenumePacient, int pVarsta, int pSexPacient, DateTime pDataPrimire, DateTime pDataLaGata, string pObservatii, int pIdCabinet, int pIdLucrare, double pPretUnitarInitial, double pPretUnitarFinal, int pIdFactura, int pMoneda, bool pUrgent, int pNrElemente, string pCuloare, bool pAcceptata, string pCodLucrare, IDbTransaction pTranzactie)
        {
            //double pValoareInitiala = pPretUnitarInitial * Math.Max(1, pNrElemente);
            double pValoareInitiala = pPretUnitarInitial * Math.Max(1, pNrElemente);
            double pValoareFinala = pPretUnitarFinal * Math.Max(1, pNrElemente);


            int id = DClientiComenzi.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pIdReprezentantClient, pNumePacient, pPrenumePacient, pVarsta, pSexPacient, pDataPrimire, pDataLaGata, pObservatii, pIdCabinet, pIdLucrare, pValoareInitiala, pValoareFinala, pPretUnitarInitial, pPretUnitarFinal, pIdFactura, pMoneda, pUrgent, pNrElemente, pCuloare, pAcceptata, pCodLucrare, pTranzactie);

            return id;
        }

        public static BClientiComenzi Add(int pIdClient, int pIdReprezentantClient, string pNumePacient, string pPrenumePacient, int pVarsta, int pSexPacient, DateTime pDataPrimire, DateTime pDataLaGata, string pObservatii, int pIdCabinet, int pIdLucrare, bool pUrgent, double pValoareInitiala, double pValoareFinala, int pNrElemente, int pIdEtapa, int pIdTehnician, DateTime pDataTermen, bool pRefacere, int pStatusEtapa, string pCuloare, string pObservatiiEtapa, bool pAcceptata, string pCodLucrare, IDbTransaction pTranzactie)
        {
            BListaPreturiClienti lucrareClient = BListaPreturiClienti.GetPretClientIdLucrare(pIdLucrare, CDefinitiiComune.EnumStare.Activa, pTranzactie);

            int id = 0;

            if (pNrElemente <= 0)
                pNrElemente = 1;

            if (lucrareClient != null)
            {
                id = BClientiComenzi.Add(pIdClient, pIdReprezentantClient, pNumePacient, pPrenumePacient, pVarsta, pSexPacient, pDataPrimire, pDataLaGata, pObservatii, pIdCabinet, pIdLucrare, pValoareInitiala, pValoareFinala, 0, lucrareClient.GetIdMoneda(), pUrgent, pNrElemente, pCuloare, pAcceptata, pCodLucrare, pTranzactie);
            }
            else
            {
                BListaPreturiStandard lucrareStandard = BListaPreturiStandard.getById(pIdLucrare, pTranzactie);
                // lucrareStandard.GetValoare(), lucrareClient.GetValoareClient(),
                id = BClientiComenzi.Add(pIdClient, pIdReprezentantClient, pNumePacient, pPrenumePacient, pVarsta, pSexPacient, pDataPrimire, pDataLaGata, pObservatii, pIdCabinet, pIdLucrare, pValoareInitiala, pValoareFinala, 0, lucrareStandard.GetIdMoneda(), pUrgent, pNrElemente,
                    pCuloare, pAcceptata, pCodLucrare, pTranzactie);
            }

            BClientiComenzi comanda = new Clienti.BClientiComenzi(id, pTranzactie);

            if (pIdEtapa > 0)
            {
                //Adaugam etapa
                int idEtapaCurenta = BClientiComenziEtape.Add(id, pIdEtapa, pDataPrimire, pDataTermen, pIdTehnician, pObservatiiEtapa, pStatusEtapa, pRefacere, pTranzactie);

                //Facem referinta
                comanda.IdEtapaCurenta = idEtapaCurenta;
                comanda.UpdateAll(pTranzactie);
            }

            return comanda;
        }

        public static double GetTotalFacturiClient(int pIdClient, IDbTransaction pTranzactie)
        {
            double nTotalFacturi = 0;
            using (DataSet ds = DClientiComenzi.GetTotalFacturi(pIdClient, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nTotalFacturi = CUtil.GetAsDouble(dr["nTotal"]);
                }
            }
            return nTotalFacturi;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdLucrare)
        {
            return pIdLucrare != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiComenzi
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiComenzi GetListByParam(int pIdClient, int pIdReprezentant, int pIdCabinet, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListByParam(pIdClient, pIdReprezentant, pIdCabinet, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        /// <summary>
        /// Recuperam ultimele lucrari ale tuturor clinicilor din baza de date
        /// </summary>
        /// <param name="pTranzactie"></param>
        /// <returns></returns>
        public static BColectieClientiComenzi GetUltimeleLucrariPerClinica(IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetUltimeleLucrariPerClinica(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        public static BColectieClientiComenzi GetUltimeleLucrariPerClinica(List<int> pListaIdClienti, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();

            if (!CUtil.EsteListaIntVida(pListaIdClienti))
            {
                using (DataSet ds = DClientiComenzi.GetUltimeleLucrariPerClinica(pListaIdClienti, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstDClientiComenzi.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return lstDClientiComenzi;
        }

        /// <summary>
        /// Recuperam ultima lucrare primita de la o clinica anume
        /// </summary>
        /// <param name="pIdClinica"></param>
        /// <param name="pTranzactie"></param>
        /// <returns></returns>
        public static BClientiComenzi GetUltimaLucrare(int pIdClinica, IDbTransaction pTranzactie)
        {
            using (DataSet ds = DClientiComenzi.GetUltimaLucrare(pIdClinica, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    return new BClientiComenzi(dr);
                }
            }
            return null;
        }


        public static BColectieClientiComenzi GetListaLucrariNefacturateByIdClinica(int pIdClinica, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListaLucrariNefacturateByIdClinica(pIdClinica, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        public static BColectieClientiComenzi GetListaLucrariByIdClinica(int pIdClinica, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiLucrari = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListaLucrariByIdClinica(pIdClinica, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiLucrari.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiLucrari;
        }


        public static BColectieClientiComenzi GetListaLucrariNefacturate(int pIdClinica, DateTime pDataInceput, DateTime pDataSfarsit, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListaLucrariNefacturate(pIdClinica, pDataInceput, pDataSfarsit, getDataInteres(pDataInteres), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        private static string getDataInteres(BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres)
        {
            switch (pDataInteres)
            {
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare:
                    return DClientiComenzi.EnumCampuriTabela.dDataCreare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire:
                    return DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataLaGata:
                    return DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataTermen:
                    return DClientiComenzi.EnumCampuriTabela.dDataSfarsitEtapa.ToString();
            }

            return DClientiComenzi.EnumCampuriTabela.dDataCreare.ToString();
        }

        public static BColectieClientiComenzi GetListByParamIntrePerioada(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListByParamSiPerioada(getDataInteres(pDataInteres), pIdTehnician, pDataInceput, pDataSfarsit, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        public static BColectieClientiComenzi GetListByClientSiLucrareIntrePerioada(int pIdClinica, int pIdLucrare, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi lstDClientiComenzi = new BColectieClientiComenzi();
            using (DataSet ds = DClientiComenzi.GetListByClientSiLucrareIntrePerioada(getDataInteres(pDataInteres), pIdClinica, pIdLucrare, pDataInceput, pDataSfarsit, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenzi(dr));
                }
            }
            return lstDClientiComenzi;
        }

        public static Dictionary<int, int> GetDictIdClinicaNrLucrariNefacturate(List<int> plistaIdClinici, IDbTransaction pTranzactie)
        {
            Dictionary<int, int> listaRetur = new Dictionary<int, int>();
            if (!CUtil.EsteListaIntVida(plistaIdClinici))
            {
                using (DataSet ds = DClientiComenzi.SelectCountByColoanaSiCheieNotNull(plistaIdClinici, pTranzactie))
                {
                    int idClinica = 0;
                    int totalLucrariNefacturate = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idClinica = CUtil.GetAsInt32(dr[DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()]);
                        totalLucrariNefacturate = CUtil.GetAsInt32(dr["nNumar"]);
                        listaRetur.Add(idClinica, totalLucrariNefacturate);
                    }
                }
            }
            return listaRetur;
        }

        public static Dictionary<int, double> GetDictIdClinicaTotalFacturi(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            Dictionary<int, double> dictRetur = new Dictionary<int, double>();

            if (!CUtil.EsteListaIntVida(pListaIdClinici))
            {
                using (DataSet ds = DClientiComenzi.GetDictIdClinicaTotalFacturi(pListaIdClinici, pTranzactie))
                {
                    int idClinica = 0;
                    double totalFact = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idClinica = CUtil.GetAsInt32(dr[DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()]);
                        totalFact = CUtil.GetAsDouble(dr["nTotal"]);
                        dictRetur.Add(idClinica, totalFact);
                    }
                }
            }

            return dictRetur;
        }

        public static Dictionary<int, int> GetDictIdClinicaNrLucrari(List<int> plistaIdClinici, IDbTransaction pTranzactie)
        {
            Dictionary<int, int> listaRetur = new Dictionary<int, int>();
            if (!CUtil.EsteListaIntVida(plistaIdClinici))
            {
                using (DataSet ds = DClientiComenzi.SelectCountByColoana(plistaIdClinici, pTranzactie))
                {
                    int idClinica = 0;
                    int totalLucrari = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idClinica = CUtil.GetAsInt32(dr[DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()]);
                        totalLucrari = CUtil.GetAsInt32(dr["nNumar"]);
                        listaRetur.Add(idClinica, totalLucrari);
                    }
                }
            }
            return listaRetur;
        }

        internal static void UpdateIdFacturaForListaId(int pIdFactura, List<int> pListaIdLucrariClienti, IDbTransaction pTranzactie)
        {
            if (!CUtil.EsteListaIntVida(pListaIdLucrariClienti))
            {
                DClientiComenzi.UpdateIdFacturaForListaId(pIdFactura, pListaIdLucrariClienti, pTranzactie);
            }
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea DataRow-ului corespunzator obiectului in baza de date
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Un DataRow ce contine informatiile corespunzatoare obiectului</returns>
        /// <remarks></remarks>
        private static DataRow GetDataRowForObjet(int pId, IDbTransaction pTranzactie)
        {
            if (pId <= 0)
                throw new IdentificareBazaImposibilaException("BClientiComenzi");
            using (DataSet ds = DClientiComenzi.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiComenzi");
            }
        }

        public static BColectieClientiComenzi GetByListaIdFacturi(List<int> pListaIdFacturi, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            if (!CUtil.EsteListaIntVida(pListaIdFacturi))
            {
                using (DataSet ds = DClientiComenzi.GetByListaIdFacturi(pListaIdFacturi, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiComenzi getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiComenzi.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiComenzi GetByIdFactura(int pIdFactura, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            if (pIdFactura > 0)
            {
                using (DataSet ds = DClientiComenzi.GetByIdFactura(pIdFactura, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiComenzi GetByIdClient(int pIdClient, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            if (pIdClient > 0)
            {
                using (DataSet ds = DClientiComenzi.GetByIdClient(pIdClient, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiComenzi GetListaNeachitateIntegral(int pIdClient, IDbTransaction pTranzactie)
        {
            BColectieClientiComenzi listaRetur = new BColectieClientiComenzi();
            if (pIdClient > 0)
            {
                using (DataSet ds = DClientiComenzi.GetListaNeachitateIntegral(pIdClient, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta
        public BListaPreturiStandard GetLucrare(IDbTransaction pTranzactie)
        {
            return BListaPreturiStandard.getById(this.IdLucrare, pTranzactie);
        }

        public bool EstePretulModificat()
        {
            return this.NrElemente * GetPretUnitarInitial() != this.ValoareFinala;
        }

        internal void ScoateDinFactura(IDbTransaction pTranzactie)
        {
            this.IdFactura = 0;
            this.UpdateAll(pTranzactie);
        }

        public double GetValoareMoneda(CDefinitiiComune.EnumTipMoneda pMoneda, double pCursSchimb)
        {
            return CUtil.GetValoareMoneda(this.ValoareFinala, this.Moneda, pCursSchimb, pMoneda);
        }

        public double GetPretUnitar()
        {
            return this.ValoareFinala / Math.Max(1, this.NrElemente);
        }

        public double GetPretUnitarInitial()
        {
            return this.ValoareInitiala / Math.Max(1, this.NrElemente);
        }

        public object GetEtichetaMoneda()
        {
            return CStructuriComune.StructTipMoneda.GetStringByEnum(this.Moneda);
        }

        public string GetNumePrenumePacient()
        {
            return string.Format("{0} {1}", this.NumePacient, this.PrenumePacient);
        }

        public string GetDenumirePrescurtata()
        {
            if (!string.IsNullOrEmpty(this.DenumirePrescurtata))
                return this.DenumirePrescurtata;
            return this.DenumireLucrare;
        }

        public void CloseEtapa(BClientiComenziEtape pEtapa, IDbTransaction pTrans)
        {
            if (pEtapa != null)
            {
                //O inchidem
                pEtapa.Close(true, string.Empty, pTrans);

                //Daca era cea curenta atunci ne legam la cea de dinainte
                if (this.IdEtapaCurenta == pEtapa.Id)
                {
                    BColectieClientiComenziEtape listaEtape = GetListaEtape(pTrans);

                    BClientiComenziEtape etapAnterioara = listaEtape.GetEtapaAnterioara(pEtapa);

                    if (etapAnterioara != null)
                        this.IdEtapaCurenta = etapAnterioara.Id;
                    else
                        this.IdEtapaCurenta = 0;

                    this.UpdateAll(pTrans);
                }
            }
        }

        public BColectieClientiComenziEtape GetListaEtape(IDbTransaction pTranzactie)
        {
            return BClientiComenziEtape.GetListByIdComanda(this.Id, CDefinitiiComune.EnumStare.Toate, pTranzactie);
        }

        public string GetDenumireClinicaCabinet()
        {
            if (string.IsNullOrEmpty(this.DenumireCabinet))
                return this.DenumireClinica;

            return string.Format("{0} - {1}", this.DenumireClinica, this.DenumireCabinet);
        }

        public string GetIdentitateMedic()
        {
            return string.Format("{0} {1}", this.NumeMedic, this.PrenumeMedic);
        }

        public string GetIdentitateTehnician()
        {
            return string.Format("{0} {1}", this.NumeTehnician, this.PrenumeTehnician);
        }

        public static BClientiComenzi getComanda(int lId, IDbTransaction xTrans)
        {
            if (_lDictComenzi == null)
                _lDictComenzi = new Dictionary<int, BClientiComenzi>();

            if (!_lDictComenzi.ContainsKey(lId))
                _lDictComenzi.Add(lId, new BClientiComenzi(lId, xTrans));

            return _lDictComenzi[lId];
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public override bool UpdateAll(IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = false;

                if (!this.ExistaProprietatiModificate())
                    succesModificare = true;
                else
                    succesModificare = DClientiComenzi.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
                return succesModificare;
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de actualizare generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        public bool UpdateAll()
        {
            return this.UpdateAll(null);
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <returns>True daca inregistrarea a fost modificata; False in caz contrar</returns>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public bool UpdateAll(int pIdEtapaParam, int pIdTehnician, DateTime pDataTermen, string pObservatiiEtapa, bool pRefacere, int pStatus, IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = false;

                //Actualizam sau adaugam etapa curenta
                if (this.IdEtapaSetari != pIdEtapaParam)
                {
                    //Add
                    int idEtapaAdaugata = BClientiComenziEtape.Add(this.Id, pIdEtapaParam, DateTime.Now, pDataTermen, pIdTehnician, pObservatiiEtapa, pStatus, pRefacere, pTranzactie);
                    this.IdEtapaCurenta = idEtapaAdaugata;
                }
                else
                {
                    //Update
                    if (this.IdEtapaCurenta > 0)
                    {
                        BClientiComenziEtape etapaCurenta = new Clienti.BClientiComenziEtape(this.IdEtapaCurenta, pTranzactie);

                        if (this.IdTehnician != pIdTehnician || this.Refacere != pRefacere || Convert.ToInt32(this.StatusEtapa) != pStatus || !this.ObservatiiEtapa.Equals(pObservatiiEtapa) || this.DataSfarsitEtapa != pDataTermen)
                        {
                            etapaCurenta.IdTehnician = pIdTehnician;
                            etapaCurenta.DataFinal = pDataTermen;
                            etapaCurenta.Observatii = pObservatiiEtapa;
                            etapaCurenta.Refacere = pRefacere;
                            etapaCurenta.Status = (EnumStareEtapa)pStatus;
                            etapaCurenta.UpdateAll(pTranzactie);
                        }
                    }
                }

                if (!this.ExistaProprietatiModificate())
                    succesModificare = true;
                else
                    succesModificare = DClientiComenzi.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
                return succesModificare;
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de actualizare generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdReprezentantClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tNumePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tPrenumePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataNasterePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nSexPacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdCabinet.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdLucrare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nValoareInitiala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nValoareFinala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nPretUnitarInitial.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nPretUnitarFinal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nMoneda.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.bUrgent.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nNrElemente.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdEtapaCurenta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.bAcceptata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nVarsta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tCodLucrare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdTehnician.ToString());
        }

        /// <summary>
        /// Metoda de instanta ce permite inchiderea(dezactivarea) obiectului
        /// </summary>
        /// <param name="pInchidere">inchidem sau activam?</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Close(bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiComenzi");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;

                //Inchidem obiectul in baza de date
                DClientiComenzi.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de inchidere generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdReprezentantClient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdReprezentantClient.ToString(), this.IdReprezentantClient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tNumePacient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tNumePacient.ToString(), this.NumePacient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tPrenumePacient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tPrenumePacient.ToString(), this.PrenumePacient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataNasterePacient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.dDataNasterePacient.ToString(), this.DataNasterePacient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nSexPacient.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nSexPacient.ToString(), this.SexPacient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.dDataPrimire.ToString(), this.DataPrimire);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.dDataLaGata.ToString(), this.DataLaGata);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdCabinet.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdCabinet.ToString(), this.IdCabinet);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdLucrare.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdLucrare.ToString(), this.IdLucrare);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nValoareInitiala.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nValoareInitiala.ToString(), this.ValoareInitiala);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nValoareFinala.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nValoareFinala.ToString(), this.ValoareFinala);
            ////lore 05.09.2019
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nPretUnitarInitial.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nPretUnitarInitial.ToString(), this.PretUnitarInitial);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nPretUnitarFinal.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nPretUnitarFinal.ToString(), this.PretUnitarFinal);
            /////////
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdFactura.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdFactura.ToString(), this.IdFactura);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nMoneda.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nMoneda.ToString(), this.Moneda);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.bUrgent.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.bUrgent.ToString(), this.Urgent);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nNrElemente.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nNrElemente.ToString(), this.NrElemente);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.xnIdEtapaCurenta.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.xnIdEtapaCurenta.ToString(), this.IdEtapaCurenta);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tCuloareLucrare.ToString(), this.Culoare);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.bAcceptata.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.bAcceptata.ToString(), this.Acceptata);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.nVarsta.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.nVarsta.ToString(), this.Varsta);
            if (this.IsMyDataRowItemHasChanged(DClientiComenzi.EnumCampuriTabela.tCodLucrare.ToString()))
                dictRezultat.Adauga(DClientiComenzi.EnumCampuriTabela.tCodLucrare.ToString(), this.CodLucrare);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiComenzi");

            FillObjectWithDataRow<BClientiComenzi>(GetDataRowForObjet(this.Id, pTranzactie), this);
        }

        /// <summary>
        /// Metoda pentru serializarea obiectului in flux XML
        /// </summary>
        /// <returns>Un sir de caractere ce reprezinta obiectul sub forma de flux XML</returns>
        /// <remarks></remarks>
        public new string ObjectToXMLString()
        {
            System.Xml.XmlDocument myXmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement myXmlElem;
            string sRet = string.Empty;

            //Cream documentul:
            myXmlDoc.LoadXml("<DClientiComenzi></DClientiComenzi>");

            //Adaugam elementele clasei BClientiComenzi
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDREPREZENTANTCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdReprezentantClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMEPACIENT");
            myXmlElem.InnerText = this.NumePacient;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PRENUMEPACIENT");
            myXmlElem.InnerText = this.PrenumePacient;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATANASTEREPACIENT");
            myXmlElem.InnerText = Convert.ToString(this.DataNasterePacient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SEXPACIENT");
            myXmlElem.InnerText = Convert.ToString(this.SexPacient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAPRIMIRE");
            myXmlElem.InnerText = Convert.ToString(this.DataPrimire);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATALAGATA");
            myXmlElem.InnerText = Convert.ToString(this.DataLaGata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.DataInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MOTIVINCHIDERE");
            myXmlElem.InnerText = this.MotivInchidere;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCABINET");
            myXmlElem.InnerText = Convert.ToString(this.IdCabinet);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLUCRARE");
            myXmlElem.InnerText = Convert.ToString(this.IdLucrare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOAREINITIALA");
            myXmlElem.InnerText = Convert.ToString(this.ValoareInitiala);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOAREFINALA");
            myXmlElem.InnerText = Convert.ToString(this.ValoareFinala);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDFACTURA");
            myXmlElem.InnerText = Convert.ToString(this.IdFactura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MONEDA");
            myXmlElem.InnerText = Convert.ToString(this.Moneda);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("URGENT");
            myXmlElem.InnerText = Convert.ToString(this.Urgent);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NRELEMENTE");
            myXmlElem.InnerText = Convert.ToString(this.NrElemente);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CULOARE");
            myXmlElem.InnerText = this.Culoare;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);


            myXmlElem = myXmlDoc.CreateElement("ACCEPTATA");
            myXmlElem.InnerText = Convert.ToString(this.Acceptata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        public override string ToString()
        {
            if (this.NrElemente <= 1)
                return this.DenumireLucrare;

            return string.Format("{0}x{1}", this.NrElemente, this.DenumireLucrare);
        }

        public BClienti GetClient()
        {
            return new BClienti(this.IdClient);
        }

        public BListaPreturiStandard GetPretSetari()
        {
            return new BListaPreturiStandard(this.IdLucrare);
        }

        #endregion //Metode de instanta

        #region Metode de comparatie



        #endregion //Metode de comparatie
    }
}
