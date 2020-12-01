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

        
        private DateTime? date;

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime StartDate
        {
            get { return date ?? DateTime.Today; }
            set { date = value; }
        }

        
        private DateTime? enddate;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EndDate
        {
            get { return enddate ?? DateTime.Today.Date; }
            set { enddate = value; }
        }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
