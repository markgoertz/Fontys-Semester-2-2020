using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Mockdata_User
{
    public static class MockDataUser
    {

        public static User CorrectUserTest = new User()
        {
            Email = "Jan.Willem@gmail.nl",
            Password = "Test123"

        };

        public static User NotknownUser = new User()
        {
            Email = "Systemtest.FakeUser@gmail.com",
            Password = "Thisisafakeuser"
        };

        public static User WrongPasswordUser = new User()
        {
            Email = "Jan.Willem@gmail.com",
            Password = "DitiseenFoutievewachtwoord"
        };

    }
}

