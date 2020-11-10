using CCL.iStomaLab;
using CDL.iStomaLab;
using ILL.BLL.General;
using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab
{
    public static class BDefinitiiGenerale
    {

        private static double _SCursLeuEur = 0;

        public static double getCursLeuEur()
        {
            return getCursLeuEur(null);
        }

        public static double getCursLeuEur(IDbTransaction pTranzactie)
        {
            if (_SCursLeuEur == 0)
            {
                InitCursBNR();
            }

            return _SCursLeuEur;
        }

        internal static void InitCursBNR()
        {
            if (CCL.iStomaLab.Utile.CGestiuneIO.ExistaConexiuneInternet())
            {
                using (var webClient = new System.Net.WebClient())
                {
                    //Format data 2011-01-28 => {"date":"2011-01-28","rate":"4,2571"}

                    var json = string.Empty;
                    try
                    {
                        json = webClient.DownloadString("http://www.infovalutar.ro/bnr/azi/eur");

                        if (!string.IsNullOrEmpty(json))
                        {
                            int parteIntreaga = 0;
                            int parteZecimala = 0;
                            if (json.Contains("."))
                            {
                                parteIntreaga = Convert.ToInt32(json.Substring(0, json.IndexOf(".")));
                                string dupaVirgula = json.Substring(json.IndexOf(".") + 1);

                                if (!string.IsNullOrEmpty(dupaVirgula))
                                {
                                    if (dupaVirgula.Length > 2)
                                        parteZecimala = Convert.ToInt32(dupaVirgula.Substring(0, 2));
                                    else
                                        parteZecimala = Convert.ToInt32(dupaVirgula);
                                }
                                _SCursLeuEur = Convert.ToDouble(parteIntreaga * 100 + parteZecimala) / 100;
                            }
                            else
                                _SCursLeuEur = Convert.ToDouble(json);

                            CCL.iStomaLab.Utile.CGestiuneIO.setCursBNR(_SCursLeuEur);
                        }
                    }
                    catch (Exception)
                    {
                        //In caz de exceptie vom incerca alt serviciu
                        try
                        {
                            json = webClient.DownloadString(string.Format("http://openapi.ro/api/exchange/eur.json?date={0:yyyy}-{0:MM}-{0:dd}", DateTime.Now));
                        }
                        catch (Exception)
                        {
                            try
                            {
                                json = webClient.DownloadString("http://openapi.ro/api/exchange/eur.json");
                            }
                            catch (Exception)
                            {
                                //In caz de exceptie nu facem nimic => vom folosi ultimul cur BNR salvat in fisierul de configurare
                                json = string.Empty;
                            }
                        }

                        string[] infoCurs = json.Split(new string[] { "\",\"" }, StringSplitOptions.None);

                        if (infoCurs.Length == 2)
                        {
                            //Daca avem informatii corecte
                            string[] curs = infoCurs[0].Replace("}", "").Replace("\"", "").Split(':');
                            if (curs.Length == 2)
                            {
                                string[] valoareCurs = curs[1].Split(new string[] { ",", "." }, StringSplitOptions.None);
                                double cursDouble = 1;
                                try
                                {
                                    if (valoareCurs.Length == 1)
                                        cursDouble = Convert.ToDouble(valoareCurs[0]);
                                    else
                                        cursDouble = (Convert.ToInt32(valoareCurs[0]) * Math.Pow(10, valoareCurs[1].Length) + Convert.ToInt32(valoareCurs[1])) / Math.Pow(10, valoareCurs[1].Length);

                                    CCL.iStomaLab.Utile.CGestiuneIO.setCursBNR(cursDouble);
                                }
                                catch (Exception ex)
                                {
                                    string test = ex.Message;

                                    cursDouble = CCL.iStomaLab.Utile.CGestiuneIO.getCursBNR();
                                }

                                _SCursLeuEur = cursDouble;
                            }
                            else
                                _SCursLeuEur = CCL.iStomaLab.Utile.CGestiuneIO.getCursBNR();
                        }
                        else
                            _SCursLeuEur = CCL.iStomaLab.Utile.CGestiuneIO.getCursBNR();
                    }

                }
            }
            else
                _SCursLeuEur = CCL.iStomaLab.Utile.CGestiuneIO.getCursBNR();
        }

        private static void setCursLeuEur(double pLeuEur)
        {
            _SCursLeuEur = pLeuEur;
        }

        private static Dictionary<DateTime, double> dictCursData = new Dictionary<DateTime, double>();

        public static string GetNumarTelefonSMSHighway(string pNrTel)
        {
            if (string.IsNullOrEmpty(pNrTel)) return string.Empty;

            pNrTel = pNrTel.Replace(".", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (pNrTel.Length == 10)
                return string.Concat("4", pNrTel);

            return pNrTel;
        }

        public static System.Drawing.Color getCuloareDinARGB(int pARGB)
        {
            if (pARGB == 0)
                return System.Drawing.Color.Empty;

            return System.Drawing.Color.FromArgb(pARGB);
        }

        public static string GetIdentitate(string pNume, string pPrenume, string pNumeDeFata, string pPorecla)
        {
            string identitate = string.Empty;

            identitate = CUtil.CapitalizeazaCuvintele(pNume.ToLower());

            if (!string.IsNullOrEmpty(pNumeDeFata))
                identitate = string.Concat(identitate, " [", CUtil.CapitalizeazaCuvintele(pNumeDeFata.ToLower()), "]");

            if (!string.IsNullOrEmpty(pPrenume))
                identitate = string.Join(" ", identitate, CUtil.CapitalizeazaCuvintele(pPrenume.ToLower()));

            if (!string.IsNullOrEmpty(pPorecla))
                identitate = string.Concat(identitate, " (", pPorecla, ")");

            return identitate.Trim();
        }

        public static int getARGBFromColor(System.Drawing.Color pCuloare)
        {
            if (pCuloare.IsEmpty)
                return 0;

            return pCuloare.ToArgb();
        }

        public delegate void ObiectGasitHandler(IAfisaj pObiect);

        public static string getListaIdPentruApelBDD<T>(List<T> pLista) where T : ICheie
        {
            string text = string.Empty;
            if (pLista != null && pLista.Count > 0)
            {
                foreach (T element in pLista)
                {
                    if (!string.IsNullOrEmpty(text))
                        text += ",";

                    text += element.Id.ToString();
                }

                text = string.Format("({0})", text);
            }
            return text;
        }

        public static string getIndicatiePerioada(CDefinitiiComune.EnumTipPerioada lTipPerioada, DateTime lDataInceput, DateTime lDataSfarsit)
        {
            //Afisam perioada
            switch (lTipPerioada)
            {
                case CDefinitiiComune.EnumTipPerioada.Custom:
                    return string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        lDataInceput,
                                                                        lDataSfarsit);
                case CDefinitiiComune.EnumTipPerioada.An:
                    string IndicatieAn = CUtil.GetIndicatieAn(lDataInceput);

                    if (!string.IsNullOrEmpty(IndicatieAn))
                        return string.Format("{0} ({1}) ", lDataInceput.Year, IndicatieAn);

                    return lDataInceput.Year.ToString();
                case CDefinitiiComune.EnumTipPerioada.Luna:
                    string IndicatieLuna = CUtil.GetIndicatieLuna(lDataInceput);
                    if (string.IsNullOrEmpty(IndicatieLuna))
                        return string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        lDataInceput,
                                                                        lDataSfarsit);
                    else
                        return string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy} ({2})",
                                                                        lDataInceput,
                                                                        lDataSfarsit,
                                                                        IndicatieLuna);
                case CDefinitiiComune.EnumTipPerioada.Saptamana:
                    string IndicatieSaptamana = CUtil.GetIndicatieSaptamana(lDataInceput);
                    if (string.IsNullOrEmpty(IndicatieSaptamana))
                        return string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy}",
                                                                        lDataInceput,
                                                                        lDataSfarsit.AddDays(-1));
                    else
                        return string.Format("{0:dd MMM yyyy} - {1:dd MMM yyyy} ({2})",
                                                                        lDataInceput,
                                                                        lDataSfarsit.AddDays(-1),
                                                                        IndicatieSaptamana);
                case CDefinitiiComune.EnumTipPerioada.Zi:
                    string IndicatieZi = CUtil.GetIndicatieZi(lDataInceput);
                    if (string.IsNullOrEmpty(IndicatieZi))
                        return string.Format("{0:dd MMM yyyy}", lDataInceput);
                    else
                        return string.Format("{0:dd MMM yyyy} ({1})", lDataInceput, IndicatieZi);
            }

            return string.Empty;
        }

        #region Filtru varsta

        public enum EnumFiltruVarsta
        {
            Indiferent = 0,
            PanaIn = 1,
            Intre = 2,
            Peste = 3
        }

        public struct StructFiltruVarsta
        {
            public EnumFiltruVarsta IdEnum { get; set; }
            public string Denumire { get; set; }

            public StructFiltruVarsta(EnumFiltruVarsta pIdEnum, string pDenumire) : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumFiltruVarsta || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumFiltruVarsta)Convert.ToInt32(obj));
                else
                    if (obj is StructFiltruVarsta)
                    return this.IdEnum.Equals(((StructFiltruVarsta)obj).IdEnum);

                return base.Equals(obj);
            }

            public static List<StructFiltruVarsta> GetLista()
            {
                List<StructFiltruVarsta> listaRetur = new List<StructFiltruVarsta>();

                listaRetur.Add(GetStructByEnum(EnumFiltruVarsta.Indiferent));
                listaRetur.Add(GetStructByEnum(EnumFiltruVarsta.PanaIn));
                listaRetur.Add(GetStructByEnum(EnumFiltruVarsta.Intre));
                listaRetur.Add(GetStructByEnum(EnumFiltruVarsta.Peste));

                return listaRetur;
            }

            public static StructFiltruVarsta GetStructByEnum(EnumFiltruVarsta pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumFiltruVarsta.Indiferent:
                        return new StructFiltruVarsta(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuConteaza));
                    case EnumFiltruVarsta.PanaIn:
                        return new StructFiltruVarsta(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PanaIn));
                    case EnumFiltruVarsta.Intre:
                        return new StructFiltruVarsta(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Intre));
                    case EnumFiltruVarsta.Peste:
                        return new StructFiltruVarsta(pIdEnum, CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.pesteCaInterval)));
                }
                return new StructFiltruVarsta(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuConteaza));
            }
        }

        #endregion

        public struct StructTipProprietarDocumente
        {
            #region Declaratii generale

            public EnumTipProprietarDocumente Id { get; set; }
            public string Nume { get; set; }

            public static StructTipProprietarDocumente Empty { get { return GetStructByEnum(EnumTipProprietarDocumente.Nedefinit); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTipProprietarDocumente(EnumTipProprietarDocumente pId, string pNume)
                : this()
            {
                this.Id = pId;
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
                {
                    if (obj is EnumTipProprietarDocumente)
                        return this.Id.Equals((EnumTipProprietarDocumente)obj);
                    else
                    {
                        if (obj is StructTipProprietarDocumente)
                            return this.Id.Equals(((StructTipProprietarDocumente)obj).Id);
                        else
                        {
                            if (obj is int)
                                return Convert.ToInt32(this.Id).Equals(Convert.ToInt32(obj));
                            else
                            {
                                if (obj is long)
                                    return Convert.ToInt64(this.Id).Equals(Convert.ToInt64(obj));
                            }
                        }
                    }
                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion //Metode suprascise

            #region Metode Publice

            public static List<StructTipProprietarDocumente> GetList()
            {
                List<StructTipProprietarDocumente> lstStruct = new List<StructTipProprietarDocumente>();
                lstStruct.Add(GetStructByEnum(EnumTipProprietarDocumente.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumTipProprietarDocumente.ImagineIdentitate));
                return lstStruct;
            }

            public static EnumTipProprietarDocumente GetEnumByString(string pNume)
            {
                EnumTipProprietarDocumente lId = EnumTipProprietarDocumente.Nedefinit;
                foreach (StructTipProprietarDocumente xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipProprietarDocumente pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipProprietarDocumente GetStructByEnum(EnumTipProprietarDocumente pId)
            {
                switch (pId)
                {
                    case EnumTipProprietarDocumente.ImagineIdentitate:
                        return new StructTipProprietarDocumente(EnumTipProprietarDocumente.ImagineIdentitate, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ImagineIdentitate));
                }
                return new StructTipProprietarDocumente(EnumTipProprietarDocumente.Nedefinit, string.Empty);
            }

            public bool Exista()
            {
                return this.Id != EnumTipProprietarDocumente.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #region Check in/out

        public enum EnumCheckInOut
        {
            CheckIn = 0,
            CheckOut = 1,
            Pauza = 2,
            Deplasare = 3,
            FinalPauza = 4,
            RevenireInClinica = 5
        }

        public struct StructCheckInOut
        {
            public EnumCheckInOut IdEnum { get; set; }
            public string Denumire { get; set; }

            public static StructCheckInOut Empty
            {
                get { return new StructCheckInOut(EnumCheckInOut.CheckIn, string.Empty); }
            }

            public StructCheckInOut(EnumCheckInOut pIdEnum, string pDenumire) : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public StructCheckInOut(string pDenumire) : this()
            {
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public bool Exista()
            {
                return this.IdEnum == EnumCheckInOut.CheckIn;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumCheckInOut || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumCheckInOut)Convert.ToInt32(obj));

                if (obj is StructCheckInOut)
                    return this.IdEnum.Equals(((StructCheckInOut)obj).IdEnum);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructCheckInOut GetStructByEnum(EnumCheckInOut pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumCheckInOut.CheckIn:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CheckIn));
                    case EnumCheckInOut.CheckOut:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CheckOut));
                    case EnumCheckInOut.Pauza:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pauza));
                    case EnumCheckInOut.Deplasare:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deplasare));
                    case EnumCheckInOut.FinalPauza:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.FinalPauza));
                    case EnumCheckInOut.RevenireInClinica:
                        return new StructCheckInOut(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RevenireInClinica));
                }
                return Empty;
            }

            public static StructCheckInOut GetEnumById(int pId)
            {
                switch (pId)
                {
                    case 1:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CheckIn));
                    case 2:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CheckOut));
                    case 3:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pauza));
                    case 4:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Deplasare));
                    case 5:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.FinalPauza));
                    case 6:
                        return new StructCheckInOut(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.RevenireInClinica));
                }
                return Empty;
            }

            public static List<StructCheckInOut> GetListCheckIn()
            {
                List<StructCheckInOut> listaRetur = new List<StructCheckInOut>();

                listaRetur.Add(GetStructByEnum(EnumCheckInOut.CheckIn));

                return listaRetur;
            }

            public static List<StructCheckInOut> GetListPauza()
            {
                List<StructCheckInOut> listaRetur = new List<StructCheckInOut>();

                listaRetur.Add(GetStructByEnum(EnumCheckInOut.FinalPauza));

                return listaRetur;
            }

            public static List<StructCheckInOut> GetListDeplasare()
            {
                List<StructCheckInOut> listaRetur = new List<StructCheckInOut>();

                listaRetur.Add(GetStructByEnum(EnumCheckInOut.RevenireInClinica));

                return listaRetur;
            }

            public static string GetDenumireTip(int pIdEnum)
            {
                return GetEnumById(pIdEnum).ToString();
            }

            public static List<StructCheckInOut> GetListCheckOut()
            {
                List<StructCheckInOut> listaRetur = new List<StructCheckInOut>();

                listaRetur.Add(GetStructByEnum(EnumCheckInOut.CheckOut));
                listaRetur.Add(GetStructByEnum(EnumCheckInOut.Pauza));
                listaRetur.Add(GetStructByEnum(EnumCheckInOut.Deplasare));

                return listaRetur;
            }
        }

        #endregion

        #region Tip Contract

        public enum EnumTipContract
        {
            Nedefinit = 0,
            ContractIndividualDeMunca = 1,
            ContractDeColaborare = 2
        }

        public struct StructTipContract
        {
            public EnumTipContract IdEnum { get; set; }
            public string Denumire { get; set; }

            public static StructTipContract Empty
            {
                get { return new StructTipContract(EnumTipContract.Nedefinit, string.Empty); }
            }

            public StructTipContract(EnumTipContract pIdEnum, string pDenumire) : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumTipContract.Nedefinit;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumTipContract || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTipContract)Convert.ToInt32(obj));

                if (obj is StructTipContract)
                    return this.IdEnum.Equals(((StructTipContract)obj).IdEnum);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructTipContract GetStructByEnum(EnumTipContract pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumTipContract.ContractIndividualDeMunca:
                        return new StructTipContract(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContractIndividualDeMunca));
                    case EnumTipContract.ContractDeColaborare:
                        return new StructTipContract(pIdEnum, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ContractDeColaborare));
                }
                return Empty;
            }

            public static List<StructTipContract> GetList()
            {
                List<StructTipContract> listaRetur = new List<StructTipContract>();

                listaRetur.Add(GetStructByEnum(EnumTipContract.Nedefinit));
                listaRetur.Add(GetStructByEnum(EnumTipContract.ContractIndividualDeMunca));
                listaRetur.Add(GetStructByEnum(EnumTipContract.ContractDeColaborare));

                return listaRetur;
            }
        }

        #endregion

        #region EnumTipFiscalitate

        public enum EnumTipFiscalitate
        {
            Nedefinit = 0,
            CMI = 1,
            SRL = 2,
            PFA = 3,
            II = 4
        }

        #endregion

        #region EnumModalitatePlata + StructModalitatePlata

        public enum EnumModalitatePlata
        {
            Nedefinit = 0,
            CarteaDeCredit = 1,
            Banca = 2,
            Cash = 3,
        }

        public struct StructModalitatePlata : ICheie, IAfisaj
        {
            #region Declaratii generale

            public EnumModalitatePlata IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }
            public bool NevoieImprimare { get; private set; }
            public string DenumireAfisaj { get { return this.Nume; } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.StructModalitatePlata; } }

            public static StructModalitatePlata Empty { get { return new StructModalitatePlata(EnumModalitatePlata.Nedefinit, string.Empty, false); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructModalitatePlata(EnumModalitatePlata pId, string pNume, bool pNevoieImprimare)
                : this()
            {
                this.IdEnum = pId;
                this.Nume = pNume;
                this.NevoieImprimare = pNevoieImprimare;
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
                    if (obj is EnumModalitatePlata || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumModalitatePlata)obj);
                else
                        if (obj is StructModalitatePlata)
                    return this.IdEnum.Equals(((StructModalitatePlata)obj).IdEnum);
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

            public static List<StructModalitatePlata> GetList()
            {
                List<StructModalitatePlata> lstStruct = new List<StructModalitatePlata>();

                return lstStruct;
            }

            public static List<StructModalitatePlata> GetListaModalitatiAchitare(bool pCuEmpty)
            {
                List<StructModalitatePlata> listaRetur = new List<StructModalitatePlata>();
                if (pCuEmpty)
                    listaRetur.Add(GetStructByEnum(EnumModalitatePlata.Nedefinit));

                listaRetur.Add(GetStructByEnum(EnumModalitatePlata.Banca));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlata.Cash));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlata.CarteaDeCredit));

                return listaRetur;
            }

            public static EnumModalitatePlata GetEnumByString(string pNume)
            {
                EnumModalitatePlata lId = EnumModalitatePlata.Nedefinit;
                foreach (StructModalitatePlata xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumModalitatePlata pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructModalitatePlata GetStructByEnum(EnumModalitatePlata pId)
            {
                switch (pId)
                {

                    case EnumModalitatePlata.CarteaDeCredit:
                        return new StructModalitatePlata(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.POS), false);
                    case EnumModalitatePlata.Cash:
                        return new StructModalitatePlata(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cash), true);
                    case EnumModalitatePlata.Banca:
                        return new StructModalitatePlata(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca), false);

                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumModalitatePlata.Nedefinit;
            }

            public bool NecesitaContBancar()
            {
                return this.IdEnum == EnumModalitatePlata.Banca || this.IdEnum == EnumModalitatePlata.CarteaDeCredit;
            }

            public Color GetCuloare()
            {
                switch (this.IdEnum)
                {
                    case EnumModalitatePlata.Cash:
                        return Color.SpringGreen;
                    case EnumModalitatePlata.CarteaDeCredit:
                        return Color.SteelBlue;
                    case EnumModalitatePlata.Banca:
                        return Color.LightGray;
                }

                return Color.Silver;
            }

            #endregion //Metode Publice

        }

        #endregion

        #region Tip Fiscalitate

        public struct StructTipFiscalitate
        {
            #region Declaratii generale

            public EnumTipFiscalitate IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructTipFiscalitate Empty { get { return new StructTipFiscalitate(EnumTipFiscalitate.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTipFiscalitate(EnumTipFiscalitate pId, string pNume)
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
                    if (obj is EnumTipFiscalitate || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTipFiscalitate)obj);
                else
                        if (obj is StructTipFiscalitate)
                    return this.IdEnum.Equals(((StructTipFiscalitate)obj).IdEnum);
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

            public static List<StructTipFiscalitate> GetListaTipFiscalitate()
            {
                List<StructTipFiscalitate> listaRetur = new List<StructTipFiscalitate>();

                listaRetur.Add(GetStructByEnum(EnumTipFiscalitate.Nedefinit));
                listaRetur.Add(GetStructByEnum(EnumTipFiscalitate.SRL));
                listaRetur.Add(GetStructByEnum(EnumTipFiscalitate.CMI));
                listaRetur.Add(GetStructByEnum(EnumTipFiscalitate.PFA));
                listaRetur.Add(GetStructByEnum(EnumTipFiscalitate.II));

                return listaRetur;
            }

            public static EnumTipFiscalitate GetEnumByString(string pNume)
            {
                EnumTipFiscalitate lId = EnumTipFiscalitate.Nedefinit;
                foreach (StructTipFiscalitate xStruct in GetListaTipFiscalitate())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipFiscalitate pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipFiscalitate GetStructByEnum(EnumTipFiscalitate pId)
            {
                switch (pId)
                {
                    case EnumTipFiscalitate.SRL:
                        return new StructTipFiscalitate(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SRL));
                    case EnumTipFiscalitate.CMI:
                        return new StructTipFiscalitate(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CMI));
                    case EnumTipFiscalitate.PFA:
                        return new StructTipFiscalitate(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PFA));
                    case EnumTipFiscalitate.II:
                        return new StructTipFiscalitate(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.II));
                }
                return Empty;
            }

            #endregion //Metode Publice

        }

        #endregion

        #region Tip plata

        public enum EnumModalitatePlataCabinet
        {
            /// <summary>
            /// Cash
            /// </summary>
            Cash = 0,
            /// <summary>
            /// Cartea de credit - POS
            /// </summary>
            CarteaDeCredit = 1,
            /// <summary>
            /// OP
            /// </summary>
            Banca = 2,
            /// <summary>
            /// CEC
            /// </summary>
            CEC = 3,
            Voucher = 4,
            Compensare = 5
        }

        public struct StructModalitatePlataCabinet
        {
            #region Declaratii generale

            public EnumModalitatePlataCabinet IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructModalitatePlataCabinet Empty { get { return new StructModalitatePlataCabinet(EnumModalitatePlataCabinet.Cash, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructModalitatePlataCabinet(EnumModalitatePlataCabinet pId, string pNume)
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
                    if (obj is EnumModalitatePlataCabinet || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumModalitatePlataCabinet)obj);
                else
                        if (obj is StructModalitatePlataCabinet)
                    return this.IdEnum.Equals(((StructModalitatePlataCabinet)obj).IdEnum);
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

            public static List<StructModalitatePlataCabinet> GetListaModalitatiAchitare()
            {
                List<StructModalitatePlataCabinet> listaRetur = new List<StructModalitatePlataCabinet>();

                listaRetur.Add(StructModalitatePlataCabinet.Empty);
                listaRetur.Add(GetStructByEnum(EnumModalitatePlataCabinet.Cash));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlataCabinet.CarteaDeCredit));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlataCabinet.Banca));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlataCabinet.Voucher));
                listaRetur.Add(GetStructByEnum(EnumModalitatePlataCabinet.Compensare));

                return listaRetur;
            }

            public static EnumModalitatePlataCabinet GetEnumByString(string pNume)
            {
                EnumModalitatePlataCabinet lId = EnumModalitatePlataCabinet.Cash;
                foreach (StructModalitatePlataCabinet xStruct in GetListaModalitatiAchitare())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumModalitatePlataCabinet pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructModalitatePlataCabinet GetStructByEnum(EnumModalitatePlataCabinet pId)
            {
                switch (pId)
                {
                    case EnumModalitatePlataCabinet.CarteaDeCredit:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.POS));
                    case EnumModalitatePlataCabinet.CEC:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CEC));
                    case EnumModalitatePlataCabinet.Cash:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Cash));
                    case EnumModalitatePlataCabinet.Banca:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banca));
                    case EnumModalitatePlataCabinet.Voucher:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Voucher));
                    case EnumModalitatePlataCabinet.Compensare:
                        return new StructModalitatePlataCabinet(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Compensare));
                }
                return Empty;
            }

            #endregion //Metode Publice

        }

        #endregion

        #region Tip Persoana

        public enum EnumTipPersoana
        {
            PersoanaFizica = 0,
            PersoanaJuridica = 1
        }

        #endregion

        #region Marime Font

        public enum EnumMarimeFont
        {
            FoarteMic = -2,
            Mic = -1,
            Normal = 0,
            Mediu = 1,
            Mare = 3
        }

        public struct StructMarimeFont
        {
            public EnumMarimeFont IdEnum { get; private set; }
            public string Denumire { get; private set; }

            public static StructMarimeFont Empty { get { return new StructMarimeFont(EnumMarimeFont.Normal, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Normal)); } }

            public StructMarimeFont(EnumMarimeFont pIdEnum, string pDenumire)
                : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumMarimeFont || obj is Int32 || obj is Int64)
                    return Convert.ToInt32(this.IdEnum).Equals(Convert.ToInt32(obj));
                else
                    if (obj is StructMarimeFont)
                    return this.IdEnum.Equals(((StructMarimeFont)obj).IdEnum);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static StructMarimeFont getStructByEnum(EnumMarimeFont pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumMarimeFont.Mediu:
                        return new StructMarimeFont(EnumMarimeFont.Mediu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Mediu));
                    case EnumMarimeFont.Mare:
                        return new StructMarimeFont(EnumMarimeFont.Mare, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Mare));
                    case EnumMarimeFont.Mic:
                        return new StructMarimeFont(EnumMarimeFont.Mic, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Mic));
                    case EnumMarimeFont.FoarteMic:
                        return new StructMarimeFont(EnumMarimeFont.FoarteMic, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.FoarteMic));
                }

                return Empty;
            }

            public static List<StructMarimeFont> getLista()
            {
                List<StructMarimeFont> listaRetur = new List<StructMarimeFont>();

                listaRetur.Add(getStructByEnum(EnumMarimeFont.Normal));
                listaRetur.Add(getStructByEnum(EnumMarimeFont.Mediu));
                listaRetur.Add(getStructByEnum(EnumMarimeFont.Mare));
                listaRetur.Add(getStructByEnum(EnumMarimeFont.Mic));
                listaRetur.Add(getStructByEnum(EnumMarimeFont.FoarteMic));

                return listaRetur;
            }
        }

        #endregion

        #region Programare agenda - Mod Afisare Telefon

        public struct StructModAfisareTelefonAgenda
        {
            public EnumModAfisareTelefonAgenda Id { get; private set; }
            public string Denumire { get; private set; }

            public StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda pId, string pDenumire)
                : this()
            {
                this.Id = pId;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public static StructModAfisareTelefonAgenda Empty
            {
                get { return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct, "0737.42.42.73"); }
            }

            public static StructModAfisareTelefonAgenda getStructByEnum(EnumModAfisareTelefonAgenda pId)
            {
                switch (pId)
                {
                    case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct:
                        return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct, "0737.42.42.73");
                    case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuSpatiu:
                        return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.GrupuriDouaSfCuSpatiu, "0737 42 42 73");
                    case EnumModAfisareTelefonAgenda.PatruTreiTreiCuPunct:
                        return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.PatruTreiTreiCuPunct, "0737.424.273");
                    case EnumModAfisareTelefonAgenda.PatruTreiTreiCuSpatiu:
                        return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.PatruTreiTreiCuSpatiu, "0737 424 273");
                    case EnumModAfisareTelefonAgenda.FaraSeparare:
                        return new StructModAfisareTelefonAgenda(EnumModAfisareTelefonAgenda.FaraSeparare, "0737424273");
                }
                return Empty;
            }

            public static List<StructModAfisareTelefonAgenda> getLista()
            {
                List<StructModAfisareTelefonAgenda> listaRetur = new List<StructModAfisareTelefonAgenda>();

                listaRetur.Add(getStructByEnum(EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct));
                listaRetur.Add(getStructByEnum(EnumModAfisareTelefonAgenda.GrupuriDouaSfCuSpatiu));
                listaRetur.Add(getStructByEnum(EnumModAfisareTelefonAgenda.PatruTreiTreiCuPunct));
                listaRetur.Add(getStructByEnum(EnumModAfisareTelefonAgenda.PatruTreiTreiCuSpatiu));
                listaRetur.Add(getStructByEnum(EnumModAfisareTelefonAgenda.FaraSeparare));

                return listaRetur;
            }

            public static StructModAfisareTelefonAgenda getStructByTitlu(string psTitlu)
            {
                foreach (StructModAfisareTelefonAgenda xElemenent in getLista())
                {
                    if (xElemenent.Denumire == psTitlu)
                    {
                        return xElemenent;
                    }
                }
                return Empty;
            }

            public static string GetNumarFormatat(string pNumarTelefon, bool pSecretizat)
            {
                return GetNumarFormatat(pNumarTelefon, EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct, pSecretizat);
            }

            public static string GetNumarFormatat(string pNumarTelefon)
            {
                return GetNumarFormatat(pNumarTelefon, EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct, false);
            }

            public static string GetNumarFormatat(string pNumarTelefon, EnumModAfisareTelefonAgenda pModAfisareTelefon, bool pSecretizat)
            {
                return CUtil.GetNumarTelefonFormatat(pNumarTelefon, pModAfisareTelefon, pSecretizat);

                //if (!string.IsNullOrEmpty(pNumarTelefon) && pNumarTelefon.Length > 6)
                //{
                //    if (pSecretizat)
                //        pNumarTelefon = string.Concat(pNumarTelefon.Substring(0, 4), "xxxx", pNumarTelefon.Substring(pNumarTelefon.Length - 3, 2));
                //    switch (pModAfisareTelefon)
                //    {
                //        case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct:
                //            return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 2), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 4, 2), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 2, 2));
                //        case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuSpatiu:
                //            return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 2), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 4, 2), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 2, 2));
                //        case EnumModAfisareTelefonAgenda.PatruTreiTreiCuPunct:
                //            return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 3), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 3));
                //        case EnumModAfisareTelefonAgenda.PatruTreiTreiCuSpatiu:
                //            return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 3), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 3));
                //    }
                //}

                //return pNumarTelefon;
            }
        }

        #endregion

        #region Raspuns - Nu stiu/Nu/Da

        public struct StructRaspuns
        {
            private EnumRaspuns lIdRaspuns;
            private string lTitlu;

            public EnumRaspuns Id
            {
                get { return this.lIdRaspuns; }
            }

            public string Titlu
            {
                get { return this.lTitlu; }
            }

            public StructRaspuns(EnumRaspuns plRaspuns, string psTitlu)
            {
                this.lIdRaspuns = plRaspuns;
                this.lTitlu = psTitlu;
            }

            public override string ToString()
            {
                return this.lTitlu;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || obj == DBNull.Value) return false;

                if (obj is EnumRaspuns || obj is int || obj is long)
                    return this.Id.Equals((EnumRaspuns)obj);

                return (this.Id == ((StructRaspuns)obj).Id);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static List<StructRaspuns> getListaRaspunsuri(bool pbExclusiv)
            {
                List<StructRaspuns> lstRaspunsuriPosibile = new List<StructRaspuns>();
                if (pbExclusiv == false)
                {
                    lstRaspunsuriPosibile.Add(getStructByEnum(EnumRaspuns.NuStiu));
                }
                lstRaspunsuriPosibile.Add(getStructByEnum(EnumRaspuns.Nu));
                lstRaspunsuriPosibile.Add(getStructByEnum(EnumRaspuns.Da));
                return lstRaspunsuriPosibile;
            }

            public static string getTitluById(EnumRaspuns pld)
            {
                return getStructByEnum(pld).lTitlu;
            }

            public static StructRaspuns getStructByEnum(EnumRaspuns pld)
            {
                switch (pld)
                {
                    case EnumRaspuns.Nu:
                        return new StructRaspuns(EnumRaspuns.Nu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionNu));
                    case EnumRaspuns.Da:
                        return new StructRaspuns(EnumRaspuns.Da, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionDa));
                }
                return new StructRaspuns(EnumRaspuns.NuStiu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.NuConteaza));
            }

            public static StructRaspuns getStructByTitlu(string psTitlu)
            {
                foreach (StructRaspuns xElemenent in getListaRaspunsuri(false))
                {
                    if (xElemenent.Titlu == psTitlu)
                    {
                        return xElemenent;
                    }
                }
                return new StructRaspuns(EnumRaspuns.Nu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionNu));
            }

            public static EnumRaspuns getEnumByBool(bool pbValoare)
            {
                if (pbValoare == true)
                    return EnumRaspuns.Da;
                else
                    return EnumRaspuns.Nu;
            }

            public static EnumRaspuns GetEnumByObject(object pVal)
            {
                if (pVal != DBNull.Value && pVal != null)
                {
                    if (Convert.ToBoolean(pVal))
                        return EnumRaspuns.Da;
                    else
                        return EnumRaspuns.Nu;
                }
                else
                    return EnumRaspuns.NuStiu;
            }

            public bool Afirmativ()
            {
                return this.Id == EnumRaspuns.Da;
            }

            public static StructRaspuns GetStructByBool(bool pAfirmativ)
            {
                if (pAfirmativ)
                    return getStructByEnum(EnumRaspuns.Da);

                return getStructByEnum(EnumRaspuns.Nu);
            }
        }

        #endregion

        #region Rol

        public struct StructRol
        {
            #region Declaratii generale

            private CDefinitiiComune.EnumRol lRol;
            private string sTitluLung;

            #endregion

            #region Proprietati

            public int IdInt
            {
                get { return Convert.ToInt32(this.lRol); }
            }

            public CDefinitiiComune.EnumRol Id
            {
                get { return this.lRol; }
            }

            public string Denumire
            {
                get { return this.sTitluLung; }
            }

            public static StructRol Empty
            {
                get { return new StructRol(CDefinitiiComune.EnumRol.Nedefinit, ""); } //"Nedefinit"); }
            }

            #endregion

            #region Constructori

            public StructRol(CDefinitiiComune.EnumRol lRol, string sTitluLung)
                : this()
            {
                this.lRol = lRol;
                this.sTitluLung = sTitluLung;
            }

            #endregion

            #region Metode publice

            public static List<StructRol> getListaRol()
            {
                List<StructRol> lstRol = new List<StructRol>();
                //lstRol.Add(Empty);
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Tehnician));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Administrativ));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Manager));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.PersonalTehnic));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Curier));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Agent));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Receptie));

                return lstRol;
            }

            public static List<StructRol> getListaRolCuEmpty()
            {
                List<StructRol> lstRol = new List<StructRol>();
                lstRol.Add(Empty);
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Tehnician));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Administrativ));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Manager));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.PersonalTehnic));

                return lstRol;
            }

            public static string getDenumireByEnum(CDefinitiiComune.EnumRol pRol)
            {
                return getStructByEnum(pRol).Denumire;
            }

            public static StructRol getStructByEnum(CDefinitiiComune.EnumRol pRol)
            {
                switch (pRol)
                {
                    case CDefinitiiComune.EnumRol.Administrativ:
                        return new StructRol(CDefinitiiComune.EnumRol.Administrativ, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Administrativ));
                    case CDefinitiiComune.EnumRol.Manager:
                        return new StructRol(CDefinitiiComune.EnumRol.Manager, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Manager));
                    case EnumRol.PersonalTehnic:
                        return new StructRol(CDefinitiiComune.EnumRol.PersonalTehnic, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PersonalTehnic));
                    case EnumRol.Tehnician:
                        return new StructRol(CDefinitiiComune.EnumRol.Tehnician, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician));
                    case EnumRol.Curier:
                        return new StructRol(pRol, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Curier));
                    case EnumRol.Receptie:
                        return new StructRol(pRol, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Receptie));
                    case EnumRol.Agent:
                        return new StructRol(pRol, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Agent));
                }

                return Empty;
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.sTitluLung;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumRol || obj is int || obj is long)
                    return ((EnumRol)obj).Equals(this.Id);
                else
                    if (obj is StructRol || obj is int || obj is long)
                    return ((StructRol)obj).Equals(this.Id);
                else
                        if (obj is string)
                    return (Convert.ToString(obj).Equals(this.Denumire));

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion
        }

        #endregion

        #region StructCalitateReprezentant

        public struct StructCalitateReprezentant
        {
            #region Declaratii generale

            private CDefinitiiComune.EnumRol lRol;
            private string sTitluLung;

            #endregion

            #region Proprietati

            public int IdInt
            {
                get { return Convert.ToInt32(this.lRol); }
            }

            public CDefinitiiComune.EnumRol Id
            {
                get { return this.lRol; }
            }

            public string Denumire
            {
                get { return this.sTitluLung; }
            }

            public static StructCalitateReprezentant Empty
            {
                get { return new StructCalitateReprezentant(CDefinitiiComune.EnumRol.Nedefinit, ""); } //"Nedefinit"); }
            }

            #endregion

            #region Constructori

            public StructCalitateReprezentant(CDefinitiiComune.EnumRol lRol, string sTitluLung)
                : this()
            {
                this.lRol = lRol;
                this.sTitluLung = sTitluLung;
            }

            #endregion

            #region Metode publice

            public static List<StructCalitateReprezentant> getListaRol()
            {
                List<StructCalitateReprezentant> lstRol = new List<StructCalitateReprezentant>();
                //lstRol.Add(Empty);
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Administrator));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.MedicTitular));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.CMI));

                return lstRol;
            }

            public static List<StructCalitateReprezentant> getListaRolCuEmpty()
            {
                List<StructCalitateReprezentant> lstRol = new List<StructCalitateReprezentant>();
                lstRol.Add(Empty);
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.Administrator));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.MedicTitular));
                lstRol.Add(getStructByEnum(CDefinitiiComune.EnumRol.CMI));

                return lstRol;
            }

            public static string getDenumireByEnum(CDefinitiiComune.EnumRol pRol)
            {
                return getStructByEnum(pRol).Denumire;
            }

            public static StructCalitateReprezentant getStructByEnum(CDefinitiiComune.EnumRol pRol)
            {
                switch (pRol)
                {
                    case CDefinitiiComune.EnumRol.Administrator:
                        return new StructCalitateReprezentant(CDefinitiiComune.EnumRol.Administrator, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Administrator));
                    case CDefinitiiComune.EnumRol.MedicTitular:
                        return new StructCalitateReprezentant(CDefinitiiComune.EnumRol.MedicTitular, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MedicTitular));
                    case EnumRol.CMI:
                        return new StructCalitateReprezentant(CDefinitiiComune.EnumRol.CMI, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CMI));
                }

                return Empty;
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.sTitluLung;
            }

            public override bool Equals(object obj)
            {
                if (obj is StructCalitateReprezentant)
                    return ((StructCalitateReprezentant)obj).Id.Equals(this.Id);
                else
                    if (obj is StructCalitateReprezentant || obj is int || obj is long)
                    return ((StructCalitateReprezentant)obj).Equals(this.Id);
                else
                        if (obj is string)
                    return (Convert.ToString(obj).Equals(this.Denumire));

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion
        }

        #endregion

        #region Sex

        public struct StructSex
        {
            #region Declaratii generale

            private CDefinitiiComune.EnumSex lSex;
            private string sTitluScurt;
            private string sTitluLung;

            #endregion

            #region Proprietati

            public int IdInt
            {
                get { return Convert.ToInt32(this.lSex); }
            }

            public CDefinitiiComune.EnumSex Id
            {
                get { return this.lSex; }
            }

            public string Prescurtare
            {
                get { return this.sTitluScurt; }
            }

            public string Denumire
            {
                get { return this.sTitluLung; }
            }

            public static StructSex Empty
            {
                get { return new StructSex(CDefinitiiComune.EnumSex.Nedefinit, "-", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionNedefinit)); } //"Nedefinit"); }
            }

            #endregion

            #region Constructori

            public StructSex(CDefinitiiComune.EnumSex lSex, string sTitluScurt, string sTitluLung)
                : this()
            {
                this.lSex = lSex;
                this.sTitluScurt = sTitluScurt;
                this.sTitluLung = sTitluLung;
            }

            #endregion

            #region Metode publice

            public static List<StructSex> getListaSex()
            {
                List<StructSex> lstSex = new List<StructSex>();
                lstSex.Add(getStructByEnum(CDefinitiiComune.EnumSex.Nedefinit));
                lstSex.Add(getStructByEnum(CDefinitiiComune.EnumSex.Barbatesc));
                lstSex.Add(getStructByEnum(CDefinitiiComune.EnumSex.Femeiesc));
                return lstSex;
            }

            public static string getDenumireByEnum(CDefinitiiComune.EnumSex pSex)
            {
                return getStructByEnum(pSex).Denumire;
            }

            public static string getPrescurtareByEnum(CDefinitiiComune.EnumSex pSex)
            {
                return getStructByEnum(pSex).Prescurtare;
            }

            public static StructSex getStructByEnum(CDefinitiiComune.EnumSex pSex)
            {
                switch (pSex)
                {
                    case CDefinitiiComune.EnumSex.Barbatesc:
                        return new StructSex(CDefinitiiComune.EnumSex.Barbatesc, "M", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionMasculin)); // "Masculin");
                    case CDefinitiiComune.EnumSex.Femeiesc:
                        return new StructSex(CDefinitiiComune.EnumSex.Femeiesc, "F", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionFeminin)); //"Feminin");
                    case EnumSex.FaraSex:
                        return new StructSex(CDefinitiiComune.EnumSex.Femeiesc, "N/A", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionNedefinit)); //"Feminin");
                }

                return Empty;
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.sTitluScurt;
            }

            public override bool Equals(object obj)
            {
                if (obj is StructSex)
                    return ((StructSex)obj).Id.Equals(this.Id);
                else
                    if (obj is EnumSex || obj is int || obj is long)
                    return ((EnumSex)obj).Equals(this.Id);
                else
                        if (obj is string)
                    return (Convert.ToString(obj).Equals(this.Denumire) || Convert.ToString(obj).Equals(this.Prescurtare));

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion
        }

        #endregion

        #region Titulatura

        public struct StructTitulatura
        {
            private CDefinitiiComune.EnumTitulatura _lTitulatura;
            private string _sTitluScurt;
            private string _sTitluLung;

            public static StructTitulatura Empty
            {
                get { return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Nedefinit, string.Empty, string.Empty); }
            }

            public CDefinitiiComune.EnumTitulatura Id
            {
                get { return this._lTitulatura; }
            }

            public int IdInt
            {
                get { return Convert.ToInt32(this._lTitulatura); }
            }

            public string TitluScurt
            {
                get { return this._sTitluScurt; }
            }

            public string TitluLung
            {
                get { return this._sTitluLung; }
            }

            public StructTitulatura(CDefinitiiComune.EnumTitulatura lTitulatura, string sTitluScurt, string sTitluLung)
            {
                this._lTitulatura = lTitulatura;
                this._sTitluScurt = sTitluScurt;
                this._sTitluLung = sTitluLung;
            }

            public static List<StructTitulatura> getListaTitulaturi()
            {
                List<StructTitulatura> lstTitulatura = new List<StructTitulatura>();

                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Domn));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Doamna));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Domnisoara));
                return lstTitulatura;
            }

            public static List<StructTitulatura> getListaTitulaturiCuEmpty()
            {
                List<StructTitulatura> lstTitulatura = new List<StructTitulatura>();

                lstTitulatura.Add(Empty);
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Domn));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Doamna));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Domnisoara));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.Doctor));
                lstTitulatura.Add(getStructByEnum(CDefinitiiComune.EnumTitulatura.ProfesorDoctor));
                return lstTitulatura;
            }

            public static StructTitulatura getStructByEnum(CDefinitiiComune.EnumTitulatura lTitulatura)
            {
                switch (lTitulatura)
                {
                    case CDefinitiiComune.EnumTitulatura.Doamna:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Doamna, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Dna),
                                 BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Doamna));
                    case CDefinitiiComune.EnumTitulatura.Doctor:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Doctor, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Dr),
                                 BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Doctor));
                    case CDefinitiiComune.EnumTitulatura.Domn:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Domn, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Dl),
                                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Domnul));
                    case CDefinitiiComune.EnumTitulatura.Domnisoara:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Domnisoara, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Dsoara),
                                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Domnisoara));
                    case CDefinitiiComune.EnumTitulatura.Profesor:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Profesor, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pr),
                                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesor));
                    case CDefinitiiComune.EnumTitulatura.ProfesorDoctor:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.ProfesorDoctor, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ProfDr),
                                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ProfesorDoctor));
                    case CDefinitiiComune.EnumTitulatura.Asistent:
                        return new StructTitulatura(CDefinitiiComune.EnumTitulatura.Asistent, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.As),
                                BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Asistent));
                }

                return Empty;
            }

            public override string ToString()
            {
                return this._sTitluScurt;
            }
        }

        #endregion

        #region Tip locatie

        public struct StructTipLocatie
        {
            private CDefinitiiComune.EnumTipLocatie _lTipLocatie;
            private string _sTitluScurt;
            private string _sTitluLung;

            public static StructTipLocatie Empty
            {
                get { return new StructTipLocatie(CDefinitiiComune.EnumTipLocatie.Nedefinit, string.Empty, string.Empty); }
            }

            public CDefinitiiComune.EnumTipLocatie Id
            {
                get { return this._lTipLocatie; }
            }

            public string TitluScurt
            {
                get { return this._sTitluScurt; }
            }

            public string TitluLung
            {
                get { return this._sTitluLung; }
            }

            public StructTipLocatie(CDefinitiiComune.EnumTipLocatie lTipLocatie, string sTitluScurt, string sTitluLung)
            {
                this._lTipLocatie = lTipLocatie;
                this._sTitluScurt = sTitluScurt;
                this._sTitluLung = sTitluLung;
            }

            public static List<StructTipLocatie> getListaLocatii()
            {
                List<StructTipLocatie> lstTipLocatie = new List<StructTipLocatie>();

                lstTipLocatie.Add(getStructByEnum(CDefinitiiComune.EnumTipLocatie.Nedefinit));
                lstTipLocatie.Add(getStructByEnum(CDefinitiiComune.EnumTipLocatie.Sediu));
                return lstTipLocatie;
            }

            public static StructTipLocatie getStructByEnum(CDefinitiiComune.EnumTipLocatie lTipLocatie)
            {
                switch (lTipLocatie)
                {
                    case CDefinitiiComune.EnumTipLocatie.Sediu:
                        return new StructTipLocatie(CDefinitiiComune.EnumTipLocatie.Sediu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sediu), BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sediu));
                }

                return Empty;
            }

            public override string ToString()
            {
                return this._sTitluScurt;
            }
        }

        #endregion

        #region Nivel de scolarizare

        public struct StructNivelScolorizare
        {
            private CDefinitiiComune.EnumNivelScolorizare _lNivelScolarizare;
            private string _sTitluScurt;
            private string _sTitluLung;

            public CDefinitiiComune.EnumNivelScolorizare Id
            {
                get { return this._lNivelScolarizare; }
            }

            public string TitluLung
            {
                get { return this._sTitluLung; }
            }

            public string TitluScurt
            {
                get { return this._sTitluScurt; }
            }

            public static StructNivelScolorizare Empty
            {
                get { return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.Nedefinit, string.Empty, string.Empty); }
            }

            public StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare lNivScolarizare, string sTitluScurt, string sTitluLung)
            {
                this._lNivelScolarizare = lNivScolarizare;
                this._sTitluScurt = sTitluScurt;
                this._sTitluLung = sTitluLung;
            }

            public static List<StructNivelScolorizare> getListaNiveluriScolarizare()
            {
                List<StructNivelScolorizare> lstNivScolarizare = new List<StructNivelScolorizare>();
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.Nedefinit));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.StudiiPostUniversitare));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.StudiiSuperioare));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.StudiiPostliceale));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.StudiiMedii));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.Profesionala));
                lstNivScolarizare.Add(getStructByEnum(CDefinitiiComune.EnumNivelScolorizare.StudiiElementare));
                return lstNivScolarizare;
            }

            public static StructNivelScolorizare getStructByEnum(CDefinitiiComune.EnumNivelScolorizare lNivelScolarizare)
            {
                switch (lNivelScolarizare)
                {
                    case CDefinitiiComune.EnumNivelScolorizare.Profesionala:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.Profesionala,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesionala),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesionala));
                    case CDefinitiiComune.EnumNivelScolorizare.StudiiElementare:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.StudiiElementare,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PrescurtareStudiiElementare),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StudiiElementare));
                    case CDefinitiiComune.EnumNivelScolorizare.StudiiMedii:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.StudiiMedii,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Liceu),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StudiiMediiLiceu));
                    case CDefinitiiComune.EnumNivelScolorizare.StudiiPostUniversitare:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.StudiiPostUniversitare,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Postuniversitare),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StudiiPostuniversitare));
                    case CDefinitiiComune.EnumNivelScolorizare.StudiiPostliceale:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.StudiiPostliceale,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Postliceala),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StudiiPostliceale));
                    case CDefinitiiComune.EnumNivelScolorizare.StudiiSuperioare:
                        return new StructNivelScolorizare(CDefinitiiComune.EnumNivelScolorizare.StudiiSuperioare,
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Superioare),
                            BMultiLingv.getElementById(BMultiLingv.EnumDictionar.StudiiSuperioare));
                }

                return Empty;
            }

            public override string ToString()
            {
                return this.TitluLung;
            }
        }

        #endregion

        #region Tip Lista

        public class StructLista
        {
            private CDefinitiiComune.EnumTipLista _lLista;
            private string _sLista;

            public CDefinitiiComune.EnumTipLista Id
            {
                get { return _lLista; }
            }

            public string TitluLung
            {
                get { return _sLista; }
            }

            public static StructLista Empty
            {
                get { return new StructLista(CDefinitiiComune.EnumTipLista.Nespecificat, string.Empty); }
            }

            public StructLista(CDefinitiiComune.EnumTipLista plLista, string psTitluLung)
            {
                this._lLista = plLista;
                this._sLista = psTitluLung;
            }

            public static List<StructLista> getLista()
            {
                List<StructLista> lstListe = new List<StructLista>();

                lstListe.Add(getListaByEnum(EnumTipLista.ListaCategorii));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaBanci));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaParametrabila));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaProfesii));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaTari));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaRegiuni));
                lstListe.Add(getListaByEnum(EnumTipLista.ListaLocalitati));

                return lstListe;
            }

            public static StructLista getListaByEnum(CDefinitiiComune.EnumTipLista lLista)
            {
                switch (lLista)
                {
                    case CDefinitiiComune.EnumTipLista.ListaProfesii:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaProfesii, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Profesii));
                    case CDefinitiiComune.EnumTipLista.ListaTari:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaTari, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tari));
                    case CDefinitiiComune.EnumTipLista.ListaLocalitati:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaLocalitati, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Localitati));
                    case CDefinitiiComune.EnumTipLista.ListaRegiuni:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaRegiuni, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Regiuni));
                    case CDefinitiiComune.EnumTipLista.ListaCategorii:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaCategorii, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Categorii));
                    case CDefinitiiComune.EnumTipLista.ListaParametrabila:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaParametrabila, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AltePersoane));
                    case CDefinitiiComune.EnumTipLista.ListaBanci:
                        return new StructLista(CDefinitiiComune.EnumTipLista.ListaBanci, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Banci));

                }
                return Empty;
            }

        }

        #endregion

        #region Dosar Client

        public struct StructDosarClient
        {
            private CDefinitiiComune.EnumTipDosarClient _lDosarClient;
            private string _sDosarClient;

            public CDefinitiiComune.EnumTipDosarClient Id
            {
                get { return _lDosarClient; }
            }

            public string TitluLung
            {
                get { return _sDosarClient; }
            }

            public static StructDosarClient Empty
            {
                get { return new StructDosarClient(CDefinitiiComune.EnumTipDosarClient.Nespecificat, string.Empty); }
            }

            public StructDosarClient(CDefinitiiComune.EnumTipDosarClient plDosarClient, string psTitluLung)
            {
                this._lDosarClient = plDosarClient;
                this._sDosarClient = psTitluLung;
            }

            public static List<StructDosarClient> getLista()
            {
                List<StructDosarClient> lstListe = new List<StructDosarClient>();
                lstListe.Add(getListaByEnum(EnumTipDosarClient.Date));
                lstListe.Add(getListaByEnum(EnumTipDosarClient.Comenzi));
                lstListe.Add(getListaByEnum(EnumTipDosarClient.Plati));

                return lstListe;
            }

            public static StructDosarClient getListaByEnum(CDefinitiiComune.EnumTipDosarClient lDosarClient)
            {
                switch (lDosarClient)
                {
                    case CDefinitiiComune.EnumTipDosarClient.Date:
                        return new StructDosarClient(CDefinitiiComune.EnumTipDosarClient.Date, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Date));
                    case CDefinitiiComune.EnumTipDosarClient.Comenzi:
                        return new StructDosarClient(CDefinitiiComune.EnumTipDosarClient.Comenzi, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comenzi));
                    case CDefinitiiComune.EnumTipDosarClient.Plati:
                        return new StructDosarClient(CDefinitiiComune.EnumTipDosarClient.Plati, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Plati));

                }
                return Empty;
            }

        }

        #endregion

        #region Stare Civila

        public struct StructStareCivila
        {
            private CDefinitiiComune.EnumStareCivila _lStareCivila;
            private string _sStareCivila;

            public CDefinitiiComune.EnumStareCivila Id
            {
                get { return _lStareCivila; }
            }

            public string TitluLung
            {
                get { return _sStareCivila; }
            }

            public static StructStareCivila Empty
            {
                get { return new StructStareCivila(CDefinitiiComune.EnumStareCivila.Nespecificat, string.Empty); }
            }

            public StructStareCivila(CDefinitiiComune.EnumStareCivila plStareCivila, string psTitluLung)
            {
                this._lStareCivila = plStareCivila;
                this._sStareCivila = psTitluLung;
            }

            public static List<StructStareCivila> getListaStariCivile()
            {
                List<StructStareCivila> lstStariCivile = new List<StructStareCivila>();
                lstStariCivile.Add(Empty);
                lstStariCivile.Add(getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila.Casatorit));
                lstStariCivile.Add(getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila.InCuplu));
                lstStariCivile.Add(getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila.Concubinaj));
                lstStariCivile.Add(getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila.Divortat));
                lstStariCivile.Add(getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila.Necasatorit));
                return lstStariCivile;
            }

            public static StructStareCivila getStareCivilaByEnum(CDefinitiiComune.EnumStareCivila lStareCivila)
            {
                switch (lStareCivila)
                {
                    case CDefinitiiComune.EnumStareCivila.Casatorit:
                        return new StructStareCivila(CDefinitiiComune.EnumStareCivila.Casatorit, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Casatorit));
                    case CDefinitiiComune.EnumStareCivila.Concubinaj:
                        return new StructStareCivila(CDefinitiiComune.EnumStareCivila.Concubinaj, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Concubinaj));
                    case CDefinitiiComune.EnumStareCivila.Divortat:
                        return new StructStareCivila(CDefinitiiComune.EnumStareCivila.Divortat, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Divortat));
                    case CDefinitiiComune.EnumStareCivila.InCuplu:
                        return new StructStareCivila(CDefinitiiComune.EnumStareCivila.InCuplu, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InCuplu));
                    case CDefinitiiComune.EnumStareCivila.Necasatorit:
                        return new StructStareCivila(CDefinitiiComune.EnumStareCivila.Necasatorit, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Necasatorit));
                }
                return Empty;
            }

            public override string ToString()
            {
                return this.TitluLung;
            }
        }

        #endregion

        #region Lunile Anului

        public enum EnumLunileAnului
        {
            Nedefinit = 0,
            Ianuarie = 1,
            Februarie = 2,
            Martie = 3,
            Aprilie = 4,
            Mai = 5,
            Iunie = 6,
            Iulie = 7,
            August = 8,
            Septembrie = 9,
            Octombrie = 10,
            Noiembrie = 11,
            Decembrie = 12
        }

        public sealed class ColectieStructLunileAnului : List<StructLunileAnului>, IAfisaj
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.ColectieStructLunileAnului; } }
        }

        public struct StructLunileAnului : ICheie, IAfisaj
        {
            #region Declaratii generale

            public EnumLunileAnului IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructLunileAnului Empty { get { return new StructLunileAnului(EnumLunileAnului.Nedefinit, string.Empty); } }
            public string DenumireAfisaj { get { return this.ToString(); } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.StructLunaAn; } }

            #endregion //Declaratii generale

            #region Constructori

            public StructLunileAnului(EnumLunileAnului pId, string pNume)
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
                    if (obj is EnumLunileAnului || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumLunileAnului)obj);
                else
                        if (obj is StructLunileAnului)
                    return this.IdEnum.Equals(((StructLunileAnului)obj).IdEnum);
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

            public static ColectieStructLunileAnului GetList()
            {
                ColectieStructLunileAnului lstStruct = new ColectieStructLunileAnului();
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Ianuarie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Februarie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Martie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Aprilie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Mai));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Iunie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Iulie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.August));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Septembrie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Octombrie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Noiembrie));
                lstStruct.Add(GetStructByEnum(EnumLunileAnului.Decembrie));
                return lstStruct;
            }

            public static EnumLunileAnului GetEnumByString(string pNume)
            {
                EnumLunileAnului lId = EnumLunileAnului.Nedefinit;
                foreach (StructLunileAnului xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumLunileAnului pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructLunileAnului GetLunaCurenta()
            {
                return GetByData(DateTime.Today);
            }

            public static StructLunileAnului GetByData(DateTime pData)
            {
                return GetStructByEnum((EnumLunileAnului)pData.Month);
            }

            public static StructLunileAnului GetStructByEnum(EnumLunileAnului pId)
            {
                switch (pId)
                {
                    case EnumLunileAnului.Ianuarie:
                        return new StructLunileAnului(EnumLunileAnului.Ianuarie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Ianuarie));
                    case EnumLunileAnului.Februarie:
                        return new StructLunileAnului(EnumLunileAnului.Februarie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Februarie));
                    case EnumLunileAnului.Martie:
                        return new StructLunileAnului(EnumLunileAnului.Martie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Martie));
                    case EnumLunileAnului.Aprilie:
                        return new StructLunileAnului(EnumLunileAnului.Aprilie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Aprilie));
                    case EnumLunileAnului.Mai:
                        return new StructLunileAnului(EnumLunileAnului.Mai, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Mai));
                    case EnumLunileAnului.Iunie:
                        return new StructLunileAnului(EnumLunileAnului.Iunie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Iunie));
                    case EnumLunileAnului.Iulie:
                        return new StructLunileAnului(EnumLunileAnului.Iulie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Iulie));
                    case EnumLunileAnului.August:
                        return new StructLunileAnului(EnumLunileAnului.August, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.August));
                    case EnumLunileAnului.Septembrie:
                        return new StructLunileAnului(EnumLunileAnului.Septembrie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Septembrie));
                    case EnumLunileAnului.Octombrie:
                        return new StructLunileAnului(EnumLunileAnului.Octombrie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Octombrie));
                    case EnumLunileAnului.Noiembrie:
                        return new StructLunileAnului(EnumLunileAnului.Noiembrie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Noiembrie));
                    case EnumLunileAnului.Decembrie:
                        return new StructLunileAnului(EnumLunileAnului.Decembrie, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Decembrie));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumLunileAnului.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #endregion

        #region EnumSemestru + StructSemestru

        public enum EnumSemestru
        {
            Nedefinit = 0,
            /// <summary>
            /// Semestrul1
            /// </summary>
            Semestrul1 = 1,
            /// <summary>
            /// Semestrul2
            /// </summary>
            Semestrul2 = 2
        }

        public sealed class ColectieStructSemestru : List<StructSemestru>, IAfisaj
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.ColectieStructSemestru; } }
        }

        public struct StructSemestru : ICheie
        {
            #region Declaratii generale

            public EnumSemestru IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructSemestru Empty { get { return new StructSemestru(EnumSemestru.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructSemestru(EnumSemestru pId, string pNume)
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
                    if (obj is EnumSemestru || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumSemestru)obj);
                else
                        if (obj is StructSemestru)
                    return this.IdEnum.Equals(((StructSemestru)obj).IdEnum);
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

            public static ColectieStructSemestru GetList()
            {
                ColectieStructSemestru lstStruct = new ColectieStructSemestru();
                lstStruct.Add(GetStructByEnum(EnumSemestru.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumSemestru.Semestrul1));
                lstStruct.Add(GetStructByEnum(EnumSemestru.Semestrul2));
                return lstStruct;
            }

            public static EnumSemestru GetEnumByString(string pNume)
            {
                EnumSemestru lId = EnumSemestru.Nedefinit;
                foreach (StructSemestru xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumSemestru pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructSemestru GetStructByEnum(EnumSemestru pId)
            {
                switch (pId)
                {
                    case EnumSemestru.Semestrul1:
                        return new StructSemestru(EnumSemestru.Semestrul1, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Semestrul1));
                    case EnumSemestru.Semestrul2:
                        return new StructSemestru(EnumSemestru.Semestrul2, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Semestrul2));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumSemestru.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #endregion //EnumSemestru + StructSemestru

        #region EnumTrimestru + StructTrimestru

        public enum EnumTrimestru
        {
            Nedefinit = 0,
            /// <summary>
            /// Trimestrul1
            /// </summary>
            Trimestrul1 = 1,
            /// <summary>
            /// Trimestrul2
            /// </summary>
            Trimestrul2 = 2,
            /// <summary>
            /// Trimestrul3
            /// </summary>
            Trimestrul3 = 3,
            /// <summary>
            /// Trimestrul4
            /// </summary>
            Trimestrul4 = 4
        }

        public sealed class ColectieStructTrimestru : List<StructTrimestru>, IAfisaj
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }
            public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.ColectieStructTrimestru; } }
        }

        public struct StructTrimestru : ICheie
        {
            #region Declaratii generale

            public EnumTrimestru IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructTrimestru Empty { get { return new StructTrimestru(EnumTrimestru.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTrimestru(EnumTrimestru pId, string pNume)
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
                    if (obj is EnumTrimestru || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTrimestru)obj);
                else
                        if (obj is StructTrimestru)
                    return this.IdEnum.Equals(((StructTrimestru)obj).IdEnum);
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

            public static ColectieStructTrimestru GetList()
            {
                ColectieStructTrimestru lstStruct = new ColectieStructTrimestru();
                lstStruct.Add(GetStructByEnum(EnumTrimestru.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumTrimestru.Trimestrul1));
                lstStruct.Add(GetStructByEnum(EnumTrimestru.Trimestrul2));
                lstStruct.Add(GetStructByEnum(EnumTrimestru.Trimestrul3));
                lstStruct.Add(GetStructByEnum(EnumTrimestru.Trimestrul4));
                return lstStruct;
            }

            public static EnumTrimestru GetEnumByString(string pNume)
            {
                EnumTrimestru lId = EnumTrimestru.Nedefinit;
                foreach (StructTrimestru xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTrimestru pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTrimestru GetStructByEnum(EnumTrimestru pId)
            {
                switch (pId)
                {
                    case EnumTrimestru.Trimestrul1:
                        return new StructTrimestru(EnumTrimestru.Trimestrul1, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Trimestrul1));
                    case EnumTrimestru.Trimestrul2:
                        return new StructTrimestru(EnumTrimestru.Trimestrul2, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Trimestrul2));
                    case EnumTrimestru.Trimestrul3:
                        return new StructTrimestru(EnumTrimestru.Trimestrul3, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Trimestrul3));
                    case EnumTrimestru.Trimestrul4:
                        return new StructTrimestru(EnumTrimestru.Trimestrul4, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Trimestrul4));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumTrimestru.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #endregion //EnumTrimestru + StructTrimestru

        #region Judetele Romaniei

        public enum EnumJudeteRomania
        {
            Alba = 1,
            Arad = 2,
            Arges = 3,
            Bacau = 4,
            Bihor = 5,
            BistritaNasaud = 6,
            Botosani = 7,
            Brasov = 8,
            Braila = 9,
            Buzau = 10,
            CarasSeverin = 11,
            Cluj = 12,
            Constanta = 13,
            Covasna = 14,
            Dambovita = 15,
            Dolj = 16,
            Galati = 17,
            Gorj = 18,
            Harghita = 19,
            Hunedoara = 20,
            Ialomita = 21,
            Iasi = 22,
            Ilfov = 23,
            Maramures = 24,
            Mehedinti = 25,
            Mures = 26,
            Neamt = 27,
            Olt = 28,
            Prahova = 29,
            SatuMare = 30,
            Salaj = 31,
            Sibiu = 32,
            Suceava = 33,
            Teleorman = 34,
            Timis = 35,
            Tulcea = 36,
            Vaslui = 37,
            Valcea = 38,
            Vrancea = 39,
            Bucuresti = 40,
            BucurestiS1 = 41,
            BucurestiS2 = 42,
            BucurestiS3 = 43,
            BucurestiS4 = 44,
            BucurestiS5 = 45,
            BucurestiS6 = 46,
            Calarasi = 51,
            Giurgiu = 52
        }

        #endregion

        #region EnumModComunicarePreferat + StructModComunicarePreferat

        public struct StructModComunicarePreferat
        {
            public CDefinitiiComune.EnumModComunicarePreferat Id { get; set; }
            public string Nume { get; set; }

            public static StructModComunicarePreferat Empty { get { return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.Nedefinit, string.Empty); } }
            public StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat pId, string pNume)
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
                if (obj == null)
                    return false;
                else
                    if (obj is CDefinitiiComune.EnumModComunicarePreferat || obj is int || obj is long)
                    return (this.Id == (CDefinitiiComune.EnumModComunicarePreferat)obj);
                else
                        if (obj is StructModComunicarePreferat)
                    return (this.Id == ((StructModComunicarePreferat)obj).Id);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static List<StructModComunicarePreferat> GetList()
            {
                List<StructModComunicarePreferat> lstStruct = new List<StructModComunicarePreferat>();
                lstStruct.Add(GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat.TelefonMobil));
                lstStruct.Add(GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat.TelefonFixAdresaPrincipala));
                lstStruct.Add(GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat.Mail));
                lstStruct.Add(GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat.YM));
                lstStruct.Add(GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat.Skype));
                return lstStruct;
            }

            public static StructModComunicarePreferat GetStructByEnum(CDefinitiiComune.EnumModComunicarePreferat pId)
            {
                switch (pId)
                {
                    case CDefinitiiComune.EnumModComunicarePreferat.Mail:
                        return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.Mail, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Email));
                    case CDefinitiiComune.EnumModComunicarePreferat.Skype:
                        return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.Skype, "Skype");
                    case CDefinitiiComune.EnumModComunicarePreferat.TelefonFixAdresaPrincipala:
                        return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.TelefonFixAdresaPrincipala, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonFix));
                    case CDefinitiiComune.EnumModComunicarePreferat.TelefonMobil:
                        return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.TelefonMobil, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TelefonMobil));
                    case CDefinitiiComune.EnumModComunicarePreferat.YM:
                        return new StructModComunicarePreferat(CDefinitiiComune.EnumModComunicarePreferat.YM, "Yahoo Messenger");
                }

                return Empty;
            }

            public static CDefinitiiComune.EnumModComunicarePreferat GetEnumByString(string pNume)
            {
                CDefinitiiComune.EnumModComunicarePreferat lId = CDefinitiiComune.EnumModComunicarePreferat.Nedefinit;
                foreach (StructModComunicarePreferat xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(CDefinitiiComune.EnumModComunicarePreferat pId)
            {
                return GetStructByEnum(pId).Nume;
            }
        }

        #endregion //EnumModComunicarePreferat + StructModComunicarePreferat

        #region EnumTipDurata + StructTipDurata

        public enum EnumTipDurata
        {
            Nedefinit = 0,
            /// <summary>
            /// Perioadă
            /// </summary>
            Perioda = 1,
            /// <summary>
            /// Perioadă orară
            /// </summary>
            PerioadaOrara = 2,
            /// <summary>
            /// Dată unică
            /// </summary>
            DataUnica = 3
        }

        public struct StructTipDurata
        {

            #region Declaratii generale

            public EnumTipDurata Id { get; set; }
            public string Nume { get; set; }

            public static StructTipDurata Empty
            {
                get { return new StructTipDurata(EnumTipDurata.Nedefinit, string.Empty); }
            }

            #endregion

            #region Constructori

            public StructTipDurata(EnumTipDurata pId, string pNume)
                : this()
            {
                this.Id = pId;
                this.Nume = pNume;
            }

            #endregion

            #region Metode Suprascrise

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                else
                    if (obj is EnumTipDurata || obj is int || obj is long)
                    return (this.Id == (EnumTipDurata)obj);
                else
                        if (obj is StructTipDurata)
                    return (this.Id == ((StructTipDurata)obj).Id);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion

            #region Metode Publice

            public static List<StructTipDurata> GetList()
            {
                List<StructTipDurata> lstStruct = new List<StructTipDurata>();
                lstStruct.Add(GetStructByEnum(EnumTipDurata.Perioda));
                lstStruct.Add(GetStructByEnum(EnumTipDurata.PerioadaOrara));
                lstStruct.Add(GetStructByEnum(EnumTipDurata.DataUnica));
                return lstStruct;
            }

            public static EnumTipDurata GetEnumByString(string pNume)
            {
                EnumTipDurata lId = EnumTipDurata.Nedefinit;
                foreach (StructTipDurata xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipDurata pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipDurata GetStructByEnum(EnumTipDurata pId)
            {
                switch (pId)
                {
                    case EnumTipDurata.Perioda:
                        return new StructTipDurata(EnumTipDurata.Perioda, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Perioada)); // "Perioadă");
                    case EnumTipDurata.PerioadaOrara:
                        return new StructTipDurata(EnumTipDurata.PerioadaOrara, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PerioadaOrara)); //"Perioadă orară");
                    case EnumTipDurata.DataUnica:
                        return new StructTipDurata(EnumTipDurata.DataUnica, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataUnica)); //"Dată unică");
                }

                return Empty;
            }

            public bool Exista()
            {
                return this.Id != EnumTipDurata.Nedefinit;
            }

            #endregion
        }

        #endregion //EnumTipDurata + StructTipDurata

        #region EnumConfirmare + StructConfirmare

        public enum EnumConfirmare
        {
            Nedefinit = 0,
            /// <summary>
            /// Confirmat
            /// </summary>
            Confirmat = 1,
            /// <summary>
            /// Infirmat
            /// </summary>
            Infirmat = 2,
            /// <summary>
            /// Nedeterminat
            /// </summary>
            Nedeterminat = 3
        }

        public struct StructConfirmare
        {
            #region Declaratii generale

            public EnumConfirmare Id { get; set; }
            public string Nume { get; set; }

            public string NumeFaraDiacritice
            {
                get { return CUtil.InlocuiesteDiacritice(this.Nume); }
            }

            public static StructConfirmare Empty
            {
                get { return new StructConfirmare(EnumConfirmare.Nedefinit, string.Empty); }
            }

            #endregion

            #region Constructori

            public StructConfirmare(EnumConfirmare pId, string pNume)
                : this()
            {
                this.Id = pId;
                this.Nume = pNume;
            }

            #endregion

            #region Metode Suprascrise

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                else
                    if (obj is EnumConfirmare || obj is int || obj is long)
                    return (this.Id == (EnumConfirmare)obj);
                else
                        if (obj is StructConfirmare)
                    return (this.Id == ((StructConfirmare)obj).Id);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion

            #region Metode publice

            public static List<StructConfirmare> GetList()
            {
                List<StructConfirmare> lstStruct = new List<StructConfirmare>();
                lstStruct.Add(GetStructByEnum(EnumConfirmare.Confirmat));
                lstStruct.Add(GetStructByEnum(EnumConfirmare.Infirmat));
                lstStruct.Add(GetStructByEnum(EnumConfirmare.Nedeterminat));
                return lstStruct;
            }

            public static EnumConfirmare GetEnumByString(string pNume)
            {
                EnumConfirmare lId = EnumConfirmare.Nedefinit;
                foreach (StructConfirmare xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumConfirmare pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructConfirmare GetStructByEnum(EnumConfirmare pId)
            {
                switch (pId)
                {
                    case EnumConfirmare.Confirmat:
                        return new StructConfirmare(EnumConfirmare.Confirmat, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Confirmat));
                    case EnumConfirmare.Infirmat:
                        return new StructConfirmare(EnumConfirmare.Infirmat, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Infirmat));
                    case EnumConfirmare.Nedeterminat:
                        return new StructConfirmare(EnumConfirmare.Nedeterminat, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Nedeterminat));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.Id != EnumConfirmare.Nedefinit;
            }

            #endregion
        }

        #endregion //EnumConfirmare + StructConfirmare

        #region EnumTipIntervalOrarPreferat + StructTipIntervalOrarPreferat

        public enum EnumTipIntervalOrarPreferat
        {
            Nedefinit = 0,
            /// <summary>
            /// Oricand
            /// </summary>
            Oricand = 1,
            /// <summary>
            /// Pana in
            /// </summary>
            PanaLaOra = 2,
            /// <summary>
            /// Intr-un interval anume
            /// </summary>
            IntrunIntervalAnume = 3,
            /// <summary>
            /// Dupa ora
            /// </summary>
            DupaOra = 4
        }

        public struct StructTipIntervalOrarPreferat : ICheie
        {
            #region Declaratii generale

            public EnumTipIntervalOrarPreferat IdEnum { get; private set; }
            public int Id { get { return (int)this.IdEnum; } }
            public string Nume { get; private set; }

            public static StructTipIntervalOrarPreferat Empty { get { return new StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat.Nedefinit, string.Empty); } }

            #endregion //Declaratii generale

            #region Constructori

            public StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat pId, string pNume)
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
                    if (obj is EnumTipIntervalOrarPreferat || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumTipIntervalOrarPreferat)obj);
                else
                        if (obj is StructTipIntervalOrarPreferat)
                    return this.IdEnum.Equals(((StructTipIntervalOrarPreferat)obj).IdEnum);
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

            public static List<StructTipIntervalOrarPreferat> GetList()
            {
                List<StructTipIntervalOrarPreferat> lstStruct = new List<StructTipIntervalOrarPreferat>();

                lstStruct.Add(GetStructByEnum(EnumTipIntervalOrarPreferat.Oricand));
                lstStruct.Add(GetStructByEnum(EnumTipIntervalOrarPreferat.PanaLaOra));
                lstStruct.Add(GetStructByEnum(EnumTipIntervalOrarPreferat.IntrunIntervalAnume));
                lstStruct.Add(GetStructByEnum(EnumTipIntervalOrarPreferat.DupaOra));

                return lstStruct;
            }

            public static EnumTipIntervalOrarPreferat GetEnumByString(string pNume)
            {
                EnumTipIntervalOrarPreferat lId = EnumTipIntervalOrarPreferat.Nedefinit;
                foreach (StructTipIntervalOrarPreferat xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.IdEnum;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipIntervalOrarPreferat pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static StructTipIntervalOrarPreferat GetStructByEnum(EnumTipIntervalOrarPreferat pId)
            {
                switch (pId)
                {
                    case EnumTipIntervalOrarPreferat.Oricand:
                        return new StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat.Oricand, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Oricand));
                    case EnumTipIntervalOrarPreferat.PanaLaOra:
                        return new StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat.PanaLaOra, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PanaLaData));
                    case EnumTipIntervalOrarPreferat.IntrunIntervalAnume:
                        return new StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat.IntrunIntervalAnume, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Intre));
                    case EnumTipIntervalOrarPreferat.DupaOra:
                        return new StructTipIntervalOrarPreferat(EnumTipIntervalOrarPreferat.DupaOra, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DupaOra));
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.IdEnum != EnumTipIntervalOrarPreferat.Nedefinit;
            }

            #endregion //Metode Publice

        }

        #endregion //EnumTipIntervalOrarPreferat + StructTipIntervalOrarPreferat

        #region Perioada

        public enum EnumPerioada
        {
            Nedefinit = 0,
            SaptamanaAceasta = 1,
            SaptamanaViitoare = 2,
            LunaAceasta = 3,
            LunaViitoare = 4,
            LunaTrecuta = 5
        }

        public struct StructPerioada
        {
            public EnumPerioada IdEnum { get; private set; }
            public string Denumire { get; private set; }

            public static StructPerioada Empty { get { return new StructPerioada(EnumPerioada.Nedefinit, string.Empty); } }

            public StructPerioada(EnumPerioada pIdEnum, string pDenumire)
                : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumPerioada || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumPerioada)obj);
                else
                    if (obj is StructPerioada)
                    return this.IdEnum.Equals(((StructPerioada)obj).IdEnum);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static List<StructPerioada> GetList()
            {
                List<StructPerioada> listaRetur = new List<StructPerioada>();

                listaRetur.Add(GetStructByEnum(EnumPerioada.SaptamanaAceasta));
                listaRetur.Add(GetStructByEnum(EnumPerioada.SaptamanaViitoare));
                listaRetur.Add(GetStructByEnum(EnumPerioada.LunaAceasta));
                listaRetur.Add(GetStructByEnum(EnumPerioada.LunaViitoare));

                return listaRetur;
            }

            public static List<StructPerioada> GetListaPropuneriSalarii()
            {
                List<StructPerioada> listaRetur = new List<StructPerioada>();

                listaRetur.Add(GetStructByEnum(EnumPerioada.LunaTrecuta));
                listaRetur.Add(GetStructByEnum(EnumPerioada.LunaAceasta));
                listaRetur.Add(GetStructByEnum(EnumPerioada.LunaViitoare));

                return listaRetur;
            }

            public static StructPerioada GetStructByEnum(EnumPerioada pId)
            {
                switch (pId)
                {
                    case EnumPerioada.SaptamanaAceasta:
                        return new StructPerioada(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.SaptamanaAceasta));
                    case EnumPerioada.SaptamanaViitoare:
                        return new StructPerioada(pId, CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.saptamanaViitoare)));
                    case EnumPerioada.LunaAceasta:
                        return new StructPerioada(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaAceasta));
                    case EnumPerioada.LunaViitoare:
                        return new StructPerioada(pId, CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaViitoare)));
                    case EnumPerioada.LunaTrecuta:
                        return new StructPerioada(pId, CUtil.Capitalizeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LunaTrecuta)));
                }

                return Empty;
            }
        }

        #endregion

        #region StructTipDocument

        public enum EnumTipDocument
        {
            Nedefinit = 0,
            /// <summary>
            /// Imagine
            /// </summary>
            Imagine = 1,
            /// <summary>
            /// Document text
            /// </summary>
            DocumentText = 2,
            /// <summary>
            /// Înregistrare video
            /// </summary>
            InregistrareVideo = 3,
            /// <summary>
            /// Înregistrare audio
            /// </summary>
            InregistrareAudio = 4,
            /// <summary>
            /// Date existente despre pacient
            /// </summary>
            DetaliiStomaAltMedic = 5,
            iDava = 6,
            AtasamentEmail = 7,
            ColectieImaginiScanate = 8,
            LinkYoutube = 9,
            Document = 10,
            Radiografie = 11,
            ImaginiClinice = 12,
            AlteImagini = 13,
            /// <summary>
            /// Salvam HTML-ul direct in BDD
            /// </summary>
            iDava2 = 14,
            HTMLBDD = 15
        }


        public struct StructTipDocument
        {
            public EnumTipDocument Id { get; set; }
            public string Nume { get; set; }
            public string FiltruOpenFileDialog { get; set; }

            public static StructTipDocument Empty
            {
                get { return new StructTipDocument(EnumTipDocument.Nedefinit, "", "Toate(*.*)|*.*"); }
            }

            public StructTipDocument(EnumTipDocument pId, string pNume, string pFiltru)
                : this()
            {
                this.Id = pId;
                this.Nume = pNume;
                this.FiltruOpenFileDialog = pFiltru;
            }

            public override string ToString()
            {
                return this.Nume;
            }

            public bool Exista()
            {
                return this.Id != EnumTipDocument.Nedefinit;
            }

            public override bool Equals(object obj)
            {
                bool Egalitate = base.Equals(obj);
                if (obj == null)
                    Egalitate = false;
                else
                {
                    if (obj is EnumTipDocument)
                        Egalitate = (this.Id == (EnumTipDocument)obj);
                    else
                    {
                        if (obj is StructTipDocument)
                            Egalitate = (this.Id == ((StructTipDocument)obj).Id);
                        else
                        {
                            if (obj is int)
                                Egalitate = (Convert.ToInt32(this.Id) == Convert.ToInt32(obj));
                            else
                                if (obj is long)
                                Egalitate = (Convert.ToInt64(this.Id) == Convert.ToInt64(obj));
                        }
                    }
                }
                return Egalitate;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static List<StructTipDocument> GetListaTipuriProceduri()
            {
                List<StructTipDocument> lstStruct = new List<StructTipDocument>();
                lstStruct.Add(GetStructByEnum(EnumTipDocument.LinkYoutube));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.InregistrareVideo));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.Document));
                return lstStruct;
            }

            public static List<StructTipDocument> GetList()
            {
                List<StructTipDocument> lstStruct = new List<StructTipDocument>();
                lstStruct.Add(GetStructByEnum(EnumTipDocument.Nedefinit));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.Imagine));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.DocumentText));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.InregistrareVideo));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.InregistrareAudio));
                lstStruct.Add(GetStructByEnum(EnumTipDocument.DetaliiStomaAltMedic));
                return lstStruct;
            }

            public static StructTipDocument GetStructByEnum(EnumTipDocument pId)
            {
                switch (pId)
                {
                    case EnumTipDocument.Imagine:
                    case EnumTipDocument.Radiografie:
                    case EnumTipDocument.ImaginiClinice:
                    case EnumTipDocument.AlteImagini:
                        return new StructTipDocument(pId, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Imagine), "(*.jpg; *.jpeg; *.gif; *.bmp; *.ico; *.png; *.tif)|*.jpg; *.jpeg; *.gif; *.bmp; *.ico; *.png; *.tif");
                    case EnumTipDocument.DocumentText:
                        return new StructTipDocument(EnumTipDocument.DocumentText, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Documente), "(*.*)|*.*");
                    case EnumTipDocument.InregistrareVideo:
                        return new StructTipDocument(EnumTipDocument.InregistrareVideo, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MaterialVideo), "(*.*)|*.*");
                    case EnumTipDocument.InregistrareAudio:
                        return new StructTipDocument(EnumTipDocument.InregistrareAudio, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.MaterialAudio), "(*.*)|*.*");
                    //case EnumTipDocument.DetaliiStomaAltMedic:
                    //    return new StructTipDocument(EnumTipDocument.DetaliiStomaAltMedic, BMultiLingv.getElementByIdCuInlocuireTermenPersonalizat(BMultiLingv.EnumDictionar.FisaPacient), "(*.*)|*.*");
                    case EnumTipDocument.Document:
                        return new StructTipDocument(EnumTipDocument.Document, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Document), "(*.*)|*.*");
                    case EnumTipDocument.LinkYoutube:
                        return new StructTipDocument(EnumTipDocument.LinkYoutube, "Youtube", "(*.*)|*.*");
                }

                return Empty;
            }

            public static EnumTipDocument GetEnumByString(string pNume)
            {
                EnumTipDocument lId = EnumTipDocument.Nedefinit;
                foreach (StructTipDocument xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipDocument pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static string GetFiltruByEnum(EnumTipDocument pId)
            {
                return GetStructByEnum(pId).FiltruOpenFileDialog;
            }
        }

        #endregion

        public static bool EsteAceeasiIdentitate(string pNume1, string pPrenume1, string pNumePrenume2)
        {
            return string.Concat(pNume1.ToLower(), pPrenume1.ToLower()).Equals(pNumePrenume2.ToLower()) ||
                string.Concat(pPrenume1.ToLower(), pNume1.ToLower()).Equals(pNumePrenume2.ToLower());
        }

        public static bool EsteAceeasiIdentitate(string pNume1, string pPrenume1, string pNume2, string pPrenume2)
        {
            return string.Concat(pNume1.ToLower(), pPrenume1.ToLower()).Equals(string.Concat(pNume2.ToLower(), pPrenume2.ToLower())) ||
                string.Concat(pPrenume1.ToLower(), pNume1.ToLower()).Equals(string.Concat(pNume2.ToLower(), pPrenume2.ToLower()));
        }

        public static IAfisaj GetObiectListaAfisaj(List<IAfisaj> pLista, CDefinitiiComune.EnumTipObiect pTipObiect, int pIdObiect)
        {
            foreach (var item in pLista)
            {
                if (item.TipObiect == pTipObiect && item.Id == pIdObiect) return item;
            }

            return null;
        }

        public static List<IAfisaj> getAsListaAfisaj<T>(List<T> pListaObiecte) where T : IAfisaj
        {
            List<IAfisaj> listaRetur = new List<IAfisaj>();
            foreach (T elem in pListaObiecte)
            {
                listaRetur.Add(elem);
            }
            return listaRetur;
        }

        public static List<ILL.BLL.General.IElementAgenda> getAsListaElementeAgenda<T>(List<T> pListaObiecte) where T : ILL.BLL.General.IElementAgenda
        {
            List<ILL.BLL.General.IElementAgenda> listaRetur = new List<ILL.BLL.General.IElementAgenda>();
            foreach (T elem in pListaObiecte)
            {
                listaRetur.Add(elem);
            }
            return listaRetur;
        }

        /// <summary>
        /// Extragem lista id-urilor unei liste de obiecte
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pListaElemente"></param>
        /// <returns></returns>
        public static List<long> GetListaId<T>(List<T> pListaElemente) where T : BGeneral, ICheie
        {
            List<long> ListaId = new List<long>();
            foreach (T Element in pListaElemente)
            {
                ListaId.Add(Element.Id);
            }
            return ListaId;
        }

        public static void DistrugeObiecteleUtilizate()
        {
            BMultiLingv.DistrugeObiecteleStatice();
            BGeneral.DistrugeObiectele();
        }

        public static string GetDenumireZodie(DateTime pDataNastere)
        {
            if (pDataNastere != CConstante.DataNula)
            {
                if (pDataNastere <= new DateTime(pDataNastere.Year, 1, 19) || pDataNastere >= new DateTime(pDataNastere.Year, 12, 22))
                    return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Capricorn);
                else
                {
                    if (pDataNastere >= new DateTime(pDataNastere.Year, 1, 20) && pDataNastere <= new DateTime(pDataNastere.Year, 2, 18))
                        return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Varsator);
                    else
                    {
                        if (pDataNastere >= new DateTime(pDataNastere.Year, 2, 19) && pDataNastere <= new DateTime(pDataNastere.Year, 3, 20))
                            return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pesti);
                        else
                        {
                            if (pDataNastere >= new DateTime(pDataNastere.Year, 3, 21) && pDataNastere <= new DateTime(pDataNastere.Year, 4, 20))
                                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Berbec);
                            else
                            {
                                if (pDataNastere >= new DateTime(pDataNastere.Year, 4, 21) && pDataNastere <= new DateTime(pDataNastere.Year, 5, 21))
                                    return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Taur);
                                else
                                {
                                    if (pDataNastere >= new DateTime(pDataNastere.Year, 5, 22) && pDataNastere <= new DateTime(pDataNastere.Year, 6, 21))
                                        return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Gemeni);
                                    else
                                    {
                                        if (pDataNastere >= new DateTime(pDataNastere.Year, 6, 22) && pDataNastere <= new DateTime(pDataNastere.Year, 7, 22))
                                            return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rac);
                                        else
                                        {
                                            if (pDataNastere >= new DateTime(pDataNastere.Year, 7, 23) && pDataNastere <= new DateTime(pDataNastere.Year, 8, 22))
                                                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Leu);
                                            else
                                            {
                                                if (pDataNastere >= new DateTime(pDataNastere.Year, 8, 23) && pDataNastere <= new DateTime(pDataNastere.Year, 9, 21))
                                                    return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Fecioara);
                                                else
                                                {
                                                    if (pDataNastere >= new DateTime(pDataNastere.Year, 9, 22) && pDataNastere <= new DateTime(pDataNastere.Year, 10, 22))
                                                        return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Balanta);
                                                    else
                                                    {
                                                        if (pDataNastere >= new DateTime(pDataNastere.Year, 10, 23) && pDataNastere <= new DateTime(pDataNastere.Year, 11, 21))
                                                            return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Scorpion);
                                                        else
                                                        {
                                                            if (pDataNastere >= new DateTime(pDataNastere.Year, 11, 21) && pDataNastere <= new DateTime(pDataNastere.Year, 12, 21))
                                                                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Sagetator);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string GetBoolAsText(bool pValoare)
        {
            if (pValoare)
                return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionDa);

            return BMultiLingv.getElementById(BMultiLingv.EnumDictionar.captionNu);
        }
    }

    public struct StructAfisaj : IAfisaj
    {
        private string lDenumire;

        public StructAfisaj(string pDenumire)
            : this()
        {
            this.lDenumire = pDenumire;
        }

        public string DenumireAfisaj
        {
            get { return this.lDenumire; }
        }

        public int Id
        {
            get { return -1; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return CDefinitiiComune.EnumTipObiect.Nedefinit; }
        }
    }

    #region StructTipActIdentitate

    public sealed class ColectieStructTipActIdentitate : List<StructTipActIdentitate>, IAfisaj
    {
        public int Id { get { return -1; } }
        public string DenumireAfisaj { get { return this.ToString(); } }
        public CDefinitiiComune.EnumTipObiect TipObiect { get { return CDefinitiiComune.EnumTipObiect.StructTipActIdentitate; } }
    }

    public struct StructTipActIdentitate : ICheie
    {
        #region Declaratii generale

        public EnumTipActIdentitate IdEnum { get; private set; }
        public int Id { get { return (int)this.IdEnum; } }
        public string Nume { get; private set; }

        public static StructTipActIdentitate Empty { get { return new StructTipActIdentitate(EnumTipActIdentitate.Nedefinit, "Act"); } }

        #endregion //Declaratii generale

        #region Constructori

        public StructTipActIdentitate(EnumTipActIdentitate pId, string pNume)
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
                if (obj is EnumTipActIdentitate || obj is int || obj is long)
                return this.IdEnum.Equals((EnumTipActIdentitate)obj);
            else
                    if (obj is StructTipActIdentitate)
                return this.IdEnum.Equals(((StructTipActIdentitate)obj).IdEnum);
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

        public static ColectieStructTipActIdentitate GetList()
        {
            ColectieStructTipActIdentitate lstStruct = new ColectieStructTipActIdentitate();
            lstStruct.Add(GetStructByEnum(EnumTipActIdentitate.Nedefinit));
            lstStruct.Add(GetStructByEnum(EnumTipActIdentitate.CI));
            lstStruct.Add(GetStructByEnum(EnumTipActIdentitate.BI));
            lstStruct.Add(GetStructByEnum(EnumTipActIdentitate.Pasaport));
            return lstStruct;
        }

        public static EnumTipActIdentitate GetEnumByString(string pNume)
        {
            EnumTipActIdentitate lId = EnumTipActIdentitate.Nedefinit;
            foreach (StructTipActIdentitate xStruct in GetList())
            {
                if (xStruct.Nume.Equals(pNume.Trim()))
                {
                    lId = xStruct.IdEnum;
                    break;
                }
            }

            return lId;
        }

        public static string GetStringByEnum(EnumTipActIdentitate pId)
        {
            return GetStructByEnum(pId).Nume;
        }

        public static StructTipActIdentitate GetStructByEnum(EnumTipActIdentitate pId)
        {
            switch (pId)
            {
                case EnumTipActIdentitate.CI:
                    return new StructTipActIdentitate(EnumTipActIdentitate.CI, "C.I.");
                case EnumTipActIdentitate.BI:
                    return new StructTipActIdentitate(EnumTipActIdentitate.BI, "B.I.");
                case EnumTipActIdentitate.Pasaport:
                    return new StructTipActIdentitate(EnumTipActIdentitate.Pasaport, "Pașaport");
            }
            return Empty;
        }

        public bool Exista()
        {
            return this.IdEnum != EnumTipActIdentitate.Nedefinit;
        }

        #endregion //Metode Publice

    }

    #endregion //StructTipActIdentitate

    public struct StructDenumireAfisaj : IAfisaj
    {
        public int Id { get; private set; }
        public string Denumire { get; private set; }
        public string DenumireAlternativa { get; private set; }
        private CDefinitiiComune.EnumTipObiect lTipObiect;

        public StructDenumireAfisaj(int pId, string pDenumire, CDefinitiiComune.EnumTipObiect pTipObiect)
            : this()
        {
            this.Id = pId;
            this.Denumire = pDenumire;
            this.lTipObiect = pTipObiect;
        }

        public StructDenumireAfisaj(int pId, string pDenumire, string pDenumireAlternativa, CDefinitiiComune.EnumTipObiect pTipObiect)
            : this()
        {
            this.Id = pId;
            this.Denumire = pDenumire;
            this.lTipObiect = pTipObiect;
            this.DenumireAlternativa = pDenumireAlternativa;
        }

        public static StructDenumireAfisaj Empty
        {
            get { return new StructDenumireAfisaj(0, string.Empty, CDefinitiiComune.EnumTipObiect.Nedefinit); }
        }

        public bool AreValoare()
        {
            return this.Id > 0;
        }

        public string DenumireAfisaj
        {
            get { return this.Denumire; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return this.lTipObiect; }
        }

        public override string ToString()
        {
            return this.Denumire;
        }
    }

    public struct StructIdDenumire : IAfisaj
    {
        public int Id { get; private set; }
        public string Denumire { get; private set; }
        public int Tip { get; private set; }

        public StructIdDenumire(int pId, string pDenumire)
            : this()
        {
            this.Id = pId;
            this.Denumire = pDenumire;
        }

        public StructIdDenumire(int pId, int pTip, string pDenumire)
            : this()
        {
            this.Id = pId;
            this.Tip = pTip;
            this.Denumire = pDenumire;
        }

        public StructIdDenumire(IAfisaj pAfisaj)
            : this(pAfisaj != null ? pAfisaj.Id : 0, pAfisaj != null ? pAfisaj.DenumireAfisaj : string.Empty)
        {
        }

        public static StructIdDenumire Empty
        {
            get { return new StructIdDenumire(0, 0, string.Empty); }
        }

        public bool AreValoare()
        {
            return this.Id > 0;
        }

        public string DenumireAfisaj
        {
            get { return this.Denumire; }
        }

        /// <summary>
        /// Folosita la traduceri
        /// </summary>
        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return CDefinitiiComune.EnumTipObiect.MultiLingv; }
        }

        public override string ToString()
        {
            return this.Denumire;
        }

        public override bool Equals(object obj)
        {
            if (obj is int)
                return this.Id.Equals(Convert.ToInt32(obj));
            else
                if (obj is StructIdDenumire)
                return this.Id.Equals(((StructIdDenumire)obj).Id);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum EnumModColorareFundalProgramareAgenda
    {
        Nedefinit = 0,
        Medic = 1,
        CategorieInterventii = 2,
        StareProgramare = 3,
    }

    public enum EnumModImprimare
    {
        Neselectat = -1,
        FullA4 = 0,
        FullA5 = 1,
        HalfA4 = 2,
        HalfA4x2 = 3,
    }

    #region EnumRapoarte + StructRapoarte

    public enum EnumRapoarte
    {
        Nedefinit = 0,
        /// <summary>
        /// Productie tehnicieni
        /// </summary>
        ProductieTehnicieni = 1,
        /// <summary>
        /// Comenzi
        /// </summary>
        Comenzi = 2,
        /// <summary>
        /// Clienti cu datorii
        /// </summary>
        ClientiDatornici = 3,
        /// <summary>
        /// Clienti noi
        /// </summary>
        ClientiNoi = 4
    }

    public sealed class ColectieStructRapoarte : List<StructRapoarte>
    {
        public int Id { get { return -1; } }
        public string DenumireAfisaj { get { return this.ToString(); } }
    }

    public struct StructRapoarte : ICheie
    {
        #region Declaratii generale

        public EnumRapoarte IdEnum { get; private set; }
        public int Id { get { return (int)this.IdEnum; } }
        public string Nume { get; private set; }

        public static StructRapoarte Empty { get { return new StructRapoarte(EnumRapoarte.Nedefinit, string.Empty); } }

        #endregion //Declaratii generale

        #region Constructori

        public StructRapoarte(EnumRapoarte pId, string pNume)
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
                if (obj is EnumRapoarte || obj is int || obj is long)
                return this.IdEnum.Equals((EnumRapoarte)obj);
            else
                    if (obj is StructRapoarte)
                return this.IdEnum.Equals(((StructRapoarte)obj).IdEnum);
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

        public static ColectieStructRapoarte GetList()
        {
            ColectieStructRapoarte lstStruct = new ColectieStructRapoarte();
            //lstStruct.Add(GetStructByEnum(EnumRapoarte.Nedefinit));
            lstStruct.Add(GetStructByEnum(EnumRapoarte.ProductieTehnicieni));
            lstStruct.Add(GetStructByEnum(EnumRapoarte.Comenzi));
            lstStruct.Add(GetStructByEnum(EnumRapoarte.ClientiDatornici));
            lstStruct.Add(GetStructByEnum(EnumRapoarte.ClientiNoi));
            return lstStruct;
        }

        public static EnumRapoarte GetEnumByString(string pNume)
        {
            EnumRapoarte lId = EnumRapoarte.Nedefinit;
            foreach (StructRapoarte xStruct in GetList())
            {
                if (xStruct.Nume.Equals(pNume.Trim()))
                {
                    lId = xStruct.IdEnum;
                    break;
                }
            }

            return lId;
        }

        public static string GetStringByEnum(EnumRapoarte pId)
        {
            return GetStructByEnum(pId).Nume;
        }

        public static StructRapoarte GetStructByEnum(EnumRapoarte pId)
        {
            switch (pId)
            {
                case EnumRapoarte.ProductieTehnicieni:
                    return new StructRapoarte(EnumRapoarte.ProductieTehnicieni, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ProductieTehnicieni));
                case EnumRapoarte.Comenzi:
                    return new StructRapoarte(EnumRapoarte.Comenzi, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comenzi));
                case EnumRapoarte.ClientiDatornici:
                    return new StructRapoarte(EnumRapoarte.ClientiDatornici, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiDatornici));
                case EnumRapoarte.ClientiNoi:
                    return new StructRapoarte(EnumRapoarte.ClientiNoi, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ClientiNoi));
            }
            return Empty;
        }

        public bool Exista()
        {
            return this.IdEnum != EnumRapoarte.Nedefinit;
        }

        #endregion //Metode Publice

    }

    #endregion //EnumRapoarte + StructRapoarte
}
