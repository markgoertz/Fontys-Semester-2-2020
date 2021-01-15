using BLL.BLL_Services;
using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Application.Layer.Tests.Collections
{
    [TestClass]
    public class ReservationTesting
    {
        private readonly ReservationServices reservationServices = new ReservationServices();
        private readonly Reservation model = new Reservation();

        [TestMethod]
        public void ChecksIfGivenDateIsLaterThenStartDate()
        {
            
            bool result = reservationServices.IsEndDateGreaterThenStartDate(Mockdata.MockDataReservations.Isgreaterthenstartdate);
            Assert.AreEqual(false , result);
        }

        [TestMethod]
        public void ChecksIfGivenDateIsEarlierThenStartDate()
        {
            bool result = reservationServices.IsEndDateGreaterThenStartDate(Mockdata.MockDataReservations.IsNotgreaterthenstartdate);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ChecksStartDateIsToday()
        {
            bool result = reservationServices.CorrectStartDate(Mockdata.MockDataReservations.TodaysDate);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void ChecksStartDateIsEarlier()
        {
            bool result = reservationServices.IsEndDateGreaterThenStartDate(Mockdata.MockDataReservations.EarlierThenToday);
            Assert.AreEqual(false, result);
        }
        


    }
}
