using System;
using System.Collections.Generic;
using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        public CabInvoGenerator generateNormalFare;
        [TestInitialize]
        public void Setup()
        {
            generateNormalFare = new CabInvoGenerator(RideType.NORMAL);
        }
        // TC1.1 - Calculate fare
        [TestMethod]
        public void GivenProperDistanceAndTimeShouldResturnFare()
        {
            double expected = 160;
            int time = 10;
            double distance = 15;
            double actual = generateNormalFare.CalculateFare(time, distance);
            Assert.AreEqual(actual, expected);
        }
        // TC1.2 - Given Imprope Time Distance Throw Esxception
        [TestMethod]
        public void GivenImproperTimeDistanceShouldThrowException()
        {
            var invalidTimeException = Assert.ThrowsException<CabInvoGeneratorException>(() => generateNormalFare.CalculateFare(0, 5));
            Assert.AreEqual(CabInvoGeneratorException.ExceptionType.INVALID_TIME, invalidTimeException.exceptionType);
            var invalidDistanceException = Assert.ThrowsException<CabInvoGeneratorException>(() => generateNormalFare.CalculateFare(12, 0));
            Assert.AreEqual(CabInvoGeneratorException.ExceptionType.INVALID_DISTANCE, invalidDistanceException.exceptionType);
        }
        // TC2.1 - Given multiple rides should return aggregate fare
        [TestMethod]
        public void GivenMultipleRidesReturnAggregateFare()
        {
            Ride[] cabRides = { new Ride(10, 15), new Ride(10, 15) };
            InvoiceSummary expected = new InvoiceSummary(cabRides.Length, 320);
            var actual = generateNormalFare.CalculateAgreegateFare(cabRides);

            Assert.AreEqual(actual, expected);
        }

        // TC2.2 - given no rides return custom exception
        [TestMethod]
        public void GivenNoRidesReturnCustomException()
        {
            Ride[] cabRides = { };
            var nullRidesException = Assert.ThrowsException<CabInvoGeneratorException>(() => generateNormalFare.CalculateAgreegateFare(cabRides));
            Assert.AreEqual(CabInvoGeneratorException.ExceptionType.NULL_RIDES, nullRidesException.exceptionType);
        }
        [TestMethod]
        [DataRow(1, 2, 320, 10, 15, 10, 15)]
        public void GivenUserIdReturnInvoiceSummary(int userId, int cabRideCount, double totalFare, int time1, double distance1, int time2, double distance2)
        {
            RideRepo rideRepository = new RideRepo();
            Ride[] userRides = { new Ride(time1, distance1), new Ride(time2, distance2) };
            rideRepository.AddUserRidesToRepository(userId, userRides, RideType.NORMAL);
            List<Ride> list = new List<Ride>();
            list.AddRange(userRides);
            InvoiceSummary userInvoice = new InvoiceSummary(cabRideCount, totalFare);

            UserCabInvoService expected = new UserCabInvoService(list, userInvoice);
            UserCabInvoService actual = rideRepository.ReturnInvoicefromRideRepository(userId);
            Assert.AreEqual(actual.InvoiceSummary.totalFare, expected.InvoiceSummary.totalFare);
        }
    }
}