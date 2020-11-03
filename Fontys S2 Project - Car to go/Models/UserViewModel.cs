using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Postalcode { get; set; }
        public string Adres { get; set; }
        public int Housenumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
