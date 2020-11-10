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
    /// Tabela Localitati_REF
    /// Localitati_REF_V
    /// </summary>
    /// <remarks></remarks>
    public static class DLocalitati
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Localitati_REF";
        public const string NUME_VIEW = "Localitati_REF_V";
        public enum EnumCampuriTabela
        {
            nIdLocalitate,
            xnIdRegiune,
            tNume,
            nTip,
            nLimbaDenumirii,
            nPreferinta,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            xnIdTara,
            tNumeRegiune,
            tNumeTara,
            nLimbaDenumiriiTara
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetListaCautare(int pIdRegiune, string pDenumire, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@xnIdRegiune", pIdRegiune);
            listaParametri.Add("@tDenumire", pDenumire);
            DataSet ds = CCerereSQL.GetDataSetByStoredProc("Localitati_REF_GetListaCautare", listaParametri, pTranzactie);
            listaParametri = null;
            return ds;
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nIdLocalitate.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Localitati_REF_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nIdLocalitate.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Localitati_REF_V
        /// </summary>
        /// <param name="pIdRegiune"></param>
        /// <param name="pIdTara"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdRegiune, int pIdTara, CDefinitiiComune.EnumStare pStare, int pIdLimba, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();

            if (pIdRegiune > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdRegiune.ToString(), pIdRegiune);

            if (pIdTara > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTara.ToString(), pIdTara);

            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pIdLimba);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumiriiTara.ToString(), pIdLimba);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tNume.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Localitati_REF
        /// </summary>
        /// <param name="pIdRegiune"></param>
        /// <param name="pNume"></param>
        /// <param name="pTip"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdRegiune, string pNume, int pTip, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            //Recuperam numarul ultimei inregistrari si adaugam 1
            int idNou = DGeneral.GetValoareMaxima(NUME_TABELA, EnumCampuriTabela.nIdLocalitate.ToString(), pTranzactie) + 1;

            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdLocalitate.ToString(), idNou);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdRegiune.ToString(), pIdRegiune);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNume.ToString(), pNume);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTip.ToString(), pTip);
            dictCorespondenta.Adauga(EnumCampuriTabela.nLimbaDenumirii.ToString(), pLimbaDenumirii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPreferinta.ToString(), pPreferinta);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }
       
        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Localitati_REF
        /// </summary>
        /// <param name="pIdUtilizatorInchidere">Id-ul utilizatorului care a declansat actiunea</param>
        /// <param name="pInchidere">pInchidere = True: coloana « dDataInchidere » va avea valoarea db.Null, altfel va avea valoarea datei de pe serverul pe care e gazduita baza de date</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia sql utilizata</param>
        /// <remarks></remarks>
        public static void CloseById(int pIdUtilizatorInchidere, int pId, bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            DGeneral.CloseById(NUME_TABELA, pIdUtilizatorInchidere, pInchidere, pMotivInchidere, EnumCampuriTabela.nIdLocalitate.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela Localitati_REF
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nIdLocalitate.ToString(), pId, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }

}