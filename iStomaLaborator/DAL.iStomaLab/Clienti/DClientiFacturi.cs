using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Clienti
{
    public static class DClientiFacturi
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiFacturi_TD";
        public const string NUME_VIEW = "ClientiFacturi_TD_V";

        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,
            dDataFactura,
            tSerieFactura,
            nNumarFactura,
            tObservatii,
            nMonedaFactura,
            nCursBNR,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tDenumireClient,
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiFacturi_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiFacturi_TD
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

        public static DataSet GetListByClientSiPerioada(int pIdClient, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdClient > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriteriiSiPerioada(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataFactura.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataFactura.ToString(), true, pTranzactie);
        }

        public static DataSet GetUltimeleFacturiPerClinica(List<int> pListaIdClienti, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiveById(NUME_VIEW, NUME_TABELA, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pListaIdClienti, pTranzactie);
        }

        public static DataSet GetUltimaFactura(int pIdClinica, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectLastActiva(NUME_VIEW, EnumCampuriTabela.dDataFactura.ToString(), EnumCampuriTabela.xnIdClient.ToString(), pIdClinica, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiFacturi_TD
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pDataFactura"></param>
        /// <param name="pSerieFactura"></param>
        /// <param name="pNumarFactura"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pMonedaFactura"></param>
        /// <param name="pCursBNR"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, DateTime pDataFactura, string pSerieFactura, int pNumarFactura, string pObservatii, int pMonedaFactura, double pCursBNR, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataFactura.ToString(), pDataFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.tSerieFactura.ToString(), pSerieFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarFactura.ToString(), pNumarFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nMonedaFactura.ToString(), pMonedaFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.nCursBNR.ToString(), pCursBNR);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiFacturi_TD
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
        /// Modificam informatiile unei inregistrari din tabela ClientiFacturi_TD
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
