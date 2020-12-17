using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{
    public class UserViewModel
    {
        private static UserViewModel _userviewmodel;
        private static User _usermodel;
        public int ID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string Postalcode { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        [Range(1,18926,ErrorMessage ="The number for {0} most be between {1} and {2}.")]
        public int Housenumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public static UserViewModel ConvertModelToUserViewModel(User model)
        {
            _userviewmodel = new UserViewModel()
            {
                ID = model.ID,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Adres = model.Adres,
                Email = model.Email,
                Housenumber = model.Housenumber,
                Password = model.Password,
                Postalcode = model.Postalcode,
                Role = model.Role
            };
            return _userviewmodel;
        }

        public static User ConvertUserViewModelToModel(UserViewModel model)
        {
            _usermodel = new User()
            {
                ID = model.ID,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Adres = model.Adres,
                Email = model.Email,
                Housenumber = model.Housenumber,
                Password = model.Password,
                Postalcode = model.Postalcode,
                Role = model.Role
            };
            return _usermodel;
        }
    }
}
