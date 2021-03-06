﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{

    public class VehicleViewModel
    {

        private static VehicleViewModel _viewmodel;
        private static Vehicle _vehiclemodel;


        [Key]
        public int ID { get; set; }


        [Display(Name = "Brandname")]
        [Required(ErrorMessage = "Required")]
        public string Brandname { get; set; }

        [Display(Name = "Modelname")]
        [Required(ErrorMessage = "Required")]
        public string Modelname { get; set; }

        [Display(Name = "Transmission")]
        [Required(ErrorMessage = "Required")]
        public string Transmission { get; set; }


        [Display(Name = "Enginepower")]
        [Required(ErrorMessage = "Required")]
        [Range(50, 1000, ErrorMessage = "The car must have a engine power between 50 and 1000 HP!")]
        public int Enginepower { get; set; }


        [Display(Name = "Weight")]
        [Required(ErrorMessage = "This field is required!")]
        public int Weight { get; set; }


        [Display(Name = "Acceleration")]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "This field is required!")]
        [Range(1.00, 15.00, ErrorMessage = "The car need to have an accelaration between 1 and 15 seconds!")]
        public decimal Acceleration { get; set; }


        [Display(Name = "Cargospace")]
        [Required(ErrorMessage = "Required")]
        public int Cargospace { get; set; }


        [Display(Name = "Seat")]
        [Required(ErrorMessage = "Required")]
        public int Seat { get; set; }


        [Display(Name = "Rentalprice")]
        [Required(ErrorMessage = "Required")]
        public double RentalPrice { get; set; }


        [Display(Name = "Fueltype")]
        [Required(ErrorMessage = "Required")]
        public string Fueltype { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        public string ImageLink { get; set; }

        [Required(ErrorMessage = "This field is required, you have to pick a category!")]
        public int CategoryID { get; set; }
             
        public static VehicleViewModel ConvertModelToVehicleViewModel(Vehicle model)
        {
            _viewmodel = new VehicleViewModel()
            {
                ID = model.ID, Brandname = model.Brandname, Modelname = model.Modelname, CategoryID = model.CategoryID, Seat = model.Seat, Cargospace = model.Cargospace, Enginepower = model.Enginepower, Acceleration = model.Acceleration, Fueltype = model.Fueltype, ImageLink = model.ImageLink, RentalPrice = model.RentalPrice, Transmission = model.Transmission, Weight = model.Weight
            };
            return _viewmodel;
        }
        public static Vehicle ConvertVehicleViewModelToModel(VehicleViewModel viewmodel)
        {
            _vehiclemodel = new Vehicle()
            {
                ID = viewmodel.ID, Seat = viewmodel.Seat, Acceleration = viewmodel.Acceleration, Brandname = viewmodel.Brandname, Cargospace = viewmodel.Cargospace, CategoryID = viewmodel.CategoryID, Enginepower = viewmodel.Enginepower, Fueltype = viewmodel.Fueltype, Weight = viewmodel.Weight, ImageLink = viewmodel.ImageLink, Modelname = viewmodel.Modelname, RentalPrice = viewmodel.RentalPrice, Transmission = viewmodel.Transmission
            };
            return _vehiclemodel;
        }
    }
}
