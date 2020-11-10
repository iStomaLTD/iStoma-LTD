                                        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CDL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea interactiunilor utilizatorilor cu statiile de lucru
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BStatiiDeLucruUtilizatori : BGestiuneCMI, IDisposable, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int IdStatieMaxLength = 150;
            public const int NumeMaxLength = 50;
            public const int ContStomaMaxLength = 50;
            public const int ParolaStomaMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        public int Id
        {
            get { return this.IdStatieDeLucru; }
        }

        [BExport("IdStatieDeLucru", true, 1)]
        [BIdentitate(true)]
        public int IdStatieDeLucru
        {
            get { return this.MyDataRowGetItemAsInteger(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdStatieDeLucru.ToString()); }
        }

        [BExport("IdUtilizator", true, 1)]
        [BIdentitate(true)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsInteger(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdUtilizator.ToString()); }
            set { this.MyDataRowSetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdUtilizator.ToString(), value); }
        }

        [BExport("PastreazaConectat", true, 1)]
        public bool PastreazaConectat
        {
            get { return this.MyDataRowGetItemAsBoolean(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bPastreazaConectat.ToString()); }
            set { this.MyDataRowSetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bPastreazaConectat.ToString(), value); }
        }

        [BExport("BlocheazaAccesul", true, 1)]
        public bool BlocheazaAccesul
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bBlocheazaAccesul.ToString()); }
            set { this.MyDataRowSetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bBlocheazaAccesul.ToString(), value); }
        }

        [BExport("StatieBlocata", true, 1)]
        public bool StatieBlocata
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bStatieBlocata.ToString()); }
        }

        [BExport("IdStatie", true, 1)]
        public string IdStatie
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.tIdStatie.ToString()); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.tNume.ToString()); }
        }

        [BExport("ContStoma", true, 1)]
        public string ContStoma
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.tContStoma.ToString()); }
        }

        [BExport("ParolaStoma", true, 1)]
        public string ParolaStoma
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucruUtilizatori.EnumCampuriTabela.tParolaStoma.ToString()); }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.StatiiDeLucruUtilizatori; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BStatiiDeLucruUtilizatori(int pIdStatieDeLucru, int pIdUtilizator)
        : this(pIdStatieDeLucru, pIdUtilizator, null)
        {
        }

        public BStatiiDeLucruUtilizatori(int pIdStatieDeLucru, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BStatiiDeLucruUtilizatori>(GetDataRowForObjet(pIdStatieDeLucru, pIdUtilizator, pTranzactie), this);
        }

        public BStatiiDeLucruUtilizatori(DataRow pMyRow)
        {
            FillObjectWithDataRow<BStatiiDeLucruUtilizatori>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static void DistrugeVariabileleStaticeLocale()
        {
            _SPreferinteStatie = null;
        }

        private static BStatiiDeLucruUtilizatori _SPreferinteStatie = null;

        public static BStatiiDeLucruUtilizatori GetPreferinteUtilizatorConectat(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            if (_SPreferinteStatie == null)
            {
                BStatiiDeLucru statie = BStatiiDeLucru.GetStatiaCurenta(pIdUtilizator, pTranzactie);

                using (DataSet ds = DStatiiDeLucruUtilizatori.GetPreferinteUtilizatorConectat(statie.Id, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _SPreferinteStatie = new BStatiiDeLucruUtilizatori(dr);
                        break;
                    }
                }
            }

            return _SPreferinteStatie;
        }

        internal static void DeconecteazaUtilizatorulConectat(IDbTransaction pTranzactie)
        {
            if (_SPreferinteStatie != null)
            {
                _SPreferinteStatie.PastreazaConectat = false;
                _SPreferinteStatie.UpdateAll(pTranzactie);

                _SPreferinteStatie = null;
            }
        }

        internal static bool SeteazaPreferinteStatie(BUtilizator pUtilizatorConectat, bool pPastreazaConexiunea, IDbTransaction pTranzactie)
        {
            if (pUtilizatorConectat == null) return false;

            if (_SPreferinteStatie == null)
            {
                using (DataSet ds = DStatiiDeLucruUtilizatori.GetById(BStatiiDeLucru.GetStatiaCurenta(pUtilizatorConectat.Id, pTranzactie).Id, pUtilizatorConectat.Id, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _SPreferinteStatie = new BStatiiDeLucruUtilizatori(dr);
                    }
                }

                if (_SPreferinteStatie == null)
                {
                    add(BStatiiDeLucru.GetStatiaCurenta(pUtilizatorConectat.Id, pTranzactie).Id, pUtilizatorConectat.Id, pPastreazaConexiunea, pTranzactie);
                    _SPreferinteStatie = new BStatiiDeLucruUtilizatori(BStatiiDeLucru.GetStatiaCurenta(pUtilizatorConectat.Id, pTranzactie).Id, pUtilizatorConectat.Id, pTranzactie);
                }
                else
                {
                    _SPreferinteStatie.PastreazaConectat = pPastreazaConexiunea;
                    _SPreferinteStatie.IdUtilizator = pUtilizatorConectat.Id;
                    _SPreferinteStatie.UpdateAll(pTranzactie);
                }
            }

            if (_SPreferinteStatie == null) return false;

            return !_SPreferinteStatie.StatieBlocata && !_SPreferinteStatie.BlocheazaAccesul;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DStatiiDeLucruUtilizatori
        /// </summary>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pPastreazaConectat"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static int add(int pIdStatieDeLucru, int pIdUtilizator, bool pPastreazaConectat, IDbTransaction pTranzactie)
        {
            int id = DStatiiDeLucruUtilizatori.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdStatieDeLucru, pIdUtilizator, pPastreazaConectat, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdStatieDeLucru, int pIdUtilizator, bool pPastreazaConectat)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BStatiiDeLucruUtilizatori
        /// </summary>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieStatiiDeLucruUtilizatori GetListByParam(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieStatiiDeLucruUtilizatori lstDStatiiDeLucruUtilizatori = new BColectieStatiiDeLucruUtilizatori();
            using (DataSet ds = DStatiiDeLucruUtilizatori.GetListByParam(pIdUtilizator, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDStatiiDeLucruUtilizatori.Add(new BStatiiDeLucruUtilizatori(dr));
                }
            }
            return lstDStatiiDeLucruUtilizatori;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea DataRow-ului corespunzator obiectului in baza de date
        /// </summary>
        /// <param name="pIdStatieDeLucru"></param>
        /// <param name="pIdUtilizator"></param>
        /// <returns>Un DataRow ce contine informatiile corespunzatoare obiectului</returns>
        /// <remarks></remarks>
        private static DataRow GetDataRowForObjet(int pIdStatieDeLucru, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            if (pIdStatieDeLucru <= 0)
                throw new IdentificareBazaImposibilaException("BStatiiDeLucruUtilizatori");
            if (pIdUtilizator <= 0)
                throw new IdentificareBazaImposibilaException("BStatiiDeLucruUtilizatori");
            using (DataSet ds = DStatiiDeLucruUtilizatori.GetById(pIdStatieDeLucru, pIdUtilizator, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BStatiiDeLucruUtilizatori");
            }
        }

        public static BColectieStatiiDeLucruUtilizatori getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieStatiiDeLucruUtilizatori listaRetur = new BColectieStatiiDeLucruUtilizatori();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DStatiiDeLucruUtilizatori.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BStatiiDeLucruUtilizatori(dr));
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
                bool succesModificare = DStatiiDeLucruUtilizatori.UpdateById(getDictProprietatiModificate(), this.IdStatieDeLucru, this.IdUtilizator, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bPastreazaConectat.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bBlocheazaAccesul.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdUtilizator.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bPastreazaConectat.ToString()))
                dictRezultat.Adauga(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bPastreazaConectat.ToString(), this.PastreazaConectat, false);
            if (this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bBlocheazaAccesul.ToString()))
                dictRezultat.Adauga(DStatiiDeLucruUtilizatori.EnumCampuriTabela.bBlocheazaAccesul.ToString(), this.BlocheazaAccesul, false);
            if (this.IsMyDataRowItemHasChanged(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdUtilizator.ToString()))
                dictRezultat.Adauga(DStatiiDeLucruUtilizatori.EnumCampuriTabela.xnIdUtilizator.ToString(), this.IdUtilizator);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.IdStatieDeLucru <= 0)
                throw new IdentificareBazaImposibilaException("BStatiiDeLucruUtilizatori");

            if (this.IdUtilizator <= 0)
                throw new IdentificareBazaImposibilaException("BStatiiDeLucruUtilizatori");

            FillObjectWithDataRow<BStatiiDeLucruUtilizatori>(GetDataRowForObjet(this.IdStatieDeLucru, this.IdUtilizator, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DStatiiDeLucruUtilizatori></DStatiiDeLucruUtilizatori>");

            //Adaugam elementele clasei BStatiiDeLucruUtilizatori
            myXmlElem = myXmlDoc.CreateElement("IDSTATIEDELUCRU");
            myXmlElem.InnerText = Convert.ToString(this.IdStatieDeLucru);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PASTREAZACONECTAT");
            myXmlElem.InnerText = Convert.ToString(this.PastreazaConectat);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("BLOCHEAZAACCESUL");
            myXmlElem.InnerText = Convert.ToString(this.BlocheazaAccesul);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("STATIEBLOCATA");
            myXmlElem.InnerText = Convert.ToString(this.StatieBlocata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDSTATIE");
            myXmlElem.InnerText = this.IdStatie;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTSTOMA");
            myXmlElem.InnerText = this.ContStoma;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PAROLASTOMA");
            myXmlElem.InnerText = this.ParolaStoma;
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

        public static int ComparaDupaNume(BStatiiDeLucruUtilizatori xElemLista1, BStatiiDeLucruUtilizatori xElemLista2)
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
                    return xElemLista1.Nume.CompareTo(xElemLista2.Nume);
            }
        }

        #endregion //Metode de comparatie

    }

}