﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fontys_S2_Project___Car_to_go.Models;
using Logic_interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminVehiclesController : Controller
    {
        private readonly IVehicleCollection _coll;
        private readonly IVehicle vehicle;
        List<VehicleViewModel> vehicleViews = new List<VehicleViewModel>();

        public AdminVehiclesController(IVehicle ivehicle, IVehicleCollection icollection)
        {
            _coll = icollection;
            vehicle = ivehicle;
        }

/* INDEX ------------------------------------------- INDEX ------------------------------------------------------ INDEX --------------------------------------------------- INDEX ------------------------------------ INDEX*/

        public IActionResult Index()
        {
            var all = _coll.GetAllVehicles();
            vehicleViews = new List<VehicleViewModel>();

            foreach (var vehicle in all)
            {
                var viewmodel = VehicleViewModel.ConvertModelToVehicleViewModel(vehicle);
                vehicleViews.Add(viewmodel);
            }
            return View(vehicleViews);
        }

        /* CREATE ------------------------------------------- CREATE ------------------------------------------------------ CREATE --------------------------------------------------- CREATE ------------------------------------ CREATE*/

        [HttpGet]
        public ActionResult Create()
        {
            var VVM = new VehicleViewModel();
            return View(VVM);
        }
     
        [HttpPost]
        public ActionResult Create(VehicleViewModel vehicle)
        {
            var convertedmodel = VehicleViewModel.ConvertVehicleViewModelToModel(vehicle);
            _coll.Create(convertedmodel);
            TempData["Create"] = "The records has been added to the system!";
            return RedirectToAction("Index");
        }

/* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var all = _coll.GetByID(ID);
            var result = VehicleViewModel.ConvertModelToVehicleViewModel(all);  
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(VehicleViewModel viewmodel)
        {
            vehicle.Edit(VehicleViewModel.ConvertVehicleViewModelToModel(viewmodel));
            TempData["Update"] = "The records has been changed from the system!";
            return RedirectToAction("Index");
        }


/* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public IActionResult Delete(int ID)
        {           
            vehicle.Delete(ID);
            TempData["Delete"] = "The records has been deleted from the system!";
            return RedirectToAction("Index");
        }
    }
}
