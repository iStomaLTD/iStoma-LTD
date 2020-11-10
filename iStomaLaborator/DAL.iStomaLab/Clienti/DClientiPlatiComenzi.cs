using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.iStomaLab.Clienti
{
    public static class DClientiPlatiComenzi
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ClientiPlatiComenzi_TD";
        public const string NUME_VIEW = "ClientiPlatiComenzi_TD";

        public enum EnumCampuriTabela
        {
            nId,
            xnIdClientComanda,
            xnIdClientPlata,
            nValoare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByIdFactura(int pIdFactura, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@xnIdFactura", pIdFactura);

            return CCerereSQL.GetDataSetByStoredProc("ClientiPlatiComenzi_TD_GetListaPlatiteByIdFactura", listaParametri, pTranzactie);
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        public static DataSet GetByListIdComenzi(List<int> pListaIdComenzi, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.xnIdClientComanda.ToString(), pListaIdComenzi, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiPlatiComenzi_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static DataSet GetByIdPlata(int pIdPlata, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.xnIdClientPlata.ToString(), pIdPlata, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiPlatiComenzi_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdClientComanda.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiPlatiComenzi_TD
        /// </summary>
        /// <param name="pIdClientComanda"></param>
        /// <param name="pIdClientPlata"></param>
        /// <param name="pValoare"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdClientComanda, int pIdClientPlata, double pValoare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClientComanda.ToString(), pIdClientComanda);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClientPlata.ToString(), pIdClientPlata);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoare.ToString(), pValoare);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, -1, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiPlatiComenzi_TD
        /// </summary>
        /// <param name="pIdUtilizatorInchidere">Id-ul utilizatorului care a declansat actiunea</param>
        /// <param name="pInchidere">pInchidere = True: coloana « dDataInchidere » va avea valoarea db.Null, altfel va avea valoarea datei de pe serverul pe care e gazduita baza de date</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia sql utilizata</param>
        /// <remarks></remarks>
        public static void CloseById(int pIdUtilizatorInchidere, int pId, bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            DGeneral.CloseById(NUME_TABELA, pIdUtilizatorInchidere, pInchidere, pMotivInchidere, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela ClientiPlatiComenzi_TD
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

        public static void DeleteByIdPlata(int pId, IDbTransaction pTranzactie)
        {
            DGeneral.DeleteById(NUME_TABELA, EnumCampuriTabela.xnIdClientPlata.ToString(), pId, pTranzactie);
        }

        #endregion //DELETE

    }
}
