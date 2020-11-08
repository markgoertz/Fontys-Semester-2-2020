using BLL.Converters;
using BLL.Models;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class VehicleCollection
    {
        public void Create(Vehicle car)
        {
            var result = ModelConverter.ConvertModelToDto(car);
            DalFactory.VehicleHandler.Create(result);
        }

        
    }

    public class VehicleGetall
    {
        private List<Vehicle> vehicles;
        public List<Vehicle> GetAllCars()
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
    }
}
