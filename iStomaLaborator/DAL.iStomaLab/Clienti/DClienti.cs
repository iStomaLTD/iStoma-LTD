using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Clienti
{
    /// <summary>
    /// Tabela Clienti_TD
    /// </summary>
    /// <remarks></remarks>
    public static class DClienti
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Clienti_TD";
        public const string NUME_VIEW = "Clienti_TD";
        public const string NUME_VIEW_CAUTARE = "Clienti_V";
        public const string NUME_VIEW_SOLDURI = "SolduriClienti_V";

        public enum EnumCampuriViewSolduri
        {
            ID,
            nSold
        }
        public enum EnumCampuriViewCautare
        {
            nId,
            tDenumire
        }

        public enum EnumCampuriTabela
        {
            nId,
            tDenumire,
            nTipClient,
            tDenumireFiscala,
            tCUI,
            tRegCom,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            tTelefonMobil,
            tTelefonFix,
            tFax,
            tContSkype,
            tAdresaMail,
            tPaginaWeb,
            tObservatiiDateClinica,
            nTipRecomandant,
            xnIdRecomandant,
            tIban,
            xnIdBanca,
            tReprezentantLegal,
            nCalitateReprezentant,
            nNumarContract,
            dDataContract,
            tObservatiiDateFirma,
            xnIdAgentVanzari
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectListaCautare(NUME_VIEW_CAUTARE, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.tDenumire.ToString(), pDenumire, pTranzactie);
            //BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            //listaParametri.Add("@tDenumire", pDenumire);
            //DataSet ds = CCerereSQL.GetDataSetByStoredProc("Clienti_TD_GetListaCautare", listaParametri, pTranzactie);
            //listaParametri = null;
            //return ds; 
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Clienti_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Clienti_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListaDatornici(IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW_SOLDURI, dictCorespondenta, pTranzactie);
        }
        public static DataSet GetSold(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_VIEW_SOLDURI, EnumCampuriViewSolduri.ID.ToString(), pId, pTranzactie);
        }
     
        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Clienti_TD
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pTipClient"></param>
        /// <param name="pDenumireFiscala"></param>
        /// <param name="pCUI"></param>
        /// <param name="pRegCom"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pTelefonFix"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pPaginaWeb"></param>
        /// <param name="pObservatiiDateClinica"></param>
        /// <param name="pTipRecomandant"></param>
        /// <param name="pIdRecomandant"></param>
        /// <param name="pIBAN"></param>
        /// <param name="pIdBanca"></param>
        /// <param name="pReprezentantLegal"></param>
        /// <param name="pCalitateReprezentant"></param>
        /// <param name="pNumarContract"></param>
        /// <param name="pDataContract"></param>
        /// <param name="pObservatiiDateFirma"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pDenumire, int pTipClient, string pDenumireFiscala, string pCUI, string pRegCom, string pTelefonMobil, string pTelefonFix, string pFax, string pContSkype, string pAdresaMail, string pPaginaWeb, string pObservatiiDateClinica, int pTipRecomandant, int pIdRecomandant, string pIban, int pIdBanca, string pReprezentantLegal, int pCalitateReprezentant, int pNumarContract, DateTime pDataContract, string pObservatiiDateFirma, int xnIdAgentVanzari, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumire.ToString(), pDenumire);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipClient.ToString(), pTipClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumireFiscala.ToString(), pDenumireFiscala);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCUI.ToString(), pCUI);
            dictCorespondenta.Adauga(EnumCampuriTabela.tRegCom.ToString(), pRegCom);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonMobil.ToString(), pTelefonMobil);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonFix.ToString(), pTelefonFix);
            dictCorespondenta.Adauga(EnumCampuriTabela.tFax.ToString(), pFax);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContSkype.ToString(), pContSkype);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPaginaWeb.ToString(), pPaginaWeb);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatiiDateClinica.ToString(), pObservatiiDateClinica);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipRecomandant.ToString(), pTipRecomandant);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdRecomandant.ToString(), pIdRecomandant);
            dictCorespondenta.Adauga(EnumCampuriTabela.tIban.ToString(), pIban);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdBanca.ToString(), pIdBanca);
            dictCorespondenta.Adauga(EnumCampuriTabela.tReprezentantLegal.ToString(), pReprezentantLegal);
            dictCorespondenta.Adauga(EnumCampuriTabela.nCalitateReprezentant.ToString(), pCalitateReprezentant);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarContract.ToString(), pNumarContract);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataContract.ToString(), pDataContract);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatiiDateFirma.ToString(), pObservatiiDateFirma);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdAgentVanzari.ToString(), xnIdAgentVanzari);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Clienti_TD
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
        /// Modificam informatiile unei inregistrari din tabela Clienti_TD
        /// </summary>
        /// <param name="pIdUser">Utilizatorul care a declansat actiunea de modificare</param>
        /// <param name="pId"></param>
        /// <param name="pTranzactie">Tranzactia SQL utilizata</param>
        /// <remarks></remarks>
        public static bool UpdateById(BColectieCorespondenteColoaneValori pModificari, int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.UpdateAllById(NUME_TABELA, pModificari, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static DataSet GetListaClientiNoiPerioada(DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();

            return DGeneral.SelectByCriteriiSiPerioada(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataCreare.ToString(), pDataInceput, pDataSfarsit, pStare, pTranzactie);
        }
               

        #endregion //UPDATE

        #region DELETE

        #endregion //DELETE

    }

}