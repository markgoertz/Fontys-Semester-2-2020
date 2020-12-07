using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IUserCollection
    {
        List<User> GetUsers();
        void Create(User user);
    }
}
