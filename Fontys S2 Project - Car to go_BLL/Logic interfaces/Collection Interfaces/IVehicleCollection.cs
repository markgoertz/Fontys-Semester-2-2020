using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces
{
    public interface IVehicleCollection
    {
        void Create(Vehicle car);
        List<Vehicle> GetAllCars();
    }
}
