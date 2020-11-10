using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Comune;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    /// <summary>
    /// Clasa pentru gestionarea listelor afisate (DGV, TGV)
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BListeAfisaj : BGeneral, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IStergere
    {

        #region Declaratii generale

        private static BColectieListeAfisaj _SListeAfisaj = null;

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireListaMaxLength = 150;
            public const int ColoanaSortareMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DListeAfisaj.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("DenumireLista", true, 1)]
        public string DenumireLista
        {
            get { return this.MyDataRowGetItem(DListeAfisaj.EnumCampuriTabela.tDenumireLista.ToString()); }
        }
        
        [BExport("ColoanaSortare", true, 1)]
        public string ColoanaSortare
        {
            get { return this.MyDataRowGetItem(DListeAfisaj.EnumCampuriTabela.tColoanaSortare.ToString()); }
            set { this.MyDataRowSetItem(DListeAfisaj.EnumCampuriTabela.tColoanaSortare.ToString(), value); }
        }

        [BExport("OrdineSortare", true, 1)]
        public int OrdineSortare
        {
            get
            {
                return this.MyDataRowGetItemAsIntegerNull(DListeAfisaj.EnumCampuriTabela.nOrdineSortare.ToString());
            }

            set { this.MyDataRowSetItem(DListeAfisaj.EnumCampuriTabela.nOrdineSortare.ToString(), value); }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ListaAfisaj; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BListeAfisaj(short pId)
            : this(pId, null)
        {
        }

        public BListeAfisaj(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BListeAfisaj>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BListeAfisaj(DataRow pMyRow)
        {
            FillObjectWithDataRow<BListeAfisaj>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static void DistrugeObiecteleStatice()
        {
            _SListeAfisaj = null;
        }

        public static BListeAfisaj GetListaByNume(string pNumeLista, IDbTransaction pTranzactie)
        {
            incarcaLista(pTranzactie);

            return _SListeAfisaj.GetByNume(pNumeLista);

            //BListeAfisaj lista = _SListeAfisaj.GetByNume(pNumeLista);

            //if (lista == null && pCreeazaDacaNuExista)
            //{
            //    Add(pNumeLista, BUtilizator.GetIdUtilizatorConectat(pTranzactie), string.Empty, 0, pTranzactie);

            //    incarcaLista(pTranzactie);
            //}

            //return _SListeAfisaj.GetByNume(pNumeLista);
        }

        public static BListeAfisaj GetListaByNume(string pNumeLista, bool pCreeazaDacaNuExista, IDbTransaction pTranzactie)
        {
            BListeAfisaj lista = _SListeAfisaj.GetByNume(pNumeLista);

            if (lista == null && pCreeazaDacaNuExista)
            {
                Add(pNumeLista, string.Empty, 0, pTranzactie);

                incarcaLista(pTranzactie);
            }

            return _SListeAfisaj.GetByNume(pNumeLista);
        }

        public static void UpdateColoanaSortare(string pNumeLista, string pNumeColoana, int pOrdineSortare, IDbTransaction pTranzactie)
        {
            incarcaLista(pTranzactie);

            BListeAfisaj lista = _SListeAfisaj.GetByNume(pNumeLista);

            if (lista != null)
            {
                //Update
                lista.ColoanaSortare = pNumeColoana;
                lista.OrdineSortare = pOrdineSortare;
                lista.UpdateAll(pTranzactie);
            }
            else
            {
                //Add
                Add(pNumeLista, pNumeColoana, pOrdineSortare, pTranzactie);
            }
        }

        private static void incarcaLista(IDbTransaction pTranzactie)
        {
            if (_SListeAfisaj == null)
            {
                _SListeAfisaj = GetListByParam( pTranzactie);
            }
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DListeAfisaj
        /// </summary>
        /// <param name="pDenumireLista"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pColoanaSortare"></param>
        /// <param name="pOrdineSortare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumireLista, string pColoanaSortare, int pOrdineSortare, IDbTransaction pTranzactie)
        {
            int id = DListeAfisaj.Add(pDenumireLista, pColoanaSortare, pOrdineSortare, pTranzactie);

            DistrugeObiecteleStatice();

            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, string pDenumireLista, string pColoanaSortare, bool pOrdineSortare)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BListeAfisaj
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieListeAfisaj GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieListeAfisaj lstDListeAfisaj = new BColectieListeAfisaj();
            using (DataSet ds = DListeAfisaj.GetListByParam(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListeAfisaj.Add(new BListeAfisaj(dr));
                }
            }
            return lstDListeAfisaj;
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
                throw new IdentificareBazaImposibilaException("BListeAfisaj");
            using (DataSet ds = DListeAfisaj.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BListeAfisaj");
            }
        }

        public static BColectieListeAfisaj getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieListeAfisaj listaRetur = new BColectieListeAfisaj();
            using (DataSet ds = DListeAfisaj.GetByListId(pListaId, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new BListeAfisaj(dr));
                }
            }
            return listaRetur;
        }

        public static bool Delete(int pIdLista, IDbTransaction pTranzactie)
        {
            if (pIdLista > 0)
            {
                DListeAfisaj.DeleteById(pIdLista, pTranzactie);
                BColoaneListeAfisaj.DeleteByIdLista(pIdLista, pTranzactie);

                DistrugeObiecteleStatice();

                return true;
            }

            return false;
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
                bool succesModificare = DListeAfisaj.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DListeAfisaj.EnumCampuriTabela.tColoanaSortare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListeAfisaj.EnumCampuriTabela.nOrdineSortare.ToString());
        }

        /// <summary>
        /// Metoda de instanta ce permite stergerea obiectului din baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Delete(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BListeAfisaj");
            //Stergem obiectul din baza de date
            DListeAfisaj.DeleteById(this.Id, pTranzactie);
        }

        public void Delete()
        {
            this.Delete(null);
        }

        public bool poateFiStearsa()
        {
            return true;
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DListeAfisaj.EnumCampuriTabela.tColoanaSortare.ToString()))
                dictRezultat.Adauga(DListeAfisaj.EnumCampuriTabela.tColoanaSortare.ToString(), this.ColoanaSortare);
            if (this.IsMyDataRowItemHasChanged(DListeAfisaj.EnumCampuriTabela.nOrdineSortare.ToString()))
                dictRezultat.Adauga(DListeAfisaj.EnumCampuriTabela.nOrdineSortare.ToString(), this.OrdineSortare);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BListeAfisaj");

            FillObjectWithDataRow<BListeAfisaj>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DListeAfisaj></DListeAfisaj>");

            //Adaugam elementele clasei BListeAfisaj
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRELISTA");
            myXmlElem.InnerText = this.DenumireLista;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);
            
            myXmlElem = myXmlDoc.CreateElement("COLOANASORTARE");
            myXmlElem.InnerText = this.ColoanaSortare;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ORDINESORTARE");
            myXmlElem.InnerText = Convert.ToString(this.OrdineSortare);
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
