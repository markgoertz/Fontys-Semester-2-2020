using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{
    public class ReservationViewModel
    {
        public int ReservationID { get; set; }
        public string Email { get; set; }
        public int VehicleID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
