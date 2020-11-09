using BLL.Models;
using DTO_layer;
using DTO_layer.Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ModelConverter
    {
        private static Vehicle _model;
        private static VehicleDTO _dto;
        public static Vehicle ConvertDtoToModel(VehicleDTO dto)
        {
            _model = new Vehicle()
            {
                ID = dto.ID, Seat = dto.Seat, Brandname = dto.Brandname, CategoryID = dto.CategoryID, Cargospace = dto.Cargospace, Acceleration = dto.Acceleration, Enginepower = dto.Enginepower, Fueltype = dto.Fueltype, ImageLink = dto.ImageLink, Modelname = dto.Modelname,  RentalPrice = dto.RentalPrice, Transmission = dto.Transmission, Weight  = dto.Weight,
            };

            return _model;
        }

        public static VehicleDTO ConvertModelToDto(Vehicle model)
        {
            _dto = new VehicleDTO() 
            { 
              ID = model.ID, Brandname= model.Brandname, Modelname= model.Modelname, CategoryID= model.CategoryID, Seat= model.Seat, Cargospace= model.Cargospace, Enginepower= model.Enginepower, Acceleration = model.Acceleration, Fueltype = model.Fueltype, ImageLink = model.ImageLink, RentalPrice = model.RentalPrice, Transmission = model.Transmission, Weight = model.Weight
            };

            return _dto;
        }
    }
}
