using BLL.Converters;
using BLL.Logic_interfaces.Collection_Interfaces;
using BLL.Models;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Collections
{
    public class ReservationCollection : IReservationCollection
    {
        private List<Reservation> reservations;

        public void PlaceReservation(Reservation reservation)
        {
            var result = ReservationConverter.ConvertModelToDto(reservation);
            DalFactory.ReservationHandler.PlaceReservation(result);
        }

        public List<Reservation> GetAll()
        {
            var result = DalFactory.ReservationHandler.GetallReservations();
            reservations = new List<Reservation>();

            foreach (var dto in result)
            {
                var model = ReservationConverter.ConvertDtoToModel(dto);
                reservations.Add(model);
            }

            return reservations;
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
            else
            {
                
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

        public bool CheckAvailable(Reservation reservation)
        {
            var result = ReservationConverter.ConvertModelToDto(reservation);
            return DalFactory.ReservationHandler.CheckForDoubleReservations(result);
        } 
    }
}
