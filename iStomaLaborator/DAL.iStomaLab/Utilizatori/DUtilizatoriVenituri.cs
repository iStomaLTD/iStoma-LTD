using CCL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Tabela UtilizatoriVenituri_TD
    /// UtilizatoriVenituri_TD_V
    /// </summary>
    /// <remarks></remarks>
    public static class DUtilizatoriVenituri
    {

        #region Declaratii generale

        public const string NUME_TABELA = "UtilizatoriVenituri_TD";
        public const string NUME_VIEW = "UtilizatoriVenituri_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            dDataCreare,
            xnUtilizatorCreare,
            xnIdUtilizator,
            dDataInceput,
            dDataFinal,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tObservatii,
            nTipVenit,
            nSalariuFix,
            tNume,
            tPrenume,
            tContStoma,
            nNumarOrdine
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }


        public static DataSet GetByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectActiveByListaId(NUME_VIEW, EnumCampuriTabela.xnIdUtilizator.ToString(), pListaId, pTranzactie);
        }


        /// <summary>
        /// Recuperam o inregistrare din baza de date UtilizatoriVenituri_TD_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela UtilizatoriVenituri_TD_V
        /// </summary>
        /// <param name="pIdUtilizator"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdUtilizator, CDL.iStomaLab.CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdUtilizator.ToString(), true, pStare, pTranzactie);
            //return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela UtilizatoriVenituri_TD
        /// </summary>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pDataInceput"></param>
        /// <param name="pDataFinal"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pTipVenit"></param>
        /// <param name="pSalariuFix"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdUtilizator, DateTime pDataInceput, DateTime pDataFinal, string pObservatii, int pTipVenit, double pSalariuFix, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataInceput.ToString(), pDataInceput);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataFinal.ToString(), pDataFinal);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipVenit.ToString(), pTipVenit);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSalariuFix.ToString(), pSalariuFix);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela UtilizatoriVenituri_TD
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
        /// Modificam informatiile unei inregistrari din tabela UtilizatoriVenituri_TD
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
