using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Mockdata
{
    public static class MockDataReservations
    {
        public static Reservation Isgreaterthenstartdate = new Reservation()
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Parse("2020-01-20")
        };

        public static Reservation IsNotgreaterthenstartdate = new Reservation()
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Parse("2024-01-20")
        };
        public static Reservation TodaysDate = new Reservation()
        {
            StartDate = DateTime.Now.Date
           
        };

        public static Reservation EarlierThenToday = new Reservation()
        {
            StartDate = DateTime.Parse("20 June 2000")

        };
        public static Reservation LaterThenToday = new Reservation()
        {
            StartDate = DateTime.FromFileTime(2030-05-10)

        };


    }
}