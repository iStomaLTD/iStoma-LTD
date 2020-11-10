using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Comune;
using ILL.iStomaLab;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab.Referinta;

namespace BLL.iStomaLab.Comune
{
    public struct StructDetaliiAdresa
    {
        public string Apartament { get; set; }
        public string Bloc { get; set; }
        public string CodInterfon { get; set; }
        public string Comentariu { get; set; }
        public int ComplementAdresa { get; set; }
        public DateTime DataFinalValabilitate { get; set; }
        public DateTime DataInceputValabilitate { get; set; }
        public DateTime DataVerificare { get; set; }
        public string Etaj { get; set; }
        public string Fax { get; set; }
        public int IdCodPostal { get; set; }
        public int IdLocalitate { get; set; }
        public int IdRegiune { get; set; }
        public int IdTara { get; set; }
        public string Numar { get; set; }
        public string NumeStrada { get; set; }
        public string Scara { get; set; }
        public string TelefonFix { get; set; }
        public BAdrese.EnumTipAdresa TipAdresa { get; set; }
        public CDefinitiiComune.EnumTipObiect TipProprietar { get; set; }
        public int IdProprietar { get; set; }
        public bool Actuala { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        private bool lExista;

        public static StructDetaliiAdresa Empty { get { return new StructDetaliiAdresa(false); } }

        public StructDetaliiAdresa(bool pExista)
            : this()
        {
            this.lExista = pExista;
        }

        public bool AreValoare()
        {
            return this.lExista;
        }
    }

    /// <summary>
    /// Clasa pentru gestionarea adreselor diferitelor entitati
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BAdrese : BGestiuneCMI, IDisposable, ICheie, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri


        #region EnumTipAdresa + StructTipAdresa

        public enum EnumTipAdresa
        {
            Nedefinit = 0,
            /// <summary>
            /// Principală
            /// </summary>
            Principala = 1,
            /// <summary>
            /// Secundară
            /// </summary>
            Secundara = 2,
            /// <summary>
            /// De vacanță
            /// </summary>
            DeVacanta = 3,
            /// <summary>
            /// De facturare
            /// </summary>
            DeFacturare = 4,
            SediuSocial = 5
        }

        public struct StructTipAdresa
        {
            public EnumTipAdresa Id { get; set; }
            public string Nume { get; set; }

            public StructTipAdresa(EnumTipAdresa pId, string pNume)
                : this()
            {
             
                  this.Id = pId;
                this.Nume = pNume;
            }

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                bool Egalitate = base.Equals(obj);
                if (obj == null)
                {
                    Egalitate = false;
                }
                else
                {
                    if (obj is EnumTipAdresa)
                    {
                        Egalitate = (this.Id == (EnumTipAdresa)obj);
                    }
                    else
                    {
                        if (obj is StructTipAdresa)
                        {
                            Egalitate = (this.Id == ((StructTipAdresa)obj).Id);
                        }
                        else
                        {
                            if (obj is int)
                            {
                                Egalitate = (Convert.ToInt32(this.Id) == Convert.ToInt32(obj));
                            }
                            else
                            {
                                if (obj is long)
                                {
                                    Egalitate = (Convert.ToInt64(this.Id) == Convert.ToInt64(obj));
                                }
                            }
                        }
                    }
                }
                return Egalitate;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructTipAdresa Empty
            {
                get { return new StructTipAdresa(EnumTipAdresa.Nedefinit, ""); }
            }

            public static List<StructTipAdresa> GetList()
            {
                List<StructTipAdresa> lstStruct = new List<StructTipAdresa>();
                lstStruct.Add(GetStructByEnum(EnumTipAdresa.Principala));
                lstStruct.Add(GetStructByEnum(EnumTipAdresa.Secundara));
                lstStruct.Add(GetStructByEnum(EnumTipAdresa.DeVacanta));
                lstStruct.Add(GetStructByEnum(EnumTipAdresa.DeFacturare));
                return lstStruct;
            }

            public static StructTipAdresa GetStructByEnum(EnumTipAdresa pTip)
            {
                switch (pTip)
                {
                    case EnumTipAdresa.Principala:
                        return new StructTipAdresa(EnumTipAdresa.Principala, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Principala));
                    case EnumTipAdresa.Secundara:
                        return new StructTipAdresa(EnumTipAdresa.Secundara, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Secundara));
                    case EnumTipAdresa.DeVacanta:
                        return new StructTipAdresa(EnumTipAdresa.DeVacanta, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeVacanta));
                    case EnumTipAdresa.DeFacturare:
                        return new StructTipAdresa(EnumTipAdresa.DeFacturare, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeFacturare));
                    case EnumTipAdresa.SediuSocial:
                        return new StructTipAdresa(EnumTipAdresa.SediuSocial, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SediuSocial));
                }

                return Empty;
            }

            public static EnumTipAdresa GetEnumByString(string pNume)
            {
                EnumTipAdresa lTipLocalitate = EnumTipAdresa.Nedefinit;
                foreach (StructTipAdresa xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lTipLocalitate = xStruct.Id;
                        break;
                    }
                }

                return lTipLocalitate;
            }

            public static string GetStringByEnum(EnumTipAdresa pId)
            {
                return GetStructByEnum(pId).Nume;
            }
        }

        #endregion // EnumTipAdresa + StructTipAdresa

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int MotivInchidereMaxLength = 500;
            public const int NumeStradaMaxLength = 250;
            public const int NumarMaxLength = 50;
            public const int BlocMaxLength = 50;
            public const int ScaraMaxLength = 50;
            public const int EtajMaxLength = 50;
            public const int ApartamentMaxLength = 50;
            public const int CodInterfonMaxLength = 50;
            public const int CodPostalMaxLength = 10;
        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DAdrese.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("TipAdresa", true, 1)]
        public EnumTipAdresa TipAdresa
        {
            get { return (EnumTipAdresa)this.MyDataRowGetItemAsInteger(DAdrese.EnumCampuriTabela.nTipAdresa.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.nTipAdresa.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("NumeStrada", true, 1)]
        public string NumeStrada
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tNumeStrada.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tNumeStrada.ToString(), value); }
        }

        [BExport("Numar", true, 1)]
        public string Numar
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tNumar.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tNumar.ToString(), value); }
        }

        [BExport("Bloc", true, 1)]
        public string Bloc
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tBloc.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tBloc.ToString(), value); }
        }

        [BExport("Scara", true, 1)]
        public string Scara
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tScara.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tScara.ToString(), value); }
        }

        [BExport("Etaj", true, 1)]
        public string Etaj
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tEtaj.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tEtaj.ToString(), value); }
        }

        [BExport("Apartament", true, 1)]
        public string Apartament
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tApartament.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tApartament.ToString(), value); }
        }

        [BExport("CodInterfon", true, 1)]
        public string CodInterfon
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tCodInterfon.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tCodInterfon.ToString(), value); }
        }

        [BExport("IdTara", true, 1)]
        public int IdTara
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DAdrese.EnumCampuriTabela.xnIdTara.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.xnIdTara.ToString(), value); }
        }

        [BExport("IdRegiune", true, 1)]
        public int IdRegiune
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DAdrese.EnumCampuriTabela.xnIdRegiune.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.xnIdRegiune.ToString(), value); }
        }

        [BExport("IdLocalitate", true, 1)]
        public int IdLocalitate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DAdrese.EnumCampuriTabela.xnIdLocalitate.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.xnIdLocalitate.ToString(), value); }
        }

        [BExport("CodPostal", true, 1)]
        public string CodPostal
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tCodPostal.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tCodPostal.ToString(), value); }
        }

        [BExport("DataVerificare", true, 1)]
        public DateTime DataVerificare
        {
            get { return this.MyDataRowGetItemAsDateNull(DAdrese.EnumCampuriTabela.dDataVerificare.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.dDataVerificare.ToString(), value); }
        }

        [BExport("Comentariu", true, 1)]
        public string Comentariu
        {
            get { return this.MyDataRowGetItem(DAdrese.EnumCampuriTabela.tComentariu.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.tComentariu.ToString(), value); }
        }

        [BExport("TipProprietar", true, 1)]
        public CDefinitiiComune.EnumTipObiect TipProprietar
        {
            get { return this.MyDataRowGetItemAsEnumTipProprietar(DAdrese.EnumCampuriTabela.nTipProprietar.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.nTipProprietar.ToString(), value); }
        }

        [BExport("IdProprietar", true, 1)]
        public int IdProprietar
        {
            get { return this.MyDataRowGetItemAsInteger(DAdrese.EnumCampuriTabela.xnIdProprietar.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.xnIdProprietar.ToString(), value); }
        }

        [BExport("Latitudine", true, 1)]
        public double Latitudine
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DAdrese.EnumCampuriTabela.nLatitudine.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.nLatitudine.ToString(), value); }
        }

        [BExport("Longitudine", true, 1)]
        public double Longitudine
        {
            get { return this.MyDataRowGetItemAsDoubleNull(DAdrese.EnumCampuriTabela.nLongitudine.ToString()); }
            set { this.MyDataRowSetItem(DAdrese.EnumCampuriTabela.nLongitudine.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.AdreseMotiveInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Adrese; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BAdrese(int pId)
        : this(pId, null)
        {
        }

        public BAdrese(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BAdrese>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BAdrese(DataRow pMyRow)
        {
            FillObjectWithDataRow<BAdrese>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DAdrese
        /// </summary>
        /// <param name="pTipAdresa"></param>
        /// <param name="pNumeStrada"></param>
        /// <param name="pNumar"></param>
        /// <param name="pBloc"></param>
        /// <param name="pScara"></param>
        /// <param name="pEtaj"></param>
        /// <param name="pApartament"></param>
        /// <param name="pCodInterfon"></param>
        /// <param name="pIdTara"></param>
        /// <param name="pIdRegiune"></param>
        /// <param name="pIdLocalitate"></param>
        /// <param name="pCodPostal"></param>
        /// <param name="pComentariu"></param>
        /// <param name="pTipProprietar"></param>
        /// <param name="pIdProprietar"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(EnumTipAdresa pTipAdresa, string pNumeStrada, string pNumar, string pBloc, string pScara, string pEtaj, string pApartament, string pCodInterfon, int pIdTara, int pIdRegiune, int pIdLocalitate, string pCodPostal, string pComentariu, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, IDbTransaction pTranzactie)
        {
            int id = DAdrese.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), Convert.ToInt32(pTipAdresa), pNumeStrada, pNumar, pBloc, pScara, pEtaj, pApartament, pCodInterfon, pIdTara, pIdRegiune, pIdLocalitate, pCodPostal, pComentariu, Convert.ToInt32(pTipProprietar), pIdProprietar, pTranzactie);
            return id;
        }

        public static BAdrese AddEmpty(CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, EnumTipAdresa nedefinit, IDbTransaction pTranzactie)
        {
            return new BAdrese(Add(EnumTipAdresa.Principala, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, 0, string.Empty, string.Empty, pTipProprietar, pIdProprietar, pTranzactie));
        }

        public static bool SuntInformatiileNecesareCoerente(int pTipAdresa, int pTipProprietar, int pIdProprietar)
        {
            return pTipAdresa != 0 && pTipProprietar != 0 && pIdProprietar != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BAdrese
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieAdrese GetListByParam(EnumTipAdresa pTipAdresa, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar,
        CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieAdrese lstDAdrese = new BColectieAdrese();
            using (DataSet ds = DAdrese.GetListByParam(Convert.ToInt32(pTipAdresa), Convert.ToInt32(pTipProprietar), pIdProprietar, pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDAdrese.Add(new BAdrese(dr));
                }
            }
            return lstDAdrese;
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
                throw new IdentificareBazaImposibilaException("BAdrese");
            using (DataSet ds = DAdrese.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BAdrese");
            }
        }

        public static BColectieAdrese getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieAdrese listaRetur = new BColectieAdrese();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DAdrese.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BAdrese(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BAdrese getAdresaByIdProprietar(int pIdProprietar, IDbTransaction pTranzactie)
        {
            BAdrese adresa = null;

            using (DataSet ds = DAdrese.GetByIdProprietar(pIdProprietar, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    adresa = new BAdrese(dr);
                }
            }

            return adresa;
        }

        public static BAdrese getAdresa(int pIdAdresa, IDbTransaction pTranzactie)
        {
            BAdrese adresa = null;

            using (DataSet ds = DAdrese.GetById(pIdAdresa, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    adresa = new BAdrese(dr);
                }
            }

            return adresa;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public override string ToString()
        {
            string campuriTotale = string.Empty;
            string denumireRegiune = BRegiuni.GetDenumireRegiune(this.IdRegiune, null);
            string denumireLocalitate = BLocalitati.GetDenumireLocalitate(this.IdLocalitate, null);
            string denumireTara = BTari.GetDenumireTara(this.IdTara, null);

            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.NumeStrada), string.Concat("Str. ", this.NumeStrada));
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.Numar), this.Numar);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.Bloc), this.Bloc);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.Scara), this.Scara);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.Etaj), this.Etaj);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(this.Apartament), this.Apartament);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(denumireRegiune), denumireRegiune);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(denumireLocalitate), denumireLocalitate);
            campuriTotale = adaugaCampuriCompletate(campuriTotale, !string.IsNullOrEmpty(denumireTara), denumireTara);

            return campuriTotale;
        }

        private string adaugaCampuriCompletate(string pCampuriTotale, bool pEsteCompletat, string pCampNou)
        {
            if (pEsteCompletat)
            {
                if (!string.IsNullOrEmpty(pCampuriTotale))
                {
                    pCampuriTotale += ", ";
                }
                pCampuriTotale += pCampNou;
            }
            return pCampuriTotale;
        }

        public bool EsteCompletata()
        {
            if (this.IdTara <= 0 || this.IdRegiune <= 0 || this.IdLocalitate <= 0 || string.IsNullOrEmpty(this.NumeStrada) || string.IsNullOrEmpty(this.Numar))
                return false;

            return true;
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
                bool succesModificare = DAdrese.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nTipAdresa.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tNumeStrada.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tNumar.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tBloc.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tScara.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tEtaj.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tApartament.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tCodInterfon.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdTara.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdRegiune.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdLocalitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tCodPostal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.dDataVerificare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tComentariu.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nTipProprietar.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdProprietar.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nLatitudine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nLongitudine.ToString());
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
                throw new IdentificareBazaImposibilaException("BAdrese");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DAdrese.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nTipAdresa.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.nTipAdresa.ToString(), Convert.ToInt32(this.TipAdresa));
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tNumeStrada.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tNumeStrada.ToString(), this.NumeStrada);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tNumar.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tNumar.ToString(), this.Numar);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tBloc.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tBloc.ToString(), this.Bloc);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tScara.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tScara.ToString(), this.Scara);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tEtaj.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tEtaj.ToString(), this.Etaj);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tApartament.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tApartament.ToString(), this.Apartament);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tCodInterfon.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tCodInterfon.ToString(), this.CodInterfon);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdTara.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.xnIdTara.ToString(), this.IdTara);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdRegiune.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.xnIdRegiune.ToString(), this.IdRegiune);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdLocalitate.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.xnIdLocalitate.ToString(), this.IdLocalitate);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tCodPostal.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tCodPostal.ToString(), this.CodPostal);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.dDataVerificare.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.dDataVerificare.ToString(), this.DataVerificare);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.tComentariu.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.tComentariu.ToString(), this.Comentariu);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nTipProprietar.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.nTipProprietar.ToString(), this.TipProprietar);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.xnIdProprietar.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.xnIdProprietar.ToString(), this.IdProprietar);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nLatitudine.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.nLatitudine.ToString(), this.Latitudine);
            if (this.IsMyDataRowItemHasChanged(DAdrese.EnumCampuriTabela.nLongitudine.ToString()))
                dictRezultat.Adauga(DAdrese.EnumCampuriTabela.nLongitudine.ToString(), this.Longitudine);

            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BAdrese");

            FillObjectWithDataRow<BAdrese>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DAdrese></DAdrese>");

            //Adaugam elementele clasei BAdrese
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
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

            myXmlElem = myXmlDoc.CreateElement("TIPADRESA");
            myXmlElem.InnerText = Convert.ToString(this.TipAdresa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMESTRADA");
            myXmlElem.InnerText = this.NumeStrada;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMAR");
            myXmlElem.InnerText = this.Numar;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("BLOC");
            myXmlElem.InnerText = this.Bloc;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SCARA");
            myXmlElem.InnerText = this.Scara;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ETAJ");
            myXmlElem.InnerText = this.Etaj;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("APARTAMENT");
            myXmlElem.InnerText = this.Apartament;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CODINTERFON");
            myXmlElem.InnerText = this.CodInterfon;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDTARA");
            myXmlElem.InnerText = Convert.ToString(this.IdTara);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDREGIUNE");
            myXmlElem.InnerText = Convert.ToString(this.IdRegiune);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCALITATE");
            myXmlElem.InnerText = Convert.ToString(this.IdLocalitate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CODPOSTAL");
            myXmlElem.InnerText = this.CodPostal;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAVERIFICARE");
            myXmlElem.InnerText = Convert.ToString(this.DataVerificare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("COMENTARIU");
            myXmlElem.InnerText = this.Comentariu;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPPROPRIETAR");
            myXmlElem.InnerText = Convert.ToString(this.TipProprietar);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDPROPRIETAR");
            myXmlElem.InnerText = Convert.ToString(this.IdProprietar);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("LATITUDINE");
            myXmlElem.InnerText = Convert.ToString(this.Latitudine);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("LONGITUDINE");
            myXmlElem.InnerText = Convert.ToString(this.Longitudine);
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