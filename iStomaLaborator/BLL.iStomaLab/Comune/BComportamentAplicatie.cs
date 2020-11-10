using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Comune;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{   /// <summary>
    /// Clasa pentru gestionarea comportamentului aplicatiei
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BComportamentAplicatie : BGestiuneCMI, IDisposable
    {
        public static CDL.iStomaLab.CStructuriComune.StructPaletaDGV GetPaletaCuloriDGV()
        {
            return CDL.iStomaLab.CStructuriComune.StructPaletaDGV.Empty;
        }

        #region Declaratii generale

        private static Dictionary<EnumComportamentAplicatie, string> _lDictParametrii = null;// new Dictionary<EnumComportamentAplicatie, BComportamentAplicatie>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        public enum EnumComportamentAplicatie
        {
            Nedefinit = 0,
            ArataCategoriileInEcranulLucrari = 1,
            ArataZonaAdaugareComandaRapida = 2,
            TablouDeBord_DataInteres = 3,
            SeFolosesteCursBNRSetatDeUser = 4,
            CursBNRLeuEur = 5
        }

        public enum Enum_TablouDeBord_DataInteres
        {
            DataCreare = 1,
            DataPrimire = 2,
            DataLaGata = 3,
            DataTermen = 4,
            DataInceput= 5,
            DataFinal = 6
        }

        #region StructCampuriTabela

        public struct StructComportamentAplicatie
        {
            public EnumComportamentAplicatie Id { get; set; }
            public string Denumire { get; set; }

            public StructComportamentAplicatie(EnumComportamentAplicatie pId, string pDenumire) : this()
            {
                this.Id = pId;
                this.Denumire = pDenumire;
            }

            public override bool Equals(object obj)
            {
                if (obj is int || obj is EnumComportamentAplicatie)
                    return this.Id.Equals((EnumComportamentAplicatie)CUtil.GetAsInt32(obj));
                else if (obj is StructComportamentAplicatie)
                    return this.Id.Equals((StructComportamentAplicatie)obj);
                return base.Equals(obj);
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructComportamentAplicatie GetStructById(EnumComportamentAplicatie pId)
            {
                switch (pId)
                {
                    case EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari:
                        return new StructComportamentAplicatie(pId, string.Empty);
                }
                return new StructComportamentAplicatie(pId, string.Empty);
            }

            public static List<StructComportamentAplicatie> GetList()
            {
                List<StructComportamentAplicatie> lstRetur = new List<StructComportamentAplicatie>();

                lstRetur.Add(GetStructById(EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari));

                return lstRetur;
            }
        }

        public struct StructCampuriTabela
        {

        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public EnumComportamentAplicatie Id
        {
            get { return (EnumComportamentAplicatie)this.MyDataRowGetItemAsIntegerNull(DComportamentAplicatie.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Valoare", true, 1)]
        public string Valoare
        {
            get { return this.MyDataRowGetItem(DComportamentAplicatie.EnumCampuriTabela.tValoare.ToString()); }
            set { this.MyDataRowSetItem(DComportamentAplicatie.EnumCampuriTabela.tValoare.ToString(), value); }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ComportamentAplicatie; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BComportamentAplicatie(int pId)
        : this(pId, null)
        {
        }

        public BComportamentAplicatie(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BComportamentAplicatie>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BComportamentAplicatie(DataRow pMyRow)
        {
            FillObjectWithDataRow<BComportamentAplicatie>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        #region Tablou de bord

        public static void TablouDeBord_SetDataInteres(Enum_TablouDeBord_DataInteres pDataInteres)
        {
            Add(EnumComportamentAplicatie.TablouDeBord_DataInteres, Convert.ToString(Convert.ToInt32(pDataInteres)), null);
        }

        public static Enum_TablouDeBord_DataInteres TablouDeBord_GetDataInteres()
        {
            if (ExistaComportament(EnumComportamentAplicatie.TablouDeBord_DataInteres, null))
            {
                return (Enum_TablouDeBord_DataInteres)Convert.ToInt32(_lDictParametrii[EnumComportamentAplicatie.TablouDeBord_DataInteres]);
            }

            return Enum_TablouDeBord_DataInteres.DataPrimire;
        }

        #endregion

        #region Curs BNR

        public static double GetCursBNR()
        {
            SetCursBNR();

            string val = GetValoareComportament(EnumComportamentAplicatie.CursBNRLeuEur);

            int nrZecimale = 0;

            if (val.Contains("."))
            {
                nrZecimale = val.Length - (val.IndexOf(".") + 1);
                val = val.Replace(".", "");
            }

            if (val.Contains(","))
            {
                nrZecimale = val.Length - (val.IndexOf(",") + 1);
                val = val.Replace(",", "");
            }

            double valDbl = 0;
            if (double.TryParse(val, out valDbl))
            {
                if (nrZecimale > 0)
                    return valDbl / Math.Pow(10, nrZecimale);
                return valDbl;
            }

            return 466 / 100;
        }

        public static void SetCursBNR()
        {
            if (!GetSeFolosesteCursBNRSetatDeUser())
            {
                double curs = BDefinitiiGenerale.getCursLeuEur(null);
                SetCursBNR(curs);
            }
        }

        public static void SetCursBNR(double pCursBNR)
        {
            Add(EnumComportamentAplicatie.CursBNRLeuEur, Convert.ToString(pCursBNR), null);
        }

        public static bool GetSeFolosesteCursBNRSetatDeUser()
        {
            if (ExistaComportament(EnumComportamentAplicatie.SeFolosesteCursBNRSetatDeUser, null))
            {
                string folCursBNRpropriu = GetValoareComportament(EnumComportamentAplicatie.SeFolosesteCursBNRSetatDeUser);
                if (!string.IsNullOrEmpty(folCursBNRpropriu))
                {
                    return Convert.ToBoolean(folCursBNRpropriu);
                }
            }

            return false;
        }

        public static void SetSeFolosesteCursBNRSetatDeUser(bool pAdevarat)
        {
            Add(EnumComportamentAplicatie.SeFolosesteCursBNRSetatDeUser, Convert.ToString(pAdevarat), null);
        }

        #endregion

        public static string GetValoareComportament(EnumComportamentAplicatie pIdComportament)
        {
            if (ExistaComportament(pIdComportament, null))
                return _lDictParametrii[pIdComportament];

            return string.Empty;
        }

        private static bool ExistaComportament(EnumComportamentAplicatie pId, IDbTransaction pTranzactie)
        {
            initDict(pTranzactie);

            return _lDictParametrii.ContainsKey(pId);
        }

        private static void initDict(IDbTransaction pTranzactie)
        {
            if (_lDictParametrii == null)
            {
                _lDictParametrii = new Dictionary<Comune.BComportamentAplicatie.EnumComportamentAplicatie, string>();

                BColectieComportamentAplicatie listaComp = GetListByParam(pTranzactie);

                foreach (var item in listaComp)
                {
                    if (!_lDictParametrii.ContainsKey(item.Id))
                        _lDictParametrii.Add(item.Id, item.Valoare);
                }
            }
        }

        public static void DistrugeDictionarul()
        {
            _lDictParametrii = null;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DComportamentAplicatie
        /// </summary>
        /// <param name="pValoare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static void Add(BComportamentAplicatie.EnumComportamentAplicatie pComportament, string pValoare, IDbTransaction pTranzactie)
        {
            if (ExistaComportament(pComportament, pTranzactie))
                DComportamentAplicatie.UpdateComportament(Convert.ToInt32(pComportament), pValoare, pTranzactie);
            else
                DComportamentAplicatie.Add(Convert.ToInt32(pComportament), pValoare, pTranzactie);

            DistrugeDictionarul();

            //int id = DComportamentAplicatie.Add(CUtil.GetAsInt32(pComportament), pValoare, pTranzactie);
            //return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pTipLista)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BComportamentAplicatie
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieComportamentAplicatie GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieComportamentAplicatie lstDComportamentAplicatie = new BColectieComportamentAplicatie();
            using (DataSet ds = DComportamentAplicatie.GetListByParam(0, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDComportamentAplicatie.Add(new BComportamentAplicatie(dr));
                }
            }
            return lstDComportamentAplicatie;
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
                throw new IdentificareBazaImposibilaException("BComportamentAplicatie");
            using (DataSet ds = DComportamentAplicatie.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BComportamentAplicatie");
            }
        }

        public static void SetArataCategoriileInEcranulLucrari(bool pValoare)
        {
            Add(EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari, Convert.ToString(pValoare), null);
        }

        public static bool GetArataCategoriileInEcranulLucrari()
        {
            if (ExistaComportament(EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari, null))
            {
                return Convert.ToBoolean(_lDictParametrii[EnumComportamentAplicatie.ArataCategoriileInEcranulLucrari]);
            }

            return true;
        }

        public static void SetArataZonaAdaugareComandaRapida(bool pValoare)
        {
            Add(EnumComportamentAplicatie.ArataZonaAdaugareComandaRapida, Convert.ToString(pValoare), null);
        }

        public static bool GetArataZonaAdaugareComandaRapida()
        {
            if (ExistaComportament(EnumComportamentAplicatie.ArataZonaAdaugareComandaRapida, null))
            {
                return Convert.ToBoolean(_lDictParametrii[EnumComportamentAplicatie.ArataZonaAdaugareComandaRapida]);
            }

            return true;
        }

        #endregion //Metode de clasa

        #region Metode de instanta


        public static void SetAsBool(EnumComportamentAplicatie pComportamentAsociat, bool pSelectat)
        {
            BComportamentAplicatie.Add(pComportamentAsociat, Convert.ToString(pSelectat), null);
        }

        public static bool GetAsBool(EnumComportamentAplicatie pComportamentAsociat, bool pDefaultValue)
        {
            if (ExistaComportament(pComportamentAsociat, null))
                return Convert.ToBoolean(_lDictParametrii[pComportamentAsociat]);
            return pDefaultValue;
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
                bool succesModificare = true;// DComportamentAplicatie.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
                //NU FACE SENS AICI
                //this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return this.IsMyDataRowItemHasChanged(DComportamentAplicatie.EnumCampuriTabela.tValoare.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DComportamentAplicatie.EnumCampuriTabela.tValoare.ToString()))
                dictRezultat.Adauga(DComportamentAplicatie.EnumCampuriTabela.tValoare.ToString(), this.Valoare);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BComportamentAplicatie");

            FillObjectWithDataRow<BComportamentAplicatie>(GetDataRowForObjet(Convert.ToInt32(this.Id), pTranzactie), this);
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
            myXmlDoc.LoadXml("<DComportamentAplicatie></DComportamentAplicatie>");

            //Adaugam elementele clasei BComportamentAplicatie
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOARE");
            myXmlElem.InnerText = this.Valoare;
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

        public static int ComparaDupaNume(BComportamentAplicatie xElemLista1, BComportamentAplicatie xElemLista2)
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
                    return xElemLista1.Valoare.CompareTo(xElemLista2.Valoare);
            }
        }

        #endregion //Metode de comparatie
    }
}
