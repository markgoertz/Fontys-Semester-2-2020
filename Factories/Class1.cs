using DAL.Handler;
using Interfaces.IHandlers;
using System;

namespace Factories
{
    public static class CarFactory
    {
        private static ICarDatabaseHandler _carHandler;
        public static ICarDatabaseHandler CarHandler
        {
            get
            {
                if (_carHandler == null)
                {
                    _carHandler = new CarDatabaseHandler(new DBConnectionHandler());
                }
                return _carHandler;
            }

        }
    }
}
