using BLL.Converters;
using BLL.Models;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Collections
{
    public class ReservationCollection
    {
        public void PlaceReservation(Reservation reservation)
        {
            var result = ReservationConverter.ConvertModelToDto(reservation);
            DalFactory.ReservationHandler.PlaceReservation(result);
        }

        public bool IsEndDateGreaterThenStartDate(Reservation reservation)
        {
            var status = false;
            var StartDate = reservation.StartDate;
            var EndDate = reservation.EndDate;

            if (EndDate > StartDate)
            {
                status = true;
                return status;
            }

            return status;
        }

        public bool CorrectStartDate(Reservation reservation)
        {
            var status = false;
            var StartDate = reservation.StartDate;
            var TodaysDate = DateTime.Now.Date;

            if (StartDate >= TodaysDate)
            {
                status = true;
                return status;
            }

            return status;
        }
    }
}
