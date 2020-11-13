using BLL;
using BLL.Models;
using Car.To.Go.UnitTests.Mockdata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Application.Layer.Tests.Collections
{
    [TestClass]
    public class VehicleCollections
    {
        private readonly VehicleCollection vehiclecollection = new VehicleCollection();
        private readonly Vehicle vehiclemodel = new Vehicle();

        [TestMethod]
        public void GetAllVehiclesTest()
        {
            var result = vehiclecollection.GetAllCars();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteVehicleID()
        {            
            Vehicle vehicle = new Vehicle();
            vehicle.Delete(MockDataVehicle.NotExistentCar.ID);
            Assert.IsNotNull(vehicle);
        }
      
    }
}
