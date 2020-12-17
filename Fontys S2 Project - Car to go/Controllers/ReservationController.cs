using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using BLL.Logic_interfaces;
using BLL.Logic_interfaces.Collection_Interfaces;
using Logic_interfaces.Services_Interfaces;

using Fontys_S2_Project___Car_to_go.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{

    [Authorize(Roles = "User")]

    public class ReservationController : Controller
    { 
        private readonly IReservationCollection _reservationlogic;
        private readonly IReservation _reservationmodel;
        private readonly IReservationServices services;
        
        public ReservationController(IReservation reservation, IReservationCollection reservationCollection, IReservationServices reservationservices)
        {
            _reservationlogic = reservationCollection;
            _reservationmodel = reservation;
            services = reservationservices;
        }

        public ActionResult Index()
        {
            var all = _reservationlogic.GetAll();
            var reservationViews = new List<ReservationViewModel>();

            foreach (var item in all)
            {
                if (User.HasClaim(ClaimTypes.Email, item.Email))
                {
                    reservationViews.Add(ReservationViewModel.ConvertModelToReservationViewModel(item));
                }
            }
            return View(reservationViews);
        }

        public ActionResult PlaceReservation(int ID)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Email);
           
                var registrationViewModel = new ReservationViewModel()
                {
                    VehicleID = ID, Email = claim.Value
                };
               
           return View(registrationViewModel);
        }

        [HttpPost]
        public ActionResult PlaceReservation(ReservationViewModel reservationviewmodel)
        {
            var convertedmodel = ReservationViewModel.ConvertReservationViewModelToModel(reservationviewmodel);
            bool result = services.CheckForDate(convertedmodel);
            bool resulttodaydate = services.CorrectStartDate(convertedmodel);
            bool resultdateplacement = services.IsEndDateGreaterThenStartDate(convertedmodel);

            if (result && resultdateplacement && resulttodaydate == true)
            {
                _reservationlogic.PlaceReservation(convertedmodel);
                return RedirectToAction("Succes");
            }
            else
            {
                TempData["ErrorReservation"] = "An Error has occured have you put in the correct input?";
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            _reservationmodel.Delete(ID);
            TempData["Delete"] = "The records are deleted from the system!";
            return RedirectToAction("Index", "Reservation");
        }
        public ActionResult Succes()
        {
            return View();
        }

    }

}




