using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Logic_interfaces;
using BLL.Logic_interfaces.Collection_Interfaces;
using Fontys_S2_Project___Car_to_go.Converters;
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
        
        public ReservationController(IReservation reservation, IReservationCollection reservationCollection)
        {
            _reservationlogic = reservationCollection;
            _reservationmodel = reservation;
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
                    VehicleID = ID, Email = claim.Value
                };
               
           return View(registrationViewModel);
        }

        [HttpPost]  //incorrect according to SOLID-principle. To be worked on in future itterations.
        public ActionResult PlaceReservation(ReservationViewModel reservationviewmodel)
        {
            var convertedmodel = ViewModelConverter.ConvertReservationViewModelToModel(reservationviewmodel);

            var checkstartdate = _reservationlogic.CorrectStartDate(convertedmodel);
            var checkenddate = _reservationlogic.IsEndDateGreaterThenStartDate(convertedmodel);

            if (checkstartdate && checkenddate == true)
            {
                bool status = _reservationlogic.CheckAvailable(convertedmodel);
                if (status == false)
                {
                    _reservationlogic.PlaceReservation(convertedmodel);
                    return RedirectToAction("Succes", "Reservation");
                }

                else
                {
                    TempData["TakenReservation"] = "Someone was before you! Please choose an different date!";
                    return View();
                }
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




