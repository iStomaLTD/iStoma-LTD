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
    public static class DEmailuri_Extrase
    {
        #region Declaratii generale

        public const string NUME_TABELA = "Emailuri_Extrase_TD";
        public const string NUME_VIEW = "Emailuri_Extrase_TD";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdEmail,
            nFlag,
            nNumarAtasamente,
            dDataServer,
            tSubiect,
            tExpeditor,
            tDestinatar,
            nIdUnic,
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
        /// Recuperam o inregistrare din baza de date Emailuri_Extrase_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Emailuri_Extrase_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdEmail(int pIdEmail, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.xnIdEmail.ToString(), pIdEmail);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdEmailDupaFlag(int pIdEmail, int pFlag, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.xnIdEmail.ToString(), pIdEmail);
            dictCorespondenta.Add(EnumCampuriTabela.nFlag.ToString(), pFlag);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nId.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Emailuri_Extrase_TD
        /// </summary>
        /// <param name="pIdEmail"></param>
        /// <param name="pFlag"></param>
        /// <param name="pNumarAtasamente"></param>
        /// <param name="pDataServer"></param>
        /// <param name="pSubiect"></param>
        /// <param name="pExpeditor"></param>
        /// <param name="pDestinatar"></param>
        /// <param name="pIdUnic"></param>
        /// <param name="pObservatii"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdEmail, int pFlag, int pNumarAtasamente, DateTime pDataServer, string pSubiect, string pExpeditor, string pDestinatar, int pIdUnic, string pObservatii, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEmail.ToString(), pIdEmail);
            dictCorespondenta.Adauga(EnumCampuriTabela.nFlag.ToString(), pFlag);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarAtasamente.ToString(), pNumarAtasamente);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataServer.ToString(), pDataServer);
            dictCorespondenta.Adauga(EnumCampuriTabela.tSubiect.ToString(), pSubiect);
            dictCorespondenta.Adauga(EnumCampuriTabela.tExpeditor.ToString(), pExpeditor);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDestinatar.ToString(), pDestinatar);
            dictCorespondenta.Adauga(EnumCampuriTabela.nIdUnic.ToString(), pIdUnic);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela Emailuri_Extrase_TD
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
        /// Modificam informatiile unei inregistrari din tabela Emailuri_Extrase_TD
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
