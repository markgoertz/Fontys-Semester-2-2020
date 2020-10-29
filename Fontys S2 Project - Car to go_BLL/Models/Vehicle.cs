using BLL.Converters;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Brandname { get; set; }
        public string Modelname { get; set; }
        public string Transmission { get; set; }
        public int Enginepower { get; set; }
        public double Acceleration { get; set; }
        public int Weight { get; set; }
        public int Cargospace { get; set; }
        public int Seat { get; set; }
        public double RentalPrice { get; set; }
        public string Fueltype { get; set; }
        public string ImageLink { get; set; }
        public int CategoryID { get; set; }

        public void Delete(int ID)
        {
            DalFactory.VehicleHandler.Delete(ID);
        }

        public void Edit(Vehicle Edit)
        {
            var DTO = ModelConverter.ConvertModelToDto(Edit);
            DalFactory.VehicleHandler.Update(DTO);
        }
    }
}
