using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Mockdata
{
    public static class MockDataVehicle
    { 
        public static Vehicle NotExistentCar = new Vehicle()
        {
            ID = 100,
            Brandname = "Volkswagem",
            Modelname = "Up!",
            Seat = 5,
            CategoryID = 1,
            Weight = 1000,
            Enginepower = 70,
            Acceleration = 6,
            Cargospace = 300,
            Fueltype = "E10",
            ImageLink = "",
            RentalPrice = 70,
            Transmission = "Auto"

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
