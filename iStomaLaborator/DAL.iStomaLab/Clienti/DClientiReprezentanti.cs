using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Clienti
{
    public static class DClientiReprezentanti
    {
        #region Declaratii generale

        public const string NUME_TABELA = "ClientiReprezentanti_TD";
        public const string NUME_VIEW = "ClientiReprezentanti_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,
            tCNP,
            tNume,
            tPrenume,
            dDataNastere,
            nSex,
            nTitulatura,
            tNumeDeFata,
            tPorecla,
            tTelefonMobil,
            tTelefonFix,
            tFax,
            tContSkype,
            tContYM,
            tAdresaMail,
            nRol,
            nStareCivila,
            nNumarCopii,
            tScoala,
            xnIdNationalitate,
            xnIdTaraNastere,
            xnIdJudetNastere,
            xnIdLocalitateNastere,
            xnIdProfesie,
            tObservatii,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiReprezentanti_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.xnIdClient.ToString(), pId, pTranzactie);
        }

        public static DataSet GetReprezentantById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiReprezentanti_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tNume.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiReprezentanti_TD
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pCNP"></param>
        /// <param name="pNume"></param>
        /// <param name="pPrenume"></param>
        /// <param name="pDataNastere"></param>
        /// <param name="pSex"></param>
        /// <param name="pTitulatura"></param>
        /// <param name="pNumeDeFata"></param>
        /// <param name="pPorecla"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pTelefonFix"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pContYM"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pRol"></param>
        /// <param name="pStareCivila"></param>
        /// <param name="pNumarCopii"></param>
        /// <param name="pScoala"></param>
        /// <param name="pIdNationalitate"></param>
        /// <param name="pIdTaraNastere"></param>
        /// <param name="pIdJudetNastere"></param>
        /// <param name="pIdLocalitateNastere"></param>
        /// <param name="pIdProfesie"></param>
        /// <param name="pObservatii"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, string pCNP, string pNume, string pPrenume, DateTime pDataNastere, int pSex, int pTitulatura, string pNumeDeFata, string pPorecla, string pTelefonMobil, string pTelefonFix, string pFax, string pContSkype, string pContYM, string pAdresaMail, int pRol, int pStareCivila, int pNumarCopii, string pScoala, int pIdNationalitate, int pIdTaraNastere, int pIdJudetNastere, int pIdLocalitateNastere, int pIdProfesie, string pObservatii, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCNP.ToString(), pCNP);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNume.ToString(), pNume);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPrenume.ToString(), pPrenume);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataNastere.ToString(), pDataNastere);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSex.ToString(), pSex);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTitulatura.ToString(), pTitulatura);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumeDeFata.ToString(), pNumeDeFata);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPorecla.ToString(), pPorecla);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonMobil.ToString(), pTelefonMobil);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonFix.ToString(), pTelefonFix);
            dictCorespondenta.Adauga(EnumCampuriTabela.tFax.ToString(), pFax);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContSkype.ToString(), pContSkype);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContYM.ToString(), pContYM);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
            dictCorespondenta.Adauga(EnumCampuriTabela.nRol.ToString(), pRol);
            dictCorespondenta.Adauga(EnumCampuriTabela.nStareCivila.ToString(), pStareCivila);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarCopii.ToString(), pNumarCopii);
            dictCorespondenta.Adauga(EnumCampuriTabela.tScoala.ToString(), pScoala);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdNationalitate.ToString(), pIdNationalitate);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTaraNastere.ToString(), pIdTaraNastere);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdJudetNastere.ToString(), pIdJudetNastere);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocalitateNastere.ToString(), pIdLocalitateNastere);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdProfesie.ToString(), pIdProfesie);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ClientiReprezentanti_TD
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
        /// Modificam informatiile unei inregistrari din tabela ClientiReprezentanti_TD
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

