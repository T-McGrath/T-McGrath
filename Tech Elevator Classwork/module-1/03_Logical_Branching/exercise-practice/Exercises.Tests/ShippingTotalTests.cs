using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{

    [TestClass]
    public sealed class Exercise03_ShippingTotalTests : TestBase
	{
		[TestMethod]
		public void ShouldCalculateCorrectShipping1_Rate()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(0.5, shipping.CalculateShippingRate(20), 0.001, "CalculateShippingRate(20) should return 0.5");
			Assert.AreEqual(0.5, shipping.CalculateShippingRate(39), 0.001, "CalculateShippingRate(39) should return 0.5");
			Assert.AreEqual(0.5, shipping.CalculateShippingRate(40), 0.001, "CalculateShippingRate(40) should return 0.5");
			Assert.AreEqual(0.75, shipping.CalculateShippingRate(41), 0.001, "CalculateShippingRate(41) should return 0.75");
			Assert.AreEqual(0.75, shipping.CalculateShippingRate(50), 0.001, "CalculateShippingRate(50) should return 0.75");
		}

		[TestMethod]
		public void ShouldCalculateCorrectShipping2_SimpleTotal()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(10, shipping.CalculateShippingTotal(20), CentsDelta, "CalculateShippingTotal(20) should return 10.0");
			Assert.AreEqual(19.5, shipping.CalculateShippingTotal(39), CentsDelta, "CalculateShippingTotal(39) should return 19.5");
			Assert.AreEqual(20, shipping.CalculateShippingTotal(40), CentsDelta, "CalculateShippingTotal(40) should return 20.0");
			Assert.AreEqual(30.75, shipping.CalculateShippingTotal(41), CentsDelta, "CalculateShippingTotal(41) should return 30.75");
			Assert.AreEqual(33.75, shipping.CalculateShippingTotal(45), CentsDelta, "CalculateShippingTotal(45) should return 33.75");
			Assert.AreEqual(37.5, shipping.CalculateShippingTotal(50), CentsDelta, "CalculateShippingTotal(50) should return 37.5");
		}

		[TestMethod]
		public void ShouldCalculateCorrectShipping3_Discount()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(10, shipping.CalculateShippingTotal(20, false), CentsDelta, "calculateShippingTotal(20, false) should return 10.0");
			Assert.AreEqual(9, shipping.CalculateShippingTotal(20, true), CentsDelta, "calculateShippingTotal(20, true) should return 9.0");
			Assert.AreEqual(12.5, shipping.CalculateShippingTotal(25, false), CentsDelta, "calculateShippingTotal(25, false) should return 12.5");
			Assert.AreEqual(11.25, shipping.CalculateShippingTotal(25, true), CentsDelta, "calculateShippingTotal(25, true) should return 11.25");
			Assert.AreEqual(20, shipping.CalculateShippingTotal(40, false), CentsDelta, "calculateShippingTotal(40, false) should return 20.0");
			Assert.AreEqual(18, shipping.CalculateShippingTotal(40, true), CentsDelta, "calculateShippingTotal(40, true) should return 18.0");
			Assert.AreEqual(30.75, shipping.CalculateShippingTotal(41, false), CentsDelta, "calculateShippingTotal(41, false) should return 30.75");
			Assert.AreEqual(27.675, shipping.CalculateShippingTotal(41, true), CentsDelta, "calculateShippingTotal(41, true) should return 27.675");
			Assert.AreEqual(33.75, shipping.CalculateShippingTotal(45, false), CentsDelta, "calculateShippingTotal(45, false) should return 33.75");
			Assert.AreEqual(30.375, shipping.CalculateShippingTotal(45, true), CentsDelta, "calculateShippingTotal(45, true) should return 30.375");
		}
	}
}
