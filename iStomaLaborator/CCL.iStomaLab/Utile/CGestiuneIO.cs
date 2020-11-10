using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO.Compression;
using System.IO;
using System.Drawing;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace CCL.iStomaLab.Utile
{
    public static class CGestiuneIO
    {
        #region Declaratii Generale

        private static string[] _SListaExtensiiImagine = new string[] { ".bmp", ".jpg", ".png", ".gif", ".jpeg", ".psd", ".thm", ".tif", ".yuv" };
        private static string lAdresaSalvareDocumente = string.Empty;
        private static string lAdresaDirectorTemporar = string.Empty;

        #endregion

        #region Enumerari + Structuri

        public enum EnumTipCheie
        {
            Nedefinit = 0,
            AdresaSalvareDocumente = 1,
            AdresaDirectorTemporar = 2,
            AdresaBackupBDD = 3,
            CursBNR = 4,
            CaleRadiografiiPrimite = 5,
            IdCalc = 6,
            MarimeDosarPacient = 7,
            MarimeEcranDeFacut = 8,
            MarimeEcranCalculVenit = 9,
            MarimeEcranCalculVenitIncasari = 10,
            /// <summary>
            /// Ultimul utilizator conectat
            /// </summary>
            UUC = 11,
            BCPRINTER = 12,
        }

        #endregion

        #region Metode publice

        /// <summary>
        /// http://checkip.dyndns.org/
        /// http://stackoverflow.com/questions/1069103/how-to-get-my-own-ip-address-in-c
        /// </summary>
        /// <returns></returns>
        public static string GetPublicIP()
        {
            String direction = "";
            System.Net.WebRequest request = System.Net.WebRequest.Create("http://checkip.dyndns.org/");
            using (System.Net.WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }
            }

            //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            return direction;
        }

        public static string getComputerName()
        {
            return System.Environment.MachineName;
        }

        public static string getComputerID()
        {
            return GetValoareDupaTipCheie(EnumTipCheie.IdCalc);
        }

        public static string getInternalIPByComputerName(string pComputerName)
        {
            System.Net.IPAddress[] listaIP = System.Net.Dns.GetHostAddresses(pComputerName);

            if (listaIP != null)
            {
                foreach (var item in listaIP)
                {
                    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        return item.ToString();
                }
            }

            return string.Empty;
        }

        public static string GetInternalIP()
        {
            System.Net.IPHostEntry host;
            string localIP = "?";
            host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static void executaFisierSQL(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity, string pNumeBDD, string pContinutFisier, string pSeparatorComenzi)
        {
            using (SqlConnection connection = new SqlConnection(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pNumeBDD, pIntegratedSecurity)))
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

        public static void executaFisierSQL(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity, string pNumeBDD, string pContinutFisier)
        {
            if (!string.IsNullOrEmpty(pContinutFisier))
            {
                using (SqlConnection connection = new SqlConnection(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pNumeBDD, pIntegratedSecurity)))
                {
                    connection.Open();
                    SqlCommand comandaSQL = connection.CreateCommand();
                    comandaSQL.CommandText = pContinutFisier;
                    comandaSQL.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static bool creazaBDD(string pServer, string pInstanta, string pUser, string pParola, string pNumeBDD, bool pIntegratedSecurity)
        {
            using (SqlConnection connection = new SqlConnection(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pIntegratedSecurity)))
            {
                connection.Open();
                SqlCommand comandaSQL = connection.CreateCommand();
                comandaSQL.CommandText = string.Format("CREATE DATABASE {0}", pNumeBDD);
                comandaSQL.ExecuteNonQuery();
                connection.Close();
            }

            return true;
        }

        public static List<string> getListaBDD(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity)
        {
            List<string> listaBDD = new List<string>();
            using (SqlConnection connection = new SqlConnection(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pIntegratedSecurity)))
            {
                connection.Open();
                DataTable info = connection.GetSchema("Databases");
                foreach (DataRow dr in info.Rows)
                {
                    listaBDD.Add(dr["database_name"].ToString());
                }
                connection.Close();
            }

            return listaBDD;
        }

        private static string getNumeConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity)
        {
            if (!string.IsNullOrEmpty(pInstanta))
                pServer += @"\" + pInstanta;

            if (pIntegratedSecurity)
                return string.Format("Data Source={0};integrated security=true;", pServer, pUser, pParola);
            else
                return string.Format("Data Source={0};uid={1};password={2};", pServer, pUser, pParola);
        }

        private static string getNumeConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola, string pNumeBDD, bool pIntegratedSecurity)
        {
            if (!string.IsNullOrEmpty(pInstanta))
                pServer += @"\" + pInstanta;

            if (pIntegratedSecurity)
                return string.Format("Data Source={0};Initial Catalog={1};integrated security=true;", pServer, pNumeBDD, pUser, pParola);
            else
                return string.Format("Data Source={0};Initial Catalog={1};uid={2};password={3};", pServer, pNumeBDD, pUser, pParola);
        }

        public static bool ConexiuneBDDValida(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity)
        {
            return ConexiuneBDDValida(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pIntegratedSecurity));
        }

        public static bool ConexiuneBDDValida(string pConexiune)
        {
            try
            {
                string provider = "System.Data.SqlClient"; // for example
                DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = pConexiune;
                    conn.Open();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsNetworkLikelyAvailable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        //Creating the extern function...
        //[DllImport("wininet.dll")]
        //private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Creating a function that uses the API function...
        public static bool ExistaConexiuneInternet()
        {
            try
            {
                return IsNetworkLikelyAvailable();
                //int Desc;
                //return InternetGetConnectedState(out Desc, 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool EstePoza(FileInfo pDocument)
        {
            return EstePoza(pDocument.FullName);
        }

        public static bool EstePoza(string pCaleDocument)
        {
            Image poza = null;
            try
            {
                FileInfo fisier = new FileInfo(pCaleDocument);
                if (CUtil.ConvertBytesToMegabytes(fisier.Length) < 20 && (string.IsNullOrEmpty(fisier.Extension) || _SListaExtensiiImagine.Contains(fisier.Extension.ToLower())))
                {
                    return true;
                }
                else
                {
                    poza = Image.FromFile(pCaleDocument);
                }
            }
            catch (Exception)
            {
            }

            if (poza != null)
            {
                poza.Dispose();
                poza = null;

                return true;
            }

            return false;
        }

        public static FileInfo GetUltimaCopieDeRezerva()
        {
            FileInfo ultimulBackup = null;

            if (Directory.Exists(CGestiuneIO.GetValoareDupaTipCheie(CGestiuneIO.EnumTipCheie.AdresaBackupBDD)))
            {
                string[] fisiereBackup = Directory.GetFiles(CGestiuneIO.GetValoareDupaTipCheie(CGestiuneIO.EnumTipCheie.AdresaBackupBDD));

                FileInfo infoFisier = null;
                foreach (string fisier in fisiereBackup)
                {
                    infoFisier = new FileInfo(fisier);

                    if (ultimulBackup == null || infoFisier.CreationTime > ultimulBackup.CreationTime)
                    {
                        ultimulBackup = infoFisier;
                    }
                }
            }

            return ultimulBackup;
        }

        public static void VerificaDirectoarele()
        {
            string salvare = GetValoareDupaTipCheie(EnumTipCheie.AdresaSalvareDocumente);
            string temp = GetValoareDupaTipCheie(EnumTipCheie.AdresaDirectorTemporar);
            string backup = GetValoareDupaTipCheie(EnumTipCheie.AdresaBackupBDD);

            if (!Directory.Exists(salvare))
                Directory.CreateDirectory(salvare);

            //Nu verificam acest director deoarece nu apartine neaparat masinii de pe care rulam aplicatia ci masinii pe care este instalat serverul SQL
            //if (!Directory.Exists(backup))
            //    Directory.CreateDirectory(backup);

            GolesteDirectorTemporar();
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);
        }

        public static void GolesteDirectorTemporar()
        {
            string temp = GetValoareDupaTipCheie(EnumTipCheie.AdresaDirectorTemporar);
            if (Directory.Exists(temp))
            {
                string[] fisiereTemporare = Directory.GetFiles(temp);
                FileInfo infoFisier = null;
                foreach (string fisier in fisiereTemporare)
                {
                    try
                    {
                        infoFisier = new FileInfo(fisier);
                        infoFisier.Attributes = FileAttributes.Normal;
                        infoFisier.Delete();
                        infoFisier = null;
                    }
                    catch (Exception)
                    {
                        //Nu este nicio problema daca nu merge acum; va merge data viitoare
                    }
                }
            }
        }

        public static void seteazaAtributeAscundereFisier(string pCaleFisier, DateTime pDataCreare)
        {
            FileInfo FisieNouCreat = new FileInfo(pCaleFisier);
            FisieNouCreat.CreationTime = pDataCreare;
            FisieNouCreat.Attributes |= FileAttributes.ReadOnly;
            FisieNouCreat.Attributes |= FileAttributes.Hidden;
            FisieNouCreat.Attributes |= FileAttributes.System;
            FisieNouCreat.Attributes |= FileAttributes.Offline;
        }

        public static byte[] CompreseazaTextHTML(string pTextDeCompresat)
        {
            return CompreseazaText(CUtil.InlocuiesteDiacriticeHTML(pTextDeCompresat));
        }

        public static byte[] CompreseazaText(string pTextDeCompresat)
        {
            if (string.IsNullOrEmpty(pTextDeCompresat)) return null;

            byte[] rezultat = null;

            using (MemoryStream memOut = new MemoryStream(1))
            {
                using (DeflateStream deflate = new DeflateStream(memOut, CompressionMode.Compress))
                {
                    byte[] data = Encoding.UTF32.GetBytes(pTextDeCompresat);
                    deflate.Write(data, 0, data.Length);
                    deflate.Close();
                }

                rezultat = memOut.ToArray();
            }
            return rezultat;
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

        /// <summary>
        /// Recuperam valoarea corespunzatoare unei chei din fisierul de configurare
        /// </summary>
        /// <param name="sCheie"></param>
        /// <returns></returns>
        public static string getCheieConfigurare(string sCheie)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(sCheie);
        }

        public static bool existaConexiuneBDD()
        {
            return existaCheieConfigurare("SQLConnection");
        }
        public static void seteazaConexiuneBDD(string pServer, string pInstanta, string pUser, string pParola, bool pIntegratedSecurity, string pNumeBDD)
        {
            seteazaConexiuneBDD(getNumeConexiuneBDD(pServer, pInstanta, pUser, pParola, pNumeBDD, pIntegratedSecurity));
        }


        /// <summary>
        /// Ar fi util sa: You can add Connection Timeout=180; to your connection string
        /// </summary>
        /// <param name="pConexiune"></param>
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

        public static bool SeFolosesteTastaturaVirtuala()
        {
            string ok = getCheieConfigurare("TastaturaVirtuala");

            return "DA".Equals(ok);
        }

        public static string GetUltimulUtilizatorConectat()
        {
            return getCheieConfigurare("UUC");
        }

        public static void SetUltimulUtilizatorConectat(string pContUUC)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("UUC"))
            {
                configuration.AppSettings.Settings["UUC"].Value = pContUUC;
            }
            else
            {
                configuration.AppSettings.Settings.Add("UUC", pContUUC);
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool EsteMeniulStangaAscuns()
        {
            bool rez = false;

            string ok = getCheieConfigurare("MeniuStanga");
            if (!string.IsNullOrEmpty(ok) && bool.TryParse(ok, out rez))
                return rez;

            return false;
        }

        /// <summary>
        /// Cu dedicatie pentru 3D
        /// Pentru a putea porni pe aceeasi masina, pentru utilizatori diferiti, iStoma
        /// </summary>
        /// <returns></returns>
        public static bool EsteMultiSesiune()
        {
            bool rez = false;

            string ok = getCheieConfigurare("MS");
            if (!string.IsNullOrEmpty(ok) && bool.TryParse(ok, out rez))
                return rez;

            return false;
        }

        public static bool PermiteSchimbareaLimbii()
        {
            int idLimba = 0;

            string ok = getCheieConfigurare("PSL");
            if (!string.IsNullOrEmpty(ok) && int.TryParse(ok, out idLimba))
                return idLimba > 0;

            return false;
        }

        public static void SeteazaLimbaImpusa(int pIdLimba)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("PSL"))
            {
                configuration.AppSettings.Settings["PSL"].Value = pIdLimba.ToString();
            }
            else
            {
                configuration.AppSettings.Settings.Add("PSL", pIdLimba.ToString());
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void SetMeniulStangaAscuns(bool pAscuns)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("MeniuStanga"))
            {
                configuration.AppSettings.Settings["MeniuStanga"].Value = pAscuns.ToString();
            }
            else
            {
                configuration.AppSettings.Settings.Add("MeniuStanga", pAscuns.ToString());
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static int GetRezolutieCamera()
        {
            int rezId = 1;

            string ok = getCheieConfigurare("RezolutieCamera");
            if (!string.IsNullOrEmpty(ok) && int.TryParse(ok, out rezId))
                return rezId;

            return 1;
        }

        public static void SetRezolutieCamera(int pRezId)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("RezolutieCamera"))
            {
                configuration.AppSettings.Settings["RezolutieCamera"].Value = pRezId.ToString();
            }
            else
            {
                configuration.AppSettings.Settings.Add("RezolutieCamera", pRezId.ToString());
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string getVersiuneActualizareAplicatie()
        {
            return getCheieConfigurare("VersiuneActualizareAplicatie");
        }

        public static void seteazaVersiuneActualizareAplicatie(string pVersiune)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("VersiuneActualizareAplicatie"))
            {
                configuration.AppSettings.Settings["VersiuneActualizareAplicatie"].Value = pVersiune;
            }
            else
            {
                configuration.AppSettings.Settings.Add("VersiuneActualizareAplicatie", pVersiune);
            }

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void seteazaFolderDocumente(string pCaleFolderDocumente)
        {
            if (string.IsNullOrEmpty(pCaleFolderDocumente)) return;

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("AdresaSalvareDocumente"))
                configuration.AppSettings.Settings["AdresaSalvareDocumente"].Value = pCaleFolderDocumente;
            else
                configuration.AppSettings.Settings.Add("AdresaSalvareDocumente", pCaleFolderDocumente);

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            string folderAplicatie = CUtil.GetLocatieAplicatie();

            if (Directory.Exists(folderAplicatie))
            {
                folderAplicatie = Path.Combine(folderAplicatie, "Temp");

                if (!Directory.Exists(folderAplicatie))
                    Directory.CreateDirectory(folderAplicatie);

                seteazaFolderTemporar(folderAplicatie);
            }
            else
            {
                folderAplicatie = Path.Combine(pCaleFolderDocumente, "Temp");
                if (!Directory.Exists(folderAplicatie))
                    Directory.CreateDirectory(folderAplicatie);

                seteazaFolderTemporar(folderAplicatie);
            }

            string folderBackup = Path.Combine(pCaleFolderDocumente, "BackupBDD");
            if (!Directory.Exists(folderBackup))
                Directory.CreateDirectory(folderBackup);

            seteazaFolderBackup(folderBackup);
        }

        public static void seteazaFolderTemporar(string pCaleFolderTemporar)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("AdresaDirectorTemporar"))
                configuration.AppSettings.Settings["AdresaDirectorTemporar"].Value = pCaleFolderTemporar;
            else
                configuration.AppSettings.Settings.Add("AdresaDirectorTemporar", pCaleFolderTemporar);

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void DeschideFisier(FileInfo fisierDateMelag)
        {
            if (fisierDateMelag != null && File.Exists(fisierDateMelag.FullName))
            {
                System.Diagnostics.Process.Start(fisierDateMelag.FullName);
            }
        }

        public static string GetSQLConnectionDinRegistri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("SQLC"));
        }

        public static void SetSQLConnectionDinRegistri(string pSQLConnection)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("SQLC", pSQLConnection);
        }

        /// <summary>
        /// de modificat si in ActualizareAplicatie
        /// </summary>
        /// <returns></returns>
        public static int GetTipAplicatieDinRegistri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToInt32(cheie.GetValue("TAPLIDAVA"));
        }

        public static void SetTipAplicatieInRegistri(int pTipAplicatie)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("TAPLIDAVA", pTipAplicatie.ToString());
        }

        public static void PuneLicentaInRegistriiDacaExistaInConfig()
        {
            string licenta = getLicenta();

            if (string.IsNullOrEmpty(licenta))
            {
                string licentaConfig = getCheieConfigurare("LICENTA");

                if (!string.IsNullOrEmpty(licentaConfig))
                {
                    Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
                    cheie.SetValue("LICENTA", licentaConfig);
                }
            }
        }

        #region Casa de marcat

        public static void SetCasaMarcatTipPlataOP(int pTipPlataOP)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CMTPOP", pTipPlataOP);
        }

        public static int GetCasaMarcatTipPlataOP()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string rez = Convert.ToString(cheie.GetValue("CMTPOP"));
            int tip = 0;

            if (!string.IsNullOrEmpty(rez) && int.TryParse(rez, out tip))
                return tip;

            return 1;
        }

        public static void SetCasaMarcatTipPlataCash(int pTipPlataCash)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CMTPC", pTipPlataCash);
        }

        public static void SetCasaMarcatTipPlataPOS(int pTipPlataPOS)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CMTPP", pTipPlataPOS);
        }

        public static int GetCasaMarcatTipPlataCash()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string rez = Convert.ToString(cheie.GetValue("CMTPC"));
            int tip = 0;

            if (!string.IsNullOrEmpty(rez) && int.TryParse(rez, out tip))
                return tip;

            return 1;
        }

        public static int GetCasaMarcatTipPlataPOS()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string rez = Convert.ToString(cheie.GetValue("CMTPP"));
            int tip = 0;

            if (!string.IsNullOrEmpty(rez) && int.TryParse(rez, out tip))
                return tip;

            return 3;
        }

        public static string getFolderCTemp()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("CTemp"));
        }

        public static void seteazaFolderCTemp(string pCaleCTemp)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CTemp", pCaleCTemp);
        }

        public static string getFolderRaspunsuri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("CTempRasp"));
        }

        public static void seteazaFolderRaspunsuri(string pCaleCTemp)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CTempRasp", pCaleCTemp);
        }

        public static void SetCasaDeMarcatModTest(bool pModTest)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CMMT", pModTest.ToString());
        }

        public static bool GetCasaDeMarcatModTest()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("CMMT"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return false;
        }

        public static void SetCasaDeMarcatConectata(bool pExista)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CM", pExista.ToString());
        }

        public static bool GetCasaDeMarcatConectata()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("CM"));
            bool exista = false;
            if (bool.TryParse(val, out exista))

                return exista;

            return false;
        }

        private static int _SModelCasaDeMarcat = -1;
        private static int _SGeneratieCasaDeMarcat = 0;
        public static void SetModelCasaDeMarcatConectata(int pModelCasaDeMarcat)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("MCM", pModelCasaDeMarcat.ToString());
            _SModelCasaDeMarcat = pModelCasaDeMarcat;
        }

        public static void SetGeneratieCasaDeMarcatConectata(int pGeneratieCasaDeMarcat)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("GCM", pGeneratieCasaDeMarcat.ToString());
            _SGeneratieCasaDeMarcat = pGeneratieCasaDeMarcat;
        }

        public static int GetModelCasaDeMarcatConectata()
        {
            if (_SModelCasaDeMarcat > 0)
                return _SModelCasaDeMarcat;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("MCM"));
            int exista = 0;
            if (Int32.TryParse(val, out exista))
                _SModelCasaDeMarcat = exista;

            return _SModelCasaDeMarcat;
        }

        public static int GetGeneratieCasaDeMarcatConectata()
        {
            if (_SGeneratieCasaDeMarcat > 0)
                return _SGeneratieCasaDeMarcat;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("GCM"));
            int exista = 0;
            if (Int32.TryParse(val, out exista))
                _SGeneratieCasaDeMarcat = exista;

            return _SGeneratieCasaDeMarcat;
        }

        private static string _SCodCotaTVA = string.Empty;
        public static string GetCodCotaTVA()
        {
            if (!string.IsNullOrEmpty(_SCodCotaTVA))
                return _SCodCotaTVA;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SCodCotaTVA = Convert.ToString(cheie.GetValue("CCTVA"));
            //int exista = 0;
            //if (Int32.TryParse(val, out exista))
            //    _SCodCotaTVA = exista;

            return _SCodCotaTVA;
        }

        public static void SetCodCotaTVA(string pCodCotaTVA)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("CCTVA", pCodCotaTVA.ToString());
            _SCodCotaTVA = pCodCotaTVA;
        }

        public static string GetSufixFisierRaspuns()
        {
            if (!string.IsNullOrEmpty(_SSufixFisierRaspuns))
                return _SSufixFisierRaspuns;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SSufixFisierRaspuns = Convert.ToString(cheie.GetValue("SRCM"));

            return _SSufixFisierRaspuns;
        }

        private static string _SSufixFisierRaspuns = string.Empty;
        public static void SetSufixFisierRaspuns(string pSufixFisierRaspuns)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("SRCM", pSufixFisierRaspuns);
            _SSufixFisierRaspuns = pSufixFisierRaspuns;
        }

        public static string GetSerieCasa()
        {
            if (!string.IsNullOrEmpty(_SSerieCasa))
                return _SSerieCasa;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SSerieCasa = Convert.ToString(cheie.GetValue("SERIECM"));

            return _SSerieCasa;
        }

        private static string _SSerieCasa = string.Empty;
        public static void SetSerieCasa(string pSerieCasa)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("SERIECM", pSerieCasa);
            _SSerieCasa = pSerieCasa;
        }

        public static string GetPortCasa()
        {
            if (!string.IsNullOrEmpty(_SPortCasa))
                return _SPortCasa;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SPortCasa = Convert.ToString(cheie.GetValue("PORTCM"));

            return _SPortCasa;
        }

        private static string _SPortCasa = string.Empty;
        public static void SetPortCasa(string pPortCasa)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("PORTCM", pPortCasa);
            _SPortCasa = pPortCasa;
        }

        #endregion

        #region Setari Acest Calculator

        public static void SetComunicareCalculatorSitePropriu(bool pComunica)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("ACCSP", pComunica.ToString());
        }

        public static bool GetComunicareCalculatorSitePropriu()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("ACCSP"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return false;
        }

        public static void SetComunicareCalculatorGoogle(bool pComunica)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("ACGC", pComunica.ToString());
        }

        public static bool? GetComunicareCalculatorGoogle()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("ACGC"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return null;
        }

        public static void SetComunicareCalculatorBNR(bool pComunica)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("ACCV", pComunica.ToString());
        }

        public static bool GetComunicareCalculatorBNR()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string val = Convert.ToString(cheie.GetValue("ACCV"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return true;
        }

        public static void SetIPTelefonSMSCenter(string pIPTelefon)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("SC", pIPTelefon);
        }

        public static string GetIPTelefonSMSCenter()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("SC"));
        }

        public static void SetPrimesteNotificariDeLaIStomaSMSCenter(bool pPrimeste)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("SN", pPrimeste.ToString());
        }

        public static bool GetPrimesteNotificariDeLaIStomaSMSCenter()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");


            string val = Convert.ToString(cheie.GetValue("SN"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return false;
        }

        private static string _SSeparatorCSV = ",";
        public static void SetSeparatorCSV(string pSeparatorCSV)
        {
            if (!_SSeparatorCSV.Equals(pSeparatorCSV) && !string.IsNullOrEmpty(pSeparatorCSV))
            {
                Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
                cheie.SetValue("SEPCSV", pSeparatorCSV);
                _SSeparatorCSV = pSeparatorCSV;
            }
        }

        public static string GetSeparatorCSV()
        {
            if (!string.IsNullOrEmpty(_SSeparatorCSV))
                return _SSeparatorCSV;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SSeparatorCSV = Convert.ToString(cheie.GetValue("SEPCSV"));

            return _SSeparatorCSV;
        }

        private static int _SFactorAjustareFontAgenda = 0;
        public static void SetFactorAjustareFontAgenda(int pFactorAjustareFontAgenda)
        {
            if (_SFactorAjustareFontAgenda != pFactorAjustareFontAgenda)
            {
                Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
                cheie.SetValue("FAFA", pFactorAjustareFontAgenda);
                _SFactorAjustareFontAgenda = pFactorAjustareFontAgenda;
            }
        }

        public static int GetFactorAjustareFontAgenda()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            _SFactorAjustareFontAgenda = Convert.ToInt32(cheie.GetValue("FAFA"));

            return _SFactorAjustareFontAgenda;
        }

        private static Microsoft.Win32.RegistryKey GetCheieCitireIStomaLocalMachine()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return cheie;
        }

        private static Microsoft.Win32.RegistryKey GetCheieScriereIStomaLocalMachine()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return cheie;
        }

        public static void SetAcestCalculatorCabinet(int pIdCabinet)
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieScriereIStomaLocalMachine();
            cheie.SetValue("ACCAB", pIdCabinet);
        }

        public static int GetAcestCalculatorCabinet()
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieCitireIStomaLocalMachine();

            return CUtil.GetAsInt32(cheie.GetValue("ACCAB"));
        }

        public static void SetAcestCalculatorFolderComunRadiologie(string pLocatieFolder)
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieScriereIStomaLocalMachine();
            cheie.SetValue("ACFCRAD", pLocatieFolder);
        }

        public static string GetAcestCalculatorFolderComunRadiologie()
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieCitireIStomaLocalMachine();

            return Convert.ToString(cheie.GetValue("ACFCRAD"));
        }

        public static void SetSenzorulEsteConectatLaAcestCalculator(bool pSenzorConectat)
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieScriereIStomaLocalMachine();
            cheie.SetValue("RADSECLAC", pSenzorConectat.ToString());
        }

        public static bool GetSenzorulEsteConectatLaAcestCalculator()
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieCitireIStomaLocalMachine();

            string val = Convert.ToString(cheie.GetValue("RADSECLAC"));
            bool exista = false;
            if (bool.TryParse(val, out exista))
                return exista;

            return false;
        }

        public static void SetDelaySenzorRadiologie(int pRezId)
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieScriereIStomaLocalMachine();
            cheie.SetValue("RADSDELAY", pRezId.ToString());
        }

        public static int GetDelaySenzorRadiologie()
        {
            Microsoft.Win32.RegistryKey cheie = GetCheieCitireIStomaLocalMachine();

            string val = Convert.ToString(cheie.GetValue("RADSDELAY"));
            int delay = 10;
            if (int.TryParse(val, out delay))
                return delay;

            return 10;
        }

        #endregion

        public static void seteazaFolderBackup(string pCaleFolderBackup)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("AdresaDirectorBackup"))
                configuration.AppSettings.Settings["AdresaDirectorBackup"].Value = pCaleFolderBackup;
            else
                configuration.AppSettings.Settings.Add("AdresaDirectorBackup", pCaleFolderBackup);

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void seteazaFolderRadiografiiPrimite(string pCale)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("CaleRadiografiiPrimite"))
                configuration.AppSettings.Settings["CaleRadiografiiPrimite"].Value = pCale;
            else
                configuration.AppSettings.Settings.Add("CaleRadiografiiPrimite", pCale);

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool existaCheieConfigurare(string pCheie)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(pCheie) && !string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get(pCheie));
        }

        public static void SeteazaCheiePrinter(string pPrinterName)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains("BCPRINTER"))
                configuration.AppSettings.Settings["BCPRINTER"].Value = pPrinterName;
            else
                configuration.AppSettings.Settings.Add("BCPRINTER", pPrinterName);

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Recuperam valoarea din fisierul de configurare ce corespunde unui tip de cheie
        /// </summary>
        /// <param name="pTipCheie"></param>
        /// <returns></returns>
        public static string GetValoareDupaTipCheie(EnumTipCheie pTipCheie)
        {
            string ValoaraRezultat = string.Empty;

            switch (pTipCheie)
            {
                case EnumTipCheie.MarimeDosarPacient:
                    ValoaraRezultat = getCheieConfigurare("MarimeDosarPacient");
                    break;
                case EnumTipCheie.MarimeEcranDeFacut:
                    ValoaraRezultat = getCheieConfigurare("MarimeEcranDeFacut");
                    break;
                case EnumTipCheie.MarimeEcranCalculVenit:
                    ValoaraRezultat = getCheieConfigurare("MarimeEcranCalculVenit");
                    break;
                case EnumTipCheie.MarimeEcranCalculVenitIncasari:
                    ValoaraRezultat = getCheieConfigurare("MarimeEcranCalculVenitIncasari");
                    break;
                case EnumTipCheie.Nedefinit:
                    break;
                case EnumTipCheie.AdresaSalvareDocumente:
                    if (string.IsNullOrEmpty(lAdresaSalvareDocumente))
                    {
                        lAdresaSalvareDocumente = getCheieConfigurare("AdresaSalvareDocumente");
                    }
                    ValoaraRezultat = lAdresaSalvareDocumente;
                    break;
                case EnumTipCheie.AdresaDirectorTemporar:
                    if (string.IsNullOrEmpty(lAdresaDirectorTemporar))
                    {
                        lAdresaDirectorTemporar = getCheieConfigurare("AdresaDirectorTemporar");
                    }
                    ValoaraRezultat = lAdresaDirectorTemporar;
                    break;
                case EnumTipCheie.AdresaBackupBDD:
                    ValoaraRezultat = getCheieConfigurare("AdresaDirectorBackup");
                    break;
                case EnumTipCheie.CursBNR:
                    ValoaraRezultat = getCheieConfigurare("CursBNR");
                    break;
                case EnumTipCheie.CaleRadiografiiPrimite:
                    ValoaraRezultat = getCheieConfigurare("CaleRadiografiiPrimite");
                    break;
                case EnumTipCheie.IdCalc:
                    ValoaraRezultat = getCheieConfigurare("UniversalTimeSpan");
                    break;
                case EnumTipCheie.UUC:
                    ValoaraRezultat = getCheieConfigurare("UUC");
                    break;
                default:
                    ValoaraRezultat = getCheieConfigurare(pTipCheie.ToString());
                    break;
            }

            return ValoaraRezultat;
        }

        public static void ScrieSirDeOctetiInFisier(string pAdresaFisier, byte[] pData)
        {
            using (FileStream fisier = File.OpenWrite(pAdresaFisier))
            {
                if (pData != null)
                {
                    for (int i = 0; i < pData.Length; i++)
                    {
                        fisier.WriteByte(pData[i]);
                    }
                }
                fisier.Close();
            }
        }

        public static void ScrieFisier(string pCaleFisier, string pContinut)
        {
            if (File.Exists(pCaleFisier))
                File.Delete(pCaleFisier);

            using (System.IO.StreamWriter file = File.CreateText(pCaleFisier))
            {
                file.Write(pContinut);
                file.Close();
            }
        }

        public static byte[] CitesteSirDeOctetiDinFisier(string pAdresaFisier)
        {
            byte[] rezultat = null;
            using (MemoryStream memOut = new MemoryStream(1))
            {
                if (File.Exists(pAdresaFisier))
                {
                    using (FileStream fisier = File.OpenRead(pAdresaFisier))
                    {
                        int octet = -1;
                        if (fisier.CanRead)
                            octet = fisier.ReadByte();

                        while (octet != -1)
                        {
                            memOut.WriteByte(Convert.ToByte(octet));
                            octet = fisier.ReadByte();
                        }
                        fisier.Close();
                    }
                }

                rezultat = memOut.ToArray();
            }

            return rezultat;
        }

        public static void setIdCalculator(string pIdCalculator)
        {
            //UniversalTimeSpan
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("UniversalTimeSpan"))
                    configuration.AppSettings.Settings["UniversalTimeSpan"].Value = pIdCalculator;
                else
                    configuration.AppSettings.Settings.Add("UniversalTimeSpan", pIdCalculator);

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static void setCursBNR(double pCursEUR)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("CursBNR"))
                    configuration.AppSettings.Settings["CursBNR"].Value = Convert.ToString(pCursEUR);
                else
                    configuration.AppSettings.Settings.Add("CursBNR", Convert.ToString(pCursEUR));

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static void setUltimulUtilizatorConectat(string pContStoma)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("UUC"))
                    configuration.AppSettings.Settings["UUC"].Value = Convert.ToString(pContStoma);
                else
                    configuration.AppSettings.Settings.Add("UUC", Convert.ToString(pContStoma));

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static string getUltimulUtilizatorConectat()
        {
            string contStoma = string.Empty;

            try
            {
                string contStomaConfig = GetValoareDupaTipCheie(EnumTipCheie.UUC);

                if (!string.IsNullOrEmpty(contStomaConfig))
                {
                    contStoma = contStomaConfig;
                }
                else
                {
                    setUltimulUtilizatorConectat(contStoma);
                }
            }
            catch (Exception)
            {
                contStoma = string.Empty;
                setUltimulUtilizatorConectat(contStoma);
            }

            return contStoma;
        }


        public static double getCursBNR()
        {
            double curs = 1;

            try
            {
                string cursConfig = GetValoareDupaTipCheie(EnumTipCheie.CursBNR);

                if (!string.IsNullOrEmpty(cursConfig))
                {
                    curs = Convert.ToDouble(cursConfig);
                }
                else
                {
                    setCursBNR(curs);
                }
            }
            catch (Exception)
            {
                curs = 1;
                setCursBNR(curs);
            }

            return curs;
        }

        #endregion

        #region Metode private

        public static string getLicenta()
        {
            string licentaConfig = getCheieConfigurare("LICENTA");

            if (!string.IsNullOrEmpty(licentaConfig))
                return licentaConfig;

            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("LICENTA"));
        }

        public static int GetLimba()
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

        public static void SetLimba(int pIdLimba)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("LIMBA", pIdLimba);
        }

        internal static string getCheieString()
        {
            string licenta = getLicenta().Replace("-", "").Replace(" ", "");
            licenta = string.Format("{1}{0}", licenta.Substring(0, 11), licenta.Substring(11));
            return string.Concat(licenta[3], licenta[9], licenta[15], licenta[18]);
        }

        #endregion

        public static string GetConnectionString()
        {
            return CGestiuneIO.getCheieConfigurare("SQLConnection");
        }

        private static string GetIPLocal()   //get IP address
        {
            System.Net.IPHostEntry ipHost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()); ;

            string ipLocal = string.Empty;

            foreach (var item in ipHost.AddressList)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || string.IsNullOrEmpty(ipLocal))
                    ipLocal = item.ToString();
            }

            return ipLocal;
        }
        public static Tuple<string, string, string, string, string, string> getDateConectare()
        {
            return getDateConectare(true);
        }

        public static Tuple<string, string, string, string, string, string> getDateConectare(bool pSecurizeaza)
        {
            string[] lista = GetConnectionString().Split(';');

            string server = string.Empty;
            string port = "1313";
            string instanta = string.Empty;
            string bdd = string.Empty;
            string user = string.Empty;
            string pass = string.Empty;

            if (lista.Length > 3)
            {
                //Server + instanta
                string[] serverInstanta = lista[0].Replace("Data Source=", "").Split('\\');
                if (serverInstanta.Length == 2)
                {
                    server = GetIPLocal();// serverInstanta[0].Trim();
                    instanta = serverInstanta[1].Trim();
                }

                bdd = lista[1].Replace("Initial Catalog=", "").Trim();
                user = lista[2].Replace("uid=", "").Trim();
                pass = lista[3].Replace("password=", "").Trim();
            }

            if (pSecurizeaza)
            {
                CSecuritate.GetTextSecurizatDinText(ref server);
                CSecuritate.GetTextSecurizatDinText(ref port);
                CSecuritate.GetTextSecurizatDinText(ref instanta);
                CSecuritate.GetTextSecurizatDinText(ref bdd);
                CSecuritate.GetTextSecurizatDinText(ref user);
                CSecuritate.GetTextSecurizatDinText(ref pass);
            }

            return new Tuple<string, string, string, string, string, string>(server, port, instanta, bdd, user, pass);
        }

        #region Dimensiuni personalizate ecrane

        /// <summary>
        /// Salvam dimensiunea aleasa pe acest calculator pentru deschiderea in popup a unei optiuni
        /// 
        /// ATENTIE!!! Transmitem Size.Empty daca ecranul este maximized
        /// 
        /// </summary>
        /// <param name="pNumeControl"></param>
        /// <param name="pMarime"></param>
        public static void SetMarimeEcran(string pNumeControl, Size pMarime)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue(pNumeControl, string.Format("{0};{1}", pMarime.Width, pMarime.Height));
        }

        /// <summary>
        /// Recuperam dimensiunea aleasa pe acest calculator pentru deschiderea in popup a unei optiuni
        /// </summary>
        /// <param name="pNumeControl"></param>
        /// <param name="pMarimeDefault"></param>
        /// <returns></returns>
        public static Size GetMarimeEcran(string pNumeControl, Size pMarimeDefault)
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            string marimeConfig = Convert.ToString(cheie.GetValue(pNumeControl));
            if (!string.IsNullOrEmpty(marimeConfig) && marimeConfig.Contains(";"))
            {
                string[] valoriMarime = marimeConfig.Split(new string[] { ";" }, StringSplitOptions.None);
                if (valoriMarime.Length == 2)
                    return new Size(Convert.ToInt32(valoriMarime[0]), Convert.ToInt32(valoriMarime[1]));
            }

            return pMarimeDefault;
        }

        public static void SetMarimeEcranPacienti(Size pMarime)
        {
            //MarimeDosarPacient
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string marime = string.Format("{0};{1}", pMarime.Width, pMarime.Height);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("MarimeDosarPacient"))
                    configuration.AppSettings.Settings["MarimeDosarPacient"].Value = marime;
                else
                    configuration.AppSettings.Settings.Add("MarimeDosarPacient", marime);

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static Size GetMarimeEcranPacienti()
        {
            Size marime = Size.Empty;

            try
            {
                string marimeConfig = GetValoareDupaTipCheie(EnumTipCheie.MarimeDosarPacient);

                if (!string.IsNullOrEmpty(marimeConfig) && marimeConfig.Contains(";"))
                {
                    string[] valoriMarime = marimeConfig.Split(new string[] { ";" }, StringSplitOptions.None);
                    if (valoriMarime.Length == 2)
                        marime = new Size(Convert.ToInt32(valoriMarime[0]), Convert.ToInt32(valoriMarime[1]));
                }
            }
            catch (Exception)
            {
                marime = Size.Empty;
            }

            return marime;
        }

        public static Size GetMarimeEcranDeFacut()
        {
            Size marime = Size.Empty;

            try
            {
                string marimeConfig = GetValoareDupaTipCheie(EnumTipCheie.MarimeEcranDeFacut);

                if (!string.IsNullOrEmpty(marimeConfig) && marimeConfig.Contains(";"))
                {
                    string[] valoriMarime = marimeConfig.Split(new string[] { ";" }, StringSplitOptions.None);
                    if (valoriMarime.Length == 2)
                        marime = new Size(Convert.ToInt32(valoriMarime[0]), Convert.ToInt32(valoriMarime[1]));
                }
            }
            catch (Exception)
            {
                marime = Size.Empty;
            }

            return marime;
        }

        public static void SetMarimeEcranDeFacut(Size pMarime)
        {
            //MarimeEcranDeFacut
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string marime = string.Format("{0};{1}", pMarime.Width, pMarime.Height);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("MarimeEcranDeFacut"))
                    configuration.AppSettings.Settings["MarimeEcranDeFacut"].Value = marime;
                else
                    configuration.AppSettings.Settings.Add("MarimeEcranDeFacut", marime);

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static Size GetMarimeEcranCalculVenit()
        {
            Size marime = Size.Empty;

            try
            {
                string marimeConfig = GetValoareDupaTipCheie(EnumTipCheie.MarimeEcranCalculVenit);

                if (!string.IsNullOrEmpty(marimeConfig) && marimeConfig.Contains(";"))
                {
                    string[] valoriMarime = marimeConfig.Split(new string[] { ";" }, StringSplitOptions.None);
                    if (valoriMarime.Length == 2)
                        marime = new Size(Convert.ToInt32(valoriMarime[0]), Convert.ToInt32(valoriMarime[1]));
                }
            }
            catch (Exception)
            {
                marime = Size.Empty;
            }

            return marime;
        }

        public static void SetMarimeEcranCalculVenit(Size pMarime)
        {
            //MarimeEcranCalculVenit
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string marime = string.Format("{0};{1}", pMarime.Width, pMarime.Height);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("MarimeEcranCalculVenit"))
                    configuration.AppSettings.Settings["MarimeEcranCalculVenit"].Value = marime;
                else
                    configuration.AppSettings.Settings.Add("MarimeEcranCalculVenit", marime);

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static Size GetMarimeEcranCalculVenitIncasari()
        {
            Size marime = Size.Empty;

            try
            {
                string marimeConfig = GetValoareDupaTipCheie(EnumTipCheie.MarimeEcranCalculVenitIncasari);

                if (!string.IsNullOrEmpty(marimeConfig) && marimeConfig.Contains(";"))
                {
                    string[] valoriMarime = marimeConfig.Split(new string[] { ";" }, StringSplitOptions.None);
                    if (valoriMarime.Length == 2)
                        marime = new Size(Convert.ToInt32(valoriMarime[0]), Convert.ToInt32(valoriMarime[1]));
                }
            }
            catch (Exception)
            {
                marime = Size.Empty;
            }

            return marime;
        }

        public static void SetMarimeEcranCalculVenitIncasari(Size pMarime)
        {
            //MarimeEcranCalculVenitIncasari
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string marime = string.Format("{0};{1}", pMarime.Width, pMarime.Height);
                if (ConfigurationManager.AppSettings.AllKeys.Contains("MarimeEcranCalculVenitIncasari"))
                    configuration.AppSettings.Settings["MarimeEcranCalculVenitIncasari"].Value = marime;
                else
                    configuration.AppSettings.Settings.Add("MarimeEcranCalculVenitIncasari", marime);

                configuration.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
            }
        }

        public static FileInfo GetFisier(string folderDocumente, string pContinutDenumireFisier, string pExtensie)
        {
            FileInfo fisier = null;

            foreach (var item in Directory.GetFiles(folderDocumente))
            {
                if (item.Contains(pContinutDenumireFisier))
                {
                    fisier = new FileInfo(item);

                    if (!fisier.Extension.ToLower().Contains(pExtensie.ToLower()))
                        fisier = null;
                    else
                        break;
                }
            }

            if (fisier == null)
            {
                foreach (var subFolder in Directory.GetDirectories(folderDocumente))
                {
                    fisier = GetFisier(subFolder, pContinutDenumireFisier, pExtensie);
                    if (fisier != null)
                        break;
                }
            }

            return fisier;
        }

        #endregion

    }
}
