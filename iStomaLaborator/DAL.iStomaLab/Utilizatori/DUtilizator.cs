using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Utilizatori
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using CCL.DAL;

    namespace DAL.iStomaLab.Utilizatori
    {
        /// <summary>
        /// Tabela Utilizator_TD
        /// </summary>
        /// <remarks></remarks>
        public static class DUtilizator
        {

            #region Declaratii generale

            public const string NUME_TABELA = "Utilizator_TD";
            public const string NUME_VIEW = "Utilizator_TD";
            public enum EnumCampuriTabela
            {
                nId,
                tNume,
                tPrenume,
                tCNP,
                dDataNastere,
                nSex,
                nTitulatura,
                tNumeDeFata,
                tPorecla,
                nStareCivila,
                nNumarCopii,
                nEducatie,
                tScoala,
                xnIdNationalitate,
                xnIdTaraNastere,
                xnIdJudetNastere,
                xnIdLocalitateNastere,
                nRol,
                xnIdProfesie,
                tObservatii,
                tTelefonFix,
                tTelefonMobil,
                tFax,
                tContSkype,
                tContYM,
                tAdresaMail,
                tPaginaWeb,
                tInfoContact,
                xnIdImagineCurenta,
                tContStoma,
                tParolaStoma,
                nUltimaOptiuneAccesata,
                nCuloare,
                nTipActIdentitate,
                tSerieActIdentitate,
                tNumarActIdentitate,
                nNumarOrdine,
                nDurataMinuteDeconectare,
                nNumarZileCOAgreate,
                dDataAngajare,
                dDataCreare,
                xnUtilizatorCreare,
                dDataInchidere,
                xnUtilizatorInchidere,
                tMotivInchidere,
                nTipContract,
                dDataContract,
                dDataIncetareContract,
                nOreNorma,
                nNumarContract,
                tEmisDe,
                dValabilitateInceput,
                dValabilitateSfarsit,
                tIban,
                xnIdBanca,
                xnIdAdresa
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

            /// <summary>
            /// Recuperam o inregistrare din baza de date Utilizator_TD
            /// </summary>
            /// <param name="pId"></param>
            /// <remarks></remarks>
            public static DataSet GetById(int pId, IDbTransaction pTranzactie)
            {
                return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
            }

            /// <summary>
            /// Recuperam o lista de inregistrari din tabela Utilizator_TD
            /// </summary>
            /// <remarks></remarks>
            public static DataSet GetListByParam(CDL.iStomaLab.CDefinitiiComune.EnumStare pStare, int pRol, IDbTransaction pTranzactie)
            {
                BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
                if (pRol > 0)
                    dictCorespondenta.Adauga(EnumCampuriTabela.nRol.ToString(), pRol);

                return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.nNumarOrdine.ToString(), true, pStare, pTranzactie);
            }

            #endregion //SELECT

            #region INSERT

            public static int AdaugaUtilizator(int lIdUtilizator,
            string sNume,
            string sPrenume,
            string sPorecla,
            IDbTransaction trans)
            {
                if (string.IsNullOrEmpty(sNume))
                    sNume = "User";
                if (string.IsNullOrEmpty(sPrenume))
                    sPrenume = sNume;

                BColectieParametriSQL lstParametri = new BColectieParametriSQL();
                lstParametri.Add("@nIdUser", lIdUtilizator, true);
                lstParametri.Add("@tNume", sNume, true);
                lstParametri.Add("@tPrenume", sPrenume, true);
                lstParametri.Add("@tPorecla", sPorecla, true);

                int lIdUtilizatorCreat = Convert.ToInt32(CCerereSQL.GetScalarByStoredProc("Utilizator_TD_AdaugaUtilizator", lstParametri, trans));
                lstParametri = null;
                return lIdUtilizatorCreat;
            }

            /// <summary>
            /// Adaugam o noua inregistrare in tabela Utilizator_TD
            /// </summary>
            /// <param name="pNume"></param>
            /// <param name="pPrenume"></param>
            /// <param name="pCNP"></param>
            /// <param name="pDataNastere"></param>
            /// <param name="pSex"></param>
            /// <param name="pTitulatura"></param>
            /// <param name="pNumeDeFata"></param>
            /// <param name="pPorecla"></param>
            /// <param name="pStareCivila"></param>
            /// <param name="pNumarCopii"></param>
            /// <param name="pEducatie"></param>
            /// <param name="pScoala"></param>
            /// <param name="pIdNationalitate"></param>
            /// <param name="pIdTaraNastere"></param>
            /// <param name="pIdJudetNastere"></param>
            /// <param name="pIdLocalitateNastere"></param>
            /// <param name="pRol"></param>
            /// <param name="pIdProfesie"></param>
            /// <param name="pObservatii"></param>
            /// <param name="pTelefonFix"></param>
            /// <param name="pTelefonMobil"></param>
            /// <param name="pFax"></param>
            /// <param name="pContSkype"></param>
            /// <param name="pContYM"></param>
            /// <param name="pAdresaMail"></param>
            /// <param name="pPaginaWeb"></param>
            /// <param name="pInfoContact"></param>
            /// <param name="pIdImagineCurenta"></param>
            /// <param name="pContStoma"></param>
            /// <param name="pParolaStoma"></param>
            /// <param name="pCuloare"></param>
            /// <param name="pTipActIdentitate"></param>
            /// <param name="pSerieActIdentitate"></param>
            /// <param name="pNumarActIdentitate"></param>
            /// <param name="pNumarOrdine"></param>
            /// <param name="pNumarZileCOAgreate"></param>
            /// <param name="pDataAngajare"></param>
            /// <param name="pTipContract"></param>
            /// <param name="pDataContract"></param>
            /// <param name="pDataIncetareContract"></param>
            /// <param name="pOreNorma"></param>
            /// <param name="pNumarContract"></param>
            /// <param name="pEmisDe"></param>
            /// <param name="pValabilitateInceput"></param>
            /// <param name="pValabilitateSfarsit"></param>
            /// <param name="pIban"></param>
            /// <param name="pIdBanca"></param>
            /// <param name="pIdAdresa"></param>
            /// <returns>Cheia inregistrarii adaugate</returns>
            /// <remarks></remarks>
            public static int Add(int pIdCreator, string pNume, string pPrenume, string pCNP, DateTime pDataNastere, int pSex, int pTitulatura, string pNumeDeFata, string pPorecla, int pStareCivila, int pNumarCopii, int pEducatie, string pScoala, int pIdNationalitate, int pIdTaraNastere, int pIdJudetNastere, int pIdLocalitateNastere, int pRol, int pIdProfesie, string pObservatii, string pTelefonFix, string pTelefonMobil, string pFax, string pContSkype, string pContYM, string pAdresaMail, string pPaginaWeb, string pInfoContact, int pIdImagineCurenta, string pContStoma, string pParolaStoma, int pCuloare, int pTipActIdentitate, string pSerieActIdentitate, string pNumarActIdentitate, int pNumarOrdine, int pNumarZileCOAgreate, DateTime pDataAngajare, int pTipContract, DateTime pDataContract, DateTime pDataIncetareContract, int pOreNorma, int pNumarContract, string pEmisDe, DateTime pValabilitateInceput, DateTime pValabilitateSfarsit, string pIban, int pIdBanca, int pIdAdresa, IDbTransaction pTranzactie)
            {
                BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
                dictCorespondenta.Adauga(EnumCampuriTabela.tNume.ToString(), pNume);
                dictCorespondenta.Adauga(EnumCampuriTabela.tPrenume.ToString(), pPrenume);
                dictCorespondenta.Adauga(EnumCampuriTabela.tCNP.ToString(), pCNP);
                dictCorespondenta.Adauga(EnumCampuriTabela.dDataNastere.ToString(), pDataNastere);
                dictCorespondenta.Adauga(EnumCampuriTabela.nSex.ToString(), pSex);
                dictCorespondenta.Adauga(EnumCampuriTabela.nTitulatura.ToString(), pTitulatura);
                dictCorespondenta.Adauga(EnumCampuriTabela.tNumeDeFata.ToString(), pNumeDeFata);
                dictCorespondenta.Adauga(EnumCampuriTabela.tPorecla.ToString(), pPorecla);
                dictCorespondenta.Adauga(EnumCampuriTabela.nStareCivila.ToString(), pStareCivila);
                dictCorespondenta.Adauga(EnumCampuriTabela.nNumarCopii.ToString(), pNumarCopii);
                dictCorespondenta.Adauga(EnumCampuriTabela.nEducatie.ToString(), pEducatie);
                dictCorespondenta.Adauga(EnumCampuriTabela.tScoala.ToString(), pScoala);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdNationalitate.ToString(), pIdNationalitate);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdTaraNastere.ToString(), pIdTaraNastere);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdJudetNastere.ToString(), pIdJudetNastere);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocalitateNastere.ToString(), pIdLocalitateNastere);
                dictCorespondenta.Adauga(EnumCampuriTabela.nRol.ToString(), pRol);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdProfesie.ToString(), pIdProfesie);
                dictCorespondenta.Adauga(EnumCampuriTabela.tObservatii.ToString(), pObservatii);
                dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonFix.ToString(), pTelefonFix);
                dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonMobil.ToString(), pTelefonMobil);
                dictCorespondenta.Adauga(EnumCampuriTabela.tFax.ToString(), pFax);
                dictCorespondenta.Adauga(EnumCampuriTabela.tContSkype.ToString(), pContSkype);
                dictCorespondenta.Adauga(EnumCampuriTabela.tContYM.ToString(), pContYM);
                dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
                dictCorespondenta.Adauga(EnumCampuriTabela.tPaginaWeb.ToString(), pPaginaWeb);
                dictCorespondenta.Adauga(EnumCampuriTabela.tInfoContact.ToString(), pInfoContact);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdImagineCurenta.ToString(), pIdImagineCurenta);
                dictCorespondenta.Adauga(EnumCampuriTabela.tContStoma.ToString(), pContStoma);
                dictCorespondenta.Adauga(EnumCampuriTabela.tParolaStoma.ToString(), pParolaStoma);
                dictCorespondenta.Adauga(EnumCampuriTabela.nCuloare.ToString(), pCuloare, false);
                dictCorespondenta.Adauga(EnumCampuriTabela.nTipActIdentitate.ToString(), pTipActIdentitate);
                dictCorespondenta.Adauga(EnumCampuriTabela.tSerieActIdentitate.ToString(), pSerieActIdentitate);
                dictCorespondenta.Adauga(EnumCampuriTabela.tNumarActIdentitate.ToString(), pNumarActIdentitate);
                dictCorespondenta.Adauga(EnumCampuriTabela.nNumarOrdine.ToString(), pNumarOrdine);
                dictCorespondenta.Adauga(EnumCampuriTabela.nNumarZileCOAgreate.ToString(), pNumarZileCOAgreate);
                dictCorespondenta.Adauga(EnumCampuriTabela.dDataAngajare.ToString(), pDataAngajare);
                dictCorespondenta.Adauga(EnumCampuriTabela.nTipContract.ToString(), pTipContract);
                dictCorespondenta.Adauga(EnumCampuriTabela.dDataContract.ToString(), pDataContract);
                dictCorespondenta.Adauga(EnumCampuriTabela.dDataIncetareContract.ToString(), pDataIncetareContract);
                dictCorespondenta.Adauga(EnumCampuriTabela.nOreNorma.ToString(), pOreNorma);
                dictCorespondenta.Adauga(EnumCampuriTabela.nNumarContract.ToString(), pNumarContract);
                dictCorespondenta.Adauga(EnumCampuriTabela.tEmisDe.ToString(), pEmisDe);
                dictCorespondenta.Adauga(EnumCampuriTabela.dValabilitateInceput.ToString(), pValabilitateInceput);
                dictCorespondenta.Adauga(EnumCampuriTabela.dValabilitateSfarsit.ToString(), pValabilitateSfarsit);
                dictCorespondenta.Adauga(EnumCampuriTabela.tIban.ToString(), pIban);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdBanca.ToString(), pIdBanca);
                dictCorespondenta.Adauga(EnumCampuriTabela.xnIdAdresa.ToString(), pIdAdresa);
                return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
            }

            #endregion //INSERT

            #region UPDATE

            /// <summary>
            /// Inchidem (dezactivam) o inregistrare din tabela Utilizator_TD
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
            /// Modificam informatiile unei inregistrari din tabela Utilizator_TD
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
}
