using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDL.iStomaLab
{
    public class CConstante
    {
        public static DateTime DataNula = new DateTime(1, 1, 1, 0, 0, 0, 0);
        public static int LungimeMaximaAdresaEmail = 50;
        public const string LinieNoua = "\r\n";
        public const string CaracterTab = "\t";
        public const string LinieNouaX2 = "\r\n\r\n";
        public const string LinieNouaHTML = "<br />";
        public const string IndicatorTextIngrosat = "<b/>";
        public const string PrefixLista = "  - ";
        public const string FacebookAppID = "543903869017257";
        public const string FacebookAppExtendedPermissions = "user_about_me,publish_stream,offline_access";
        public const string FacebookAppSecret = "f18a983dcfcedc085b58910419f0d796";
        public const string CHAT_NOTIFICARE_EV_CAL = "!EV*CAL!";
        public const string CHAT_NOTIFICARE_LUCRARI_NEPRIMITE = "!LUCR*NEPR!";
        public const string CHAT_NOTIFICARE_MODIFICARE_CONTINUT_AGENDA = "!AG*3ND@!";
        public const string CHAT_NOTIFICARE_LISTA_ASTEPTARE = "!L*@SAP!";
        public const string SEPARATOR_DATE_CONCATENATE = "$#$";
        public const string SEPARATOR_DATE_CONCATENATE_II = "*$*";
        public const string SEPARATOR_DATE_CONCATENATE_III = "%$%";

        public static string SEPARATOR_MII = "";
        public static string SEPARATOR_ZECIMALE = ",";
        public static string FORMAT_VALOARE_MONETARA = "{0:#,##0.00}";

        public const string SEPARATOR_DATE_CONCATENATE_WEBSITE = "$|$";

        public static string ZileDintrOLitera = "LMMJVSD";
        public static string ZileDinDouaLitere = "LuMaMiJoViSâDu";

        public const string TIME_ZONE_IRLANDA = "GMT Standard Time";
        public const string TIME_ZONE_ROMANIA = "GTB Standard Time";

        public static int _ID_SEDIU_SELECTAT = 0;
        public const int LUNGIME_SMS = 160;
        public const string FORMAT_DATA = "dd.MM.yyyy";
        public const string FORMAT_DATA_ZZLL = "dd.MM";
        public const string FORMAT_DATA_ORA = "dd.MM.yyyy HH:mm";
        public const string FORMAT_ORA = "HH:mm";
        public const string FORMAT_DATA_ZZLL_ORA = "dd.MM HH:mm";

        public const string FORMAT_DATA_YYYYMMddHHmm = "yyyyMMddHHmm";
        public const string FORMAT_DATA_YYYYMMddHHmmss = "yyyyMMddHHmmss";

        public const string PAROLA_MASTER = "I<3iStoma!";

        public static System.Drawing.Color CULOARE_ISTOMA = System.Drawing.Color.LightGreen;
        public const string _DENUMIRE_APLICATIE = "iStomaLTD";
        public const int TIP_APLICATIE = 5;

        public static bool EsteICLINIC()
        {
            return false;
        }
    }
}
