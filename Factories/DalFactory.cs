using DAL.DatabaseConnectionHandler;
using DAL.Handler;
using Interfaces.IHandlers;
using System;

namespace Factories
{
    public static class DalFactory
    {
        private static IVehicleHandler _vehicleHandler;
        private static IUserHandler _userHandler;
        private static IReservationHandler _reservationHandler;
        public static IVehicleHandler VehicleHandler
        {
            get
            {
                {
                    _vehicleHandler = new VehicleDatabaseHandler(new DBConnectionHandler());
                }
                return _vehicleHandler;
            }

        }

        public static IUserHandler UserDatabaseHandler
        {
            get
            {
                {
                    _userHandler = new UserDatabaseHandler(new DBConnectionHandler());
                }
                return _userHandler;
            }
        }

        public static IReservationHandler ReservationHandler
        {
            get
            {
                {
                    _reservationHandler = new ReservationDatabaseHandler(new DBConnectionHandler());
                }
                return _reservationHandler;
            }
        }
    }
}
