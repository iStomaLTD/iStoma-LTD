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
    /// Tabela Regiuni_REF
    /// Regiuni_REF_V
    /// </summary>
    /// <remarks></remarks>
    public static class DRegiuni
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Regiuni_REF";
        public const string NUME_VIEW = "Regiuni_REF_V";
        public enum EnumCampuriTabela
        {
            nIdRegiune,
            xnIdTara,
            tNume,
            tAbreviere,
            tPrefixTelefon,
            nLimbaDenumirii,
            nPreferinta,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tNumeTara,
            nLimbaDenumiriiTara
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetListaCautare(int pIdTara, string pDenumire, int pIdLimba, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@xnIdTara", pIdTara);
            listaParametri.Add("@tDenumire", pDenumire);
            listaParametri.Add("@nIdLimba", pIdLimba);
            DataSet ds = CCerereSQL.GetDataSetByStoredProc("Regiuni_REF_GetListaCautare", listaParametri, pTranzactie);
            listaParametri = null;
            return ds;
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nIdRegiune.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Regiuni_REF_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nIdRegiune.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Regiuni_REF_V
        /// </summary>
        /// <param name="pIdTara"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdTara, CDefinitiiComune.EnumStare pStare, int pIdLimba, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTara.ToString(), pIdTara);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pIdLimba);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumiriiTara.ToString(), pIdLimba);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tNume.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Regiuni_REF
        /// </summary>
        /// <param name="pIdTara"></param>
        /// <param name="pNume"></param>
        /// <param name="pAbreviere"></param>
        /// <param name="pPrefixTelefon"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdTara, string pNume, string pAbreviere, string pPrefixTelefon, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            int idNou = DGeneral.GetValoareMaxima(NUME_TABELA, EnumCampuriTabela.nIdRegiune.ToString(), pTranzactie) + 1;

            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTara.ToString(), pIdTara);
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdRegiune.ToString(), idNou);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNume.ToString(), pNume);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAbreviere.ToString(), pAbreviere);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPrefixTelefon.ToString(), pPrefixTelefon);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pLimbaDenumirii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPreferinta.ToString(), pPreferinta);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Regiuni_REF
        /// </summary>
        /// <param name="pIdUtilizatorInchidere">Id-ul utilizatorului care a declansat actiunea</param>
        /// <param name="pInchidere">pInchidere = True: coloana « dDataInchidere » va avea valoarea db.Null, altfel va avea valoarea datei de pe serverul pe care e gazduita baza de date</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia sql utilizata</param>
        /// <remarks></remarks>
        public static void CloseById(int pIdUtilizatorInchidere, int pId, bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            DGeneral.CloseById(NUME_TABELA, pIdUtilizatorInchidere, pInchidere, pMotivInchidere, EnumCampuriTabela.nIdRegiune.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela Regiuni_REF
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nIdRegiune.ToString(), pId, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }

}