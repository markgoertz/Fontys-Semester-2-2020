using Interfaces.IHandlers;
using DTO_layer.Entities_DTO;
using Interfaces.IDBconnectionHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace DAL.Handler
{
    public class UserDatabaseHandler : IUserHandler
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
                string query = "INSERT INTO [dbo].[User] (Firstname, Lastname, Postalcode, Adres, Housenumber, Email, Role, Password) VALUES (@Firstname, @Lastname, @Postalcode, @Adres, @Housenumber, @Email, @Role, @Password);";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@Firstname", C1.Firstname);
                command.Parameters.AddWithValue("@Lastname", C1.Lastname);
                command.Parameters.AddWithValue("@Postalcode", C1.Postalcode);
                command.Parameters.AddWithValue("@Adres", C1.Adres);
                command.Parameters.AddWithValue("@Housenumber", C1.Housenumber);
                command.Parameters.AddWithValue("@Email", C1.Email);
                command.Parameters.AddWithValue("@Role", C1.Role);
                command.Parameters.AddWithValue("@Password", C1.Password);

                command.ExecuteNonQuery();
            }
        }

/* READ ------------------------------------------- READ ------------------------------------------------------ READ --------------------------------------------------- READ ------------------------------------ READ*/

        public List<UserDTO> GetAll()
        {
            var users = new List<UserDTO>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [Dbo].[User]";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserDTO UserDTO = new UserDTO
                    {
                        ID = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Postalcode= reader.GetString(3),
                        Adres= reader.GetString(4),
                        Housenumber = reader.GetInt32(5),
                        Email = reader.GetString(6),
                        Role = reader.GetString(7),
                        Password = reader.GetString(8)
                    };

                    users.Add(UserDTO);
                }
            }
            return users;
        }

/* LogIn ------------------------------------------- READ ------------------------------------------------------ READ --------------------------------------------------- READ ------------------------------------ READ*/

        public string Login(UserDTO user)
        {
            using (_dbCon.Open())
            {

                using SqlCommand command = new SqlCommand("spValidateUserLogin", _dbCon.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LoginEmail", user.Email);
                command.Parameters.AddWithValue("@LoginPassword", user.Password);
               
                string result = command.ExecuteScalar().ToString();

                return result;
            }
        }

/* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/


        public void Update(UserDTO U1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE [Dbo].[User] Set Firstname = @Firstname, Lastname = @Lastname, PostalCode = @Postalcode, Adres = @Adres, Housenumber = @Housenumber, Email = @Email, Role = @Role WHERE ID = @ID;";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@ID", U1.ID);
                command.Parameters.AddWithValue("@Firstname", U1.Firstname);
                command.Parameters.AddWithValue("@Lastname", U1.Lastname);
                command.Parameters.AddWithValue("@Postalcode", U1.Postalcode);
                command.Parameters.AddWithValue("@Adres", U1.Adres);
                command.Parameters.AddWithValue("@Housenumber", U1.Housenumber);
                command.Parameters.AddWithValue("@Email", U1.Email);
                command.Parameters.AddWithValue("@Role", U1.Role);
               
                command.ExecuteNonQuery();
            }
        }

        /* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public void Delete(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM User WHERE ID=@ID";
                using SqlCommand command = new SqlCommand(query, _dbCon.Connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }

    }
}

