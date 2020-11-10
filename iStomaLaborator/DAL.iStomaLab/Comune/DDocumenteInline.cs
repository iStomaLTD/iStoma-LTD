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
    /// Tabela DocumenteInline_TD
    /// </summary>
    /// <remarks></remarks>
    public static class DDocumenteInline
    {

        #region Declaratii generale

        public const string NUME_TABELA = "DocumenteInline_TD";
        public const string NUME_VIEW = "DocumenteInline_TD";
        public enum EnumCampuriTabela
        {
            nId,
            nTipObiect,
            xnIdObiect,
            nTipImagine,
            nImagine,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tInformatiiComplementare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date DocumenteInline_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela DocumenteInline_TD
        /// </summary>
        /// <param name="pTipObiect"></param>
        /// <param name="pIdObiect"></param>
        /// <param name="pTipImagine"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect, int pTipImagine, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipObiect.ToString(), pTipObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdObiect.ToString(), pIdObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipImagine.ToString(), pTipImagine);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataCreare.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListaCVCompletMedicMobileAPP(CDefinitiiComune.EnumTipObiect pTipObiect, int pTipImagine,
        List<int> pListaIdMedici, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipObiect.ToString(), pTipObiect);
            //dictCorespondenta.Adauga(EnumCampuriTabela.xnIdObiect.ToString(), pIdObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipImagine.ToString(), pTipImagine);

            return DGeneral.SelectByListaIdSiCriterii(NUME_VIEW, EnumCampuriTabela.xnIdObiect.ToString(), pListaIdMedici, dictCorespondenta, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        public static DataSet GetImaginiProfilMediciMobileAPP(CDefinitiiComune.EnumTipObiect pTipObiect, int pTipImagine,
        List<int> pListaIdMedici, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipObiect.ToString(), pTipObiect);
            //dictCorespondenta.Adauga(EnumCampuriTabela.xnIdObiect.ToString(), pIdObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipImagine.ToString(), pTipImagine);

            return DGeneral.SelectByListaIdSiCriterii(NUME_VIEW, EnumCampuriTabela.xnIdObiect.ToString(), pListaIdMedici, dictCorespondenta, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela DocumenteInline_TD
        /// </summary>
        /// <param name="pTipObiect"></param>
        /// <param name="pIdObiect"></param>
        /// <param name="pTipImagine"></param>
        /// <param name="pImagine"></param>
        /// <param name="pInformatiiComplementare"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect, int pTipImagine, byte[] pImagine, string pInformatiiComplementare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipObiect.ToString(), pTipObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdObiect.ToString(), pIdObiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipImagine.ToString(), pTipImagine);
            if (pImagine != null)
                dictCorespondenta.Adauga(EnumCampuriTabela.nImagine.ToString(), pImagine);

            dictCorespondenta.Adauga(EnumCampuriTabela.tInformatiiComplementare.ToString(), pInformatiiComplementare);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela DocumenteInline_TD
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
        /// Modificam informatiile unei inregistrari din tabela DocumenteInline_TD
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static bool UpdateImagine(byte[] pImagine, int pIdElement, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori listaParam = new BColectieCorespondenteColoaneValori();
            listaParam.Add(EnumCampuriTabela.nImagine.ToString(), pImagine);

            return DGeneral.UpdateAllById(NUME_VIEW, listaParam, EnumCampuriTabela.nId.ToString(), pIdElement, pTranzactie);
        }

        #endregion //UPDATE

        #region DELETE

        /// <summary>
        /// Stergem o inregistrare din tabela DocumenteInline_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static void DeleteById(int pId, IDbTransaction pTranzactie)
        {
            DGeneral.DeleteById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        #endregion //DELETE

    }
}
