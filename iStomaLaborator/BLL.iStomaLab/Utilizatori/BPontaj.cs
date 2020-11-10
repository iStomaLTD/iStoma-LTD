using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Utilizatori;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea pontajelor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BPontaj : BGestiuneCMI, IDisposable, ICheie, ILL.General.Interfete.IProprietarDocumente, IAfisaj, ICreare
    {
        #region Declaratii generale

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int ObservatiiMaxLength = 200;
        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DPontaj.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdSediu", true, 1)]
        public int IdSediu
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DPontaj.EnumCampuriTabela.xnIdSediu.ToString()); }
            set { this.MyDataRowSetItem(DPontaj.EnumCampuriTabela.xnIdSediu.ToString(), value); }
        }

        [BExport("IdUtilizator", true, 1)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DPontaj.EnumCampuriTabela.xnIdUtilizator.ToString()); }
            set { this.MyDataRowSetItem(DPontaj.EnumCampuriTabela.xnIdUtilizator.ToString(), value); }
        }

        [BExport("DataPontaj", true, 1)]
        public DateTime DataPontaj
        {
            get { return this.MyDataRowGetItemAsDateNull(DPontaj.EnumCampuriTabela.dDataPontaj.ToString()); }
            set { this.MyDataRowSetItem(DPontaj.EnumCampuriTabela.dDataPontaj.ToString(), value); }
        }

        [BExport("TipPontaj", true, 1)]
        public int TipPontaj
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DPontaj.EnumCampuriTabela.nTipPontaj.ToString()); }
            set { this.MyDataRowSetItem(DPontaj.EnumCampuriTabela.nTipPontaj.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DPontaj.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DPontaj.EnumCampuriTabela.tObservatii.ToString(), value); }
        }


        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Pontaj; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BPontaj(int pId)
        : this(pId, null)
        {
        }

        public BPontaj(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BPontaj>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BPontaj(DataRow pMyRow)
        {
            FillObjectWithDataRow<BPontaj>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DPontaj
        /// </summary>
        /// <param name="pIdSediu"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pDataPontaj"></param>
        /// <param name="pTipPontaj"></param>
        /// <param name="pObservatii"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdSediu, int pIdUtilizator, DateTime pDataPontaj, int pTipPontaj, string pObservatii, IDbTransaction pTranzactie)
        {
            int id = DPontaj.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdSediu, pIdUtilizator, pDataPontaj, pTipPontaj, pObservatii, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdSediu, int pIdUtilizator)
        {
            return pIdSediu != 0 && pIdUtilizator != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BPontaj
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectiePontaj GetListByParam(IDbTransaction pTranzactie)
        {
            BColectiePontaj lstDPontaj = new BColectiePontaj();
            using (DataSet ds = DPontaj.GetListByParam(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDPontaj.Add(new BPontaj(dr));
                }
            }
            return lstDPontaj;
        }

        public static BColectiePontaj GetListByIdUtilizator(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectiePontaj lstDPontaj = new BColectiePontaj();
            using (DataSet ds = DPontaj.GetListByIdUtilizator(pIdUtilizator, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDPontaj.Add(new BPontaj(dr));
                }
            }
            return lstDPontaj;
        }
        
        public static BColectiePontaj GetListByIdUtilizatorTotal(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectiePontaj lstDPontaj = new BColectiePontaj();
            using (DataSet ds = DPontaj.GetListByIdUtilizatorTotal(pIdUtilizator, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDPontaj.Add(new BPontaj(dr));
                }
            }
            return lstDPontaj;
        }

        public static BColectiePontaj GetListByIdUtilizatorTotalPePerioada(int pIdUtilizator, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectiePontaj lstDPontaj = new BColectiePontaj();
            using (DataSet ds = DPontaj.GetListByIdUtilizatorTotalPePerioada(pIdUtilizator, pDataInceput, pDataSfarsit, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDPontaj.Add(new BPontaj(dr));
                }
            }
            return lstDPontaj;
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
                throw new IdentificareBazaImposibilaException("BPontaj");
            using (DataSet ds = DPontaj.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BPontaj");
            }
        }

        public static BColectiePontaj getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectiePontaj listaRetur = new BColectiePontaj();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DPontaj.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BPontaj(dr));
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
                bool succesModificare = DPontaj.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.xnIdSediu.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.xnIdUtilizator.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.dDataPontaj.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.nTipPontaj.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.tObservatii.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.xnIdSediu.ToString()))
                dictRezultat.Adauga(DPontaj.EnumCampuriTabela.xnIdSediu.ToString(), this.IdSediu);
            if (this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.xnIdUtilizator.ToString()))
                dictRezultat.Adauga(DPontaj.EnumCampuriTabela.xnIdUtilizator.ToString(), this.IdUtilizator);
            if (this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.dDataPontaj.ToString()))
                dictRezultat.Adauga(DPontaj.EnumCampuriTabela.dDataPontaj.ToString(), this.DataPontaj);
            if (this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.nTipPontaj.ToString()))
                dictRezultat.Adauga(DPontaj.EnumCampuriTabela.nTipPontaj.ToString(), this.TipPontaj);
            if (this.IsMyDataRowItemHasChanged(DPontaj.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DPontaj.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BPontaj");

            FillObjectWithDataRow<BPontaj>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DPontaj></DPontaj>");

            //Adaugam elementele clasei BPontaj
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDSEDIU");
            myXmlElem.InnerText = Convert.ToString(this.IdSediu);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAPONTAJ");
            myXmlElem.InnerText = Convert.ToString(this.DataPontaj);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPPONTAJ");
            myXmlElem.InnerText = Convert.ToString(this.TipPontaj);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
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

        public static int ComparaDupaNume(BPontaj xElemLista1, BPontaj xElemLista2)
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
                    return xElemLista1.DataPontaj.CompareTo(xElemLista2.DataPontaj);
            }
        }

        #endregion //Metode de comparatie
    }
}
