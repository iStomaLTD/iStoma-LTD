using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Clienti
{
    public static class DClientiComenzi
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiComenzi_TD";
        public const string NUME_VIEW = "ClientiComenzi_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,
            xnIdReprezentantClient,
            tNumePacient,
            tPrenumePacient,
            dDataNasterePacient,
            nSexPacient,
            dDataPrimire,
            dDataLaGata,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tObservatii,
            xnIdCabinet,
            xnIdLucrare,
            nValoareInitiala,
            nValoareFinala,
            nPretUnitarInitial,
            nPretUnitarFinal,
            xnIdFactura,
            nMoneda,
            bUrgent,
            nNrElemente,
            xnIdEtapaCurenta,
            xnIdTehnician,
            tDenumire,
            tDenumireCabinet,
            tNumeMedic,
            tPrenumeMedic,
            tNumeTehnician,
            tPrenumeTehnician,
            xnIdEtapaSetari,
            tDenumireEtapa,
            tDenumireLucrare,
            dDataInceputEtapa,
            dDataSfarsitEtapa,
            tObservatiiEtapa,
            tCuloareLucrare,
            nStatusEtapa,
            tDenumirePrescurtata,
            bRefacere,
            bAcceptata,
            nCuloareTehnician,
            dDataFactura,
            tSerieFactura,
            nNumarFactura,
            nMonedaFactura,
            tObservatiiFactura,
            nVarsta,
            tCodLucrare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetDictIdClinicaTotalFacturi(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectSumByColoanaSiCheieNotNull(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), pListaIdClinici, EnumCampuriTabela.xnIdFactura.ToString(), EnumCampuriTabela.nValoareFinala.ToString(),  pTranzactie);
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        public static DataSet GetByListaIdFacturi(List<int> pListaIdFacturi, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.xnIdFactura.ToString(), pListaIdFacturi, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiComenzi_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static DataSet GetByIdFactura(int pIdFactura, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.xnIdFactura.ToString(), pIdFactura, pTranzactie);
        }

        public static DataSet GetByIdClient(int pIdClient, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.xnIdClient.ToString(), pIdClient, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiComenzi_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdClient, int pIdReprezentant, int pIdCabinet, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClient > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            if (pIdReprezentant > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdReprezentantClient.ToString(), pIdReprezentant);
            if (pIdCabinet > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdCabinet.ToString(), pIdCabinet);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdClient.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamSiPerioada(string pDenumireColoanaDataInteres, int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdTehnician > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTehnician.ToString(), pIdTehnician);
            return DGeneral.SelectByCriteriiSiPerioadaCuAltaDataISNULL(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataSfarsitEtapa.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataCreare.ToString(), pStare, pTranzactie);
        }

        public static DataSet GetListByClientSiLucrareIntrePerioada(string pDenumireColoanaDataInteres, int pIdclinica, int pIdLucrare, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdclinica > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdclinica);
            if (pIdLucrare > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);

            return DGeneral.SelectByCriteriiSiPerioadaCuAltaDataISNULL(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataSfarsitEtapa.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataCreare.ToString(), pStare, pTranzactie);
        }

        public static DataSet GetListaLucrariNefacturate(int pIdClinica, DateTime pDataInceput, DateTime pDataSfarsit, string pNumeColoanaDataInteres, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClinica > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClinica);

            return DGeneral.SelectByCriteriiSiPerioadaWhereNull(NUME_VIEW, dictCorespondenta, pNumeColoanaDataInteres, pDataInceput, pDataSfarsit, CDefinitiiComune.EnumStare.Activa, EnumCampuriTabela.xnIdFactura.ToString(), pTranzactie);
        }

        public static DataSet GetListaLucrariNefacturateByIdClinica(int pIdClinica, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClinica > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClinica);

            return DGeneral.SelectByCriteriiWhereNull(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdFactura.ToString(), EnumCampuriTabela.nId.ToString(), true, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        public static DataSet GetListaLucrariByIdClinica(int pIdClinica, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClinica > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClinica);

            return DGeneral.SelectByCriteriiWhereNotNull(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdFactura.ToString(), EnumCampuriTabela.nId.ToString(), true, CDefinitiiComune.EnumStare.Activa, pTranzactie);            
        }

        public static DataSet GetTotalFacturi(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectSumByColoanaSiCheieWhereNotNull(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), EnumCampuriTabela.nValoareFinala.ToString(), pId, EnumCampuriTabela.xnIdFactura.ToString(), pTranzactie);
        }


        public static DataSet GetUltimeleLucrariPerClinica(List<int> pListaIdClienti, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiveById(NUME_VIEW, NUME_TABELA, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pListaIdClienti, pTranzactie);
        }
        public static DataSet GetUltimeleLucrariPerClinica(IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiveById(NUME_VIEW, NUME_TABELA, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pTranzactie);
        }

        public static DataSet SelectCountByColoanaSiCheieNotNull(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectCountByColoanaSiCheieNotNull(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), pListaIdClinici, EnumCampuriTabela.xnIdFactura.ToString(), pTranzactie);
        }

        public static DataSet SelectCountByColoana(List<int> plistaIdClinici, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectCountByColoana(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), pTranzactie);
        }


        public static DataSet GetUltimaLucrare(int pIdClinica, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiva(NUME_VIEW, EnumCampuriTabela.dDataPrimire.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pIdClinica, pTranzactie);
        }
        public static DataSet GetListaNeachitateIntegral(int pIdClient, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@xnIdClient", pIdClient);

            return CCerereSQL.GetDataSetByStoredProc("ClientiComenzi_TD_GetListaNeachitateIntegral", listaParametri, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiComenzi_TD
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
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, int pIdReprezentantClient, string pNumePacient, string pPrenumePacient, int pVarsta, int pSexPacient, DateTime pDataPrimire, DateTime pDataLaGata, string pObservatii, int pIdCabinet, int pIdLucrare, double pValoareInitiala, double pValoareFinala, double pPretUnitarInitial, double pPretUnitarFinal, int pIdFactura, int pMoneda, bool pUrgent, int pNrElemente, string pCuloare, bool pAcceptata, string tCodLucrare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdReprezentantClient.ToString(), pIdReprezentantClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumePacient.ToString(), pNumePacient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPrenumePacient.ToString(), pPrenumePacient);
            dictCorespondenta.Adauga(EnumCampuriTabela.nVarsta.ToString(), pVarsta);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSexPacient.ToString(), pSexPacient);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataPrimire.ToString(), pDataPrimire);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataLaGata.ToString(), pDataLaGata);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdCabinet.ToString(), pIdCabinet);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareInitiala.ToString(), pValoareInitiala);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareFinala.ToString(), pValoareFinala);
            //lore 03.09.2019
            dictCorespondenta.Adauga(EnumCampuriTabela.nPretUnitarInitial.ToString(), pPretUnitarInitial);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPretUnitarFinal.ToString(), pPretUnitarFinal);
            /////////////////
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdFactura.ToString(), pIdFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.nMoneda.ToString(), pMoneda);
            dictCorespondenta.Adauga(EnumCampuriTabela.bUrgent.ToString(), pUrgent);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNrElemente.ToString(), pNrElemente);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCuloareLucrare.ToString(), pCuloare);
            dictCorespondenta.Adauga(EnumCampuriTabela.bAcceptata.ToString(), pAcceptata);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodLucrare.ToString(), tCodLucrare);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiComenzi_TD
        /// </summary>
        /// <param name="pIdUtilizatorInchidere">Id-ul utilizatorului care a declansat actiunea</param>
        /// <param name="pInchidere">pInchidere = True: coloana « dDataInchidere » va avea valoarea db.Null, altfel va avea valoarea datei de pe serverul pe care e gazduita baza de date</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia sql utilizata</param>
        /// <remarks></remarks>
        public static void CloseById(int pIdUtilizatorInchidere, int pId, bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            DGeneral.CloseById(NUME_TABELA, pIdUtilizatorInchidere, pInchidere, pMotivInchidere, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela ClientiComenzi_TD
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static void UpdateIdFacturaForListaId(int pIdFactura, List<int> pListaIdLucrariClienti, IDbTransaction pTranzactie)
        {
            DGeneral.UpdateAllByListaId(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pListaIdLucrariClienti, EnumCampuriTabela.xnIdFactura.ToString(), pIdFactura, pTranzactie);
        }
        

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }
}
