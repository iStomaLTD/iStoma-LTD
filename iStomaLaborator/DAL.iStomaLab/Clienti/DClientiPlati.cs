using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Clienti
{
    public static class DClientiPlati
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiPlati_TD";
        public const string NUME_VIEW = "ClientiPlati_TD_V";

        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,
            dDataPlata,
            nSumaPlatita,
            nModalitatePlata,
            nCursBNR,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tObservatii,
            tDenumire
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }
        
        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiPlati_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }
        
        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiPlati_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdClient.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdClient.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetDictIdClinicaTotalIncasari(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectSumByColoana(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), EnumCampuriTabela.nSumaPlatita.ToString(), pTranzactie);
        }

        public static DataSet GetTotalIncasari(int pId, IDbTransaction pTranzactie) 
        {
            return DGeneral.SelectSumByColoanaSiCheie(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), EnumCampuriTabela.nSumaPlatita.ToString(), pId, pTranzactie);
        }

        public static DataSet GetListByParamSiPerioada(int pIdClient, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClient > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);

            return DGeneral.SelectByCriteriiSiPerioadaCuAltaDataISNULL(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataPlata.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataCreare.ToString(), pStare, pTranzactie);
        }

        //pIdClinica, pDataInceput, pDataSfarsit, pTranzactie

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiPlati_TD
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pDataPlata"></param>
        /// <param name="pSumaPlatita"></param>
        /// <param name="pModalitatePlata"></param>
        /// <param name="pCursBNR"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, DateTime pDataPlata, double pSumaPlatita, int pModalitatePlata, double pCursBNR, string pObservatii, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataPlata.ToString(), pDataPlata);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSumaPlatita.ToString(), pSumaPlatita);
            dictCorespondenta.Adauga(EnumCampuriTabela.nModalitatePlata.ToString(), pModalitatePlata);
            dictCorespondenta.Adauga(EnumCampuriTabela.nCursBNR.ToString(), pCursBNR);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiPlati_TD
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
        /// Modificam informatiile unei inregistrari din tabela ClientiPlati_TD
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }
        

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE


    }
}
