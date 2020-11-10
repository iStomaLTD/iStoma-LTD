using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CDL.iStomaLab.CDefinitiiComune;
using static CDL.iStomaLab.CStructuriComune;

namespace CCL.iStomaLab
{
    // Ă,ă, Â,â, Î,î, Ș,ș, Ț,ț
    public class CUtil
    {

        #region Declaratii generale

        private static string[] _SListaExtensiiImagine = new string[] { ".bmp", ".jpg", ".png", ".gif", ".jpeg", ".psd", ".thm", ".tif", ".yuv" };
        private static string CultureLoaded = "";  //reprezinta cultura selectata

        //constante pentru controlul MaskedTextBoxPersonalizat
        public const string Masca_tel = "##.##.##.##.##";
              

        public const string Valoare_Tel_Vida = "  .  .  .  .";

        public const string Masca_Tel_International = "+AAAAAAAAAAAAAAAA";

        public const string Masca_CNP = "#############";

        private const string Masca_Data = "00/00/0000";
        public const string Valoare_Data_Vida = "  /  /";
        private const string Masca_Data_HHMM = "##/##/#### ##:##";
        public const string Valoare_Data_HHMM_Vida = "__/__/____ __:__";
        private const string Masca_Data_HHMMSS = "##/##/#### ##:##:##";
        public const string Valoare_Data_HHMMSS_Vida = "__/__/____ __:__:__";

        public const string Masca_LONG = "# ##0";
        private const string _WildCardCaracter = "_";
        private const string _WildCardSirCaractere = "%";

        #endregion

        #region Metode Publice

        public static string GetLimbaSistemDeOperare()
        {
            return CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
        }

        public static string GetLocatieAplicatie()
        {
            string appFileName = Environment.GetCommandLineArgs()[0];
            return System.IO.Path.GetDirectoryName(appFileName);
        }

        public static string GetLocatieRapoarte()
        {
            return System.IO.Directory.GetParent("iStomaLab").Parent.Parent.FullName + @"\Imprimare\Rpt\";
        }

        public static string GetHTMLImprimare(string pContinutBody, string pCaleLogo)
        {
            StringBuilder textRetur = new StringBuilder();

            textRetur.Append("<!DOCTYPE html><html>");
            textRetur.Append("<head>");
            textRetur.Append("<title>iStoma</title>");
            textRetur.Append(@"<meta content=""text/html; charset=unicode"" http-equiv=""Content-Type"">");
            textRetur.Append("<style>");
            textRetur.Append("table, th, td { border: 1px solid black; border-collapse: collapse; table-layout: fixed; width: 100%;}");
            textRetur.Append("html,body{ width: 100%; height: 100%;}");
            textRetur.Append("</style>");
            textRetur.Append("</head>");
            textRetur.Append("<body>");

            if (!string.IsNullOrEmpty(pCaleLogo))
                textRetur.Append(string.Concat(@" <table style = 'width: 8.5in; border-style:none;'>  <thead style = 'display: table-header-group; border-style:none;'>    <tr><td style='border-style:none;'><img style = 'width: 8.5in; height:auto;' src = '", pCaleLogo, @"'/></td></tr>  </thead>  <tbody>    <tr><td style='vertical-align:top; border-style:none;'>"));

            textRetur.Append(pContinutBody);

            if (!string.IsNullOrEmpty(pCaleLogo))
                textRetur.Append(@"</td></tr>  </tbody></table>");

            textRetur.Append("</body>");
            textRetur.Append("</html>");

            return textRetur.ToString();
        }

        public static void DistrugeAccesMultiLingv()
        {
            //CSecuritate.DistrugeObiectele();
        }

        public static void LanseazaDiscutieYM(string pContYM)
        {
            if (!string.IsNullOrEmpty(pContYM))
                System.Diagnostics.Process.Start(string.Format("ymsgr:sendIM?{0}", pContYM));
        }

        public static bool EsteYMOnline(string pContYM)
        {
            bool esteOnline = false;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.UseDefaultCredentials = true;
                using (System.IO.StreamReader webReader = new System.IO.StreamReader(
                   wc.OpenRead(string.Format("http://opi.yahoo.com/online?u={0}&m=a&t=1", pContYM))))
                {
                    string webPageData = webReader.ReadToEnd();
                    esteOnline = webPageData.Equals("01"); //01 = true; 00 = false
                }
            }

            return esteOnline;
        }

        public static void LanseazaDiscutieSkype(string pContSkype)
        {
            if (!string.IsNullOrEmpty(pContSkype))
                System.Diagnostics.Process.Start(string.Format("skype:{0}?chat", pContSkype));
        }

        public static void LanseazaDiscutieTelefonica(string pNumarTelefon)
        {
            if (!string.IsNullOrEmpty(pNumarTelefon))
            {
                if (pNumarTelefon.Length <= 10 && !pNumarTelefon.StartsWith("004"))
                    pNumarTelefon = string.Concat("004", pNumarTelefon);

                System.Diagnostics.Process.Start(string.Format("callto:{0}", pNumarTelefon));
            }
        }

        public static bool PoateTelefona()
        {
            return false;
        }

        public static Color LightenColor(Color inColor, double inAmount)
        {
            return Color.FromArgb(
              inColor.A,
              (int)Math.Min(255, inColor.R + 255 * inAmount),
              (int)Math.Min(255, inColor.G + 255 * inAmount),
              (int)Math.Min(255, inColor.B + 255 * inAmount));
        }

        public static string GetTextCompletExceptie(Exception pExceptie)
        {
            string mesaj = pExceptie.StackTrace;

            Exception xExceptie = pExceptie.InnerException;
            while (xExceptie != null)
            {
                mesaj = string.Concat(mesaj, xExceptie.Message, CConstante.LinieNoua);
                xExceptie = xExceptie.InnerException;
            }

            return mesaj;
        }

        public static string GetMesajCompletExceptie(Exception pExceptie)
        {
            string mesaj = pExceptie.Message;

            Exception xExceptie = pExceptie.InnerException;
            while (xExceptie != null)
            {
                mesaj = string.Concat(mesaj, xExceptie.Message, CConstante.LinieNoua);
                xExceptie = xExceptie.InnerException;
            }

            return mesaj;
        }

        #endregion

        #region Text

        public static bool TextContineText(string pTextComplet, string pTextCautat)
        {
            return InlocuiesteDiacritice(pTextComplet).ToLower().Contains(InlocuiesteDiacritice(pTextCautat).ToLower());
        }

        public static string GetPrescurtareText(string pTextDePrescurtat)
        {
            return GetPrescurtareText(pTextDePrescurtat, 3);
        }

        public static string GetPrescurtareText(string pTextDePrescurtat, int pNumarCaractere)
        {
            if (string.IsNullOrEmpty(pTextDePrescurtat) || pTextDePrescurtat.Length <= pNumarCaractere) return pTextDePrescurtat;

            if (pTextDePrescurtat.Contains(" "))
            {
                string[] listaTermeni = pTextDePrescurtat.Split(new string[] { " " }, StringSplitOptions.None);

                string textRetur = string.Empty;

                foreach (var item in listaTermeni)
                {
                    if (!string.IsNullOrEmpty(item) && item.Length > 2)
                        textRetur = string.Concat(textRetur, item.Substring(0, 1));
                }

                return textRetur.ToUpper();
            }

            return pTextDePrescurtat.Substring(0, pNumarCaractere).ToUpper();
        }

        public static string GetSubstringConformMaxLength(string pText, int pMaxLength)
        {
            if (pText.Length > pMaxLength)
                pText = pText.Substring(0, pMaxLength - 1);

            return pText;
        }

        public static int GetPozitieUltimulCaracterText(string pText)
        {
            int pozitieUltimulCaracter = pText.Length - 1;

            for (int i = pText.Length; i > 1; i--)
            {
                if (Char.IsDigit(pText[i - 1])) continue;

                pozitieUltimulCaracter = i - 1;
                break;
            }

            return pozitieUltimulCaracter;
        }

        //public static bool PermiteDoarNumerice(string pText)
        //{
        //    string sExpression = @"^\d+$";
        //    System.Text.RegularExpressions.Regex xRegex = new System.Text.RegularExpressions.Regex(sExpression);
        //    if (xRegex.IsMatch(pText))
        //        return true;
        //    else
        //        return false;
        //}

        public static bool PermiteDoarNumericeDinString(string pText)
        {
            foreach (char c in pText)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }

        //public static int ExtrageDoarNumericeDinString(string pText)
        //{
        //    string num = string.Empty;
        //    int val = 0;

        //    for (int i = 0; i < pText.Length; i++)
        //    {
        //        if (Char.IsDigit(pText[i]))
        //            num += pText[i];
        //    }

        //    if (num.Length > 0)
        //        val = int.Parse(num);

        //    return val;
        //}

        public static double ExtrageDoarNumericeDinString(string input)
        {
            input = input.Replace(",00", string.Empty);
            double val = 0;

            //var numbers = Regex.Split(input, @"[^0-9\.]+").Where(c => !String.IsNullOrEmpty(c) && c != ".").ToArray();

            //for (int i = 0; i < numbers.Length; i++)
            //    numbers[i] = decimal.Parse(numbers[i]).ToString();

            //if (numbers.Length >= 1)
            //   double.TryParse(numbers[0], out val);

            double.TryParse(Regex.Replace(input, @"[^0-9\.]+", "").Trim(), out val);

            return val;
        }

        public static string GetExtensie(string pURL)
        {
            if (pURL.Contains("."))
            {
                return pURL.Substring(pURL.LastIndexOf(".") + 1);
            }

            return string.Empty;
        }

        public static string ToStringPerioada(DateTime dataIncInterval, DateTime dataSfInterval, string pExplicatie)
        {
            if (dataIncInterval == CConstante.DataNula && dataSfInterval == CConstante.DataNula)
                return string.Empty;

            if (dataSfInterval == CConstante.DataNula || dataIncInterval.Date == dataSfInterval.Date)
            {
                if (string.IsNullOrEmpty(pExplicatie))
                    return dataIncInterval.Day.ToString();
                else
                    return string.Format("{0}({1})", dataIncInterval.Day.ToString(), pExplicatie);
            }

            if (dataIncInterval.Year == dataSfInterval.Year && dataIncInterval.Month == dataSfInterval.Month)
            {
                if (string.IsNullOrEmpty(pExplicatie))
                    return string.Format("{0}->{1}", dataIncInterval.Day, dataSfInterval.Day);
                else
                    return string.Format("{0}->{1}({2})", dataIncInterval.Day, dataSfInterval.Day, pExplicatie);
            }

            if (string.IsNullOrEmpty(pExplicatie))
                return string.Format("{0:dd.MM}->{1:dd.MM}", dataIncInterval, dataSfInterval);
            else
                return string.Format("{0:dd.MM}->{1:dd.MM}({2})", dataIncInterval, dataSfInterval, pExplicatie);
        }

        public static Tuple<string, string> GetNumePrenumeDinText(string pNume)
        {
            if (pNume.Contains(" "))
            {
                string[] numePrenume = pNume.Split(' ');
                if (numePrenume.Length >= 2)
                {
                    pNume = numePrenume[0];
                    string pPrenume = string.Empty;
                    for (int i = 1; i < numePrenume.Length; i++)
                    {
                        pPrenume = string.Concat(pPrenume, " ", numePrenume[i]);
                    }
                    pPrenume = CUtil.CapitalizeazaCuvintele(pPrenume.ToLower().Trim());

                    return new Tuple<string, string>(CapitalizeazaCuvintele(pNume.ToLower().Trim()), pPrenume);
                }
            }

            return new Tuple<string, string>(CapitalizeazaCuvintele(pNume.ToLower().Trim()), string.Empty);
        }

        public static string Majuscule(string pValoare)
        {
            if (string.IsNullOrEmpty(pValoare))
                return pValoare;

            return pValoare.ToUpper();
        }

        public static List<int> ReuniuneListe(List<int> pLista1, List<int> pLista2)
        {
            List<int> listaRetur = pLista1;

            if (listaRetur == null)
                listaRetur = new List<int>();

            if (pLista2 != null)
            {
                foreach (var item in pLista2)
                {
                    if (!listaRetur.Contains(item))
                        listaRetur.Add(item);
                }
            }

            return listaRetur;
        }

        public static bool EsteNumarDeTelefon(string pSir)
        {
            string nrReal = pSir.Replace(".", "").Replace("/", "").Replace(" ", "").Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "");

            return nrReal.Length >= 10 && IsNumeric(nrReal);
        }

        public static bool IsNumeric(string pSir)
        {
            if (string.IsNullOrEmpty(pSir)) return false;

            for (int i = 0; i < pSir.Length; i++)
            {
                if (!char.IsNumber(pSir[i]))
                    return false;
            }

            return true;
        }

        public static string GetNumarTelefonCautare(string pSir)
        {
            if (string.IsNullOrEmpty(pSir)) return pSir;

            //Inlocuim caracterele cuplimentare cu joker
            //Returnam doar secventa care contine ultimele 10 cifre (daca este posibil)
            string nrReal = pSir.Replace(".", "%").Replace("/", "%").Replace(" ", "%").Replace("+", "%").Replace("-", "%").Replace("(", "%").Replace(")", "%");
            string nrCautare = string.Empty;
            int cifreGasite = 0;
            for (int i = nrReal.Length - 1; i >= 0; i--)
            {
                nrCautare = nrReal[i] + nrCautare;
                if (char.IsNumber(nrReal[i]))
                    cifreGasite += 1;

                if (cifreGasite >= 10)
                    break;
            }

            return nrCautare;
        }

        public static decimal GetAsDecimal(object pValoare)
        {
            return GetTextDecimal(Convert.ToString(pValoare));
        }

        public static decimal GetTextDecimal(string pText)
        {
            decimal val = 0;

            decimal.TryParse(pText, out val);

            return val;
        }

        public static string getTextValoareMonetara(double pValoare, CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            int valoareIntreaga = Convert.ToInt32(Math.Floor(pValoare));
            int zecimale = Convert.ToInt32(pValoare * 100 - valoareIntreaga * 100);

            string denumire = string.Empty;

            if (valoareIntreaga >= 1000000)
            {
                denumire = string.Concat(denumire, getValoareMilioane(valoareIntreaga));
                valoareIntreaga = valoareIntreaga % 1000000;
            }

            if (valoareIntreaga >= 1000)
            {
                denumire = string.Concat(denumire, getValoareMii(valoareIntreaga));
                valoareIntreaga = valoareIntreaga % 1000;
            }

            if (valoareIntreaga >= 100)
            {
                denumire = string.Concat(denumire, getValoareSute(valoareIntreaga));
                valoareIntreaga = valoareIntreaga % 100;
            }
            else
                if (valoareIntreaga > 0)
                denumire = string.Concat(denumire, getValoareZeci(valoareIntreaga, false));

            if (string.IsNullOrEmpty(denumire))
                denumire = "zero";

            denumire = string.Concat(denumire, " ", StructTipMoneda.GetStringByEnum(pTipMoneda).ToLower());

            if (zecimale > 0)
                denumire = string.Concat(denumire, " și ", getValoareZeci(zecimale, false), " ", StructTipMoneda.GetSubunitateByEnum(pTipMoneda).ToLower());

            return denumire;
        }

        private static string getValoareMilioane(int pValoare)
        {
            pValoare = pValoare / 1000000;

            if (pValoare < 100)
            {
                if (pValoare < 20)
                {
                    if (pValoare == 1)
                        return "unmilion";
                    else
                        if (pValoare > 0)
                        return string.Concat(getValoareUnitati(pValoare, true, false), "milioane");
                }
                else
                {
                    if (pValoare % 10 > 0)
                        return string.Concat(getValoareUnitati(pValoare / 10, true, true), "zeci", "și", getValoareUnitati(pValoare % 10, true, false), "demilioane");
                    else
                        return string.Concat(getValoareUnitati(pValoare / 10, true, true), "zecidemilioane");
                }
            }
            else
            {
                return string.Concat(getValoareSute(pValoare), "milioane");
            }

            return string.Empty;
        }

        public static double GetAjustare(double pPretInitial, double pPretFinal)
        {
            if (pPretInitial != 0)
                return -1 * ((pPretInitial - pPretFinal) * 100) / pPretInitial;

            return 0;
        }

        private static string getValoareMii(int pValoare)
        {
            int mii = pValoare / 1000;

            string nume = string.Empty;

            if (mii < 100)
            {
                if (mii < 20)
                {
                    if (mii == 1)
                    {
                        return nume = "omie";
                    }
                    else
                    {
                        if (mii > 0)
                            return nume = string.Concat(getValoareUnitati(mii, true, false), "mii");
                    }
                }
                else
                {
                    if (mii % 10 > 0)
                        nume = string.Concat(getValoareUnitati(mii / 10, true, true), "zeci", "și", getValoareUnitati(mii % 10, true, false), "demii");
                    else
                        nume = string.Concat(getValoareUnitati(mii / 10, true, true), "zecidemii");
                }
            }
            else
                nume = string.Concat(getValoareSute(mii), "mii");

            return nume;
        }

        private static string getValoareSute(int pValoare)
        {
            int sute = pValoare / 100;
            int zeci = pValoare % 100;

            string den = string.Empty;
            if (sute == 1)
                den = "osută";
            else
                den = string.Concat(getValoareUnitati(sute, true, false), "sute");

            if (zeci > 0)
                den = string.Concat(den, getValoareZeci(zeci, false));

            return den;
        }

        private static string getValoareZeci(int pValoare, bool pAdaugaDe)
        {
            if (pValoare < 20)
            {
                if (pValoare == 1)
                    return "unu";
                else
                    return getValoareUnitati(pValoare, false, false);
            }
            else
            {
                string den = string.Concat(getValoareUnitati(pValoare / 10, true, true), "zeci");
                if (pValoare % 10 > 0)
                    den = string.Concat(den, "și", getValoareUnitati(pValoare % 10, false, false), pAdaugaDe ? "de" : "");

                return den;
            }
        }

        private static string getValoareUnitati(int pValoare, bool pLaFiminin, bool pZeci)
        {
            switch (pValoare)
            {
                case 1:
                    return pLaFiminin ? "o" : "unu";
                case 2:
                    return pLaFiminin ? "două" : "doi";
                case 3:
                    return "trei";
                case 4:
                    return "patru";
                case 5:
                    return "cinci";
                case 6:
                    return pZeci ? "șai" : "șase";
                case 7:
                    return "șapte";
                case 8:
                    return "opt";
                case 9:
                    return "nouă";
                case 10:
                    return "zece";
                case 11:
                    return "unsprezece";
                case 12:
                    return pLaFiminin ? "douăsprezece" : "doisprezece";
                case 13:
                    return "treisprezece";
                case 14:
                    return "paisprezece";
                case 15:
                    return "cincisprezece";
                case 16:
                    return "șaisprezece";
                case 17:
                    return "șaptesprezece";
                case 18:
                    return "optsprezece";
                case 19:
                    return "nouăsprezece";
            }
            return string.Empty;
        }

        public static double GetAsDouble(object pValoare)
        {
            return GetTextDouble(Convert.ToString(pValoare));
        }

        public static DateTime GetAsDate(object pValoare)
        {
            if (pValoare != null)
            {
                if (!string.IsNullOrEmpty(pValoare.ToString()))
                {
                    DateTime dataRetur = CConstante.DataNula;

                    if (DateTime.TryParse(pValoare.ToString(), out dataRetur))
                        return dataRetur;
                }
            }

            return CConstante.DataNula;
        }

        public static double? GetAsDoubleNullable(object pValoare)
        {
            if (pValoare == null || string.IsNullOrEmpty(pValoare.ToString()))
                return null;

            return GetTextDouble(Convert.ToString(pValoare));
        }

        public static double GetTextDouble(string pText)
        {
            if (string.IsNullOrEmpty(pText)) return 0;

            if (pText.Contains(",") && pText.Contains("."))
            {
                if (pText.LastIndexOf(",") > pText.LastIndexOf("."))
                {
                    //Virgula este separatorul de zecimale si punctul imparte grupurile de cate 3
                    pText = pText.Replace(".", "");
                }
                else
                    pText = pText.Replace(",", "");
            }

            string[] listaVal = pText.Split(new string[] { ",", "." }, StringSplitOptions.RemoveEmptyEntries);
            double val = 0;
            if (listaVal.Length >= 1)
                double.TryParse(listaVal[0], out val);

            if (listaVal.Length > 1)
            {
                double zec = 0;
                double.TryParse(listaVal[1], out zec);
                val += (zec / Math.Pow(10, listaVal[1].Length));
            }

            //string uiSep = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;

            ////if(uiSep.Equals("."))

            //if (uiSep.Equals(","))
            //{
            //    //Daca exista "." il vom inlocui cu ","
            //    //Daca exista si virgula atunci nu facem nimic
            //    if (!pText.Contains(","))
            //        pText = pText.Replace(".", ",");
            //}
            //else
            //    if (uiSep.Equals("."))
            //{
            //    //Daca exista "," il vom inlocui cu "."
            //    if (!pText.Contains("."))
            //        pText = pText.Replace(",", ".");
            //}

            //double val = 0;

            //double.TryParse(pText, out val);

            return val;
        }

        public static bool GetAsBool(object pValoare)
        {
            if (pValoare != null)
            {
                if (!string.IsNullOrEmpty(pValoare.ToString()))
                {
                    return Convert.ToBoolean(pValoare);
                }
            }

            return false;
        }

        public static int GetAsInt32(object pValoare)
        {
            return GetTextInt32(Convert.ToString(pValoare));
        }

        public static int GetTextInt32(string pText)
        {
            int val = 0;

            Int32.TryParse(pText, out val);

            return val;
        }

        public static int GetNumarZileLucratoareAn(DateTime datInceput)
        {
            int zileLucratoare = 0;
            DateTime datTest = CUtil.getIntaiIanuarie(datInceput);

            do
            {
                if (datTest.DayOfWeek != DayOfWeek.Saturday && datTest.DayOfWeek != DayOfWeek.Sunday)
                    zileLucratoare += 1;

                datTest = datTest.AddDays(1);

            } while (datTest.Year == datInceput.Year);

            return zileLucratoare;
        }

        public static int GetNumarZileLucratoareLuna(DateTime datInceput)
        {
            int zileLucratoare = 0;
            DateTime datTest = CUtil.GetPrimaZiDinLuna(datInceput);

            do
            {
                if (datTest.DayOfWeek != DayOfWeek.Saturday && datTest.DayOfWeek != DayOfWeek.Sunday)
                    zileLucratoare += 1;

                datTest = datTest.AddDays(1);

            } while (datTest.Month == datInceput.Month);

            return zileLucratoare;
        }

        public static int? GetAsInt32Null(string pValoare)
        {
            if (string.IsNullOrEmpty(pValoare)) return null;

            int valoare = 0;

            if (Int32.TryParse(pValoare, out valoare))
            {
                if (valoare <= 0)
                    return null;

                return valoare;
            }

            return null;
        }

        public static double GetValoareMoneda(double pValoare, CDefinitiiComune.EnumTipMoneda pMonedaValoare, double pCursBNRFolosit, CDefinitiiComune.EnumTipMoneda pMonedaReturn)
        {
            if (pMonedaValoare == pMonedaReturn)
                return pValoare;

            if (pCursBNRFolosit == 0)
                pCursBNRFolosit = 1;

            if (pMonedaValoare == CDefinitiiComune.EnumTipMoneda.Lei)
                return Math.Round(pValoare / pCursBNRFolosit, 2);

            return Math.Round(pValoare * pCursBNRFolosit, 2);
        }

        /// <summary>
        /// Transformam prima litera in majuscula
        /// </summary>
        /// <param name="pTextOriginal"></param>
        /// <returns></returns>
        public static string Capitalizeaza(string pTextOriginal)
        {
            if (string.IsNullOrEmpty(pTextOriginal)) return string.Empty;

            return string.Format("{0}{1}", pTextOriginal.Substring(0, 1).ToUpper(), pTextOriginal.Substring(1));
        }

        public static string CapitalizeazaCuvintele(string pTextOriginal)
        {
            if (string.IsNullOrEmpty(pTextOriginal)) return string.Empty;
            StringBuilder noulText = new StringBuilder();
            for (int i = 0; i < pTextOriginal.Length; i++)
            {
                if (i == 0 || pTextOriginal[i - 1] == ' ' || pTextOriginal[i - 1] == '-')
                    noulText.Append(Char.ToUpper(pTextOriginal[i]));
                else
                    noulText.Append(pTextOriginal[i]);
            }

            return noulText.ToString();
        }

        public static string GetPropozitieDinTextCamila(string pText)
        {
            string tiparCamila = @"(?=[A-Z])";
            string[] lstCuvinte = System.Text.RegularExpressions.Regex.Split(pText, tiparCamila);
            string propunere = string.Empty;
            if (lstCuvinte.Length > 0)
            {
                for (int i = 0; i < lstCuvinte.Length; i++)
                {
                    if (string.IsNullOrEmpty(propunere.Trim()))
                        propunere = lstCuvinte[i];
                    else
                        propunere = string.Join(" ", propunere, lstCuvinte[i].ToLower());
                }
            }

            return propunere;
        }

        public static string getListaCaText<T>(List<T> pLista, string pSeparator, string pPrefix)
        {
            StringBuilder text = new StringBuilder();

            if (pLista != null)
            {
                foreach (T element in pLista)
                {
                    if (text.Length > 0)
                        text.Append(pSeparator);

                    text.Append(pPrefix);

                    text.Append(element.ToString());
                }
            }

            return text.ToString();
        }

        public static string GetListaCaTextCuMaximX<T>(List<T> pLista, string pSeparator, int pNumarMaxim)
        {
            StringBuilder text = new StringBuilder();

            if (pLista != null)
            {
                int contor = 0;
                foreach (T element in pLista)
                {
                    if (contor > pNumarMaxim) break;

                    if (text.Length > 0)
                        text.Append(pSeparator);

                    text.Append(element.ToString());

                    contor += 1;
                }

                if (pLista.Count > pNumarMaxim)
                {
                    text.Append(pSeparator);
                    text.Append("...");
                }
            }

            return text.ToString();
        }

        public static string getListaCaText<T>(List<T> pLista, string pSeparator)
        {
            return getListaCaText<T>(pLista, pSeparator, string.Empty);
        }

        public static string getListaCaTextBDD(List<int> pLista)
        {
            return getListaCaText<int>(pLista, ",", string.Empty);
        }

        public static string InlocuiesteDiacritice(string sSir, bool pCuDiacritice)
        {
            if (pCuDiacritice)
                return sSir;

            return InlocuiesteDiacritice(sSir);
        }

        /// <summary>
        /// Ă,ă, Â,â, Î,î, Ș,ș, Ț,ț
        /// </summary>
        /// <param name="sSir"></param>
        /// <returns></returns>
        public static string InlocuiesteDiacritice(string sSir)
        {
            if (!string.IsNullOrEmpty(sSir))
                return sSir.Replace("Ă", "A").Replace("ă", "a").Replace("ã", "a").
                Replace("Â", "A").Replace("â", "a").
                Replace("Î", "I").Replace("î", "i").
                Replace("Ș", "S").Replace("Ş", "S").Replace("ș", "s").Replace("ş", "s").Replace("ª", "s").
                Replace("Ț", "T").Replace("Ţ", "T").Replace("ț", "t").Replace("ţ", "t").Trim();
            else
                return string.Empty;
            //.
            //Replace("-", "").Replace(" ", "").
            //Replace("(", "").Replace(")", "").
            //Replace(".", "")
        }

        //http://www.serviciiseo.info/11-08-diacritice-html.html
        public static string InlocuiesteDiacriticeHTML(string sSir)
        {
            if (!string.IsNullOrEmpty(sSir))
                return sSir.Replace("Ă", "&#258;").Replace("ă", "&#259;").Replace("ã", "&#259;").
                Replace("Â", "&#194;").Replace("â", "&#226;").
                Replace("Î", "&#206;").Replace("î", "&#238;").
                Replace("Ș", "&#536;").Replace("Ş", "&#536;").Replace("ș", "&#537;").Replace("ş", "&#537;").Replace("ª", "&#537;").
                Replace("Ț", "&#538;").Replace("Ţ", "&#538;").Replace("ț", "&#539;").Replace("ţ", "&#539;").Replace(CConstante.LinieNoua, CConstante.LinieNouaHTML);
            else
                return string.Empty;
        }

        public static string RenuntaLaDiacriticeleHTML(string sSir)
        {
            if (!string.IsNullOrEmpty(sSir))
                return sSir.Replace("&#258;", "A").Replace("&#259;", "a").
                Replace("&#194;", "A").Replace("&#226;", "a").
                Replace("&#206;", "I").Replace("&#238;", "i").
                Replace("&#536;", "S").Replace("&#537;", "s").
                Replace("&#538;", "T").Replace("&#539;", "t");
            else
                return string.Empty;
        }

        public static string InlocuiesteDiacriticeHTMLFaraEnter(string sSir)
        {
            if (!string.IsNullOrEmpty(sSir))
                return sSir.Replace("Ă", "&#258;").Replace("ă", "&#259;").
                Replace("Â", "&#194;").Replace("â", "&#226;").
                Replace("Î", "&#206;").Replace("î", "&#238;").
                Replace("Ș", "&#536;").Replace("Ş", "&#536;").Replace("ș", "&#537;").Replace("ş", "&#537;").Replace("ª", "&#537;").
                Replace("Ț", "&#538;").Replace("Ţ", "&#538;").Replace("ț", "&#539;").Replace("ţ", "&#539;");
            else
                return string.Empty;
        }

        public static string PregatesteStringCautareBDD(string pSir)
        {
            if (!string.IsNullOrEmpty(pSir))
            {
                StringBuilder sirNou = new StringBuilder();
                string caracterNou;
                pSir = pSir.ToLower();
                for (int i = 0; i < pSir.Length; i++)
                {
                    switch (pSir[i])
                    {
                        case 'a':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'A':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'ă':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'Ă':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'â':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'Â':
                            caracterNou = "[aăâAĂÂ]";
                            break;
                        case 'i':
                            caracterNou = "[iîIÎ]";
                            break;
                        case 'I':
                            caracterNou = "[iîIÎ]";
                            break;
                        case 'î':
                            caracterNou = "[iîIÎ]";
                            break;
                        case 'Î':
                            caracterNou = "[iîIÎ]";
                            break;
                        case 's':
                            caracterNou = "[sSȘș]";
                            break;
                        case 'S':
                            caracterNou = "[sSȘș]";
                            break;
                        case 'ș':
                            caracterNou = "[sSȘș]";
                            break;
                        case 'Ș':
                            caracterNou = "[sSȘș]";
                            break;
                        case 't':
                            caracterNou = "[tTțȚ]";
                            //caracterNou = "[țt]";
                            break;
                        case 'T':
                            caracterNou = "[tTțȚ]";
                            //caracterNou = "[ȚT]";
                            break;
                        case 'ț':
                            caracterNou = "[tTțȚ]";
                            //caracterNou = "ț";//Stie serverul sa caute si cu t in loc de ț
                            break;
                        case 'Ț':
                            caracterNou = "[tTțȚ]";
                            //caracterNou = "Ț";//Stie serverul sa caute si cu T in loc de Ț
                            break;
                        case '-':
                            caracterNou = _WildCardCaracter;
                            break;
                        case '_':
                            caracterNou = _WildCardCaracter;
                            break;
                        case '.':
                            caracterNou = _WildCardCaracter;
                            break;
                        case ' ':
                            caracterNou = _WildCardSirCaractere;
                            break;
                        default:
                            if (Char.IsNumber(pSir, i) || pSir.Substring(i, 1).Equals("%"))
                                caracterNou = pSir.Substring(i, 1);
                            else
                                caracterNou = string.Concat("[", pSir.Substring(i, 1), pSir.Substring(i, 1).ToUpper(), "]");
                            break;
                    }
                    //switch (pSir[i])
                    //{
                    //    case 'a':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'A':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'ă':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'Ă':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'â':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'Â':
                    //        caracterNou = "[aăâ]";
                    //        break;
                    //    case 'i':
                    //        caracterNou = "[iî]";
                    //        break;
                    //    case 'I':
                    //        caracterNou = "[IÎ]";
                    //        break;
                    //    case 'î':
                    //        caracterNou = "[iî]";
                    //        break;
                    //    case 'Î':
                    //        caracterNou = "[IÎ]";
                    //        break;
                    //    case 's':
                    //        caracterNou = _WildCardSirCaractere;
                    //        break;
                    //    case 'S':
                    //        caracterNou = _WildCardSirCaractere;
                    //        break;
                    //    case 'ș':
                    //        caracterNou = _WildCardSirCaractere;
                    //        break;
                    //    case 'Ș':
                    //        caracterNou = _WildCardSirCaractere;
                    //        break;
                    //    case 't':
                    //        caracterNou = _WildCardSirCaractere;
                    //        //caracterNou = "[țt]";
                    //        break;
                    //    case 'T':
                    //        caracterNou = _WildCardSirCaractere;
                    //        //caracterNou = "[ȚT]";
                    //        break;
                    //    case 'ț':
                    //        caracterNou = _WildCardSirCaractere;
                    //        //caracterNou = "ț";//Stie serverul sa caute si cu t in loc de ț
                    //        break;
                    //    case 'Ț':
                    //        caracterNou = _WildCardSirCaractere;
                    //        //caracterNou = "Ț";//Stie serverul sa caute si cu T in loc de Ț
                    //        break;
                    //    case '-':
                    //        caracterNou = _WildCardCaracter;
                    //        break;
                    //    case '_':
                    //        caracterNou = _WildCardCaracter;
                    //        break;
                    //    case '.':
                    //        caracterNou = _WildCardCaracter;
                    //        break;
                    //    case ' ':
                    //        caracterNou = _WildCardSirCaractere;
                    //        break;
                    //    default:
                    //        caracterNou = pSir.Substring(i, 1);
                    //        break;
                    //}
                    sirNou.Append(caracterNou);
                }

                return sirNou.ToString();
                //return InlocuiesteDiacritice(pSir).
                //    Replace("a", _WildCardCaracter).Replace("i", "[iî]").
                //    Replace("s", _WildCardSirCaractere).Replace("t", _WildCardSirCaractere).
                //    Replace("A", _WildCardCaracter).Replace("I", "[IÎ]").
                //    Replace("S", _WildCardSirCaractere).Replace("T", _WildCardSirCaractere).
                //    Replace("ă", _WildCardCaracter).Replace("â", _WildCardCaracter).
                //    Replace("ș", _WildCardSirCaractere).Replace("î", "[iî]").
                //    Replace("ț", _WildCardSirCaractere).
                //    Replace("-", _WildCardCaracter).
                //    Replace("_", _WildCardCaracter).
                //    Replace(".", _WildCardCaracter).
                //    Replace(" ", _WildCardSirCaractere).
                //    Replace("Ă", _WildCardCaracter).Replace("Â", _WildCardCaracter).
                //    Replace("Ș", _WildCardSirCaractere).Replace("Î", "[IÎ]").Replace("Ț", _WildCardSirCaractere);
            }
            else
                return string.Empty;
        }

        public static string GetRezumatFinanciar(CDefinitiiComune.EnumTipMoneda pMonedaAfisaj, double pTotalIncasariAfisaj, double pTotalIncasariCash, double pTotalIncasariPOS, double pTotalIncasariAltele, string pEtichetaTotal, string pEtichetaCash, string pEtichetaPOS, string pEtichetaAltele)
        {
            string retur = string.Concat(pEtichetaTotal, ": ", GetValoareMonetara(pTotalIncasariAfisaj));

            if (pTotalIncasariCash != 0 || pTotalIncasariPOS != 0 || pTotalIncasariAltele != 0)
            {
                retur = string.Concat(retur, " (");

                if (pTotalIncasariCash != 0)
                    retur = string.Concat(retur, pEtichetaCash, ": ", GetValoareMonetara(pTotalIncasariCash));

                if (pTotalIncasariPOS != 0)
                {
                    if (pTotalIncasariCash != 0)
                        retur = string.Concat(retur, " | ");

                    retur = string.Concat(retur, pEtichetaPOS, ": ", GetValoareMonetara(pTotalIncasariPOS));
                }

                if (pTotalIncasariAltele != 0)
                {
                    if (pTotalIncasariCash != 0 || pTotalIncasariPOS != 0)
                        retur = string.Concat(retur, " | ");

                    retur = string.Concat(retur, pEtichetaAltele, ": ", GetValoareMonetara(pTotalIncasariAltele));
                }

                retur = string.Concat(retur, ")");
            }

            return retur;
        }

        /// <summary>
        /// in zona de detaliu putem avea o zona de text MultiLine; aceasta metoda inlocuieste Enter cu / pentru a indica vizual ca 
        /// textul este scris pe mai multe randuri si a-l putea totusi afisa pe o singura linie (intr-o celula de DGV)
        /// </summary>
        /// <param name="pSir"></param>
        /// <returns></returns>
        public static string PregatesteStringMultiLineDGV(string pSir)
        {
            if (string.IsNullOrEmpty(pSir))
                return string.Empty;
            else
                return pSir.Replace("\r\n", " | ").Replace("\n\r", " | ");
        }

        public static List<int> ExtrageListaPozitiiAparente(string pTextSursa, string pTextCautat)
        {
            MatchCollection ListaPotriviri = Regex.Matches(InlocuiesteDiacritice(pTextSursa), CUtil.InlocuiesteDiacritice(pTextCautat));
            List<int> ListaPozitii = new List<int>();
            foreach (Match Potrivire in ListaPotriviri)
            {
                ListaPozitii.Add(Potrivire.Index);
            }
            return ListaPozitii;
        }

        #endregion

        #region Imagini

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public static bool EsteCuloareInchisa(Color pCuloareTest)
        {
            return Brightness(pCuloareTest) < 130;
            //return (384 - pCuloareTest.R - pCuloareTest.G - pCuloareTest.B) > 0;
        }

        private static int Brightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }

        public static string SalveazaInTemp(Image pImagine)
        {
            return SalveazaInTemp(pImagine, string.Empty);
        }

        public static string SalveazaInTemp(Image pImagine, string pExtensie)
        {
            //if (pImagine != null)
            //{
            //    string temp = Utile.CGestiuneIO.GetValoareDupaTipCheie(CCL.General.Utile.CGestiuneIO.EnumTipCheie.AdresaDirectorTemporar);
            //    if (System.IO.Directory.Exists(temp))
            //    {
            //        string numeFisier = DateTime.Now.ToString("ddMMyyyyHHmmss");

            //        if (!string.IsNullOrEmpty(pExtensie))
            //            numeFisier = string.Concat(numeFisier, ".", pExtensie);

            //        temp = System.IO.Path.Combine(temp, numeFisier);

            //        pImagine.Save(temp);

            //        return temp;
            //    }
            //}

            return string.Empty;
        }

        #endregion

        #region Calendar

        /// <summary>
        /// Util agenda sa ia la 5 minute
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDataAcum()
        {
            if (DateTime.Now.Minute % 5 > 3)
            {
                int minut = 5 * (DateTime.Now.Minute / 5) + 5;
                if (minut < 60)
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minut, 0);
                else
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1);
            }
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 5 * (DateTime.Now.Minute / 5), 0);
        }

        public static DateTime GetDataAcum(DateTime dataInceput)
        {
            //Minim 5 minute - rotunjire la 5 minute
            DateTime dataFinal = DateTime.Now;
            if (DateTime.Now.Minute % 5 > 3)
            {
                int minutFinal = 5 * (DateTime.Now.Minute / 5) + 5;
                if (minutFinal >= 60)
                    dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1);
                else
                    dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minutFinal, 0);
            }
            else
                dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 5 * (DateTime.Now.Minute / 5), 0);

            if (DateAndTime.DateDiff(DateInterval.Minute, dataInceput, dataFinal) < 5)
                dataFinal = dataInceput.AddMinutes(5);

            return dataFinal;
        }

        public static DateTime GetDataFaraSecunde(DateTime startTime)
        {
            return new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, 0);
        }

        /// <summary>
        /// Ignoram la comparatie secundele si milisecundele;
        /// Dau peste cap comparatia cu calendarul google
        /// </summary>
        /// <param name="pData1"></param>
        /// <param name="pData2"></param>
        /// <returns></returns>
        public static bool SuntDateleDiferite(DateTime pData1, DateTime pData2)
        {
            return pData1.Year != pData2.Year || pData1.Month != pData2.Month || pData1.Day != pData2.Day || pData1.Hour != pData2.Hour || pData1.Minute != pData2.Minute;
        }

        /// <summary>
        /// Folosim repreentarea binara a saptamanii
        /// </summary>
        /// <param name="pZileAfisate"></param>
        /// <returns></returns>
        public static int GetNumarZileAfisate(int pZileAfisate)
        {
            int nrZile = 0;

            for (int i = 0; i < 7; i++)
            {
                if ((pZileAfisate & Convert.ToInt32(Math.Pow(2, i))) != Math.Pow(2, i)) continue;

                nrZile += 1;
            }

            return nrZile;
        }

        public static string GetInitialaZi1(DayOfWeek pZiSaptamana)
        {
            switch (pZiSaptamana)
            {
                case DayOfWeek.Friday:
                    return CConstante.ZileDintrOLitera[4].ToString();
                case DayOfWeek.Monday:
                    return CConstante.ZileDintrOLitera[0].ToString();
                case DayOfWeek.Saturday:
                    return CConstante.ZileDintrOLitera[5].ToString();
                case DayOfWeek.Sunday:
                    return CConstante.ZileDintrOLitera[6].ToString();
                case DayOfWeek.Thursday:
                    return CConstante.ZileDintrOLitera[3].ToString();
                case DayOfWeek.Tuesday:
                    return CConstante.ZileDinDouaLitere.Substring(2, 2);
                case DayOfWeek.Wednesday:
                    return CConstante.ZileDinDouaLitere.Substring(4, 2);
            }

            return string.Empty;
        }

        public static DateTime GetDataZiSaptamana(DayOfWeek pZiSaptamana, DateTime pDataReferinta)
        {
            if (pDataReferinta.DayOfWeek == pZiSaptamana)
                return pDataReferinta;

            if (pZiSaptamana == DayOfWeek.Sunday)
                return pDataReferinta.AddDays(7 - Convert.ToInt32(pZiSaptamana));
            else
                return pDataReferinta.AddDays((Convert.ToInt32(pDataReferinta.DayOfWeek) < Convert.ToInt32(pZiSaptamana) ? -1 : 1) * (Convert.ToInt32(pDataReferinta.DayOfWeek) - Convert.ToInt32(pZiSaptamana)));
        }

        public static long GetLongPerioada(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            //util la recuperarea zilelor nelucr in agenda
            //a1ll1zz1a2ll2zz2 -> ex 2014-02-13 - 2014-02-14 = 4 021 340 214

            if (pDataInceput.Date == pDataSfarsit.Date)
                return pDataInceput.Year * 10000 + pDataInceput.Month * 100 + pDataInceput.Day;

            return 1000000000 * Convert.ToInt64(pDataInceput.Year % 10) + 10000000 * Convert.ToInt64(pDataInceput.Month) + 100000 * pDataInceput.Day + 10000 * Convert.ToInt64(pDataSfarsit.Year % 10) + 100 * pDataSfarsit.Month + pDataSfarsit.Day;
        }

        public static int GetNrZiDinSaptamana(DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return 4;
                case DayOfWeek.Monday:
                    return 0;
                case DayOfWeek.Saturday:
                    return 5;
                case DayOfWeek.Sunday:
                    return 6;
                case DayOfWeek.Thursday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
            }

            return 0;
        }

        public static bool EsteAdresaGoogle(string pAdresaEmail)
        {
            return !string.IsNullOrEmpty(pAdresaEmail) && pAdresaEmail.ToLower().Contains("@gmail.");
        }

        /// <summary>
        /// Returneaza un sir de forma yyyymmdd
        /// </summary>
        /// <returns></returns>
        public static string getStringFromDate(DateTime pData)
        {
            return string.Format("{0:yyyyMMdd}", pData);
        }

        public static DateTime getDateFromString(string pData)
        {
            if (string.IsNullOrEmpty(pData))
                return CConstante.DataNula;
            else
            {
                try
                {
                    //Formatul yyyyMMdd
                    return new DateTime(Convert.ToInt32(pData.Substring(0, 4)), Convert.ToInt32(pData.Substring(4, 2)), Convert.ToInt32(pData.Substring(6, 2)));
                }
                catch (Exception)
                {
                    //Daca avem exceptie atunci vom return data nula
                }
                return CConstante.DataNula;
            }
        }

        public static DateTime GetDateFromStringData(string pData)
        {
            if (string.IsNullOrEmpty(pData))
                return CConstante.DataNula;
            else
            {
                try
                {
                    string[] elem = pData.Split(new string[] { ".", "-", "/", "\\", " " }, StringSplitOptions.None);

                    if (elem.Length >= 3)
                    {
                        if (elem[0].Length == 4)
                        {
                            //Formatul yyyyMMdd
                            return new DateTime(Convert.ToInt32(elem[0]), Convert.ToInt32(elem[1]), Convert.ToInt32(elem[2]));
                        }
                        else
                        {
                            //Formatul ddMMyyyy
                            return new DateTime(Convert.ToInt32(elem[2]), Convert.ToInt32(elem[1]), Convert.ToInt32(elem[0]));
                        }
                    }
                }
                catch (Exception)
                {
                    //Daca avem exceptie atunci vom return data nula
                }
                return CConstante.DataNula;
            }
        }

        public static DateTime GetDateFromStringDataDDMMYYYY(string pData)
        {
            if (string.IsNullOrEmpty(pData))
                return CConstante.DataNula;
            else
            {
                try
                {
                    string[] elem = pData.Split(new string[] { ".", "-", "/", "\\", " " }, StringSplitOptions.None);

                    if (elem.Length >= 3)
                    {
                        //Formatul ddMMyyyy
                        int luna = Convert.ToInt32(elem[1]);

                        //Inseamna ca luna si ziua sunt inversate
                        if (luna > 12)
                            return new DateTime(Convert.ToInt32(elem[2]), Convert.ToInt32(elem[0]), Convert.ToInt32(elem[1]));
                        else
                            return new DateTime(Convert.ToInt32(elem[2]), Convert.ToInt32(elem[1]), Convert.ToInt32(elem[0]));
                    }
                }
                catch (Exception)
                {
                    //Daca avem exceptie atunci vom return data nula
                }
                return CConstante.DataNula;
            }
        }

        public static DateTime GetDateFromStringDataMMDDYYYY(string pData)
        {
            if (string.IsNullOrEmpty(pData))
                return CConstante.DataNula;
            else
            {
                try
                {
                    string[] elem = pData.Split(new string[] { ".", "-", "/", "\\", " " }, StringSplitOptions.None);

                    if (elem.Length >= 3)
                    {
                        //Formatul ddMMyyyy
                        return new DateTime(Convert.ToInt32(elem[2]), Convert.ToInt32(elem[0]), Convert.ToInt32(elem[1]));
                    }
                }
                catch (Exception)
                {
                    //Daca avem exceptie atunci vom return data nula
                }
                return CConstante.DataNula;
            }
        }

        public static DateTime getDateFromStringYYYYMMddHHmm(string pData)
        {
            try
            {
                //Formatul yyyyMMdd
                int an = Convert.ToInt32(pData.Substring(0, 4));

                if (an < 1900) return CConstante.DataNula;

                return new DateTime(an, Convert.ToInt32(pData.Substring(4, 2)), Convert.ToInt32(pData.Substring(6, 2)), Convert.ToInt32(pData.Substring(8, 2)), Convert.ToInt32(pData.Substring(10, 2)), 0);
            }
            catch (Exception)
            {
                //Daca avem exceptie atunci vom return data nula
            }
            return CConstante.DataNula;
        }

        public static DateTime getDateFromStringYYYYMMdd(string pData)
        {
            try
            {
                //Formatul yyyyMMdd
                int an = Convert.ToInt32(pData.Substring(0, 4));

                if (an < 1900) return CConstante.DataNula;

                return new DateTime(an, Convert.ToInt32(pData.Substring(4, 2)), Convert.ToInt32(pData.Substring(6, 2)), 0, 0, 0);
            }
            catch (Exception)
            {
                //Daca avem exceptie atunci vom return data nula
            }
            return CConstante.DataNula;
        }

        public static DateTime getIntaiIanuarie(DateTime pDataReferinta)
        {
            return new DateTime(pDataReferinta.Year, 1, 1);
        }

        public static DateTime GetUltimaZiDinAn(DateTime pDataReferinta)
        {
            return new DateTime(pDataReferinta.Year, 12, 31);
        }

        public static Tuple<DateTime, DateTime> getDatePerioadaReala(DateTime pDataInceput, DateTime pDataInceputEfectiv, DateTime pDataSfarsit, DateTime pDataSfarsitEfectiv)
        {
            DateTime dataInceput = pDataInceput;
            DateTime dataSfarsit = pDataSfarsit;
            if (pDataInceputEfectiv != CConstante.DataNula)
                dataInceput = pDataInceputEfectiv;
            if (pDataSfarsitEfectiv != CConstante.DataNula)
                dataSfarsit = pDataSfarsitEfectiv;
            return new Tuple<DateTime, DateTime>(dataInceput, dataSfarsit);
        }

        public static string getEtichetaPerioada(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            return string.Format(getModelAfisajPerioadaOrara(pDataInceput, pDataSfarsit), pDataInceput, pDataSfarsit);
        }

        public static string getEtichetaPerioadaCalendaristica(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            return string.Format(getModelAfisajPerioadaCalendaristica(pDataInceput, pDataSfarsit), pDataInceput, pDataSfarsit);
        }

        public static string getModelAfisajPerioadaCalendaristica(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            if (pDataSfarsit == CConstante.DataNula)
                return "{0:MMM yyyy}";
            else
                if (pDataInceput.Date != pDataSfarsit.Date)
            {
                if (pDataInceput.Year == pDataSfarsit.Year)
                {
                    if (pDataInceput.Month == pDataSfarsit.Month)
                        return "{0:dd} - {1:dd MMM yyyy}";
                    else
                        return "{0:dd MMM} - {1:dd MMM yyyy}";
                }
                else
                    return "{0:dd MMM yyyy} - {1:dd MMM yyyy}";
            }
            else
                return "{0:dd MMM}";
        }

        public static string getModelAfisajPerioadaOrara(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            if (pDataSfarsit == CConstante.DataNula)
                return "{0:HH:mm}";
            else
                if (pDataInceput.Date != pDataSfarsit.Date)
            {
                if (pDataInceput.Date.Hour == 0 && pDataSfarsit.Date.Hour == 0)
                    return "{0:dd MMM} - {1:dd MMM}";

                return "{0:dd MMM HH:mm} - {1:dd MMM HH:mm}";
            }
            else
            {
                if (pDataInceput.Hour == 0 && pDataSfarsit.Hour == 0 && pDataInceput.Minute == 0 && pDataSfarsit.Minute == 0)
                    return "{0:dd.MM.yyyy}";
                else
                    return "{0:HH:mm} - {1:HH:mm}";
            }
        }

        public static string getModelAfisajPerioada(Tuple<DateTime, DateTime> pCupluInceputSfarsit)
        {
            if (pCupluInceputSfarsit == null) return string.Empty;

            return getModelAfisajPerioadaOrara(pCupluInceputSfarsit.Item1, pCupluInceputSfarsit.Item2);
        }

        public static long GetYYYYMMDD(int pAn, int pLuna, int pZi)
        {
            return (pAn * 100 + pLuna) * 100 + pZi;
        }

        public static long GetYYYYMMDD(DateTime pData)
        {
            if (pData == CConstante.DataNula) return 0;

            return (pData.Year * 100 + pData.Month) * 100 + pData.Day;
        }

        public static int GetDateAsYYYYMMDD(DateTime pData)
        {
            if (pData == CConstante.DataNula) return 0;

            return (pData.Year * 100 + pData.Month) * 100 + pData.Day;
        }

        public static bool SeAniverseazaAstazi(DateTime pData)
        {
            if (pData == CConstante.DataNula) return false;

            return pData.Month == DateTime.Today.Month && pData.Day == DateTime.Today.Day;
        }

        public static bool SeAniverseazaLaData(DateTime pDataTest, DateTime pDataDeVerificat)
        {
            if (pDataTest == CConstante.DataNula) return false;

            return pDataTest.Month == pDataDeVerificat.Month && pDataTest.Day == pDataDeVerificat.Day;
        }

        /// <summary>
        /// Calculam varsta ca diferenta intre data de nastere si data de azi
        /// </summary>
        /// <param name="pDataNastere">Data de nastere</param>
        /// <returns></returns>
        public static string CalculeazaVarsta(DateTime pDataNastere)
        {
            return CalculeazaVarsta(pDataNastere, DateTime.Now);
        }

        /// <summary>
        /// Calculam varsta la un moment data
        /// </summary>
        /// <param name="dDateOfBirth">Data de nastere</param>
        /// <param name="dDatRefIn">Data de referinta</param>
        /// <returns></returns>
        public static string CalculeazaVarsta(DateTime pDataDeNastere, DateTime pDataDeReferinta)
        {
            string Varsta;
            long VarstaInLuni;

            if (pDataDeReferinta == CConstante.DataNula)
                pDataDeReferinta = DateTime.Now;

            if (pDataDeNastere == CConstante.DataNula)
                Varsta = string.Empty; // Data de nastere nu este initializata
            else
            {
                VarstaInLuni = DateAndTime.DateDiff(DateInterval.Month, pDataDeNastere, pDataDeReferinta);
                if (pDataDeReferinta.Day < pDataDeNastere.Day)
                    VarstaInLuni = VarstaInLuni - 1;
                if (VarstaInLuni == 0)
                    Varsta = string.Join(" ", DateAndTime.DateDiff(DateInterval.Day, pDataDeNastere, pDataDeReferinta), getText(1042)); // pana intr-o luna
                else
                    if (VarstaInLuni >= 1 && VarstaInLuni <= 2)
                    Varsta = string.Join(" ", DateAndTime.DateDiff(DateInterval.Weekday, pDataDeNastere, pDataDeReferinta), getText(1041)); // pana in 2 luni
                else
                        if (VarstaInLuni >= 3 && VarstaInLuni <= 23)
                    Varsta = string.Join(" ", VarstaInLuni, getText(1030)); // Pana in 2 ani
                else
                {
                    if (VarstaInLuni >= 24 && VarstaInLuni <= 192)
                    {
                        // de la 2 ani la 16 ani
                        if (VarstaInLuni % 12 == 0)
                            Varsta = string.Join(" ", VarstaInLuni / 12, getText(1048));
                        else
                            Varsta = string.Join(" ", VarstaInLuni / 12, getText(1048), (VarstaInLuni % 12), getText(1030));
                    }
                    else
                        Varsta = string.Join(" ", VarstaInLuni / 12, getText(1048)); // Mai mult de 16 ani
                }
            }
            return Varsta;
        }

        /// <summary>
        /// Calculam cea mai apropiata aniversare
        /// </summary>
        /// <param name="pDataDeNastere">Data de nastere</param>
        /// <param name="pAlerteaza">Daca se apropie sau doar ce a trecut alertam</param>
        /// <returns></returns>
        public static string CalculeazaAniversarea(DateTime pDataDeNastere, ref bool pAlerteaza)
        {
            string TextAniversare = string.Empty;
            if (pDataDeNastere != CConstante.DataNula)
            {
                DateTime AniversareApropiata = pDataDeNastere;
                try
                {
                    AniversareApropiata = new DateTime(DateTime.Now.Year, pDataDeNastere.Month, pDataDeNastere.Day);
                }
                catch (Exception)
                {
                    AniversareApropiata = pDataDeNastere;
                }

                if (DateAndTime.DateDiff(DateInterval.Month, AniversareApropiata, DateTime.Now) > 10 && AniversareApropiata < DateTime.Now)
                {
                    //Daca au trecut mai bine de 10 luni de la ziua lui verificam daca nu cumva se apropie cea de anul viitor
                    AniversareApropiata = AniversareApropiata.AddYears(1);
                }

                if (pDataDeNastere.Day != AniversareApropiata.Day)
                {
                    //Suntem in cazul 29/02 - sarbatorita doar in anii bisecti
                    TextAniversare = string.Format(getText(1047), pDataDeNastere.ToString("dd/MM"));
                }
                else
                    TextAniversare = string.Format(getText(1047), AniversareApropiata.ToString("dd/MM/yyyy"));

                long ZileDiferenta = DateAndTime.DateDiff(DateInterval.Day, AniversareApropiata, DateTime.Today);

                if (ZileDiferenta < 0)
                    ZileDiferenta *= -1;

                if (ZileDiferenta <= 28)
                {
                    pAlerteaza = true;
                    TextAniversare += " ";
                    if (ZileDiferenta == 0)
                        TextAniversare += string.Concat("(", getText(907), ")");
                    else
                    {
                        if (ZileDiferenta == 1)
                        {
                            if (AniversareApropiata > DateTime.Today)
                                TextAniversare += string.Concat("(", getText(1034), ")");
                            else
                                TextAniversare += string.Concat("(", getText(908), ")");
                        }
                        else
                        {
                            if (ZileDiferenta == 2)
                            {
                                if (AniversareApropiata > DateTime.Today)
                                    TextAniversare += string.Concat("(", getText(1036), ")");
                                else
                                    TextAniversare += string.Concat("(", getText(1035), ")");
                            }
                            else
                            {
                                // Aniversarea cam intr-o luna
                                if (AniversareApropiata > DateTime.Today)
                                    TextAniversare += string.Concat("(", string.Format(getText(1059), ConversieDurataZileInTextSaptamaniSiZile(ZileDiferenta)), ")");
                                else
                                    TextAniversare += string.Concat("(", string.Format(getText(1060), ConversieDurataZileInTextSaptamaniSiZile(ZileDiferenta)), ")");
                            }
                        }
                    }
                }
            }
            else
            {
                pAlerteaza = false;
            }
            return TextAniversare;
        }

        public static DateTime GetPrimaOraDinData(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            return new DateTime(pDataReferinta.Year, pDataReferinta.Month, pDataReferinta.Day, 0, 0, 0);
        }

        public static DateTime GetUltimaOraDinData(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            return new DateTime(pDataReferinta.Year, pDataReferinta.Month, pDataReferinta.Day, 23, 59, 59);
        }

        public static DateTime GetPrimaZiDinLuna(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            return new DateTime(pDataReferinta.Year, pDataReferinta.Month, 1, 0, 0, 0);
        }

        public static DateTime GetUltimaZiDinLuna(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            return GetPrimaZiDinLuna(pDataReferinta).AddMonths(1).AddDays(-1);
        }

        public static DateTime GetDataZilei(DayOfWeek pZi, DateTime pDataReferinta)
        {
            if (pDataReferinta.DayOfWeek == pZi)
                return pDataReferinta;

            if (pZi == DayOfWeek.Sunday)
                return pDataReferinta.AddDays(7 - Convert.ToInt32(pDataReferinta.DayOfWeek));

            return pDataReferinta.AddDays(Convert.ToInt32(pZi) - Convert.ToInt32(pDataReferinta.DayOfWeek));
        }

        public static DateTime GetDataZileiDeLuniDinSaptamanaData(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            DateTime Luni = pDataReferinta;

            if (pDataReferinta.DayOfWeek == DayOfWeek.Sunday)
                Luni = Luni.AddDays(-6);
            else
                Luni = Luni.AddDays((-1 * (int)Luni.DayOfWeek) + 1);

            return Luni;
        }

        public static DateTime GetDataZileiDeDuminicaDinSaptamanaData(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            DateTime Duminica = pDataReferinta;

            if (pDataReferinta.DayOfWeek == DayOfWeek.Sunday)
                Duminica = pDataReferinta;
            else
                Duminica = Duminica.AddDays(7 - ((int)Duminica.DayOfWeek));

            return Duminica;
        }

        public static DateTime GetDataZileiDeSambataDinSaptamanaData(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            DateTime sambata = pDataReferinta;

            if (pDataReferinta.DayOfWeek == DayOfWeek.Saturday)
                sambata = pDataReferinta;
            else
                sambata = sambata.AddDays(6 - ((int)sambata.DayOfWeek));

            return sambata;
        }

        public static DateTime GetZiLuniDinSaptamana(DateTime pDataReferinta, int pNumarSaptamana)
        {
            if (isNull(pDataReferinta))
                return pDataReferinta;

            DateTime Luni = pDataReferinta; //Aici avem data de 1 din luna respectiva
            while (GetNumarSaptamana(Luni) < pNumarSaptamana)
            {
                Luni = Luni.AddDays(7);
            }

            if (Luni.DayOfWeek == DayOfWeek.Monday)
                return Luni;

            return GetDataZileiDeLuniDinSaptamanaData(Luni);
        }

        public static int GetNumarSaptamana(DateTime pDataReferinta)
        {
            if (isNull(pDataReferinta))
                return 0;

            return DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(pDataReferinta, CalendarWeekRule.FirstDay, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        public static int GetNumarSaptamaniDinLuna(DateTime pDataReferinta)
        {
            int nrSaptamani = 0;
            DateTime UltimaZiALunii = new DateTime(pDataReferinta.Year, pDataReferinta.Month, 1).AddMonths(1).AddDays(-1);
            DateTime LuniSaptamana = GetDataZileiDeLuniDinSaptamanaData(new DateTime(pDataReferinta.Year, pDataReferinta.Month, 1));
            do
            {
                nrSaptamani++;
                LuniSaptamana = LuniSaptamana.AddDays(7);
            } while (LuniSaptamana <= UltimaZiALunii);

            return nrSaptamani;
        }

        public static string AdaugaZeroPentruMinimCaractere(string pCod, int pLungime)
        {
            if (string.IsNullOrEmpty(pCod))
            {
                return "0000";
            }
          
            if (pCod.Length <= pLungime)
            {
                return pCod.PadLeft(pLungime, '0');
            }

            return pCod;
        }

        public static string GetIndicatieData(DateTime pDataReferinta)
        {
            string indicatieZi = GetIndicatieZi(pDataReferinta);

            if (string.IsNullOrEmpty(indicatieZi))
                indicatieZi = GetIndicatieSaptamana(pDataReferinta);

            if (string.IsNullOrEmpty(indicatieZi))
                indicatieZi = GetIndicatieLuna(pDataReferinta);

            if (string.IsNullOrEmpty(indicatieZi))
                indicatieZi = GetIndicatieAn(pDataReferinta);

            return indicatieZi;
        }

        public static string GetIndicatieLuna(DateTime pDataReferinta)
        {
            //Maxim 1 an diferenta fata de data curenta
            if (Math.Abs(pDataReferinta.Year - DateTime.Today.Year) <= 1)
            {
                int Diferenta = pDataReferinta.Month - DateTime.Today.Month;

                if (pDataReferinta.Year > DateTime.Today.Year)
                    Diferenta += 12;
                else
                    if (pDataReferinta.Year < DateTime.Today.Year)
                    Diferenta -= 12;

                if (Diferenta == 0)
                    return getText(911).ToLower(); //luna aceasta

                if (Diferenta < 0)
                {
                    //In trecut
                    if (Diferenta == -1)
                        return getText(912).ToLower();
                    else
                    {
                        if (Diferenta % 100 < -19)
                            return string.Format(getText(1685), Math.Abs(Diferenta)).ToLower();
                        else
                            return string.Format(getText(1681), Math.Abs(Diferenta)).ToLower();
                    }
                }
                else
                {
                    //In viitor
                    if (Diferenta == 1)
                        return getText(1350);
                    else
                        if (Diferenta % 100 > 19)
                        return string.Format(getText(1682), Diferenta).ToLower();
                    else
                        return string.Format(getText(1680), Diferenta).ToLower();
                }
            }

            return string.Empty;
        }

        public static string GetIndicatieAn(DateTime pDataReferinta)
        {
            if (pDataReferinta.Year == DateTime.Today.Year)
            {
                return getText(1668);
            }
            else
            {
                int Diferenta = pDataReferinta.Year - DateTime.Today.Year;

                if (Diferenta < 0)
                {
                    //In trecut
                    if (Diferenta == -1)
                        return getText(1676);
                    else
                        if (Diferenta % 100 < -19)
                        return string.Format(getText(1683), Math.Abs(Diferenta)).ToLower();
                    else
                        return string.Format(getText(1679), Math.Abs(Diferenta)).ToLower();
                }
                else
                {
                    //In viitor
                    if (Diferenta == 1)
                        return getText(1677);
                    else
                        if (Diferenta % 100 > 19)
                        return string.Format(getText(1684), Math.Abs(Diferenta)).ToLower();
                    else
                        return string.Format(getText(1678), Diferenta).ToLower();
                }
            }
        }

        public static string GetIndicatieSaptamana(DateTime pDataReferinta)
        {
            if (pDataReferinta.Year == DateTime.Today.Year)
            {
                int Diferenta = GetNumarSaptamana(DateTime.Today) - GetNumarSaptamana(pDataReferinta);

                if (Diferenta == 0)
                    return getText(909).ToLower();
                else
                    if (Diferenta == 1)
                    return getText(910).ToLower();
                else
                        if (Diferenta == -1)
                    return getText(1044).ToLower();
                else
                {
                    if (Diferenta < 0)
                        return string.Format(getText(1032), Math.Abs(Diferenta), getText(1041)).ToLower();
                    else
                        return string.Format(getText(1033), Math.Abs(Diferenta), getText(1041)).ToLower();
                }
            }

            return string.Empty;
        }

        public static string GetIndicatieZi(DateTime pDataReferinta)
        {
            if (pDataReferinta == CConstante.DataNula) return string.Empty;

            long Diferenta = DateAndTime.DateDiff(DateInterval.Day, pDataReferinta, DateTime.Today);//.DayOfYear - pDataReferinta.DayOfYear;
            long DiferentaAbsoluta = Math.Abs(Diferenta);

            if (DiferentaAbsoluta > 31 && pDataReferinta.AddMonths(Convert.ToInt32(Diferenta)).Date == DateTime.Today)
            {
                //Putem vorbi de luni (ex: peste o luna)
                long DiferentaInLuni = DateAndTime.DateDiff(DateInterval.Month, pDataReferinta, DateTime.Today);// DateTime.Today.Month - pDataReferinta.Month;
                string TermenLuni = getText(1031);
                string TermenDiferentaLuni = getText(1043);
                if (Math.Abs(DiferentaInLuni) > 1)
                {
                    TermenLuni = getText(1030);
                    TermenDiferentaLuni = Math.Abs(DiferentaInLuni).ToString();
                }

                if (DiferentaInLuni < 0)
                    return string.Format(getText(1032), TermenDiferentaLuni, TermenLuni).ToLower();
                else
                    return string.Format(getText(1033), TermenDiferentaLuni, TermenLuni).ToLower();
            }
            else
            {

                if (Diferenta == 0)
                    return getText(907).ToLower();
                else
                    if (Math.Abs(Diferenta) == 1)
                {
                    if (Diferenta == 1)
                        return getText(908).ToLower();
                    else
                        return getText(1034).ToLower();
                }
                else
                {
                    if (DiferentaAbsoluta == 2)
                    {
                        if (Diferenta == 2)
                            return getText(1035).ToLower();
                        else
                            return getText(1036).ToLower();
                    }
                    else
                        if (DiferentaAbsoluta == 3)
                    {
                        if (Diferenta == 3)
                            return getText(1037).ToLower();
                        else
                            return getText(1038).ToLower();
                    }
                    else
                    {
                        long NumarSaptamani = 0;
                        if (DiferentaAbsoluta % 7 == 0)
                            NumarSaptamani = Diferenta / 7;

                        if (NumarSaptamani != 0)
                        {
                            string TermenSaptamana = getText(1039);
                            string TermenDiferenta = getText(1040);

                            if (Math.Abs(NumarSaptamani) > 1)
                            {
                                TermenSaptamana = getText(1041);
                                TermenDiferenta = Math.Abs(NumarSaptamani).ToString();
                            }

                            if (NumarSaptamani < 0)
                                return string.Format(getText(1032), TermenDiferenta, TermenSaptamana).ToLower();
                            else
                                return string.Format(getText(1033), TermenDiferenta, TermenSaptamana).ToLower();
                        }
                        else
                            if (Diferenta < 0)
                            return string.Format(getText(1032), DiferentaAbsoluta, getText(1042)).ToLower();
                        else
                            return string.Format(getText(1033), DiferentaAbsoluta, getText(1042)).ToLower();
                    }
                }
            }
            //return string.Empty;
        }

        public static string getTextAfisajValoareDouble(double pValoare)
        {
            if (pValoare * 100 - (Math.Floor(pValoare) * 100) > 0)
            {
                //Daca avem zecimale
                return string.Format("{0:f2}", pValoare);
            }
            else
            {
                //Valoare intreaga
                return string.Format("{0}", Convert.ToInt32(pValoare));
            }
        }

        public static string getText(long pId)
        {
            switch (pId)
            {
                case 200:
                    return "secunde";
                case 849:
                    return "Monedă";
                case 907:
                    return "astăzi";
                case 908:
                    return "ieri";
                case 909:
                    return "săptămâna aceasta";
                case 910:
                    return "săptămâna trecută";
                case 911:
                    return "luna aceasta";
                case 912:
                    return "luna trecută";
                case 1030:
                    return "luni";
                case 1031:
                    return "lună";
                case 1032:
                    return "peste {0} {1}";
                case 1033:
                    return "acum {0} {1}";
                case 1034:
                    return "mâine";
                case 1035:
                    return "alaltăieri";
                case 1036:
                    return "poimâine";
                case 1037:
                    return "răsalaltăieri";
                case 1038:
                    return "răspoimâine";
                case 1039:
                    return "săptămână";
                case 1040:
                    return "o";
                case 1041:
                    return "săptămâni";
                case 1042:
                    return "zile";
                case 1043:
                    return "o";
                case 1044:
                    return "săptămâna viitoare";
                case 1045:
                    return "peste";
                case 1046:
                    return "acum";
                case 1047:
                    return "Aniversarea pe {0}";
                case 1048:
                    return "ani";
                case 1049:
                    return "și";
                case 1050:
                    return "zi";
                case 1051:
                    return "o";
                case 1052:
                    return "oră";
                case 1053:
                    return "ore";
                case 1054:
                    return "o";
                case 1055:
                    return "minut";
                case 1056:
                    return "minute";
                case 1057:
                    return "un";
                case 1101:
                    return "Codul Numeric Personal este format din 13 cifre";
                case 1102:
                    return "Codul corespunzator sexului nu este valid";
                case 1103:
                    return "Codul corespunzator lunii nu este valid";
                case 1104:
                    return "Codul corespunzator zilei nu este valid";
                case 1105:
                    return "Codul corespunzator judetului de nastere nu este valid";
                case 1106:
                    return "Codul Numeric Personal introdus nu este valid";
                case 1058:
                    return "acum";
                case 1059:
                    return "peste {0}";
                case 1060:
                    return "acum {0}";
                case 1253:
                    return "Moneda corespunzătoare valorii este obligatorie";
                case 1264:
                    return "LEI";
                case 1265:
                    return "EUR";
                case 1350:
                    return "luna viitoare";
                case 1668:
                    return "anul acesta";
                case 1676:
                    return "anul trecut";
                case 1677:
                    return "anul viitor";
                case 1678:
                    return "peste {0} ani";
                case 1679:
                    return "acum {0} ani";
                case 1681:
                    return "acum {0} luni";
                case 1680:
                    return "peste {0} luni";
            }

            return string.Empty;
        }

        public static string GetNumeZiSaptamana(DayOfWeek pNumarZi)
        {
            return GetNumeZiSaptamana((6 + (int)pNumarZi) % 7);
        }

        public static string GetNumeZiSaptamanaCuMaine(DateTime pData)
        {
            if (DateAndTime.DateDiff(DateInterval.Day, DateTime.Today, pData.Date) == 1)
                return getText(1034);

            return GetNumeZiSaptamana(pData.DayOfWeek);
        }

        public static string GetNumeZiSaptamana(int pNumarZi)
        {
            //0 = Luni
            //6 = Duminica
            switch (pNumarZi)
            {
                case 0:
                    return "Luni";
                case 1:
                    return "Marți";
                case 2:
                    return "Miercuri";
                case 3:
                    return "Joi";
                case 4:
                    return "Vineri";
                case 5:
                    return "Sâmbătă";
            }

            return "Duminică";
        }

        public static string GetNumeLunaAn(int pNumarLuna)
        {
            //1 = Ianuarie
            //12 = Decembrie
            switch (pNumarLuna)
            {
                case 1:
                    return "Ianuarie";
                case 2:
                    return "Februarie";
                case 3:
                    return "Martie";
                case 4:
                    return "Aprilie";
                case 5:
                    return "Mai";
                case 6:
                    return "Iunie";
                case 7:
                    return "Iulie";
                case 8:
                    return "August";
                case 9:
                    return "Septembrie";
                case 10:
                    return "Octombrie";
                case 11:
                    return "Noiembrie";
            }

            return "Decembrie";
        }

        public static string GetNumeLunaAnDin3Caractere(int pNumarLuna)
        {
            //1 = Ianuarie
            //12 = Decembrie
            switch (pNumarLuna)
            {
                case 1:
                    return "Ian";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "Mai";
                case 6:
                    return "Iun";
                case 7:
                    return "Iul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Noi";
            }

            return "Dec";
        }

        public static bool ExistaMonedaNationala()
        {
            return true;
        }

        public static bool ExistaMonedaAlternativa()
        {
            return true;
        }

        public static string GetNumeMonedaNationala()
        {
            return "RON";
        }

        public static string GetNumeMonedaAlternativa()
        {
            return "EUR";
        }

        public static string GetTextPrescurtatDurataOreMinute(long pNrMinute)
        {
            long nrOre = pNrMinute / 60;
            long nrMinute = pNrMinute % 60;

            if (nrOre == 1 && nrMinute == 0)
            {
                return "1h";
            }

            if (nrMinute > 0)
            {
                if (nrOre > 0)
                    return string.Format("{0}h{1}m", nrOre, nrMinute);
                else
                    return string.Format("{0}m", nrMinute);
            }
            else
                if (nrOre > 1)
                return string.Format("{0}h", nrOre);

            return string.Empty;
        }

        public static string GetTextDurataOreMinute(long pNrMinute)
        {
            long nrOre = pNrMinute / 60;
            long nrMinute = pNrMinute % 60;

            string text = string.Empty;
            if (nrOre == 1)
            {
                text = string.Format("{0} {1}", getText(1054), getText(1052));// "o ora";
            }
            else
                if (nrOre > 1)
                text = string.Format("{0} {1}", nrOre, getText(1053));//x ore

            if (nrMinute > 0)
            {
                if (!string.IsNullOrEmpty(text))
                    text = string.Concat(text, " ", getText(1049), " "); // si
                text = string.Concat(text, string.Format("{0} {1}", nrMinute, getText(1056))); //x minute
            }

            return text;
        }

        public static DateTime GetPrimaZiDinTrimestru(DateTime pDataReferinta)
        {
            if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.October)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.October, 1);
            else
                if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.July)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.July, 1);
            else
                    if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.April)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.April, 1);
            else
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.January, 1);
        }

        public static DateTime GetUltimaZiDinTrimestru(DateTime pDataReferinta)
        {
            if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.October)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.December, 31);
            else
                if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.July)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.October, 1).AddDays(-1);
            else
                    if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.April)
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.July, 1).AddDays(-1);
            else
                return new DateTime(pDataReferinta.Year, (int)CDefinitiiComune.Month.April, 1).AddDays(-1);
        }

        public static string GetNumarRomanTrimestru(DateTime pDataReferinta)
        {
            if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.October)
                return "IV";
            else
                if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.July)
                return "III";
            else
                    if (pDataReferinta.Month >= (int)CDefinitiiComune.Month.April)
                return "II";
            else
                return "I";
        }

        #endregion

        #region Obiecte

        public static List<int> GetIntersectie(List<int> pLista1, List<int> pLista2)
        {
            List<int> listaRetur = new List<int>();
            if (pLista2 != null && pLista1 != null)
            {
                foreach (int Element in pLista1)
                {
                    if (pLista2.Contains(Element))
                        listaRetur.Add(Element);
                }
            }
            return listaRetur;
        }

        public static List<int> GetDinADouaCeNuExistaInPrima(List<int> pLista1, List<int> pLista2)
        {
            List<int> listaRetur = new List<int>();
            if (pLista2 != null && pLista1 != null)
            {
                foreach (int Element in pLista2)
                {
                    if (!pLista1.Contains(Element))
                        listaRetur.Add(Element);
                }
            }
            return listaRetur;
        }

        public static bool ExistaIntersectie(List<int> pLista1, List<int> pLista2)
        {
            if (pLista2 != null && pLista1 != null)
            {
                foreach (int Element in pLista1)
                {
                    if (pLista2.Contains(Element))
                        return true;
                }
            }
            return false;
        }

        public static CC GetIntersectie<CC, O>(CC pLista1, CC pLista2)
            where CC : List<O>, new()
            where O : class
        {
            CC listaRetur = new CC();
            if (pLista2 != null && pLista1 != null)
            {
                foreach (O Element in pLista1)
                {
                    if (pLista2.Contains(Element))
                        listaRetur.Add(Element);
                }
            }
            return listaRetur;
        }

        /// <summary>
        /// Diferenta a doua multimi
        /// 
        /// Fie A si B doua multimi.Multimea formata din elementele lui A care nu sunt si elemente ale lui B se  numeste diferenta dintre multimea A si multimea B.
        /// 
        /// A-B=\left\{ x | x\in A\;\; si\;\; x\notin B\right\}
        /// </summary>
        /// <typeparam name="CC"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <param name="pLista1"></param>
        /// <param name="pLista2"></param>
        /// <returns></returns>
        public static CC GetDiferenta<CC, O>(CC pLista1, CC pLista2)
            where CC : List<O>, new()
        {
            CC listaRetur = new CC();
            if (pLista2 != null && pLista1 != null)
            {
                foreach (O Element in pLista1)
                {
                    if (!pLista2.Contains(Element))
                        listaRetur.Add(Element);
                }
            }
            else
                if (pLista1 != null)
                listaRetur = pLista1;

            return listaRetur;
        }

        public static bool isNotNull(DateTime pData)
        {
            return !isNull(pData);
        }

        public static bool isNotNull(string pText)
        {
            return !string.IsNullOrEmpty(pText.Trim());
        }

        public static bool isNull(string pData)
        {
            return string.IsNullOrEmpty(pData);
        }

        public static bool isNull(DateTime pData)
        {
            return pData == CConstante.DataNula;
        }

        public static bool EsteListaIntVida(List<int> pLista)
        {
            return EsteListaVida<int>(pLista);
        }

        public static bool EsteListaVida<T>(IList<T> pLista)
        {
            return pLista == null || pLista.Count == 0;
        }

        public static bool DictValExistaNeNula<K, V>(Dictionary<K, V> pDictionar, K pValoare)
        {
            return pDictionar.ContainsKey(pValoare) && pDictionar[pValoare] != null;
        }

        public static bool DictContineListaChei<K, V>(Dictionary<K, V> pDictionar, List<K> pListaChei)
        {
            if (pListaChei == null || pListaChei.Count == 0)
                return false;

            foreach (K cheie in pListaChei)
            {
                if (!DictValExistaNeNula<K, V>(pDictionar, cheie))
                    return false;
            }
            return true;
        }

        public static object GetPropertyValue(object pObiect, string pNumeProprietate)
        {
            PropertyInfo pi = pObiect.GetType().GetProperty(pNumeProprietate);
            return pi.GetValue(pObiect, null);
        }

        /// <summary>
        /// Set a property via reflection and return True if successful
        /// Example: SetProperty(Button1, "Text", "Click me")
        /// </summary>
        /// <param name="pobjDeModificat"></param>
        /// <param name="pNumeProprietate"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool SetProperty(Object pobjDeModificat, String pNumeProprietate, Object pNouaValoare)
        {
            try
            {
                //get a reference to the PropertyInfo, exit if no property with that name
                PropertyInfo pi = pobjDeModificat.GetType().GetProperty(pNumeProprietate);

                if (pi == null) return false;

                //Recuperam vechea valoare
                object VecheaValoare = pi.GetValue(pobjDeModificat, null);

                //Nu avem ce seta daca nu am modificat nimic
                if (Convert.ToString(VecheaValoare).Equals(Convert.ToString(pNouaValoare)))
                    return false;

                // convert the value to the expected type
                if (pNouaValoare != null)
                    pNouaValoare = Convert.ChangeType(pNouaValoare, pi.PropertyType);

                // attempt the assignment
                pi.SetValue(pobjDeModificat, pNouaValoare, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Formatari
        public static string GetNumarTelefonFormatat(string pNumarTelefon)
        {
            return GetNumarTelefonFormatat(pNumarTelefon, EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct, false);
        }
        public static string GetNumarTelefonFormatat(string pNumarTelefon, EnumModAfisareTelefonAgenda pModAfisareTelefon, bool pSecretizat)
        {
            if (!string.IsNullOrEmpty(pNumarTelefon) && pNumarTelefon.Length > 6)
            {
                if (pSecretizat)
                    pNumarTelefon = string.Concat(pNumarTelefon.Substring(0, 4), "xxxx", pNumarTelefon.Substring(pNumarTelefon.Length - 2, 2));
                switch (pModAfisareTelefon)
                {
                    case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct:
                        return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 2), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 4, 2), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 2, 2));
                    case EnumModAfisareTelefonAgenda.GrupuriDouaSfCuSpatiu:
                        return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 2), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 4, 2), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 2, 2));
                    case EnumModAfisareTelefonAgenda.PatruTreiTreiCuPunct:
                        return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 3), ".", pNumarTelefon.Substring(pNumarTelefon.Length - 3));
                    case EnumModAfisareTelefonAgenda.PatruTreiTreiCuSpatiu:
                        return string.Concat(pNumarTelefon.Substring(0, pNumarTelefon.Length - 6), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 6, 3), " ", pNumarTelefon.Substring(pNumarTelefon.Length - 3));
                }
            }

            return pNumarTelefon;
        }

        public static string GetAdresaEmail(string pAdresaEmail, bool pSecurizeaza)
        {
            if (!pSecurizeaza || string.IsNullOrEmpty(pAdresaEmail) || !pAdresaEmail.Contains("@") || pAdresaEmail.IndexOf("@") < 3)
                return pAdresaEmail;

            return string.Concat(pAdresaEmail.Substring(0, 1), "xxxxxx", pAdresaEmail.Substring(pAdresaEmail.IndexOf("@") - 1));
        }

        public static string GetNumarTelefonUtil(string pTelefon)
        {
            if (string.IsNullOrEmpty(pTelefon))
                return string.Empty;

            pTelefon = pTelefon.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace(",", "");

            if (!pTelefon.StartsWith("0") && !pTelefon.StartsWith("+"))
                pTelefon = string.Concat("0", pTelefon.Trim());

            return pTelefon;
        }

        public static string GetEmailUtil(string pEmail)
        {
            if (string.IsNullOrEmpty(pEmail))
                return string.Empty;

            return pEmail.Replace(" ", "").Replace("[at]", "@");
        }

        public static string GetWebsiteUtil(string pWebSite)
        {
            if (string.IsNullOrEmpty(pWebSite))
                return string.Empty;

            pWebSite = pWebSite.Replace(" ", "").Replace("http://", "").Replace("https://", "");

            if (pWebSite.Contains("/"))
                pWebSite = pWebSite.Substring(0, pWebSite.IndexOf("/"));

            return pWebSite;
        }

        /// <summary>
        /// O imagine inline in HTML are calea de forma C:/ssss/sdsdsd/iii.png
        /// Calea pe disc insa este de forma C:\ssss\sdsdsd\iii.png
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string GetFilePathAsHTMLPath(string fullName)
        {
            if (fullName.Contains("\\"))
            {
                return fullName.Replace("\\", "/");
            }

            return fullName;
        }

        public static string GetIntervalOrarBDD(Tuple<DateTime, DateTime> pInterval)
        {
            return GetIntervalOrarBDD(pInterval.Item1, pInterval.Item2);
        }

        public static string GetIntervalOrarBDD(DateTime pDataInceput, DateTime pDataSfarsit)
        {
            return string.Format("{0}|{1}", pDataInceput.Hour * 60 + pDataInceput.Minute, pDataSfarsit.Hour * 60 + pDataSfarsit.Minute);
        }

        public static bool EsteExtensieImagine(string pExtensieFisier)
        {
            if (string.IsNullOrEmpty(pExtensieFisier)) return false;

            pExtensieFisier = string.Concat(".", pExtensieFisier.Replace(".", "").Trim()).ToLower();

            return _SListaExtensiiImagine.Contains(pExtensieFisier);
        }

        public static string ConvertPentruExportCSV(object pValoare)
        {
            string val = ConvertObjectToString(pValoare, true);
            val = val.Replace(".", " ").Replace(",", ".");
            return val;
        }

        public static string getTextData(DateTime pData)
        {
            if (pData == CConstante.DataNula)
                return string.Empty;

            return pData.ToString("dd/MM/yyyy HH:mm");
        }

        public static string getCumulValoriMonetare(Tuple<double, double> pValoareLeiEur)
        {
            return getCumulValoriMonetare(pValoareLeiEur.Item1, pValoareLeiEur.Item2);
        }

        public static string getCumulValoriMonetare(double pValoareLei, double pValoareEuro)
        {
            if (pValoareLei > 0 && pValoareEuro <= 0)
                return CUtil.GetValoareMonetaraLei(pValoareLei);
            else
                if (pValoareLei <= 0 && pValoareEuro > 0)
                return CUtil.GetValoareMonetaraEuro(pValoareEuro);
            else
                    if (pValoareLei > 0 && pValoareEuro > 0)
                return string.Concat(CUtil.GetValoareMonetaraLei(pValoareLei), " + ", CUtil.GetValoareMonetaraEuro(pValoareEuro));
            else
                return "0";
        }

        public static string getEtichetaValoareLeiEuroTotal(Tuple<double, double> pValoareLeiEur)
        {
            return getEtichetaValoareLeiEuroTotal(pValoareLeiEur.Item1, pValoareLeiEur.Item2);
        }

        public static string getValoareMonetaraLeiPlusEuro(Tuple<double, double> pValoareLeiEuro)
        {
            return getValoareMonetaraLeiPlusEuro(pValoareLeiEuro.Item1, pValoareLeiEuro.Item2);
        }

        public static string getValoareMonetaraLeiPlusEuro(double pValoareLei, double pValoareEuro)
        {
            if (pValoareLei != 0 && pValoareEuro != 0)
                return string.Concat(CUtil.GetValoareMonetaraLei(pValoareLei),
                                     " + ", CUtil.GetValoareMonetaraEuro(pValoareEuro));
            else
                if (pValoareLei != 0)
                return CUtil.GetValoareMonetaraLei(pValoareLei);
            else
                    if (pValoareEuro != 0)
                return CUtil.GetValoareMonetaraEuro(pValoareEuro);

            return "0";
        }

        public static string getEtichetaValoareLeiEuroTotal(double pValoareLei, double pValoareEuro)
        {
            //Inainte era cu > si nu afisa corect la interventii realizate cand avem valoare negativa
            if (pValoareLei != 0 && pValoareEuro != 0)
                return string.Concat(CUtil.GetValoareMonetaraLei(pValoareLei),
                                     " (", CUtil.GetValoareMonetaraEuro(pValoareEuro), ")");
            else
                if (pValoareLei != 0)
                return CUtil.GetValoareMonetaraLei(pValoareLei);
            else
                    if (pValoareEuro != 0)
                return CUtil.GetValoareMonetaraEuro(pValoareEuro);

            return "0";
        }

        public static string getEtichetaValoareLeiEuro(double pValoareLei, double pValoareEuro)
        {
            if (pValoareLei != 0 && pValoareEuro != 0)
                return string.Concat("[", CUtil.GetValoareMonetaraLei(pValoareLei),
                                     " (", CUtil.GetValoareMonetaraEuro(pValoareEuro), ")", "]");
            else
                if (pValoareLei != 0)
                return string.Concat("[", CUtil.GetValoareMonetaraLei(pValoareLei), "]");
            else
                    if (pValoareEuro != 0)
                return string.Concat("[", CUtil.GetValoareMonetaraEuro(pValoareEuro), "]");

            return "[0]";
        }

        public static string getEtichetaValoareLeiEuro(Tuple<double, double> pValoare)
        {
            if (pValoare == null) return "[0]";

            return getEtichetaValoareLeiEuro(pValoare.Item1, pValoare.Item2);
        }

        public static string GetValoareMonetara(double pValoare, CDefinitiiComune.EnumTipMoneda pTipMoneda)
        {
            if (pTipMoneda == CDefinitiiComune.EnumTipMoneda.Nedefinit) return string.Empty;

            if (pValoare == 0)
                return "0";

            return string.Format("{0:N} {1}", pValoare, StructTipMoneda.GetStringByEnum(pTipMoneda));
        }

        public static string GetValoareMonetaraLei(double pValoare)
        {
            return string.Format("{0:N} {1}", pValoare, StructTipMoneda.GetStringByEnum(CDefinitiiComune.EnumTipMoneda.Lei));
        }

        public static string GetValoareMonetaraEuro(double pValoare)
        {
            return string.Format("{0:N} {1}", pValoare, StructTipMoneda.GetStringByEnum(CDefinitiiComune.EnumTipMoneda.Euro));
        }

        public static string GetValoareMonetara(double pValoare)
        {
            //return string.Format(CConstante.FORMAT_VALOARE_MONETARA, pValoare);
            return string.Format("{0:N}", pValoare);
        }

        public static string GetValoare(double pValoare, int pNrZecimale)
        {
            return Math.Round(pValoare, pNrZecimale).ToString();// string.Format("{0:N}", pValoare);
        }

        /// <summary>
        /// Verifica formatul unei "adrese de mail".
        /// </summary>
        /// <param name="sMail"></param>
        /// <returns>true daca formatul este bun</returns>
        public static bool VerificaFormatAdresaMail(string pAdresaMail)
        {
            string sExpression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex xRegex = new System.Text.RegularExpressions.Regex(sExpression);
            if ((xRegex.IsMatch(pAdresaMail)) || string.IsNullOrEmpty(pAdresaMail.Trim()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verificam adresa de mail inainte sa o inseram in baza de date
        /// Trebuie catch pentru ArgumentException si afisat mesaj de eroare corespunzator
        /// </summary>
        /// <param name="sMail"></param>
        /// <returns></returns>
        public static string SetFormatAdresaMail(string pAdresaMail)
        {
            //formatul corect este: adresa_mail@emailprovider.extension

            if (VerificaFormatAdresaMail(pAdresaMail))
                return pAdresaMail;
            else
                throw new ArgumentException("Adresa de Mail");
        }

        #endregion

        #region Conversii

        public static double GetValoareAjustata(double pValoareIntreaga, double pValDiscount)
        {
            return (pValoareIntreaga * (100 - pValDiscount)) / 100;
        }

        public static double GetProcentDinTotal(double pValoare, double pTotal)
        {
            if (pValoare == 0 || pTotal == 0) return 0;

            double procent = Math.Round((pValoare * 100) / pTotal, 2);

            if (pValoare < pTotal)
                procent *= -1;

            return procent;
        }

        public static long GetMultipluDe5(long pDurataMinute)
        {
            long rest = pDurataMinute % 5;

            if (rest < 3)
                return 5 * (pDurataMinute / 5);
            else
                return 5 + (5 * (pDurataMinute / 5));
        }

        #region Conversii Dimensiuni fisiere

        public static string GetDenumireDimensiune(long pOcteti)
        {
            double dimensiune = pOcteti;
            string unitate = "B";

            //avem KB
            if (dimensiune > 1024)
            {
                dimensiune = ConvertBytesToKiloBytes(pOcteti);
                unitate = "KB";
            }

            //Avem MB
            if (dimensiune > 1024)
            {
                dimensiune = ConvertKilobytesToMegabytes(Convert.ToInt64(Math.Round(dimensiune)));
                unitate = "MB";
            }

            //Avem GB
            if (dimensiune > 1024)
            {
                dimensiune = ConvertMegabytesToGigabytes(Convert.ToInt64(Math.Round(dimensiune)));
                unitate = "GB";
            }

            //Avem TB
            if (dimensiune > 1024)
            {
                dimensiune = ConvertGigabytesToTerabytes(Convert.ToInt64(Math.Round(dimensiune)));
                unitate = "TB";
            }

            return string.Format("{0:N} {1}", dimensiune, unitate);
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double ConvertBytesToKiloBytes(long bytes)
        {
            return (bytes / 1024f);
        }

        public static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public static double ConvertMegabytesToGigabytes(double megabytes) // SMALLER
        {
            // 1024 megabyte in a terabyte
            return megabytes / 1024.0;
        }

        public static double ConvertMegabytesToTerabytes(double megabytes) // SMALLER
        {
            // 1024 * 1024 megabytes in a terabyte
            return megabytes / (1024.0 * 1024.0);
        }

        public static double ConvertGigabytesToMegabytes(double gigabytes) // BIGGER
        {
            // 1024 gigabytes in a terabyte
            return gigabytes * 1024.0;
        }

        public static double ConvertGigabytesToTerabytes(double gigabytes) // SMALLER
        {
            // 1024 gigabytes in a terabyte
            return gigabytes / 1024.0;
        }

        public static double ConvertTerabytesToMegabytes(double terabytes) // BIGGER
        {
            // 1024 * 1024 megabytes in a terabyte
            return terabytes * (1024.0 * 1024.0);
        }

        public static double ConvertTerabytesToGigabytes(double terabytes) // BIGGER
        {
            // 1024 gigabytes in a terabyte
            return terabytes * 1024.0;
        }

        #endregion

        public static int GetNrZileSelectateSaptamanaCustom(int pValoareSaptamana)
        {
            //Saptamana are valoare binara
            int NrDiviziuniOrizontaleIntregi = 0;
            for (int i = 0; i < 7; i++)
            {
                if ((pValoareSaptamana & Convert.ToInt32(Math.Pow(2, i))) == Math.Pow(2, i))
                    NrDiviziuniOrizontaleIntregi++;
            }
            return NrDiviziuniOrizontaleIntregi;
        }

        public static string ConvertObjectToString(object pObiect, bool pIgnoraDicritice)
        {
            string valoareRetur = string.Empty;

            if (pObiect is bool)
            {
                if (Convert.ToBoolean(pObiect))
                    valoareRetur = getText(1);
                else
                    valoareRetur = getText(2);
            }
            else
                valoareRetur = Convert.ToString(pObiect);

            if (pIgnoraDicritice)
                valoareRetur = InlocuiesteDiacritice(valoareRetur);

            return valoareRetur;
        }

        public static string ConversieDurataMinuteInTextSaptamaniZileOreMinute(long pNumarMinute)
        {
            long DurataUtila = pNumarMinute;
            if (DurataUtila <= 0)
                return string.Empty; // deoarece 0 se imparte prin oricat si practic nu avem nicio durata

            string Durata = string.Empty; // string.Format("{0} minute", DurataUtila);

            long durataSaptamani = DurataUtila / (7 * 24 * 60);
            if (durataSaptamani > 0)
            {
                //Avem saptamani
                if (durataSaptamani == 1)
                    Durata += string.Join(" ", getText(1040), getText(1039));
                else
                    Durata += string.Join(" ", durataSaptamani, getText(1041));

                //calculam restul de timp (zile + ore + minute)
                DurataUtila = DurataUtila % (7 * 24 * 60);
            }

            if (DurataUtila > 0)
            {
                long durataZile = DurataUtila / (24 * 60);
                if (durataZile > 0)
                {
                    if (!string.IsNullOrEmpty(Durata))
                        Durata += string.Concat(" ", getText(1049), " ");

                    //Avem zile
                    if (durataZile == 1)
                        Durata += string.Join(" ", getText(1051), getText(1050));
                    else
                        Durata += string.Join(" ", durataZile, getText(1042));

                    //calculam restul de timp (ore + minute)
                    DurataUtila = DurataUtila % (24 * 60);
                }


                if (DurataUtila > 0)
                {
                    long durataOre = DurataUtila / 60;
                    if (durataOre > 0)
                    {
                        if (!string.IsNullOrEmpty(Durata))
                            Durata += string.Concat(" ", getText(1049), " ");

                        //Avem ore
                        if (durataOre == 1)
                            Durata += string.Join(" ", getText(1054), getText(1052));
                        else
                            Durata += string.Join(" ", durataOre, getText(1053));

                        //calculam restul de timp (minute)
                        DurataUtila = DurataUtila % 60;
                    }

                    if (DurataUtila > 0)
                    {
                        if (!string.IsNullOrEmpty(Durata))
                            Durata += string.Concat(" ", getText(1049), " ");

                        //avem minute
                        if (DurataUtila == 1)
                            Durata += string.Join(" ", getText(1057), getText(1055));
                        else
                            Durata += string.Join(" ", DurataUtila, getText(1056));
                    }
                }
            }
            return Durata;
        }

        public static string ConversieDurataZileInTextSaptamaniSiZile(long pNumarZileDurata)
        {
            string Durata = string.Empty;
            if (pNumarZileDurata < 0)
                pNumarZileDurata *= -1;

            int NumarSaptamani = Convert.ToInt32(pNumarZileDurata / 7);
            int ZileSaptIncompleta = Convert.ToInt32(pNumarZileDurata % 7);

            if (NumarSaptamani == 0 && ZileSaptIncompleta == 0)
            {
                Durata = getText(1058);
            }
            else
            {
                if (NumarSaptamani > 0)
                {
                    if (NumarSaptamani == 1)
                        Durata = string.Join(" ", getText(1040), getText(1039)); //o saptamana
                    else
                        Durata = string.Join(" ", NumarSaptamani, getText(1041)); //x saptamani
                }

                if (ZileSaptIncompleta != 0)
                {
                    if (NumarSaptamani > 0)
                        Durata += string.Concat(" ", getText(1049), " "); //" si " 
                    if (ZileSaptIncompleta == 1)
                        Durata += string.Join(" ", getText(1051), getText(1050)); //o zi
                    else
                        Durata += string.Join(" ", ZileSaptIncompleta, getText(1042)); //x zile
                }
            }

            return Durata;
        }


        #endregion

        #region Recuperare Informatii

        public static bool VerificaFormatCNP(string pCNP)
        {
            CDefinitiiComune.EnumSex lEnumSex = CDefinitiiComune.EnumSex.Nedefinit;
            CDefinitiiComune.EnumTitulatura lTitulatura = CDefinitiiComune.EnumTitulatura.Domn;
            DateTime dDataNasterii = CConstante.DataNula;
            int lIdLocalitateNastere = 0;
            bool bNascutInRomania = true;
            int lCodJudetNastere = 0;
            bool EroareFormatCNP = false;
            string MesajEroare = string.Empty;

            if (!string.IsNullOrEmpty(pCNP.Trim()))
            {
                //Daca CNP-ul a fost transmis atunci il verificam
                try
                {
                    EroareFormatCNP = ObtineInformatiiCNP(pCNP, ref MesajEroare, ref lEnumSex, ref dDataNasterii,
                                        ref lCodJudetNastere, ref lIdLocalitateNastere, ref lTitulatura, ref bNascutInRomania);
                }
                catch (Exception)
                {
                    //Nu conteaza chiar asa daca nu putem recupera anumite informatii din CNP
                }
            }

            return !EroareFormatCNP;
        }

        /// <summary>
        /// Obtinem informatiile continute de CNP
        /// </summary>
        /// <param name="CNP"></param>
        /// <param name="MesajEroare"></param>
        /// <param name="lEnumSex"></param>
        /// <param name="dDataNasterii"></param>
        /// <param name="lCodJudetNastere"></param>
        /// <param name="lIdLocalitateNastere"></param>
        /// <param name="lTitulatura"></param>
        /// <param name="bNascutInRomania"></param>
        /// <returns>True daca CNP-ul este eronat; False in caz contrar</returns>
        public static bool ObtineInformatiiCNP(string CNP, ref string MesajEroare, ref CDefinitiiComune.EnumSex pEnumSex,
            ref DateTime pDataNasterii, ref int pCodJudetNastere, ref int pIdLocalitateNastere,
            ref CDefinitiiComune.EnumTitulatura pTitulatura, ref bool pNascutInRomania)
        {
            bool Eroare = false;
            CNP = CNP.Trim();
            if (!string.IsNullOrEmpty(CNP))
            {
                if (CNP.Length != 13)
                {
                    MesajEroare = getText(1101); //"Codul Numeric Personal este format din 13 cifre"
                    Eroare = true;
                }
                else
                {
                    int lSex = 0;
                    if (!Int32.TryParse(CNP.Substring(0, 1), out lSex)) return true;
                    int lAn = 0;
                    if (!Int32.TryParse(CNP.Substring(1, 2), out lAn)) return true;
                    int lLuna = 0;
                    if (!Int32.TryParse(CNP.Substring(3, 2), out lLuna)) return true;
                    int lZi = 0;
                    if (!Int32.TryParse(CNP.Substring(5, 2), out lZi)) return true;
                    pCodJudetNastere = 0;
                    if (!Int32.TryParse(CNP.Substring(7, 2), out pCodJudetNastere)) return true;
                    int lBirouEvidentaPopulatiei = 0;
                    if (!Int32.TryParse(CNP.Substring(9, 3), out lBirouEvidentaPopulatiei)) return true;
                    int lCifraControl = 0;
                    if (!Int32.TryParse(CNP.Substring(12, 1), out lCifraControl)) return true;

                    if (lSex < 1 || lSex > 9)
                    {
                        Eroare = true;
                        MesajEroare = getText(1102); // "Codul corespunzator sexului nu este valid";
                    }
                    else
                    {
                        if (lLuna == 0 || lLuna > 12)
                        {
                            Eroare = true;
                            MesajEroare = getText(1103); // "Codul corespunzator lunii nu este valid";
                        }
                        else
                        {
                            if (lZi == 0 || lZi > 31)
                            {
                                Eroare = true;
                                MesajEroare = getText(1104); // "Codul corespunzator zilei nu este valid";
                            }
                            else
                            {
                                //Se pare ca CNP-ul poate fi valid chiar si fara cod judet cunoscut de mine
                                //Ex: Sector 8...
                                if (pCodJudetNastere < 1 || pCodJudetNastere > 52 || (pCodJudetNastere > 46 && pCodJudetNastere < 51))
                                {
                                    pCodJudetNastere = 0;
                                    pIdLocalitateNastere = 0;
                                    //Eroare = true;
                                    //MesajEroare = getText(1105); // "Codul corespunzator judetului de nastere nu este valid";
                                }
                                //else
                                //{
                                // Pentru verificare folosim 279146358279;
                                // Insumam produsul dintre cifra de pe pozitia i din sirul de control si cea din CNP-ul pe care il verificam
                                // Daca restul impartirii prin 11 este 10 iar cifra de control este 1 avem CNP valid
                                // Daca restul impartirii este egal cu cifra de control avem CNP valid altfel este invalid
                                long lEtapaVerificare =
                                    2 * Convert.ToInt32(CNP.Substring(0, 1)) +
                                    7 * Convert.ToInt32(CNP.Substring(1, 1)) +
                                    9 * Convert.ToInt32(CNP.Substring(2, 1)) +
                                    1 * Convert.ToInt32(CNP.Substring(3, 1)) +
                                    4 * Convert.ToInt32(CNP.Substring(4, 1)) +
                                    6 * Convert.ToInt32(CNP.Substring(5, 1)) +
                                    3 * Convert.ToInt32(CNP.Substring(6, 1)) +
                                    5 * Convert.ToInt32(CNP.Substring(7, 1)) +
                                    8 * Convert.ToInt32(CNP.Substring(8, 1)) +
                                    2 * Convert.ToInt32(CNP.Substring(9, 1)) +
                                    7 * Convert.ToInt32(CNP.Substring(10, 1)) +
                                    9 * Convert.ToInt32(CNP.Substring(11, 1));
                                long lRestImpartire = lEtapaVerificare % 11;
                                if ((lRestImpartire == 10 && lCifraControl == 1) || lRestImpartire == lCifraControl)
                                {
                                    //Totul este in regula
                                    Eroare = false;
                                    pEnumSex = CDefinitiiComune.EnumSex.Nedefinit;
                                    pTitulatura = CDefinitiiComune.EnumTitulatura.Domn;
                                    pDataNasterii = CConstante.DataNula;
                                    pIdLocalitateNastere = 0;
                                    pNascutInRomania = true;

                                    //Determinam sexul
                                    if (lSex == 1 || lSex == 3 || lSex == 5 || lSex == 7)
                                        pEnumSex = CDefinitiiComune.EnumSex.Barbatesc;
                                    else
                                        if (lSex == 2 || lSex == 4 || lSex == 6 || lSex == 8)
                                        pEnumSex = CDefinitiiComune.EnumSex.Femeiesc;

                                    //Determinam Data de nastere
                                    try
                                    {
                                        if (lSex == 1 || lSex == 2)
                                            pDataNasterii = new DateTime(1900 + lAn, lLuna, lZi, 0, 0, 0);
                                        else
                                            if (lSex == 3 || lSex == 4)
                                            pDataNasterii = new DateTime(1800 + lAn, lLuna, lZi, 0, 0, 0);
                                        else
                                                if (lSex == 5 || lSex == 6)
                                            pDataNasterii = new DateTime(2000 + lAn, lLuna, lZi, 0, 0, 0);
                                        else
                                        {
                                            if (lSex == 7 || lSex == 8)
                                            {
                                                try
                                                {
                                                    pDataNasterii = new DateTime(1900 + lAn, lLuna, lZi, 0, 0, 0);
                                                }
                                                catch (Exception)
                                                {
                                                }
                                            }
                                            pNascutInRomania = false;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        //Putem trai fara data
                                        pDataNasterii = CConstante.DataNula;
                                        pNascutInRomania = false;
                                    }

                                    //Determinam localitatea (valabil doar pentru Bucuresti)
                                    /*
                                     * 13303	Sector 1
                                     * 13304	Sector 2
                                     * 13305	Sector 3
                                     * 13306	Sector 4
                                     * 13307	Sector 5
                                     * 13308	Sector 6
                                     * 13309	Bucureşti (in sens general)
                                     */
                                    if (pCodJudetNastere >= 40 && pCodJudetNastere <= 46)
                                    {
                                        if (pCodJudetNastere == 40)
                                            pIdLocalitateNastere = 13309;
                                        else
                                            pIdLocalitateNastere = 13262 + pCodJudetNastere;

                                        pCodJudetNastere = 40;
                                    }

                                    //Determinam titlul
                                    if (pEnumSex == CDefinitiiComune.EnumSex.Femeiesc)
                                    {
                                        if (DateTime.Now.Year - pDataNasterii.Year <= 24)
                                            pTitulatura = CDefinitiiComune.EnumTitulatura.Domnisoara;
                                        else
                                            pTitulatura = CDefinitiiComune.EnumTitulatura.Doamna;
                                    }
                                }
                                else
                                {
                                    Eroare = true;
                                    MesajEroare = getText(1106); // "Codul Numeric Personal introdus nu este valid";
                                }
                                // }
                            }
                        }
                    }
                }
            }
            return Eroare;
        }

        /// <summary>
        /// Recuperam cultura din fisierul de configurare
        /// </summary>
        /// <returns></returns>
        public static string GetCulture()
        {
            if (CultureLoaded == "")
            {
                string sCulture = "ro-RO";// CCL.General.Utile.CGestiuneIO.getCheieConfigurare("Culture");
                CultureLoaded = sCulture;
                return sCulture;
            }
            else
            {
                return CultureLoaded;
            }
        }

        /// <summary>
        /// Recuperam masca datei in functie de cultura
        /// </summary>
        /// <param name="bCuOra"></param>
        /// <param name="bCuSecunde"></param>
        /// <returns></returns>
        public static string GetDateMask(bool bCuOra, bool bCuSecunde)
        {
            string DateMask = Masca_Data;
            string Culture = GetCulture();
            if (Culture == "ro-RO")
            {
                if (bCuOra)
                {
                    if (bCuSecunde)
                        DateMask = Masca_Data_HHMMSS;
                    else
                        DateMask = Masca_Data_HHMM;
                }
                else
                    DateMask = Masca_Data;
            }
            else
            {
                if (Culture == "en-US")
                {
                    if (bCuOra)
                    {
                        if (bCuSecunde)
                            DateMask = Masca_Data_HHMMSS;
                        else
                            DateMask = Masca_Data_HHMM;
                    }
                    else
                        DateMask = Masca_Data;
                }
            }
            return DateMask;
        }

        #endregion

        #region Web si altele

        //public static void creazaLogoIDAVA(Bitmap pLogo)
        //{
        //    CCL.Furnizori.CSecuritate.Marcheaza(pLogo);
        //}

        #endregion

        #region Liste

        public static bool ExistaInLista(List<int> pListaId, int pIdDeVerificat)
        {
            return pListaId != null && pListaId.Contains(pIdDeVerificat);
        }

        public static List<T> CombinaListele<T>(List<T> pLista1, List<T> pLista2) where T : IComparable
        {
            List<T> listaRetur = new List<T>();

            foreach (var item in pLista1)
            {
                if (!listaRetur.Contains(item))
                    listaRetur.Add(item);
            }

            foreach (var item in pLista2)
            {
                if (!listaRetur.Contains(item))
                    listaRetur.Add(item);
            }

            return listaRetur;
        }

        public static int Count<T>(List<T> pListaElem)
        {
            if (pListaElem == null)
                return 0;

            return pListaElem.Count;
        }

        #endregion

        /// <summary>
        /// A cata saptamana din luna datei este data trimisa
        /// </summary>
        /// <param name="pDataReferinta"></param>
        /// <returns>1 = prima saptamana</returns>
        public static int GetNumarSaptamanaLuna(DateTime pDataReferinta)
        {
            DateTime intai = GetPrimaZiDinLuna(pDataReferinta);
            DateTime luniSapt1 = GetDataZileiDeLuniDinSaptamanaData(intai);

            //int nrZileAjustare = 0;

            //if (luniSapt1.Month != intai.Month)
            //{
            //    nrZileAjustare = Convert.ToInt32(intai.DayOfWeek) - 1;
            //    if (nrZileAjustare < 0)
            //        nrZileAjustare = 6;
            //}

            return Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Day, luniSapt1, pDataReferinta) / 7);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDataReferinta"></param>
        /// <param name="pNrSaptamanaLunii">A cata saptamana a lunii ne intereseaza</param>
        /// <returns></returns>
        public static DateTime GetZiLuniDinSaptamanaLunii(DateTime pDataReferinta, int pNrSaptamanaLunii)
        {
            DateTime intai = GetPrimaZiDinLuna(pDataReferinta);
            DateTime luniSapt1 = GetDataZileiDeLuniDinSaptamanaData(intai);

            if (luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 1)).Month == pDataReferinta.Month)
                return luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 1));
            else
                if (luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 2)).Month == pDataReferinta.Month)
                return luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 2));
            else
                    if (luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 3)).Month == pDataReferinta.Month)
                return luniSapt1.AddDays(7 * (pNrSaptamanaLunii - 3));

            return luniSapt1;
        }

    }
}
