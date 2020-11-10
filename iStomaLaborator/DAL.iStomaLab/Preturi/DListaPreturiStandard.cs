using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Preturi
{
    /// <summary>
    /// Tabela ListaPreturiStandard_TP
    /// ListaPreturiStandard_TP_V
    /// </summary>
    /// <remarks></remarks>
    public static class DListaPreturiStandard
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ListaPreturiStandard_TP";
        public const string NUME_VIEW = "ListaPreturiStandard_TP_V";
        public enum EnumCampuriTabela
        {
            nId,
            tDenumire,
            tDenumirePrescurtata,
            tCodIntern,
            nTermenMediuZile,
            xnIdCategorie,
            nValoareRON,
            nValoareEUR,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tDenumireCategorie,
            nCuloare,
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        public static DataSet GetByListIdCategorii(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.xnIdCategorie.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ListaPreturiStandard_TP_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ListaPreturiStandard_TP_V
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdCategorie(int pIdCategorie, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdCategorie.ToString(), pIdCategorie);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@tDenumire", pDenumire);
            DataSet ds = CCerereSQL.GetDataSetByStoredProc("ListaPreturiStandard_TP_GetListaCautare", listaParametri, pTranzactie);
            listaParametri = null;
            return ds;
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ListaPreturiStandard_TP
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pDenumirePrescurtata"></param>
        /// <param name="pCodIntern"></param>
        /// <param name="pTermenMediuZile"></param>
        /// <param name="pIdCategorie"></param>
        /// <param name="pValoareRON"></param>
        /// <param name="pValoareEUR"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pDenumire, string pDenumirePrescurtata, string pCodIntern, int pTermenMediuZile, int pIdCategorie, double pValoareRON, double pValoareEUR, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumire.ToString(), pDenumire);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumirePrescurtata.ToString(), pDenumirePrescurtata);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodIntern.ToString(), pCodIntern);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTermenMediuZile.ToString(), pTermenMediuZile);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdCategorie.ToString(), pIdCategorie);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareRON.ToString(), pValoareRON);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareEUR.ToString(), pValoareEUR);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ListaPreturiStandard_TP
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
        /// Modificam informatiile unei inregistrari din tabela ListaPreturiStandard_TP
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