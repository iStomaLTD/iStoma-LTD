using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using ILL.iStomaLab;
using CCL.DAL;
using DAL.iStomaLab.Referinta;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;

namespace BLL.iStomaLab.Referinta
{
    /// <summary>
    /// Clasa pentru gestionarea tarilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BTari : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static BColectieTari _lstTari = null;
        private static Dictionary<int, BTari> _lDictTari = new Dictionary<int, BTari>();

        public const int ConstIDRomania = 79;
        public const int ConstIDMoldova = 56;

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumeScurtMaxLength = 60;
            public const int NumeOficialMaxLength = 100;
            public const int PrefixTelefonicMaxLength = 10;
            public const int AbreviereMaxLength = 4;
            public const int CetatenieMaxLength = 50;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DTari.EnumCampuriTabela.nIdTara.ToString()); }
        }

        [BExport("NumeScurt", true, 1)]
        public string NumeScurt
        {
            get { return this.MyDataRowGetItem(DTari.EnumCampuriTabela.tNumeScurt.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.tNumeScurt.ToString(), value); }
        }

        [BExport("NumeOficial", true, 1)]
        public string NumeOficial
        {
            get { return this.MyDataRowGetItem(DTari.EnumCampuriTabela.tNumeOficial.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.tNumeOficial.ToString(), value); }
        }

        [BExport("PrefixTelefonic", true, 1)]
        public string PrefixTelefonic
        {
            get { return this.MyDataRowGetItem(DTari.EnumCampuriTabela.tPrefixTelefonic.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.tPrefixTelefonic.ToString(), value); }
        }

        [BExport("Abreviere", true, 1)]
        public string Abreviere
        {
            get { return this.MyDataRowGetItem(DTari.EnumCampuriTabela.tAbreviere.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.tAbreviere.ToString(), value); }
        }

        [BExport("Cetatenie", true, 1)]
        public string Cetatenie
        {
            get { return this.MyDataRowGetItem(DTari.EnumCampuriTabela.tCetatenie.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.tCetatenie.ToString(), value); }
        }

        [BExport("LimbaDenumirii", true, 1)]
        public int LimbaDenumirii
        {
            get { return this.MyDataRowGetItemAsInteger(DTari.EnumCampuriTabela.nLimbaDenumirii.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.nLimbaDenumirii.ToString(), value); }
        }

        [BExport("Preferinta", true, 1)]
        public int Preferinta
        {
            get { return this.MyDataRowGetItemAsInteger(DTari.EnumCampuriTabela.nPreferinta.ToString()); }
            set { this.MyDataRowSetItem(DTari.EnumCampuriTabela.nPreferinta.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.TariMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Tari; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BTari(int pId)
        : this(pId, null)
        {
        }

        public BTari(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BTari>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BTari(DataRow pMyRow)
        {
            FillObjectWithDataRow<BTari>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static BTari getTara(int lId, IDbTransaction xTrans)
        {
            if (lId <= 0) return null;

            if (_lDictTari == null)
                _lDictTari = new Dictionary<int, BTari>();

            if (!_lDictTari.ContainsKey(lId))
                _lDictTari.Add(lId, new BTari(lId, xTrans));

            return _lDictTari[lId];
        }

        public static string GetDenumireTara(int lId, IDbTransaction xTrans)
        {
            BTari tara = getTara(lId, xTrans);

            if (tara != null)
                return tara.NumeScurt;

            return string.Empty;
        }

        public static List<StructIdDenumire> GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DTari.GetListaCautare(pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), Convert.ToInt32(BMultiLingv.EnumLimba.Romana), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr[DTari.EnumCampuriTabela.nIdTara.ToString()]), Convert.ToString(dr[DTari.EnumCampuriTabela.tNumeScurt.ToString()])));
                }
            }

            return listaRetur;
        }


        public static int Add(string pNumeScurt, IDbTransaction pTranzactie)
        {
            return Add(pNumeScurt, pNumeScurt, string.Empty, CUtil.GetPrescurtareText(pNumeScurt, 2), pNumeScurt, 1, 1, pTranzactie);
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DTari
        /// </summary>
        /// <param name="pNumeScurt"></param>
        /// <param name="pNumeOficial"></param>
        /// <param name="pPrefixTelefonic"></param>
        /// <param name="pAbreviere"></param>
        /// <param name="pCetatenie"></param>
        /// <param name="pLimbaDenumirii"></param>
        /// <param name="pPreferinta"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pNumeScurt, string pNumeOficial, string pPrefixTelefonic, string pAbreviere, string pCetatenie, int pLimbaDenumirii, int pPreferinta, IDbTransaction pTranzactie)
        {
            int id = DTari.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pNumeScurt, pNumeOficial, pPrefixTelefonic, pAbreviere, pCetatenie, pLimbaDenumirii, pPreferinta, pTranzactie);

            _lstTari = null;

            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pNumeScurt, int pLimbaDenumirii)
        {
            return !string.IsNullOrEmpty(pNumeScurt) && pLimbaDenumirii == 0;
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BTari
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieTari GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieTari lstDTari = new BColectieTari();
            using (DataSet ds = DTari.GetListByParam(pStare, Convert.ToInt32(BMultiLingv.EnumLimba.Romana), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDTari.Add(new BTari(dr));
                }
            }
            return lstDTari;
        }

        public static List<string> getListaTariNume()
        {
            List<string> lstTari = new List<string>();
            foreach (BTari pTara in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstTari.Add(pTara.NumeScurt);
            }

            return lstTari;
        }

        public static List<int> getListaTariId()
        {
            List<int> lstTari = new List<int>();
            foreach (BTari pTara in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstTari.Add(pTara.Id);
            }

            return lstTari;
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
                throw new IdentificareBazaImposibilaException("BTari");
            using (DataSet ds = DTari.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BTari");
            }
        }

        public static BColectieTari getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieTari listaRetur = new BColectieTari();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DTari.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BTari(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static void DistrugeListaTari()
        {
            _lstTari = null;
            _lDictTari = null;
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
                bool succesModificare = DTari.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tNumeScurt.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tNumeOficial.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tPrefixTelefonic.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tAbreviere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tCetatenie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.nLimbaDenumirii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.nPreferinta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BTari");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DTari.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tNumeScurt.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tNumeScurt.ToString(), this.NumeScurt);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tNumeOficial.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tNumeOficial.ToString(), this.NumeOficial);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tPrefixTelefonic.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tPrefixTelefonic.ToString(), this.PrefixTelefonic);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tAbreviere.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tAbreviere.ToString(), this.Abreviere);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tCetatenie.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tCetatenie.ToString(), this.Cetatenie);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.nLimbaDenumirii.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.nLimbaDenumirii.ToString(), this.LimbaDenumirii);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.nPreferinta.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.nPreferinta.ToString(), this.Preferinta);
            if (this.IsMyDataRowItemHasChanged(DTari.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DTari.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BTari");

            FillObjectWithDataRow<BTari>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DTari></DTari>");

            //Adaugam elementele clasei BTari
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMESCURT");
            myXmlElem.InnerText = this.NumeScurt;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMEOFICIAL");
            myXmlElem.InnerText = this.NumeOficial;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PREFIXTELEFONIC");
            myXmlElem.InnerText = this.PrefixTelefonic;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ABREVIERE");
            myXmlElem.InnerText = this.Abreviere;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CETATENIE");
            myXmlElem.InnerText = this.Cetatenie;
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