using BLL;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.View
{
    [TestClass]
    public class VehicleTest
    {
        private Vehicle vehicle;

        [TestMethod]
        public void TestVehicleDetails()
        {
            VehicleCollection newvehicle = new VehicleCollection();
            String Brandname = "BMW";
            String Modelname = "X6 M";
            String expentedbrandname = "BMW";
            String expentedmodelname = "X6 M";

            var actual = newvehicle.GetAllCars();
            Assert.AreEqual(expentedbrandname, actual);


        }
    }
}
