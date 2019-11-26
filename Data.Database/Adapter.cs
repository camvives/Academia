using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace Data.Database
{
    public class Adapter
    {
        public SqlConnection sqlConn = new SqlConnection();

        protected void OpenConnection()
        {
            string conn = ConfigurationManager.ConnectionStrings["ExpressConnection"].ConnectionString;
            sqlConn = new SqlConnection(conn);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }
    }
}
