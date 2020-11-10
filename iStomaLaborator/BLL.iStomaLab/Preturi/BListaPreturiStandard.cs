using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Preturi;
using ILL.General.Interfete;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using ILL.iStomaLab;
using DAL.iStomaLab.Referinta;
using BLL.iStomaLab.Referinta;

namespace BLL.iStomaLab.Preturi
{
    /// <summary>
    /// Clasa pentru gestionarea listei de preturi standard
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BListaPreturiStandard : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 250;
            public const int DenumirePrescurtataMaxLength = 50;
            public const int CodInternMaxLength = 10;
            public const int MotivInchidereMaxLength = 500;
            public const int DenumireCategorieMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DListaPreturiStandard.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DListaPreturiStandard.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("DenumirePrescurtata", true, 1)]
        public string DenumirePrescurtata
        {
            get { return this.MyDataRowGetItem(DListaPreturiStandard.EnumCampuriTabela.tDenumirePrescurtata.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.tDenumirePrescurtata.ToString(), value); }
        }

        [BExport("CodIntern", true, 1)]
        public string CodIntern
        {
            get { return this.MyDataRowGetItem(DListaPreturiStandard.EnumCampuriTabela.tCodIntern.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.tCodIntern.ToString(), value); }
        }

        [BExport("TermenMediuZile", true, 1)]
        public int TermenMediuZile
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DListaPreturiStandard.EnumCampuriTabela.nTermenMediuZile.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.nTermenMediuZile.ToString(), value); }
        }

        [BExport("IdCategorie", true, 1)]
        public int IdCategorie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DListaPreturiStandard.EnumCampuriTabela.xnIdCategorie.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.xnIdCategorie.ToString(), value); }
        }

        [BExport("ValoareRON", true, 1)]
        public double ValoareRON
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiStandard.EnumCampuriTabela.nValoareRON.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.nValoareRON.ToString(), value); }
        }

        [BExport("ValoareEUR", true, 1)]
        public double ValoareEUR
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiStandard.EnumCampuriTabela.nValoareEUR.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiStandard.EnumCampuriTabela.nValoareEUR.ToString(), value); }
        }

        [BExport("DenumireCategorie", true, 1)]
        public string DenumireCategorie
        {
            get { return this.MyDataRowGetItem(DListaPreturiStandard.EnumCampuriTabela.tDenumireCategorie.ToString()); }
        }

        [BExport("Culoare", true, 1)]
        public int Culoare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DListaPreturiStandard.EnumCampuriTabela.nCuloare.ToString()); }
        }
        
        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ListaPreturiStandardMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ListaPreturiStandard; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BListaPreturiStandard(int pId)
        : this(pId, null)
        {
        }

        public BListaPreturiStandard(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BListaPreturiStandard>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BListaPreturiStandard(DataRow pMyRow)
        {
            FillObjectWithDataRow<BListaPreturiStandard>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DListaPreturiStandard
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pDenumirePrescurtata"></param>
        /// <param name="pCodIntern"></param>
        /// <param name="pTermenMediuZile"></param>
        /// <param name="pIdCategorie"></param>
        /// <param name="pValoareRON"></param>
        /// <param name="pValoareEUR"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, string pDenumirePrescurtata, string pCodIntern, int pTermenMediuZile, int pIdCategorie, double pValoareRON, double pValoareEUR, IDbTransaction pTranzactie)
        {
            int id = DListaPreturiStandard.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pDenumirePrescurtata, pCodIntern, pTermenMediuZile, pIdCategorie, pValoareRON, pValoareEUR, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BListaPreturiStandard
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieListaPreturiStandard GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiStandard lstDListaPreturiStandard = new BColectieListaPreturiStandard();
            using (DataSet ds = DListaPreturiStandard.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiStandard.Add(new BListaPreturiStandard(dr));
                }
            }
            return lstDListaPreturiStandard;
        }

        public static BColectieListaPreturiStandard GetListByParamIdCategorie(int pIdCategorie, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiStandard lstDListaPreturiStandard = new BColectieListaPreturiStandard();
            using (DataSet ds = DListaPreturiStandard.GetListByParamIdCategorie(pIdCategorie, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiStandard.Add(new BListaPreturiStandard(dr));
                }
            }
            return lstDListaPreturiStandard;
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
                throw new IdentificareBazaImposibilaException("BListaPreturiStandard");
            using (DataSet ds = DListaPreturiStandard.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BListaPreturiStandard");
            }
        }

        public static BColectieListaPreturiStandard getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiStandard listaRetur = new BColectieListaPreturiStandard();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DListaPreturiStandard.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BListaPreturiStandard(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieListaPreturiStandard getByListaIdCategorii(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiStandard listaRetur = new BColectieListaPreturiStandard();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DListaPreturiStandard.GetByListIdCategorii(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BListaPreturiStandard(dr));
                    }
                }
            }
            return listaRetur;
        }
        
        public static BListaPreturiStandard getById(int pId, IDbTransaction pTranzactie)
        {
            return new BListaPreturiStandard(pId, pTranzactie);
        }

        public static int getByIdSubcategorie(int pId)
        {
            int idCategorie = 0;

            using (DataSet ds = DCategorii.GetById(pId, null))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idCategorie = new BListaPreturiStandard(dr).IdCategorie;
                }
            }
            return idCategorie;
        }

        public static int getByIdCategorie(int pId, IDbTransaction pTranzactie)
        {
            int idCategorie = 0;

            using (DataSet ds = DCategorii.GetById(pId, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idCategorie = new BCategorii(dr).IdCategorie;
                    if (idCategorie == 0)
                    {
                        idCategorie = new BCategorii(dr).Id;
                    }
                }
            }
            return idCategorie;
        }

        public static int getByIdSubcategorie(int pId, IDbTransaction pTranzactie)
        {
            int idCategorie = 0;

            using (DataSet ds = DCategorii.GetById(pId, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idCategorie = new BCategorii(dr).IdCategorie;

                }
            }
            return idCategorie;
        }

        public static List<StructIdDenumire> GetListaCautare(string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DListaPreturiStandard.GetListaCautare(pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nId"]), Convert.ToString(dr["tDenumire"])));
                }
            }

            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public double GetValoare()
        {
            if (GetMoneda() == CDefinitiiComune.EnumTipMoneda.Lei)
                return this.ValoareRON;

            return this.ValoareEUR;
        }

        public CDefinitiiComune.EnumTipMoneda GetMoneda()
        {
            if (this.ValoareEUR > 0)
                return CDefinitiiComune.EnumTipMoneda.Euro;

            return CDefinitiiComune.EnumTipMoneda.Lei;
        }

        public int GetIdMoneda()
        {
            if (this.ValoareEUR > 0)
                return CStructuriComune.StructTipMoneda.GetStructByEnum(CDefinitiiComune.EnumTipMoneda.Euro).IdInt;

            return CStructuriComune.StructTipMoneda.GetStructByEnum(CDefinitiiComune.EnumTipMoneda.Lei).IdInt;
        }

        public string GetEtichetaMoneda()
        {
            return CStructuriComune.StructTipMoneda.GetStringByEnum(GetMoneda());
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
                bool succesModificare = DListaPreturiStandard.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

        public string GetEtichetaEuro()
        {
            if (this.ValoareEUR == 0 && this.ValoareRON == 0)
                return string.Empty;
            if (this.ValoareEUR != 0)
                return CUtil.GetValoareMonetara(this.ValoareEUR);
            return string.Empty;
        }

        public string GetEtichetaRon()
        {
            if (this.ValoareEUR == 0 && this.ValoareRON == 0)
                return "0";
            if (this.ValoareRON != 0)
                return CUtil.GetValoareMonetara(this.ValoareRON);
            return string.Empty;

        }

        public bool ExistaProprietatiModificate()
        {
            return this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tDenumirePrescurtata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tCodIntern.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nTermenMediuZile.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.xnIdCategorie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nValoareRON.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nValoareEUR.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BListaPreturiStandard");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DListaPreturiStandard.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tDenumirePrescurtata.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.tDenumirePrescurtata.ToString(), this.DenumirePrescurtata);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tCodIntern.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.tCodIntern.ToString(), this.CodIntern);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nTermenMediuZile.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.nTermenMediuZile.ToString(), this.TermenMediuZile);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.xnIdCategorie.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.xnIdCategorie.ToString(), this.IdCategorie);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nValoareRON.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.nValoareRON.ToString(), this.ValoareRON);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.nValoareEUR.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.nValoareEUR.ToString(), this.ValoareEUR);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiStandard.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DListaPreturiStandard.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BListaPreturiStandard");

            FillObjectWithDataRow<BListaPreturiStandard>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DListaPreturiStandard></DListaPreturiStandard>");

            //Adaugam elementele clasei BListaPreturiStandard
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIREPRESCURTATA");
            myXmlElem.InnerText = this.DenumirePrescurtata;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CODINTERN");
            myXmlElem.InnerText = this.CodIntern;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TERMENMEDIUZILE");
            myXmlElem.InnerText = Convert.ToString(this.TermenMediuZile);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCATEGORIE");
            myXmlElem.InnerText = Convert.ToString(this.IdCategorie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOARERON");
            myXmlElem.InnerText = Convert.ToString(this.ValoareRON);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOAREEUR");
            myXmlElem.InnerText = Convert.ToString(this.ValoareEUR);
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

            myXmlElem = myXmlDoc.CreateElement("DENUMIRECATEGORIE");
            myXmlElem.InnerText = this.DenumireCategorie;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CULOARE");
            myXmlElem.InnerText = Convert.ToString(this.Culoare);
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

        public static int ComparaDupaNume(BListaPreturiStandard xElemLista1, BListaPreturiStandard xElemLista2)
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