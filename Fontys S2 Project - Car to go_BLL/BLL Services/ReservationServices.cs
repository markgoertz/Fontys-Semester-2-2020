using BLL.Collections;
using BLL.Converters;
using BLL.Models;
using Logic_interfaces.Services_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLL_Services
{
    public class ReservationServices : IReservationServices
    {
        ReservationCollection reservationcollection = new ReservationCollection();
       
        public bool CheckForDate(Reservation inputUser)
        {
            var result = reservationcollection.GetAll();
            bool status = true;
          
            foreach (var item in result)
            {
                if (item.VehicleID == inputUser.VehicleID)
                {
                    if ((item.EndDate <= inputUser.EndDate) && (item.StartDate >= inputUser.StartDate))
                    {
                        status = false;
                        return status;
                    }
                }              
            }
            return status;
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
