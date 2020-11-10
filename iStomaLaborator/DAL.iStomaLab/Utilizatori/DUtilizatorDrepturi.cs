
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;

namespace DAL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Tabela UtilizatorDrepturi_TP
    /// </summary>
    /// <remarks></remarks>
    public static class DUtilizatorDrepturi
    {

        #region Declaratii generale

        public const string NUME_TABELA = "UtilizatorDrepturi_TP";
        public const string NUME_VIEW = "UtilizatorDrepturi_TP";
        public enum EnumCampuriTabela
        {
            nIdRubrica,
            nIdOptiune,
            xnIdUtilizator,
            dDataCreare,
            xnUtilizatorCreare
        }

        #endregion //Declaratii generale

        #region SELECT

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela UtilizatorDrepturi_TP
        /// </summary>
        /// <param name="pIdRubrica"></param>
        /// <param name="pIdOptiune"></param>
        /// <param name="pIdUtilizator"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdRubrica, int pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdRubrica > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.nIdRubrica.ToString(), pIdRubrica);
            if (pIdOptiune > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.nIdOptiune.ToString(), pIdOptiune);
            if (pIdUtilizator > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela UtilizatorDrepturi_TP
        /// </summary>
        /// <param name="pIdRubrica"></param>
        /// <param name="pIdOptiune"></param>
        /// <param name="pIdUtilizator"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdRubrica, int pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdRubrica.ToString(), pIdRubrica);
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdOptiune.ToString(), pIdOptiune);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela UtilizatorDrepturi_TP
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pIdRubrica"></param>
        /// <param name="pIdOptiune"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pIdRubrica, int pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nIdRubrica.ToString(), pIdRubrica, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE
        public static bool Delete(int pIdRubrica, int pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdRubrica.ToString(), pIdRubrica);
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdOptiune.ToString(), pIdOptiune);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);

            return DGeneral.DeleteByIds(NUME_TABELA, dictCorespondenta, pTranzactie);
        }


        #endregion //DELETE

    }

}

