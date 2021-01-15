using DAL.DatabaseConnectionHandler;
using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Car.To.Go.UnitTests.Application.Layer.Tests.Collections
{
    public class MockConnection : IDBConnectionHandler
    {
        public static string connectionString = "";

        public static void SetConnectionString(string constring)
        {
            connectionString = constring;
        }

        public SqlConnection Connection { get; set; }
        public SqlConnection Open()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();

            return Connection;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
