using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Collections;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Converters;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{

    [Authorize(Roles = "User")]

    public class ReservationController : Controller
    { 
        private readonly ReservationCollection _reservationlogic;
        private readonly Reservation _reservationmodel;
        List<ReservationViewModel> reservationViews = new List<ReservationViewModel>();

        public ReservationController()
        {
            _reservationlogic = new ReservationCollection();
            _reservationmodel = new Reservation();
        }

        public ActionResult Index()
        {
            var all = _reservationlogic.GetAll();
            var reservationViews = new List<ReservationViewModel>();


            foreach (var item in all)
            {
                if (User.HasClaim(ClaimTypes.Email, item.Email))
                {
                    var viewmodel = ViewModelConverter.ConvertModelToReservationViewModel(item);
                    reservationViews.Add(viewmodel);
                    
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
                    VehicleID = ID,
                    Email = claim.Value
                    
                };
               
           return View(registrationViewModel);
        }

        [HttpPost]  //incorrect according to SOLID-principle. To be worked on in future itterations.
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




