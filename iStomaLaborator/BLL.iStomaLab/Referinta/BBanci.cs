using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Referinta;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Referinta
{
    [Serializable()]
    public sealed class BBanci : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {
        #region Declaratii generale

        private static BColectieBanci _lstBanci = null;
        private static Dictionary<int, BBanci> _lDictBanci = new Dictionary<int, BBanci>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 50;
            public const int InformatiiComplementareMaxLength = 2000;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DBanci.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DBanci.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DBanci.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("InformatiiComplementare", true, 1)]
        public string InformatiiComplementare
        {
            get { return this.MyDataRowGetItem(DBanci.EnumCampuriTabela.tInformatiiComplementare.ToString()); }
            set { this.MyDataRowSetItem(DBanci.EnumCampuriTabela.tInformatiiComplementare.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.BanciMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Banci; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BBanci(int pId)
        : this(pId, null)
        {
        }

        public BBanci(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BBanci>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BBanci(DataRow pMyRow)
        {
            FillObjectWithDataRow<BBanci>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static BBanci getBanca(int lId, IDbTransaction xTrans)
        {
            if (lId <= 0) return null;

            if (_lDictBanci == null)
                _lDictBanci = new Dictionary<int, BBanci>();

            if (!_lDictBanci.ContainsKey(lId))
                _lDictBanci.Add(lId, new BBanci(lId, xTrans));

            return _lDictBanci[lId];
        }

        public static string GetDenumireBanca(int lId, IDbTransaction xTrans)
        {
            BBanci tara = getBanca(lId, xTrans);

            if (tara != null)
                return tara.Denumire;

            return string.Empty;
        }

        public static List<StructIdDenumire> GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DBanci.GetListaCautare(pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nId"]), Convert.ToString(dr["tDenumire"])));
                }
            }

            return listaRetur;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DBanci
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pInformatiiComplementare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, string pInformatiiComplementare, IDbTransaction pTranzactie)
        {
            int id = DBanci.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pInformatiiComplementare, pTranzactie);

            _lstBanci = null;

            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BBanci
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieBanci GetListByParam(
        CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieBanci lstDBanci = new BColectieBanci();
            using (DataSet ds = DBanci.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDBanci.Add(new BBanci(dr));
                }
            }
            return lstDBanci;
        }

        public static List<string> getListaBanciDenumire()
        {
            List<string> lstBanci = new List<string>();
            foreach (BBanci banca in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstBanci.Add(banca.Denumire);
            }

            return lstBanci;
        }

        public static List<int> getListaBanciId()
        {
            List<int> lstBanci = new List<int>();
            foreach (BBanci banca in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstBanci.Add(banca.Id);
            }

            return lstBanci;
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
                throw new IdentificareBazaImposibilaException("BBanci");
            using (DataSet ds = DBanci.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BBanci");
            }
        }

        public static BColectieBanci getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieBanci listaRetur = new BColectieBanci();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DBanci.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BBanci(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static void DistrugeListaTari()
        {
            _lstBanci = null;
            _lDictBanci = null;
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
                bool succesModificare = DBanci.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tInformatiiComplementare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BBanci");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DBanci.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DBanci.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tInformatiiComplementare.ToString()))
                dictRezultat.Adauga(DBanci.EnumCampuriTabela.tInformatiiComplementare.ToString(), this.InformatiiComplementare);
            if (this.IsMyDataRowItemHasChanged(DBanci.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DBanci.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BBanci");

            FillObjectWithDataRow<BBanci>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DBanci></DBanci>");

            //Adaugam elementele clasei BBanci
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

            myXmlElem = myXmlDoc.CreateElement("INFORMATIICOMPLEMENTARE");
            myXmlElem.InnerText = this.InformatiiComplementare;
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
