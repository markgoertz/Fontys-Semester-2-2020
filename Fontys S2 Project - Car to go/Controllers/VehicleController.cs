using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Fontys_S2_Project___Car_to_go.Converters;
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
                if (vehicle.CategoryID == 1)
                {
                    var viewmodel = ViewModelConverter.ConvertModelToVehicleViewModel(vehicle);
                    vehicleViews.Add(viewmodel);
                }        
            }
            return View(vehicleViews);
        }

        public IActionResult VanIndex()
        {
            var all = _coll.GetAllCars();
            vehicleViews = new List<VehicleViewModel>();

            foreach (var van in all)
            {
                if (van.CategoryID == 2)
                {
                    var viewmodel = ViewModelConverter.ConvertModelToVehicleViewModel(van);
                    vehicleViews.Add(viewmodel);
                }

            }
            return View(vehicleViews);
        }

        public IActionResult SpecialVehicleIndex()
        {
            var all = _coll.GetAllCars();
            vehicleViews = new List<VehicleViewModel>();

            foreach (var specialvehicle in all)
            {
                if (specialvehicle.CategoryID == 3)
                {
                    var viewmodel = ViewModelConverter.ConvertModelToVehicleViewModel(specialvehicle);
                    vehicleViews.Add(viewmodel);
                }

            }
            return View(vehicleViews);
        }


        public ActionResult Details(int? ID)
        {
            var all = _coll.GetAllCars();
            
            //If the ID isn't equil to Null-value, the if-statement is executed.
            if (ID != null)
            {
                //Here it count with int 'i' and it keeps counting 'til the max value of all is counted.
                for (int i = 0; i < all.Count; i++)
                {
                    //When ID is equil to all; the program will 'copy' all values of Vehicleviewmodel and add it to VVM.
                    if (ID == all[i].ID)
                    {
                        var viewmodel = ViewModelConverter.ConvertModelToVehicleViewModel(all[i]);
                        vehicleViews.Add(viewmodel);
                    }
                }
            }
            else
            {
                //Hier kan een exception komen voor meer voortgang.
            }

            return View(vehicleViews);
        }
    }
}
