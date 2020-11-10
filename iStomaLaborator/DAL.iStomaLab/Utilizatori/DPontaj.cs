using CCL.DAL;
using CCL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Utilizatori
{
    public static class DPontaj
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Pontaj_TD";
        public const string NUME_VIEW = "Pontaj_TD";
        public enum EnumCampuriTabela
        {
            nId,
            dDataCreare,
            xnUtilizatorCreare,
            xnIdSediu,
            xnIdUtilizator,
            dDataPontaj,
            nTipPontaj,
            tObservatii
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date Pontaj_TD
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela Pontaj_TD
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetListByIdUtilizator(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriteriiSiPerioada(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.dDataPontaj.ToString(), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), DateTime.Now, pTranzactie);
        }

        public static DataSet GetListByIdUtilizatorTotal(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriterii(NUME_TABELA, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetListByIdUtilizatorTotalPePerioada(int pIdUtilizator, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Add(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriteriiSiPerioada(NUME_TABELA, dictCorespondenta, EnumCampuriTabela.dDataPontaj.ToString(), pDataInceput, pDataSfarsit, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Pontaj_TD
        /// </summary>
        /// <param name="pIdSediu"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pDataPontaj"></param>
        /// <param name="pTipPontaj"></param>
        /// <param name="pObservatii"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdSediu, int pIdUtilizator, DateTime pDataPontaj, int pTipPontaj, string pObservatii, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdSediu.ToString(), pIdSediu);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            dictCorespondenta.Adauga(EnumCampuriTabela.dDataPontaj.ToString(), pDataPontaj);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipPontaj.ToString(), pTipPontaj);
            dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela Pontaj_TD
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
