using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EStall.App_Start
{
    public class DataBaseConfig
    {
        private const string USER = "estall";
        private const string PASS = "Benner2013";
        private const string SERVER_NAME = "tcp:zy56jbyfzo.database.windows.net,1433";
        private const string DB_NAME = "e-stall";

        private static SqlConnection CreateConnection()
        {
            // Create a connection string for the master database
            SqlConnectionStringBuilder connString1Builder;
            connString1Builder = new SqlConnectionStringBuilder();
            connString1Builder.DataSource = SERVER_NAME;
            connString1Builder.InitialCatalog = DB_NAME;
            connString1Builder.Encrypt = true;
            connString1Builder.TrustServerCertificate = false;
            connString1Builder.UserID = USER;
            connString1Builder.Password = PASS;

            return new SqlConnection(connString1Builder.ToString());
        }

        public static IEnumerable<T> ExecuteReader<T>(string command, Func<SqlDataReader, IEnumerable<T>> function)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = command;
                    connection.Open();
                    return function(sqlCommand.ExecuteReader());
                }
            }
        }

        public static void ExecuteNonQuery(string command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = command;
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}