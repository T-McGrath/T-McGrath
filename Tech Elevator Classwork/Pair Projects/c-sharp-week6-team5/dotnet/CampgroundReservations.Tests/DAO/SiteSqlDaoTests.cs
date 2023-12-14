using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class SiteSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetSitesWithRVAccessByParkId_Should_ReturnSitesWithPositiveRVLength()
        {
            SiteSqlDao dao = new SiteSqlDao(ConnectionString);
            IList<Site> siteList = dao.GetSitesWithRVAccessByParkId(1);

            Assert.AreEqual(2, siteList.Count, "Incorrect amount of sites in returned list.");
            Assert.AreEqual(1, siteList[0].SiteId, "Incorrect site at first index in returned list.");
            Assert.AreEqual(2, siteList[1].SiteId, "Incorrect site at second index in returned list.");
        }

        [TestMethod]
        public void GetSitesAvailableTodayByParkId_Should_ReturnAvailableParks()
        {
            // Arrange
            SiteSqlDao dao = new SiteSqlDao(ConnectionString);

            // Act
            IList<Site> sites = dao.GetSitesAvailableTodayByParkId(1);

            // Assert
            Assert.AreEqual(7, sites.Count, "Incorrect count of currently available sites");
        }
    }
}
