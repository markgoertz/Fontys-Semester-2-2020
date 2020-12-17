using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fontys_S2_Project___Car_to_go.Models;
using Logic_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Car_to_go.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleCollection _coll;
        List<VehicleViewModel> vehicleViews = new List<VehicleViewModel>();

        public VehicleController(IVehicleCollection collection)
        {
            _coll = collection;
        }
        public IActionResult CarIndex()
        {
            var all = _coll.GetAllCars();
            foreach (var vehicle in all)
            {
               vehicleViews.Add(VehicleViewModel.ConvertModelToVehicleViewModel(vehicle));
            }
            return View(vehicleViews);
        }

        public IActionResult VanIndex()
        {
            var all = _coll.GetAllVans();
            foreach (var vehicle in all)
            {
                vehicleViews.Add(VehicleViewModel.ConvertModelToVehicleViewModel(vehicle));
            }
            return View(vehicleViews);
        }

        public IActionResult SpecialVehicleIndex()
        {
            var all = _coll.GetAllSpecials();
            foreach (var vehicle in all)
            {
               vehicleViews.Add(VehicleViewModel.ConvertModelToVehicleViewModel(vehicle));
            }
            return View(vehicleViews);
        }


        public ActionResult Details(int ID)
        {
            var all = _coll.GetByID(ID);
            
            var viewmodel = VehicleViewModel.ConvertModelToVehicleViewModel(all);
            vehicleViews.Add(viewmodel);
                    
            return View(vehicleViews);
        }
    }
}
