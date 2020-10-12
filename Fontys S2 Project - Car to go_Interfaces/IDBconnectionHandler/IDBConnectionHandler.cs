using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Interfaces.IDBconnectionHandler
{
    public interface IDBConnectionHandler
    {
        SqlConnection Connection { get; }
        SqlConnection Open();
        void Close();

    }
}
