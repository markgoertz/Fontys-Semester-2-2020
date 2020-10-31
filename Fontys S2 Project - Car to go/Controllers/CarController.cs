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


        public ActionResult Details(int? ID)
        {
            var all = _coll.GetAllCars();
            VVM = new List<VehicleViewModel>();

            //If the ID isn't equil to Null-value, the if-statement is executed.
            if (ID != null)
            {
                //Here it count with int 'i' and it keeps counting 'til the max value of all is counted.
                for (int i = 0; i < all.Count; i++)
                {
                    //When ID is equil to all; the program will 'copy' all values of Vehicleviewmodel and add it to VVM.
                    if (ID == all[i].ID)
                    {
                        VVM.Add(new VehicleViewModel
                        {
                            ID = all[i].ID,
                            Seat = all[i].Seat,
                            Enginepower = all[i].Enginepower,
                            Acceleration = all[i].Acceleration,
                            Brandname = all[i].Brandname,
                            Cargospace = all[i].Cargospace,
                            Modelname = all[i].Modelname,
                            RentalPrice = all[i].RentalPrice,
                            Transmission = all[i].Transmission,
                            Weight = all[i].Weight,
                            Fueltype = all[i].Fueltype,
                            ImageLink = all[i].ImageLink
                        });
                    }
                }
            }
            else
            {
                throw new Exception();
            }

            return View(VVM);
        }
    }
}
