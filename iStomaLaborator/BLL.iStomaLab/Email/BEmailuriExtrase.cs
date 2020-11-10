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
    public sealed class BEmailuriExtrase : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int SubiectMaxLength = 50;
            public const int ExpeditorMaxLength = 50;
            public const int DestinatarMaxLength = 100;
            public const int ObservatiiMaxLength = 100;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DEmailuri_Extrase.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdEmail", true, 1)]
        public int IdEmail
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmailuri_Extrase.EnumCampuriTabela.xnIdEmail.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.xnIdEmail.ToString(), value); }
        }

        [BExport("Flag", true, 1)]
        public int Flag
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmailuri_Extrase.EnumCampuriTabela.nFlag.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.nFlag.ToString(), value); }
        }

        [BExport("NumarAtasamente", true, 1)]
        public int NumarAtasamente
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmailuri_Extrase.EnumCampuriTabela.nNumarAtasamente.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.nNumarAtasamente.ToString(), value); }
        }

        [BExport("DataServer", true, 1)]
        public DateTime DataServer
        {
            get { return this.MyDataRowGetItemAsDateNull(DEmailuri_Extrase.EnumCampuriTabela.dDataServer.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.dDataServer.ToString(), value); }
        }

        [BExport("Subiect", true, 1)]
        public string Subiect
        {
            get { return this.MyDataRowGetItem(DEmailuri_Extrase.EnumCampuriTabela.tSubiect.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.tSubiect.ToString(), value); }
        }

        [BExport("Expeditor", true, 1)]
        public string Expeditor
        {
            get { return this.MyDataRowGetItem(DEmailuri_Extrase.EnumCampuriTabela.tExpeditor.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.tExpeditor.ToString(), value); }
        }

        [BExport("Destinatar", true, 1)]
        public string Destinatar
        {
            get { return this.MyDataRowGetItem(DEmailuri_Extrase.EnumCampuriTabela.tDestinatar.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.tDestinatar.ToString(), value); }
        }

        [BExport("IdUnic", true, 1)]
        public int IdUnic
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEmailuri_Extrase.EnumCampuriTabela.nIdUnic.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.nIdUnic.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DEmailuri_Extrase.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DEmailuri_Extrase.EnumCampuriTabela.tObservatii.ToString(), value); }
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
            get { return CDefinitiiComune.EnumTipObiect.EmailuriExtrase; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BEmailuriExtrase(int pId)
        : this(pId, null)
        {
        }

        public BEmailuriExtrase(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BEmailuriExtrase>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BEmailuriExtrase(DataRow pMyRow)
        {
            FillObjectWithDataRow<BEmailuriExtrase>(pMyRow, this);
        }

        #endregion //Constructorim

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip Emailuri_Extrase
        /// </summary>
        /// <param name="pIdEmail"></param>
        /// <param name="pFlag"></param>
        /// <param name="pNumarAtasamente"></param>
        /// <param name="pDataServer"></param>
        /// <param name="pSubiect"></param>
        /// <param name="pExpeditor"></param>
        /// <param name="pDestinatar"></param>
        /// <param name="pIdUnic"></param>
        /// <param name="pObservatii"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdEmail, int pFlag, int pNumarAtasamente, DateTime pDataServer, string pSubiect, string pExpeditor, string pDestinatar, int pIdUnic, string pObservatii, IDbTransaction pTranzactie)
        {
            int id = DEmailuri_Extrase.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdEmail, pFlag, pNumarAtasamente, pDataServer, pSubiect, pExpeditor, pDestinatar, pIdUnic, pObservatii, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdEmail)
        {
            return pIdEmail != 0;
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BEmailuriExtrase
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieEmailuriExtrase GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieEmailuriExtrase lstDEmailuri_Extrase = new BColectieEmailuriExtrase();
            using (DataSet ds = DEmailuri_Extrase.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEmailuri_Extrase.Add(new BEmailuriExtrase(dr));
                }
            }
            return lstDEmailuri_Extrase;
        }

        public static BColectieEmailuriExtrase GetListByParamIdEmail(int pIdEmail, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieEmailuriExtrase lstDEmailuri_Extrase = new BColectieEmailuriExtrase();
            using (DataSet ds = DEmailuri_Extrase.GetListByParamIdEmail(pIdEmail, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEmailuri_Extrase.Add(new BEmailuriExtrase(dr));
                }
            }
            return lstDEmailuri_Extrase;
        }

        public static BColectieEmailuriExtrase GetListByParamIdEmailDupaFlag(int pIdEmail, int pFlag, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieEmailuriExtrase lstDEmailuri_Extrase = new BColectieEmailuriExtrase();
            using (DataSet ds = DEmailuri_Extrase.GetListByParamIdEmailDupaFlag(pIdEmail, pFlag, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEmailuri_Extrase.Add(new BEmailuriExtrase(dr));
                }
            }
            return lstDEmailuri_Extrase;
        }

        public static List<DateTime> GetListUniqueId(int pIdEmail, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            List<DateTime> lstIdUnicEmailuriExtrase = new List<DateTime>();
            using (DataSet ds = DEmailuri_Extrase.GetListByParamIdEmail(pIdEmail, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstIdUnicEmailuriExtrase.Add(new BEmailuriExtrase(dr).DataServer);
                }
            }
            return lstIdUnicEmailuriExtrase;
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
                throw new IdentificareBazaImposibilaException("BEmailuriExtrase");
            using (DataSet ds = DEmailuri_Extrase.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BEmailuriExtrase");
            }
        }

        public static BColectieEmailuriExtrase getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieEmailuriExtrase listaRetur = new BColectieEmailuriExtrase();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DEmailuri_Extrase.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BEmailuriExtrase(dr));
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
                bool succesModificare = DEmailuri_Extrase.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.xnIdEmail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nFlag.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nNumarAtasamente.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.dDataServer.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tSubiect.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tExpeditor.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tDestinatar.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nIdUnic.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tObservatii.ToString());
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
                throw new IdentificareBazaImposibilaException("BEmailuriExtrase");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DEmailuri_Extrase.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.xnIdEmail.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.xnIdEmail.ToString(), this.IdEmail);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nFlag.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.nFlag.ToString(), this.Flag);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nNumarAtasamente.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.nNumarAtasamente.ToString(), this.NumarAtasamente);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.dDataServer.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.dDataServer.ToString(), this.DataServer);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tSubiect.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.tSubiect.ToString(), this.Subiect);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tExpeditor.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.tExpeditor.ToString(), this.Expeditor);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tDestinatar.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.tDestinatar.ToString(), this.Destinatar);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.nIdUnic.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.nIdUnic.ToString(), this.IdUnic);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DEmailuri_Extrase.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DEmailuri_Extrase.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BEmailuriExtrase");

            FillObjectWithDataRow<BEmailuriExtrase>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DEmailuri_Extrase></DEmailuri_Extrase>");

            //Adaugam elementele clasei BEmailuriExtrase
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDEMAIL");
            myXmlElem.InnerText = Convert.ToString(this.IdEmail);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("FLAG");
            myXmlElem.InnerText = Convert.ToString(this.Flag);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARATASAMENTE");
            myXmlElem.InnerText = Convert.ToString(this.NumarAtasamente);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATASERVER");
            myXmlElem.InnerText = Convert.ToString(this.DataServer);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SUBIECT");
            myXmlElem.InnerText = this.Subiect;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("EXPEDITOR");
            myXmlElem.InnerText = this.Expeditor;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DESTINATAR");
            myXmlElem.InnerText = this.Destinatar;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUNIC");
            myXmlElem.InnerText = Convert.ToString(this.IdUnic);
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

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BEmailuriExtrase xElemLista1, BEmailuriExtrase xElemLista2)
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
                    return xElemLista1.IdUnic.CompareTo(xElemLista2.IdUnic);
            }
        }

        #endregion //Metode de comparatie

    }
}
