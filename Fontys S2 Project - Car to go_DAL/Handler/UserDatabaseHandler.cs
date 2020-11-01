using DTO_layer.Entities_DTO;
using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Car_to_go_DAL.Handler
{
    public class UserDatabaseHandler
    {
        private static readonly string connectionString = "";
        private readonly IDBConnectionHandler _dbCon;
        public UserDatabaseHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        /* CREATE ------------------------------------------- CREATE ------------------------------------------------------ CREATE --------------------------------------------------- CREATE ------------------------------------ CREATE*/

        public void Create(UserDTO C1)
        {
            using (_dbCon.Open())
            {
                string query = "Insert into User (Firstname, Lastname, Postalcode, Adres, Housenumber, Email, Role) Values (@Firstname, @Lastname, @Postalcode, @Adres,@Housenumber, @Email, @Role);";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@Firstname", C1.Firstname);
                command.Parameters.AddWithValue("@Lastname", C1.Lastname);
                command.Parameters.AddWithValue("@Postalcode", C1.Postalcode);
                command.Parameters.AddWithValue("@Adres", C1.Adres);
                command.Parameters.AddWithValue("@Housenumber", C1.Housenumber);
                command.Parameters.AddWithValue("@Email", C1.Email);
                command.Parameters.AddWithValue("@Role", C1.Role);

                command.ExecuteNonQuery();
            }
        }

        /* READ ------------------------------------------- READ ------------------------------------------------------ READ --------------------------------------------------- READ ------------------------------------ READ*/

        //public List<UserDTO> GetAll()
        //{
        //    var users = new List<UserDTO>();
        //    using (_dbCon.Open())
        //    {
        //        string query = "SELECT * FROM Vehicle WHERE CategoryID = '1';";
        //        using SqlCommand command = new SqlCommand(query, _dbCon.Connection);
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            UserDTO UserDTO = new UserDTO
        //            {
        //                ID = reader.GetInt32(0),
        //                Brandname = reader.GetString(1),
        //                Modelname = reader.GetString(2),
        //                Transmission = reader.GetString(3),
        //                Enginepower = reader.GetInt32(4),
        //                Weight = reader.GetInt32(5),
        //                Acceleration = reader.GetDouble(6),
        //                Cargospace = reader.GetInt32(7),
        //                Seat = reader.GetInt32(8),
        //                RentalPrice = reader.GetDouble(9),
        //                Fueltype = reader.GetString(10),
        //                ImageLink = reader.GetString(11),
        //                CategoryID = reader.GetInt32(12)
        //            };

        //            users.Add(UserDTO);
        //        }
        //    }
        //    return users;
        //}

        /* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/


        //public void Update(UserDTO U1)
        //{
        //    using (_dbCon.Open())
        //    {
        //        string query = "UPDATE Vehicle Set Brandname = @Brandname, Modelname = @Modelname, Transmission = @Transmission, Enginepower = @Enginepower, Weight = @Weight, Acceleration = @Acceleration, Cargospace = @Cargospace, Seat = @Seat, Rentalprice = @Rentalprice, Fueltype = @Fueltype, ImageLink = @ImageLink WHERE ID = @ID;";
        //        using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

        //        command.Parameters.AddWithValue("@ID", U1.ID);
        //        command.Parameters.AddWithValue("@Brandname", U1.Brandname);
        //        command.Parameters.AddWithValue("@Modelname", U1.Modelname);
        //        command.Parameters.AddWithValue("@Transmission", U1.Transmission);
        //        command.Parameters.AddWithValue("@Enginepower", U1.Enginepower);
        //        command.Parameters.AddWithValue("@Weight", U1.Weight);
        //        command.Parameters.AddWithValue("@Acceleration", U1.Acceleration);
        //        command.Parameters.AddWithValue("@Cargospace", U1.Cargospace);
        //        command.Parameters.AddWithValue("@Seat", U1.Seat);
        //        command.Parameters.AddWithValue("@Rentalprice", U1.RentalPrice);
        //        command.Parameters.AddWithValue("@Fueltype", U1.Fueltype);
        //        command.Parameters.AddWithValue("@ImageLink", U1.ImageLink);
        //        command.Parameters.AddWithValue("@CategoryID", U1.CategoryID);

        //        command.ExecuteNonQuery();
        //    }
        //}

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

