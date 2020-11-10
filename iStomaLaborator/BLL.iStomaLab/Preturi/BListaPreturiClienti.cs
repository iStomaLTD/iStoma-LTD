using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Preturi;
using ILL.iStomaLab;
using ILL.General.Interfete;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;

namespace BLL.iStomaLab.Preturi
{
    /// <summary>
    /// Clasa pentru gestionarea listei de preturi negociata cu fiecare client
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BListaPreturiClienti : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int MotivInchidereMaxLength = 500;
            public const int DenumireMaxLength = 250;
            public const int DenumireClientMaxLength = 50;
            public const int DenumireCategorieMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DListaPreturiClienti.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdListaPreturi", true, 1)]
        public int IdListaPreturi
        {
            get { return this.MyDataRowGetItemAsInteger(DListaPreturiClienti.EnumCampuriTabela.xnIdListaPreturi.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DListaPreturiClienti.EnumCampuriTabela.xnIdClient.ToString()); }
        }

        [BExport("ValoareRON", true, 1)]
        public double ValoareRON
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiClienti.EnumCampuriTabela.nValoareRON.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiClienti.EnumCampuriTabela.nValoareRON.ToString(), value); }
        }

        [BExport("ValoareEUR", true, 1)]
        public double ValoareEUR
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiClienti.EnumCampuriTabela.nValoareEUR.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiClienti.EnumCampuriTabela.nValoareEUR.ToString(), value); }
        }

        [BExport("TermenAgreat", true, 1)]
        public int TermenAgreat
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DListaPreturiClienti.EnumCampuriTabela.nTermenAgreat.ToString()); }
            set { this.MyDataRowSetItem(DListaPreturiClienti.EnumCampuriTabela.nTermenAgreat.ToString(), value); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DListaPreturiClienti.EnumCampuriTabela.tDenumire.ToString()); }
        }

        [BExport("IdCategorie", true, 1)]
        public int IdCategorie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DListaPreturiClienti.EnumCampuriTabela.xnIdCategorie.ToString()); }
        }

        [BExport("ValoareRONStandard", true, 1)]
        public double ValoareRONStandard
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiClienti.EnumCampuriTabela.nValoareRONStandard.ToString()); }
        }

        [BExport("ValoareEURStandard", true, 1)]
        public double ValoareEURStandard
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DListaPreturiClienti.EnumCampuriTabela.nValoareEURStandard.ToString()); }
        }

        [BExport("DenumireClient", true, 1)]
        public string DenumireClient
        {
            get { return this.MyDataRowGetItem(DListaPreturiClienti.EnumCampuriTabela.tDenumireClient.ToString()); }
        }

        [BExport("DenumireCategorie", true, 1)]
        public string DenumireCategorie
        {
            get { return this.MyDataRowGetItem(DListaPreturiClienti.EnumCampuriTabela.tDenumireCategorie.ToString()); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ListaPreturiClientiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ListaPreturiClienti; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BListaPreturiClienti(int pId)
        : this(pId, null)
        {
        }

        public BListaPreturiClienti(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BListaPreturiClienti>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BListaPreturiClienti(DataRow pMyRow)
        {
            FillObjectWithDataRow<BListaPreturiClienti>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static void AplicaDiscount(int pIdClinica, List<Tuple<BListaPreturiStandard, BListaPreturiClienti>> pListaPreturiActuale, double pValDiscount)
        {
            if(!CUtil.EsteListaVida<Tuple<BListaPreturiStandard, BListaPreturiClienti>>(pListaPreturiActuale))
            {
                foreach (var item in pListaPreturiActuale)
                {
                    if(item.Item2 != null)
                    {
                        item.Item2.UpdatePret(CUtil.GetValoareAjustata(item.Item1.GetValoare(), pValDiscount)); 
                    }
                    else
                    {
                        BListaPreturiClienti.Add(item.Item1.Id, pIdClinica, CUtil.GetValoareAjustata(item.Item1.GetValoare(), pValDiscount), item.Item1.GetMoneda(), 0, null);
                    }
                }
            }
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DListaPreturiClienti
        /// </summary>
        /// <param name="pIdListaPreturi"></param>
        /// <param name="pIdClient"></param>
        /// <param name="pValoareRON"></param>
        /// <param name="pValoareEUR"></param>
        /// <param name="pTermenAgreat"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdListaPreturi, int pIdClient, double pValoare, CDefinitiiComune.EnumTipMoneda pMoneda, int pTermenAgreat, IDbTransaction pTranzactie)
        {
            double pValoareEUR = 0;
            double pValoareRON = 0;
            if (pMoneda == CDefinitiiComune.EnumTipMoneda.Euro)
                pValoareEUR = pValoare;
            else
                pValoareRON = pValoare;

            int id = DListaPreturiClienti.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdListaPreturi, pIdClient, pValoareRON, pValoareEUR, pTermenAgreat, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdListaPreturi, int pIdClient, double pValoareRON, double pValoareEUR, int pTermenAgreat)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BListaPreturiClienti
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieListaPreturiClienti GetListByParam(int pIdListaPreturi, int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiClienti lstDListaPreturiClienti = new BColectieListaPreturiClienti();
            using (DataSet ds = DListaPreturiClienti.GetListByParam(pIdListaPreturi, pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiClienti.Add(new BListaPreturiClienti(dr));
                }
            }
            return lstDListaPreturiClienti;
        }

        public static BColectieListaPreturiClienti GetListByParam(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiClienti lstDListaPreturiClienti = new BColectieListaPreturiClienti();
            using (DataSet ds = DListaPreturiClienti.GetListByParam(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiClienti.Add(new BListaPreturiClienti(dr));
                }
            }
            return lstDListaPreturiClienti;
        }

        public static BListaPreturiClienti GetPretClient(int pIdListaPreturi, int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BListaPreturiClienti lstDListaPreturiClienti = null;
            using (DataSet ds = DListaPreturiClienti.GetListByParam(pIdListaPreturi, pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiClienti = new BListaPreturiClienti(dr);
                }
            }
            return lstDListaPreturiClienti;
        }

        public static BListaPreturiClienti GetPretClientIdLucrare(int pIdListaPreturi, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BListaPreturiClienti lstDListaPreturiClienti = null;
            using (DataSet ds = DListaPreturiClienti.GetListByParam(pIdListaPreturi, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiClienti = new BListaPreturiClienti(dr);
                }
            }
            return lstDListaPreturiClienti;
        }

        public static BColectieListaPreturiClienti GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiClienti lstDListaPreturiClienti = new BColectieListaPreturiClienti();
            using (DataSet ds = DListaPreturiClienti.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaPreturiClienti.Add(new BListaPreturiClienti(dr));
                }
            }
            return lstDListaPreturiClienti;
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
                throw new IdentificareBazaImposibilaException("BListaPreturiClienti");
            using (DataSet ds = DListaPreturiClienti.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BListaPreturiClienti");
            }
        }

        public static BColectieListaPreturiClienti getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieListaPreturiClienti listaRetur = new BColectieListaPreturiClienti();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DListaPreturiClienti.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BListaPreturiClienti(dr));
                    }
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public double GetAjustare()
        {
            double pretLista = this.GetValoareStandard();
            double pretNegociat = this.GetValoareClient();
            double diferenta = pretLista - pretNegociat;

            return CUtil.GetProcentDinTotal(diferenta, pretLista);
        }

        public string GetEtichetaAjustare()
        {
            double ajustare = GetAjustare();

            if (ajustare == 0)
                return string.Empty;

            return CUtil.GetValoareMonetara(ajustare);
        }

        public double GetValoareStandard()
        {
            if (GetMoneda() == CDefinitiiComune.EnumTipMoneda.Lei)
                return this.ValoareRONStandard;

            return this.ValoareEURStandard;
        }

        public CDefinitiiComune.EnumTipMoneda GetMonedaClient()
        {
            if (this.ValoareEUR > 0)
                return CDefinitiiComune.EnumTipMoneda.Euro;

            return CDefinitiiComune.EnumTipMoneda.Lei;
        }

        public int GetIdMoneda()
        {
            if (this.ValoareEUR > 0)
                return CStructuriComune.StructTipMoneda.GetStructByEnum(CDefinitiiComune.EnumTipMoneda.Euro).IdInt;

            return CStructuriComune.StructTipMoneda.GetStructByEnum(CDefinitiiComune.EnumTipMoneda.Lei).IdInt;
        }

        public string GetEtichetaMoneda()
        {
            return CStructuriComune.StructTipMoneda.GetStringByEnum(GetMoneda());
        }

        public bool UpdatePret(double pTotal)
        {
            if (getMonedaPretStandard() == CDefinitiiComune.EnumTipMoneda.Lei)
            {
                this.ValoareRON = pTotal;
                this.ValoareEUR = 0;
            }
            else
            {
                this.ValoareRON = 0;
                this.ValoareEUR = pTotal;
            }

            return this.UpdateAll();
        }

        private CDefinitiiComune.EnumTipMoneda getMonedaPretStandard()
        {
            if (this.ValoareEURStandard > 0)
                return CDefinitiiComune.EnumTipMoneda.Euro;

            return CDefinitiiComune.EnumTipMoneda.Lei;
        }

        public double GetValoareClient()
        {
            if (GetMoneda() == CDefinitiiComune.EnumTipMoneda.Lei)
                return this.ValoareRON;

            return this.ValoareEUR;
        }

        public CDefinitiiComune.EnumTipMoneda GetMoneda()
        {
            if (this.ValoareEUR > 0)
                return CDefinitiiComune.EnumTipMoneda.Euro;

            return CDefinitiiComune.EnumTipMoneda.Lei;
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
                bool succesModificare = DListaPreturiClienti.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nValoareRON.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nValoareEUR.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nTermenAgreat.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BListaPreturiClienti");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DListaPreturiClienti.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nValoareRON.ToString()))
                dictRezultat.Adauga(DListaPreturiClienti.EnumCampuriTabela.nValoareRON.ToString(), this.ValoareRON);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nValoareEUR.ToString()))
                dictRezultat.Adauga(DListaPreturiClienti.EnumCampuriTabela.nValoareEUR.ToString(), this.ValoareEUR);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.nTermenAgreat.ToString()))
                dictRezultat.Adauga(DListaPreturiClienti.EnumCampuriTabela.nTermenAgreat.ToString(), this.TermenAgreat);
            if (this.IsMyDataRowItemHasChanged(DListaPreturiClienti.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DListaPreturiClienti.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BListaPreturiClienti");

            FillObjectWithDataRow<BListaPreturiClienti>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DListaPreturiClienti></DListaPreturiClienti>");

            //Adaugam elementele clasei BListaPreturiClienti
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLISTAPRETURI");
            myXmlElem.InnerText = Convert.ToString(this.IdListaPreturi);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOARERON");
            myXmlElem.InnerText = Convert.ToString(this.ValoareRON);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOAREEUR");
            myXmlElem.InnerText = Convert.ToString(this.ValoareEUR);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TERMENAGREAT");
            myXmlElem.InnerText = Convert.ToString(this.TermenAgreat);
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

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCATEGORIE");
            myXmlElem.InnerText = Convert.ToString(this.IdCategorie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOARERONSTANDARD");
            myXmlElem.InnerText = Convert.ToString(this.ValoareRONStandard);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOAREEURSTANDARD");
            myXmlElem.InnerText = Convert.ToString(this.ValoareEURStandard);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRECLIENT");
            myXmlElem.InnerText = this.DenumireClient;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRECATEGORIE");
            myXmlElem.InnerText = this.DenumireCategorie;
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

        public static int ComparaDupaNume(BListaPreturiClienti xElemLista1, BListaPreturiClienti xElemLista2)
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