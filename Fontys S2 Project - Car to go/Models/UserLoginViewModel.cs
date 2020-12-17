using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        private static UserLoginViewModel _viewmodel;
        private static User _model;
        public static User ConvertViewModelToModel(UserLoginViewModel viewmodel)
        {
            _model = new User()
            {
               Email = viewmodel.Email,
               Password = viewmodel.Password
            };
            return _model;
        }
        public static UserLoginViewModel ConvertModelViewModel(User model)
        {
            _model = new User()
            {
               Email = model.Email,
               Password = model.Password
            };
            return _viewmodel;
        }
    }
}
