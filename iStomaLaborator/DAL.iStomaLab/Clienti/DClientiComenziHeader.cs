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
    public static class DClientiComenziHeader
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiComenziHeader_TD";
       public const string NUME_VIEW = "ClientiComenziHeader_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,  //Clinica
            tDenumireClinica,
            xnIdCabinet,
            tDenumireCabinet,
            xnIdReprezentantClient,           
            xnIdPacient,           
            tCodComanda,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tObservatii,
            dDataPrimire,
            dDataLaGata
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiComenziHeader_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie); //aici era NUME_VIEW dar crapa cand nu existau date
        }
        
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
                dictCorespondenta.Adauga(null, pIdTehnician);  //EnumCampuriTabela.xnIdTehnician.ToString() era in loc de null
            return DGeneral.SelectByCriteriiSiPerioadaCuAltaDataISNULL(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataCreare.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataCreare.ToString(), pStare, pTranzactie);
        }

        public static DataSet GetUltimeleLucrariPerClinica(IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiveById(NUME_VIEW, NUME_TABELA, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pTranzactie);
        }

        public static DataSet GetUltimaLucrare(int pIdClinica, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiva(NUME_VIEW, EnumCampuriTabela.dDataPrimire.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pIdClinica, pTranzactie);
        }

        public static DataSet GetIdClient(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiva(NUME_VIEW, EnumCampuriTabela.dDataPrimire.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pId, pTranzactie);
        }


        #endregion //SELECT

        #region INSERT         
        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiComenzi_TD
        /// </summary>
        /// <param name="pIdClient"></param>      
        /// <param name="pIdCabinet"></param>    
        /// <param name="pIdReprezentantClient"></param>         
        /// <param name="pIdPacient"></param>  
        /// <param name="pObservatii"></param>  
        /// <param name="pCodComanda"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pDataCreare"></param>
        /// <param name="pDataInchidere"></param>
        /// <param name="pnUtilizatorCreare"></param>
        /// <param name="pnUtilizatorInchidere"></param>
        /// <param name="pMotivInchidere"></param>


        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, int pIdCabinet, int pIdReprezentantClient,int pIdPacient, string pCodComanda,string pObservatii, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);          
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdCabinet.ToString(), pIdCabinet);           
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdReprezentantClient.ToString(), pIdReprezentantClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdPacient.ToString(), pIdPacient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodComanda.ToString(), pCodComanda);
            //dictCorespondenta.Adauga(EnumCampuriTabela.xnUtilizatorInchidere.ToString(), pnUtilizatorInchidere);
            // dictCorespondenta.Adauga(EnumCampuriTabela.xnUtilizatorCreare.ToString(), pnUtilizatorCreare);
           // dictCorespondenta.Adauga(EnumCampuriTabela.dDataCreare.ToString(), pDataCreare);
           // dictCorespondenta.Adauga(EnumCampuriTabela.dDataInchidere.ToString(), pDataInchidere);       
            dictCorespondenta.Adauga(EnumCampuriTabela.tMotivInchidere.ToString(), pMotivInchidere);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
          
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
     //       DGeneral.UpdateAllByListaId(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pListaIdLucrariClienti, EnumCampuriTabela.xnIdFactura.ToString(), pIdFactura, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }
}
