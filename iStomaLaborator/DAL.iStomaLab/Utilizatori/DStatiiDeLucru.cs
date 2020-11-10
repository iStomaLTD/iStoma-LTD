using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;

namespace DAL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Tabela StatiiDeLucru_TD
    /// </summary>
    /// <remarks></remarks>
    public static class DStatiiDeLucru
    {

        #region Declaratii generale

        public const string NUME_TABELA = "StatiiDeLucru_TD";
        public const string NUME_VIEW = "StatiiDeLucru_TD";
        public enum EnumCampuriTabela
        {
            nId,
            tIdStatie,
            tNume,
            bBlocheazaAccesul,
            dDataCreare,
            xnUtilizatorCreare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetStatiaCurenta(string pIdCalculator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.tIdStatie.ToString(), pIdCalculator);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date StatiiDeLucru_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela StatiiDeLucru_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela StatiiDeLucru_TD
        /// </summary>
        /// <param name="pIdStatie"></param>
        /// <param name="pNume"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pIdStatie, string pNume, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tIdStatie.ToString(), pIdStatie);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNume.ToString(), pNume);
            dictCorespondenta.Adauga(EnumCampuriTabela.bBlocheazaAccesul.ToString(), false, false);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela StatiiDeLucru_TD
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