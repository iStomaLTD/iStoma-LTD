using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iStomaLab.Locatii
{
    public static class DLocatii
    {

        #region Declaratii generale

        public const string NUME_TABELA = "Locatii_TD";
        public const string NUME_VIEW = "Locatii_TD";
        public enum EnumCampuriTabela
        {
            nId,
            tDenumire,
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            nTipLocatie,
            xnIdLocatieRadacina,
            xnIdGrup,
            xnIdSediu,
            xnIdSectie,
            xnIdUnitateFunctionala,
            tTelefonMobil,
            tFax,
            tContSkype,
            tContYM,
            tAdresaMail,
            tPaginaWeb,
            tInfoContact,
            tLogo,
            xnIdLocatieDetaliiFiscale,
            tDenumireFiscala,
            nTipFiscalitate,
            tCodFiscal,
            tNumarInregistrare,
            tContIBAN,
            tDenumireBanca,
            tReprezentantLegal,
            tCalitateReprezentantLegal,
            tSerieChitante,
            nNumarUltimaChitanta,
            tSerieFacturi,
            nNumarUltimaFactura,
            bPlatitorDeTVA,
            tInitialaLocatie,
            nSubTipLocatie,
            nCuloare
        }

        #endregion //Declaratii generale

        #region SELECT

        public static DataSet GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectByListaId(NUME_VIEW, EnumCampuriTabela.nId.ToString(), pListaId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o inregistrare din baza de date ListaPreturiStandard_TP_V
        /// </summary>
        /// <param name="pId"></param>
        /// <remarks></remarks>
        public static DataSet GetById(int pId, IDbTransaction pTranzactie)
        {
            return DGeneral.SelectById(NUME_TABELA, EnumCampuriTabela.nId.ToString(), pId, pTranzactie);
        }

        /// <summary>
        /// Recuperam o lista de inregistrari din tabela ListaPreturiStandard_TP_V
        /// </summary>
        /// <remarks></remarks>
        public static DataSet GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            return DGeneral.SelectByCriterii(NUME_VIEW, dictCorespondenta, EnumCampuriTabela.tDenumire.ToString(), true, pStare, pTranzactie);
        }

        #endregion //SELECT

        #region INSERT

        /// <summary>
        /// Adaugam o noua inregistrare in tabela Locatii_TD
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pTipLocatie"></param>
        /// <param name="pIdLocatieRadacina"></param>
        /// <param name="pIdGrup"></param>
        /// <param name="pIdSediu"></param>
        /// <param name="pIdSectie"></param>
        /// <param name="pIdUnitateFunctionala"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pContYM"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pPaginaWeb"></param>
        /// <param name="pInfoContact"></param>
        /// <param name="pLogo"></param>
        /// <param name="pIdLocatieDetaliiFiscale"></param>
        /// <param name="pDenumireFiscala"></param>
        /// <param name="pTipFiscalitate"></param>
        /// <param name="pCodFiscal"></param>
        /// <param name="pNumarInregistrare"></param>
        /// <param name="pContIBAN"></param>
        /// <param name="pDenumireBanca"></param>
        /// <param name="pReprezentantLegal"></param>
        /// <param name="pCalitateReprezentantLegal"></param>
        /// <param name="pSerieChitante"></param>
        /// <param name="pNumarUltimaChitanta"></param>
        /// <param name="pSerieFacturi"></param>
        /// <param name="pNumarUltimaFactura"></param>
        /// <param name="pPlatitorDeTVA"></param>
        /// <param name="pInitialaLocatie"></param>
        /// <param name="pSubTipLocatie"></param>
        /// <param name="pCuloare"></param>
        /// <returns>Cheia inregistrarii adaugate</returns>
        /// <remarks></remarks>
        public static int Add(int pIdCreator, string pDenumire, int pTipLocatie, int pIdLocatieRadacina, int pIdGrup, int pIdSediu, int pIdSectie, int pIdUnitateFunctionala, string pTelefonMobil, string pFax, string pContSkype, string pContYM, string pAdresaMail, string pPaginaWeb, string pInfoContact, string pLogo, int pIdLocatieDetaliiFiscale, string pDenumireFiscala, int pTipFiscalitate, string pCodFiscal, string pNumarInregistrare, string pContIBAN, string pDenumireBanca, string pReprezentantLegal, string pCalitateReprezentantLegal, string pSerieChitante, int pNumarUltimaChitanta, string pSerieFacturi, int pNumarUltimaFactura, bool pPlatitorDeTVA, string pInitialaLocatie, int pSubTipLocatie, int pCuloare, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumire.ToString(), pDenumire);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipLocatie.ToString(), pTipLocatie);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocatieRadacina.ToString(), pIdLocatieRadacina);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdGrup.ToString(), pIdGrup);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdSediu.ToString(), pIdSediu);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdSectie.ToString(), pIdSectie);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdUnitateFunctionala.ToString(), pIdUnitateFunctionala);
            dictCorespondenta.Adauga(EnumCampuriTabela.tTelefonMobil.ToString(), pTelefonMobil);
            dictCorespondenta.Adauga(EnumCampuriTabela.tFax.ToString(), pFax);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContSkype.ToString(), pContSkype);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContYM.ToString(), pContYM);
            dictCorespondenta.Adauga(EnumCampuriTabela.tAdresaMail.ToString(), pAdresaMail);
            dictCorespondenta.Adauga(EnumCampuriTabela.tPaginaWeb.ToString(), pPaginaWeb);
            dictCorespondenta.Adauga(EnumCampuriTabela.tInfoContact.ToString(), pInfoContact);
            dictCorespondenta.Adauga(EnumCampuriTabela.tLogo.ToString(), pLogo);
            dictCorespondenta.Adauga(EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString(), pIdLocatieDetaliiFiscale);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumireFiscala.ToString(), pDenumireFiscala);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipFiscalitate.ToString(), pTipFiscalitate);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCodFiscal.ToString(), pCodFiscal);
            dictCorespondenta.Adauga(EnumCampuriTabela.tNumarInregistrare.ToString(), pNumarInregistrare);
            dictCorespondenta.Adauga(EnumCampuriTabela.tContIBAN.ToString(), pContIBAN);
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumireBanca.ToString(), pDenumireBanca);
            dictCorespondenta.Adauga(EnumCampuriTabela.tReprezentantLegal.ToString(), pReprezentantLegal);
            dictCorespondenta.Adauga(EnumCampuriTabela.tCalitateReprezentantLegal.ToString(), pCalitateReprezentantLegal);
            dictCorespondenta.Adauga(EnumCampuriTabela.tSerieChitante.ToString(), pSerieChitante);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarUltimaChitanta.ToString(), pNumarUltimaChitanta);
            dictCorespondenta.Adauga(EnumCampuriTabela.tSerieFacturi.ToString(), pSerieFacturi);
            dictCorespondenta.Adauga(EnumCampuriTabela.nNumarUltimaFactura.ToString(), pNumarUltimaFactura);
            dictCorespondenta.Adauga(EnumCampuriTabela.bPlatitorDeTVA.ToString(), pPlatitorDeTVA);
            dictCorespondenta.Adauga(EnumCampuriTabela.tInitialaLocatie.ToString(), pInitialaLocatie);
            dictCorespondenta.Adauga(EnumCampuriTabela.nSubTipLocatie.ToString(), pSubTipLocatie);
            dictCorespondenta.Adauga(EnumCampuriTabela.nCuloare.ToString(), pCuloare, false);
            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        public static int Add(int pIdCreator, string pDenumire, IDbTransaction pTranzactie)
        {
            BColectieCorespondenteColoaneValori dictCorespondenta = new BColectieCorespondenteColoaneValori();
            dictCorespondenta.Adauga(EnumCampuriTabela.tDenumire.ToString(), pDenumire);
            dictCorespondenta.Adauga(EnumCampuriTabela.nTipLocatie.ToString(), 3); //Sediu (punct de lucru)

            return DGeneral.Insert(NUME_TABELA, dictCorespondenta, pIdCreator, pTranzactie);
        }

        #endregion //INSERT

        #region UPDATE

        /// <summary>
        /// Inchidem (dezactivam) o inregistrare din tabela ListaPreturiStandard_TP
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
        /// Modificam informatiile unei inregistrari din tabela ListaPreturiStandard_TP
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
