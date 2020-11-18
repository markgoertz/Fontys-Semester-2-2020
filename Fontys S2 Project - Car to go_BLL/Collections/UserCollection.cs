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

        public void Create(User user)
        {
            var result = UserModelConverter.ConvertModelToDto(user);
            DalFactory.UserDatabaseHandler.Create(result);
        }
    }
}
