using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
    public sealed class Exercise00_GettingStartedTests : TestBase
    {
		[TestMethod]
		public void Exercise00_isRainExpected()
		{
			// Arrange
			GettingStarted gettingStarted = new GettingStarted();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion

			// Warm cases
			Assert.IsTrue(gettingStarted.IsRainExpected(true, 45), "Rain should be expected when it is precipitating and above freezing");
			Assert.IsFalse(gettingStarted.IsRainExpected(false, 45), "Rain should not be expected when it is not precipitating");
			// Cold cases
			Assert.IsFalse(gettingStarted.IsRainExpected(true, 16), "Rain should not be expected when it is below freezing");
			Assert.IsFalse(gettingStarted.IsRainExpected(false, 16), "Rain should not be expected when it is not precipitating");
			// Edge cases
			Assert.IsFalse(gettingStarted.IsRainExpected(true, 32), "Rain should not be expected when it at the freezing point");
			Assert.IsFalse(gettingStarted.IsRainExpected(false, 32), "Rain should not be expected when it is not precipitating");
		}

	}
}
