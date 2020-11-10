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

namespace BLL.iStomaLab.Clienti
{
    public sealed class BClientiPacienti : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {
        #region Declaratii generale

        private static Dictionary<int, BClientiPacienti> _lDictPacienti = new Dictionary<int, BClientiPacienti>();
        private static BClientiPacienti _UtilizatorConectat = null;
        private static BColectiePacienti _ListaPacientiBDD = null;
        int lId = 0;

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumeMaxLength = 50;
            public const int PrenumeMaxLength = 50;           
            public const int TelefonMobilMaxLength = 20;           
            public const int AdresaMailMaxLength = 50;           
            public const int ObservatiiMaxLength = 500;         
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPacienti.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPacienti.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }
      
        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tNumePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tNumePacient.ToString(), value); }
        }

        [BExport("Prenume", true, 1)]
        public string Prenume
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tPrenumePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tPrenumePacient.ToString(), value); }
        }

        [BExport("DataNastere", true, 1)]
        public DateTime DataNastere
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiPacienti.EnumCampuriTabela.dDataNasterePacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.dDataNasterePacient.ToString(), value); }
        }

        [BExport("Varsta", true, 1)]
        public int Varsta
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPacienti.EnumCampuriTabela.nVarsta.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.nVarsta.ToString(), value); }
        }

        [BExport("Sex", true, 1)]
        public int Sex
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiPacienti.EnumCampuriTabela.nSexPacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.nSexPacient.ToString(), value); }
        }

        [BExport("TelefonMobil", true, 1)]
        public string TelefonMobil
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tTelefonMobil.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tTelefonMobil.ToString(), value); }
        }       

        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tObservatii.ToString(), value); }
        }
        [BExport("ContStoma", true, 1)]
        public string ContStoma
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tContStoma.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tContStoma.ToString(), value); }
        }

        [BExport("ParolaStoma", true, 1)]
        public string ParolaStoma
        {
            get { return this.MyDataRowGetItem(DClientiPacienti.EnumCampuriTabela.tParolaStoma.ToString()); }
            set { this.MyDataRowSetItem(DClientiPacienti.EnumCampuriTabela.tParolaStoma.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiPacientiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiPacienti; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiPacienti(int pId)
        : this(pId, null)
        {
        }

        public BClientiPacienti(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiPacienti>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiPacienti(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiPacienti>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static List<StructIdDenumire> GetListaCautare(int pIdClient, string pDenumire, IDbTransaction pTranzactie)
        {
            List<StructIdDenumire> listaRetur = new List<StructIdDenumire>();

            if (pIdClient <= 0 || string.IsNullOrEmpty(pDenumire)) return listaRetur;

            using (DataSet ds = DClientiPacienti.GetListaCautare(pIdClient, pDenumire.Length <= 2 ? string.Concat(CUtil.PregatesteStringCautareBDD(pDenumire), "%") : string.Concat("%", CUtil.PregatesteStringCautareBDD(pDenumire), "%"), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //string A = Convert.ToString(dr["tNumePacient"]);
                   // string B = Convert.ToString(dr["tPrenumePacient"]);
                   // string denumire = string.Concat(A," ",B);

                    listaRetur.Add(new StructIdDenumire(Convert.ToInt32(dr["nId"]), Convert.ToString(dr["tNumePacient"])));
                }
            }
            return listaRetur;
        }


        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiReprezentanti
        /// </summary>
        /// <param name="pIdClient"></param>        
        /// <param name="pNume"></param>
        /// <param name="pPrenume"></param>
        /// <param name="pDataNastere"></param>
        /// <param name="pVarsta"></param>
        /// <param name="pSex"></param>       
        /// <param name="pTelefonMobil"></param>       
        /// <param name="pAdresaMail"></param>       
        /// <param name="pObservatii"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdClient, string pNume, string pPrenume, DateTime pDataNastere,int pVarsta ,int pSex, string pTelefonMobil, string pAdresaMail, string pObservatii, IDbTransaction pTranzactie)
        {
            int id = DClientiPacienti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient,  pNume, pPrenume, pDataNastere, pVarsta, pSex, pTelefonMobil, pAdresaMail, pObservatii, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pNume, string pPrenume)
        {            
            return !string.IsNullOrEmpty(pNume) && !string.IsNullOrEmpty(pPrenume);
        }

        public static BClientiPacienti getPacient(int lId, IDbTransaction xTrans)
        {
            if (_lDictPacienti == null)
                _lDictPacienti = new Dictionary<int, BClientiPacienti>();

            if (!_lDictPacienti.ContainsKey(lId))
                _lDictPacienti.Add(lId, new BClientiPacienti(lId, xTrans));

            return _lDictPacienti[lId];
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BReprezentant
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>

        public static BColectiePacienti GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectiePacienti lstDClientiPacienti = new BColectiePacienti();
            using (DataSet ds = DClientiPacienti.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPacienti.Add(new BClientiPacienti(dr));
                }
            }
            return lstDClientiPacienti;
        }

        public static BColectiePacienti GetListByIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectiePacienti lstDClientiPacienti = new BColectiePacienti();
            using (DataSet ds = DClientiPacienti.GetListByParamIdClient(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPacienti.Add(new BClientiPacienti(dr));
                }
            }
            return lstDClientiPacienti;
        }
              

        public static List<string> getListaPacientiDenumire()
        {
            List<string> lstpacienti = new List<string>();
            foreach (BClientiPacienti pacient in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstpacienti.Add(pacient.Nume);
            }
            return lstpacienti;
        }

        public static List<int> getListaPacientiId()
        {
            List<int> lstpacienti = new List<int>();
            foreach (BClientiPacienti pacient in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstpacienti.Add(pacient.Id);
            }
            return lstpacienti;
        }


        public static List<int> getMaxPacientId()
        {
            List<int> lstpacienti = new List<int>();
            foreach (BClientiPacienti pacient in GetListByParam(CDefinitiiComune.EnumStare.Activa, null))
            {
                lstpacienti.Add(pacient.Id);
            }
            return lstpacienti;
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
              throw new IdentificareBazaImposibilaException("BClientiPacienti");
            using (DataSet ds = DClientiPacienti.GetPacientById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiPacienti");
            }
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
                bool succesModificare = DClientiPacienti.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
           return this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.xnIdClient.ToString()) ||                
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tNumePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tPrenumePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.dDataNasterePacient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.dDataCreare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.xnUtilizatorCreare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.nSexPacient.ToString()) ||                 
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tAdresaMail.ToString()) ||                
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.dDataInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.xnUtilizatorInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiPacient");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiPacienti.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);
              
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
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);           
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tNumePacient.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tNumePacient.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tPrenumePacient.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tPrenumePacient.ToString(), this.Prenume);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.dDataNasterePacient.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.dDataNasterePacient.ToString(), this.DataNastere);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.nSexPacient.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.nSexPacient.ToString(), this.Sex); 
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tTelefonMobil.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tTelefonMobil.ToString(), this.TelefonMobil);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);  
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.dDataCreare.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.dDataCreare.ToString(), this.DataCreare);
            if (this.IsMyDataRowItemHasChanged(DClientiPacienti.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiPacienti.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiPacienti");

            FillObjectWithDataRow<BClientiPacienti>(GetDataRowForObjet(this.Id, pTranzactie), this);
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

            myXmlElem = myXmlDoc.CreateElement("TELEFONMOBIL");
            myXmlElem.InnerText = this.TelefonMobil;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ADRESAMAIL");
            myXmlElem.InnerText = this.AdresaMail;
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
            foreach (BClientiPacienti medic in GetListByIdClient(pIdClient, CDefinitiiComune.EnumStare.Activa, null))
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
