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
    /// Clasa pentru gestionarea platilor clientilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiPlati : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
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


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPlati.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdClient", true, 1)]
        public int IdClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiPlati.EnumCampuriTabela.xnIdClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.xnIdClient.ToString(), value); }
        }

        [BExport("DataPlata", true, 1)]
        public DateTime DataPlata
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiPlati.EnumCampuriTabela.dDataPlata.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.dDataPlata.ToString(), value); }
        }

        [BExport("SumaPlatita", true, 1)]
        public double SumaPlatita
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiPlati.EnumCampuriTabela.nSumaPlatita.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.nSumaPlatita.ToString(), value); }
        }

        [BExport("ModalitatePlata", true, 1)]
        public BDefinitiiGenerale.EnumModalitatePlata ModalitatePlata
        {
            get { return (BDefinitiiGenerale.EnumModalitatePlata)this.MyDataRowGetItemAsIntegerNull(DClientiPlati.EnumCampuriTabela.nModalitatePlata.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.nModalitatePlata.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiPlati.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        public string DenumireClient
        {
            get { return this.MyDataRowGetItem(DClientiPlati.EnumCampuriTabela.tDenumire.ToString()); }
        }

        [BExport("CursBNR", true, 1)]
        public double CursBNR
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiPlati.EnumCampuriTabela.nCursBNR.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.nCursBNR.ToString(), value); }
        }

        [BExport("MotivInchidere", true, 1)]
        public string MotivInchidere
        {
            get { return this.MyDataRowGetItem(DClientiPlati.EnumCampuriTabela.tMotivInchidere.ToString()); }
            set { this.MyDataRowSetItem(DClientiPlati.EnumCampuriTabela.tMotivInchidere.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiPlatiMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiPlati; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiPlati(int pId) : this(pId, null)
        {
        }

        public BClientiPlati(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiPlati>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiPlati(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiPlati>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiPlati
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <param name="pDataPlata"></param>
        /// <param name="pSumaPlatita"></param>
        /// <param name="pModalitatePlata"></param>
        /// <param name="pCursBNR"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdClient, DateTime pDataPlata, double pSumaPlatita, BDefinitiiGenerale.EnumModalitatePlata pModalitatePlata, double pCursBNR, string pObservatii, BColectieClientiComenzi lComenzi, IDbTransaction pTranzactie)
        {
            int id = DClientiPlati.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdClient, pDataPlata, pSumaPlatita, Convert.ToInt32(pModalitatePlata), pCursBNR, pObservatii, pTranzactie);

            if (id > 0)
            {
                double valoarePlatita = pSumaPlatita;

                foreach (var item in lComenzi)
                {
                    if (valoarePlatita > 0)
                    {
                        if (valoarePlatita >= item.ValoareFinala)
                        {
                            BClientiPlatiComenzi.Add(item.Id, id, item.ValoareFinala, null);
                            valoarePlatita -= item.ValoareFinala;
                        }
                        else
                        {
                            BClientiPlatiComenzi.Add(item.Id, id, valoarePlatita, null);
                            valoarePlatita = 0;
                        }
                    }
                }
            }

            return id;
        }

        public BClienti GetClient(IDbTransaction pTranzactie)
        {
            return BClienti.getClient(this.IdClient, pTranzactie);
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdClient, DateTime pDataPlata, double pSumaPlatita, int pModalitatePlata)
        {
            return pIdClient != 0 && pDataPlata != CConstante.DataNula && pSumaPlatita > 0 && pModalitatePlata > 0;
        }
           

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiPlati
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiPlati GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiPlati lstDClientiPlati = new BColectieClientiPlati();
            using (DataSet ds = DClientiPlati.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPlati.Add(new BClientiPlati(dr));
                }
            }
            return lstDClientiPlati;
        }

        public static BColectieClientiPlati GetListByParamIdClient(int pIdClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiPlati lstDClientiPlati = new BColectieClientiPlati();
            using (DataSet ds = DClientiPlati.GetListByParamIdClient(pIdClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPlati.Add(new BClientiPlati(dr));
                }
            }
            return lstDClientiPlati;
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
                throw new IdentificareBazaImposibilaException("BClientiPlati");
            using (DataSet ds = DClientiPlati.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiPlati");
            }
        }

        public static BColectieClientiPlati getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiPlati listaRetur = new BColectieClientiPlati();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiPlati.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlati(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlati getById(int pId, IDbTransaction pTranzactie)
        {
            BColectieClientiPlati listaRetur = new BColectieClientiPlati();
            if (pId > 0)
            {
                using (DataSet ds = DClientiPlati.GetById(pId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiPlati(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BColectieClientiPlati GetListaIncasari(int pIdClient, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieClientiPlati lstDClientiPlati = new BColectieClientiPlati();
            using (DataSet ds = DClientiPlati.GetListByParamSiPerioada(pIdClient, pDataInceput, pDataSfarsit, CDefinitiiComune.EnumStare.Activa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiPlati.Add(new BClientiPlati(dr));
                }
            }
            return lstDClientiPlati;
        }

        public static double GetTotalIncasari(int pIdClient, IDbTransaction pTranzactie)
        {
            double nTotalPlati = 0;
            using (DataSet ds = DClientiPlati.GetTotalIncasari(pIdClient, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    nTotalPlati = CUtil.GetAsDouble(dr["nTotal"]);
                }
            }
            return nTotalPlati;
        }


        public static Dictionary<int, double> GetDictIdClinicaTotalIncasari(List<int> pListaIdClinici, IDbTransaction pTranzactie)
        {
            Dictionary<int, double> dictRetur = new Dictionary<int, double>();

            if (!CUtil.EsteListaIntVida(pListaIdClinici))
            {
                using (DataSet ds = DClientiPlati.GetDictIdClinicaTotalIncasari(pListaIdClinici, pTranzactie))
                {
                    int idClinica = 0;
                    double totalInc = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idClinica = CUtil.GetAsInt32(dr[DClientiPlati.EnumCampuriTabela.xnIdClient.ToString()]);
                        totalInc = CUtil.GetAsDouble(dr["nTotal"]);
                        dictRetur.Add(idClinica, totalInc);
                    }
                }
            }

            return dictRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public string ToStringSumaPlatita()
        {
            return string.Format("{0} LEI", CUtil.GetValoareMonetara(this.SumaPlatita));
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
                bool succesModificare = DClientiPlati.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.xnIdClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.dDataPlata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nSumaPlatita.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nModalitatePlata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nCursBNR.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.tObservatii.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiPlati");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiPlati.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

                BClientiPlatiComenzi.DeleteByIdPlata(this.Id, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.xnIdClient.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.xnIdClient.ToString(), this.IdClient);
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.dDataPlata.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.dDataPlata.ToString(), this.DataPlata);
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nSumaPlatita.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.nSumaPlatita.ToString(), this.SumaPlatita);
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nModalitatePlata.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.nModalitatePlata.ToString(), Convert.ToInt32(this.ModalitatePlata));
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.nCursBNR.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.nCursBNR.ToString(), this.CursBNR);
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DClientiPlati.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiPlati.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);

            return dictRezultat;
        }

      

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiPlati");

            FillObjectWithDataRow<BClientiPlati>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DClientiPlati></DClientiPlati>");

            //Adaugam elementele clasei BClientiPlati
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAPLATA");
            myXmlElem.InnerText = Convert.ToString(this.DataPlata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SUMAPLATITA");
            myXmlElem.InnerText = Convert.ToString(this.SumaPlatita);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MODALITATEPLATA");
            myXmlElem.InnerText = Convert.ToString(this.ModalitatePlata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CURSBNR");
            myXmlElem.InnerText = Convert.ToString(this.CursBNR);
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
