using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fontys_S2_Project___Car_to_go.Models
{
    public class VehicleViewModel
    {
        public int ID { get; set; }
        public string Brandname { get; set; }
        public string Modelname { get; set; }
        public string Transmission { get; set; }
        public int Enginepower { get; set; }
        public int Weight { get; set; }
        public int Cargospace { get; set; }
        public int Seat { get; set; }
        public double RentalPrice { get; set; }
        public string Fueltype { get; set; }
        public string ImageLink { get; set; }
        public int CategoryID { get; set; }
    }
}
