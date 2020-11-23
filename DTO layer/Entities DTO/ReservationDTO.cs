using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_layer.Entities_DTO
{
    public class ReservationDTO
    {
        public int ReservationID { get; set; }
        public string Email { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Brandname { get; set; }
        public string Modelname { get; set; }
    }
}
