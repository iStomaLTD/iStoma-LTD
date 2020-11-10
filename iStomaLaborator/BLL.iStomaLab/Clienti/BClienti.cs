using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Clienti;
using ILL.iStomaLab;
using ILL.General.Interfete;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab.Comune;

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClienti : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BClienti> _lDictClienti = new Dictionary<int, BClienti>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        public struct StructDatornici
        {
            private DataRow dr;

            public StructDatornici(DataRow pDataRow) : this()
            {
                if (pDataRow["nId"] != DBNull.Value)
                    this.Id = Convert.ToInt32(pDataRow["nId"]);

            }

            public int Id { get; set; }
            public double SumaDatorata { get; set; }


        }

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 50;
            public const int DenumireFiscalaMaxLength = 50;
            public const int CUIMaxLength = 20;
            public const int RegComMaxLength = 20;
            public const int MotivInchidereMaxLength = 500;
            public const int TelefonMobilMaxLength = 20;
            public const int TelefonFixMaxLength = 20;
            public const int FaxMaxLength = 20;
            public const int ContSkypeMaxLength = 50;
            public const int AdresaMailMaxLength = 50;
            public const int PaginaWebMaxLength = 50;
            public const int IbanMaxLength = 40;
            public const int ReprezentantLegalMaxLength = 100;
            public const int ObservatiiDateFirmaMaxLength = 500;
            public const int NrContractMaxLength = 4;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClienti.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("TipClient", true, 1)]
        public int TipClient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.nTipClient.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.nTipClient.ToString(), value); }
        }

        [BExport("DenumireFiscala", true, 1)]
        public string DenumireFiscala
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tDenumireFiscala.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tDenumireFiscala.ToString(), value); }
        }

        [BExport("CUI", true, 1)]
        public string CUI
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tCUI.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tCUI.ToString(), value); }
        }

        [BExport("RegCom", true, 1)]
        public string RegCom
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tRegCom.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tRegCom.ToString(), value); }
        }
        
        [BExport("TelefonMobil", true, 1)]
        public string TelefonMobil
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tTelefonMobil.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tTelefonMobil.ToString(), value); }
        }
               

        [BExport("TelefonFix", true, 1)]
        public string TelefonFix
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tTelefonFix.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tTelefonFix.ToString(), value); }
        }

        [BExport("Fax", true, 1)]
        public string Fax
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tFax.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tFax.ToString(), value); }
        }
               

        [BExport("ContSkype", true, 1)]
        public string ContSkype
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tContSkype.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tContSkype.ToString(), value); }
        }

        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }

        [BExport("PaginaWeb", true, 1)]
        public string PaginaWeb
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tPaginaWeb.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tPaginaWeb.ToString(), value); }
        }

        [BExport("ObservatiiDateClinica", true, 1)]
        public string ObservatiiDateClinica
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tObservatiiDateClinica.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tObservatiiDateClinica.ToString(), value); }
        }

        [BExport("TipRecomandant", true, 1)]
        public int TipRecomandant
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.nTipRecomandant.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.nTipRecomandant.ToString(), value); }
        }

        [BExport("IdRecomandant", true, 1)]
        public int IdRecomandant
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.xnIdRecomandant.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.xnIdRecomandant.ToString(), value); }
        }

        public int IdAgentVanzari
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.xnIdAgentVanzari.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.xnIdAgentVanzari.ToString(), value); }
        }

        [BExport("Iban", true, 1)]
        public string Iban
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tIban.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tIban.ToString(), value); }
        }

        [BExport("IdBanca", true, 1)]
        public int IdBanca
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.xnIdBanca.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.xnIdBanca.ToString(), value); }
        }

        [BExport("ReprezentantLegal", true, 1)]
        public string ReprezentantLegal
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tReprezentantLegal.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tReprezentantLegal.ToString(), value); }
        }

        [BExport("CalitateReprezentant", true, 1)]
        public int CalitateReprezentant
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.nCalitateReprezentant.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.nCalitateReprezentant.ToString(), value); }
        }

        [BExport("NumarContract", true, 1)]
        public int NumarContract
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClienti.EnumCampuriTabela.nNumarContract.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.nNumarContract.ToString(), value); }
        }

        [BExport("DataContract", true, 1)]
        public DateTime DataContract
        {
            get { return this.MyDataRowGetItemAsDateNull(DClienti.EnumCampuriTabela.dDataContract.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.dDataContract.ToString(), value); }
        }

        [BExport("ObservatiiDateFirma", true, 1)]
        public string ObservatiiDateFirma
        {
            get { return this.MyDataRowGetItem(DClienti.EnumCampuriTabela.tObservatiiDateFirma.ToString()); }
            set { this.MyDataRowSetItem(DClienti.EnumCampuriTabela.tObservatiiDateFirma.ToString(), value); }
        }
        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Clienti; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClienti(int pId)
        : this(pId, null)
        {
        }

        public BClienti(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClienti>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClienti(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClienti>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static List<StructIdDenumire> GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (string.IsNullOrEmpty(pDenumire)) return listaRetur;

            //Nu avem un infinit de clienti; cautam dupa orice din prima
            using (DataSet ds = DClienti.GetListaCautare(string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nId"]), Convert.ToString(dr["tDenumire"])));
                }
            }

            return listaRetur;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClienti
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
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, int pTipClient, string pDenumireFiscala, string pCUI, string pRegCom, string pTelefonMobil, string pTelefonFix, string pFax, string pContSkype, string pAdresaMail, string pPaginaWeb, string pObservatiiDateClinica, int pTipRecomandant, int pIdRecomandant, string pIban, int pIdBanca, string pReprezentantLegal, int pCalitateReprezentant, int pNumarContract, DateTime pDataContract, string pObservatiiDateFirma, int xnIdAgentVanzari, IDbTransaction pTranzactie)
        {
            int id = DClienti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pTipClient, pDenumireFiscala, pCUI, pRegCom, pTelefonMobil, pTelefonFix, pFax, pContSkype, pAdresaMail, pPaginaWeb, pObservatiiDateClinica, pTipRecomandant, pIdRecomandant, pIban, pIdBanca, pReprezentantLegal, pCalitateReprezentant, pNumarContract, pDataContract, pObservatiiDateFirma, xnIdAgentVanzari, pTranzactie);
            return id;
        }

        public static int Add(string pDenumire, IDbTransaction pTranzactie)
        {
            int id = DClienti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire.Trim(), 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, 0, CConstante.DataNula, string.Empty, 0, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }

        public static BClienti getClient(int lId, IDbTransaction xTrans)
        {
            if (_lDictClienti == null)
                _lDictClienti = new Dictionary<int, BClienti>();

            if (!_lDictClienti.ContainsKey(lId))
                _lDictClienti.Add(lId, new BClienti(lId, xTrans));

            return _lDictClienti[lId];
        }


        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClienti
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClienti GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClienti lstDClienti = new BColectieClienti();
            using (DataSet ds = DClienti.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClienti.Add(new BClienti(dr));
                }
            }
            return lstDClienti;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea DataRow-ului corespunzator obiectului in baza de date
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Un DataRow ce contine informatiile corespunzatoare obiectului</returns>
        /// <remarks></remarks>
        private static DataRow GetDataRowForObjet(int pId, IDbTransaction pTranzactie)
        {
            if (pId <= 0)
                throw new IdentificareBazaImposibilaException("BClienti");
            using (DataSet ds = DClienti.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClienti");
            }
        }

        public static BColectieClienti getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClienti listaRetur = new BColectieClienti();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClienti.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClienti(dr));
                    }
                }
            }
            return listaRetur;
        }
             
        public static BColectieClienti GetListaClientiNoiPerioada(DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieClienti lstDClientiComenziEtape = new BColectieClienti();
            using (DataSet ds = DClienti.GetListaClientiNoiPerioada(pDataInceput, pDataSfarsit, CDefinitiiComune.EnumStare.Activa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClienti(dr));
                }
            }
            return lstDClientiComenziEtape;
        }

        public static Dictionary<int, double> GetListaDatornici(IDbTransaction pTranzactie)
        {
            Dictionary<int, double> listaRetur = new Dictionary<int, double>();

            using (DataSet ds = DClienti.GetListaDatornici(pTranzactie))
            {
                int idClinica = 0;
                double nSold = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idClinica = CUtil.GetAsInt32(dr[DClienti.EnumCampuriViewSolduri.ID.ToString()]);
                    nSold = CUtil.GetAsDouble(dr[DClienti.EnumCampuriViewSolduri.nSold.ToString()]);
                    listaRetur.Add(idClinica, nSold);
                }
            }

            return listaRetur;
        }

        public double GetTotalIncasari(IDbTransaction pTranzactie)
        {
            return BClientiPlati.GetTotalIncasari(this.Id, pTranzactie);
        }

        public double GetTotalFacturi(IDbTransaction pTranzactie)
        {
            return BClientiComenzi.GetTotalFacturiClient(this.Id, pTranzactie);            
        }


        #endregion //Metode de clasa

        #region Metode de instanta
        public BClientiComenzi GetUltimaLucrare(IDbTransaction pTranzactie)
        {
            return BClientiComenzi.GetUltimaLucrare(this.Id, pTranzactie);
        }


        public double GetSold(IDbTransaction pTranzactie)
        {
            double nSold = 0;
            using (DataSet ds = DClienti.GetSold(this.Id, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nSold = CUtil.GetAsDouble(dr[DClienti.EnumCampuriViewSolduri.nSold.ToString()]);
                }
            }
            return nSold;
        }

        public BColectieClientiComenzi GetListaLucrariNefacturate(IDbTransaction pTranzactie)
        {
            return BClientiComenzi.GetListaLucrariNefacturateByIdClinica(this.Id, pTranzactie);
        }

        public BColectieClientiComenzi GetListaLucrari(IDbTransaction pTranzactie) 
        {
            return BClientiComenzi.GetListaLucrariByIdClinica(this.Id, pTranzactie); 
        }

        public BClientiFacturi GetUltimaFactura(IDbTransaction pTranzactie)
        {
            return BClientiFacturi.GetUltimaFactura(this.Id, pTranzactie);
        }

        public string GetDenumireFiscala()
        {
            if (!string.IsNullOrEmpty(this.DenumireFiscala) && this.DenumireFiscala.Length > 4)
                return this.DenumireFiscala;

            return this.Denumire;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public bool UpdateAll()
        {
            return this.UpdateAll(null);
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <returns>True daca inregistrarea a fost modificata; False in caz contrar</returns>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public override bool UpdateAll(IDbTransaction pTranzactie)
        {

            if (!this.ExistaProprietatiModificate()) return true;

            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = DClienti.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
                return succesModificare;
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de actualizare generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nTipClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tDenumireFiscala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tCUI.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tRegCom.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tTelefonMobil.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tTelefonFix.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tFax.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tContSkype.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tAdresaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tPaginaWeb.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tObservatiiDateClinica.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nTipRecomandant.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdRecomandant.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tIban.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdBanca.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tReprezentantLegal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nCalitateReprezentant.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nNumarContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.dDataContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tObservatiiDateFirma.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdAgentVanzari.ToString());
        }

        /// <summary>
        /// Metoda de instanta ce permite inchiderea(dezactivarea) obiectului
        /// </summary>
        /// <param name="pInchidere">inchidem sau activam?</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Close(bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClienti");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClienti.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de inchidere generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nTipClient.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.nTipClient.ToString(), this.TipClient);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tDenumireFiscala.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tDenumireFiscala.ToString(), this.DenumireFiscala);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tCUI.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tCUI.ToString(), this.CUI);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tRegCom.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tRegCom.ToString(), this.RegCom);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tTelefonMobil.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tTelefonMobil.ToString(), this.TelefonMobil);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tTelefonFix.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tTelefonFix.ToString(), this.TelefonFix);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tFax.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tFax.ToString(), this.Fax);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tContSkype.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tContSkype.ToString(), this.ContSkype);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tPaginaWeb.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tPaginaWeb.ToString(), this.PaginaWeb);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tObservatiiDateClinica.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tObservatiiDateClinica.ToString(), this.ObservatiiDateClinica);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nTipRecomandant.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.nTipRecomandant.ToString(), this.TipRecomandant);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdRecomandant.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.xnIdRecomandant.ToString(), this.IdRecomandant);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tIban.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tIban.ToString(), this.Iban);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdBanca.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.xnIdBanca.ToString(), this.IdBanca);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tReprezentantLegal.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tReprezentantLegal.ToString(), this.ReprezentantLegal);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nCalitateReprezentant.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.nCalitateReprezentant.ToString(), this.CalitateReprezentant);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.nNumarContract.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.nNumarContract.ToString(), this.NumarContract);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.dDataContract.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.dDataContract.ToString(), this.DataContract);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.tObservatiiDateFirma.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.tObservatiiDateFirma.ToString(), this.ObservatiiDateFirma);
            if (this.IsMyDataRowItemHasChanged(DClienti.EnumCampuriTabela.xnIdAgentVanzari.ToString()))
                dictRezultat.Adauga(DClienti.EnumCampuriTabela.xnIdAgentVanzari.ToString(), this.IdAgentVanzari);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClienti");

            FillObjectWithDataRow<BClienti>(GetDataRowForObjet(this.Id, pTranzactie), this);
        }

        /// <summary>
        /// Metoda pentru serializarea obiectului in flux XML
        /// </summary>
        /// <returns>Un sir de caractere ce reprezinta obiectul sub forma de flux XML</returns>
        /// <remarks></remarks>
        public new string ObjectToXMLString()
        {
            System.Xml.XmlDocument myXmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement myXmlElem;
            string sRet = string.Empty;

            //Cream documentul:
            myXmlDoc.LoadXml("<DClienti></DClienti>");

            //Adaugam elementele clasei BClienti
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.TipClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIREFISCALA");
            myXmlElem.InnerText = this.DenumireFiscala;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CUI");
            myXmlElem.InnerText = this.CUI;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("REGCOM");
            myXmlElem.InnerText = this.RegCom;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.DataInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MOTIVINCHIDERE");
            myXmlElem.InnerText = this.MotivInchidere;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TELEFONMOBIL");
            myXmlElem.InnerText = this.TelefonMobil;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TELEFONFIX");
            myXmlElem.InnerText = this.TelefonFix;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("FAX");
            myXmlElem.InnerText = this.Fax;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTSKYPE");
            myXmlElem.InnerText = this.ContSkype;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ADRESAMAIL");
            myXmlElem.InnerText = this.AdresaMail;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PAGINAWEB");
            myXmlElem.InnerText = this.PaginaWeb;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATIIDATECLINICA");
            myXmlElem.InnerText = this.ObservatiiDateClinica;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPRECOMANDANT");
            myXmlElem.InnerText = Convert.ToString(this.TipRecomandant);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDRECOMANDANT");
            myXmlElem.InnerText = Convert.ToString(this.IdRecomandant);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IBAN");
            myXmlElem.InnerText = this.Iban;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDBANCA");
            myXmlElem.InnerText = Convert.ToString(this.IdBanca);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("REPREZENTANTLEGAL");
            myXmlElem.InnerText = this.ReprezentantLegal;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CALITATEREPREZENTANT");
            myXmlElem.InnerText = Convert.ToString(this.CalitateReprezentant);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARCONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.NumarContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.DataContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATIIDATEFIRMA");
            myXmlElem.InnerText = this.ObservatiiDateFirma;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        public override string ToString()
        {
            return this.Denumire;
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BClienti xElemLista1, BClienti xElemLista2)
        {
            if (xElemLista1 == null)
            {
                if (xElemLista2 == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (xElemLista2 == null)
                    return 1;
                else
                    return xElemLista1.Denumire.CompareTo(xElemLista2.Denumire);
            }
        }

        #endregion //Metode de comparatie

    }

}