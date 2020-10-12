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
        private readonly CarCollection _coll;

        public CarController()
        {
            _coll = new CarCollection();
        }
        public IActionResult Index()
        {
            var all = _coll.GetAllCars();
            var cars = new List<CarViewmodel>();

            foreach (var car in all)
            {
                cars.Add(new CarViewmodel
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
            return View(cars);
        }

    }
}
