using System;
using CCL.iStomaLab.Utile;
using System.Data;

namespace CCL.DAL
{
    public class CInterfataSQLServer
    {

        public static IDataParameter getParametruEmpty(string pNumeColoana)
        {
            return new System.Data.SqlClient.SqlParameter(pNumeColoana, DBNull.Value);
        }

        private static string connexionString = null;
        private static string connexionStringAlternativ = null;

        /// <summary>
        /// Recuperam connexion string din fisierul de configurare
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(connexionString))
                connexionString = CGestiuneIO.getCheieConfigurare("SQLConnection");

            if (connexionString.Equals("SECURE"))
            {
                connexionString = BDD.abc.get();
            }

            //if (string.IsNullOrEmpty(connexionString))
            //    connexionString = CGestiuneIO.GetSQLConnectionDinRegistri();
            //else
            //    CGestiuneIO.SetSQLConnectionDinRegistri(connexionString);

            return connexionString;
        }

        public static string GetConnectionStringAlternativ()
        {
            if (string.IsNullOrEmpty(connexionStringAlternativ))
                connexionStringAlternativ = CGestiuneIO.getCheieConfigurare("SQLConnectionAlternativ");

            //if (string.IsNullOrEmpty(connexionStringAlternativ))
            //    return GetConnectionString();
            //else
            //    CGestiuneIO.SetSQLConnectionDinRegistri(connexionStringAlternativ);

            return connexionStringAlternativ;
        }

        /// <summary>
        /// Stergem conexion string din memorie
        /// </summary>
        protected static void deleteConnexionStringFromMemory()
        {
            connexionString = null;
            connexionStringAlternativ = null;
        }

        //pentru a obtine o conexiune de tip SQLServer
        public static IDbConnection getNewDataConnection(string sConnexionString)
        {
            System.Data.SqlClient.SqlConnection newConn;
            newConn = new System.Data.SqlClient.SqlConnection(sConnexionString);
            return newConn;
        }

        //pentru a obtine o comanda de tipSQLServer
        public static IDbCommand getNewDataCommand(string requete, IDbConnection conn)
        {
            return new System.Data.SqlClient.SqlCommand(requete, (System.Data.SqlClient.SqlConnection)conn);
        }

        //pentru a obtine o comanda de tip SQLServer
        public static IDbCommand getNewDataCommand()
        {
            System.Data.SqlClient.SqlCommand comanda = new System.Data.SqlClient.SqlCommand();
            comanda.CommandTimeout = 0;

            return comanda;
        }

        /// <summary>
        /// Intoarce un parametru de tip SQL Server
        /// </summary>
        public static IDataParameter getNewDataParameterForStoredProcedure(string sNume, object xValue)
        {
            return new System.Data.SqlClient.SqlParameter(sNume, xValue);
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, DateTime pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.DateTime);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, short pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.SmallInt);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, int pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.Int);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, long pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.BigInt);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, double pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.Decimal);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, string pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.NVarChar);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDataParameter getNewDataParameterForStoredProcedure(string pNume, bool pValoare)
        {
            System.Data.SqlClient.SqlParameter parametru = new System.Data.SqlClient.SqlParameter(pNume, SqlDbType.Bit);
            parametru.Value = pValoare;
            return parametru;
        }

        public static IDbDataAdapter getNewDataAdaptater()
        {
            return new System.Data.SqlClient.SqlDataAdapter();
        }

    }
}
