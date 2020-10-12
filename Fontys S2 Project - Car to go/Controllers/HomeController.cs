using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLL;
using Fontys_S2_Project___Car_to_go.Models;

namespace Car_to_go.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarCollection _coll;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
