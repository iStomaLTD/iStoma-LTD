using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Utilizatori;
using ILL.BLL.General;
using ILL.General.Interfete;
using ILL.iStomaLab;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea modalitatii de plata a personalului
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BUtilizatoriVenituri : BGestiuneCMI, IDisposable, ICheie, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int MotivInchidereMaxLength = 500;
            public const int ObservatiiMaxLength = 500;
        }

        #endregion // StructCampuriTabela

        #region EnumTipVenit + StructTipVenit

        public enum EnumTipVenit
        {
            Nedefinit = 0,
            /// <summary>
            /// Salariu fix
            /// </summary>
            SalariuFix = 1,
            /// <summary>
            /// Pret fix pe etapa
            /// </summary>
            PretFixPeEtapa = 2
        }

        public sealed class ColectieStructTipVenit : List<StructTipVenit>
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }

        }

        public struct StructTipVenit : ICheie
        {
            #region Declaratii generale

            public EnumTipVenit IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructTipVenit Empty { get { return new StructTipVenit(EnumTipVenit.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTipVenit(EnumTipVenit pId, string pNume)
                : this()
            {
                this.IdEnum = pId;
                this.Nume = pNume;
            }

            #endregion //Constructori

            #region Metode suprascise

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                else
                    if (obj is EnumTipVenit || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTipVenit)obj);
                else
                        if (obj is StructTipVenit)
                    return this.IdEnum.Equals(((StructTipVenit)obj).IdEnum);
                else
                            if (obj is string)
                    return Convert.ToString(obj).Equals(this.Nume);
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion //Metode suprascise

            #region Metode Publice

            public static ColectieStructTipVenit GetList()
            {
                ColectieStructTipVenit lstStruct = new ColectieStructTipVenit();
                //lstStruct.Add(GetStructByEnum(EnumTipVenit.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumTipVenit.SalariuFix));
                lstStruct.Add(GetStructByEnum(EnumTipVenit.PretFixPeEtapa));
                return lstStruct;
            }

            public static EnumTipVenit GetEnumByString(string pNume)
            {
                EnumTipVenit lId = EnumTipVenit.Nedefinit;
                foreach (StructTipVenit xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipVenit pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipVenit GetStructByEnum(EnumTipVenit pId)
            {
                switch (pId)
                {
                    case EnumTipVenit.SalariuFix:
                        return new StructTipVenit(EnumTipVenit.SalariuFix, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SalariuFix));
                    case EnumTipVenit.PretFixPeEtapa:
                        return new StructTipVenit(EnumTipVenit.PretFixPeEtapa, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PretFixPeEtapa));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumTipVenit.Nedefinit;
            }

            #endregion //Metode Publice

        }
              

        #endregion //EnumTipVenit + StructTipVenit

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituri.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdUtilizator", true, 1)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituri.EnumCampuriTabela.xnIdUtilizator.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.xnIdUtilizator.ToString(), value); }
        }

        [BExport("DataInceput", true, 1)]
        public DateTime DataInceput
        {
            get { return this.MyDataRowGetItemAsDate(DUtilizatoriVenituri.EnumCampuriTabela.dDataInceput.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.dDataInceput.ToString(), value); }
        }

        [BExport("DataFinal", true, 1)]
        public DateTime DataFinal
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizatoriVenituri.EnumCampuriTabela.dDataFinal.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.dDataFinal.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DUtilizatoriVenituri.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        [BExport("TipVenit", true, 1)]
        public EnumTipVenit TipVenit
        {
            get { return (EnumTipVenit)this.MyDataRowGetItemAsIntegerNull(DUtilizatoriVenituri.EnumCampuriTabela.nTipVenit.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.nTipVenit.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("SalariuFix", true, 1)]
        public double SalariuFix
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DUtilizatoriVenituri.EnumCampuriTabela.nSalariuFix.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituri.EnumCampuriTabela.nSalariuFix.ToString(), value); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DUtilizatoriVenituri.EnumCampuriTabela.tNume.ToString()); }
        }

        [BExport("Prenume", true, 1)]
        public string Prenume
        {
            get { return this.MyDataRowGetItem(DUtilizatoriVenituri.EnumCampuriTabela.tPrenume.ToString()); }
        }

        [BExport("ContStoma", true, 1)]
        public string ContStoma
        {
            get { return this.MyDataRowGetItem(DUtilizatoriVenituri.EnumCampuriTabela.tContStoma.ToString()); }
        }

        [BExport("NumarOrdine", true, 1)]
        public int NumarOrdine
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizatoriVenituri.EnumCampuriTabela.nNumarOrdine.ToString()); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.Nedefinita; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.DeInlocuit; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BUtilizatoriVenituri(int pId)
        : this(pId, null)
        {
        }

        public BUtilizatoriVenituri(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BUtilizatoriVenituri>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BUtilizatoriVenituri(DataRow pMyRow)
        {
            FillObjectWithDataRow<BUtilizatoriVenituri>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DUtilizatoriVenituri
        /// </summary>
        /// <param name="pIdUtilizator"></param>
        /// <param name="pDataInceput"></param>
        /// <param name="pDataFinal"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pTipVenit"></param>
        /// <param name="pSalariuFix"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdUtilizator, DateTime pDataInceput, DateTime pDataFinal, string pObservatii, EnumTipVenit pTipVenit, double pSalariuFix, Dictionary<int, double> pDictIdEtapaPret, IDbTransaction pTranzactie)
        {
            IDbTransaction Tranzactie = null;
            int id = 0;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCL.DAL.CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;

                id = DUtilizatoriVenituri.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdUtilizator, pDataInceput, pDataFinal, pObservatii, Convert.ToInt32(pTipVenit), pSalariuFix, Tranzactie);

                if (pDictIdEtapaPret != null)
                {
                    foreach (var item in pDictIdEtapaPret)
                    {
                        BUtilizatoriVenituriDetalii.Add(id, item.Key, item.Value, Tranzactie);
                    }
                }

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCL.DAL.CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }

            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdUtilizator, DateTime pDataInceput, DateTime pDataFinal, string pObservatii, int pTipVenit, double pSalariuFix)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BUtilizatoriVenituri
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieUtilizatoriVenituri GetListByParam(int pIdUtilizator, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituri lstDUtilizatoriVenituri = new BColectieUtilizatoriVenituri();
            using (DataSet ds = DUtilizatoriVenituri.GetListByParam(pIdUtilizator, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatoriVenituri.Add(new BUtilizatoriVenituri(dr));
                }
            }
            return lstDUtilizatoriVenituri;
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
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituri");
            using (DataSet ds = DUtilizatoriVenituri.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BUtilizatoriVenituri");
            }
        }

        public static BColectieUtilizatoriVenituri getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituri listaRetur = new BColectieUtilizatoriVenituri();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DUtilizatoriVenituri.GetByListaId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BUtilizatoriVenituri(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieUtilizatoriVenituri getById(int pId, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituri listaRetur = new BColectieUtilizatoriVenituri();
            if (pId > 0)
            {
                using (DataSet ds = DUtilizatoriVenituri.GetById(pId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BUtilizatoriVenituri(dr));
                    }
                }
            }
            return listaRetur;
        }


        #endregion //Metode de clasa

        #region Metode de instanta

        public override string ToString()
        {
            return StructTipVenit.GetStringByEnum(this.TipVenit);
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
                bool succesModificare = DUtilizatoriVenituri.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.xnIdUtilizator.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.dDataInceput.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.dDataFinal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.nTipVenit.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.nSalariuFix.ToString());
        }

        public bool EsteActivInPerioada(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            //1. Venitul nu mai este activ in prezent
            if(this.DataFinal != CConstante.DataNula)
            {
                return pDataSfarsit > this.DataInceput && pDataInceput < this.DataFinal;
            }
            else
            {
                //2. Venitul este activ in momentul de fata
                return pDataSfarsit > this.DataInceput;
            }

            //return this.DataInceput <= pDataInceput && (this.DataFinal == CConstante.DataNula || this.DataFinal >= pDataSfarsit);
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
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituri");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DUtilizatoriVenituri.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.xnIdUtilizator.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.xnIdUtilizator.ToString(), this.IdUtilizator);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.dDataInceput.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.dDataInceput.ToString(), this.DataInceput);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.dDataFinal.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.dDataFinal.ToString(), this.DataFinal);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.nTipVenit.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.nTipVenit.ToString(), Convert.ToInt32(this.TipVenit));
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituri.EnumCampuriTabela.nSalariuFix.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituri.EnumCampuriTabela.nSalariuFix.ToString(), this.SalariuFix);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituri");

            FillObjectWithDataRow<BUtilizatoriVenituri>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DUtilizatoriVenituri></DUtilizatoriVenituri>");

            //Adaugam elementele clasei BUtilizatoriVenituri
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCEPUT");
            myXmlElem.InnerText = Convert.ToString(this.DataInceput);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAFINAL");
            myXmlElem.InnerText = Convert.ToString(this.DataFinal);
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

            myXmlElem = myXmlDoc.CreateElement("TIPVENIT");
            myXmlElem.InnerText = Convert.ToString(this.TipVenit);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SALARIUFIX");
            myXmlElem.InnerText = Convert.ToString(this.SalariuFix);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PRENUME");
            myXmlElem.InnerText = this.Prenume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTSTOMA");
            myXmlElem.InnerText = this.ContStoma;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARORDINE");
            myXmlElem.InnerText = Convert.ToString(this.NumarOrdine);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;
            else
                if (obj is int || obj is long)
                return this.Id.Equals(Convert.ToInt32(obj));
            else
                    if (obj is BUtilizatoriVenituri)
                return this.Id.Equals((obj as BUtilizatoriVenituri).Id);
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BUtilizatoriVenituri xElemLista1, BUtilizatoriVenituri xElemLista2)
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