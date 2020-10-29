using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_to_go.Controllers
{
    public class CarController : Controller
    {
        private readonly VehicleCollection _coll;
        private List<VehicleViewModel> VVM;

        public CarController()
        {
            _coll = new VehicleCollection();
        }
        public IActionResult Index()
        {
            var all = _coll.GetAllCars();
            VVM = new List<VehicleViewModel>();

            foreach (var car in all)
            {
                VVM.Add(new VehicleViewModel
                {
                    ID = car.ID,
                    Seat = car.Seat,
                    Enginepower = car.Enginepower,
                    Acceleration = car.Acceleration,
                    Brandname = car.Brandname,
                    Cargospace = car.Cargospace,
                    Modelname = car.Modelname,
                    RentalPrice = car.RentalPrice,
                    Transmission = car.Transmission,
                    Weight = car.Weight,
                    Fueltype = car.Fueltype,
                    ImageLink = car.ImageLink

                });
            }
            return View(VVM);
        }

      
        public ActionResult Details(int ID)
        {
            
            var all = _coll.GetAllCars();
            VVM = new List<VehicleViewModel>();

            foreach (var car in all)
            {
                if (ID == car.ID)
                {
                    VVM.Add(new VehicleViewModel
                    {
                        ID = car.ID,
                        Seat = car.Seat,
                        Enginepower = car.Enginepower,
                        Acceleration = car.Acceleration,
                        Brandname = car.Brandname,
                        Cargospace = car.Cargospace,
                        Modelname = car.Modelname,
                        RentalPrice = car.RentalPrice,
                        Transmission = car.Transmission,
                        Weight = car.Weight,
                        Fueltype = car.Fueltype,
                        ImageLink = car.ImageLink
                    });
                }
                else
                {
                    
                }
            }
            return View(VVM);

        }
    }
}
