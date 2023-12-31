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
            testPark = new Park(0, "Test Park", DateTime.Now, 900, true);
            base.Setup();
        }

        [TestMethod]
        public void GetParkById_With_Valid_Id_Returns_Correct_Park()
        {
            Park result = dao.GetParkById(1);
            AssertParksMatch(PARK_1, result);
        }

        [TestMethod]
        public void GetParkById_With_Invalid_Id_Returns_Null_Park()
        {
            Park park = dao.GetParkById(99);
            Assert.IsNull(park);
        }

        [TestMethod]
        public void GetParksByState_With_Valid_State_Returns_Correct_Parks()
        {
            IList<Park> result = dao.GetParksByState("AA");
            Assert.AreEqual(2, result.Count);
            AssertParksMatch(PARK_1, result[0]);
            AssertParksMatch(PARK_3, result[1]);

            result = dao.GetParksByState("BB");
            Assert.AreEqual(1, result.Count);
            AssertParksMatch(PARK_2, result[0]);
        }

        [TestMethod]
        public void GetParksByState_With_Invalid_State_Returns_Empty_List()
        {
            IList<Park> parks = dao.GetParksByState("XX");
            Assert.AreEqual(0, parks.Count);
        }

        [TestMethod]
        public void CreatePark_Creates_Park()
        {
            Park fakePark = new Park();
            fakePark.Area = 100;
            fakePark.ParkName = "Foxy's Dog Park";
            fakePark.DateEstablished = new DateTime(2023, 02, 20);
            fakePark.HasCamping = true;


            Park createdPark = dao.CreatePark(fakePark);

            Assert.AreEqual(fakePark.ParkName, createdPark.ParkName);
            Assert.AreEqual(fakePark.DateEstablished.Date, createdPark.DateEstablished.Date);
            Assert.AreEqual(fakePark.Area, createdPark.Area, "area does not match");
            Assert.AreEqual(fakePark.HasCamping, createdPark.HasCamping);



            //Park createdPark = dao.CreatePark(testPark);
            //Assert.IsNotNull(createdPark);

            //int newId = createdPark.ParkId;
            //Assert.IsTrue(newId > 0);

            //Park retrievedPark = dao.GetParkById(newId);
            //AssertParksMatch(createdPark, retrievedPark);
        }

        [TestMethod]
        public void UpdatePark_Updates_Park()
        {
            Park parkToUpdate = dao.GetParkById(1);

            parkToUpdate.ParkName = "Updated";
            parkToUpdate.DateEstablished = DateTime.Now;
            parkToUpdate.Area = 900;
            parkToUpdate.HasCamping = false;

            Park updatedPark = dao.UpdatePark(parkToUpdate);
            Assert.IsNotNull(updatedPark);

            Park retrievedPark = dao.GetParkById(1);
            AssertParksMatch(updatedPark, retrievedPark);
        }

        [TestMethod]
        public void DeleteParkById_Deletes_Park()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void LinkParkState_Adds_Park_To_List_Of_Parks_In_State()
        {
            int preLinkParkCount = dao.GetParksByState("CC").Count;
            dao.LinkParkState(1, "CC");
            IList<Park> parks = dao.GetParksByState("CC");
            int postLinkParkCount = parks.Count;
            Assert.AreEqual(preLinkParkCount + 1, postLinkParkCount);
            AssertParksMatch(PARK_1, parks[0]);

        }

        [TestMethod]
        public void UnlinkParkState_Removes_Park_From_List_Of_Parks_In_State()
        {
            int preUnlinkParkCount = dao.GetParksByState("AA").Count;

            dao.UnlinkParkState(1, "AA");
            IList<Park> parks = dao.GetParksByState("AA");
            int postUnlinkParkCount = parks.Count;

            Assert.AreEqual(preUnlinkParkCount - 1, postUnlinkParkCount);
            AssertParksMatch(PARK_3, parks[0]);
        }

        private void AssertParksMatch(Park expected, Park actual)
        {
            Assert.AreEqual(expected.ParkId, actual.ParkId);
            Assert.AreEqual(expected.ParkName, actual.ParkName);
            Assert.AreEqual(expected.DateEstablished.Date, actual.DateEstablished.Date);
            Assert.AreEqual(expected.Area, actual.Area, "area does not match");
            Assert.AreEqual(expected.HasCamping, actual.HasCamping);
        }
    }
}
