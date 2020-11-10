using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Comune
{
    /// <summary>
    /// Tabela ColoaneListeAfisaj_TP
    /// </summary>
    /// <remarks></remarks>
    public static class DColoaneListeAfisaj
    {
        #region Declaratii generale

        public const string NUME_TABELA = "ColoaneListeAfisaj_TP";
        public const string NUME_VIEW = "ColoaneListeAfisaj_TP";
        public enum EnumCampuriTabela
        {
            xnIdLista,
            tColoana,
            nOrdine,
            bVizibila,
            nLatime
        }

        #endregion //Declaratii generale

        #region SELECT

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ColoaneListeAfisaj_TP
        /// </summary>
        /// <param name="pIdLista"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdLista, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLista.ToString(), pIdLista);

            //Le sortam dupa numarul de ordine
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.nOrdine.ToString(), true, CDefinitiiComune.EnumStare.Toate, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ColoaneListeAfisaj_TP
        /// </summary>
        /// <param name="pIdLista"></param>
        /// <param name="pColoana"></param>
        /// <param name="pOrdine"></param>
        /// <param name="pVizibila"></param>
        /// <param name="pLatime"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static void Add(int pIdLista, string pColoana, int pOrdine, bool pVizibila, int pLatime, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();

            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLista.ToString(), pIdLista);
            dictCorespondenta.Adauga(EnumCampuriTabela.tColoana.ToString(), pColoana);
            if (pOrdine < 0)
                dictCorespondenta.AdaugaNull(EnumCampuriTabela.nOrdine.ToString());
            else
                dictCorespondenta.Adauga(EnumCampuriTabela.nOrdine.ToString(), pOrdine, false);
            dictCorespondenta.Adauga(EnumCampuriTabela.bVizibila.ToString(), pVizibila);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLatime.ToString(), pLatime);

            DGeneral.Insert(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela ColoaneListeAfisaj_TP
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pIdLista"></param>
        /// <param name="pColoana"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pIdLista, string pColoana, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLista.ToString(), pIdLista);
            dictCorespondenta.Adauga(EnumCampuriTabela.tColoana.ToString(), pColoana);

            return DGeneral.UpdateAllByIds(-1, NUME_TABELA, pModificari, dictCorespondenta, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        public static void DeleteByIdLista(int pIdLista, IDbTransaction pTranzactie)
        {
            DGeneral.DeleteById(NUME_TABELA, EnumCampuriTabela.xnIdLista.ToString(), pIdLista, pTranzactie);
        }

        #endregion //DELETE

    }
}
