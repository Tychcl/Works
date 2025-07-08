using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr42.Classes
{
    public class Connection
    {
        private static readonly string config = "server=;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=False;DataBase=;User=;PWD=";
        public static SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(config);
            sqlConnection.Open();
            return sqlConnection;
        }

        public static SqlDataReader Query(string SQL, SqlConnection connection)
        {
            connection = OpenConnection();
            return new SqlCommand(SQL, connection).ExecuteReader();
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
            SqlConnection.ClearPool(connection);
        }
    }
}
