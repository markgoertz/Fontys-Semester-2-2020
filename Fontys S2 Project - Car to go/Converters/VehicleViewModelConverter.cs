using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Converters
{
    public class ModelConverter
    {
        private static Vehicle _model;
        private static VehicleViewModel _viewmodel;
        public static Vehicle ConvertModelToViewModel(Vehicle model)
        {
            _model = new Vehicle()
            {
                ID = model.ID,
                Seat = model.Seat,
                Brandname = model.Brandname,
                CategoryID = model.CategoryID,
                Cargospace = model.Cargospace,
                Acceleration = model.Acceleration,
                Enginepower = model.Enginepower,
                Fueltype = model.Fueltype,
                ImageLink = model.ImageLink,
                Modelname = model.Modelname,
                RentalPrice = model.RentalPrice,
                Transmission = model.Transmission,
                Weight = model.Weight

            };

            return _model;
        }

        public static VehicleViewModel ConvertViewModelToModel(VehicleViewModel viewmodel)
        {
            _viewmodel = new VehicleViewModel()
            {
                ID = viewmodel.ID,
                Brandname = viewmodel.Brandname,
                Modelname = viewmodel.Modelname,
                CategoryID = viewmodel.CategoryID,
                Seat = viewmodel.Seat,
                Cargospace = viewmodel.Cargospace,
                Enginepower = viewmodel.Enginepower,
                Acceleration = viewmodel.Acceleration,
                Fueltype = viewmodel.Fueltype,
                ImageLink = viewmodel.ImageLink,
                RentalPrice = viewmodel.RentalPrice,
                Transmission = viewmodel.Transmission,
                Weight = viewmodel.Weight
            };

            return _viewmodel;
        }
    }
}
