using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Logic_interfaces.Collection_Interfaces
{
    public interface IReservationCollection
    {
        void PlaceReservation(Reservation reservation);
        List<Reservation> GetAll();
      

    }
}
