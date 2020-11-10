using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Preturi
{
    /// <summary>
    /// Tabela ListaPreturiClienti_TD
    /// ListaPreturiClienti_TD_V
    /// </summary>
    /// <remarks></remarks>
    public static class DListaPreturiClienti
    {

        #region Declaratii generale

        public const string NUME_TABELA = "ListaPreturiClienti_TD";
        public const string NUME_VIEW = "ListaPreturiClienti_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdListaPreturi,
            xnIdClient,
            nValoareRON,
            nValoareEUR,
            nTermenAgreat,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tDenumire,
            xnIdCategorie,
            nValoareRONStandard,
            nValoareEURStandard,
            tDenumireClient,
            tDenumireCategorie
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ListaPreturiClienti_TD_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ListaPreturiClienti_TD_V
        /// </summary>
        /// <param name="pIdListaPreturi"></param>
        /// <param name="pIdClient"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdListaPreturi, int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdListaPreturi.ToString(), pIdListaPreturi);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParam(int pIdListaPreturi, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdListaPreturi.ToString(), pIdListaPreturi);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ListaPreturiClienti_TD
        /// </summary>
        /// <param name="pIdListaPreturi"></param>
        /// <param name="pIdClient"></param>
        /// <param name="pValoareRON"></param>
        /// <param name="pValoareEUR"></param>
        /// <param name="pTermenAgreat"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdListaPreturi, int pIdClient, double pValoareRON, double pValoareEUR, int pTermenAgreat, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdListaPreturi.ToString(), pIdListaPreturi);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareRON.ToString(), pValoareRON);
            dictCorespondenta.Adauga(EnumCampuriTabela.nValoareEUR.ToString(), pValoareEUR);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTermenAgreat.ToString(), pTermenAgreat);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ListaPreturiClienti_TD
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
        /// Modificam informatiile unei inregistrari din tabela ListaPreturiClienti_TD
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