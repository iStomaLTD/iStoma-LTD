using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab.Utilizatori;
using CCL.DAL;
using CCL.iStomaLab;
using CCL.iStomaLab.Utile;
using CCL.UI;
using CDL.iStomaLab;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ILL.BLL.General;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.iStomaLab.BDefinitiiGenerale;

namespace iStomaLab
{
    #region Enumerari

    public enum EnumRubricaEmail
    {
        Inbox = 1,
        Drafts = 2,
        Sent = 3,
        Trash = 4
    }
    public enum EnumWindowStates
    {
        SW_SHOWNORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
    }

    #endregion

    internal static class IHMUtile
    {
        internal static ILL.General.Interfete.IAccesTotal _AccesTotal = null;

        //Cum sta cu plata?
        private static string _SCumStaCuPlata = string.Empty;
        private static string _SActivare = "33";
        private static string _MesajEroare = "";
        private static DateTime _SDataServer = CConstante.DataNula;
        private static DateTime _SDataVerifServerIStoma = CConstante.DataNula;
        private static bool _SExistaUpgradeDisponibil = false;
        private const string _SOFT_REG = @"SOFTWARE\iStomaLTD";

        public static OpenFileDialog _AccesDisk = null;

        internal static Image GetImagineSageataJos()
        {
            return Properties.Resources.collapse;
        }

        internal static Image GetImagineSageataDreapta()
        {
            return Properties.Resources.expand;
        }

        public static Tuple<DateTime, DateTime> GetPerioada(System.Windows.Forms.Form pEcranParinte, DateTime pDataInceput, DateTime pDataSfarsit)
        {
            return Caramizi.FormSelecteazaDate.Afiseaza(pEcranParinte, pDataInceput, pDataSfarsit);
        }

        public static void seteazaConexiuneRaport(ReportDocument pRaport)
        {
            string cheie = CInterfataSQLServer.GetConnectionString();// getCheieConfigurare("SQLConnection");

            string[] strConnection = cheie.Split(new char[] { ';' });
            //ConfigurationManager.ConnectionStrings[("SQLConnection")].ConnectionString.Split(new char[] { ';' });

            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = strConnection[0].Split(new char[] { '=' }).GetValue(1).ToString();
            crConnectionInfo.DatabaseName = strConnection[1].Split(new char[] { '=' }).GetValue(1).ToString();
            crConnectionInfo.UserID = strConnection[2].Split(new char[] { '=' }).GetValue(1).ToString();
            crConnectionInfo.Password = strConnection[3].Split(new char[] { '=' }).GetValue(1).ToString();

            Tables CrTables;
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            CrTables = pRaport.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
        }

        #region Adrese

        public static BAdrese AdaugaAdresa(Form pEcranParinte, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar)
        {
            if (pIdProprietar > 0)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pTipProprietar, pIdProprietar, BAdrese.EnumTipAdresa.Principala, true, true, true);

            return null;
        }

        public static BAdrese AdaugaAdresa(Form pEcranParinte, IProprietar pObiectProprietarAdresa)
        {
            if (pObiectProprietarAdresa != null)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pObiectProprietarAdresa, true, true, true);

            return null;
        }

        public static BAdrese GetAdresa(Form pEcranParinte, CDefinitiiComune.EnumTipObiect pTipProprietar, int pIdProprietar, bool pEcranInModificare)
        {
            if (pIdProprietar > 0)
                return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pTipProprietar, pIdProprietar, BAdrese.EnumTipAdresa.Principala, false, true, pEcranInModificare);

            return null;
        }

        public static BAdrese GetAdresa(Form pEcranParinte, IProprietar pObiectProprietarAdresa, bool pEcranInModificare)
        {
            return Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pObiectProprietarAdresa, false, true, pEcranInModificare);
        }

        internal static void ModificaAdresa(Form pEcranParinte, BAdrese pAdresa, bool pEcranInModificare)
        {
            Generale.frmAfiseazaAdresa.AfiseazaEcran(pEcranParinte, pAdresa, pEcranInModificare);
        }

        #endregion

        #region Clienti

        internal static void DeschideDosarClient(Form pEcranParinte, int pIdClient)
        {
            TablouDeBord.Clienti.FormDosarClient.Afiseaza(pEcranParinte, pIdClient);
        }

        #endregion

        #region Comenzi-Lucrari

        internal static bool DeschideComanda(Form pEcranParinte, int pIdComandaClient)
        {
            return TablouDeBord.Clienti.FormDetaliuComanda.Afiseaza(pEcranParinte, pIdComandaClient);
        }

        #endregion

        internal static bool ConfirmareStergere(Form pEcranParinte)
        {
            return Mesaj.Confirmare(pEcranParinte, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ConfirmatiStergerea), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stergere));
        }

        public static OpenFileDialog getAccesDisk()
        {
            if (_AccesDisk == null)
                _AccesDisk = new OpenFileDialog();

            return _AccesDisk;
        }

        public static List<int> GetListaKey(Dictionary<int, double> pDict)
        {
            List<int> listaRetur = pDict.Keys.ToList<int>();

            return listaRetur;
        }

        public static FileInfo GetFisierUnic(Form pEcranParinte)
        {
            using (OpenFileDialog accesDisk = getAccesDisk())
            {
                accesDisk.Filter = StructTipDocument.GetFiltruByEnum(EnumTipDocument.Nedefinit);
                accesDisk.Multiselect = false;

                if (CCL.UI.IHMUtile.DeschideEcran(pEcranParinte, accesDisk))
                {
                    return new FileInfo(accesDisk.FileName);
                }

                return null;
            }
        }

        public static bool VerificaSiInstaleazaCrystalReports(string pSAPCrystalReports, bool x86Platform)
        {
            string sapKey = string.Empty;
            try
            {
                if (x86Platform)
                    sapKey = @"Software\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0";//@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                else
                    sapKey = @"SOFTWARE\Wow6432Node\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0"; //@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(sapKey))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            //if (sk.GetValue("Crystal Reports") != null && sk.GetValue("Crystal Reports").ToString().ToUpper().Equals(pSAPCrystalReports.ToUpper()))
                            if (sk.GetValueNames() != null)
                            {
                                return true; //exista
                            }
                        }
                    }
                    rk.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        internal static Tuple<string, string> verificaCalculatorul()
        {
            //MessageBox.Show("verificaCalculatorul");
            //Pentru a genera imaginea ce contine data verificarii -> Altfel nu putem transforma sirurile de caractere
            CSecuritate.Marcheaza(Properties.Resources.idv);
            return verifCalc();
        }

        private static string getCheieLicenta()
        {
            RegistryKey cheie = Registry.CurrentUser.OpenSubKey(@_SOFT_REG);
            if (cheie != null)
                return Convert.ToString(cheie.GetValue("LICENTA"));

            return string.Empty;
        }

        internal static Tuple<string, string> verifCalc()
        {
            //MessageBox.Show("Verif calc");
            Tuple<string, string> retur = null;
            _SActivare = "33";
            _MesajEroare = string.Empty;
            _SDataVerifServerIStoma = CConstante.DataNula;

            try
            {
                //MessageBox.Show("Inainte de net");
                if (CCL.iStomaLab.Utile.CGestiuneIO.ExistaConexiuneInternet())
                {
                    //MessageBox.Show("Are net");

                    BMasina.setIdMasina();

                    BUtilizator userIST = BUtilizator.GetUtilizatorISTOMA(null);

                    iStatie.ValidareStatieDeLucruSoapClient verif = new iStatie.ValidareStatieDeLucruSoapClient();

                    string idMasina = BMasina.getIdMasina();
                    string licenta = getCheieLicenta();

                    string raspuns = verif.VerificaStatiaV2(userIST.ContStoma, userIST.ParolaStoma, licenta, idMasina, BMasina.getDenumireMasina());

                    //if (BComportamentAplicatie.SeVerificaLInBDD())
                    //{
                    //    //Scriem raspunsul primit si in baza pentru ca celelalte calculatoare sa isi faca verificarea acolo
                    //    BComportamentAplicatie.SetUltimulRaspunsVL(raspuns);
                    //}
                    //MessageBox.Show(raspuns);
                    _SDataServer = CSecuritate.FinalizeazaInregistrarea(raspuns);
                    verif.Close();

                    if (_SDataServer != CConstante.DataNula)
                        _SActivare = "13";
                    else
                        _SActivare = "66";
                    verif.Close();

                    Actualizari.ActualizariSoapClient act = new Actualizari.ActualizariSoapClient();
                    _SExistaUpgradeDisponibil = act.ExistaActualizareDisponibila(userIST.ContStoma, userIST.ParolaStoma, getCheieLicenta(), BMasina.getIdMasina());
                    act.Close();

                    verif = null;

                    if (_SActivare.Equals("66"))
                    {
                        if (!string.IsNullOrEmpty(raspuns))
                            retur = new Tuple<string, string>(string.Empty, string.Empty);
                        else
                            retur = new Tuple<string, string>(String.Format("{0} - {1} - ({2}:{3} - {4:dd.MM.yyyy HH:mm})", "Contactati un reprezentant IDAVA SOLUTIONS", BMasina.getIdMasina(), userIST != null ? userIST.ContStoma : "U", userIST != null ? userIST.ParolaStoma : "P", DateTime.Now), "Licenta iStoma LTD");
                    }
                    else
                    {
                        iStoma.VerificareSoapClient plata = new iStoma.VerificareSoapClient();
                        _SCumStaCuPlata = plata.CumStaCuPlata(userIST.ContStoma, userIST.ParolaStoma, getCheieLicenta());
                        plata.Close();
                        plata = null;
                    }

                    userIST = null;
                    _SDataVerifServerIStoma = DateTime.Now;
                }
                else
                {
                    if (!verifLicentaRecenta())
                    {
                        _SActivare = "66";
                        //"Vă rugăm să vă conectați la internet pentru verificarea licenței"

                        //Nu putem folosi multilingv cand dictionarul nu poate fi incarcat
                        retur = new Tuple<string, string>("Va rugam sa va conectati la internet pentru verificarea licentei", "Contactati un reprezentant IDAVA SOLUTIONS");
                    }
                }
            }
            catch (Exception)
            {
                //Daca avem exceptie este posibil ca acest calculator sa nu aiba acces la internet ci doar la retea.
                //In acest caz facem verificarea licentei cu baza de date
                //if (BComportamentAplicatie.SeVerificaLInBDD())
                //{
                //    CSecuritate.FinalizeazaInregistrarea(BComportamentAplicatie.GetUltimulRaspunsVLCaText());
                //}

                //Oricum nu face sens sa crape aplicatia daca nu are omul internet, indiferent de motiv
            }

            return retur;
        }

        internal static bool verifLicentaRecenta()
        {
            DateTime dataVerif = CSecuritate.getDataVerificare();

            //In lipsa unei conexiuni permanente la internet verificarea licentei este totusi necesara o data pe luna
            if (dataVerif > DateTime.Today.AddDays(1) || DateAndTime.DateDiff(DateInterval.Day, dataVerif, DateTime.Today) > 30)
                dataVerif = CConstante.DataNula;

            return dataVerif != CConstante.DataNula;
        }

        public enum EnumColoaneDGVStandardizate
        {
            colUltimaLucrare,
            colUltimaFactura
        }
        internal static void AdaugaColoanaUltimaLucrare(DataGridViewPersonalizat pDGV)
        {
            pDGV.AdaugaColoanaData(EnumColoaneDGVStandardizate.colUltimaLucrare.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaLucrare), 110, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);
        }

        internal static void AdaugaColoanaUltimaFactura(DataGridViewPersonalizat pDGV)
        {
            pDGV.AdaugaColoanaData(EnumColoaneDGVStandardizate.colUltimaFactura.ToString(), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.UltimaFactura), 110, false, DataGridViewColumnSortMode.Automatic, CConstante.FORMAT_DATA);
        }
        internal static void IncarcaRandUltimaLucrare(DataGridViewRow pRand, BClientiComenzi pUltimaLucrare)
        {
            IncarcaRandUltimaLucrare(pRand, pUltimaLucrare, string.Empty);
        }

        internal static void IncarcaRandUltimaFactura(DataGridViewRow pRand, BClientiFacturi pUltimaFactura)
        {
            IncarcaRandUltimaFactura(pRand, pUltimaFactura, string.Empty);
        }

        internal static void IncarcaRandUltimaLucrare(DataGridViewRow pRand, BClientiComenzi pUltimaLucrare, string pNumeColoanaAlerta)
        {
            if (pUltimaLucrare != null)
            {
                pRand.Cells[EnumColoaneDGVStandardizate.colUltimaLucrare.ToString()].Value = pUltimaLucrare.DataPrimire;
                pRand.Cells[EnumColoaneDGVStandardizate.colUltimaLucrare.ToString()].ToolTipText = pUltimaLucrare.ToString();

                if (DateAndTime.DateDiff(DateInterval.Day, pUltimaLucrare.DataPrimire, DateTime.Now) > 60)
                    DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGVStandardizate.colUltimaLucrare.ToString());
                else
                    DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGVStandardizate.colUltimaLucrare.ToString());

                if (!string.IsNullOrEmpty(pNumeColoanaAlerta))
                    DataGridViewPersonalizat.IndeparteazaAlerta(pRand, pNumeColoanaAlerta);
            }
            else
            {
                if (!string.IsNullOrEmpty(pNumeColoanaAlerta))
                {
                    DataGridViewPersonalizat.SeteazaAlerta(pRand, pNumeColoanaAlerta);
                    pRand.Cells[pNumeColoanaAlerta].ToolTipText = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaLucrariDeLaAceastaClinica);
                }
            }
        }

        internal static void IncarcaRandUltimaFactura(DataGridViewRow pRand, BClientiFacturi pUltimaFactura, string pNumeColoanaAlerta)
        {
            if (pUltimaFactura != null)
            {
                pRand.Cells[EnumColoaneDGVStandardizate.colUltimaFactura.ToString()].Value = pUltimaFactura.DataFactura;
                pRand.Cells[EnumColoaneDGVStandardizate.colUltimaFactura.ToString()].ToolTipText = pUltimaFactura.ToString();

                if (DateAndTime.DateDiff(DateInterval.Day, pUltimaFactura.DataFactura, DateTime.Now) > 31)
                    DataGridViewPersonalizat.SeteazaAlerta(pRand, EnumColoaneDGVStandardizate.colUltimaFactura.ToString());
                else
                    DataGridViewPersonalizat.IndeparteazaAlerta(pRand, EnumColoaneDGVStandardizate.colUltimaFactura.ToString());

                if (!string.IsNullOrEmpty(pNumeColoanaAlerta))
                    DataGridViewPersonalizat.IndeparteazaAlerta(pRand, pNumeColoanaAlerta);
            }
            else
            {
                if (!string.IsNullOrEmpty(pNumeColoanaAlerta))
                {
                    DataGridViewPersonalizat.SeteazaAlerta(pRand, pNumeColoanaAlerta);
                    pRand.Cells[pNumeColoanaAlerta].ToolTipText = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuExistaLucrariDeLaAceastaClinica);
                }
            }
        }
    }

    #region Struct Optiune Email

    public struct StructOptiuneEmail
    {
        private EnumRubricaEmail _lRubricaEmail;
        private string _sTitluLung;

        public EnumRubricaEmail Id
        {
            get { return this._lRubricaEmail; }
        }

        public string TitluLung
        {
            get { return this._sTitluLung; }
        }

        public static StructOptiuneEmail Empty
        {
            get { return new StructOptiuneEmail(EnumRubricaEmail.Inbox, string.Empty); }
        }

        public StructOptiuneEmail(EnumRubricaEmail lRubricaEmail, string sTitluLung)
        {
            this._lRubricaEmail = lRubricaEmail;
            this._sTitluLung = sTitluLung;
        }

        public static List<StructOptiuneEmail> getListaRubriciEmail()
        {
            List<StructOptiuneEmail> lstRubriciEmail = new List<StructOptiuneEmail>();
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Inbox));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Drafts));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Sent));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Trash));
            return lstRubriciEmail;
        }

        public static StructOptiuneEmail getStructByEnum(EnumRubricaEmail lRubricaEmail)
        {
            switch (lRubricaEmail)
            {
                case EnumRubricaEmail.Inbox:
                    return new StructOptiuneEmail(EnumRubricaEmail.Inbox,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inbox));
                case EnumRubricaEmail.Drafts:
                    return new StructOptiuneEmail(EnumRubricaEmail.Drafts,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Drafts));
                case EnumRubricaEmail.Sent:
                    return new StructOptiuneEmail(EnumRubricaEmail.Sent,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sent));
                case EnumRubricaEmail.Trash:
                    return new StructOptiuneEmail(EnumRubricaEmail.Trash,
                        BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Trash));
            }

            return Empty;
        }

        public override string ToString()
        {
            return this.TitluLung;
        }
    }

    #endregion

    #region Struct Indice Flag Email

    public struct StructIndiceFlag
    {
        private EnumRubricaEmail _lRubricaEmail;
        private int _lIdFlag;

        public EnumRubricaEmail Id
        {
            get { return this._lRubricaEmail; }
        }

        public int IdFlag
        {
            get { return this._lIdFlag; }
        }

        public static StructIndiceFlag Empty
        {
            get { return new StructIndiceFlag(EnumRubricaEmail.Inbox, 1); }
        }

        public StructIndiceFlag(EnumRubricaEmail lRubricaEmail, int lIdFlag)
        {
            this._lRubricaEmail = lRubricaEmail;
            this._lIdFlag = lIdFlag;
        }

        public static List<StructIndiceFlag> getListaRubriciEmail()
        {
            List<StructIndiceFlag> lstRubriciEmail = new List<StructIndiceFlag>();
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Inbox));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Drafts));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Sent));
            lstRubriciEmail.Add(getStructByEnum(EnumRubricaEmail.Trash));
            return lstRubriciEmail;
        }

        public static StructIndiceFlag getStructByEnum(EnumRubricaEmail lRubricaEmail)
        {
            switch (lRubricaEmail)
            {
                case EnumRubricaEmail.Inbox:
                    return new StructIndiceFlag(EnumRubricaEmail.Inbox, 7);
                case EnumRubricaEmail.Drafts:
                    return new StructIndiceFlag(EnumRubricaEmail.Drafts, 4);
                case EnumRubricaEmail.Sent:
                    return new StructIndiceFlag(EnumRubricaEmail.Sent, 2);
                case EnumRubricaEmail.Trash:
                    return new StructIndiceFlag(EnumRubricaEmail.Trash, 8);
            }

            return Empty;
        }

    }

    #endregion

    #region StructImportClienti

    public struct StructImportClienti
    {
        private int _lId;
        private string _lDenumireCabinet;
        private string _lNumeClient;
        private string _lPrenumeClient;

        public int Id
        {
            get { return this._lId; }
        }

        public string DenumireCabinet
        {
            get { return this._lDenumireCabinet; }
        }

        public string NumeClient
        {
            get { return this._lNumeClient; }
        }

        public string PrenumeClient
        {
            get { return this._lPrenumeClient; }
        }

        public static StructImportClienti Empty
        {
            get { return new StructImportClienti(1, string.Empty, string.Empty, string.Empty); }
        }

        public StructImportClienti(int id, string denumireCabinet, string numeClient, string prenumeClient)
        {
            this._lId = id;
            this._lDenumireCabinet = denumireCabinet;
            this._lNumeClient = numeClient;
            this._lPrenumeClient = prenumeClient;
        }

        public StructImportClienti(string[] date)
        {
            this._lId = 0;
            this._lDenumireCabinet = date[0];
            Tuple<string, string> tupleNumePrenume = CUtil.GetNumePrenumeDinText(date[1]);
            this._lNumeClient = tupleNumePrenume.Item1;
            this._lPrenumeClient = tupleNumePrenume.Item2;

        }

    }

    #endregion

    #region StructImportListaPreturi

    public struct StructImportListaPreturi
    {
        private string _lCod;
        private string _lDenumire;
        private double _lPretLei;
        private double _lPretEuro;

        public string Cod
        {
            get { return this._lCod; }
        }

        public string Denumire
        {
            get { return this._lDenumire; }
        }

        public double PretLei
        {
            get { return this._lPretLei; }
        }

        public double PretEuro
        {
            get { return this._lPretEuro; }
        }

        public static StructImportListaPreturi Empty
        {
            get { return new StructImportListaPreturi(string.Empty, string.Empty, 0, 0); }
        }

        public StructImportListaPreturi(string cod, string denumire, double pretLei, double pretEuro)
        {
            this._lCod = cod;
            this._lDenumire = denumire;
            this._lPretLei = pretLei;
            this._lPretEuro = pretEuro;
        }

        public StructImportListaPreturi(string[] date)
        {
            this._lCod = date[0];

            if (date.Length == 4)
            {
                //CUtil.GetNumePrenumeDinText
                this._lDenumire = date[1];
                if (!date[2].Trim().Equals(""))
                    this._lPretLei = CUtil.GetAsDouble(date[2].Trim());
                else
                    this._lPretLei = 0;
                if (!date[3].Trim().Equals(""))
                    this._lPretEuro = CUtil.GetAsDouble(date[3].Trim());
                else
                    this._lPretEuro = 0;
            }
            else
            {
                string[] tempDate = date;
                StringBuilder sb = new StringBuilder();

                for (int i = 1; i < tempDate.Length - 3; i++)
                {
                    sb.Append(tempDate[i]);
                }

                this._lDenumire = sb.ToString();
                if (!tempDate[tempDate.Length - 1].Trim().Equals(""))
                    this._lPretLei = CUtil.GetAsDouble(tempDate[tempDate.Length - 1].Trim());
                else
                    this._lPretLei = 0;
                if (!tempDate[tempDate.Length - 2].Trim().Equals(""))
                    this._lPretEuro = CUtil.GetAsDouble(tempDate[tempDate.Length - 2].Trim());
                else
                    this._lPretEuro = 0;
            }

        }

    }

    #endregion

    #region StructImportPersonal

    public struct StructImportPersonal
    {
        private string _lNume;
        private string _lPrenume;
        private DateTime _lDataNastere;
        private string _lTelefonMobil;

        public string Nume
        {
            get { return this._lNume; }
        }

        public string Prenume
        {
            get { return this._lPrenume; }
        }

        public DateTime DataNastere
        {
            get { return this._lDataNastere; }
        }

        public string TelefonMobil
        {
            get { return this._lTelefonMobil; }
        }

        public static StructImportPersonal Empty
        {
            get { return new StructImportPersonal(string.Empty, string.Empty, CConstante.DataNula, string.Empty); }
        }

        public StructImportPersonal(string nume, string prenume, DateTime dataNasterii, string telefon) : this()
        {
            this._lNume = nume;
            this._lPrenume = prenume;
            this._lDataNastere = dataNasterii;
            this._lTelefonMobil = telefon;
        }

        public StructImportPersonal(string[] date) : this()
        {
            this._lNume = date[0];

            if (date.Length > 1)
                this._lPrenume = date[1];

            if (date.Length > 2)
                this._lDataNastere = CUtil.GetDateFromStringDataDDMMYYYY(date[2]);

            if (date.Length > 3)
                this._lTelefonMobil = date[3];

            if (string.IsNullOrEmpty(this._lPrenume) && this._lNume.Contains(" "))
            {
                Tuple<string, string> numePrenume = CUtil.GetNumePrenumeDinText(this._lNume);
                this._lNume = numePrenume.Item1;
                this._lPrenume = numePrenume.Item2;
            }
        }

    }

    #endregion
}
