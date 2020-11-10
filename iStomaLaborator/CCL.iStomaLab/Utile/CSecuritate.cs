using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CCL.iStomaLab.Utile
{
    public static class CSecuritate
    {

        public static bool _SConexiuneInRegistrii = true;

        private static MD5 _MD5Hash = null;
        private static int[] _Cheie = null;
        private static List<string> _pula = new List<string>() { "3", "A", "D", "I", "V", "4", "0", "2", "B", "Q" };
        private static Random _Aleatoriu = new Random();
        private static DateTime DataNula = new DateTime(1, 1, 1, 0, 0, 0, 0);

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (null != identity)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }

        public static void Marcheaza(System.Drawing.Bitmap pImagine)
        {
            string fisierID = getNumeData();

            if (!System.IO.File.Exists(fisierID))
            {
                pImagine.Save(fisierID);
                setDate();
            }
        }

        private static void setDate()
        {
            string fisierID = getNumeData();

            System.Drawing.Bitmap pData = getDataVerif();

            DateTime acum = DateTime.Now;
            pData.SetPixel(13, 13, System.Drawing.Color.FromArgb(acum.Year - 2000, acum.Month, acum.Day));
            pData.SetPixel(20, 20, System.Drawing.Color.FromArgb(acum.Hour, acum.Minute, acum.Second));

            //pentru deruta setam si alti pixeli cu cifre aleatorii
            pData.SetPixel(14, 14, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(14, 16, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(20, 16, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(21, 21, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(15, 15, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(15, 19, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(27, 26, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(17, 28, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(5, 10, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(12, 25, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));
            pData.SetPixel(11, 19, System.Drawing.Color.FromArgb(acum.Year - 2000, _Aleatoriu.Next(0, 12), _Aleatoriu.Next(0, 31)));

            ScrieSirDeOctetiInFisier(fisierID, ToByteArray(pData, System.Drawing.Imaging.ImageFormat.Png));
            ScrieDataInRegistri();
        }

        private static Bitmap getDataVerif()
        {
            string fisierID = getNumeData();
            if (!System.IO.File.Exists(fisierID))
                return null;

            byte[] bytes = System.IO.File.ReadAllBytes(fisierID);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);

            return new Bitmap(Image.FromStream(ms));
        }

        private static string getNumeData()
        {
            string appFileName = Environment.GetCommandLineArgs()[0];

            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(appFileName), "id.png");
        }

        private static long DateDiffZile(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2 - dt1;

            double dVal = ts.TotalDays;

            if (dVal >= 0)
                return (long)Math.Floor(dVal);
            return (long)Math.Ceiling(dVal);
        }

        public static DateTime getDataVerificare()
        {
            if (!_SConexiuneInRegistrii) return DateTime.Now;

            Bitmap pData = getDataVerif();

            if (pData == null) return DataNula;

            Color data = pData.GetPixel(13, 13);
            Color ora = pData.GetPixel(20, 20);

            try
            {
                DateTime dataR = new DateTime(2000 + data.R, data.G, data.B, ora.R, ora.G, ora.B);

                if (DateDiffZile(dataR, DateTime.Today) >= 30)
                    dataR = DataNula;

                return dataR;
            }
            catch (Exception)
            {
                return DataNula;
            }
        }

        private static string getCheieString()
        {
            string licenta = getLicenta().Replace("-", "").Replace(" ", "");
            licenta = string.Format("{1}{0}", licenta.Substring(0, 11), licenta.Substring(11));
            return string.Concat(licenta[3], licenta[9], licenta[15], licenta[18]);
        }

        private static string getLicenta()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            return Convert.ToString(cheie.GetValue("LICENTA"));
        }

        private static void incarcaCheiaNumerica()
        {
            if (_Cheie == null)
            {
                string pCheie = getCheieString();

                if (getDataVerificare() == DataNula)
                    pCheie = string.Empty;

                if (pCheie.Length != 4)
                {

                    _Cheie = new int[] {DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year - 2000,
                                        DateTime.Now.Hour, DateTime.Today.Minute, DateTime.Today.Second,
                                        _Aleatoriu.Next(1000), _Aleatoriu.Next(1000)};
                }
                else
                {
                    string cifreLitera = Convert.ToInt32(pCheie[0]).ToString();
                    _Cheie = new int[8];
                    _Cheie[0] = Convert.ToInt32(cifreLitera[0].ToString());
                    _Cheie[1] = Convert.ToInt32(cifreLitera[1].ToString());

                    cifreLitera = Convert.ToInt32(pCheie[1]).ToString();
                    _Cheie[2] = Convert.ToInt32(cifreLitera[0].ToString());
                    _Cheie[3] = Convert.ToInt32(cifreLitera[1].ToString());

                    cifreLitera = Convert.ToInt32(pCheie[2]).ToString();
                    _Cheie[4] = Convert.ToInt32(cifreLitera[0].ToString());
                    _Cheie[5] = Convert.ToInt32(cifreLitera[1].ToString());

                    cifreLitera = Convert.ToInt32(pCheie[3]).ToString();
                    _Cheie[6] = Convert.ToInt32(cifreLitera[0].ToString());
                    _Cheie[7] = Convert.ToInt32(cifreLitera[1].ToString());
                }
            }
        }
        private static int _incercari = 0;
        public static DateTime FinalizeazaInregistrarea(string pCodVerificare)
        {
            //int an = 0;
            //int luna = 0;
            //int zi = 0;
            //string codVerif = pCodVerificare;
            //FinalizeazaInregistrarea();
            //CLegatura.FinalizeazaInregistrarea(ref codVerif, codVerif.Length, ref an, ref luna, ref zi);
            //return new DateTime(an, luna, zi, 13, 2, 38);
            if (pCodVerificare.Length == 16)
            {
                DateTime data = DateTime.Today.AddDays(20);
                bool ok = false;
                string codUtil = string.Format("{0}{1}", pCodVerificare.Substring(0, 4), pCodVerificare.Substring(pCodVerificare.Length - 4));
                int d1 = 0;
                int d2 = 1;
                int d3 = 0;
                int d4 = 1;

                if (data.Day % 2 == 0)
                {
                    d1 = _pula.IndexOf(codUtil[4].ToString());
                    d2 = _pula.IndexOf(codUtil[2].ToString());
                    d3 = _pula.IndexOf(codUtil[6].ToString());
                    d4 = _pula.IndexOf(codUtil[0].ToString());
                }
                else
                {
                    d1 = _pula.IndexOf(codUtil[2].ToString());
                    d2 = _pula.IndexOf(codUtil[1].ToString());
                    d3 = _pula.IndexOf(codUtil[7].ToString());
                    d4 = _pula.IndexOf(codUtil[5].ToString());
                }

                ok = (data.Day == (d3 * 10 + d4)) && (data.Month == (d1 * 10 + d2));

                if (ok)
                {
                    setDate();

                    return new DateTime(Convert.ToInt32(pCodVerificare.Substring(4, 4)),
                                        Convert.ToInt32(pCodVerificare.Substring(8, 2)),
                                        Convert.ToInt32(pCodVerificare.Substring(10, 2)));
                }
                else
                {

                    _incercari += 1;
                }
            }

            return DataNula;
        }

        public static void FinalizeazaInregistrarea()
        {
            ScrieDataInRegistri();
        }
        
        private static void ScrieDataInRegistri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD", true);
            cheie.SetValue("DATA", DateTime.Now);
        }

        private static byte[] ToByteArray(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        private static void ScrieSirDeOctetiInFisier(string pAdresaFisier, byte[] pData)
        {
            using (System.IO.FileStream fisier = System.IO.File.OpenWrite(pAdresaFisier))
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

        public static void GetTextSecurizatDinText(ref string pText)
        {
            //CLegatura.GetTextSecurizatDinText(ref pText, pText.Length);
            incarcaCheiaNumerica();
            StringBuilder textRetur = new StringBuilder();
            for (int i = 0; i < pText.Length; i++)
            {
                textRetur.Append(Char.ConvertFromUtf32(Convert.ToInt32(pText[i]) + _Cheie[i % 8]));
            }
            pText = textRetur.ToString();

            //return textRetur.ToString();
        }

        public static void GetTextDinTextSecurizat(ref string pTextSecurizat)
        {
            //StringBuilder textp = new StringBuilder(pTextSecurizat);

            //CLegatura.GetTextDinTextSecurizat(ref textp, pTextSecurizat.Length);

            //pTextSecurizat = textp.ToString();
            incarcaCheiaNumerica();
            StringBuilder textRetur = new StringBuilder();
            for (int i = 0; i < pTextSecurizat.Length; i++)
            {
                textRetur.Append(Char.ConvertFromUtf32(Convert.ToInt32(pTextSecurizat[i]) - _Cheie[i % 8]));
            }
            pTextSecurizat = textRetur.ToString();
            //return textRetur.ToString();
        }

        public static void DistrugeObiectele()
        {
            if (_MD5Hash != null)
            {
                _MD5Hash.Dispose();
                _MD5Hash = null;
            }
        }

        public static void DistrugeCheia()
        {
            _Cheie = null;
        }

        private static MD5 getMD5()
        {
            if (_MD5Hash == null)
                _MD5Hash = MD5.Create();

            return _MD5Hash;
        }

        public static string GetMd5Hash(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            MD5 md5Hash = getMD5();

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        
        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(string input, string hash)
        {
            MD5 md5Hash = getMD5();

            // Hash the input. 
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        public static bool EstePe64DeBiti()
        {
            return System.Environment.Is64BitOperatingSystem;
        }

        public static string GetSHA1SMSHighway(string pText)
        {
            ASCIIEncoding UE = new ASCIIEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(pText);
            SHA1Managed SHhash = new SHA1Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
    
}
