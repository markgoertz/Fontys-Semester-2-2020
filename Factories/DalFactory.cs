﻿using DAL.DatabaseConnectionHandler;
using DAL.Handler;
using Interfaces.IHandlers;
using System;

namespace Factories
{
    public static class DalFactory
    {
        private static IVehicleDatabaseHandler _vehicleHandler;
        private static IUserDatabaseHandler _userHandler;
        public static IVehicleDatabaseHandler VehicleHandler
        {
            get
            {
                {
                    _vehicleHandler = new VehicleDatabaseHandler(new DBConnectionHandler());
                }
                return _vehicleHandler;
            }

        }

        public static IUserDatabaseHandler userDatabaseHandler
        {
            get
            {            
                {
                    _userHandler = new UserDatabaseHandler(new DBConnectionHandler());
                }
                return _userHandler;
            }
        }
    }
}
