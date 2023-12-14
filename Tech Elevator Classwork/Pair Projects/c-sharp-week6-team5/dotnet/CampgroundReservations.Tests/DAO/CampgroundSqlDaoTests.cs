using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class CampgroundSqlDaoTests : BaseDaoTests
    {
        private Campground campground_1 = new Campground(1, 1, "Test Campground", 1, 12, 35);
        private Campground campground_2 = new Campground(2, 1, "Test Campground", 1, 12, 35);
        
        private void AssertCampgroundsMatch(Campground expected, Campground actual)
        {
            Assert.AreEqual(expected.CampgroundId, actual.CampgroundId);
            Assert.AreEqual(expected.ParkId, actual.ParkId);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.OpenFromMonth, actual.OpenFromMonth);
            Assert.AreEqual(expected.OpenToMonth, actual.OpenToMonth);
            Assert.AreEqual(expected.DailyFee, actual.DailyFee);
        }
        
        [TestMethod]
        public void GetCampgroundById_Should_ReturnSpecificCampground()
        {
            // Arrange
            CampgroundSqlDao dao = new CampgroundSqlDao(ConnectionString);

            // Act
            Campground campground = dao.GetCampgroundById(1);

            // Assert
            Assert.AreEqual(1, campground.ParkId, "Incorrect campground returned for ID 1");
        }

        [TestMethod]
        public void GetCampgroundsByParkId_Should_ReturnAllCampgroundsForPark()
        {
            CampgroundSqlDao dao = new CampgroundSqlDao(ConnectionString);
            IList<Campground> campgroundList = dao.GetCampgroundsByParkId(1);
            Assert.AreEqual(2, campgroundList.Count);

            AssertCampgroundsMatch(campground_1, campgroundList[0]);
            AssertCampgroundsMatch(campground_2, campgroundList[1]);
        }
    }
}
