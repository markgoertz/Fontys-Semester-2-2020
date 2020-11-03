using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{
    public class AdminController : Controller
    {
        private readonly VehicleCollection _coll;
        private readonly Vehicle vehicle;
        private List<VehicleViewModel> VVM;
        public AdminController()
        {
            _coll = new VehicleCollection();
            vehicle = new Vehicle();
        }

/* INDEX ------------------------------------------- INDEX ------------------------------------------------------ INDEX --------------------------------------------------- INDEX ------------------------------------ INDEX*/

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
                    ImageLink = car.ImageLink,
                    CategoryID = (VehicleViewModel.Category)car.CategoryID

                });
            }
            return View(VVM);
        }

/* CREATE ------------------------------------------- CREATE ------------------------------------------------------ CREATE --------------------------------------------------- CREATE ------------------------------------ CREATE*/

        [HttpGet]
        public ActionResult Create()
        {
            var VVM = new VehicleViewModel();
            return View(VVM);
          
        }
     
        [HttpPost]
        public ActionResult Create(Vehicle car)
        {
            _coll.Create(car);
            return RedirectToAction("Index");

        }

/* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var all = _coll.GetAllCars();
         
            foreach (var car in all)
            {
                if (ID == car.ID)
                {
                    var carvm = new VehicleViewModel()
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
                        ImageLink = car.ImageLink,
                        CategoryID = (VehicleViewModel.Category)car.CategoryID
                    };

                    return View(carvm);
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Update(Vehicle vehicleViewModel)
        {
             vehicle.Edit(vehicleViewModel);
            return RedirectToAction("Index");
        }


        /* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public IActionResult Delete(int ID)
        {           
            vehicle.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}
