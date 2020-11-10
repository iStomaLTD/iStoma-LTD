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
    public sealed class BLucrariEtape : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


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
            get { return this.MyDataRowGetItemAsInteger(DLucrariEtape.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdLucrare", true, 1)]
        public int IdLucrare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLucrariEtape.EnumCampuriTabela.xnIdLucrare.ToString()); }
            set { this.MyDataRowSetItem(DLucrariEtape.EnumCampuriTabela.xnIdLucrare.ToString(), value); }
        }

        [BExport("IdEtapa", true, 1)]
        public int IdEtapa
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLucrariEtape.EnumCampuriTabela.xnIdEtapa.ToString()); }
            set { this.MyDataRowSetItem(DLucrariEtape.EnumCampuriTabela.xnIdEtapa.ToString(), value); }
        }

        [BExport("NumarOrdine", true, 1)]
        public int NumarOrdine
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLucrariEtape.EnumCampuriTabela.nNumarOrdine.ToString()); }
            set { this.MyDataRowSetItem(DLucrariEtape.EnumCampuriTabela.nNumarOrdine.ToString(), value); }
        }

        [BExport("DurataMedieMinute", true, 1)]
        public int DurataMedieMinute
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLucrariEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()); }
            set { this.MyDataRowSetItem(DLucrariEtape.EnumCampuriTabela.nDurataMedieMinute.ToString(), value); }
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
            get { return CDefinitiiComune.EnumTipObiect.LucrariEtape; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BLucrariEtape(int pId)
        : this(pId, null)
        {
        }

        public BLucrariEtape(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BLucrariEtape>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BLucrariEtape(DataRow pMyRow)
        {
            FillObjectWithDataRow<BLucrariEtape>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DLucrariEtape
        /// </summary>
        /// <param name="pIdLucrare"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pNumarOrdine"></param>
        /// <param name="pDurataMedieMinute"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdLucrare, int pIdEtapa, int pNumarOrdine, int pDurataMedieMinute, IDbTransaction pTranzactie)
        {
            int id = DLucrariEtape.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdLucrare, pIdEtapa, pNumarOrdine, pDurataMedieMinute, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente()
        {
            return true;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BLucrariEtape
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieLucrariEtape GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieLucrariEtape lstDLucrariEtape = new BColectieLucrariEtape();
            using (DataSet ds = DLucrariEtape.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDLucrariEtape.Add(new BLucrariEtape(dr));
                }
            }
            return lstDLucrariEtape;
        }

        public static BColectieLucrariEtape GetListByParamIdLucrare(int pIdLucrare, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieLucrariEtape lstDLucrariEtape = new BColectieLucrariEtape();
            using (DataSet ds = DLucrariEtape.GetListByParamIdLucrare(pIdLucrare, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDLucrariEtape.Add(new BLucrariEtape(dr));
                }
            }
            return lstDLucrariEtape;
        }

        public static List<int> GetListIdEtapeByParamIdLucrare(int pIdLucrare, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            List<int> lstDLucrariEtape = new List<int>();
            using (DataSet ds = DLucrariEtape.GetListByParamIdLucrare(pIdLucrare, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BLucrariEtape lucrareEtapa = new BLucrariEtape(dr);
                    lstDLucrariEtape.Add(lucrareEtapa.IdEtapa);
                }
            }
            return lstDLucrariEtape;
        }

        public static List<int> GetListByParamIdLucrareEtapa(int pIdLucrare, int pIdEtapa, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            List<int> lstDLucrariEtape = new List<int>();
            using (DataSet ds = DLucrariEtape.GetListByParamIdLucrareEtapa(pIdLucrare, pIdEtapa, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDLucrariEtape.Add(new BLucrariEtape(dr).IdEtapa);
                }
            }
            return lstDLucrariEtape;
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
                throw new IdentificareBazaImposibilaException("BLucrariEtape");
            using (DataSet ds = DLucrariEtape.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BLucrariEtape");
            }
        }

        public static BColectieLucrariEtape getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieLucrariEtape listaRetur = new BColectieLucrariEtape();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DLucrariEtape.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BLucrariEtape(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BLucrariEtape getByIdLucrareEtapa(int pIdLucrare, int pIdEtapa, IDbTransaction pTranzactie)
        {
            BLucrariEtape adresa = null;

            using (DataSet ds = DLucrariEtape.GetByIdLucrareEtapa(pIdLucrare, pIdEtapa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    adresa = new BLucrariEtape(dr);
                }
            }

            return adresa;
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
                bool succesModificare = DLucrariEtape.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.xnIdLucrare.ToString()) ||
                this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.xnIdEtapa.ToString()) ||
                this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.nNumarOrdine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BLucrariEtape");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DLucrariEtape.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.xnIdLucrare.ToString()))
                dictRezultat.Adauga(DLucrariEtape.EnumCampuriTabela.xnIdLucrare.ToString(), this.IdLucrare);
            if (this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.xnIdEtapa.ToString()))
                dictRezultat.Adauga(DLucrariEtape.EnumCampuriTabela.xnIdEtapa.ToString(), this.IdEtapa);
            if (this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.nNumarOrdine.ToString()))
                dictRezultat.Adauga(DLucrariEtape.EnumCampuriTabela.nNumarOrdine.ToString(), this.NumarOrdine);
            if (this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.nDurataMedieMinute.ToString()))
                dictRezultat.Adauga(DLucrariEtape.EnumCampuriTabela.nDurataMedieMinute.ToString(), this.DurataMedieMinute);
            if (this.IsMyDataRowItemHasChanged(DLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DLucrariEtape.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BLucrariEtape");

            FillObjectWithDataRow<BLucrariEtape>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DLucrariEtape></DLucrariEtape>");

            //Adaugam elementele clasei BLucrariEtape
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLUCRARE");
            myXmlElem.InnerText = Convert.ToString(this.IdLucrare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDETAPA");
            myXmlElem.InnerText = Convert.ToString(this.IdEtapa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARORDINE");
            myXmlElem.InnerText = Convert.ToString(this.NumarOrdine);
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

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BLucrariEtape xElemLista1, BLucrariEtape xElemLista2)
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
                    return xElemLista1.IdLucrare.CompareTo(xElemLista2.IdLucrare);
            }
        }

        #endregion //Metode de comparatie

    }
}
