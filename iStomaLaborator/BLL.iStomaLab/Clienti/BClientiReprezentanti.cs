using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Clienti;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Reprezentanti
{
    public sealed class BClientiReprezentanti : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BClientiReprezentanti> _lDictReprezentanti = new Dictionary<int, BClientiReprezentanti>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int CNPMaxLength = 20;
            public const int NumeMaxLength = 50;
            public const int PrenumeMaxLength = 50;
            public const int NumeDeFataMaxLength = 50;
            public const int PoreclaMaxLength = 50;
            public const int TelefonMobilMaxLength = 20;
            public const int TelefonFixMaxLength = 20;
            public const int FaxMaxLength = 20;
            public const int ContSkypeMaxLength = 50;
            public const int ContYMMaxLength = 50;
            public const int AdresaMailMaxLength = 50;
            public const int ScoalaMaxLength = 100;
            public const int ObservatiiMaxLength = 500;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiReprezentanti.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiReprezentanti.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        [BExport("CNP", true, 1)]
        public string CNP
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tCNP.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tCNP.ToString(), value); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tNume.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tNume.ToString(), value); }
        }

        [BExport("Prenume", true, 1)]
        public string Prenume
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tPrenume.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tPrenume.ToString(), value); }
        }

        [BExport("DataNastere", true, 1)]
        public DateTime DataNastere
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiReprezentanti.EnumCampuriTabela.dDataNastere.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.dDataNastere.ToString(), value); }
        }

        [BExport("Sex", true, 1)]
        public int Sex
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.nSex.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.nSex.ToString(), value); }
        }

        [BExport("Titulatura", true, 1)]
        public int Titulatura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.nTitulatura.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.nTitulatura.ToString(), value); }
        }

        [BExport("NumeDeFata", true, 1)]
        public string NumeDeFata
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tNumeDeFata.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tNumeDeFata.ToString(), value); }
        }

        [BExport("Porecla", true, 1)]
        public string Porecla
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tPorecla.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tPorecla.ToString(), value); }
        }

        [BExport("TelefonMobil", true, 1)]
        public string TelefonMobil
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tTelefonMobil.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tTelefonMobil.ToString(), value); }
        }

        [BExport("TelefonFix", true, 1)]
        public string TelefonFix
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tTelefonFix.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tTelefonFix.ToString(), value); }
        }

        [BExport("Fax", true, 1)]
        public string Fax
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tFax.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tFax.ToString(), value); }
        }

        [BExport("ContSkype", true, 1)]
        public string ContSkype
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tContSkype.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tContSkype.ToString(), value); }
        }

        [BExport("ContYM", true, 1)]
        public string ContYM
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tContYM.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tContYM.ToString(), value); }
        }

        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }

        [BExport("Rol", true, 1)]
        public CDefinitiiComune.EnumRol Rol
        {
            get { return (CDefinitiiComune.EnumRol)this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.nRol.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.nRol.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("StareCivila", true, 1)]
        public int StareCivila
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.nStareCivila.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.nStareCivila.ToString(), value); }
        }

        [BExport("NumarCopii", true, 1)]
        public int NumarCopii
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.nNumarCopii.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.nNumarCopii.ToString(), value); }
        }

        [BExport("Scoala", true, 1)]
        public string Scoala
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tScoala.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tScoala.ToString(), value); }
        }

        [BExport("IdNationalitate", true, 1)]
        public int IdNationalitate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.xnIdNationalitate.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdNationalitate.ToString(), value); }
        }

        [BExport("IdTaraNastere", true, 1)]
        public int IdTaraNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.xnIdTaraNastere.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdTaraNastere.ToString(), value); }
        }

        [BExport("IdJudetNastere", true, 1)]
        public int IdJudetNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.xnIdJudetNastere.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdJudetNastere.ToString(), value); }
        }

        [BExport("IdLocalitateNastere", true, 1)]
        public int IdLocalitateNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.xnIdLocalitateNastere.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdLocalitateNastere.ToString(), value); }
        }

        [BExport("IdProfesie", true, 1)]
        public int IdProfesie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiReprezentanti.EnumCampuriTabela.xnIdProfesie.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.xnIdProfesie.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiReprezentanti.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiReprezentanti.EnumCampuriTabela.tObservatii.ToString(), value); }
        }


        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiReprezentantiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiReprezentanti; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiReprezentanti(int pId)
        : this(pId, null)
        {
        }

        public BClientiReprezentanti(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiReprezentanti>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiReprezentanti(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiReprezentanti>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiReprezentanti
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pCNP"></param>
        /// <param name="pNume"></param>
        /// <param name="pPrenume"></param>
        /// <param name="pDataNastere"></param>
        /// <param name="pSex"></param>
        /// <param name="pTitulatura"></param>
        /// <param name="pNumeDeFata"></param>
        /// <param name="pPorecla"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pTelefonFix"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pContYM"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pRol"></param>
        /// <param name="pStareCivila"></param>
        /// <param name="pNumarCopii"></param>
        /// <param name="pScoala"></param>
        /// <param name="pIdNationalitate"></param>
        /// <param name="pIdTaraNastere"></param>
        /// <param name="pIdJudetNastere"></param>
        /// <param name="pIdLocalitateNastere"></param>
        /// <param name="pIdProfesie"></param>
        /// <param name="pObservatii"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdClient, string pCNP, string pNume, string pPrenume, DateTime pDataNastere, int pSex, int pTitulatura, string pNumeDeFata, string pPorecla, string pTelefonMobil, string pTelefonFix, string pFax, string pContSkype, string pContYM, string pAdresaMail, CDefinitiiComune.EnumRol pRol, int pStareCivila, int pNumarCopii, string pScoala, int pIdNationalitate, int pIdTaraNastere, int pIdJudetNastere, int pIdLocalitateNastere, int pIdProfesie, string pObservatii, IDbTransaction pTranzactie)
        {
            int id = DClientiReprezentanti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pCNP, pNume, pPrenume, pDataNastere, pSex, pTitulatura, pNumeDeFata, pPorecla, pTelefonMobil, pTelefonFix, pFax, pContSkype, pContYM, pAdresaMail, Convert.ToInt32(pRol), pStareCivila, pNumarCopii, pScoala, pIdNationalitate, pIdTaraNastere, pIdJudetNastere, pIdLocalitateNastere, pIdProfesie, pObservatii, pTranzactie);
            return id;
        }

        public static int Add(int pIdClient, string pNume, string pPrenume, string pTelefonMobil, IDbTransaction pTranzactie)
        {
            int id = DClientiReprezentanti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, string.Empty, pNume, pPrenume, CConstante.DataNula, 0, 0, string.Empty, string.Empty, pTelefonMobil, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdClient, string pNume)
        {
            return pIdClient != 0 && !string.IsNullOrEmpty(pNume);
        }

        public static BClientiReprezentanti getReprezentant(int lId, IDbTransaction xTrans)
        {
            if (_lDictReprezentanti == null)
                _lDictReprezentanti = new Dictionary<int, BClientiReprezentanti>();

            if (!_lDictReprezentanti.ContainsKey(lId))
                _lDictReprezentanti.Add(lId, new BClientiReprezentanti(lId, xTrans));

            return _lDictReprezentanti[lId];
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BReprezentant
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieReprezentant GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieReprezentant lstDClientiReprezentanti = new BColectieReprezentant();
            using (DataSet ds = DClientiReprezentanti.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiReprezentanti.Add(new BClientiReprezentanti(dr));
                }
            }
            return lstDClientiReprezentanti;
        }

        public static BColectieReprezentant GetListByIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieReprezentant lstDClientiReprezentanti = new BColectieReprezentant();
            using (DataSet ds = DClientiReprezentanti.GetListByParamIdClient(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiReprezentanti.Add(new BClientiReprezentanti(dr));
                }
            }
            return lstDClientiReprezentanti;
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
                throw new IdentificareBazaImposibilaException("BClientiReprezentanti");
            using (DataSet ds = DClientiReprezentanti.GetReprezentantById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiReprezentanti");
            }
        }

        public static BColectieReprezentant getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieReprezentant listaRetur = new BColectieReprezentant();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiReprezentanti.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiReprezentanti(dr));
                    }
                }
            }
            return listaRetur;
        }

        public string GetIdentitateReprezentant()
        {
            return this.Nume + BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Spatiu) + this.Prenume;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

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
                bool succesModificare = DClientiReprezentanti.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tCNP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tNume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tPrenume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.dDataNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nSex.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nTitulatura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tNumeDeFata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tPorecla.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tTelefonMobil.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tFax.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tContSkype.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tContYM.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tAdresaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nRol.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nStareCivila.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nNumarCopii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tScoala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdNationalitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdTaraNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdJudetNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdLocalitateNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdProfesie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BReprezentant");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiReprezentanti.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tCNP.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tCNP.ToString(), this.CNP);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tNume.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tNume.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tPrenume.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tPrenume.ToString(), this.Prenume);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.dDataNastere.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.dDataNastere.ToString(), this.DataNastere);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nSex.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.nSex.ToString(), this.Sex);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nTitulatura.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.nTitulatura.ToString(), this.Titulatura);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tNumeDeFata.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tNumeDeFata.ToString(), this.NumeDeFata);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tPorecla.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tPorecla.ToString(), this.Porecla);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tTelefonMobil.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tTelefonMobil.ToString(), this.TelefonMobil);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tTelefonFix.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tTelefonFix.ToString(), this.TelefonFix);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tFax.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tFax.ToString(), this.Fax);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tContSkype.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tContSkype.ToString(), this.ContSkype);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tContYM.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tContYM.ToString(), this.ContYM);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nRol.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.nRol.ToString(), Convert.ToInt32(this.Rol));
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nStareCivila.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.nStareCivila.ToString(), this.StareCivila);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.nNumarCopii.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.nNumarCopii.ToString(), this.NumarCopii);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tScoala.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tScoala.ToString(), this.Scoala);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdNationalitate.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdNationalitate.ToString(), this.IdNationalitate);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdTaraNastere.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdTaraNastere.ToString(), this.IdTaraNastere);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdJudetNastere.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdJudetNastere.ToString(), this.IdJudetNastere);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdLocalitateNastere.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdLocalitateNastere.ToString(), this.IdLocalitateNastere);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.xnIdProfesie.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.xnIdProfesie.ToString(), this.IdProfesie);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiReprezentanti.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiReprezentanti.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BReprezentant");

            FillObjectWithDataRow<BClientiReprezentanti>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DClientiReprezentanti></DClientiReprezentanti>");

            //Adaugam elementele clasei BReprezentant
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CNP");
            myXmlElem.InnerText = this.CNP;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PRENUME");
            myXmlElem.InnerText = this.Prenume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATANASTERE");
            myXmlElem.InnerText = Convert.ToString(this.DataNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SEX");
            myXmlElem.InnerText = Convert.ToString(this.Sex);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TITULATURA");
            myXmlElem.InnerText = Convert.ToString(this.Titulatura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMEDEFATA");
            myXmlElem.InnerText = this.NumeDeFata;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PORECLA");
            myXmlElem.InnerText = this.Porecla;
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

            myXmlElem = myXmlDoc.CreateElement("CONTYM");
            myXmlElem.InnerText = this.ContYM;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ADRESAMAIL");
            myXmlElem.InnerText = this.AdresaMail;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ROL");
            myXmlElem.InnerText = Convert.ToString(this.Rol);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("STARECIVILA");
            myXmlElem.InnerText = Convert.ToString(this.StareCivila);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARCOPII");
            myXmlElem.InnerText = Convert.ToString(this.NumarCopii);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SCOALA");
            myXmlElem.InnerText = this.Scoala;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDNATIONALITATE");
            myXmlElem.InnerText = Convert.ToString(this.IdNationalitate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDTARANASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdTaraNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDJUDETNASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdJudetNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCALITATENASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdLocalitateNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDPROFESIE");
            myXmlElem.InnerText = Convert.ToString(this.IdProfesie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
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

            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        public static List<string> getListaMediciDenumire(int pIdClient)
        {
            List<string> lstReturn = new List<string>();
            foreach (BClientiReprezentanti medic in GetListByIdClient(pIdClient, CDefinitiiComune.EnumStare.Activa, null))
            {
                lstReturn.Add(medic.GetIdentitateReprezentant());
            }

            return lstReturn;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Nume, this.Prenume);
        }

        #endregion //Metode de instanta

        #region Metode de comparatie



        #endregion //Metode de comparatie

    }
}
