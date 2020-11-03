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
        private List<UserDTO> _user;
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Postalcode { get; set; }
        public string Adres { get; set; }
        public int Housenumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public void Create(User user)
        {
            var result = UserModelConverter.ConvertModelToDto(user);
            DalFactory.userDatabaseHandler.Create(result);
        }
    }
}
