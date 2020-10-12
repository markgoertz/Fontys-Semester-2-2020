using DTO_layer.Entities_DTO;
using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car_to_go_DAL.Handler
{
    public class CarDatabaseHandler 
    {
        private static readonly string connectionString = "";
        private readonly IDBConnectionHandler _connectionString;

        public CarDatabaseHandler(IDBConnectionHandler dbCon)
        {
            _connectionString = dbCon;
        }

        public List<CarDTO> GetAll()
        {
            var cars = new List<CarDTO>();
            using (_connectionString.Open())
            {
                string query = "SELECT * FROM Vehicle WHERE CategoryID = 1;";
                using (SqlCommand command = new SqlCommand(query, _connectionString.Connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CarDTO CarDTO = new CarDTO
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
                            ImageLink = reader.GetString(11)
                        };

                        cars.Add(CarDTO);
                    }

                    _connectionString.Close();
                }
            }
            return cars;
        }

        public void Create(CarDTO C1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Vehicle (Brandname, Modelname, Transmission, Enginepower, Weight, Acceleration, Cargospace, Seat, Rentalprice, Fueltype, ImageLink, CategoryID) VALUES (@Brandname, @Modelname, @Transmission, @Enginepower, @Weight, @Acceleration, @Cargospace, @Seat, @Rentalprice, @Fueltype, @ImageLink, @CategoryID);";
                using (SqlCommand command = new SqlCommand(query, _connectionString.Connection))
                {
                    command.Parameters.AddWithValue("@ID", C1.ID);
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
        }

        public void Update(CarDTO U1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Vehicle Set Brandname = @Brandname, Modelname = @Modelname, Transmission = @Transmission, Enginepower = @Enginepower, Weight = @Weight, Acceleration = @Acceleration, Cargospace = @Cargospace, Seat = @Seat, Rentalprice = @Rentalprice, Fueltype = @Fueltype, ImageLink = @ImageLink WHERE ID = @ID;";
                using (SqlCommand command = new SqlCommand(query, _connectionString.Connection))
                {
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
        }

        public CarDTO GetByID(CarDTO ID)
        {
            CarDTO car = new CarDTO();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [dbi434548].[dbo].[Vehicle] WHERE ID = @ID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ID", ID.ID);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        car.ID = reader.GetInt32(0);
                        car.Brandname = reader.GetString(1);
                        car.Modelname = reader.GetString(2);
                        car.Transmission = reader.GetString(3);
                        car.Enginepower = reader.GetInt32(4);
                        car.Weight = reader.GetInt32(5);
                        car.Acceleration = reader.GetDouble(6);
                        car.Cargospace = reader.GetInt32(7);
                        car.Seat = reader.GetInt32(8);
                        car.RentalPrice = reader.GetDouble(9);
                        car.Fueltype = reader.GetString(10);
                        car.ImageLink = reader.GetString(11);
                        car.CategoryID = reader.GetInt32(12);
                    }
                }

                return car;
            }
        }

        public void Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vehicle WHERE ID=@ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
