using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CCL.DAL;
using CDL.iStomaLab;

namespace DAL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Tabela UtilizatoriVenituriDetalii_TD
    /// UtilizatoriVenituriDetalii_TD_V
    /// </summary>
    /// <remarks></remarks>
    public static class DUtilizatoriVenituriDetalii
    {

        #region Declaratii generale

        public const string NUME_TABELA = "UtilizatoriVenituriDetalii_TD";
        public const string NUME_VIEW = "UtilizatoriVenituriDetalii_TD_V";
        public enum EnumCampuriTabela
        {
            nId,
            dDataCreare,
            xnUtilizatorCreare,
            xnIdUtilizatoriVenituri,
            xnIdEtapa,
            nPret,
            dDataInceput,
            dDataFinal,
            xnIdUtilizator,
            tDenumire
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date UtilizatoriVenituriDetalii_TD_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        //public static DataSet GetByIdUtilizator(int pIdUtilizator, IDbTransaction pTranzactie)
        //{
        //    return DGeneral.SelectById(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pIdUtilizator, pTranzactie);
        //}

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela UtilizatoriVenituriDetalii_TD_V
        /// </summary>
        /// <param name="pIdUtilizatoriVenituri"></param>
        /// <remarks></remarks>
        public static DataSet GetListByParam(int pIdUtilizatoriVenituri, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizatoriVenituri.ToString(), pIdUtilizatoriVenituri);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
        }

        public static DataSet GetListByParamIdUtilizator(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            //return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, pTranzactie);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, CDefinitiiComune.EnumStare.Activa, pTranzactie);
        }


        public static DataSet GetListByParam(int pIdUtilizatorVenituri, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizatoriVenituri.ToString(), pIdUtilizatorVenituri);
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        public static DataSet GetListVenituriByPerioada(int pIdUtilizator, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            if (pIdUtilizator > 0)
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizator.ToString(), pIdUtilizator);
            return DGeneral.SelectByCriteriiSiPerioadaCuAltaDataISNULL(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.dDataCreare.ToString(), pDataInceput, pDataSfarsit, EnumCampuriTabela.dDataCreare.ToString(), pStare, pTranzactie);
        }


        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela UtilizatoriVenituriDetalii_TD
        /// </summary>
        /// <param name="pIdUtilizatoriVenituri"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pPret"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, int pIdUtilizatoriVenituri, int pIdEtapa, double pPret, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUtilizatoriVenituri.ToString(), pIdUtilizatoriVenituri);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdEtapa.ToString(), pIdEtapa);
            dictCorespondenta.Adauga(EnumCampuriTabela.nPret.ToString(), pPret);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Modificam informatiile unei inregistrari din tabela UtilizatoriVenituriDetalii_TD
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

        /// <summary>
        /// Stergem o inregistrare din tabela UtilizatoriVenituriDetalii_TD
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