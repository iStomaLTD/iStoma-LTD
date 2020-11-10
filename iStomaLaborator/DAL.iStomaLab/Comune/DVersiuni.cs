using CCL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Comune
{
    public static class DVersiuni
    {
        #region Declaratii generale

        public const string NUME_TABELA = "VersiuniBDD_TD";

        public enum EnumCampuriTabela
        {
            tVersiune,
            dDataCreare
        }

        #endregion //Declaratii generale

        #region SELECT

        /// <summary>
        /// Recuperam lista de versiuni instalate de-a lungul timpului
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetUltimaVersiuneBDD(IDbTransaction pTranzactie)
        {
            return CCerereSQL.GetDataSetByComandaDirecta("SELECT TOP 1 tVersiune FROM VersiuniBDD_TD ORDER BY dDataCreare DESC", null, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua versiune de BDD
        /// </summary>
        /// <param name="pVersiune">Versiunea</param>
        /// <remarks></remarks>
        public static void Add(string pVersiune, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tVersiune.ToString(), pVersiune);
            DGeneral.Insert(NUME_TABELA, dictCorespondenta, -1, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }
}
