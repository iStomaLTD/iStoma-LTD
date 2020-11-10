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
    /// Tabela Tari_REF
    /// </summary>
    /// <remarks></remarks>
    public static class DTari
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Tari_REF";
        public const string NUME_VIEW = "Tari_REF";
        public enum EnumCampuriTabela
        {
            nIdTara,
            tNumeScurt,
            tNumeOficial,
            tPrefixTelefonic,
            tAbreviere,
            tCetatenie,
            nLimbaDenumirii,
            nPreferinta,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetListaCautare(string pDenumire, int pIdLimba, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectListaCautareActivaCuTest(NUME_VIEW, EnumCampuriTabela.nIdTara.ToString(), EnumCampuriTabela.tNumeScurt.ToString(), pDenumire, EnumCampuriTabela.nLimbaDenumirii.ToString(), pIdLimba.ToString(), pTranzactie);
            //BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            //listaParametri.Add("@tDenumire", pDenumire);
            //DataSet ds = CCerereSQL.GetDataSetByStoredProc("Tari_REF_GetListaCautare", listaParametri, pTranzactie);
            //listaParametri = null;
            //return ds;
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nIdTara.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Tari_REF
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nIdTara.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Tari_REF
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, int pIdLimba, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pIdLimba);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tNumeScurt.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Tari_REF
        /// </summary>
        /// <param name="pNumeScurt"></param>
        /// <param name="pNumeOficial"></param>
        /// <param name="pPrefixTelefonic"></param>
        /// <param name="pAbreviere"></param>
        /// <param name="pCetatenie"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pNumeScurt, string pNumeOficial, string pPrefixTelefonic, string pAbreviere, string pCetatenie, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumeScurt.ToString(), pNumeScurt);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumeOficial.ToString(), pNumeOficial);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPrefixTelefonic.ToString(), pPrefixTelefonic);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAbreviere.ToString(), pAbreviere);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCetatenie.ToString(), pCetatenie);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pLimbaDenumirii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPreferinta.ToString(), pPreferinta);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Tari_REF
        /// </summary>
        /// <param name="pIdUtilizatorInchidere">Id-ul utilizatorului care a declansat actiunea</param>
        /// <param name="pInchidere">pInchidere = True: coloana « dDataInchidere » va avea valoarea db.Null, altfel va avea valoarea datei de pe serverul pe care e gazduita baza de date</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia sql utilizata</param>
        /// <remarks></remarks>
        public static void CloseById(int pIdUtilizatorInchidere, int pId, bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            DGeneral.CloseById(NUME_TABELA, pIdUtilizatorInchidere, pInchidere, pMotivInchidere, EnumCampuriTabela.nIdTara.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela Tari_REF
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nIdTara.ToString(), pId, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }

}