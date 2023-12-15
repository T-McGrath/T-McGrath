using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class ParkSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetParks_Should_ReturnAllParksInLocationAlphabeticalOrder()
        {
            ParkSqlDao dao = new ParkSqlDao(ConnectionString);
            IList<Park> parkList = dao.GetParks();
            Assert.AreEqual(2, parkList.Count);

            Assert.AreEqual("Ohio", parkList[0].Location);
            Assert.AreEqual("Pennsylvania", parkList[1].Location);
        }
    }
}
