using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Preturi;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Preturi
{
    [Serializable()]
    public sealed class BEtape : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
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
            get { return this.MyDataRowGetItemAsInteger(DEtape.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DEtape.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DEtape.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("DurataMedieMinute", true, 1)]
        public int DurataMedieMinute
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()); }
            set { this.MyDataRowSetItem(DEtape.EnumCampuriTabela.nDurataMedieMinute.ToString(), value); }
        }


        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.EtapeMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Etape; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BEtape(int pId)
        : this(pId, null)
        {
        }

        public BEtape(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BEtape>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BEtape(DataRow pMyRow)
        {
            FillObjectWithDataRow<BEtape>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DEtape
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pDurataMedieMinute"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, int pDurataMedieMinute, IDbTransaction pTranzactie)
        {
            int id = DEtape.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pDurataMedieMinute, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BEtape
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieEtape GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieEtape lstDEtape = new BColectieEtape();
            using (DataSet ds = DEtape.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEtape.Add(new BEtape(dr));
                }
            }
            return lstDEtape;
        }

        public static BEtape GetById(int pIdEtapa, IDbTransaction pTranzactie)
        {
            return new BEtape(pIdEtapa, pTranzactie);
        }

        public static BEtape GetEtapaById(int pIdEtapa, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BEtape lstDEtape = null;
            using (DataSet ds = DEtape.GetById(pIdEtapa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDEtape = new BEtape(dr);
                }
            }
            return lstDEtape;
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
                throw new IdentificareBazaImposibilaException("BEtape");
            using (DataSet ds = DEtape.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BEtape");
            }
        }

        public static BColectieEtape getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieEtape listaRetur = new BColectieEtape();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DEtape.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BEtape(dr));
                    }
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public string getNumeEtapa(int pIdEtapa, IDbTransaction pTranzactie)
        {
            if (!string.IsNullOrEmpty(this.Denumire))
                return this.Denumire;
            return string.Empty;
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
                bool succesModificare = DEtape.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BEtape");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DEtape.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DEtape.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()))
                dictRezultat.Adauga(DEtape.EnumCampuriTabela.nDurataMedieMinute.ToString(), this.DurataMedieMinute);
            if (this.IsMyDataRowItemHasChanged(DEtape.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DEtape.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BEtape");

            FillObjectWithDataRow<BEtape>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DEtape></DEtape>");

            //Adaugam elementele clasei BEtape
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DURATAMEDIEMINUTE");
            myXmlElem.InnerText = Convert.ToString(this.DurataMedieMinute);
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

        public override string ToString()
        {
            return this.Denumire;
        }

        public override bool Equals(object obj)
        {
            if (obj is int || obj is long)
                return this.Id.Equals(CUtil.GetAsInt32(obj));

            if (obj is BEtape)
                return this.Id.Equals((obj as BEtape).Id);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BEtape xElemLista1, BEtape xElemLista2)
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

