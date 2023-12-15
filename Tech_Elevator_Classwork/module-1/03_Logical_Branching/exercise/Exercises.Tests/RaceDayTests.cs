using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{

    [TestClass]
    public sealed class Exercise06_RaceDayTests : TestBase
	{
		[TestMethod]
		public void ShouldDetermineRunnerInfo1_RaceBlock()
		{
			// Arrange
			RaceDay raceDay = new RaceDay();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(3, raceDay.DetermineRaceBlock(17, false), "DetermineRaceBlock(17, false) should return 3");
			Assert.AreEqual(3, raceDay.DetermineRaceBlock(17, true), "DetermineRaceBlock(17, true) should return 3");
			Assert.AreEqual(2, raceDay.DetermineRaceBlock(18, false), "DetermineRaceBlock(18, false) should return 2");
			Assert.AreEqual(1, raceDay.DetermineRaceBlock(18, true), "DetermineRaceBlock(18, true) should return 1");
			Assert.AreEqual(2, raceDay.DetermineRaceBlock(30, false), "DetermineRaceBlock(30, false) should return 2");
			Assert.AreEqual(1, raceDay.DetermineRaceBlock(30, true), "DetermineRaceBlock(30, true) should return 1");

		}

		[TestMethod]
		public void ShouldDetermineRunnerInfo2_BibNumber()
		{
			// Arrange
			RaceDay raceDay = new RaceDay();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(500, raceDay.GetBibNumber(17, 500, false), "GetBibNumber(17, 500, false) should return 500");
			Assert.AreEqual(500, raceDay.GetBibNumber(17, 500, true), "GetBibNumber(17, 500, true) should return 500");
			Assert.AreEqual(600, raceDay.GetBibNumber(18, 600, false), "GetBibNumber(17, 500, false) should return 600");
			Assert.AreEqual(1600, raceDay.GetBibNumber(18, 600, true), "GetBibNumber(18, 600, true) should return 1600");
			Assert.AreEqual(700, raceDay.GetBibNumber(30, 700, false), "GetBibNumber(30, 700, false) should return 700");
			Assert.AreEqual(1700, raceDay.GetBibNumber(30, 700, true), "GetBibNumber(30, 1700, true) should return 1700");
		}

		[TestMethod]
		public void ShouldDetermineRunnerInfo3_ConfirmedBibNumber()
		{
			// Arrange
			RaceDay raceDay = new RaceDay();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(500, raceDay.GetConfirmedBibNumber(17, 500, false), "GetConfirmedBibNumber(17, 500, false) should return 500");
			Assert.AreEqual(500, raceDay.GetConfirmedBibNumber(17, 500, true), "GetConfirmedBibNumber(17, 500, true) should return 500");
			Assert.AreEqual(600, raceDay.GetConfirmedBibNumber(18, 600, false), "GetConfirmedBibNumber(18, 600, false) should return 600");
			Assert.AreEqual(1600, raceDay.GetConfirmedBibNumber(18, 600, true), "GetConfirmedBibNumber(18, 600, true) should return 1600");
			Assert.AreEqual(700, raceDay.GetConfirmedBibNumber(30, 700, false), "GetConfirmedBibNumber(30, 700, false) should return 700");
			Assert.AreEqual(1700, raceDay.GetConfirmedBibNumber(30, 700, true), "GetConfirmedBibNumber(30, 700, true) should return 1700");
			Assert.AreEqual(-1, raceDay.GetConfirmedBibNumber(30, 1001, false), "GetConfirmedBibNumber(30, 1001, false) should return -1");
			Assert.AreEqual(2001, raceDay.GetConfirmedBibNumber(30, 1001, true), "GetConfirmedBibNumber(30, 1001, true) should return 2001");
		}
	}
}
