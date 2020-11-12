using BLL.Converters;
using DTO_layer.Entities_DTO;
using Factories;
using Logic_interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class User 
    { 
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

     
    }
}
