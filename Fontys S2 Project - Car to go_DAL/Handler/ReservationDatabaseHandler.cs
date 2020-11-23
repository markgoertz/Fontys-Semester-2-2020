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

        public List<ReservationDTO>GetallReservations()
        {
            var reservations = new List<ReservationDTO>();
            using (_dbCon.Open())
            {
        
                string query = "SELECT [Vehicle].[Brandname], [Vehicle].[Modelname], [Reservations].[ReservationID], [Reservations].[StartDate], [Reservations].[EndDate], [Reservations].[Email]" +
                               "FROM [Dbo].[Reservations]" +
                               "INNER JOIN [Dbo].[Vehicle]" +
                               "ON [Reservations].[VehicleID] = [Vehicle].[ID]" +
                               "Order by [StartDate];";

                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReservationDTO reservationDTO = new ReservationDTO
                    {
                        Brandname = reader.GetString(0),
                        Modelname = reader.GetString(1),
                        ReservationID = reader.GetInt32(2),
                        StartDate= reader.GetDateTime(3),
                        EndDate= reader.GetDateTime(4),
                        Email = reader.GetString(5),
                       
                    };

                    reservations.Add(reservationDTO);
                }
            }
            return reservations;
        }


        public void Delete(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM [Dbo].[Reservations] WHERE [ReservationID] = @ID";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }
    }
}
