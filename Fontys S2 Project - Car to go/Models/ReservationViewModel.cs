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
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        private DateTime? date;
        public DateTime StartDate
        {
            get { return date ?? DateTime.Today; }
            set { date = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        private DateTime? enddate;
        public DateTime EndDate
        {
            get { return enddate ?? DateTime.Today.Date; }
            set { enddate = value; }
        }
    }
}
