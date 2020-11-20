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
            var checkstartdate = _reservationlogic.CorrectStartDate(reservation);
            var checkenddate = _reservationlogic.IsEndDateGreaterThenStartDate(reservation);
            if (checkstartdate && checkenddate == true)
            {
                _reservationlogic.PlaceReservation(reservation);
                return RedirectToAction("Succes", "Reservation");
            }

            else 
            {
                if (checkstartdate == false)
                {
                    TempData["IncorrectStartData"] = "The Startdate can not be earlier then today's date!";
                    return View();
                }
                else
                {
                    TempData["IncorrectData"] = "The EndDate can not be earlier then the startDate!";
                    return View();
                }

            }
        }

        public ActionResult Succes()
        {
            return View();
        }

    }

}




