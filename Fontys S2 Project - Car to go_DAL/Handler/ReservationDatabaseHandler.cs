using DTO_layer.Entities_DTO;
using Interfaces.IDBconnectionHandler;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Handler
{
    public class ReservationDatabaseHandler : IReservationHandler
    {
        private static readonly string connectionString = "";
        private readonly IDBConnectionHandler _dbCon;
        public ReservationDatabaseHandler (IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public void PlaceReservation(ReservationDTO C1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO [dbo].[Reservations] (Email, VehicleID, StartDate, EndDate) VALUES (@Email, @VehicleID, @StartDate, @EndDate);";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@Email", C1.Email);
                command.Parameters.AddWithValue("@VehicleID", C1.VehicleID);
                command.Parameters.AddWithValue("@StartDate", C1.StartDate);
                command.Parameters.AddWithValue("@EndDate", C1.EndDate);
                
                command.ExecuteNonQuery();
            }
        }
    }
}
