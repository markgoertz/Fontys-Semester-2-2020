using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.DatabaseConnectionHandler
{
    public class DBConnectionHandler : IDBConnectionHandler 
    {
        private protected string connectionString = "Server=mssql.fhict.local;Database=dbi434548;User Id = dbi434548; Password=MijnFontysServer2020";
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
