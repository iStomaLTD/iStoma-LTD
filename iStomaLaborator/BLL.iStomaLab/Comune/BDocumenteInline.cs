using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Comune;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.iStomaLab.Comune
{
    /// <summary>
    /// Clasa pentru gestionarea documentelor salvate direct in baza de date (Ex: Imaginile medicilor pentru Mobile App)
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BDocumenteInline : BGestiuneCMI, IDisposable, ICheie
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

        #region EnumTipDocumentInline + StructTipDocumentInline

        public enum EnumTipDocumentInline
        {
            Nedefinit = 0,
            /// <summary>
            /// Imagine profil medic
            /// </summary>
            ImagineProfilMedic = 1,
            CVCompletPDF = 2,
            LogoSediu = 3
        }

        public sealed class ColectieStructTipDocumentInline : List<StructTipDocumentInline>, IAfisaj
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.StructTipDocumentInline; } }
        }

        public struct StructTipDocumentInline
        {
            #region Declaratii generale

            public EnumTipDocumentInline IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructTipDocumentInline Empty { get { return new StructTipDocumentInline(EnumTipDocumentInline.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTipDocumentInline(EnumTipDocumentInline pId, string pNume)
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
                    if (obj is EnumTipDocumentInline || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTipDocumentInline)obj);
                else
                        if (obj is StructTipDocumentInline)
                    return this.IdEnum.Equals(((StructTipDocumentInline)obj).IdEnum);
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

            public static ColectieStructTipDocumentInline GetList()
            {
                ColectieStructTipDocumentInline lstStruct = new ColectieStructTipDocumentInline();
                lstStruct.Add(GetStructByEnum(EnumTipDocumentInline.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumTipDocumentInline.ImagineProfilMedic));
                return lstStruct;
            }

            public static EnumTipDocumentInline GetEnumByString(string pNume)
            {
                EnumTipDocumentInline lId = EnumTipDocumentInline.Nedefinit;
                foreach (StructTipDocumentInline xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipDocumentInline pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipDocumentInline GetStructByEnum(EnumTipDocumentInline pId)
            {
                switch (pId)
                {
                    case EnumTipDocumentInline.ImagineProfilMedic:
                        return new StructTipDocumentInline(EnumTipDocumentInline.ImagineProfilMedic, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ImagineIdentitate));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumTipDocumentInline.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #endregion //EnumTipDocumentInline + StructTipDocumentInline

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DDocumenteInline.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("TipObiect", true, 1)]
        public int TipObiect
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DDocumenteInline.EnumCampuriTabela.nTipObiect.ToString()); }
            set { this.MyDataRowSetItem(DDocumenteInline.EnumCampuriTabela.nTipObiect.ToString(), value); }
        }

        [BExport("IdObiect", true, 1)]
        public int IdObiect
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DDocumenteInline.EnumCampuriTabela.xnIdObiect.ToString()); }
            set { this.MyDataRowSetItem(DDocumenteInline.EnumCampuriTabela.xnIdObiect.ToString(), value); }
        }

        [BExport("TipImagine", true, 1)]
        public EnumTipDocumentInline TipImagine
        {
            get { return (EnumTipDocumentInline)this.MyDataRowGetItemAsIntegerNull(DDocumenteInline.EnumCampuriTabela.nTipImagine.ToString()); }
            set { this.MyDataRowSetItem(DDocumenteInline.EnumCampuriTabela.nTipImagine.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("Imagine", true, 1)]
        public byte[] Imagine
        {
            get { return this.MyDataRowGetItemAsByteList(DDocumenteInline.EnumCampuriTabela.nImagine.ToString()); }
            set { this.MyDataRowSetItem(DDocumenteInline.EnumCampuriTabela.nImagine.ToString(), value); }
        }

        [BExport("InformatiiComplementare", true, 1)]
        public string InformatiiComplementare
        {
            get { return this.MyDataRowGetItem(DDocumenteInline.EnumCampuriTabela.tInformatiiComplementare.ToString()); }
            set { this.MyDataRowSetItem(DDocumenteInline.EnumCampuriTabela.tInformatiiComplementare.ToString(), value); }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.DocumenteInline; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BDocumenteInline(int pId)
        : this(pId, null)
        {
        }

        public BDocumenteInline(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BDocumenteInline>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BDocumenteInline(DataRow pMyRow)
        {
            FillObjectWithDataRow<BDocumenteInline>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DDocumenteInline
        /// </summary>
        /// <param name="pTipObiect"></param>
        /// <param name="pIdObiect"></param>
        /// <param name="pTipImagine"></param>
        /// <param name="pImagine"></param>
        /// <param name="pInformatiiComplementare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect, EnumTipDocumentInline pTipImagine, byte[] pImagine, string pInformatiiComplementare, IDbTransaction pTranzactie)
        {
            int id = DDocumenteInline.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pTipObiect, pIdObiect, Convert.ToInt32(pTipImagine), pImagine, pInformatiiComplementare, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pTipObiect, int pIdObiect, int pTipImagine, byte[] pImagine, string pInformatiiComplementare)
        {
            bool esteOK = true;

            return esteOK;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BDocumenteInline
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieDocumenteInline GetListByParam(CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect, EnumTipDocumentInline pTipImagine, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieDocumenteInline lstDDocumenteInline = new BColectieDocumenteInline();
            using (DataSet ds = DDocumenteInline.GetListByParam(pTipObiect, pIdObiect, Convert.ToInt32(pTipImagine), pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDDocumenteInline.Add(new BDocumenteInline(dr));
                }
            }
            return lstDDocumenteInline;
        }

        public static BDocumenteInline GetLogoSediuMobileAPP(int pIdSediu, IDbTransaction pTranzactie)
        {
            BColectieDocumenteInline listaDoc = BDocumenteInline.GetListByParam(Locatii.BLocatii.TipObiectClasa, pIdSediu, BDocumenteInline.EnumTipDocumentInline.LogoSediu, CDefinitiiComune.EnumStare.Activa, pTranzactie);

            if (!CUtil.EsteListaVida<BDocumenteInline>(listaDoc))
                return listaDoc[0];

            return null;
        }
        public static BDocumenteInline GetImagineProfilUtilizator(int pIdUser, IDbTransaction pTranzactie)
        {
            BColectieDocumenteInline listaDoc = BDocumenteInline.GetListByParam(BUtilizator.TipObiectClasa , pIdUser, BDocumenteInline.EnumTipDocumentInline.ImagineProfilMedic, CDefinitiiComune.EnumStare.Activa, pTranzactie);

            if (!CUtil.EsteListaVida<BDocumenteInline>(listaDoc))
                return listaDoc[0];

            return null;
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
                throw new IdentificareBazaImposibilaException("BDocumenteInline");
            using (DataSet ds = DDocumenteInline.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BDocumenteInline");
            }
        }

        public static BColectieDocumenteInline getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieDocumenteInline listaRetur = new BColectieDocumenteInline();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DDocumenteInline.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BDocumenteInline(dr));
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

        public bool UpdateImagine(byte[] pImagine, IDbTransaction pTranzactie)
        {
            DDocumenteInline.UpdateImagine(pImagine, this.Id, pTranzactie);

            this.Refresh(pTranzactie);

            return true;
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
                bool succesModificare = DDocumenteInline.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nTipObiect.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.xnIdObiect.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nTipImagine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nImagine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.tInformatiiComplementare.ToString());
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
            BUtilizator UserInchidere = BUtilizator.GetUtilizatorConectat();
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BDocumenteInline");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DDocumenteInline.CloseById(UserInchidere.Id, this.Id, pInchidere, pMotivInchidere, Tranzactie);

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

        /// <summary>
        /// Metoda de instanta ce permite stergerea obiectului din baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Delete(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BDocumenteInline");
            //Stergem obiectul din baza de date
            DDocumenteInline.DeleteById(this.Id, pTranzactie);
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
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nTipObiect.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.nTipObiect.ToString(), this.TipObiect);
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.xnIdObiect.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.xnIdObiect.ToString(), this.IdObiect);
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nTipImagine.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.nTipImagine.ToString(), Convert.ToInt32(this.TipImagine));
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.nImagine.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.nImagine.ToString(), this.Imagine);
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DDocumenteInline.EnumCampuriTabela.tInformatiiComplementare.ToString()))
                dictRezultat.Adauga(DDocumenteInline.EnumCampuriTabela.tInformatiiComplementare.ToString(), this.InformatiiComplementare);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BDocumenteInline");

            FillObjectWithDataRow<BDocumenteInline>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DDocumenteInline></DDocumenteInline>");

            //Adaugam elementele clasei BDocumenteInline
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPOBIECT");
            myXmlElem.InnerText = Convert.ToString(this.TipObiect);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDOBIECT");
            myXmlElem.InnerText = Convert.ToString(this.IdObiect);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPIMAGINE");
            myXmlElem.InnerText = Convert.ToString(this.TipImagine);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IMAGINE");
            myXmlElem.InnerText = Convert.ToString(this.Imagine);
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

            myXmlElem = myXmlDoc.CreateElement("INFORMATIICOMPLEMENTARE");
            myXmlElem.InnerText = this.InformatiiComplementare;
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
