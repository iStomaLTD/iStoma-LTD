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
    /// <summary>
    /// Clasa pentru gestionarea cabinetelor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiCabinete : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 50;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiCabinete.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiCabinete.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiCabinete.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        [BExport("IdAdresa", true, 1)]
        public int IdAdresa
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiCabinete.EnumCampuriTabela.xnIdAdresa.ToString()); }
            set { this.MyDataRowSetItem(DClientiCabinete.EnumCampuriTabela.xnIdAdresa.ToString(), value); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DClientiCabinete.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DClientiCabinete.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiCabineteMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiCabinete; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiCabinete(int pId) : this(pId, null)
        {
        }

        public BClientiCabinete(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiCabinete>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiCabinete(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiCabinete>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiCabinete
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pDenumire"></param>
        /// <param name="pIdAdresa"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static BClientiCabinete Add(int pIdClient, string pDenumire, IDbTransaction pTranzactie)
        {
            int id = DClientiCabinete.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pDenumire, pTranzactie);

            Comune.BAdrese adresa = Comune.BAdrese.AddEmpty(TipObiectClasa, id, Comune.BAdrese.EnumTipAdresa.Principala, pTranzactie);

            BClientiCabinete cabinet = new Clienti.BClientiCabinete(id, pTranzactie);
            cabinet.IdAdresa = adresa.Id;
            cabinet.UpdateAll(pTranzactie);

            return cabinet;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire, int pIdAdresa)
        {
            return !string.IsNullOrEmpty(pDenumire) && pIdAdresa != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiCabinete
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiCabinete GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiCabinete lstDClientiCabinete = new BColectieClientiCabinete();
            using (DataSet ds = DClientiCabinete.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiCabinete.Add(new BClientiCabinete(dr));
                }
            }
            return lstDClientiCabinete;
        }

        public static BColectieClientiCabinete GetListByIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiCabinete lstDClientiCabinete = new BColectieClientiCabinete();
            using (DataSet ds = DClientiCabinete.GetListByParamIdClient(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiCabinete.Add(new BClientiCabinete(dr));
                }
            }
            return lstDClientiCabinete;
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
                throw new IdentificareBazaImposibilaException("BClientiCabinete");
            using (DataSet ds = DClientiCabinete.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiCabinete");
            }
        }

        public static BColectieClientiCabinete getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiCabinete listaRetur = new BColectieClientiCabinete();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiCabinete.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiCabinete(dr));
                    }
                }
            }
            return listaRetur;
        }
        
        #endregion //Metode de clasa

        #region Metode de instanta

        public override string ToString()
        {
            return this.Denumire;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is int || obj is long)
                return this.Id.Equals(CUtil.GetAsInt32(obj));

            if (obj is BClientiCabinete)
                return this.Id.Equals((obj as BClientiCabinete).Id);

            return base.Equals(obj);
        }

        public Comune.BAdrese GetAdresa(IDbTransaction pTranzactie)
        {
            return new Comune.BAdrese(this.IdAdresa, pTranzactie);
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
                bool succesModificare = DClientiCabinete.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
                //this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.xnIdClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.xnIdAdresa.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiCabinete");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiCabinete.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiCabinete.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DClientiCabinete.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.xnIdAdresa.ToString()))
                dictRezultat.Adauga(DClientiCabinete.EnumCampuriTabela.xnIdAdresa.ToString(), this.IdAdresa);
            if (this.IsMyDataRowItemHasChanged(DClientiCabinete.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiCabinete.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiCabinete");

            FillObjectWithDataRow<BClientiCabinete>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DClientiCabinete></DClientiCabinete>");

            //Adaugam elementele clasei BClientiCabinete
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDADRESA");
            myXmlElem.InnerText = Convert.ToString(this.IdAdresa);
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
