using BLL.iStomaLab.Comune;
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

namespace BLL.iStomaLab.Clienti
{
    /// <summary>
    /// Clasa pentru gestionarea comenzilor etapelor comenzilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BClientiComenziEtape : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        public enum EnumStareEtapa
        {
            Nedefinita = 0,
            InLucru = 1,
            Finalizata = 2,
            Livrata = 3
        }

        #region StructCampuriTabela

        public struct StructStareEtapa
        {
            public EnumStareEtapa Id { get; set; }
            public string Denumire { get; set; }

            public StructStareEtapa(EnumStareEtapa pId, string pDenumire) : this()
            {
                this.Id = pId;
                this.Denumire = pDenumire;
            }

            public override bool Equals(object obj)
            {
                if (obj is int || obj is EnumStareEtapa)
                    return this.Id.Equals((EnumStareEtapa)CUtil.GetAsInt32(obj));
                else if (obj is StructStareEtapa)
                    return this.Id.Equals((StructStareEtapa)obj);
                return base.Equals(obj);
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructStareEtapa GetStructById(EnumStareEtapa pId)
            {
                switch (pId)
                {
                    case EnumStareEtapa.InLucru:
                        return new StructStareEtapa(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InLucru));
                    case EnumStareEtapa.Finalizata:
                        return new StructStareEtapa(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Finalizata));
                    case EnumStareEtapa.Livrata:
                        return new StructStareEtapa(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Livrata));
                }
                return new StructStareEtapa(pId, string.Empty);
            }

            public static List<StructStareEtapa> GetList()
            {
                List<StructStareEtapa> lstRetur = new List<StructStareEtapa>();

                lstRetur.Add(GetStructById(EnumStareEtapa.Nedefinita));
                lstRetur.Add(GetStructById(EnumStareEtapa.InLucru));
                lstRetur.Add(GetStructById(EnumStareEtapa.Finalizata));
                lstRetur.Add(GetStructById(EnumStareEtapa.Livrata));

                return lstRetur;
            }
        }

        public struct StructCampuriTabela
        {
            public const int ObservatiiMaxLength = 500;
            public const int MotivInchidereMaxLength = 500;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenziEtape.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdComandaClient", true, 1)]
        public int IdComandaClient
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenziEtape.EnumCampuriTabela.xnIdComandaClient.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.xnIdComandaClient.ToString(), value); }
        }

        [BExport("IdEtapa", true, 1)]
        public int IdEtapa
        {
            get { return this.MyDataRowGetItemAsInteger(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapa.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapa.ToString(), value); }
        }

        [BExport("DataInceput", true, 1)]
        public DateTime DataInceput
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziEtape.EnumCampuriTabela.dDataInceput.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.dDataInceput.ToString(), value); }
        }


        [BExport("DataFinal", true, 1)]
        public DateTime DataFinal
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString(), value); }
        }

        public DateTime DataCreareLucrare
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziEtape.EnumCampuriTabela.dDataCreareLucrare.ToString()); }
        }

        public DateTime DataLaGataLucrare
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziEtape.EnumCampuriTabela.dDataLaGataLucrare.ToString()); }
        }

        public DateTime DataPrimireLucrare
        {
            get { return this.MyDataRowGetItemAsDateNull(DClientiComenziEtape.EnumCampuriTabela.dDataPrimireLucrare.ToString()); }
        }

        [BExport("IdTehnician", true, 1)]
        public int IdTehnician
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdTehnician.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.xnIdTehnician.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        public string DenumireEtapa
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tDenumire.ToString()); }

        }

        [BExport("Status", true, 1)]
        public EnumStareEtapa Status
        {
            get { return (EnumStareEtapa)this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.nStatus.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.nStatus.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("Refacere", true, 1)]
        public bool Refacere
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DClientiComenziEtape.EnumCampuriTabela.bRefacere.ToString()); }
            set { this.MyDataRowSetItem(DClientiComenziEtape.EnumCampuriTabela.bRefacere.ToString(), value); }
        }
              

        public int IdClient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdClient.ToString()); }
        }

        public int IdReprezentantClient
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdReprezentantClient.ToString()); }
        }

        public string NumePacient
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tNumePacient.ToString()); }
        }

        public string PrenumePacient
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tPrenumePacient.ToString()); }
        }

        public string ObservatiiComanda
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tObservatiiComanda.ToString()); }
        }

        public int IdCabinet
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdCabinet.ToString()); }
        }

        public int IdLucrare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdLucrare.ToString()); }
        }

        public int NumarElemente
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.nNrElemente.ToString()); }
        }

        public bool Urgent
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DClientiComenziEtape.EnumCampuriTabela.bUrgent.ToString()); }
        }

        public string CuloareLucrare
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tCuloareLucrare.ToString()); }
        }

        public string DenumireClient
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tDenumireClient.ToString()); }
        }

        public string NumeTehnician
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tNume.ToString()); }
        }

        public string PrenumeTehnician
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tPrenume.ToString()); }
        }

        public string Porecla
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tPorecla.ToString()); }
        }

        public string DenumireLucrare
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tDenumireLucrare.ToString()); }
        }

        public string DenumirePrescurtataLucrare
        {
            get { return this.MyDataRowGetItem(DClientiComenziEtape.EnumCampuriTabela.tDenumirePrescurtataLucrare.ToString()); }
        }
        public double ValoareInitiala
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenziEtape.EnumCampuriTabela.nValoareInitiala.ToString()); }
        }
        public double ValoareFinala
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenziEtape.EnumCampuriTabela.nValoareFinala.ToString()); }
        }
        public double PretUnitarInitial
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenziEtape.EnumCampuriTabela.nPretUnitarInitial.ToString()); }
        }
        public double PretUnitarFinal
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DClientiComenziEtape.EnumCampuriTabela.nPretUnitarFinal.ToString()); }
        }
        public int IdFactura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdFactura.ToString()); }
        }
        public CDefinitiiComune.EnumTipMoneda Moneda
        {
            get { return this.MyDataRowGetItemAsMoneda(DClientiComenziEtape.EnumCampuriTabela.nMoneda.ToString()); }
        }
        public double Venit
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.Venit.ToString()); }
        }
        public int IdEtapaVenit
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapaVenit.ToString()); }
        }


        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.ClientiComenziEtapeMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.ClientiComenziEtape; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BClientiComenziEtape(int pId) : this(pId, null)
        {
        }

        public BClientiComenziEtape(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BClientiComenziEtape>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BClientiComenziEtape(DataRow pMyRow)
        {
            FillObjectWithDataRow<BClientiComenziEtape>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DClientiComenziEtape
        /// </summary>
        /// <param name="pIdComandaClient"></param>
        /// <param name="pIdEtapa"></param>
        /// <param name="pDataInceput"></param>
        /// <param name="pDataFinal"></param>
        /// <param name="pIdTehnician"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pStatus"></param>
        /// <param name="pRefacere"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(int pIdComandaClient, int pIdEtapa, DateTime pDataInceput, DateTime pDataFinal, int pIdTehnician, string pObservatii, int pStatus, bool pRefacere, IDbTransaction pTranzactie)
        {
            int id = DClientiComenziEtape.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pIdComandaClient, pIdEtapa, pDataInceput, pDataFinal, pIdTehnician, pObservatii, pStatus, pRefacere, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(int pIdComandaClient, int pIdEtapa)
        {
            return pIdComandaClient != 0 && pIdEtapa != 0;
        }

        public static BColectieClientiComenziEtape GetByTehnicianPerioada(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetByTehnicianPerioada(pIdTehnician, pDataInceput, pDataSfarsit, getDataInteres(pDataInteres), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }


        public static BColectieClientiComenziEtape GetListVenituriByIdTehnician(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetListByParamIdTehnician(pIdTehnician, pDataInceput, pDataSfarsit, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }

        private static string getDataInteres(BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres)
        {
            switch (pDataInteres)
            {
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare:
                    return DClientiComenziEtape.EnumCampuriTabela.dDataCreareLucrare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire:
                    return DClientiComenziEtape.EnumCampuriTabela.dDataPrimireLucrare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataLaGata:
                    return DClientiComenziEtape.EnumCampuriTabela.dDataLaGataLucrare.ToString();
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataTermen:
                    return DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString();
            }

            return DClientiComenzi.EnumCampuriTabela.dDataCreare.ToString();
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BClientiComenziEtape
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieClientiComenziEtape GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }

        public static BColectieClientiComenziEtape GetListByIdComanda(int pIdComanda, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetListByParamIdComandaClient(pIdComanda, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }

        public static BColectieClientiComenziEtape GetListByTehnicianSiLucrareIntrePerioada(int pIdTehnician, int pIdLucrare, DateTime pDataInceput, DateTime pDataSfarsit, BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetListByTehnicianSiLucrareIntrePerioada(pIdTehnician, pIdLucrare, pDataInceput, pDataSfarsit, getDataInteres(pDataInteres), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }
        public static List<int> GetIdListByParamIdComandaClient(int pIdComandaClient, CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            List<int> lstDClientiComenziEtape = new List<int>();
            using (DataSet ds = DClientiComenziEtape.GetListByParamIdComandaClient(pIdComandaClient, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr).Id);
                }
            }
            return lstDClientiComenziEtape;
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
                throw new IdentificareBazaImposibilaException("BClientiComenziEtape");
            using (DataSet ds = DClientiComenziEtape.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BClientiComenziEtape");
            }
        }

        public static BColectieClientiComenziEtape getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape listaRetur = new BColectieClientiComenziEtape();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DClientiComenziEtape.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BClientiComenziEtape(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static Dictionary<int, Tuple<double, double>> GetListaVenituri(DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            Dictionary<int, Tuple<double, double>> listaRetur = new Dictionary<int, Tuple<double, double>>();

            using (DataSet ds = DClientiComenziEtape.GetListaVenituri(pDataInceput, pDataSfarsit, pTranzactie))
            {
                int idUtilizator = 0; 
                double nrElemente= 0;
                double totalCuvenit = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    idUtilizator = CUtil.GetAsInt32(dr[DClientiComenziEtape.EnumCampuriRezumat.xnIdTehnician.ToString()]); 
                    nrElemente = CUtil.GetAsDouble(dr[DClientiComenziEtape.EnumCampuriRezumat.NrElemente.ToString()]);
                    totalCuvenit = CUtil.GetAsDouble(dr[DClientiComenziEtape.EnumCampuriRezumat.TotalCuvenit.ToString()]);
                    listaRetur.Add(idUtilizator, new Tuple<double, double>(nrElemente, totalCuvenit));
                }
            }

            return listaRetur;
        }

        public static BColectieClientiComenziEtape GetListaVenituriDetaliat(int pIdTehnician, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction pTranzactie)
        {
            BColectieClientiComenziEtape lstDClientiComenziEtape = new BColectieClientiComenziEtape();
            using (DataSet ds = DClientiComenziEtape.GetListaDetaliatVenituri(pIdTehnician, pDataInceput, pDataSfarsit, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDClientiComenziEtape.Add(new BClientiComenziEtape(dr));
                }
            }
            return lstDClientiComenziEtape;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public string GetIdentitateTehnician()
        {
            return string.Format("{0} {1}", this.NumeTehnician, this.PrenumeTehnician);
        }

        public object GetEtichetaMoneda()
        {
            return CStructuriComune.StructTipMoneda.GetStringByEnum(this.Moneda);
        }

        public string GetIdentitatePacient()
        {
            return string.Format("{0} {1}", this.NumePacient, this.PrenumePacient);
        }

        public string GetEtichetaStare()
        {
            return StructStareEtapa.GetStructById(this.Status).Denumire;
        }

        public string GetDenumirePrescurtataLucrare()
        {
            if (!string.IsNullOrEmpty(this.DenumirePrescurtataLucrare))
                return this.DenumirePrescurtataLucrare;
            return this.DenumireLucrare;
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
                bool succesModificare = DClientiComenziEtape.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdComandaClient.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapa.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.dDataInceput.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdTehnician.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.nStatus.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.bRefacere.ToString());
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
                throw new IdentificareBazaImposibilaException("BClientiComenziEtape");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DClientiComenziEtape.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdComandaClient.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.xnIdComandaClient.ToString(), this.IdComandaClient);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapa.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.xnIdEtapa.ToString(), this.IdEtapa);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.dDataInceput.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.dDataInceput.ToString(), this.DataInceput);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.dDataFinal.ToString(), this.DataFinal);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.xnIdTehnician.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.xnIdTehnician.ToString(), this.IdTehnician);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.nStatus.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.nStatus.ToString(), Convert.ToInt32(this.Status));
            if (this.IsMyDataRowItemHasChanged(DClientiComenziEtape.EnumCampuriTabela.bRefacere.ToString()))
                dictRezultat.Adauga(DClientiComenziEtape.EnumCampuriTabela.bRefacere.ToString(), this.Refacere);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BClientiComenziEtape");

            FillObjectWithDataRow<BClientiComenziEtape>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DClientiComenziEtape></DClientiComenziEtape>");

            //Adaugam elementele clasei BClientiComenziEtape
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDCOMANDACLIENT");
            myXmlElem.InnerText = Convert.ToString(this.IdComandaClient);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDETAPA");
            myXmlElem.InnerText = Convert.ToString(this.IdEtapa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCEPUT");
            myXmlElem.InnerText = Convert.ToString(this.DataInceput);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAFINAL");
            myXmlElem.InnerText = Convert.ToString(this.DataFinal);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDTEHNICIAN");
            myXmlElem.InnerText = Convert.ToString(this.IdTehnician);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
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

            myXmlElem = myXmlDoc.CreateElement("STATUS");
            myXmlElem.InnerText = Convert.ToString(this.Status);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("REFACERE");
            myXmlElem.InnerText = Convert.ToString(this.Refacere);
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
