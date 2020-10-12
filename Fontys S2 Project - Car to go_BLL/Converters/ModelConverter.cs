using DTO_layer.Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public static class ModelConverter
    {
        private static Car _model;
        private static CarDTO _dto;
        public static Car ConvertDtoToModel(CarDTO dto)
        {
            _model = new Car()
            {
                ID = dto.ID,
                Seat = dto.Seat,
                Acceleration = dto.Acceleration,
                Brandname = dto.Brandname,
                CategoryID = dto.CategoryID,
                Cargospace = dto.Cargospace,
                Enginepower = dto.Enginepower,
                Fueltype = dto.Fueltype,
                ImageLink = dto.ImageLink,
                Modelname = dto.Modelname,
                RentalPrice = dto.RentalPrice,
                Transmission = dto.Transmission,
                Weight  = dto.Weight
            };

            return _model;
        }

        public static CarDTO ConvertModelToDto(Car model)
        {
            _dto = new CarDTO() 
            { ID = model.ID, 
              Brandname= model.Brandname, 
              Modelname= model.Modelname, 
              CategoryID= model.CategoryID, 
              Seat= model.Seat, 
              Acceleration= model.Acceleration, 
              Cargospace= model.Cargospace, 
              Enginepower= model.Enginepower,
              Fueltype = model.Fueltype,
              ImageLink = model.ImageLink,
              RentalPrice = model.RentalPrice,
              Transmission = model.Transmission,
              Weight = model.Weight
            };
            return _dto;
        }
    }
}
