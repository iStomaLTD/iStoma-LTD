using System;
using System.Collections.Generic;
using System.Data;
using CCL.iStomaLab.Utile;
using System.ServiceProcess;
using System.Diagnostics;

namespace CCL.DAL
{

    /// <summary>
    /// Clasa ce ofera functii de acces la BDD
    /// </summary>
    public class CCerereSQL
    {
        private static bool suntConectatPeAlternativ = false;

        internal static string getConnectionString()
        {
            return CInterfataSQLServer.GetConnectionString();
        }

        public static IDbTransaction GetTransactionOnConnection()
        {
            return GetTransactionOnConnection(String.Empty);
        }

        internal static void startSQLService(IDbConnection pConexiune)
        {
            ServiceController[] controllers = ServiceController.GetServices();
            foreach (var item in controllers)
            {
                if (item.ServiceName.Contains("MSSQL$") && item.Status != ServiceControllerStatus.Running)
                {
                    using (var sc = new System.ServiceProcess.ServiceController(item.ServiceName, ((System.Data.SqlClient.SqlConnection)(pConexiune)).WorkstationId))
                    {
                        if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            using (var process = new Process())
                            {
                                process.StartInfo.FileName = "net";
                                process.StartInfo.Arguments = "start " + sc.ServiceName;
                                process.StartInfo.Verb = "runas";//run as administrator
                                process.Start();
                                process.WaitForExit();
                            }

                            //sc.Start();
                            //sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            //System.Threading.Thread.Sleep(5000);
                        }
                    }
                    //item.Start();
                    //item.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(20));
                    //break;
                }
            }
            controllers = null;
        }

        //private static void startSQLService(IDbConnection pConexiune)
        //{
        //    ServiceController[] controllers = ServiceController.GetServices();
        //    foreach (var item in controllers)
        //    {
        //        if (item.ServiceName.Contains("MSSQL$") && item.Status != ServiceControllerStatus.Running)
        //        {
        //            var sc = new System.ServiceProcess.ServiceController(item.ServiceName, ((System.Data.SqlClient.SqlConnection)(pConexiune)).WorkstationId);
        //            sc.Start();
        //            sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
        //            System.Threading.Thread.Sleep(5000);
        //            //item.Start();
        //            //item.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(20));
        //            //break;
        //        }
        //    }
        //    controllers = null;
        //}

        /// <summary>
        /// Metoda ce permite obtinerea unei conexiuni deschise cu o transactie 
        /// </summary>
        /// <param name="sConnexionString"></param>
        /// <returns>Conexiunea cu tranzactia in parametru</returns>
        public static IDbTransaction GetTransactionOnConnection(string sConnexionString)
        {
            string sqlConnect;
            if (!String.IsNullOrEmpty(sConnexionString))
            {
                sqlConnect = sConnexionString;
            }
            else
            {
                if (suntConectatPeAlternativ)
                    sqlConnect = CInterfataSQLServer.GetConnectionStringAlternativ();
                else
                    sqlConnect = CInterfataSQLServer.GetConnectionString();
            }

            IDbConnection cn = CInterfataSQLServer.getNewDataConnection(sqlConnect);
            try
            {
                cn.Open();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                if (string.IsNullOrEmpty(sConnexionString))
                {
                    cn.Dispose();
                    cn = null;

                    //Daca nu merge pe normal incercam pe alternativ
                    if (suntConectatPeAlternativ)
                        sqlConnect = CInterfataSQLServer.GetConnectionString();
                    else
                        sqlConnect = CInterfataSQLServer.GetConnectionStringAlternativ();

                    cn = CInterfataSQLServer.getNewDataConnection(sqlConnect);

                    try
                    {
                        cn.Open();

                        //Pentru a sti care merge
                        suntConectatPeAlternativ = !suntConectatPeAlternativ;
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        if (!suntConectatPeAlternativ)
                        {
                            startSQLService(cn);
                            cn.Open();
                        }
                    }
                }
                else
                {
                    startSQLService(cn);
                    cn.Open();
                }
            }

            try
            {
                IDbTransaction Transac;
                Transac = cn.BeginTransaction();
                return Transac;
            }
            catch (Exception ex)
            {
                cn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// Obtinem o conexiune deschisa cu o tranzactie
        /// </summary>
        /// <param name="transac"></param>
        /// <param name="DoCommit"></param>
        public static void CloseTransactionOnConnection(System.Data.SqlClient.SqlTransaction transac, bool DoCommit)
        {
            System.Data.SqlClient.SqlConnection cn = transac.Connection;
            if (cn != null)
            {
                if (DoCommit)
                {
                    transac.Commit();
                }
                else
                {
                    transac.Rollback();
                }
                transac.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public static void CloseTransactionOnConnection(IDbTransaction transac, bool DoCommit)
        {
            CloseTransactionOnConnection((System.Data.SqlClient.SqlTransaction)transac, DoCommit);
        }

        internal static System.Data.SqlClient.SqlConnection getConexiuneNoua()
        {
            System.Data.SqlClient.SqlConnection conexiune = null;

            if (suntConectatPeAlternativ)
                conexiune = new System.Data.SqlClient.SqlConnection(CInterfataSQLServer.GetConnectionStringAlternativ());
            else
                conexiune = new System.Data.SqlClient.SqlConnection(CInterfataSQLServer.GetConnectionString());

            try
            {
                conexiune.Open();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                conexiune.Dispose();
                conexiune = null;

                if (!suntConectatPeAlternativ)
                    conexiune = new System.Data.SqlClient.SqlConnection(CInterfataSQLServer.GetConnectionStringAlternativ());
                else
                    conexiune = new System.Data.SqlClient.SqlConnection(CInterfataSQLServer.GetConnectionString());

                try
                {
                    conexiune.Open();
                    suntConectatPeAlternativ = !suntConectatPeAlternativ;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                }
            }

            return conexiune;
        }

        /// <summary>
        /// Executa o procedura stocata de tip INSERT, UPDATE, sau DELETE si returneaza numarul de linii afectate de aceasta
        /// </summary>
        /// <param name="pComanda">Numele procedurii stocate</param>
        /// <param name="pListaParametri">Parametrii pe care ii transmitem procedurii stocate</param>
        /// <param name="pTranzactie"></param>
        /// <returns>Numarul de linii afectate</returns>
        public static int ExecuteByStoredProc(string p_NumeProcedura, List<IDataParameter> p_ListaParametri, IDbTransaction p_Tranzactie)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();

            try
            {
                //Configuram comanda (SqlCommand)
                cmdSqlCommand.CommandType = CommandType.StoredProcedure;      //Fixam tipul comenzii la StoredProcedure
                cmdSqlCommand.CommandText = p_NumeProcedura;                 //Numele procedurii stocate

                //Detaliem conexiunea la baza de date

                //Atasam conexiunea comenzii SQL
                if (p_Tranzactie == null)
                    cmdSqlCommand.Connection = getConexiuneNoua();
                else
                {
                    //Atasam conexiunea tranzactiei, si tranzactia, comenzii SQL
                    cmdSqlCommand.Connection = p_Tranzactie.Connection;
                    cmdSqlCommand.Transaction = (System.Data.SqlClient.SqlTransaction)(p_Tranzactie);
                }

                //Stergem parametrii comenzii (SqlCommand)
                cmdSqlCommand.Parameters.Clear();

                //Adaugam parametrii trimisi pentru a-i adauga comenzii (SqlCommand)
                if (p_ListaParametri != null)
                {
                    foreach (IDataParameter sqlParm in p_ListaParametri)
                    {
                        cmdSqlCommand.Parameters.Add(sqlParm);
                    }
                }

                //Daca exista tranzactie, inseamna ca o conexiune a fost deschisa
                if (p_Tranzactie == null)
                {
                    if (cmdSqlCommand.Connection.State != ConnectionState.Open)
                        cmdSqlCommand.Connection.Open();
                }

                //Executa procedura stocata, returnand numarul de linii afectate
                //A se utiliza pentru INSERT, UPDATE, DELETE
                return cmdSqlCommand.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                if (cmdSqlCommand.Connection.State == ConnectionState.Open)
                { cmdSqlCommand.Connection.Close(); }
                throw exc;
            }
            finally
            {
                cmdSqlCommand = null;
            }
        }

        public static int ExecuteByComandaDirecta(string pComanda, BColectieParametriSQL pListaParametri, IDbTransaction pTranzactie)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();

            try
            {
                //Configuram comanda (SqlCommand)
                cmdSqlCommand.CommandType = CommandType.Text;                //Fixam tipul comenzii la text
                cmdSqlCommand.CommandText = pComanda;                 //Numele procedurii stocate

                //Detaliem conexiunea la baza de date

                //Atasam conexiunea comenzii SQL
                if (pTranzactie == null)
                    cmdSqlCommand.Connection = getConexiuneNoua();
                else
                {
                    //Atasam conexiunea tranzactiei, si tranzactia, comenzii SQL
                    cmdSqlCommand.Connection = pTranzactie.Connection;
                    cmdSqlCommand.Transaction = (System.Data.SqlClient.SqlTransaction)(pTranzactie);
                }

                //Stergem parametrii comenzii (SqlCommand)
                cmdSqlCommand.Parameters.Clear();

                //Adaugam parametrii trimisi pentru a-i adauga comenzii (SqlCommand)
                if (pListaParametri != null)
                    pListaParametri.AdaugaParametriiLaComanda(cmdSqlCommand);

                //Daca exista tranzactie, inseamna ca o conexiune a fost deschisa
                if (pTranzactie == null)
                {
                    if (cmdSqlCommand.Connection.State != ConnectionState.Open)
                        cmdSqlCommand.Connection.Open();
                }

                //Executa procedura stocata, returnand numarul de linii afectate
                //A se utiliza pentru INSERT, UPDATE, DELETE
                return cmdSqlCommand.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                if (cmdSqlCommand.Connection.State == ConnectionState.Open)
                { cmdSqlCommand.Connection.Close(); }
                throw exc;
            }
            finally
            {
                cmdSqlCommand = null;
            }
        }

        public static DataSet GetDataSetByStoredProc(string sNumeProcedura, List<IDataParameter> lstParametri, IDbTransaction xTranzactieSQL)
        {
            return GetDataSetByStoredProc(sNumeProcedura, lstParametri, xTranzactieSQL, string.Empty);
        }

        /// <summary>
        /// Executa o PS de selectie si returneaza intr-un DataSet inregistrarile ce corespund acestei executii
        /// </summary>
        /// <param name="sNumeProcedura">numele procedurii stocate pe care dorim sa o executam</param>
        /// <param name="lstParametri">lista de parametri pasati PS</param>
        /// <param name="xTranzactieSQL">Tranzactia in cadrul careia executam PS</param>
        /// <param name="sConnexionString">poate fi utilizat doar daca nu transmitem tranzactie in parametru deoarece acest connection string este atasat noii tranzactii</param>
        /// <returns>Un DataSet ce contine rezultatul executiei procedurii stocate</returns>
        public static DataSet GetDataSetByStoredProc(string sNumeProcedura, List<IDataParameter> lstParametri, IDbTransaction xTranzactieSQL, string sConnexionString)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();
            IDbDataAdapter adpSqlDataAdapter = CInterfataSQLServer.getNewDataAdaptater();
            DataSet dsDataSet = new DataSet();

            try
            {
                //Configuram comanda
                using (cmdSqlCommand)
                {
                    cmdSqlCommand.CommandType = CommandType.StoredProcedure;     //precizam ca executam o procedura stocata
                    cmdSqlCommand.CommandText = sNumeProcedura;               //numele procedurii stocate

                    //Conexiunea la BDD pe care o vom utiliza
                    if (xTranzactieSQL == null)
                    {
                        IDbTransaction myTrans = GetTransactionOnConnection(sConnexionString);
                        cmdSqlCommand.Connection = myTrans.Connection;
                        cmdSqlCommand.Transaction = myTrans;
                    }
                    else
                    {   //Atasam conexiunea si tranzactia comenzii
                        cmdSqlCommand.Connection = xTranzactieSQL.Connection;
                        cmdSqlCommand.Transaction = xTranzactieSQL;
                    }

                    //Stergem parametrii precedenti ai comenzii
                    if (cmdSqlCommand.Parameters != null)
                        cmdSqlCommand.Parameters.Clear();

                    //Adaugam noii parametri la comanda
                    if (lstParametri != null)
                    {
                        foreach (IDataParameter sqlParam in lstParametri)
                        {
                            cmdSqlCommand.Parameters.Add(sqlParam);
                        }
                    }
                }

                //Configuram un SqlDataAdapter pentru a folosi SqlCommand si a incarca DataSet-ul
                adpSqlDataAdapter.SelectCommand = cmdSqlCommand;

                try
                {
                    adpSqlDataAdapter.Fill(dsDataSet);
                }
                catch (Exception)
                {
                    //in caz de eroare mai incercam o data
                    adpSqlDataAdapter.Fill(dsDataSet);
                }

                //Daca nu am pasat o tranzactie atunci inchidem si facem comit tranzactiei create si utilizate
                if (xTranzactieSQL == null)
                {
                    CloseTransactionOnConnection(cmdSqlCommand.Transaction, true);
                    cmdSqlCommand.Connection.Close();
                    cmdSqlCommand.Connection.Dispose();
                }

                return dsDataSet;
            }
            catch (Exception ex)
            {
                if (cmdSqlCommand.Connection != null && cmdSqlCommand.Connection.State == ConnectionState.Open)
                {
                    //daca nu am transmis tranzactie
                    if (xTranzactieSQL == null)
                    {
                        //Daca exista o tranzactie creata in interiorul acestei metode
                        if (cmdSqlCommand.Transaction != null)
                            CloseTransactionOnConnection(cmdSqlCommand.Transaction, false);
                    }
                    cmdSqlCommand.Connection.Close();
                    cmdSqlCommand.Connection.Dispose();
                }
                throw ex;
            }
            finally
            {
                cmdSqlCommand.Dispose();
                cmdSqlCommand = null;
                adpSqlDataAdapter = null;
                dsDataSet = null;
            }
        }

        public static DataSet GetDataSetByComandaDirecta(string sComandaDirecta, BColectieParametriSQL pListaParametri, IDbTransaction pTranzactieSQL)
        {
            return GetDataSetByComandaDirecta(sComandaDirecta, pListaParametri, pTranzactieSQL, string.Empty);
        }

        public static DataSet GetDataSetByComandaDirecta(string sComandaDirecta, BColectieParametriSQL pListaParametri, IDbTransaction pTranzactieSQL, string pConnexionString)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();
            IDbDataAdapter adpSqlDataAdapter = CInterfataSQLServer.getNewDataAdaptater();
            DataSet dsDataSet = new DataSet();

            try
            {
                //Configuram comanda
                using (cmdSqlCommand)
                {
                    cmdSqlCommand.CommandType = CommandType.Text;     //precizam ca executam o comanda directa
                    cmdSqlCommand.CommandText = sComandaDirecta;      //textul comenzii directe

                    //Conexiunea la BDD pe care o vom utiliza
                    if (pTranzactieSQL == null)
                    {
                        IDbTransaction myTrans = GetTransactionOnConnection(pConnexionString);
                        cmdSqlCommand.Connection = myTrans.Connection;
                        cmdSqlCommand.Transaction = myTrans;
                    }
                    else
                    {   //Atasam conexiunea si tranzactia comenzii
                        cmdSqlCommand.Connection = pTranzactieSQL.Connection;
                        cmdSqlCommand.Transaction = pTranzactieSQL;
                    }

                    //Adaugam noii parametri la comanda
                    if (pListaParametri != null)
                        pListaParametri.AdaugaParametriiLaComanda(cmdSqlCommand);
                }

                //Configuram un SqlDataAdapter pentru a folosi SqlCommand si a incarca DataSet-ul
                adpSqlDataAdapter.SelectCommand = cmdSqlCommand;
                adpSqlDataAdapter.Fill(dsDataSet);

                //Daca nu am pasat o tranzactie atunci inchidem si facem comit tranzactiei create si utilizate
                if (pTranzactieSQL == null)
                {
                    CloseTransactionOnConnection(cmdSqlCommand.Transaction, true);
                    cmdSqlCommand.Connection.Close();
                    cmdSqlCommand.Connection.Dispose();
                }

                return dsDataSet;
            }
            catch (Exception ex)
            {
                if (cmdSqlCommand.Connection != null && cmdSqlCommand.Connection.State == ConnectionState.Open)
                {
                    //daca nu am transmis tranzactie
                    if (pTranzactieSQL == null)
                    {
                        //Daca exista o tranzactie creata in interiorul acestei metode
                        if (cmdSqlCommand.Transaction != null)
                            CloseTransactionOnConnection(cmdSqlCommand.Transaction, false);
                    }
                    cmdSqlCommand.Connection.Close();
                    cmdSqlCommand.Connection.Dispose();
                }
                throw ex;
            }
            finally
            {
                cmdSqlCommand.Dispose();
                cmdSqlCommand = null;
                adpSqlDataAdapter = null;
                dsDataSet = null;
            }
        }

        /// <summary>
        /// Executam o procedura stocata si recuperam o valoare (numarul de inregistrari modificate sau id-ul inregistrarii adaugate)
        /// </summary>
        /// <param name="pNumePS">Numele procedurii stocate de executat</param>
        /// <param name="pListaParametri">Lista de parametri</param>
        /// <param name="pTranzactie">Tranzactia folosita</param>
        /// <returns>un DataSet ce contine rezultatul apelului procedurii stocate</returns>
        public static object GetScalarByStoredProc(string pNumePS, List<IDataParameter> pListaParametri, IDbTransaction pTranzactie)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();
            try
            {
                //Configure l'objet SqlCommand
                cmdSqlCommand.CommandType = CommandType.StoredProcedure;      //Tipul comenzii = PS
                cmdSqlCommand.CommandText = pNumePS;                          //Numele PS

                //Specificam conexiunea la BDD
                if (pTranzactie == null)
                {
                    //Atasam conexiunea la comanda SQL
                    cmdSqlCommand.Connection = getConexiuneNoua();
                }
                else
                {
                    //Atasam conexiunea tranzactiei si tranzactia la comanda SQL
                    cmdSqlCommand.Connection = pTranzactie.Connection;
                    cmdSqlCommand.Transaction = pTranzactie;
                }

                //Stergem lista de parametri existenti
                cmdSqlCommand.Parameters.Clear();

                //Adaugam lista de parametri transmiri in parametru
                if (pListaParametri != null)
                {

                    foreach (IDataParameter sqlParam in pListaParametri)
                    {
                        cmdSqlCommand.Parameters.Add(sqlParam);
                    }
                }

                //Daca avem o tranzactie inseamna ca o conexiune a fost deschisa
                if (pTranzactie == null)
                {
                    if (cmdSqlCommand.Connection.State != ConnectionState.Open)
                        cmdSqlCommand.Connection.Open();
                }

                //Obiectul de returnat 
                Object returnValue = cmdSqlCommand.ExecuteScalar();

                //In cazul in care nu a fost transmisa o tranzactie, inchidem conexiunea
                if (pTranzactie == null)
                {
                    cmdSqlCommand.Connection.Close();
                }

                return returnValue;

            }
            catch (Exception exc)
            {
                if (cmdSqlCommand.Connection.State == ConnectionState.Open)
                {
                    cmdSqlCommand.Connection.Close();
                }
                throw exc;
            }
            finally
            {
                cmdSqlCommand.Dispose();
                cmdSqlCommand = null;
            }
        }

        public static void restaureazaCopiaDeRezerva(System.IO.FileInfo pCopieDeRezerva)
        {
            if (pCopieDeRezerva == null) return;

            using (System.Data.SqlClient.SqlConnection conexiuneBDD = getConexiuneNoua())
            {
                string numeBDD = conexiuneBDD.Database;
                conexiuneBDD.ConnectionString = conexiuneBDD.ConnectionString.Replace(numeBDD, "master");
                if (conexiuneBDD.State != ConnectionState.Open)
                    conexiuneBDD.Open();

                //Execute SQL---------------
                System.Data.SqlClient.SqlCommand command;
                command = new System.Data.SqlClient.SqlCommand("use master", conexiuneBDD);
                command.ExecuteNonQuery();

                command = new System.Data.SqlClient.SqlCommand(string.Format("restore database {0} from disk = '{1}'", numeBDD, pCopieDeRezerva.FullName), conexiuneBDD);
                command.ExecuteNonQuery();

                conexiuneBDD.Close();
            }
        }

        public static void creazaCopieDeRezerva(bool pPastreazaUltimaCopie)
        {
            string numeFolder = CGestiuneIO.GetValoareDupaTipCheie(CGestiuneIO.EnumTipCheie.AdresaBackupBDD);

            if (!string.IsNullOrEmpty(numeFolder))
            {
                using (System.Data.SqlClient.SqlConnection conexiuneBDD = getConexiuneNoua())
                {
                    string numeBDD = conexiuneBDD.Database;
                    string numeCopie = string.Concat(numeBDD, DateTime.Now.ToString("ddMMyyyyHHmm"), ".bak");
                    string numeSalvare = System.IO.Path.Combine(numeFolder, numeCopie);

                    if (conexiuneBDD.State != ConnectionState.Open)
                        conexiuneBDD.Open();

                    if (System.IO.File.Exists(numeBDD))
                        System.IO.File.Delete(numeBDD);

                    //Execute SQL---------------
                    System.Data.SqlClient.SqlCommand command;
                    command = new System.Data.SqlClient.SqlCommand(string.Format("backup database {0} to disk ='{1}'", numeBDD, numeSalvare), conexiuneBDD);
                    command.CommandTimeout = 100;
                    command.ExecuteNonQuery();

                    conexiuneBDD.Close();

                    if (pPastreazaUltimaCopie)
                    {
                        //stergem celelalte copii de rezerva
                        if (System.IO.Directory.Exists(numeFolder))
                        {
                            string[] copiiRezerva = System.IO.Directory.GetFiles(numeFolder);
                            System.IO.FileInfo fisierBackup = null;
                            foreach (string fisier in copiiRezerva)
                            {
                                fisierBackup = new System.IO.FileInfo(fisier);
                                if (!fisierBackup.Name.Equals(numeCopie))
                                    System.IO.File.Delete(fisier);
                            }
                            fisierBackup = null;
                        }
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string pComandaSQL, List<IDataParameter> pListaParametri, IDbTransaction pTranzactie)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();
            try
            {
                //Configuram comanda
                cmdSqlCommand.CommandType = CommandType.Text;      //Tipul comenzii = text
                cmdSqlCommand.CommandText = pComandaSQL;           //Comanda SQL

                //Specificam conexiunea la BDD
                if (pTranzactie == null)
                {
                    //Atasam conexiunea la comanda SQL
                    cmdSqlCommand.Connection = getConexiuneNoua();
                }
                else
                {
                    //Atasam conexiunea tranzactiei si tranzactia la comanda SQL
                    cmdSqlCommand.Connection = pTranzactie.Connection;
                    cmdSqlCommand.Transaction = pTranzactie;
                }

                //Stergem lista de parametri existenti
                cmdSqlCommand.Parameters.Clear();

                //Adaugam lista de parametri transmiri in parametru
                if (pListaParametri != null)
                {

                    foreach (IDataParameter sqlParam in pListaParametri)
                    {
                        cmdSqlCommand.Parameters.Add(sqlParam);
                    }
                }

                //Daca avem o tranzactie inseamna ca o conexiune a fost deschisa
                if (pTranzactie == null)
                {
                    if (cmdSqlCommand.Connection.State != ConnectionState.Open)
                        cmdSqlCommand.Connection.Open();
                }

                //Obiectul de returnat 
                int returnValue = cmdSqlCommand.ExecuteNonQuery();

                //In cazul in care nu a fost transmisa o tranzactie, inchidem conexiunea
                if (pTranzactie == null)
                    cmdSqlCommand.Connection.Close();

                return returnValue;
            }
            catch (Exception exc)
            {
                if (cmdSqlCommand.Connection.State == ConnectionState.Open)
                {
                    cmdSqlCommand.Connection.Close();
                }
                throw exc;
            }
            finally
            {
                cmdSqlCommand.Dispose();
                cmdSqlCommand = null;
            }
        }

        public static object GetScalarByComandaDirecta(string pComandaSQL, List<IDataParameter> pListaParametri, IDbTransaction pTranzactie)
        {
            IDbCommand cmdSqlCommand = CInterfataSQLServer.getNewDataCommand();
            try
            {
                //Configure l'objet SqlCommand
                cmdSqlCommand.CommandType = CommandType.Text;      //Tipul comenzii = text
                cmdSqlCommand.CommandText = pComandaSQL;           //Comanda SQL

                //Specificam conexiunea la BDD
                if (pTranzactie == null)
                {
                    //Atasam conexiunea la comanda SQL
                    cmdSqlCommand.Connection = getConexiuneNoua();   //ajunge aici?
                }
                else
                {
                    //Atasam conexiunea tranzactiei si tranzactia la comanda SQL
                    cmdSqlCommand.Connection = pTranzactie.Connection;
                    cmdSqlCommand.Transaction = pTranzactie;
                }

                //Stergem lista de parametri existenti
                cmdSqlCommand.Parameters.Clear();

                //Adaugam lista de parametri transmiri in parametru
                if (pListaParametri != null)
                {

                    foreach (IDataParameter sqlParam in pListaParametri)
                    {
                        cmdSqlCommand.Parameters.Add(sqlParam);
                    }
                }

                //Daca avem o tranzactie inseamna ca o conexiune a fost deschisa
                if (pTranzactie == null)
                {
                    if (cmdSqlCommand.Connection.State != ConnectionState.Open)
                        cmdSqlCommand.Connection.Open();
                }

                //Obiectul de returnat 
                Object returnValue = cmdSqlCommand.ExecuteScalar();    

                //In cazul in care nu a fost transmisa o tranzactie, inchidem conexiunea
                if (pTranzactie == null)
                    cmdSqlCommand.Connection.Close();

                return returnValue;
            }
            catch (Exception exc)
            {
                if (cmdSqlCommand.Connection.State == ConnectionState.Open)
                {
                    cmdSqlCommand.Connection.Close();
                }
                throw exc;
            }
            finally
            {
                cmdSqlCommand.Dispose();
                cmdSqlCommand = null;
            }
        }

    }
}
