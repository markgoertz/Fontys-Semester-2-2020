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
    }
}
