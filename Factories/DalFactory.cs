using DAL.DatabaseConnectionHandler;
using DAL.Handler;
using Interfaces.IHandlers;
using System;

namespace Factories
{
    public static class DalFactory
    {
        private static IVehicleDatabaseHandler _vehicleHandler;
        public static IVehicleDatabaseHandler VehicleHandler
        {
            get
            {
                if (_vehicleHandler == null)
                {
                    _vehicleHandler = new VehicleDatabaseHandler(new DBConnectionHandler());
                }
                return _vehicleHandler;
            }

        }
    }
}
