using BLL.iStomaLab.Clienti;
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

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea platilor comenzilor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiPlatiComenzi : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPlatiComenzi.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClientComanda", true, 1)]
        public int IdClientComanda
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientComanda.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientComanda.ToString(), value); }
        }

        [BExport("IdClientPlata", true, 1)]
        public int IdClientPlata
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientPlata.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientPlata.ToString(), value); }
        }

        [BExport("Valoare", true, 1)]
        public double Valoare
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiPlatiComenzi.EnumCampuriTabela.nValoare.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlatiComenzi.EnumCampuriTabela.nValoare.ToString(), value); }
        }
        
        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiPlatiComenziMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiPlatiComenzi; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiPlatiComenzi(int pId) : this(pId, null)
        {
        }

        public BClientiPlatiComenzi(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiPlatiComenzi>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiPlatiComenzi(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiPlatiComenzi>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiPlatiComenzi
        /// </summary>
        /// <param name="pIdClientComanda"></param>
        /// <param name="pIdClientPlata"></param>
        /// <param name="pValoare"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add( int pIdClientComanda, int pIdClientPlata, double pValoare, IDbTransaction pTranzactie)
        {
            int id = DClientiPlatiComenzi.Add(pIdClientComanda, pIdClientPlata, pValoare, pTranzactie);

            return id;
        }
        
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiPlatiComenzi
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiPlatiComenzi GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi lstDClientiPlatiComenzi = new BColectieClientiPlatiComenzi();
            using (DataSet ds = DClientiPlatiComenzi.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPlatiComenzi.Add(new BClientiPlatiComenzi(dr));
                }
            }
            return lstDClientiPlatiComenzi;
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
                throw new IdentificareBazaImposibilaException("BClientiPlatiComenzi");
            using (DataSet ds = DClientiPlatiComenzi.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiPlatiComenzi");
            }
        }

        public static BColectieClientiPlatiComenzi getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiPlatiComenzi.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlatiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlatiComenzi getById(int pId, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();
            if (pId > 0)
            {
                using (DataSet ds = DClientiPlatiComenzi.GetById(pId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlatiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlatiComenzi GetByIdPlata(int pIdPlata, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();
            if (pIdPlata > 0)
            {
                using (DataSet ds = DClientiPlatiComenzi.GetByIdPlata(pIdPlata, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlatiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlatiComenzi GetByListIdComenzi(List<int> pListIdComenzi, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();
            if (!CUtil.EsteListaIntVida(pListIdComenzi))
            {
                using (DataSet ds = DClientiPlatiComenzi.GetByListIdComenzi(pListIdComenzi, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlatiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlatiComenzi GetListByIdFactura(int pIdFactura, IDbTransaction pTranzactie)
        {
            BColectieClientiPlatiComenzi listaRetur = new BColectieClientiPlatiComenzi();
            if (pIdFactura > 0)
            {
                using (DataSet ds = DClientiPlatiComenzi.GetByIdFactura(pIdFactura, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlatiComenzi(dr));
                    }
                }
            }
            return listaRetur;
        }

        internal static void DeleteByIdPlata(int pId, IDbTransaction pTranzactie)
        {
            DClientiPlatiComenzi.DeleteByIdPlata(pId, pTranzactie);
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
                bool succesModificare = DClientiPlatiComenzi.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientComanda.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientPlata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.nValoare.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiPlatiComenzi");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiPlatiComenzi.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientComanda.ToString()))
                dictRezultat.Adauga(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientComanda.ToString(), this.IdClientComanda);
            if (this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientPlata.ToString()))
                dictRezultat.Adauga(DClientiPlatiComenzi.EnumCampuriTabela.xnIdClientPlata.ToString(), this.IdClientPlata);
            if (this.IsMyDataRowItemHasChanged(DClientiPlatiComenzi.EnumCampuriTabela.nValoare.ToString()))
                dictRezultat.Adauga(DClientiPlatiComenzi.EnumCampuriTabela.nValoare.ToString(), this.Valoare);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiPlatiComenzi");

            FillObjectWithDataRow<BClientiPlatiComenzi>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DClientiPlatiComenzi></DClientiPlatiComenzi>");

            //Adaugam elementele clasei BClientiPlatiComenzi
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENTCOMANDA");
            myXmlElem.InnerText = Convert.ToString(this.IdClientComanda);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENTPLATA");
            myXmlElem.InnerText = Convert.ToString(this.IdClientPlata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALOARE");
            myXmlElem.InnerText = Convert.ToString(this.Valoare);
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
