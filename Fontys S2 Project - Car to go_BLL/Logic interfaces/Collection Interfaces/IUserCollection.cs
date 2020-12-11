using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IUserCollection
    {
        List<User> GetUsers();
        User GetByID(int ID);
        void Create(User user);
    }
}
