using BLL.Converters;
using BLL.Models;
using Factories;
using Logic_interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Collections
{
    public class UserCollection : IUserCollection
    {
        private List<User> user;

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

        public List<User> GetUsers()
        {
            var result = DalFactory.UserDatabaseHandler.GetAll();
            user = new List<User>();

            foreach (var dto in result)
            {
                var model = UserModelConverter.ConvertDtoToModel(dto);
                user.Add(model);
            }
            return user;
        }
    }
}
