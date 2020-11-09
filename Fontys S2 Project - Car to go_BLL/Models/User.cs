using BLL.Converters;
using DTO_layer.Entities_DTO;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class User
    { 
        private UserDTO _user;
        private List<User> users;

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Postalcode { get; set; }
        public string Adres { get; set; }
        public int Housenumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public void Create(User user)
        {
            var result = UserModelConverter.ConvertModelToDto(user);
            DalFactory.UserDatabaseHandler.Create(result);
        }

        public string ValidateLogin(User user)
        {
            var result = UserModelConverter.ConvertModelToDto(user);
            string userresult = DalFactory.UserDatabaseHandler.Login(result);
            return userresult;
            
        }

        public List<User> GetUsers()
        {
            var result = DalFactory.UserDatabaseHandler.GetAll();
            users = new List<User>();

            foreach (var dto in result)
            {
                var model = UserModelConverter.ConvertDtoToModel(dto);
                users.Add(model);
            }
            return users;
        }
    }
}
