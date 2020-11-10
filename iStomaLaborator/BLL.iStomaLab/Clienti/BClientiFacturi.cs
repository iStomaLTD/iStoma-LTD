using BLL.iStomaLab.Locatii;
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

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea facturilor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiFacturi : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int SerieFacturaMaxLength = 10;
            public const int ObservatiiMaxLength = 500;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela

        public enum EnumTipDocumentNotaPlata
        {
            Proforma = 1,
            Factura = 2,
        }

        public struct StructTipDocumentNotaPlata
        {
            public EnumTipDocumentNotaPlata IdEnum { get; set; }
            public int Id { get { return Convert.ToInt32(this.IdEnum); } }
            public string Nume { get; set; }

            private StructTipDocumentNotaPlata(EnumTipDocumentNotaPlata pIdEnum, string pNume) : this()
            {
                this.IdEnum = pIdEnum;
                this.Nume = pNume;
            }

            public static List<StructTipDocumentNotaPlata> GetList()
            {
                List<StructTipDocumentNotaPlata> listaRetur = new List<StructTipDocumentNotaPlata>();

                listaRetur.Add(GetStructByEnum(EnumTipDocumentNotaPlata.Proforma));
                listaRetur.Add(GetStructByEnum(EnumTipDocumentNotaPlata.Factura));

                return listaRetur;
            }

            public static StructTipDocumentNotaPlata GetStructByEnum(EnumTipDocumentNotaPlata pIdEnum)
            {
                if (pIdEnum == EnumTipDocumentNotaPlata.Factura)
                    return new StructTipDocumentNotaPlata(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura));

                return new StructTipDocumentNotaPlata(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Proforma));
            }

            public static string GetStringByEnum(EnumTipDocumentNotaPlata pIdEnum)
            {
                return GetStructByEnum(pIdEnum).Nume;
            }

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumTipDocumentNotaPlata || obj is Int32 || obj is Int64)
                    return this.Id == Convert.ToInt32(obj);

                if (obj is StructTipDocumentNotaPlata)
                    return this.IdEnum == ((StructTipDocumentNotaPlata)obj).IdEnum;

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiFacturi.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiFacturi.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        [BExport("DataFactura", true, 1)]
        public DateTime DataFactura
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiFacturi.EnumCampuriTabela.dDataFactura.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.dDataFactura.ToString(), value); }
        }

        [BExport("SerieFactura", true, 1)]
        public string SerieFactura
        {
            get { return this.MyDataRowGetItem(DClientiFacturi.EnumCampuriTabela.tSerieFactura.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.tSerieFactura.ToString(), value); }
        }

        [BExport("NumarFactura", true, 1)]
        public int NumarFactura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiFacturi.EnumCampuriTabela.nNumarFactura.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.nNumarFactura.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiFacturi.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        [BExport("MonedaFactura", true, 1)]
        public CDefinitiiComune.EnumTipMoneda MonedaFactura
        {
            get { return this.MyDataRowGetItemAsMoneda(DClientiFacturi.EnumCampuriTabela.nMonedaFactura.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.nMonedaFactura.ToString(), value); }
        }

        [BExport("CursBNR", true, 1)]
        public double CursBNR
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiFacturi.EnumCampuriTabela.nCursBNR.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.nCursBNR.ToString(), value); }
        }

        [BExport("MotivInchidere", true, 1)]
        public string MotivInchidere
        {
            get { return this.MyDataRowGetItem(DClientiFacturi.EnumCampuriTabela.tMotivInchidere.ToString()); }
            set { this.MyDataRowSetItem(DClientiFacturi.EnumCampuriTabela.tMotivInchidere.ToString(), value); }
        }

        public string DenumireClient
        {
            get { return this.MyDataRowGetItem(DClientiFacturi.EnumCampuriTabela.tDenumireClient.ToString()); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiFacturiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiFacturi; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiFacturi(int pId) : this(pId, null)
        {
        }

        public BClientiFacturi(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiFacturi>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiFacturi(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiFacturi>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiFacturi
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pDataFactura"></param>
        /// <param name="pSerieFactura"></param>
        /// <param name="pNumarFactura"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pMonedaFactura"></param>
        /// <param name="pCursBNR"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdClient, DateTime pDataFactura, string pSerieFactura, int pNumarFactura, string pObservatii, CDefinitiiComune.EnumTipMoneda pMonedaFactura, double pCursBNR, BColectieClientiComenzi pListaComenzi, EnumTipDocumentNotaPlata pTipDocument, IDbTransaction pTranzactie)
        {
            int id = DClientiFacturi.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pDataFactura, pSerieFactura, pNumarFactura, pObservatii, Convert.ToInt32(pMonedaFactura), pCursBNR, pTranzactie);

            pListaComenzi.UpdateIdFactura(id, pTranzactie);

            if (pTipDocument == EnumTipDocumentNotaPlata.Factura)
            {
                BClientiFacturi factCreata = new BClientiFacturi(id, pTranzactie);
                factCreata.Fiscalizeaza(pTranzactie);
            }

            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdClient)
        {
            return pIdClient != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiFacturi
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiFacturi GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi lstDClientiFacturi = new BColectieClientiFacturi();
            using (DataSet ds = DClientiFacturi.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiFacturi.Add(new BClientiFacturi(dr));
                }
            }
            return lstDClientiFacturi;
        }

        public static BColectieClientiFacturi GetListByClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi lstDClientiFacturi = new BColectieClientiFacturi();
            using (DataSet ds = DClientiFacturi.GetListByParamIdClient(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiFacturi.Add(new BClientiFacturi(dr));
                }
            }
            return lstDClientiFacturi;
        }

        public static BColectieClientiFacturi GetUltimeleFacturiPerClinica(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi lstDClientiFacturi = new BColectieClientiFacturi();
            if (!CUtil.EsteListaIntVida(pListaIdClinici))
            {
                using (DataSet ds = DClientiFacturi.GetUltimeleFacturiPerClinica(pListaIdClinici, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstDClientiFacturi.Add(new BClientiFacturi(dr));
                    }
                }
            }
            return lstDClientiFacturi;
        }

        public static BColectieClientiFacturi GetListByClientSiPerioada(int pIdClient, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi lstDClientiFacturi = new BColectieClientiFacturi();
            using (DataSet ds = DClientiFacturi.GetListByClientSiPerioada(pIdClient, pDataInceput, pDataSfarsit, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiFacturi.Add(new BClientiFacturi(dr));
                }
            }
            return lstDClientiFacturi;
        }

        public static BColectieClientiFacturi GetByListId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi lstDClientiFacturi = new BColectieClientiFacturi();
            using (DataSet ds = DClientiFacturi.GetByListId(pListaId, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiFacturi.Add(new BClientiFacturi(dr));
                }
            }
            return lstDClientiFacturi;
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
                throw new IdentificareBazaImposibilaException("BClientiFacturi");
            using (DataSet ds = DClientiFacturi.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiFacturi");
            }
        }

        public static BColectieClientiFacturi getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiFacturi listaRetur = new BColectieClientiFacturi();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiFacturi.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiFacturi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BClientiFacturi getById(int pId, IDbTransaction pTranzactie)
        {
            return new BClientiFacturi(pId, pTranzactie);
        }

        public static Dictionary<int, double> GetDictIdClinicaTotalFacturi(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            return BClientiComenzi.GetDictIdClinicaTotalFacturi(pListaIdClinici, pTranzactie);
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public void Fiscalizeaza(IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCL.DAL.CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;

                BLocatii firma = BLocatii.GetLocatieCurenta();

                this.SerieFactura = firma.SerieFacturi;
                this.NumarFactura = firma.NumarUltimaFactura + 1;
                this.UpdateAll(Tranzactie);

                firma.NumarUltimaFactura = this.NumarFactura;
                firma.UpdateAll(Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
        }
        public string ToStringTipDocument()
        {
            if (EsteFiscalizata())
                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Factura);
            else
                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Proforma);
        }

        public bool EsteFiscalizata()
        {
            return !string.IsNullOrEmpty(this.SerieFactura);
        }

        public string ToStringImprimare()
        {
            return string.Format("{0}_{1}_{2:dd-MM-yyyy}", this.DenumireClient, this.Id, this.DataFactura);
        }

        public BClienti GetClient(IDbTransaction pTranzactie)
        {
            return new Clienti.BClienti(this.IdClient, pTranzactie);
        }

        public BColectieClientiComenzi GetListaLucrari(IDbTransaction pTranzactie)
        {
            return BClientiComenzi.GetByIdFactura(this.Id, pTranzactie);
        }

        public BColectieClientiPlatiComenzi GetListaPlati(IDbTransaction pTranzactie)
        {
            return BClientiPlatiComenzi.GetListByIdFactura(this.Id, pTranzactie);
        }

        public string GetSerieNumarFactura()
        {

            return string.Format("{0} - {1}", this.SerieFactura, this.NumarFactura);
        }

        public double GetValoare(BColectieClientiComenzi pListaComenzi, CDefinitiiComune.EnumTipMoneda pMoneda, double pCursSchimb)
        {
            double valoare = 0;

            foreach (var item in pListaComenzi)
            {
                valoare += item.GetValoareMoneda(pMoneda, pCursSchimb);
            }

            return valoare;
        }

        public EnumTipDocumentNotaPlata GetTipDocumentNotaPlata()
        {
            if (EsteFiscalizata())
                return EnumTipDocumentNotaPlata.Factura;
            else
                return EnumTipDocumentNotaPlata.Proforma;
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
                bool succesModificare = DClientiFacturi.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.xnIdClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.dDataFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tSerieFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nNumarFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nMonedaFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nCursBNR.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiFacturi");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;


                //Inchidem obiectul in baza de date
                DClientiFacturi.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

                //Recuperam toate comenzile si le disociem
                GetListaLucrari(Tranzactie).ScoateDinFactura(Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.dDataFactura.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.dDataFactura.ToString(), this.DataFactura);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tSerieFactura.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.tSerieFactura.ToString(), this.SerieFactura);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nNumarFactura.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.nNumarFactura.ToString(), this.NumarFactura);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nMonedaFactura.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.nMonedaFactura.ToString(), this.MonedaFactura);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.nCursBNR.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.nCursBNR.ToString(), this.CursBNR);
            if (this.IsMyDataRowItemHasChanged(DClientiFacturi.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiFacturi.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiFacturi");

            FillObjectWithDataRow<BClientiFacturi>(GetDataRowForObjet(this.Id, pTranzactie), this);
        }
        public static BClientiFacturi GetUltimaFactura(int pIdClinica, IDbTransaction pTranzactie)
        {
            using (DataSet ds = DClientiFacturi.GetUltimaFactura(pIdClinica, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    return new BClientiFacturi(dr);
                }
            }
            return null;
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
            myXmlDoc.LoadXml("<DClientiFacturi></DClientiFacturi>");

            //Adaugam elementele clasei BClientiFacturi
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAFACTURA");
            myXmlElem.InnerText = Convert.ToString(this.DataFactura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SERIEFACTURA");
            myXmlElem.InnerText = this.SerieFactura;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARFACTURA");
            myXmlElem.InnerText = Convert.ToString(this.NumarFactura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MONEDAFACTURA");
            myXmlElem.InnerText = Convert.ToString(this.MonedaFactura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CURSBNR");
            myXmlElem.InnerText = Convert.ToString(this.CursBNR);
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

        #endregion //Metode de instanta

        #region Metode de comparatie



        #endregion //Metode de comparatie

    }
}
