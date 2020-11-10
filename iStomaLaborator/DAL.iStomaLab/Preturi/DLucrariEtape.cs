using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Preturi
{
    public static class DLucrariEtape
    {


        #region Declaratii generale

        public const string NUME_TABELA = "LucrariEtape_TP";
        public const string NUME_VIEW = "LucrariEtape_TP_V";
        public enum EnumCampuriTabela
        {
            nId,
            xnIdLucrare,
            xnIdEtapa,
            nNumarOrdine,
            nDurataMedieMinute,
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
        /// Recuperam o inregistrare din baza de date LucrariEtape_TP_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        public static DataSet GetByIdLucrareEtapa(int pIdLucrare, int pIdEtapa, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEtapa.ToString(), pIdEtapa);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdLucrare.ToString(), true, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela LucrariEtape_TP
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdLucrare.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdLucrare(int pIdLucrare, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdLucrare.ToString(), false, pStare, pTranzactie);
        }

        public static DataSet GetListByParamIdLucrareEtapa(int pIdLucrare, int pIdEtapa, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEtapa.ToString(), pIdEtapa);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.xnIdLucrare.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela LucrariEtape_TP
        /// </summary>
        /// <param name="pIdLucrare"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pNumarOrdine"></param>
        /// <param name="pDurataMedieMinute"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdLucrare, int pIdEtapa, int pNumarOrdine, int pDurataMedieMinute, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLucrare.ToString(), pIdLucrare);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEtapa.ToString(), pIdEtapa);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarOrdine.ToString(), pNumarOrdine);
            dictCorespondenta.Adauga(EnumCampuriTabela.nDurataMedieMinute.ToString(), pDurataMedieMinute);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela LucrariEtape_TP
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
        /// Modificam informatiile unei inregistrari din tabela LucrariEtape_TP
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
