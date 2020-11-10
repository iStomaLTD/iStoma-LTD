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
    public static class DClientiPacienti
    {
        #region Declaratii generale

        public const string NUME_TABELA = "ClientiPacienti_TD";
        public const string NUME_VIEW = "ClientiPacienti_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdClient,
            tNumePacient,
            tPrenumePacient,            
            dDataNasterePacient,
            nVarsta,
            nSexPacient,           
            tObservatii,
            tTelefonMobil,
            tAdresaMail,
            nTitulatura,
            tContStoma,
            tParolaStoma,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere
        }

        #endregion //Declaratii generale

        #region SELECT
        public static DataSet GetUtilizatorISTOMA(IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByCriteriiWhereNull(NUME_VIEW, EnumCampuriTabela.xnUtilizatorCreare.ToString(), pTranzactie);
        }

        public static DataSet GetByUserSiPass(string pUser, string pParola, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.tContStoma.ToString(), pUser);
            dictCorespondenta.Add(EnumCampuriTabela.tParolaStoma.ToString(), pParola);

            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), false, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        public static DataSet GetListaCautare(int pIdClient, string pDenum,IDbTransaction pTranzactie)
        {
            return DGeneral.SelectListaCautare(NUME_VIEW, EnumCampuriTabela.nId.ToString(), EnumCampuriTabela.tNumePacient.ToString(),string.Empty , pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ClientiReprezentanti_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.xnIdClient.ToString(), pId, pTranzactie);
        }
       
        public static DataSet GetPacientById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ClientiReprezentanti_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.tNumePacient.ToString(), true, pStare, pTranzactie);
        }     

        public static DataSet GetListByParamIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.tNumePacient.ToString(), true, pStare, pTranzactie);
        }
        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela ClientiPacienti_TD
        /// </summary>
        /// <param name="pIdClient"></param>      
        /// <param name="pNume"></param>
        /// <param name="pPrenume"></param>
        /// <param name="pVarsta"></param>
        /// <param name="pDataNastere"></param>
        /// <param name="pSex"></param>     
        /// <param name="pTelefonMobil"></param>      
        /// <param name="pAdresaMail"></param>       
        /// <param name="pObservatii"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdClient, string pNume, string pPrenume, DateTime pDataNastere, int pVarsta, int pSex, string pTelefonMobil, string pAdresaMail, string pObservatii, IDbTransaction pTranzactie)
        {
            string A = pNume;
            string B = pPrenume;
            string denumpac = string.Concat(A," ",B);

            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdClient.ToString(), pIdClient);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumePacient.ToString(), denumpac);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPrenumePacient.ToString(), pPrenume);          
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataNasterePacient.ToString(), pDataNastere);
            dictCorespondenta.Adauga(EnumCampuriTabela.nVarsta.ToString(), pVarsta);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSexPacient.ToString(), pSex);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonMobil.ToString(), pTelefonMobil);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
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

