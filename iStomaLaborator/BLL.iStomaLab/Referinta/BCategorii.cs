﻿using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CDL.iStomaLab;
using DAL.iStomaLab.Referinta;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab.Referinta
{
    [Serializable()]
    public sealed class BCategorii : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 50;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DCategorii.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DCategorii.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DCategorii.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("IdCategorie", true, 1)]
        public int IdCategorie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DCategorii.EnumCampuriTabela.xnIdCategorie.ToString()); }
            set { this.MyDataRowSetItem(DCategorii.EnumCampuriTabela.xnIdCategorie.ToString(), value); }
        }

        [BExport("Culoare", true, 1)]
        public int Culoare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DCategorii.EnumCampuriTabela.nCuloare.ToString()); }
            set { this.MyDataRowSetItem(DCategorii.EnumCampuriTabela.nCuloare.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.CategoriiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Categorii; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BCategorii(int pId)
        : this(pId, null)
        {
        }

        public BCategorii(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BCategorii>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BCategorii(DataRow pMyRow)
        {
            FillObjectWithDataRow<BCategorii>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DCategorii
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pIdCategorie"></param>
        /// <param name="pCuloare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, int pIdCategorie, int pCuloare, IDbTransaction pTranzactie)
        {
            int id = DCategorii.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pIdCategorie, pCuloare, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire)
        {
            return !string.IsNullOrEmpty(pDenumire);
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BCategorii
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieCategorii GetListByParam(
        CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCategorii lstDCategorii = new BColectieCategorii();
            using (DataSet ds = DCategorii.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDCategorii.Add(new BCategorii(dr));
                }
            }
            return lstDCategorii;
        }

        public static BColectieCategorii GetListByParamCategorii(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCategorii lstDCategorii = new BColectieCategorii();
            using (DataSet ds = DCategorii.GetListByParamCategorii(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDCategorii.Add(new BCategorii(dr));
                }
            }
            return lstDCategorii;
        }

        public static BColectieCategorii GetListByParamSubcategorii(int pIdCategorie, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieCategorii lstDSubcategorii = new BColectieCategorii();
            using (DataSet ds = DCategorii.GetListByParamSubcategorii(pIdCategorie, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDSubcategorii.Add(new BCategorii(dr));
                }
            }
            return lstDSubcategorii;
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
                throw new IdentificareBazaImposibilaException("BCategorii");
            using (DataSet ds = DCategorii.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BCategorii");
            }
        }

        public static BColectieCategorii getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieCategorii listaRetur = new BColectieCategorii();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DCategorii.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BCategorii(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BCategorii getCategorieById(int pIdCategorie, IDbTransaction pTranzactie)
        {
            BCategorii categorie = null;
            using (DataSet ds = DCategorii.GetById(pIdCategorie, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categorie = new BCategorii(dr);
                }
            }
            return categorie;
        }

        public static List<int> GetListaIdCategorieComun(int id, IDbTransaction pTranzactie)
        {
            List<int> listaRetur = new List<int>();

            using (DataSet ds = DCategorii.GetListByParamSubcategorii(id, CDefinitiiComune.EnumStare.Activa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new BCategorii(dr).Id);
                }
            }
            return listaRetur;
        }

        public static List<int> GetListaIdCategorii(int id, IDbTransaction pTranzactie)
        {
            List<int> listaRetur = new List<int>();

            using (DataSet ds = DCategorii.GetListByParamCategorii(id, CDefinitiiComune.EnumStare.Activa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaRetur.Add(new BCategorii(dr).Id);
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public static string GetDenumireById(int pIdCategorie)
        {
            if (pIdCategorie <= 0) return string.Empty;

            return new BCategorii(pIdCategorie).Denumire;
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
                bool succesModificare = DCategorii.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.xnIdCategorie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.nCuloare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.tMotivInchidere.ToString());
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
                throw new IdentificareBazaImposibilaException("BCategorii");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DCategorii.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DCategorii.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.xnIdCategorie.ToString()))
                dictRezultat.Adauga(DCategorii.EnumCampuriTabela.xnIdCategorie.ToString(), this.IdCategorie);
            if (this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.nCuloare.ToString()))
                dictRezultat.Adauga(DCategorii.EnumCampuriTabela.nCuloare.ToString(), this.Culoare, false);
            if (this.IsMyDataRowItemHasChanged(DCategorii.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DCategorii.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BCategorii");

            FillObjectWithDataRow<BCategorii>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DCategorii></DCategorii>");

            //Adaugam elementele clasei BCategorii
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCATEGORIE");
            myXmlElem.InnerText = Convert.ToString(this.IdCategorie);
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

            myXmlElem = myXmlDoc.CreateElement("CULOARE");
            myXmlElem.InnerText = Convert.ToString(this.Culoare);
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
