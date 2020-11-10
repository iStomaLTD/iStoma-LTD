using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Referinta
{
    /// <summary>
    /// Tabela ListeParametrabile_TP
    /// </summary>
    /// <remarks></remarks>
    public static class DListeParametrabile
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ListeParametrabile_TP";
        public const string NUME_VIEW = "ListeParametrabile_TP";
        public enum EnumCampuriTabela
        {
            nId,
            nTipLista,
            tDenumire,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetListaCautareRecomandanti(string pDenumire, IDbTransaction pTranzactie)
        {

            //BColectieCorespondenteColoaneValori listaParametri = new BColectieCorespondenteColoaneValori();
            //listaParametri.Add("tDenumire", pDenumire);
            //DataSet ds = DGeneral.SelectByCriterii("Recomandanti_V", listaParametri, pTranzactie);
            
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@tDenumire", pDenumire);
            DataSet ds = CCerereSQL.GetDataSetByStoredProc("Recomandanti_V_GetListaCautare", listaParametri, pTranzactie);
            listaParametri = null;

            return ds;
        }
        
        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ListeParametrabile_TP
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ListeParametrabile_TP
        /// </summary>
        /// <param name="pTipLista"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pTipLista, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipLista.ToString(), pTipLista);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ListeParametrabile_TP
        /// </summary>
        /// <param name="pTipLista"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pTipLista, string pDenumire, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipLista.ToString(), pTipLista);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumire.ToString(), pDenumire);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ListeParametrabile_TP
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
        /// Modificam informatiile unei inregistrari din tabela ListeParametrabile_TP
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