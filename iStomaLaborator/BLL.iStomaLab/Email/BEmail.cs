using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.EMail;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Email
{
    [Serializable()]
    public sealed class BEmail : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int AdresaMailMaxLength = 50;
            public const int ParolaMailMaxLength = 50;
            public const int HostSMTPMaxLength = 100;
            public const int HostIMAPMaxLength = 100;
            public const int UserMaxLength = 50;
            public const int IdCalculatorMaxLength = 100;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DEmail.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }

        [BExport("ParolaMail", true, 1)]
        public String ParolaMail
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tParolaMail.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tParolaMail.ToString(), value); }
        }

        [BExport("HostSMTP", true, 1)]
        public string HostSMTP
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tHostSMTP.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tHostSMTP.ToString(), value); }
        }

        [BExport("PortSMTP", true, 1)]
        public int PortSMTP
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmail.EnumCampuriTabela.nPortSMTP.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.nPortSMTP.ToString(), value); }
        }

        [BExport("HostIMAP", true, 1)]
        public string HostIMAP
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tHostIMAP.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tHostIMAP.ToString(), value); }
        }

        [BExport("PortIMAP", true, 1)]
        public int PortIMAP
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmail.EnumCampuriTabela.nPortIMAP.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.nPortIMAP.ToString(), value); }
        }

        [BExport("TimeOut", true, 1)]
        public int TimeOut
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmail.EnumCampuriTabela.nTimeOut.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.nTimeOut.ToString(), value); }
        }

        [BExport("SSL", true, 1)]
        public bool SSL
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DEmail.EnumCampuriTabela.bSSL.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.bSSL.ToString(), value); }
        }

        [BExport("User", true, 1)]
        public string User
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tUser.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tUser.ToString(), value); }
        }

        [BExport("IdLocatieCurenta", true, 1)]
        public int IdLocatieCurenta
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmail.EnumCampuriTabela.xnIdLocatieCurenta.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.xnIdLocatieCurenta.ToString(), value); }
        }

        [BExport("IdCalculator", true, 1)]
        public string IdCalculator
        {
            get { return this.MyDataRowGetItem(DEmail.EnumCampuriTabela.tIdCalculator.ToString()); }
            set { this.MyDataRowSetItem(DEmail.EnumCampuriTabela.tIdCalculator.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.EmailMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Email; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BEmail(int pId)
        : this(pId, null)
        {
        }

        public BEmail(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BEmail>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BEmail(DataRow pMyRow)
        {
            FillObjectWithDataRow<BEmail>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DEmail
        /// </summary>
        /// <param name="pAdresaMail"></param>
        /// <param name="pParolaMail"></param>
        /// <param name="pHostSMTP"></param>
        /// <param name="pPortSMTP"></param>
        /// <param name="pHostIMAP"></param>
        /// <param name="pPortIMAP"></param>
        /// <param name="pTimeOut"></param>
        /// <param name="pSSL"></param>
        /// <param name="pUser"></param>
        /// <param name="pIdLocatieCurenta"></param>
        /// <param name="pIdCalculator"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pAdresaMail, string pParolaMail, string pHostSMTP, int pPortSMTP, string pHostIMAP, int pPortIMAP, int pTimeOut, bool pSSL, string pUser, int pIdLocatieCurenta, string pIdCalculator, IDbTransaction pTranzactie)
        {
            int id = DEmail.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pAdresaMail, CCL.iStomaLab.Utile.CSecuritate.Encrypt(pParolaMail), pHostSMTP, pPortSMTP, pHostIMAP, pPortIMAP, pTimeOut, pSSL, pUser, pIdLocatieCurenta, pIdCalculator, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pAdresaMail, string pParolaMail, string pHostSMTP, int pPortSMTP, string pHostIMAP, int pPortIMAP)
        {
            return !string.IsNullOrEmpty(pAdresaMail) && !string.IsNullOrEmpty(pParolaMail) && !string.IsNullOrEmpty(pHostSMTP) && pPortSMTP != 0 && !string.IsNullOrEmpty(pHostIMAP) && pPortIMAP != 0;
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BEmail
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieEmail GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieEmail lstDEmail = new BColectieEmail();
            using (DataSet ds = DEmail.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEmail.Add(new BEmail(dr));
                }
            }
            return lstDEmail;
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
                throw new IdentificareBazaImposibilaException("BEmail");
            using (DataSet ds = DEmail.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BEmail");
            }
        }

        public static BColectieEmail getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieEmail listaRetur = new BColectieEmail();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DEmail.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BEmail(dr));
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
                bool succesModificare = DEmail.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tAdresaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tParolaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tHostSMTP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nPortSMTP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tHostIMAP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nPortIMAP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nTimeOut.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.bSSL.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tUser.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.xnIdLocatieCurenta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tIdCalculator.ToString());
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
                throw new IdentificareBazaImposibilaException("BEmail");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DEmail.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tParolaMail.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tParolaMail.ToString(), this.ParolaMail);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tHostSMTP.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tHostSMTP.ToString(), this.HostSMTP);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nPortSMTP.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.nPortSMTP.ToString(), this.PortSMTP);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tHostIMAP.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tHostIMAP.ToString(), this.HostIMAP);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nPortIMAP.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.nPortIMAP.ToString(), this.PortIMAP);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.nTimeOut.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.nTimeOut.ToString(), this.TimeOut);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.bSSL.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.bSSL.ToString(), this.SSL);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tUser.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tUser.ToString(), this.User);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.xnIdLocatieCurenta.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.xnIdLocatieCurenta.ToString(), this.IdLocatieCurenta);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tIdCalculator.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tIdCalculator.ToString(), this.IdCalculator);
            if (this.IsMyDataRowItemHasChanged(DEmail.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DEmail.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BEmail");

            FillObjectWithDataRow<BEmail>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DEmail></DEmail>");

            //Adaugam elementele clasei BEmail
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ADRESAMAIL");
            myXmlElem.InnerText = this.AdresaMail;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PAROLAMAIL");
            myXmlElem.InnerText = this.ParolaMail;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("HOSTSMTP");
            myXmlElem.InnerText = this.HostSMTP;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PORTSMTP");
            myXmlElem.InnerText = Convert.ToString(this.PortSMTP);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("HOSTIMAP");
            myXmlElem.InnerText = this.HostIMAP;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PORTIMAP");
            myXmlElem.InnerText = Convert.ToString(this.PortIMAP);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIMEOUT");
            myXmlElem.InnerText = Convert.ToString(this.TimeOut);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SSL");
            myXmlElem.InnerText = Convert.ToString(this.SSL);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("USER");
            myXmlElem.InnerText = this.User;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCATIECURENTA");
            myXmlElem.InnerText = Convert.ToString(this.IdLocatieCurenta);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCALCULATOR");
            myXmlElem.InnerText = this.IdCalculator;
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

        public static int ComparaDupaNume(BEmail xElemLista1, BEmail xElemLista2)
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
                    return xElemLista1.AdresaMail.CompareTo(xElemLista2.AdresaMail);
            }
        }

        #endregion //Metode de comparatie

    }
}
