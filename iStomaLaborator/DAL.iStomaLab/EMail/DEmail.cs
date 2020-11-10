using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.EMail
{
    public static class DEmail
    {
        #region Declaratii generale

        public const string NUME_TABELA = "Email_TP";
        public const string NUME_VIEW = "Email_TP";
        public enum EnumCampuriTabela
        {
            nId,
            dDataCreare,
            xnUtilizatorCreare,
            tAdresaMail,
            tParolaMail,
            tHostSMTP,
            nPortSMTP,
            tHostIMAP,
            nPortIMAP,
            nTimeOut,
            bSSL,
            tUser,
            xnIdLocatieCurenta,
            tIdCalculator,
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
        /// Recuperam o inregistrare din baza de date Email_TP
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Email_TP
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tAdresaMail.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Email_TP
        /// </summary>
        /// <param name="pAdresaMail"></param>
        /// <param name="pParolaMail"></param>
        /// <param name="pHostSMTP"></param>
        /// <param name="pPortSMTP"></param>
        /// <param name="pHostIMAP"></param>
        /// <param name="pPortIMAP"></param>
        /// <param name="pTimeOut"></param>
        /// <param name="pSSL"></param>
        /// <param name="pUser"></param>
        /// <param name="pIdLocatieCurenta"></param>
        /// <param name="pIdCalculator"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pAdresaMail, string pParolaMail, string pHostSMTP, int pPortSMTP, string pHostIMAP, int pPortIMAP, int pTimeOut, bool pSSL, string pUser, int pIdLocatieCurenta, string pIdCalculator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
            dictCorespondenta.Adauga(EnumCampuriTabela.tParolaMail.ToString(), pParolaMail);
            dictCorespondenta.Adauga(EnumCampuriTabela.tHostSMTP.ToString(), pHostSMTP);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPortSMTP.ToString(), pPortSMTP);
            dictCorespondenta.Adauga(EnumCampuriTabela.tHostIMAP.ToString(), pHostIMAP);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPortIMAP.ToString(), pPortIMAP);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTimeOut.ToString(), pTimeOut);
            dictCorespondenta.Adauga(EnumCampuriTabela.bSSL.ToString(), pSSL);
            dictCorespondenta.Adauga(EnumCampuriTabela.tUser.ToString(), pUser);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocatieCurenta.ToString(), pIdLocatieCurenta);
            dictCorespondenta.Adauga(EnumCampuriTabela.tIdCalculator.ToString(), pIdCalculator);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Email_TP
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
        /// Modificam informatiile unei inregistrari din tabela Email_TP
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
