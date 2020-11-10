using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Comune;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    /// <summary>
    /// Clasa pentru gestionarea BColoaneListeAfisaj
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BColoaneListeAfisaj : BGeneral, IDisposable
    {

        #region Declaratii generale

        private static Dictionary<int, BColectieColoaneListeAfisaj> _SDictColoaneListeAfisaj = new Dictionary<int, BColectieColoaneListeAfisaj>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int ColoanaMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("IdLista", true, 1)]
        public int IdLista
        {
            get { return this.MyDataRowGetItemAsInteger(DColoaneListeAfisaj.EnumCampuriTabela.xnIdLista.ToString()); }
        }

        [BExport("Coloana", true, 1)]
        public string Coloana
        {
            get { return this.MyDataRowGetItem(DColoaneListeAfisaj.EnumCampuriTabela.tColoana.ToString()); }
        }

        [BExport("Ordine", true, 1)]
        public int Ordine
        {
            get
            {
                if (this.IsCampDbNull(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString()))
                    return -1;

                return this.MyDataRowGetItemAsIntegerNull(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString());
            }
            set { this.MyDataRowSetItem(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString(), value); }
        }

        [BExport("Vizibila", true, 1)]
        public bool Vizibila
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DColoaneListeAfisaj.EnumCampuriTabela.bVizibila.ToString()); }
            set { this.MyDataRowSetItem(DColoaneListeAfisaj.EnumCampuriTabela.bVizibila.ToString(), value); }
        }

        [BExport("Latime", true, 1)]
        public int Latime
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DColoaneListeAfisaj.EnumCampuriTabela.nLatime.ToString()); }
            set { this.MyDataRowSetItem(DColoaneListeAfisaj.EnumCampuriTabela.nLatime.ToString(), value); }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ListeAfisajColoane; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BColoaneListeAfisaj(DataRow pMyRow)
        {
            FillObjectWithDataRow<BColoaneListeAfisaj>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static void DeleteByIdLista(int pIdLista, IDbTransaction pTranzactie)
        {
            DColoaneListeAfisaj.DeleteByIdLista(pIdLista, pTranzactie);

            if (_SDictColoaneListeAfisaj != null && _SDictColoaneListeAfisaj.ContainsKey(pIdLista))
                _SDictColoaneListeAfisaj.Remove(pIdLista);
        }

        public static BColoaneListeAfisaj GetByNume(string pNumeLista, string pNumeColoana, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);
            BColoaneListeAfisaj coloana = null;

            if (lista == null)
            {
                BListeAfisaj.Add(pNumeLista, string.Empty, 0, pTranzactie);

                lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);
            }

            if (lista != null)
            {
                incarcaColoanele(lista.Id, pTranzactie);

                coloana = _SDictColoaneListeAfisaj[lista.Id].GetByNume(pNumeColoana);

                if (coloana == null)
                {
                    Add(lista.Id, pNumeColoana, -1, true, 0, pTranzactie);
                    incarcaColoanele(lista.Id, pTranzactie);
                    coloana = _SDictColoaneListeAfisaj[lista.Id].GetByNume(pNumeColoana);
                }
            }

            return coloana;
        }

        public static void UpdateIndexColoana(string pNumeLista, string pNumeColoana, int pDisplayIndex, IDbTransaction pTranzactie)
        {
            BColoaneListeAfisaj coloana = GetByNume(pNumeLista, pNumeColoana, pTranzactie);

            if (coloana != null)
            {
                coloana.Ordine = pDisplayIndex;
                coloana.UpdateAll(pTranzactie);
            }
        }

        public static void UpdateLatimeColoana(string pNumeLista, string pNumeColoana, int pLatime, IDbTransaction pTranzactie)
        {
            BColoaneListeAfisaj coloana = GetByNume(pNumeLista, pNumeColoana, pTranzactie);

            if (coloana != null)
            {
                coloana.Latime = pLatime;
                coloana.UpdateAll(pTranzactie);
            }
        }

        public static List<string> GetListaColoaneAscunse(string pNumeLista, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);

            if (lista != null)
            {
                incarcaColoanele(lista.Id, pTranzactie);

                if (_SDictColoaneListeAfisaj.ContainsKey(lista.Id))
                    return _SDictColoaneListeAfisaj[lista.Id].GetListaColoaneAscunse();
            }

            return null;
        }

        public static Dictionary<string, int> GetOrdineAfisareColoane(string pNumeLista, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);

            if (lista != null)
            {
                incarcaColoanele(lista.Id, pTranzactie);

                return _SDictColoaneListeAfisaj[lista.Id].GetOrdineAfisareColoane();
            }

            return null;
        }

        public static Dictionary<string, int> GetLatimeColoane(string pNumeLista, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);

            if (lista != null)
            {
                incarcaColoanele(lista.Id, pTranzactie);

                return _SDictColoaneListeAfisaj[lista.Id].GetLatimeColoane();
            }

            return null;
        }

        public static BColoaneListeAfisaj GetByNume(int pIdLista, string pNumeColoana, IDbTransaction pTranzactie)
        {
            incarcaColoanele(pIdLista, pTranzactie);

            return _SDictColoaneListeAfisaj[pIdLista].GetByNume(pNumeColoana);
        }

        public static BColectieColoaneListeAfisaj GetByLista(int pIdLista, IDbTransaction pTranzactie)
        {
            incarcaColoanele(pIdLista, pTranzactie);

            return _SDictColoaneListeAfisaj[pIdLista];
        }

        public static BColectieColoaneListeAfisaj GetByLista(string pNumeLista, bool pCreeazaDacaNuExista, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);

            if (lista == null && pCreeazaDacaNuExista)
            {
                BListeAfisaj.Add(pNumeLista,string.Empty, 0, pTranzactie);

                lista = BListeAfisaj.GetListaByNume(pNumeLista, pTranzactie);
            }

            if (lista != null)
            {
                incarcaColoanele(lista.Id, pTranzactie);

                return _SDictColoaneListeAfisaj[lista.Id];
            }

            return null;
        }

        public static void incarcaColoanele(int pIdLista, IDbTransaction pTranzactie)
        {
            if (_SDictColoaneListeAfisaj == null)
                _SDictColoaneListeAfisaj = new Dictionary<int, BColectieColoaneListeAfisaj>();

            if (!_SDictColoaneListeAfisaj.ContainsKey(pIdLista))
            {
                _SDictColoaneListeAfisaj.Add(pIdLista, GetListByParam(pIdLista, pTranzactie));
            }
        }

        public static void DistrugeObiecteleStatice()
        {
            _SDictColoaneListeAfisaj = null;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DColoaneListeAfisaj
        /// </summary>
        /// <param name="pIdLista"></param>
        /// <param name="pColoana"></param>
        /// <param name="pOrdine"></param>
        /// <param name="pVizibila"></param>
        /// <param name="pLatime"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static void Add(int pIdLista, string pColoana, int pOrdine, bool pVizibila, int pLatime, IDbTransaction pTranzactie)
        {
            DColoaneListeAfisaj.Add(pIdLista, pColoana, pOrdine, pVizibila, pLatime, pTranzactie);

            if (_SDictColoaneListeAfisaj == null)
                _SDictColoaneListeAfisaj = new Dictionary<int, BColectieColoaneListeAfisaj>();

            if (_SDictColoaneListeAfisaj.ContainsKey(pIdLista))
                _SDictColoaneListeAfisaj.Remove(pIdLista);
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdLista, string pColoana, byte pOrdine, bool pVizibila, short pLatime)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BColoaneListeAfisaj
        /// </summary>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieColoaneListeAfisaj GetListByParam(int pIdLista, IDbTransaction pTranzactie)
        {
            BColectieColoaneListeAfisaj lstDColoaneListeAfisaj = new BColectieColoaneListeAfisaj();
            using (DataSet ds = DColoaneListeAfisaj.GetListByParam(pIdLista, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDColoaneListeAfisaj.Add(new BColoaneListeAfisaj(dr));
                }
            }
            return lstDColoaneListeAfisaj;
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
                bool succesModificare = DColoaneListeAfisaj.UpdateById(getDictProprietatiModificate(), this.IdLista, this.Coloana, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.bVizibila.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.nLatime.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();

            if (this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString()))
            {
                if (this.Ordine < 0)
                    dictRezultat.AdaugaNull(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString());
                else
                    dictRezultat.Adauga(DColoaneListeAfisaj.EnumCampuriTabela.nOrdine.ToString(), this.Ordine, false);
            }

            if (this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.bVizibila.ToString()))
                dictRezultat.Adauga(DColoaneListeAfisaj.EnumCampuriTabela.bVizibila.ToString(), this.Vizibila);

            if (this.IsMyDataRowItemHasChanged(DColoaneListeAfisaj.EnumCampuriTabela.nLatime.ToString()))
                dictRezultat.Adauga(DColoaneListeAfisaj.EnumCampuriTabela.nLatime.ToString(), this.Latime);

            return dictRezultat;
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
            myXmlDoc.LoadXml("<DColoaneListeAfisaj></DColoaneListeAfisaj>");

            //Adaugam elementele clasei BColoaneListeAfisaj
            myXmlElem = myXmlDoc.CreateElement("IDLISTA");
            myXmlElem.InnerText = Convert.ToString(this.IdLista);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("COLOANA");
            myXmlElem.InnerText = this.Coloana;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ORDINE");
            myXmlElem.InnerText = Convert.ToString(this.Ordine);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VIZIBILA");
            myXmlElem.InnerText = Convert.ToString(this.Vizibila);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("LATIME");
            myXmlElem.InnerText = Convert.ToString(this.Latime);
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
