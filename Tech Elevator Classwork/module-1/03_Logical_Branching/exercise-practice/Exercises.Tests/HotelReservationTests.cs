using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise04_HotelReservationTests : TestBase
    {
        [TestMethod]
        public void ShouldCalculateCorrectTotal1_Simple()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1), CentsDelta, "A 1 night stay should cost $99.99");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2), CentsDelta, "A 2 night stay should cost $199.98");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3), CentsDelta, "A 3 night stay should get the discount rate and cost $269.97");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4), CentsDelta, "A 4 night stay should get the discount rate and cost $359.96");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10), CentsDelta, "A 10 night stay should get the discount rate and cost $899.90");
        }

        [TestMethod]
        public void ShouldCalculateCorrectTotal2_WithParking()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1, false), CentsDelta, "CalculateStayTotal(1, false) should return 99.99");
            Assert.AreEqual(124.99, hotel.CalculateStayTotal(1, true), CentsDelta, "CalculateStayTotal(1, true) should return 124.99");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, false), CentsDelta, "CalculateStayTotal(2, false) should return 199.98");
            Assert.AreEqual(249.98, hotel.CalculateStayTotal(2, true), CentsDelta, "CalculateStayTotal(2, true) should return 249.98");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, false), CentsDelta, "CalculateStayTotal(3, false) should return 269.97");
            Assert.AreEqual(344.97, hotel.CalculateStayTotal(3, true), CentsDelta, "CalculateStayTotal(3, true) should return 344.97");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, false), CentsDelta, "CalculateStayTotal(4, false) should return 359.96");
            Assert.AreEqual(459.96, hotel.CalculateStayTotal(4, true), CentsDelta, "CalculateStayTotal(4, true) should return 459.96");
        }

        [TestMethod]
        public void ShouldCalculateCorrectTotal3_WithLateCheckout()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, false, false), CentsDelta, "calculateStayTotal(2, false, false) should return 199.98");
            Assert.AreEqual(219.98, hotel.CalculateStayTotal(2, false, true), CentsDelta, "calculateStayTotal(2, false, true) should return 219.98");
            Assert.AreEqual(249.98, hotel.CalculateStayTotal(2, true, false), CentsDelta, "calculateStayTotal(2, true, false) should return 249.98");
            Assert.AreEqual(269.98, hotel.CalculateStayTotal(2, true, true), CentsDelta, "calculateStayTotal(2, true, true) should return 269.98");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, false, false), CentsDelta, "calculateStayTotal3, false, false) should return 269.97");
            Assert.AreEqual(289.97, hotel.CalculateStayTotal(3, false, true), CentsDelta, "calculateStayTotal(3, false, true) should return 289.97");
            Assert.AreEqual(344.97, hotel.CalculateStayTotal(3, true, false), CentsDelta, "calculateStayTotal(3 true, false) should return 344.97");
            Assert.AreEqual(364.97, hotel.CalculateStayTotal(3, true, true), CentsDelta, "calculateStayTotal(3, true, true) should return 364.97");
        }
    }
}
