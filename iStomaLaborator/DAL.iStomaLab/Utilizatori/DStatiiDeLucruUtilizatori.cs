using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;

namespace DAL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Tabela StatiiDeLucruUtilizatori_TD
    /// StatiiDeLucruUtilizatori_TD_V
    /// </summary>
    /// <remarks></remarks>
    public static class DStatiiDeLucruUtilizatori
    {

        #region Declaratii generale

        public const string NUME_TABELA = "StatiiDeLucruUtilizatori_TD";
        public const string NUME_VIEW = "StatiiDeLucruUtilizatori_TD_V";
        public enum EnumCampuriTabela
        {
            xnIdStatieDeLucru,
            xnIdUtilizator,
            bPastreazaConectat,
            bBlocheazaAccesul,
            dDataCreare,
            xnUtilizatorCreare,
            bStatieBlocata,
            tIdStatie,
            tNume,
            tContStoma,
            tParolaStoma
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.xnIdUtilizator.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date StatiiDeLucruUtilizatori_TD_V
        /// </summary>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pIdStatieDeLucru, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.xnIdStatieDeLucru.ToString(), pIdStatieDeLucru, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela StatiiDeLucruUtilizatori_TD_V
        /// </summary>
        /// <param name="pIdUtilizator"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetPreferinteUtilizatorConectat(int pIdStatie, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdStatieDeLucru.ToString(), pIdStatie);
            dictCorespondenta.Adauga(EnumCampuriTabela.bPastreazaConectat.ToString(), true);
            dictCorespondenta.Adauga(EnumCampuriTabela.bStatieBlocata.ToString(), false, false);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela StatiiDeLucruUtilizatori_TD
        /// </summary>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pPastreazaConectat"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdStatieDeLucru, int pIdUtilizator, bool pPastreazaConectat, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdStatieDeLucru.ToString(), pIdStatieDeLucru);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            dictCorespondenta.Adauga(EnumCampuriTabela.bPastreazaConectat.ToString(), pPastreazaConectat);
            dictCorespondenta.Adauga(EnumCampuriTabela.bBlocheazaAccesul.ToString(), false, false);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela StatiiDeLucruUtilizatori_TD
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pIdStatieDeLucru, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.xnIdStatieDeLucru.ToString(), pIdStatieDeLucru, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }
}