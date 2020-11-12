using DTO_layer;
using DTO_layer.Entities_DTO;
using Interfaces.IDBconnectionHandler;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Handler
{
    public class VehicleDatabaseHandler: IVehicleHandler
    {
        private static readonly string connectionString = "";
        private readonly IDBConnectionHandler _dbCon;
        public VehicleDatabaseHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

/* CREATE ------------------------------------------- CREATE ------------------------------------------------------ CREATE --------------------------------------------------- CREATE ------------------------------------ CREATE*/

        public void Create(VehicleDTO C1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO Vehicle (Brandname, Modelname, Transmission, Enginepower, Weight, Acceleration, Cargospace, Seat, Rentalprice, Fueltype, ImageLink, CategoryID) VALUES (@Brandname, @Modelname, @Transmission, @Enginepower, @Weight, @Acceleration, @Cargospace, @Seat, @Rentalprice, @Fueltype, @ImageLink, @CategoryID);";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                    command.Parameters.AddWithValue("@Brandname", C1.Brandname);
                    command.Parameters.AddWithValue("@Modelname", C1.Modelname);
                    command.Parameters.AddWithValue("@Transmission", C1.Transmission);
                    command.Parameters.AddWithValue("@Enginepower", C1.Enginepower);
                    command.Parameters.AddWithValue("@Weight", C1.Weight);
                    command.Parameters.AddWithValue("@Acceleration", C1.Acceleration);
                    command.Parameters.AddWithValue("@Cargospace", C1.Cargospace);
                    command.Parameters.AddWithValue("@Seat", C1.Seat);
                    command.Parameters.AddWithValue("@Rentalprice", C1.RentalPrice);
                    command.Parameters.AddWithValue("@Fueltype", C1.Fueltype);
                    command.Parameters.AddWithValue("@ImageLink", C1.ImageLink);
                    command.Parameters.AddWithValue("@CategoryID", C1.CategoryID);
             
                    command.ExecuteNonQuery();
            }
        }

        /* READ ------------------------------------------- READ ------------------------------------------------------ READ --------------------------------------------------- READ ------------------------------------ READ*/

        public List<VehicleDTO> GetAll()
        {
            var vehicles = new List<VehicleDTO>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [Dbo].[Vehicle]";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    VehicleDTO vehicle = new VehicleDTO
                    {
                        ID = reader.GetInt32(0),
                        Brandname = reader.GetString(1),
                        Modelname = reader.GetString(2),
                        Transmission = reader.GetString(3),
                        Enginepower = reader.GetInt32(4),
                        Weight = reader.GetInt32(5),
                        Acceleration = reader.GetDouble(6),
                        Cargospace = reader.GetInt32(7),
                        Seat = reader.GetInt32(8),
                        RentalPrice = reader.GetDouble(9),
                        Fueltype = reader.GetString(10),
                        ImageLink = reader.GetString(11),
                        CategoryID = reader.GetInt32(12)
                    };

                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }




        
/* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/


        public void Update(VehicleDTO U1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE [Dbo].[Vehicle] Set Brandname = @Brandname, Modelname = @Modelname, Transmission = @Transmission, Enginepower = @Enginepower, Weight = @Weight, Acceleration = @Acceleration, Cargospace = @Cargospace, Seat = @Seat, Rentalprice = @Rentalprice, Fueltype = @Fueltype, ImageLink = @ImageLink, CategoryID = @CategoryID WHERE ID = @ID;";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@ID", U1.ID);
                command.Parameters.AddWithValue("@Brandname", U1.Brandname);
                command.Parameters.AddWithValue("@Modelname", U1.Modelname);
                command.Parameters.AddWithValue("@Transmission", U1.Transmission);
                command.Parameters.AddWithValue("@Enginepower", U1.Enginepower);
                command.Parameters.AddWithValue("@Weight", U1.Weight);
                command.Parameters.AddWithValue("@Acceleration", U1.Acceleration);
                command.Parameters.AddWithValue("@Cargospace", U1.Cargospace);
                command.Parameters.AddWithValue("@Seat", U1.Seat);
                command.Parameters.AddWithValue("@Rentalprice", U1.RentalPrice);
                command.Parameters.AddWithValue("@Fueltype", U1.Fueltype);
                command.Parameters.AddWithValue("@ImageLink", U1.ImageLink);
                command.Parameters.AddWithValue("@CategoryID", U1.CategoryID);

                command.ExecuteNonQuery();
            }
        }

/* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public void Delete(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM Vehicle WHERE ID=@ID";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }

    }
}
