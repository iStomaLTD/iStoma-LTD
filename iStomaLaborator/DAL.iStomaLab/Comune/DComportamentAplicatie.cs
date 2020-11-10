using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Comune
{
    public static class DComportamentAplicatie
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ComportamentAplicatie_TP";
        public const string NUME_VIEW = "ComportamentAplicatie_TP";

        public enum EnumCampuriTabela
        {
            nId,
            tValoare
        }

        #endregion //Declaratii generale

        #region SELECT

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ComportamentAplicatie_TP
        /// </summary>
        /// <param name="pIdLista"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pId, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pId > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.nId.ToString(), pId);

            //Le sortam dupa numarul de ordine
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, CDefinitiiComune.EnumStare.Toate, pTranzactie);
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

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ComportamentAplicatie_TP
        /// </summary>
        /// <param name="pValoare"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdComportament, string pValoare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();

            dictCorespondenta.Adauga(EnumCampuriTabela.nId.ToString(), pIdComportament);
            dictCorespondenta.Adauga(EnumCampuriTabela.tValoare.ToString(), pValoare);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela ComportamentAplicatie_TP
        /// </summary>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static void UpdateComportament(int pIdComportament, string pValoare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictModificari = new BColectieCorespondenteColoaneValori();
            dictModificari.Adauga(EnumCampuriTabela.tValoare.ToString(), pValoare);

            DGeneral.UpdateAllById(NUME_TABELA, dictModificari, EnumCampuriTabela.nId.ToString(), pIdComportament, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        public static void DeleteByIdLista(int pIdLista, IDbTransaction pTranzactie)
        {
            DGeneral.DeleteById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pIdLista, pTranzactie);
        }

        #endregion //DELETE

    }
}
