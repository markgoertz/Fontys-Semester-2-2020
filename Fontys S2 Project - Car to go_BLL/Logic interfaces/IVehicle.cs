using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IVehicle
    {
        public int ID { get; set; }
        public string Brandname { get; set; }
        public string Modelname { get; set; }
        public string Transmission { get; set; }
        public int Enginepower { get; set; }
        public decimal Acceleration { get; set; }
        public int Weight { get; set; }
        public int Cargospace { get; set; }
        public int Seat { get; set; }
        public double RentalPrice { get; set; }
        public string Fueltype { get; set; }
        public string ImageLink { get; set; }
        public int CategoryID { get; set; }
        void Delete(int ID);
        void Edit(Vehicle Edit);
    }
}
