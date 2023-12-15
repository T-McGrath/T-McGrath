using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class ParkSqlDaoTests : BaseDaoTests
    {
        private static readonly Park PARK_1 = new Park(1, "Park 1", DateTime.Parse("1800-01-02"), 100, true);
        private static readonly Park PARK_2 = new Park(2, "Park 2", DateTime.Parse("1900-12-31"), 200, false);
        private static readonly Park PARK_3 = new Park(3, "Park 3", DateTime.Parse("2000-06-15"), 300, false);

        private ParkSqlDao dao;
        private Park testPark;

        [TestInitialize]
        public override void Setup()
        {
            dao = new ParkSqlDao(ConnectionString);
            testPark = new Park(0, "Stuff", new DateTime(2023, 04, 23), 15, true);
            base.Setup();
        }

        [TestMethod]
        public void GetParkById_With_Valid_Id_Returns_Correct_Park()
        {
            //Arrange
            // Completed via private variables above.
            //Act
            Park actual = dao.GetParkById(1);
            //Assert
            AssertParksMatch(PARK_1, actual); // (expected, actual)
        }

        [TestMethod]
        public void GetParkById_With_Invalid_Id_Returns_Null_Park()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetParksByState_With_Valid_State_Returns_Correct_Parks()
        {
            IList<Park> resultList = dao.GetParksByState("AA"); // Must be IList type rather than just List.
            Assert.AreEqual(2, resultList.Count);

            AssertParksMatch(PARK_1, resultList[0]);
            AssertParksMatch(PARK_3, resultList[1]);

            resultList = dao.GetParksByState("BB"); 
            Assert.AreEqual(1, resultList.Count);

            AssertParksMatch(PARK_2, resultList[0]);

        }

        [TestMethod]
        public void GetParksByState_With_Invalid_State_Returns_Empty_List()
        {
            IList<Park> resultList = dao.GetParksByState("XX"); // Must be IList type rather than just List.
            Assert.AreEqual(0, resultList.Count);
        }

        [TestMethod]
        public void CreatePark_Creates_Park()
        {
            Park createdPark = dao.CreatePark(testPark);
            Assert.IsNotNull(createdPark);

            int newId = createdPark.ParkId;
            Assert.IsTrue(newId > 0); // Make sure the ID got automatically set to something other than the 0 we gave it up top.

            Park retrievedPark = dao.GetParkById(createdPark.ParkId);
            AssertParksMatch(testPark, retrievedPark);
        }

        [TestMethod]
        public void UpdatePark_Updates_Park()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteParkById_Deletes_Park()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void LinkParkState_Adds_Park_To_List_Of_Parks_In_State()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UnlinkParkState_Removes_Park_From_List_Of_Parks_In_State()
        {
            Assert.Fail();
        }

        private void AssertParksMatch(Park expected, Park actual)
        {
            Assert.AreEqual(expected.ParkId, actual.ParkId);
            Assert.AreEqual(expected.ParkName, actual.ParkName);
            Assert.AreEqual(expected.DateEstablished.Date, actual.DateEstablished.Date);
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.HasCamping, actual.HasCamping);
        }
    }
}
