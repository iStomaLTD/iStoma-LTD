using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.UtilizatorLucrariEtape;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Utilizatori
{
    [Serializable()]
    public sealed class BUtilizatorLucrariEtape : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, ICreare, IInchidere
    {


        #region Declaratii generale

        private static BUtilizatorLucrariEtape _UtilizatorConectat = null;
        private static BColectieUtilizator _ListaUtilizatoriBDD = null;

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatorLucrariEtape.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdLucrareEtapa", true, 1)]
        public int IdLucrareEtapa
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdLucrareEtapa.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdLucrareEtapa.ToString(), value); }
        }

        [BExport("IdUtilizator", true, 1)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdUtilizator.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdUtilizator.ToString(), value); }
        }

        [BExport("DurataMinute", true, 1)]
        public int DurataMinute
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizatorLucrariEtape.EnumCampuriTabela.nDurataMinute.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorLucrariEtape.EnumCampuriTabela.nDurataMinute.ToString(), value); }
        }
        
        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.MotiveInchidereUtilizator; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.UtilizatorLucrariEtape; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BUtilizatorLucrariEtape(int pId)
        : this(pId, null)
        {
        }

        public BUtilizatorLucrariEtape(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BUtilizatorLucrariEtape>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BUtilizatorLucrariEtape(DataRow pMyRow)
        {
            FillObjectWithDataRow<BUtilizatorLucrariEtape>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DUtilizatorLucrariEtape
        /// </summary>
        /// <param name="pIdLucrareEtapa"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pDurataMinute"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdLucrareEtapa, int pIdUtilizator, int pDurataMinute, IDbTransaction pTranzactie)
        {
            int id = DUtilizatorLucrariEtape.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdLucrareEtapa, pIdUtilizator, pDurataMinute, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdLucrareEtapa, int pIdUtilizator)
        {
            return pIdLucrareEtapa != 0 && pIdUtilizator != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BUtilizatorLucrariEtape
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieUtilizatorLucrariEtape GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieUtilizatorLucrariEtape lstDUtilizatorLucrariEtape = new BColectieUtilizatorLucrariEtape();
            using (DataSet ds = DUtilizatorLucrariEtape.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatorLucrariEtape.Add(new BUtilizatorLucrariEtape(dr));
                }
            }
            return lstDUtilizatorLucrariEtape;
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
                throw new IdentificareBazaImposibilaException("BUtilizatorLucrariEtape");
            using (DataSet ds = DUtilizatorLucrariEtape.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BUtilizatorLucrariEtape");
            }
        }

        public static BColectieUtilizatorLucrariEtape getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieUtilizatorLucrariEtape listaRetur = new BColectieUtilizatorLucrariEtape();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DUtilizatorLucrariEtape.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BUtilizatorLucrariEtape(dr));
                    }
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa
        
        public static BUtilizatorLucrariEtape GetById(int pIDUtilizatorLucrariEtape, IDbTransaction pTranzactie)
        {
            return new BUtilizatorLucrariEtape(pIDUtilizatorLucrariEtape, pTranzactie);
        }

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
                bool succesModificare = DUtilizatorLucrariEtape.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdLucrareEtapa.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdUtilizator.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.nDurataMinute.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BUtilizatorLucrariEtape");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DUtilizatorLucrariEtape.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdLucrareEtapa.ToString()))
                dictRezultat.Adauga(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdLucrareEtapa.ToString(), this.IdLucrareEtapa);
            if (this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdUtilizator.ToString()))
                dictRezultat.Adauga(DUtilizatorLucrariEtape.EnumCampuriTabela.xnIdUtilizator.ToString(), this.IdUtilizator);
            if (this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.nDurataMinute.ToString()))
                dictRezultat.Adauga(DUtilizatorLucrariEtape.EnumCampuriTabela.nDurataMinute.ToString(), this.DurataMinute);
            if (this.IsMyDataRowItemHasChanged(DUtilizatorLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DUtilizatorLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizatorLucrariEtape");

            FillObjectWithDataRow<BUtilizatorLucrariEtape>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DUtilizatorLucrariEtape></DUtilizatorLucrariEtape>");

            //Adaugam elementele clasei BUtilizatorLucrariEtape
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLUCRAREETAPA");
            myXmlElem.InnerText = Convert.ToString(this.IdLucrareEtapa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DURATAMINUTE");
            myXmlElem.InnerText = Convert.ToString(this.DurataMinute);
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

        public static int ComparaDupaNume(BUtilizatorLucrariEtape xElemLista1, BUtilizatorLucrariEtape xElemLista2)
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
                    return xElemLista1.IdLucrareEtapa.CompareTo(xElemLista2.IdLucrareEtapa);
            }
        }

        #endregion //Metode de comparatie

    }
}
