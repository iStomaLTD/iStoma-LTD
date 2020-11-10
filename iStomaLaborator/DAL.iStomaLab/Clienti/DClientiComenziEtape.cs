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
    public static class DClientiComenziEtape
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiComenziEtape_TD";
        public const string NUME_VIEW = "ClientiComenziEtape_TD_V";
       
        public enum EnumCampuriRezumat
        {
            xnIdTehnician,
            NrElemente,
            TotalCuvenit
        }

        public enum EnumCampuriTabela
        {
            nId,
            xnIdComandaClient,
            xnIdEtapa,
            dDataInceput,
            dDataFinal,
            xnIdTehnician,
            tObservatii,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tDenumire,
            nStatus,
            bRefacere,
            xnIdClient,
            xnIdReprezentantClient,
            tNumePacient,
            tPrenumePacient,
            tObservatiiComanda,
            xnIdCabinet,
            xnIdLucrare,
            nNrElemente,
            bUrgent,
            tCuloareLucrare,
            tDenumireClient,
            tNume,
            tPrenume,
            tPorecla,
            tDenumireLucrare,
            tDenumirePrescurtataLucrare,
            dDataCreareLucrare,
            dDataPrimireLucrare,
            dDataLaGataLucrare,
            nValoareInitiala,
            nValoareFinala,
            nPretUnitarInitial,
            nPretUnitarFinal,
            xnIdFactura,
            nMoneda,
            Venit,
            xnIdEtapaVenit
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByTehnicianPerioada(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, string pNumeColoanaDataInteres, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdTehnician > 0)
                dictCorespondenta.Add(EnumCampuriTabela.xnIdTehnician.ToString(), pIdTehnician);

            return DGeneral.SelectByCriteriiSiPerioada(NUME_VIEW, dictCorespondenta, pNumeColoanaDataInteres, pDataInceput, pDataSfarsit, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiComenziEtape_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiComenziEtape_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdComandaClient(int pIdComandaClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdComandaClient.ToString(), pIdComandaClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdTehnician(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTehnician.ToString(), pIdTehnician);
            return DGeneral.SelectByCriteriiSiPerioada(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataInceput.ToString(), pDataInceput, pDataSfarsit, pTranzactie);
        }


        public static DataSet GetListByParamIdComandaClientDescrescator(int pIdComandaClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdComandaClient.ToString(), pIdComandaClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), false, pStare, pTranzactie);
        }

        public static DataSet GetListaVenituri(DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@DataInceput", pDataInceput);
            listaParametri.Add("@DataSfarsit", pDataSfarsit);

            return CCerereSQL.GetDataSetByStoredProc("ClientiComenziEtape_TD_GetRezumatVenituri", listaParametri, pTranzactie);
        }

        public static DataSet GetListaDetaliatVenituri(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@IdTehnician", pIdTehnician);
            listaParametri.Add("@DataInceput", pDataInceput);
            listaParametri.Add("@DataSfarsit", pDataSfarsit);

            return CCerereSQL.GetDataSetByStoredProc("ClientiComenziEtape_TD_GetDetaliatVenituri", listaParametri, pTranzactie);
        }


        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiComenziEtape_TD
        /// </summary>
        /// <param name="pIdComandaClient"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pDataInceput"></param>
        /// <param name="pDataFinal"></param>
        /// <param name="pIdTehnician"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pStatus"></param>
        /// <param name="pRefacere"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdComandaClient, int pIdEtapa, DateTime pDataInceput, DateTime pDataFinal, int pIdTehnician, string pObservatii, int pStatus, bool pRefacere, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdComandaClient.ToString(), pIdComandaClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEtapa.ToString(), pIdEtapa);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataInceput.ToString(), pDataInceput);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataFinal.ToString(), pDataFinal);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTehnician.ToString(), pIdTehnician);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nStatus.ToString(), pStatus);
            dictCorespondenta.Adauga(EnumCampuriTabela.bRefacere.ToString(), pRefacere);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiComenziEtape_TD
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
            return DGeneral.UpdateAllById(NUME_VIEW, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }
      
        public static DataSet GetListByTehnicianSiLucrareIntrePerioada(int pIdTehnician, int pIdLucrare, DateTime pDataInceput, DateTime pDataSfarsit, string pNumeColoanaDataInteres, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdTehnician > 0)
                dictCorespondenta.Add(EnumCampuriTabela.xnIdTehnician.ToString(), pIdTehnician);
            if (pIdLucrare > 0)
                dictCorespondenta.Add(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);

            return DGeneral.SelectByCriteriiSiPerioada(NUME_VIEW, dictCorespondenta, pNumeColoanaDataInteres, pDataInceput, pDataSfarsit, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }
              


        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }
}
