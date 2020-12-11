using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IVehicleCollection
    {
        void Create(Vehicle car);
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllCars();
        List<Vehicle> GetAllVans();
        List<Vehicle> GetAllSpecials();
        Vehicle GetByID(int ID);
    }
}
