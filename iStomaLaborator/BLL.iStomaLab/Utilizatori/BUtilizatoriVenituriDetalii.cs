using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.iStomaLab.Comune;
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
    /// Clasa pentru gestionarea pretului primit per etapa realizata de fiecare tehnician
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BUtilizatoriVenituriDetalii : BGestiuneCMI, IDisposable, ICheie, ILL.General.Interfete.IProprietarDocumente, IAfisaj, ICreare
    , IStergere
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 100;
        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdUtilizatoriVenituri", true, 1)]
        public int IdUtilizatoriVenituri
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdUtilizatoriVenituri.ToString()); }
        }

        [BExport("IdEtapa", true, 1)]
        public int IdEtapa
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdEtapa.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdEtapa.ToString(), value); }
        }

        [BExport("Pret", true, 1)]
        public double Pret
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nPret.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nPret.ToString(), value); }
        }

        [BExport("DataInceput", true, 1)]
        public DateTime DataInceput
        {
            get { return this.MyDataRowGetItemAsDate(DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataInceput.ToString()); }
        }

        [BExport("DataFinal", true, 1)]
        public DateTime DataFinal
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataFinal.ToString()); }
        }

        [BExport("IdUtilizator", true, 1)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdUtilizator.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DUtilizatoriVenituriDetalii.EnumCampuriTabela.tDenumire.ToString()); }
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

        public BUtilizatoriVenituriDetalii(int pId)
        : this(pId, null)
        {
        }

        public BUtilizatoriVenituriDetalii(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BUtilizatoriVenituriDetalii>(GetDataRowForObjet(pId, pTranzactie), this);
        }


        public BUtilizatoriVenituriDetalii(DataRow pMyRow)
        {
            FillObjectWithDataRow<BUtilizatoriVenituriDetalii>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DUtilizatoriVenituriDetalii
        /// </summary>
        /// <param name="pIdUtilizatoriVenituri"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pPret"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdUtilizatoriVenituri, int pIdEtapa, double pPret, IDbTransaction pTranzactie)
        {
            int id = DUtilizatoriVenituriDetalii.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdUtilizatoriVenituri, pIdEtapa, pPret, pTranzactie);
            return id;
        }

        public static BUtilizatoriVenituriDetalii GetVenituriDetalii(int pIdUtilizatorVenituri, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BUtilizatoriVenituriDetalii lstDListaVenituriDetalii = null;
            using (DataSet ds = DUtilizatoriVenituriDetalii.GetListByParam(pIdUtilizatorVenituri, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDListaVenituriDetalii = new BUtilizatoriVenituriDetalii(dr);
                }
            }
            return lstDListaVenituriDetalii;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdUtilizatoriVenituri, int pIdEtapa, double pPret)
        {
            bool esteOK = true;

            return esteOK;
        }



        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BUtilizatoriVenituriDetalii
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieUtilizatoriVenituriDetalii GetListByParam(int pIdUtilizatoriVenituri, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituriDetalii lstDUtilizatoriVenituriDetalii = new BColectieUtilizatoriVenituriDetalii();
            using (DataSet ds = DUtilizatoriVenituriDetalii.GetListByParam(pIdUtilizatoriVenituri, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatoriVenituriDetalii.Add(new BUtilizatoriVenituriDetalii(dr));
                }
            }
            return lstDUtilizatoriVenituriDetalii;
        }



        private static string getDataInteres(BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres)
        {
            switch (pDataInteres)
            {
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare:
                    return DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataCreare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataInceput:
                    return DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataInceput.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataFinal:
                    return DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataFinal.ToString();
            }

            return DUtilizatoriVenituriDetalii.EnumCampuriTabela.dDataCreare.ToString(); 
        }

        public static BColectieUtilizatoriVenituriDetalii GetListVenituriByPerioada(int pIdUtilizator, DateTime pDataInceput, DateTime pDataSfarsit,  CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituriDetalii lstDUtilizatoriVenituriDetalii = new BColectieUtilizatoriVenituriDetalii();
            using (DataSet ds = DUtilizatoriVenituriDetalii.GetListVenituriByPerioada(pIdUtilizator, pDataInceput, pDataSfarsit, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatoriVenituriDetalii.Add(new BUtilizatoriVenituriDetalii(dr));
                }
            }
            return lstDUtilizatoriVenituriDetalii;
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
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituriDetalii");
            using (DataSet ds = DUtilizatoriVenituriDetalii.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BUtilizatoriVenituriDetalii");
            }
        }

        public static BColectieUtilizatoriVenituriDetalii getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituriDetalii listaRetur = new BColectieUtilizatoriVenituriDetalii();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DUtilizatoriVenituriDetalii.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BUtilizatoriVenituriDetalii(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieUtilizatoriVenituriDetalii GetListByIdUtilizator(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieUtilizatoriVenituriDetalii lstDUtilizatoriVenituriDetalii = new BColectieUtilizatoriVenituriDetalii();
            using (DataSet ds = DUtilizatoriVenituriDetalii.GetListByParamIdUtilizator(pIdUtilizator, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatoriVenituriDetalii.Add(new BUtilizatoriVenituriDetalii(dr));
                }
            }
            return lstDUtilizatoriVenituriDetalii;
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

        public bool UpdatePret(double pPret)
        {
            this.Pret = pPret;

            return this.UpdateAll();
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
                bool succesModificare = DUtilizatoriVenituriDetalii.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdEtapa.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nPret.ToString());
        }

        /// <summary>
        /// Metoda de instanta ce permite stergerea obiectului din baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Delete(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituriDetalii");
            //Stergem obiectul din baza de date
            DUtilizatoriVenituriDetalii.DeleteById(this.Id, pTranzactie);
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
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdEtapa.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituriDetalii.EnumCampuriTabela.xnIdEtapa.ToString(), this.IdEtapa);
            if (this.IsMyDataRowItemHasChanged(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nPret.ToString()))
                dictRezultat.Adauga(DUtilizatoriVenituriDetalii.EnumCampuriTabela.nPret.ToString(), this.Pret);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizatoriVenituriDetalii");

            FillObjectWithDataRow<BUtilizatoriVenituriDetalii>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DUtilizatoriVenituriDetalii></DUtilizatoriVenituriDetalii>");

            //Adaugam elementele clasei BUtilizatoriVenituriDetalii
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATORIVENITURI");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizatoriVenituri);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDETAPA");
            myXmlElem.InnerText = Convert.ToString(this.IdEtapa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PRET");
            myXmlElem.InnerText = Convert.ToString(this.Pret);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCEPUT");
            myXmlElem.InnerText = Convert.ToString(this.DataInceput);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAFINAL");
            myXmlElem.InnerText = Convert.ToString(this.DataFinal);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
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

        public static int ComparaDupaNume(BUtilizatoriVenituriDetalii xElemLista1, BUtilizatoriVenituriDetalii xElemLista2)
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