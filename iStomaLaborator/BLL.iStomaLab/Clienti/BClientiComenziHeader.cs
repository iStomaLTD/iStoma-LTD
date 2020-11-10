using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Preturi;
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
using static BLL.iStomaLab.Clienti.BClientiComenziEtape;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea liniilor comenzilor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiComenziHeader : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale

        private static Dictionary<int, BClientiComenziHeader> _lDictComenzi = new Dictionary<int, BClientiComenziHeader>();

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumePacientMaxLength = 50;
            public const int PrenumePacientMaxLength = 50;
            public const int MotivInchidereMaxLength = 500;
            public const int CuloareLucrareMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenziHeader.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenziHeader.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        public string DenumireClinica
        {
            get { return this.MyDataRowGetItem(DClientiComenziHeader.EnumCampuriTabela.tDenumireClinica.ToString()); }
        }
        
        [BExport("IdCabinet", true, 1)]
        public int IdCabinet
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString(), value); }
        }

        public string DenumireCabinet
        {
            get { return this.MyDataRowGetItem(DClientiComenziHeader.EnumCampuriTabela.tDenumireCabinet.ToString()); }
        }
        
        [BExport("IdPacient", true, 1)]
        public int IdPacient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziHeader.EnumCampuriTabela.xnIdPacient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.xnIdPacient.ToString(), value); }
        }
        
        [BExport("IdReprezentantClient", true, 1)]
        public int IdReprezentantClient  //Medicul
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziHeader.EnumCampuriTabela.xnIdReprezentantClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.xnIdReprezentantClient.ToString(), value); }
        }

        public string CodComanda
        {
            get { return this.MyDataRowGetItem(DClientiComenziHeader.EnumCampuriTabela.tCodComanda.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.tCodComanda.ToString(), value); }
        }       
        public DateTime DataInceputEtapa
        {
        get { return this.MyDataRowGetItemAsDateNull(DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString()); }
        }
 
        public DateTime DataSfarsitEtapa
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString()); }
        }


        [BExport("DataPrimire", true, 1)]
        public DateTime DataPrimire
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString(), value); }
        }

        [BExport("DataLaGata", true, 1)]
        public DateTime DataLaGata
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiComenziHeader.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziHeader.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

      
        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiComenziMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiComenzi; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiComenziHeader(int pId) 
        : this(pId, null)
        {
        }

        public BClientiComenziHeader(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiComenziHeader>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiComenziHeader(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiComenziHeader>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiComenziHeader
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pIdCabinet"></param>     
        /// <param name="pIdPacient"></param>
        /// <param name="pIdReprezentantClient"></param>        
        /// <param name="pObservatii"></param>
        /// <param name="pCodComanda"></param>
        /// <param name="pDataCreare"></param>
        /// <param name="pDataInchidere"></param>
        /// <param name="pnUtilizatorCreare"></param>
        /// <param name="pnUtilizatorInchidere"></param>
        /// <param name="pMotivInchidere"></param>
        /// <param name="pObservatii"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        public static int Add(int pIdClient, int pIdCabinet, int pIdReprezentantClient, int pIdPacient, string pCodComanda,  string pMotivInchidere, string pObservatii,  IDbTransaction pTranzactie)
        {
            int id = DClientiComenziHeader.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pIdCabinet, pIdReprezentantClient, pIdPacient, pCodComanda, pMotivInchidere, pObservatii, pTranzactie);

            return id;
        }
        
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiComenzi
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BClientiComenziHeader getById(int pId, IDbTransaction pTranzactie)
        {
            return new BClientiComenziHeader(pId, pTranzactie);
        }


        public static bool SuntInformatiileNecesareCoerente(int pIdClient)
        {
            return pIdClient != 0;
        }

        /// <summary>
        /// Recuperam Clientul/Clinica comenzii selectate
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pTranzactie"></param>
        /// <returns></returns>
        public static BClientiComenziHeader GetIdClient(int pId, IDbTransaction pTranzactie)
        {
            using (DataSet ds = DClientiComenziHeader.GetIdClient(pId, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    return new BClientiComenziHeader(dr);
                }
            }
            return null;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiComenzi
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiComenziHeader GetListByParam(int pIdClient, int pIdReprezentant, int pIdCabinet, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziHeader lstDClientiComenzi = new BColectieClientiComenziHeader();
            using (DataSet ds = DClientiComenziHeader.GetListByParam(pIdClient, pIdReprezentant, pIdCabinet, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenziHeader(dr));
                }
            }
            return lstDClientiComenzi;
        }
               
        /// <summary>
        /// Recuperam ultima lucrare primita de la o clinica anume
        /// </summary>
        /// <param name="pIdClinica"></param>
        /// <param name="pTranzactie"></param>
        /// <returns></returns>
        public static BClientiComenziHeader GetUltimaLucrare(int pIdClinica, IDbTransaction pTranzactie)
        {
            using (DataSet ds = DClientiComenziHeader.GetUltimaLucrare(pIdClinica, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    return new BClientiComenziHeader(dr);
                }
            }
            return null;
        }

        public static BColectieClientiComenziHeader GetListByParamIntrePerioada(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziHeader lstDClientiComenzi = new BColectieClientiComenziHeader();
            using (DataSet ds = DClientiComenziHeader.GetListByParamSiPerioada(getDataInteres(pDataInteres), pIdTehnician, pDataInceput, pDataSfarsit, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenzi.Add(new BClientiComenziHeader(dr));
                }
            }
            return lstDClientiComenzi;
        }

        public static BColectieClientiComenziHeader GetUltimeleLucrariPerClinica(IDbTransaction pTranzactie)
        {
            BColectieClientiComenziHeader listaRetur = new BColectieClientiComenziHeader();

            using (DataSet ds = DClientiComenziHeader.GetUltimeleLucrariPerClinica(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new BClientiComenziHeader(dr));
                }
            }

            return listaRetur;
        }

        private static string getDataInteres(BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres)
        {
            switch (pDataInteres)
            {
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare:
                    return DClientiComenziHeader.EnumCampuriTabela.dDataCreare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire:
                    return DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataLaGata:
                    return DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataTermen:
                    return DClientiComenziHeader.EnumCampuriTabela.dDataInchidere.ToString();
            }
            return DClientiComenziHeader.EnumCampuriTabela.dDataCreare.ToString();
        }

     
        public BClientiComenziHeader GetPacient()
        {
            return new BClientiComenziHeader(this.IdPacient);
        }


        public static BClientiComenziHeader getComanda(int lId, IDbTransaction xTrans)
        {
            if (_lDictComenzi == null)
                _lDictComenzi = new Dictionary<int, BClientiComenziHeader>();

            if (!_lDictComenzi.ContainsKey(lId))
                _lDictComenzi.Add(lId, new BClientiComenziHeader(lId, xTrans));

            return _lDictComenzi[lId];
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
                throw new IdentificareBazaImposibilaException("BClientiComenziHeader");
            using (DataSet ds = DClientiComenziHeader.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiComenziHeader");
            }
        }
        #endregion //Metode de clasa


        #region Metode de instanta

        public string GetDenumireClinicaCabinet()
        {
            if (string.IsNullOrEmpty(this.DenumireCabinet))
                return this.DenumireClinica;

            return string.Format("{0} - {1}", this.DenumireClinica, this.DenumireCabinet);
        }
      
        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public override bool UpdateAll(IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = false;

                if (!this.ExistaProprietatiModificate())
                    succesModificare = true;
                else
                    succesModificare = DClientiComenziHeader.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
       
        public bool UpdateAll(int pIdClient, int pIdCabinet, int pIdReprezentantClient, int pIdPacient,  DateTime pDataCreare, DateTime pDataInchidere, string pCodComanda, string pObservatii, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = false;               

                if (!this.ExistaProprietatiModificate())
                    succesModificare = true;
                else
                    succesModificare = DClientiComenziHeader.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdClient.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdReprezentantClient.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdPacient.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tObservatii.ToString()) ||
                   this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tCodComanda.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiComenziHeader");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
               DClientiComenziHeader.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdReprezentantClient.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.xnIdReprezentantClient.ToString(), this.IdReprezentantClient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString(), this.IdCabinet);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdPacient.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.xnIdPacient.ToString(), this.IdPacient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.dDataPrimire.ToString(), this.DataPrimire);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.dDataLaGata.ToString(), this.DataLaGata);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.xnIdCabinet.ToString(), this.IdCabinet);     
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);       
            if (this.IsMyDataRowItemHasChanged(DClientiComenziHeader.EnumCampuriTabela.tCodComanda.ToString()))
                dictRezultat.Adauga(DClientiComenziHeader.EnumCampuriTabela.tCodComanda.ToString(), this.CodComanda);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiComenziHeader");

            FillObjectWithDataRow<BClientiComenziHeader>(GetDataRowForObjet(this.Id, pTranzactie), this);
        }
        
        public BClienti GetClient()
        {
            return new BClienti(this.IdClient);
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
            myXmlDoc.LoadXml("<DClientiComenziHeader></DClientiComenziHeader>");

            //Adaugam elementele clasei BClientiComenziHeader
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDREPREZENTANTCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdReprezentantClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAPRIMIRE");
            myXmlElem.InnerText = Convert.ToString(this.DataPrimire);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATALAGATA");
            myXmlElem.InnerText = Convert.ToString(this.DataLaGata);
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

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCABINET");
            myXmlElem.InnerText = Convert.ToString(this.IdCabinet);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDPACIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdPacient);
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
