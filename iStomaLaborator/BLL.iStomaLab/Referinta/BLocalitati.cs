using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Referinta;
using ILL.iStomaLab;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;

namespace BLL.iStomaLab.Referinta
{
    /// <summary>
    /// Clasa pentru gestionarea localitatilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BLocalitati : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BLocalitati> _lDictLocalitati = new Dictionary<int, BLocalitati>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumeMaxLength = 50;
            public const int MotivInchidereMaxLength = 250;
            public const int NumeRegiuneMaxLength = 50;
            public const int NumeTaraMaxLength = 60;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.nIdLocalitate.ToString()); }
        }

        [BExport("IdRegiune", true, 1)]
        public int IdRegiune
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.xnIdRegiune.ToString()); }
            set { this.MyDataRowSetItem(DLocalitati.EnumCampuriTabela.xnIdRegiune.ToString(), value); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DLocalitati.EnumCampuriTabela.tNume.ToString()); }
            set { this.MyDataRowSetItem(DLocalitati.EnumCampuriTabela.tNume.ToString(), value); }
        }

        [BExport("Tip", true, 1)]
        public int Tip
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.nTip.ToString()); }
            set { this.MyDataRowSetItem(DLocalitati.EnumCampuriTabela.nTip.ToString(), value); }
        }

        [BExport("LimbaDenumirii", true, 1)]
        public int LimbaDenumirii
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.nLimbaDenumirii.ToString()); }
            set { this.MyDataRowSetItem(DLocalitati.EnumCampuriTabela.nLimbaDenumirii.ToString(), value); }
        }

        [BExport("Preferinta", true, 1)]
        public int Preferinta
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.nPreferinta.ToString()); }
            set { this.MyDataRowSetItem(DLocalitati.EnumCampuriTabela.nPreferinta.ToString(), value); }
        }

        [BExport("IdTara", true, 1)]
        public int IdTara
        {
            get { return this.MyDataRowGetItemAsInteger(DLocalitati.EnumCampuriTabela.xnIdTara.ToString()); }
        }

        [BExport("NumeRegiune", true, 1)]
        public string NumeRegiune
        {
            get { return this.MyDataRowGetItem(DLocalitati.EnumCampuriTabela.tNumeRegiune.ToString()); }
        }

        [BExport("NumeTara", true, 1)]
        public string NumeTara
        {
            get { return this.MyDataRowGetItem(DLocalitati.EnumCampuriTabela.tNumeTara.ToString()); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.LocalitatiMotivInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Localitati; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BLocalitati(int pId)
        : this(pId, null)
        {
        }

        public BLocalitati(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BLocalitati>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BLocalitati(DataRow pMyRow)
        {
            FillObjectWithDataRow<BLocalitati>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static BLocalitati getLocalitate(int lId, IDbTransaction xTrans)
        {
            if (lId <= 0)
                return null;

            if (_lDictLocalitati == null)
                _lDictLocalitati = new Dictionary<int, BLocalitati>();

            if (!_lDictLocalitati.ContainsKey(lId))
                _lDictLocalitati.Add(lId, new BLocalitati(lId, xTrans));

            return _lDictLocalitati[lId];
        }

        public static string GetDenumireLocalitate(int lId, IDbTransaction xTrans)
        {
            BLocalitati localitate = getLocalitate(lId, xTrans);

            if (localitate != null)
                return localitate.Nume;

            return string.Empty;
        }

        public static List<StructIdDenumire> GetListaCautare(int pIdRegiune, string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (pIdRegiune <= 0 || string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DLocalitati.GetListaCautare(pIdRegiune, pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nIdLocalitate"]), Convert.ToString(dr["tNume"])));
                }
            }

            return listaRetur;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DLocalitati
        /// </summary>
        /// <param name="pIdRegiune"></param>
        /// <param name="pNume"></param>
        /// <param name="pTip"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdRegiune, string pNume, int pTip, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            int id = DLocalitati.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdRegiune, pNume, pTip, pLimbaDenumirii, pPreferinta, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdRegiune, string pNume, int pTip, int pLimbaDenumirii, int pPreferinta)
        {
            return pIdRegiune != 0 && !string.IsNullOrEmpty(pNume) && pTip != 0 && pLimbaDenumirii != 0 && pPreferinta != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BLocalitati
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieLocalitati GetListByParam(int pIdRegiune, int pIdTara, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieLocalitati lstDLocalitati = new BColectieLocalitati();
            using (DataSet ds = DLocalitati.GetListByParam(pIdRegiune, pIdTara, pStare, Convert.ToInt32(BMultiLingv.EnumLimba.Romana), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDLocalitati.Add(new BLocalitati(dr));
                }
            }
            return lstDLocalitati;
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
                throw new IdentificareBazaImposibilaException("BLocalitati");
            using (DataSet ds = DLocalitati.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BLocalitati");
            }
        }

        public static BColectieLocalitati getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieLocalitati listaRetur = new BColectieLocalitati();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DLocalitati.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BLocalitati(dr));
                    }
                }
            }
            return listaRetur;
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
                bool succesModificare = DLocalitati.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return

                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.xnIdRegiune.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.tNume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nTip.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nLimbaDenumirii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nPreferinta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BLocalitati");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DLocalitati.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.xnIdRegiune.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.xnIdRegiune.ToString(), this.IdRegiune);
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.tNume.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.tNume.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nTip.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.nTip.ToString(), this.Tip);
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nLimbaDenumirii.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.nLimbaDenumirii.ToString(), this.LimbaDenumirii);
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.nPreferinta.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.nPreferinta.ToString(), this.Preferinta);
            if (this.IsMyDataRowItemHasChanged(DLocalitati.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DLocalitati.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BLocalitati");

            FillObjectWithDataRow<BLocalitati>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DLocalitati></DLocalitati>");

            //Adaugam elementele clasei BLocalitati
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDREGIUNE");
            myXmlElem.InnerText = Convert.ToString(this.IdRegiune);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIP");
            myXmlElem.InnerText = Convert.ToString(this.Tip);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("LIMBADENUMIRII");
            myXmlElem.InnerText = Convert.ToString(this.LimbaDenumirii);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PREFERINTA");
            myXmlElem.InnerText = Convert.ToString(this.Preferinta);
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

            myXmlElem = myXmlDoc.CreateElement("IDTARA");
            myXmlElem.InnerText = Convert.ToString(this.IdTara);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMEREGIUNE");
            myXmlElem.InnerText = this.NumeRegiune;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMETARA");
            myXmlElem.InnerText = this.NumeTara;
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

        public static int ComparaDupaNume(BLocalitati xElemLista1, BLocalitati xElemLista2)
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
                    return xElemLista1.Nume.CompareTo(xElemLista2.Nume);
            }
        }

        #endregion //Metode de comparatie

    }

}