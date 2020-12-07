using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.DatabaseConnectionHandler
{
    public class DBConnectionHandler : IDBConnectionHandler 
    {
        private static string connectionString = "";

        public static void SetConnectionString(string constring)
        {
            connectionString = constring;
        }

        public SqlConnection Connection { get; private set; }
        public SqlConnection Open()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();

            return Connection;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
