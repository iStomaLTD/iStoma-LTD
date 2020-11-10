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
    /// Clasa pentru gestionarea regiunilor/judetelor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BRegiuni : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BRegiuni> _lDictRegiuni = new Dictionary<int, BRegiuni>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumeMaxLength = 50;
            public const int AbreviereMaxLength = 10;
            public const int PrefixTelefonMaxLength = 10;
            public const int MotivInchidereMaxLength = 250;
            public const int NumeTaraMaxLength = 60;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DRegiuni.EnumCampuriTabela.nIdRegiune.ToString()); }
        }

        [BExport("IdTara", true, 1)]
        public int IdTara
        {
            get { return this.MyDataRowGetItemAsInteger(DRegiuni.EnumCampuriTabela.xnIdTara.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.xnIdTara.ToString(), value); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DRegiuni.EnumCampuriTabela.tNume.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.tNume.ToString(), value); }
        }

        [BExport("Abreviere", true, 1)]
        public string Abreviere
        {
            get { return this.MyDataRowGetItem(DRegiuni.EnumCampuriTabela.tAbreviere.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.tAbreviere.ToString(), value); }
        }

        [BExport("PrefixTelefon", true, 1)]
        public string PrefixTelefon
        {
            get { return this.MyDataRowGetItem(DRegiuni.EnumCampuriTabela.tPrefixTelefon.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.tPrefixTelefon.ToString(), value); }
        }

        [BExport("LimbaDenumirii", true, 1)]
        public int LimbaDenumirii
        {
            get { return this.MyDataRowGetItemAsInteger(DRegiuni.EnumCampuriTabela.nLimbaDenumirii.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.nLimbaDenumirii.ToString(), value); }
        }

        [BExport("Preferinta", true, 1)]
        public int Preferinta
        {
            get { return this.MyDataRowGetItemAsInteger(DRegiuni.EnumCampuriTabela.nPreferinta.ToString()); }
            set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.nPreferinta.ToString(), value); }
        }
       //lore
      [BExport("NumeTara", true, 1)]
        public string NumeTara
        {
            get { return this.MyDataRowGetItem(DRegiuni.EnumCampuriTabela.tNumeTara.ToString()); }
           // set { this.MyDataRowSetItem(DRegiuni.EnumCampuriTabela.tNumeTara.ToString(), value); }  //oare
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.RegiuniMotivInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Regiuni; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BRegiuni(int pId)
        : this(pId, null)
        {
        }

        public BRegiuni(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BRegiuni>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BRegiuni(DataRow pMyRow)
        {
            FillObjectWithDataRow<BRegiuni>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static BRegiuni getRegiune(int lId, IDbTransaction xTrans)
        {
            if (lId <= 0) return null;

            if (_lDictRegiuni == null)
                _lDictRegiuni = new Dictionary<int, BRegiuni>();

            if (!_lDictRegiuni.ContainsKey(lId))
                _lDictRegiuni.Add(lId, new BRegiuni(lId, xTrans));

            return _lDictRegiuni[lId];
        }

        public static string GetDenumireRegiune(int pId, IDbTransaction pTranzactie)
        {
            BRegiuni reg = getRegiune(pId, pTranzactie);

            if (reg != null)
                return reg.Nume;

            return string.Empty;
        }

        public static List<StructIdDenumire> GetListaCautare(int pIdTara, string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (pIdTara <= 0 || string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DRegiuni.GetListaCautare(pIdTara, pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), Convert.ToInt32(BMultiLingv.EnumLimba.Romana), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr[DRegiuni.EnumCampuriTabela.nIdRegiune.ToString()]), Convert.ToString(dr[DRegiuni.EnumCampuriTabela.tNume.ToString()])));
                }
            }

            return listaRetur;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DRegiuni
        /// </summary>
        /// <param name="pIdTara"></param>
        /// <param name="pNume"></param>
        /// <param name="pAbreviere"></param>
        /// <param name="pPrefixTelefon"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdTara, string pNume, string pAbreviere, string pPrefixTelefon, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            int id = DRegiuni.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdTara, pNume, pAbreviere, pPrefixTelefon, pLimbaDenumirii, pPreferinta, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdTara, string pNume)
        {
            return pIdTara != 0 && !string.IsNullOrEmpty(pNume);
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BRegiuni
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieRegiuni GetListByParam(int pIdTara, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieRegiuni lstDRegiuni = new BColectieRegiuni();
            using (DataSet ds = DRegiuni.GetListByParam(pIdTara, pStare, Convert.ToInt32(BMultiLingv.EnumLimba.Romana), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDRegiuni.Add(new BRegiuni(dr));
                }
            }
            return lstDRegiuni;
        }

        public static List<string> GetListNumeRegiuni(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            List<string> lstRegiuni = new List<string>();
            foreach (BRegiuni regiune in GetListByParam(0, CDefinitiiComune.EnumStare.Activa, null))
            {
                lstRegiuni.Add(regiune.Nume);
            }

            return lstRegiuni;
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
                throw new IdentificareBazaImposibilaException("BRegiuni");
            using (DataSet ds = DRegiuni.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BRegiuni");
            }
        }

        public static BColectieRegiuni getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieRegiuni listaRetur = new BColectieRegiuni();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DRegiuni.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BRegiuni(dr));
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
                bool succesModificare = DRegiuni.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.xnIdTara.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tNume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tAbreviere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tPrefixTelefon.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.nLimbaDenumirii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.nPreferinta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BRegiuni");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DRegiuni.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.xnIdTara.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.xnIdTara.ToString(), this.IdTara);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tNume.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.tNume.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tAbreviere.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.tAbreviere.ToString(), this.Abreviere);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tPrefixTelefon.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.tPrefixTelefon.ToString(), this.PrefixTelefon);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.nLimbaDenumirii.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.nLimbaDenumirii.ToString(), this.LimbaDenumirii);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.nPreferinta.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.nPreferinta.ToString(), this.Preferinta);
            if (this.IsMyDataRowItemHasChanged(DRegiuni.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DRegiuni.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BRegiuni");

            FillObjectWithDataRow<BRegiuni>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DRegiuni></DRegiuni>");

            //Adaugam elementele clasei BRegiuni
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDTARA");
            myXmlElem.InnerText = Convert.ToString(this.IdTara);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ABREVIERE");
            myXmlElem.InnerText = this.Abreviere;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PREFIXTELEFON");
            myXmlElem.InnerText = this.PrefixTelefon;
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

        public static int ComparaDupaNume(BRegiuni xElemLista1, BRegiuni xElemLista2)
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