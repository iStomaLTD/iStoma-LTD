using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Configuration;

namespace ActualizareAplicatie
{
    public static class CUtile
    {
        private const string _SOFT_REG = @"SOFTWARE\iStomaLTD";
        internal const int _ID_LIMBA_ROMANA = 1;

        internal static int GetLimba()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            try
            {
                if (cheie.GetValue("LIMBA") != null)
                    return Convert.ToInt32(cheie.GetValue("LIMBA"));
            }
            catch (Exception)
            {
            }

            return -1;
        }

        public static int GetTipAplicatieDinRegistri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToInt32(cheie.GetValue("TAPLIDAVA"));
        }

        internal static bool EsteInLimbaRomana()
        {
            return GetLimba() == _ID_LIMBA_ROMANA;
        }

        internal static void updateMultiLingv(byte[] pContinutFisier)
        {
            //Doar daca sunt necesare modificarile
            executaComandaSQL("DELETE FROM MultiLingv_TD");
            executaFisierSQL(DeCompreseazaText(pContinutFisier), "-$$$-");
        }

        public static bool EsteMultiSesiune()
        {
            bool rez = false;

            string ok = getCheieConfigurare("MS");
            if (!string.IsNullOrEmpty(ok) && bool.TryParse(ok, out rez))
                return rez;

            return false;
        }

        public static string getCheieConfigurare(string sCheie)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(sCheie);
        }

        internal static string getUltimaVersiuneBDD()
        {
            string versiune = string.Empty;

            using (SqlConnection connection = new SqlConnection(getConexiuneBDD()))
            {
                connection.Open();
                SqlCommand comandaSQL = connection.CreateCommand();
                comandaSQL.CommandText = "SELECT TOP 1 tVersiune FROM VersiuniBDD_TD ORDER BY dDataCreare DESC";
                SqlDataReader reader = comandaSQL.ExecuteReader();
                while (reader.Read())
                {
                    versiune = Convert.ToString(reader["tVersiune"]);
                }
                connection.Close();
            }

            return versiune;
        }

        internal static void UpdateVersiuneBDD(string pVersiune)
        {
            executaComandaSQL(string.Format("INSERT INTO VersiuniBDD_TD(tVersiune) VALUES ('{0}')", pVersiune));
        }

        internal static void executaFisierSQL(string pContinutFisier, string pSeparatorComenzi)
        {
            using (SqlConnection connection = new SqlConnection(getConexiuneBDD()))
            {
                connection.Open();

                string[] listaComenzi = pContinutFisier.Split(new string[] { pSeparatorComenzi }, StringSplitOptions.None);

                foreach (string comanda in listaComenzi)
                {
                    if (!string.IsNullOrEmpty(comanda.Trim()))
                    {
                        SqlCommand comandaSQL = connection.CreateCommand();
                        comandaSQL.CommandText = comanda.Trim();
                        comandaSQL.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        internal static void executaComandaSQL(string pComanda)
        {
            using (SqlConnection connection = new SqlConnection(getConexiuneBDD()))
            {
                connection.Open();
                SqlCommand comandaSQL = connection.CreateCommand();
                comandaSQL.CommandText = pComanda;
                comandaSQL.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static string DeCompreseazaText(byte[] pTextDeDecompresat)
        {
            if (pTextDeDecompresat == null || pTextDeDecompresat.Length == 0) return string.Empty;

            string rezultat = string.Empty;

            using (MemoryStream memIn = new MemoryStream(pTextDeDecompresat))
            {
                using (DeflateStream deflate = new DeflateStream(memIn, CompressionMode.Decompress))
                {
                    using (MemoryStream memOut = new MemoryStream(1))
                    {
                        int octet = deflate.ReadByte();
                        while (octet != -1)
                        {
                            memOut.WriteByte(Convert.ToByte(octet));
                            octet = deflate.ReadByte();
                        }

                        if (memOut.Length > 0)
                            rezultat = System.Text.Encoding.UTF32.GetString(memOut.ToArray());
                    }
                }
            }
            return rezultat;
        }

        internal static string GetLocatieAplicatie()
        {
            string appFileName = Environment.GetCommandLineArgs()[0];
            return System.IO.Path.GetDirectoryName(appFileName);
        }

        internal static void StergeContinutFolder(string pNumeFolder)
        {
            string[] listaFisiere = System.IO.Directory.GetFiles(pNumeFolder);
            foreach (string fisier in listaFisiere)
            {
                System.IO.File.Delete(fisier);
            }
            string[] listaDirectoare = Directory.GetDirectories(pNumeFolder);
            foreach (string director in listaDirectoare)
            {
                StergeContinutFolder(director);
            }
            Directory.Delete(pNumeFolder);
        }

        internal static Tuple<string, string> GetUtilizatorISTOMA()
        {
            string user = string.Empty;
            string parola = string.Empty;

            using (SqlConnection connection = new SqlConnection(getConexiuneBDD()))
            {
                connection.Open();
                SqlCommand comandaSQL = connection.CreateCommand();
                comandaSQL.CommandText = "SELECT tContStoma,tParolaStoma FROM Utilizator_TD WHERE xnUtilizatorCreare IS NULL";
                SqlDataReader reader = comandaSQL.ExecuteReader();
                while (reader.Read())
                {
                    user = Convert.ToString(reader["tContStoma"]);
                    parola = Convert.ToString(reader["tParolaStoma"]);
                }
                connection.Close();
            }

            return new Tuple<string, string>(user, parola);
        }

        private static string _SConexiuneValida = string.Empty;
        private static string getConexiuneBDD()
        {
            if (!string.IsNullOrEmpty(_SConexiuneValida))
                return _SConexiuneValida;

            string conexiune = System.Configuration.ConfigurationManager.AppSettings.Get("SQLConnection");

            if (conexiune.Equals("SECURE"))
            {
                conexiune = Secure.getSecure1();
            }

            return conexiune;
        }

        private static string getConexiuneBDDAlternativa()
        {
            string conexiune = System.Configuration.ConfigurationManager.AppSettings.Get("SQLConnectionAlternativ");

            if (conexiune.Equals("SECURE"))
            {
                conexiune = Secure.getSecure2();
            }

            return conexiune;
        }

        internal static string getCheieLicenta()
        {
            RegistryKey cheie = Registry.CurrentUser.OpenSubKey(@_SOFT_REG);
            if (cheie != null)
                return Convert.ToString(cheie.GetValue("LICENTA"));

            return string.Empty;
        }

        public static void PornesteProces(string pNumeFisier)
        {
            System.Diagnostics.Process.Start(pNumeFisier);
        }

        //Creating the extern function...
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Creating a function that uses the API function...
        public static bool ExistaConexiuneInternet()
        {
            try
            {
                int Desc;
                return InternetGetConnectedState(out Desc, 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool existaConexiuneBDD()
        {
            bool cheie = existaCheieConfigurare("SQLConnection");

            if (cheie)
            {
                return ConexiuneBDDValida(getConexiuneBDD());
            }

            return cheie;
        }

        public static bool existaCheieConfigurare(string pCheie)
        {
            return !string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get(pCheie));
        }

        public static void seteazaConexiuneBDD(string pConexiune)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("SQLConnection"))
            {
                configuration.AppSettings.Settings["SQLConnection"].Value = pConexiune;
            }
            else
            {
                configuration.AppSettings.Settings.Add("SQLConnection", pConexiune);
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void seteazaConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola, string pNumeBDD)
        {
            seteazaConexiuneBDD(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pNumeBDD));
        }

        private static string getNumeConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola, string pNumeBDD)
        {
            if (!string.IsNullOrEmpty(pInstanta))
                pServer += @"\" + pInstanta;

            return string.Format("Data Source={0};Initial Catalog={1};uid={2};password={3};", pServer, pNumeBDD, pUser, pParola);
        }

        private static string getNumeConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola)
        {
            if (!string.IsNullOrEmpty(pInstanta))
                pServer += @"\" + pInstanta;

            return string.Format("Data Source={0};uid={1};password={2};", pServer, pUser, pParola);
        }

        public static bool ConexiuneBDDValida(string pServer, string pInstanta, string pUser, string pParola)
        {
            return ConexiuneBDDValida(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola));
        }

        public static bool ConexiuneBDDValida(string pConexiune)
        {
            try
            {
                string conexiune = pConexiune;

                string provider = "System.Data.SqlClient"; // for example
                System.Data.Common.DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory(provider);
                using (System.Data.Common.DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = pConexiune;
                    conn.Open();
                }

                _SConexiuneValida = conexiune;

                return true;
            }
            catch (Exception)
            {
                try
                {
                    string conexiuneAlternativa = getConexiuneBDDAlternativa();
                    string provider = "System.Data.SqlClient"; // for example
                    System.Data.Common.DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory(provider);
                    using (System.Data.Common.DbConnection conn = factory.CreateConnection())
                    {
                        conn.ConnectionString = conexiuneAlternativa;
                        conn.Open();
                    }
                    _SConexiuneValida = conexiuneAlternativa;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
