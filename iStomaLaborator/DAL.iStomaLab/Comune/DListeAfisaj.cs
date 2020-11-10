using CCL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Comune
{
    /// <summary>
    /// Tabela ListeAfisaj_TP
    /// </summary>
    /// <remarks></remarks>
    public static class DListeAfisaj
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ListeAfisaj_TP";
        public const string NUME_VIEW = "ListeAfisaj_TP";
        public enum EnumCampuriTabela
        {
            nId,
            tDenumireLista,
            tColoanaSortare,
            nOrdineSortare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ListeAfisaj_TP
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ListeAfisaj_TP
        /// </summary>
        /// <param name="pIdUtilizator"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ListeAfisaj_TP
        /// </summary>
        /// <param name="pDenumireLista"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pColoanaSortare"></param>
        /// <param name="pOrdineSortare"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(string pDenumireLista, string pColoanaSortare, int pOrdineSortare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumireLista.ToString(), pDenumireLista);
            dictCorespondenta.Adauga(EnumCampuriTabela.tColoanaSortare.ToString(), pColoanaSortare);
            dictCorespondenta.Adauga(EnumCampuriTabela.nOrdineSortare.ToString(), pOrdineSortare);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela ListeAfisaj_TP
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

        /// <summary>
        /// Stergem o inregistrare din tabela ListeAfisaj_TP
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static void DeleteById(int pId, IDbTransaction pTranzactie)
        {
            DGeneral.DeleteById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        #endregion //DELETE

    }
}
