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
    }
}
