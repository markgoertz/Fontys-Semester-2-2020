using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using Logic_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Converters
{
    public class ViewModelConverter
    {
        private static VehicleViewModel _viewmodel;
        private static UserViewModel _userviewmodel;
        private static ReservationViewModel _reservationViewModel;

        private static Vehicle _vehiclemodel;
        private static Reservation _reservationmodel;
        private static User _usermodel;
        public static VehicleViewModel ConvertModelToVehicleViewModel(Vehicle model)
        {
            _viewmodel = new VehicleViewModel()
            {
                ID = model.ID, Brandname = model.Brandname,Modelname = model.Modelname,CategoryID = model.CategoryID, Seat = model.Seat, Cargospace = model.Cargospace, Enginepower = model.Enginepower, Acceleration = model.Acceleration, Fueltype = model.Fueltype, ImageLink = model.ImageLink, RentalPrice = model.RentalPrice,Transmission = model.Transmission, Weight = model.Weight
            };
            return _viewmodel;
        }
        public static Vehicle ConvertVehicleViewModelToModel(VehicleViewModel viewmodel)
        {
            _vehiclemodel = new Vehicle()
            {
                ID = viewmodel.ID, Seat = viewmodel.Seat, Acceleration = viewmodel.Acceleration, Brandname = viewmodel.Brandname, Cargospace = viewmodel.Cargospace, CategoryID = viewmodel.CategoryID, Enginepower = viewmodel.Enginepower, Fueltype = viewmodel.Fueltype, Weight= viewmodel.Weight, ImageLink = viewmodel.ImageLink, Modelname = viewmodel.Modelname, RentalPrice = viewmodel.RentalPrice, Transmission = viewmodel.Transmission
            };
            return _vehiclemodel;
        }

        public static UserViewModel ConvertModelToUserViewModel(User model)
        {
            _userviewmodel = new UserViewModel()
            {
                ID = model.ID, Firstname = model.Firstname,Lastname = model.Lastname, Adres = model.Adres, Email = model.Email,Housenumber = model.Housenumber, Password = model.Password ,Postalcode = model.Postalcode,Role = model.Role
            };
            return _userviewmodel;
        }

        public static User ConvertUserViewModelToModel(UserViewModel model)
        {
            _usermodel = new User()
            {
                ID = model.ID, Firstname = model.Firstname, Lastname = model.Lastname, Adres = model.Adres, Email = model.Email, Housenumber = model.Housenumber, Password = model.Password, Postalcode = model.Postalcode, Role = model.Role 
            };
            return _usermodel;
        }
        public static ReservationViewModel ConvertModelToReservationViewModel(Reservation model)
        {
            _reservationViewModel = new ReservationViewModel()
            {
                ReservationID = model.ReservationID, BrandName = model.BrandName, EndDate = model.EndDate, StartDate = model.StartDate, VehicleID = model.VehicleID, Email = model.Email, ModelName = model.ModelName
            };
            return _reservationViewModel;
        }

        public static Reservation ConvertReservationViewModelToModel(ReservationViewModel model)
        {
            _reservationmodel = new Reservation()
            {
                ReservationID = model.ReservationID, BrandName = model.BrandName, EndDate = model.EndDate, StartDate = model.StartDate, VehicleID = model.VehicleID, Email = model.Email, ModelName = model.ModelName
            };
            return _reservationmodel;
        }
    }
}
