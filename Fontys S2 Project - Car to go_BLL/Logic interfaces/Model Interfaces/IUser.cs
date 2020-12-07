using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IUser
    {
        int ID { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Postalcode { get; set; }
        string Adres { get; set; }
        int Housenumber { get; set; }
        string Email { get; set; }
        string Role { get; set; }
        string Password { get; set; }

        string ValidateLogin(User user);
        bool CheckDoubleEmails(User user);
        void Delete(int ID);
        void Edit(User Edit);

    }
}
