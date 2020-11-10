using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Comune
{
    /// <summary>
    /// Tabela Adrese_TD
    /// Adrese_TD_V
    /// </summary>
    /// <remarks></remarks>
    public static class DAdrese
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Adrese_TD";
        public const string NUME_VIEW = "Adrese_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            nTipAdresa,
            tNumeStrada,
            tNumar,
            tBloc,
            tScara,
            tEtaj,
            tApartament,
            tCodInterfon,
            xnIdTara,
            xnIdRegiune,
            xnIdLocalitate,
            tCodPostal,
            dDataVerificare,
            tComentariu,
            nTipProprietar,
            xnIdProprietar,
            nLatitudine,
            nLongitudine
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Adrese_TD_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static DataSet GetByIdProprietar(int pIdProprietar, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.xnIdProprietar.ToString(), pIdProprietar, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Adrese_TD_V
        /// </summary>
        /// <param name="pTipAdresa"></param>
        /// <param name="pTipProprietar"></param>
        /// <param name="pIdProprietar"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pTipAdresa, int pTipProprietar, int pIdProprietar, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipAdresa.ToString(), pTipAdresa);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipProprietar.ToString(), pTipProprietar);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdProprietar.ToString(), pIdProprietar);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataCreare.ToString(), false, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Adrese_TD
        /// </summary>
        /// <param name="pTipAdresa"></param>
        /// <param name="pNumeStrada"></param>
        /// <param name="pNumar"></param>
        /// <param name="pBloc"></param>
        /// <param name="pScara"></param>
        /// <param name="pEtaj"></param>
        /// <param name="pApartament"></param>
        /// <param name="pCodInterfon"></param>
        /// <param name="pIdTara"></param>
        /// <param name="pIdRegiune"></param>
        /// <param name="pIdLocalitate"></param>
        /// <param name="pCodPostal"></param>
        /// <param name="pComentariu"></param>
        /// <param name="pTipProprietar"></param>
        /// <param name="pIdProprietar"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pTipAdresa, string pNumeStrada, string pNumar, string pBloc, string pScara, string pEtaj, string pApartament, string pCodInterfon, int pIdTara, int pIdRegiune, int pIdLocalitate, string pCodPostal, string pComentariu, int pTipProprietar, int pIdProprietar, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipAdresa.ToString(), pTipAdresa);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumeStrada.ToString(), pNumeStrada);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumar.ToString(), pNumar);
            dictCorespondenta.Adauga(EnumCampuriTabela.tBloc.ToString(), pBloc);
            dictCorespondenta.Adauga(EnumCampuriTabela.tScara.ToString(), pScara);
            dictCorespondenta.Adauga(EnumCampuriTabela.tEtaj.ToString(), pEtaj);
            dictCorespondenta.Adauga(EnumCampuriTabela.tApartament.ToString(), pApartament);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodInterfon.ToString(), pCodInterfon);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTara.ToString(), pIdTara);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdRegiune.ToString(), pIdRegiune);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocalitate.ToString(), pIdLocalitate);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodPostal.ToString(), pCodPostal);
            dictCorespondenta.Adauga(EnumCampuriTabela.tComentariu.ToString(), pComentariu);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipProprietar.ToString(), pTipProprietar);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdProprietar.ToString(), pIdProprietar);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Adrese_TD
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
        /// Modificam informatiile unei inregistrari din tabela Adrese_TD
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