using BLL;
using BLL.Collections;
using BLL.Models;
using Car.To.Go.UnitTests.Mockdata;
using DAL.DatabaseConnectionHandler;
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
        public void Connectionsetter()
        {
            DBConnectionHandler.SetConnectionString("Server = mssql.fhict.local; Database = dbi434548; User Id = dbi434548; Password = MijnFontysServer2020");
        }
        [TestMethod]
        public void GetAllVehiclesTest()
        {
            Connectionsetter();
            var result = vehiclecollection.GetAllCars();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteVehicleID()
        {
            Connectionsetter();
            Vehicle vehicle = new Vehicle();
            vehicle.Delete(MockDataVehicle.NotExistentCar.ID);
            Assert.IsNotNull(vehicle);
        }
      
    }
}
