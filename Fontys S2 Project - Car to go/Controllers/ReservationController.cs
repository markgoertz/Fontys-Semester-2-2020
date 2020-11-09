using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Collections;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationCollection _reservationlogic;

        public ReservationController()
        {
            _reservationlogic = new ReservationCollection();
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult PlaceReservation(int ID)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Email);
            var registrationViewModel = new ReservationViewModel()
            {
                VehicleID = ID,
                Email = claim.Value

            };

            return View(registrationViewModel);
        }

        [HttpPost]
        public ActionResult PlaceReservation(Reservation reservation)
        {
            _reservationlogic.PlaceReservation(reservation);
            return RedirectToAction("Succes", "Reservation");

        }

        public ActionResult Succes()
        {
            return View();
        }

    }

}




