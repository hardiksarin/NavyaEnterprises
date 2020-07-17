using GravitonLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary
{
    public class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }
        public static void InitializeConnections()
        {
            SQLConnector sql = new SQLConnector();
            Connection = sql;
        }

        public static string getDatabaseConnectionString()
        {
            string server = "mydb.ctmbums33jwn.ap-south-1.rds.amazonaws.com";
            string port = "5432";
            string user = "postgres";
            string password = "postgres";
            string database = "accounting";
            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    server, port, user, password, database);
            return connectionString;
        }

    }
}
