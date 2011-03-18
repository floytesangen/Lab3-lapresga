using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2011, 3, 19);
        private readonly DateTime endDate = new DateTime(2011, 3, 20);
        private readonly int someMiles = 100;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor1Days()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor2Days()
        {
            var target = new Flight(startDate, new DateTime(2011, 3, 21), someMiles);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor10Days()
        {
            endDate.AddDays(8);
            var target = new Flight(new DateTime(2011, 3, 15), new DateTime(2011, 3, 25), someMiles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMilesCannotBeNegative()
        {
            var target = new Flight(startDate, endDate, -10);
       }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEndDateCannotBeBeforeStartDate()
        {
            var target = new Flight(endDate, startDate, someMiles);
        }
        [Test()]
        public void TestEquals()
        {
            var target1 = new Flight(startDate, endDate, someMiles);
            var target2 = new Flight(startDate, endDate, someMiles);
            var target3 = new Flight(startDate, new DateTime(2011, 3, 26), someMiles);

            Assert.AreEqual(target1, target2);
            Assert.AreNotEqual(target1, target3);
        }

	}
}
