using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Text;

namespace CCL.iStomaLab.Utile
{
    [Serializable]
    public class ServerSQL
    {
        public ServerSQL()
        {
            ServerName = string.Empty;
            InstanceName = string.Empty;
            IsClustered = string.Empty;
            Version = string.Empty;
        }

        #region ICloneable Members

        public object Clone()
        {
            try
            {
                if (this == null)
                {
                    return null;
                }
                ServerSQL SqlSL = new ServerSQL { ServerName = ServerName, InstanceName = InstanceName, IsClustered = IsClustered, Version = Version };
                return SqlSL;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            try
            {
                if (!(obj is ServerSQL))
                {
                    throw new Exception("obj is not an instance of SqlServerList");
                }
                if (this == null)
                {
                    return -1;
                }
                return ServerName.CompareTo((obj as ServerSQL).ServerName);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        public override string ToString()
        {
            return this.ServerName;
        }

        public static List<ServerSQL> GetListaServereSQL()
        {
            try
            {
                List<ServerSQL> lista = new List<ServerSQL>();

                ServerSQL SqlSL = null;
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                using (DataTable table = instance.GetDataSources())
                {
                    foreach (DataRow row in table.Rows)
                    {
                        SqlSL = new ServerSQL();
                        SqlSL.ServerName = row[0].ToString();
                        SqlSL.InstanceName = row[1].ToString();
                        SqlSL.IsClustered = row[2].ToString();
                        SqlSL.Version = row[3].ToString();
                        lista.Add(SqlSL);
                    }
                }

                return lista;
            }
            catch
            {
                return null;
            }
        }

        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string IsClustered { get; set; }
        public string Version { get; set; }
    }
}
