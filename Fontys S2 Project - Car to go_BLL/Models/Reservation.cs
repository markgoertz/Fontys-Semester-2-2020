using BLL.Converters;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string Email { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
