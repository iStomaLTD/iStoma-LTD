using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Utilizatori;
using ILL.iStomaLab;
using CCL.iStomaLab;
using CDL.iStomaLab;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea statiilor de lucru
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BStatiiDeLucru : BGestiuneCMI, IDisposable, ICheie, IAfisaj, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int IdStatieMaxLength = 150;
            public const int NumeMaxLength = 50;
        }

        #endregion // StructCampuriTabela


        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DStatiiDeLucru.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("IdStatie", true, 1)]
        public string IdStatie
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucru.EnumCampuriTabela.tIdStatie.ToString()); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DStatiiDeLucru.EnumCampuriTabela.tNume.ToString()); }
            set { this.MyDataRowSetItem(DStatiiDeLucru.EnumCampuriTabela.tNume.ToString(), value); }
        }

        [BExport("BlocheazaAccesul", true, 1)]
        public bool BlocheazaAccesul
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DStatiiDeLucru.EnumCampuriTabela.bBlocheazaAccesul.ToString()); }
            set { this.MyDataRowSetItem(DStatiiDeLucru.EnumCampuriTabela.bBlocheazaAccesul.ToString(), value); }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.StatiiDeLucru; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BStatiiDeLucru(int pId)
        : this(pId, null)
        {
        }

        public BStatiiDeLucru(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BStatiiDeLucru>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BStatiiDeLucru(DataRow pMyRow)
        {
            FillObjectWithDataRow<BStatiiDeLucru>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        #region Helper 

        private static string getNumeCalculator()
        {
            return CCL.iStomaLab.Utile.CGestiuneIO.getComputerName();// System.Environment.MachineName;
        }

        private static string _SIdCalculator = string.Empty;
        private static string _SNumeCalculator = string.Empty;
        private static string getIdCalculator()
        {
            if (string.IsNullOrEmpty(_SIdCalculator))
            {
                initMasina();
            }

            return _SIdCalculator;
        }

        private static void initMasina()
        {
            var vsn = getVolumeSerial(Environment.SystemDirectory.Substring(0, 1));
            var result = getHash(vsn + getDiskSize().ToString()).Substring(2, 6);
            result += getHash(result).Substring(5, 2);

            result += "PIDV" + getMotor();
            result += "BISL" + getSofer();

            result.Replace(" ", "");

            _SIdCalculator = result.Trim();

            _SNumeCalculator = getNumeCalculator();
        }

        private static string getMotor()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (System.Management.ManagementClass theClass = new System.Management.ManagementClass("Win32_Processor"))
                {
                    using (System.Management.ManagementObjectCollection theCollectionOfResults = theClass.GetInstances())
                    {
                        foreach (System.Management.ManagementObject currentResult in theCollectionOfResults)
                        {
                            sb.Append(currentResult["ProcessorID"].ToString());
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "NPDF";
            }
        }

        private static string getSofer()
        {
            System.Management.ManagementObjectSearcher searcher = new
                System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (System.Management.ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "NDFB";
        }

        private static string getHash(string s)
        {
            return encodeText(getHashValue(s));
        }

        private static string encodeText(string s)
        {
            string buf = s.Replace(Convert.ToChar(10).ToString(),
                                                            string.Empty);
            string bin = string.Empty;
            for (int i = 0; i < buf.Length; i++)
            {
                bin += intToBin(Convert.ToByte(buf[i]),
                                                 7);
            }

            var result = string.Empty;
            while (bin.Length > 0)
            {
                string w5 = safeSubstring(bin,
                                                                   0,
                                                                   5);
                w5 = w5.PadRight(5,
                                                  '0');

                result += bin5ToB36(w5);
                bin = safeSubstring(bin,
                                                         5,
                                                         0);
            }

            return result;
        }

        private static char bin5ToB36(string w5)
        {
            initAlfabet();

            int d = Convert.ToInt16(w5, 2);
            return _alphabet[d];
        }

        private static void initAlfabet()
        {
            if (_alphabet == null)
            {
                _alphabet = new char[36];

                for (int i = 0; i < 26; i++)
                    _alphabet[i] = Convert.ToChar(i + Convert.ToInt16('A'));
                for (int i = 0; i < 10; i++)
                    _alphabet[i + 26] = Convert.ToChar(i + Convert.ToInt16('0'));
            }
        }

        private static char[] _alphabet = null;

        private static string intToBin(
                int number,
                int numBits)
        {
            var b = new char[numBits];
            var pos = numBits - 1;

            var i = 0;
            while (i < numBits)
            {
                if ((number & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }

            return new string(b);
        }

        private static string safeSubstring(
                string s,
                int start,
                int length)
        {
            if (length == 0)
                length = s.Length - start;
            if (length < 0)
                length = 0;

            if (start > s.Length)
                return string.Empty;
            if (start < 0)
                start = 0;

            if (start + length >
                     s.Length)
                return s.Substring(start);

            return s.Substring(start, length);
        }

        private static string separateText(
                string s,
                int numChars,
                string separator)
        {
            var result = string.Empty;
            var count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if ((count != 0) && (count % numChars == 0))
                {
                    result += separator;
                }

                result += s[i];
                count++;
            }

            return result;
        }

        private static string getHashValue(string s)
        {
            const string def = @"5CACAD0D1C88626D74B30C1ADC2951E8";

            if (string.IsNullOrEmpty(s))
            {
                return def;
            }
            else
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                var textToHash = Encoding.Default.GetBytes(s);
                var h = md5.ComputeHash(textToHash);

                var result = BitConverter.ToString(h);
                result = result.Replace(@"-", string.Empty);
                result = result.ToUpperInvariant();

                return result;
            }
        }

        private static int getVolumeSerial(string drive)
        {
            var voln = new StringBuilder(300);
            int vsn;
            uint mcl, fsf;
            var fsnb = new StringBuilder(300);
            GetVolumeInformation(string.Format(@"{0}:\", drive),
                                                      voln,
                                                      voln.Capacity,
                                                      out vsn,
                                                      out mcl,
                                                      out fsf,
                                                      fsnb,
                                                      fsnb.Capacity);

            return vsn;
        }

        private static ulong getDiskSize()
        {
            ulong freeBytesAvail;
            ulong totalNumOfBytes;
            ulong totalNumOfFreeBytes;

            GetDiskFreeSpaceEx(
                    string.Format(
                    @"{0}:\",
                    Environment.SystemDirectory.Substring(0, 1)),
                                                    out freeBytesAvail,
                                                    out totalNumOfBytes,
                                                    out totalNumOfFreeBytes);

            return totalNumOfBytes;
        }

        [DllImport(@"kernel32.dll")]
        private static extern bool GetDiskFreeSpaceEx(
                string lpDirectoryName,
                out ulong lpFreeBytesAvailable,
                out ulong lpTotalNumberOfBytes,
                out ulong lpTotalNumberOfFreeBytes);

        [DllImport(@"Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetVolumeInformation(
                string rootPathName,
                StringBuilder volumeNameBuffer,
                int volumeNameSize,
                out int volumeSerialNumber,
                out uint maximumComponentLength,
                out uint fileSystemFlags,
                StringBuilder fileSystemNameBuffer,
                int nFileSystemNameSize);

        #endregion

        private static BStatiiDeLucru _SStatie = null;

        public static BStatiiDeLucru GetStatiaCurenta(int pIdUtilizatorConectat, IDbTransaction pTranzactie)
        {
            if (_SStatie == null)
            {
                using (DataSet ds = DStatiiDeLucru.GetStatiaCurenta(getIdCalculator(), pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _SStatie = new BStatiiDeLucru(dr);
                        break;
                    }
                }

                if (_SStatie == null)
                    _SStatie = new BStatiiDeLucru(add(getIdCalculator(), getNumeCalculator(), pIdUtilizatorConectat, pTranzactie));
            }

            return _SStatie;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DStatiiDeLucru
        /// </summary>
        /// <param name="pIdStatie"></param>
        /// <param name="pNume"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static int add(string pIdStatie, string pNume, int pIdUtilizatorConectat, IDbTransaction pTranzactie)
        {
            int id = DStatiiDeLucru.Add(pIdUtilizatorConectat, pIdStatie, pNume, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, string pIdStatie, string pNume)
        {
            bool esteOK = true;

            return esteOK;
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BStatiiDeLucru
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieStatiiDeLucru GetListByParam(IDbTransaction pTranzactie)
        {
            BColectieStatiiDeLucru lstDStatiiDeLucru = new BColectieStatiiDeLucru();
            using (DataSet ds = DStatiiDeLucru.GetListByParam(pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDStatiiDeLucru.Add(new BStatiiDeLucru(dr));
                }
            }
            return lstDStatiiDeLucru;
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
                throw new IdentificareBazaImposibilaException("BStatiiDeLucru");
            using (DataSet ds = DStatiiDeLucru.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BStatiiDeLucru");
            }
        }

        public static BColectieStatiiDeLucru getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieStatiiDeLucru listaRetur = new BColectieStatiiDeLucru();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DStatiiDeLucru.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BStatiiDeLucru(dr));
                    }
                }
            }
            return listaRetur;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

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
                bool succesModificare = DStatiiDeLucru.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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
            return

                  this.IsMyDataRowItemHasChanged(DStatiiDeLucru.EnumCampuriTabela.tNume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DStatiiDeLucru.EnumCampuriTabela.bBlocheazaAccesul.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DStatiiDeLucru.EnumCampuriTabela.tNume.ToString()))
                dictRezultat.Adauga(DStatiiDeLucru.EnumCampuriTabela.tNume.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DStatiiDeLucru.EnumCampuriTabela.bBlocheazaAccesul.ToString()))
                dictRezultat.Adauga(DStatiiDeLucru.EnumCampuriTabela.bBlocheazaAccesul.ToString(), this.BlocheazaAccesul);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BStatiiDeLucru");

            FillObjectWithDataRow<BStatiiDeLucru>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DStatiiDeLucru></DStatiiDeLucru>");

            //Adaugam elementele clasei BStatiiDeLucru
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDSTATIE");
            myXmlElem.InnerText = this.IdStatie;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("BLOCHEAZAACCESUL");
            myXmlElem.InnerText = Convert.ToString(this.BlocheazaAccesul);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
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

        public static int ComparaDupaNume(BStatiiDeLucru xElemLista1, BStatiiDeLucru xElemLista2)
        {
            if (xElemLista1 == null)
            {
                if (xElemLista2 == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (xElemLista2 == null)
                    return 1;
                else
                    return xElemLista1.Nume.CompareTo(xElemLista2.Nume);
            }
        }

        #endregion //Metode de comparatie

    }

}