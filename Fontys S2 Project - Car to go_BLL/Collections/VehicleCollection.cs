using BLL.Converters;
using BLL.Models;
using Factories;
using Logic_interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Collections
{
    public class VehicleCollection : IVehicleCollection
    {
        private List<Vehicle> vehicles;
        public void Create(Vehicle car)
        {
            var result = ModelConverter.ConvertModelToDto(car);
            DalFactory.VehicleHandler.Create(result);
        }

        public List<Vehicle> GetAllVehicles()
        {
            var result = DalFactory.VehicleHandler.GetAll();
            vehicles = new List<Vehicle>();

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertDtoToModel(dto);
                vehicles.Add(model);
            }
            return vehicles;
        }


        public List<Vehicle> GetAllCars()
        {
            var result = DalFactory.VehicleHandler.GetAll();
            vehicles = new List<Vehicle>();

            foreach (var dto in result)
            {
                if (dto.CategoryID == 1)
                {
                    var model = ModelConverter.ConvertDtoToModel(dto);
                    vehicles.Add(model);
                }
            }

            return vehicles;
        }

        public List<Vehicle> GetAllVans()
        {
            var result = DalFactory.VehicleHandler.GetAll();
            vehicles = new List<Vehicle>();

            foreach (var dto in result)
            {
                if (dto.CategoryID == 2)
                {
                    var model = ModelConverter.ConvertDtoToModel(dto);
                    vehicles.Add(model);
                }
            }

            return vehicles;
        }
        public List<Vehicle> GetAllSpecials()
        {
            var result = DalFactory.VehicleHandler.GetAll();
            vehicles = new List<Vehicle>();

            foreach (var dto in result)
            {
                if (dto.CategoryID == 3)
                {
                    var model = ModelConverter.ConvertDtoToModel(dto);
                    vehicles.Add(model);
                }
            }

            return vehicles;
        }

        public Vehicle GetByID(int ID)
        {
            var result = GetAllVehicles();
            Vehicle vehicle = null;
            foreach (var item in result)
            {
                if(item.ID == ID)
                {
                    vehicle = item;
                }
            }
            return vehicle;
        }
    }
}
