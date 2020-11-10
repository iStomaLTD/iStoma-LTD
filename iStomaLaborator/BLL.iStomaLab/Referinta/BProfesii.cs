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
    /// Clasa pentru gestionarea profesiilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BProfesii : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BProfesii> _lDictProfesii = new Dictionary<int, BProfesii>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 100;
            public const int MotivInchidereMaxLength = 500;
            public const int CodCORMaxLength = 10;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DProfesii.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DProfesii.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DProfesii.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("CodCOR", true, 1)]
        public string CodCOR
        {
            get { return this.MyDataRowGetItem(DProfesii.EnumCampuriTabela.tCodCOR.ToString()); }
            set { this.MyDataRowSetItem(DProfesii.EnumCampuriTabela.tCodCOR.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ProfesiiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Profesii; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BProfesii(int pId)
        : this(pId, null)
        {
        }

        public BProfesii(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BProfesii>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BProfesii(DataRow pMyRow)
        {
            FillObjectWithDataRow<BProfesii>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static BProfesii getProfesie(int lId, IDbTransaction xTrans)
        {
            if (_lDictProfesii == null)
                _lDictProfesii = new Dictionary<int, BProfesii>();

            if (!_lDictProfesii.ContainsKey(lId))
                _lDictProfesii.Add(lId, new BProfesii(lId, xTrans));

            return _lDictProfesii[lId];
        }

        public static List<StructIdDenumire> GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DProfesii.GetListaCautare(pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nId"]), Convert.ToString(dr["tDenumire"])));
                }
            }

            return listaRetur;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DProfesii
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pCodCOR"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, string pCodCOR, IDbTransaction pTranzactie)
        {
            int id = DProfesii.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pCodCOR, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BProfesii
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieProfesii GetListByParam(
        CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieProfesii lstDProfesii = new BColectieProfesii();
            using (DataSet ds = DProfesii.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDProfesii.Add(new BProfesii(dr));
                }
            }
            return lstDProfesii;
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
                throw new IdentificareBazaImposibilaException("BProfesii");
            using (DataSet ds = DProfesii.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BProfesii");
            }
        }

        public static BColectieProfesii getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieProfesii listaRetur = new BColectieProfesii();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DProfesii.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BProfesii(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static List<string> getListaProfesiiDenumire()
        {
            List<string> lstProfesii = new List<string>();
            foreach (BProfesii profesie in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstProfesii.Add(profesie.Denumire);
            }

            return lstProfesii;
        }

        public static void DistrugeListaTari()
        {
            _lDictProfesii = null;
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
                bool succesModificare = DProfesii.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tCodCOR.ToString());
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
                throw new IdentificareBazaImposibilaException("BProfesii");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DProfesii.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DProfesii.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DProfesii.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DProfesii.EnumCampuriTabela.tCodCOR.ToString()))
                dictRezultat.Adauga(DProfesii.EnumCampuriTabela.tCodCOR.ToString(), this.CodCOR);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BProfesii");

            FillObjectWithDataRow<BProfesii>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DProfesii></DProfesii>");

            //Adaugam elementele clasei BProfesii
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
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

            myXmlElem = myXmlDoc.CreateElement("CODCOR");
            myXmlElem.InnerText = this.CodCOR;
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

        public static int ComparaDupaNume(BProfesii xElemLista1, BProfesii xElemLista2)
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