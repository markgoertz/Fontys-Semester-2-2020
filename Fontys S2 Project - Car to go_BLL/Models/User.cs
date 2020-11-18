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

        public string ValidateLogin(User user)
        {
            var result = UserModelConverter.ConvertModelToDto(user);
            string userresult = DalFactory.UserDatabaseHandler.Login(result);
            return userresult;
        }

        public bool CheckDoubleEmails(User user)
        {
            var status = false;
            var emailtest = DalFactory.UserDatabaseHandler.GetAll();
            foreach (var account in emailtest)
            {
                if (account.Email == user.Email)
                {
                    status = true;
                    return status;
                }
            }
            return status;
        }
        public void Delete(int ID)
        {
            DalFactory.UserDatabaseHandler.Delete(ID);
        }

        public void Edit(User Edit)
        {
            var DTO = UserModelConverter.ConvertModelToDto(Edit);
            DalFactory.UserDatabaseHandler.Update(DTO);
        }
    }
}
