using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Logic_interfaces
{
    public interface IReservation
    {
         int ReservationID { get; set; }
         string Email { get; set; }
         int VehicleID { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
         string ModelName { get; set; }
         string BrandName { get; set; }

        void Delete(int ID);
    }
}
