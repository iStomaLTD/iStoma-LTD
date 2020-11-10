using CCL.DAL;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab
{
    public abstract class BGeneral : IDisposable
    {
        #region Declaratii generale

        private System.Data.DataRow lDataRowCorespunzator;

        private int lNumarZecimaleFloat = 2;

        private string lAliasTabela = "";

        #endregion

        #region Enumerari si Structuri

        public enum EnumActionOnChanges
        {
            ResumeChanges = 0,
            NotResumeChanges = 1
        }

        protected enum EnumColoaneStandard
        {
            dDataCreare,
            xnUtilizatorCreare,
            dDataInchidere,
            xnUtilizatorInchidere,
            tMotivInchidere,
            dDataUltimeiModificari,
            xnUtilizatorulUltimeiModificari,
            tIdentitateCreator,
            tIdentitateUserInchidere,
            tIdentitateUserModificare
        }

        #endregion

        #region Proprietati

        protected System.Data.DataRow MyDataRow
        {
            get { return lDataRowCorespunzator; }
            set
            {
                try
                {
                    //Testam validitatea DataRow-ului
                    CheckMyDataRow(value);
                    //Setam DataRow-ul obiectului
                    lDataRowCorespunzator = value;
                    //Acceptam ansamblul modificarilor pentru a avea un DataRow OK
                    lDataRowCorespunzator.AcceptChanges();
                }
                catch (Exception ex)
                {
                    lDataRowCorespunzator = null;
                    throw new Exception("MyDataRow", ex);
                }
            }
        }

        protected int ArrondiFloat
        {
            get { return this.lNumarZecimaleFloat; }
            set { this.lNumarZecimaleFloat = value; }
        }

        protected string AliasTable
        {
            get { return this.lAliasTabela; }
            set { this.lAliasTabela = value; }
        }

        #endregion

        #region Metode de clasa

        public static Tuple<string, string> VerificaComunicareaCuBazaDeDate()
        {
            string connectionString = CCL.DAL.DGeneral.GetConnectionString();
            bool nuMerge = false;
            string exceptie = string.Empty;
            try
            {
                using (System.Data.SqlClient.SqlConnection conexiune = CCL.DAL.DGeneral.GetConexiuneNoua())
                {
                    //In momentul in care recuperam conexiunea, se fac toate incercarile de conectare si reparare a ei in cazul in care nu este fiabila
                    //conexiune.Open();

                    //Daca nu a mers conexiunea, aceasta va fi null
                    if (conexiune != null)
                    {
                        conexiune.Close();
                        conexiune.Dispose();
                    }
                    else
                        nuMerge = true;
                }
            }
            catch (Exception ex)
            {
                nuMerge = true;
                exceptie = ex.Message;
            }

            if (nuMerge)
            {
                //Avem o problema de conectare
                //Ce facem acum?
                StringBuilder solutiiPosibile = new StringBuilder();
                //Daca nu suntem pe server ii dam utilizatorului cateva indicii
                solutiiPosibile.Append("Din păcate nu am reușit să mă conectez la baza de date :(");
                solutiiPosibile.AppendLine();
                solutiiPosibile.AppendLine();
                solutiiPosibile.Append("Vă rog frumos să mă ajutați...");
                solutiiPosibile.AppendLine();
                solutiiPosibile.AppendLine();

                if (connectionString.ToLower().Equals("secure"))
                {
                    //Serverul este in cloud
                    solutiiPosibile.Append("Îi puteți suna, vă rog, pe colegii mei de la birou, la unul din numerele: 0731.47.86.62, 0724.78.66.20 sau 021.555.10.52 și să le spuneți că am nevoie de ajutorul lor?");
                    solutiiPosibile.AppendLine();
                    solutiiPosibile.AppendLine();
                    solutiiPosibile.Append("Vă mulțumesc frumos!");
                }
                else
                {
                    //Daca suntem pe server incercam sa repornim serviciul
                    if (connectionString.Contains(","))
                    {
                        //Nu suntem pe server (suntem pe statie)
                        solutiiPosibile.Append("1. Este posibil să se fi oprit calculatorul pe care este baza de date. Puteți verifica vă rog? Eventual puteți porni aplicația și pe acel calculator");
                        solutiiPosibile.AppendLine();
                        solutiiPosibile.AppendLine();
                        solutiiPosibile.Append("2. Este posibil să fiți pe altă rețea față de cea pe care este server-ul sau server-ul să nu fie conectat la internet. Puteți verifica vă rog?");
                        solutiiPosibile.AppendLine();
                        solutiiPosibile.AppendLine();
                        solutiiPosibile.Append("3. Este posibil ca unul din colegii mei de la birou să vă ofere mai multe informații. Puteți suna, vă rog, la unul din numerele: 0731.47.86.62, 0724.78.66.20 sau 021.555.10.52?");
                    }
                    else
                    {
                        //Suntem pe server

                        //Incercam sa pornim serviciul sql
                        DGeneral.StartServiciuSQlServer(new System.Data.SqlClient.SqlConnection(connectionString));

                        //Revericam conexiunea
                        nuMerge = false;
                        System.Threading.Thread.Sleep(4000);
                        using (System.Data.SqlClient.SqlConnection conexiune = CCL.DAL.DGeneral.GetConexiuneNoua())
                        {
                            //In momentul in care recuperam conexiunea, se fac toate incercarile de conectare si reparare a ei in cazul in care nu este fiabila
                            //conexiune.Open();

                            //Daca nu a mers conexiunea, aceasta va fi null
                            if (conexiune != null)
                            {
                                conexiune.Close();
                                conexiune.Dispose();
                            }
                            else
                                nuMerge = true;
                        }

                        if (nuMerge)
                        {
                            //Daca suntem pe server si nu am reusit sa repornim serviciul
                            solutiiPosibile.Append("1. Dacă astăzi este prima oară când vedeți acest ecran, puteți închide acest mesaj și să încercați să mai porniți aplicația încă o dată");
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.Append("2. Daca Windows-ul și-a făcut un update este posibil să fi oprit Serverul (mai face din astea câteodată); Îl puteți reporni apăsând tasta Windows din stânga jos, tastând services, identificând în lista de programe SQL Server (SQLExpress), făcând click pe el și apoi din dreapta sus apăsând pe opțiunea Start");
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.Append("3. Dacă nu știți să faceți asta, vă e teamă să o faceți sau ați făcut-o și nu a funcționat, vă rog să-i sunați pe colegii mei de la birou la unul din numerele: 0731.47.86.62, 0724.78.66.20 sau 021.555.10.52 și cu siguranță vă vor ajuta");
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.AppendLine();
                            solutiiPosibile.Append("Vă mulțumesc frumos!");
                        }
                        else
                        {
                            //Daca s-a remediat problema atunci continuam executia
                            return null;
                        }
                    }
                }

                return new Tuple<string, string>(solutiiPosibile.ToString(), "SQL Server offline");
            }
            return null;
        }

        public static void OptimizeazaBDD()
        {
            DGeneral.OptimizeazaBDD();
        }

        public static void DistrugeObiectele()
        {
            Utilizatori.BStatiiDeLucruUtilizatori.DistrugeVariabileleStaticeLocale();
        }

        /// <summary>
        /// Metoda de clasa pentru testarea validitatii unui DataRow
        /// </summary>
        /// <param name="myDataRow"></param>
        protected static void CheckMyDataRow(System.Data.DataRow myDataRow)
        {
            if (myDataRow == null) throw new ArgumentNullException("myDataRow");
            if (myDataRow.Table.Columns.Count <= 0) throw new ArgumentException("myDataRow");
        }

        protected static void FillObjectWithDataRow<T>(System.Data.DataRow pDateleDinBaza, T pObiect) where T : BGeneral
        {
            if (pDateleDinBaza == null) throw new ArgumentNullException("Datele din baza nu sunt corect furnizate");
            if (pObiect == null) throw new ArgumentNullException("Obiectul nu este instantiat");

            pObiect.MyDataRow = pDateleDinBaza;
        }

        #endregion

        #region Metode de instanta

        protected void MarcheazaCaSters(string pNumeProprietateId)
        {
            this.MyDataRowSetItem(pNumeProprietateId, 0);
        }

        /// <summary>
        /// Verificam daca pentru un anumit camp avem DbNull in baza de date
        /// </summary>
        /// <param name="pNumeCamp"></param>
        /// <returns></returns>
        protected bool IsCampDbNull(string pNumeCamp)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return this.MyDataRow[pNumeCamp] == DBNull.Value;
            else
                return this.MyDataRow[string.Concat(lAliasTabela + pNumeCamp)] == DBNull.Value;
        }

        #region MyDataRowGetItem

        /// <summary>
        /// Metoda de instanta pentru recuperarea valorii unui camp din DataRow
        /// </summary>
        /// <param name="nomChamp"></param>
        /// <returns></returns>
        protected string MyDataRowGetItem(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToString(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToString(this.MyDataRow[lAliasTabela + pNumeColoana]);
        }

        protected object MyDataRowGetItemAsObject(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return this.MyDataRow[pNumeColoana];
            else
                return this.MyDataRow[lAliasTabela + pNumeColoana];
        }

        protected EnumRaspuns MyDataRowGetItemAsRaspuns(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (EnumRaspuns)Convert.ToInt32(this.MyDataRow[pNumeColoana]);
                else
                    if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (EnumRaspuns)Convert.ToInt32(this.MyDataRow[lAliasTabela + pNumeColoana]);

            return EnumRaspuns.NuStiu;
        }

        protected EnumRaspuns MyDataRowGetItemAsRaspunsFromBit(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                {
                    if (Convert.ToBoolean(this.MyDataRow[pNumeColoana]))
                        return EnumRaspuns.Da;
                    else
                        return EnumRaspuns.Nu;
                }
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
            {
                if (Convert.ToBoolean(this.MyDataRow[lAliasTabela + pNumeColoana]))
                    return EnumRaspuns.Da;
                else
                    return EnumRaspuns.Nu;
            }

            return EnumRaspuns.NuStiu;
        }

        protected CDefinitiiComune.EnumTipObiect MyDataRowGetItemAsEnumTipProprietar(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (CDefinitiiComune.EnumTipObiect)Convert.ToInt32(this.MyDataRow[pNumeColoana]);
                else
                    if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (CDefinitiiComune.EnumTipObiect)Convert.ToInt32(this.MyDataRow[lAliasTabela + pNumeColoana]);

            return CDefinitiiComune.EnumTipObiect.Nedefinit;
        }

        protected CDefinitiiComune.EnumTipMoneda MyDataRowGetItemAsMoneda(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (CDefinitiiComune.EnumTipMoneda)Convert.ToInt32(this.MyDataRow[pNumeColoana]);
                else
                    if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (CDefinitiiComune.EnumTipMoneda)Convert.ToInt32(this.MyDataRow[lAliasTabela + pNumeColoana]);

            return CDefinitiiComune.EnumTipMoneda.Nedefinit;
        }

        protected int MyDataRowGetItemAsInteger(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToInt32(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToInt32(this.MyDataRow[lAliasTabela + pNumeColoana]);
        }

        protected int MyDataRowGetItemAsIntegerNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }
            return 0;
        }

        protected byte[] MyDataRowGetItemAsByteList(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (byte[])(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return (byte[])(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }

            return null;
        }

        protected int? MyDataRowGetItemAsIntegerNullable(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }
            return null;
        }

        protected int MyDataRowGetItemAsIntegerNull(string pNumeColoana, int pValoareNULL)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return Convert.ToInt32(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }

            return pValoareNULL;
        }

        protected long MyDataRowGetItemAsLong(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToInt64(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToInt64(this.MyDataRow[lAliasTabela + pNumeColoana]);
        }

        protected long MyDataRowGetItemAsLongNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToInt64(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return Convert.ToInt64(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }
            return 0;
        }

        protected short MyDataRowGetItemAsSingle(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToInt16(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToInt16(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
        }

        protected short MyDataRowGetItemAsSingleNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToInt16(this.MyDataRow[pNumeColoana]);
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                return Convert.ToInt16(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            return 0;
        }

        protected DateTime MyDataRowGetItemAsDate(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToDateTime(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToDateTime(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
        }

        protected DateTime MyDataRowGetItemAsDateNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToDateTime(this.MyDataRow[pNumeColoana]);
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                return Convert.ToDateTime(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            return CConstante.DataNula;
        }

        protected bool MyDataRowGetItemAsBoolean(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToBoolean(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToBoolean(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
        }

        protected bool MyDataRowGetItemAsBooleanNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToBoolean(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToBoolean(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }
            return false;
        }

        protected double MyDataRowGetItemAsDouble(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToDouble(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToDouble(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
        }

        protected double MyDataRowGetItemAsDoubleNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToDouble(this.MyDataRow[pNumeColoana]);
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                return Convert.ToDouble(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            return 0;
        }

        protected double? MyDataRowGetItemAsDoubleNullable(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToDouble(this.MyDataRow[pNumeColoana]);
            }
            else
            {
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                    return Convert.ToDouble(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            }
            return null;
        }

        protected CDefinitiiComune.EnumTipMoneda MyDataRowGetItemAsTipMonedaNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return (CDefinitiiComune.EnumTipMoneda)Convert.ToInt32(this.MyDataRow[pNumeColoana]);
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                return (CDefinitiiComune.EnumTipMoneda)Convert.ToInt32(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);

            return CDefinitiiComune.EnumTipMoneda.Nedefinit;
        }



        protected decimal MyDataRowGetItemAsDecimal(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                return Convert.ToDecimal(this.MyDataRow[pNumeColoana]);
            else
                return Convert.ToDecimal(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
        }

        protected decimal MyDataRowGetItemAsDecimalNull(string pNumeColoana)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (this.MyDataRow[pNumeColoana] != DBNull.Value)
                    return Convert.ToDecimal(this.MyDataRow[pNumeColoana]);
            }
            else
                if (this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)] != DBNull.Value)
                return Convert.ToDecimal(this.MyDataRow[string.Concat(lAliasTabela + pNumeColoana)]);
            return 0;
        }

        #endregion

        #region MyDataRowSetItem

        /// <summary>
        /// Metoda de instanta pentru modificarea valorii unui camp din DataRow
        /// </summary>
        /// <param name="nomChamp"></param>
        /// <param name="value"></param>
        protected void MyDataRowSetItem(string pNumeColoana, string pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        private void MyDataRowSetItem(string pNumeColoana, object pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, byte[] pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, int pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, int? pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (pValoare.HasValue)
                    this.MyDataRow[pNumeColoana] = pValoare;
                else
                    this.MyDataRow[pNumeColoana] = DBNull.Value;
            }
            else
            {
                if (pValoare.HasValue)
                    this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
                else
                    this.MyDataRow[lAliasTabela + pNumeColoana] = DBNull.Value;
            }
        }

        protected void MyDataRowSetItem(string pNumeColoana, long pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, double pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, double? pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (pValoare.HasValue)
                    this.MyDataRow[pNumeColoana] = pValoare.Value;
                else
                    this.MyDataRow[pNumeColoana] = DBNull.Value;
            }
            else
            {
                if (pValoare.HasValue)
                    this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare.Value;
                else
                    this.MyDataRow[lAliasTabela + pNumeColoana] = DBNull.Value;
            }
        }

        protected void MyDataRowSetItem(string pNumeColoana, DateTime pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, bool pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, decimal pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, BDefinitiiGenerale.EnumConfirmare pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, BDefinitiiGenerale.EnumJudeteRomania pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, BDefinitiiGenerale.EnumLunileAnului pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumModComunicarePreferat pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumNivelScolorizare pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, EnumRaspuns pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
            {
                if (pValoare == EnumRaspuns.Da)
                    this.MyDataRow[pNumeColoana] = true;
                else
                    if (pValoare == EnumRaspuns.Nu)
                    this.MyDataRow[pNumeColoana] = false;
                else
                    this.MyDataRow[pNumeColoana] = DBNull.Value;
            }
            else
            {
                if (pValoare == EnumRaspuns.Da)
                    this.MyDataRow[lAliasTabela + pNumeColoana] = true;
                else
                    if (pValoare == EnumRaspuns.Nu)
                    this.MyDataRow[lAliasTabela + pNumeColoana] = false;
                else
                    this.MyDataRow[lAliasTabela + pNumeColoana] = DBNull.Value;
            }
        }

        protected void MyDataRowSetItem(string pNumeColoana, BDefinitiiGenerale.EnumTipDurata pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumTipMoneda pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumTipObiect pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, BMultiLingv.EnumLimba pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumSex pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumStare pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumStareCivila pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        protected void MyDataRowSetItem(string pNumeColoana, CDefinitiiComune.EnumTitulatura pValoare)
        {
            if (string.IsNullOrEmpty(lAliasTabela))
                this.MyDataRow[pNumeColoana] = pValoare;
            else
                this.MyDataRow[lAliasTabela + pNumeColoana] = pValoare;
        }

        #endregion

        /// <summary>
        /// Metoda de instanta pentru a testa daca un DataRow a fost modificat fata de starea sa initiala
        /// </summary>
        /// <returns></returns>
        protected bool IsMyDataRowHasChanged()
        {
            CheckMyDataRow(this.lDataRowCorespunzator);
            if (this.lDataRowCorespunzator.RowState == System.Data.DataRowState.Modified)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metoda de instanta pentru a testa daca un camp anume din DataRow a fost modificat
        /// </summary>
        /// <param name="nomItem"></param>
        /// <returns></returns>
        protected bool IsMyDataRowItemHasChanged(string nomItem)
        {
            CheckMyDataRow(this.lDataRowCorespunzator);
            string a = this.lDataRowCorespunzator[lAliasTabela + nomItem, System.Data.DataRowVersion.Original].ToString();
            string b = this.lDataRowCorespunzator[lAliasTabela + nomItem].ToString();
            if (this.lDataRowCorespunzator[lAliasTabela + nomItem, System.Data.DataRowVersion.Original].ToString() != this.lDataRowCorespunzator[lAliasTabela + nomItem].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected int GetMyDataRowItemOldValueAsInt(string pNumeColoana)
        {
            string val = GetMyDataRowItemOldValue(pNumeColoana);
            if (!string.IsNullOrEmpty(val))
                return Convert.ToInt32(val);
            return 0;
        }

        protected bool GetMyDataRowItemOldValueAsBool(string pNumeColoana)
        {
            string val = GetMyDataRowItemOldValue(pNumeColoana);
            if (!string.IsNullOrEmpty(val))
                return Convert.ToBoolean(val);
            return false;
        }

        protected double GetMyDataRowItemOldValueAsDouble(string pNumeColoana)
        {
            string val = GetMyDataRowItemOldValue(pNumeColoana);
            if (!string.IsNullOrEmpty(val))
                return Convert.ToDouble(val);
            return 0;
        }

        protected DateTime GetMyDataRowItemOldValueAsDate(string pNumeColoana)
        {
            string val = GetMyDataRowItemOldValue(pNumeColoana);
            if (!string.IsNullOrEmpty(val))
                return Convert.ToDateTime(val);
            return CConstante.DataNula;
        }

        /// <summary>
        /// Metoda de instanta ce permite recuperarea valorii initiale a unui camp anume din DataRow
        /// </summary>
        /// <param name="nomItem"></param>
        /// <returns></returns>
        protected string GetMyDataRowItemOldValue(string nomItem)
        {
            CheckMyDataRow(this.lDataRowCorespunzator);
            return this.lDataRowCorespunzator[lAliasTabela + nomItem, System.Data.DataRowVersion.Original].ToString();
        }

        /// <summary>
        /// Metoda de instanta ce permite recuperarea unei liste de String (camp = valoare) cu toate campurile modificate din DataRow
        /// </summary>
        /// <param name="ActionToDoAfter">Precizam daca vrem sa reinitializam campurile modificate cu valorile initiale dupa ce am recuperat modificarile</param>
        /// <returns></returns>
        protected string GetMyDataRowChanges(EnumActionOnChanges ActionToDoAfter)
        {
            List<string> lstchampout = new List<string>();
            return this.GetMyDataRowChanges(ActionToDoAfter, lstchampout);
        }

        /// <summary>
        /// Metoda de instanta ce permite recuperarea unei liste de String (camp = valoare) cu toate campurile modificate din DataRow
        /// </summary>
        /// <param name="ActionToDoAfter">Precizam daca vrem sa reinitializam campurile modificate cu valorile initiale dupa ce am recuperat modificarile</param>
        /// <param name="listChampOut">Lista de campuri care nu ne intereseaza</param>
        /// <returns></returns>
        protected string GetMyDataRowChanges(EnumActionOnChanges ActionToDoAfter, List<string> listChampOut)
        {
            if (this.IsMyDataRowHasChanged())
            {
                //on construit la chaine de modification
                System.Text.StringBuilder strSqlModification = new System.Text.StringBuilder();
                System.Data.DataColumnCollection colonnes;

                //Recuperam coloanete prin clonarea tabelei obiectului. 
                colonnes = this.lDataRowCorespunzator.Table.Clone().Columns;

                //Eliminam coloanele care nu ne intereseaza
                foreach (String champToRemove in listChampOut)
                {
                    colonnes.Remove(lAliasTabela + champToRemove);
                }

                foreach (System.Data.DataColumn dtCol in colonnes)
                {
                    if (string.Compare(this.lDataRowCorespunzator[dtCol.ColumnName, System.Data.DataRowVersion.Original].ToString(), this.lDataRowCorespunzator[dtCol.ColumnName].ToString(), false) != 0)
                    {
                        if (string.IsNullOrEmpty(lAliasTabela))
                        {
                            strSqlModification.Append(dtCol.ColumnName);
                        }
                        else
                        {
                            strSqlModification.Append(dtCol.ColumnName.Substring(lAliasTabela.Length));
                        }

                        strSqlModification.Append(" = ");
                        string sTypeDate = dtCol.DataType.Name;

                        if (sTypeDate == "Int32" || sTypeDate == "Int16")
                        {
                            if (this.lDataRowCorespunzator.IsNull(dtCol.ColumnName))
                            {
                                strSqlModification.Append("NULL");
                            }
                            else
                            {
                                strSqlModification.Append(this.lDataRowCorespunzator[dtCol.ColumnName].ToString());
                            }
                        }
                        else
                        {
                            if (sTypeDate == "Double" || sTypeDate == "Single")
                            {
                                strSqlModification.Append(Double.Parse(this.lDataRowCorespunzator[dtCol.ColumnName].ToString()));
                            }
                            else
                            {
                                if (sTypeDate == "Decimal")
                                {
                                    strSqlModification.Append(Decimal.Parse(this.lDataRowCorespunzator[dtCol.ColumnName].ToString()));
                                }
                                else
                                {
                                    if (sTypeDate == "String")
                                    {
                                        strSqlModification.Append(this.lDataRowCorespunzator[dtCol.ColumnName].ToString());

                                    }
                                    else
                                    {
                                        if (sTypeDate == "DateTime")
                                        {
                                            if (this.lDataRowCorespunzator.IsNull(dtCol.ColumnName))
                                            {
                                                strSqlModification.Append("NULL");
                                            }
                                            else
                                            {
                                                strSqlModification.Append(DateTime.Parse(this.lDataRowCorespunzator[dtCol.ColumnName].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (sTypeDate == "Boolean")
                                            {
                                                strSqlModification.Append(this.lDataRowCorespunzator[dtCol.ColumnName].ToString());
                                            }
                                            else
                                            {
                                                strSqlModification.Append(this.lDataRowCorespunzator[dtCol.ColumnName].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        strSqlModification.Append(", ");
                    }
                }
                //stergem ultima virgula
                if (strSqlModification.Length > 2) strSqlModification.Remove(strSqlModification.Length - 2, 2);

                //daca asa este specificat in parametru, acceptam modificarile
                if (ActionToDoAfter == EnumActionOnChanges.ResumeChanges)
                {
                    this.ResumeMyDataRowChanges();
                }
                return strSqlModification.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Metoda de instanta pentru a valida modificarile din DataRow
        /// </summary>
        protected void ResumeMyDataRowChanges()
        {
            CheckMyDataRow(this.lDataRowCorespunzator);
            this.lDataRowCorespunzator.AcceptChanges();
        }

        /// <summary>
        /// Metoda ce transforma obiectul in flux XML (Trebuie sa fie redefinita pentru fiecare obiect)
        /// </summary>
        /// <returns></returns>
        public string ObjectToXMLString()
        {
            return String.Empty;
        }

        /// <summary>
        /// Metoda ce permite actualizarea informatiilor unui obiect.
        /// Se face Update doar pe coloanele modificate
        /// </summary>
        /// <param name="pIdUtilizatorModificare">IdEnum-ul utilizatorului ce realizeaza moodificarea</param>
        /// <param name="pNumeTabela">Numele tabelei in care se face modificarea</param>
        /// <param name="pModificari">dictionar ce contine:
        ///                                 - Nume coloana modificata
        ///                                 - Noua valoare</param>
        /// <param name="pId">dictionar ce contine:
        ///                                 - Nume coloana de identificare a unei inregistrari
        ///                                 - Valoarea ce corespunde obiectului pentru care facem modificarea in baza</param>
        /// <param name="pTranzactie">Tranzactia utilizata</param>
        /// <returns>True daca s-a efectuat modificarea, False in caz contrar</returns>
        protected bool UpdateAll(int pIdUtilizatorModificare,
                                 string pNumeTabela,
                                 BColectieCorespondenteColoaneValori pModificari,
                                 BColectieCorespondenteColoaneValori pId,
                                 IDbTransaction pTranzactie)
        {
            if (string.IsNullOrEmpty(pNumeTabela))
                throw new ArgumentNullException("Nu este precizata nicio tabela!");

            if (pModificari.Count == 0 || pId.Count == 0)
                return false;

            return CCL.DAL.DGeneral.UpdateAllByIds(pIdUtilizatorModificare, pNumeTabela, pModificari, pId, pTranzactie);
        }

        protected bool UpdateAll(int pIdUtilizatorModificare,
                                 string pNumeTabela,
                                 BColectieCorespondenteColoaneValori pModificari,
                                 string pNumeColoanaId,
                                 int pId, IDbTransaction pTranzactie)
        {
            return UpdateAll(pIdUtilizatorModificare, pNumeTabela, pModificari, pNumeColoanaId, pId, CConstante.DataNula, pTranzactie);
        }

        protected bool UpdateAll(int pIdUtilizatorModificare,
                                 string pNumeTabela,
                                 BColectieCorespondenteColoaneValori pModificari,
                                 string pNumeColoanaId,
                                 int pId,
                                 DateTime pDataUltimeiModificari, IDbTransaction pTranzactie)
        {
            if (string.IsNullOrEmpty(pNumeTabela))
                throw new ArgumentNullException("Nu este precizata nicio tabela!");

            if (pModificari.Count == 0 || pId <= 0)
                return false;

            return DGeneral.UpdateAllById(pIdUtilizatorModificare, pNumeTabela, pModificari, pNumeColoanaId, pId, pDataUltimeiModificari, pTranzactie);
        }

        public bool SetProperty(string pNumeColoana, object pValoare)
        {
            this.MyDataRowSetItem(pNumeColoana, pValoare);

            return this.UpdateAll(null);
        }

        public abstract bool UpdateAll(IDbTransaction pTranzactie);

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.lDataRowCorespunzator = null;
        }

        #endregion

    }
}
