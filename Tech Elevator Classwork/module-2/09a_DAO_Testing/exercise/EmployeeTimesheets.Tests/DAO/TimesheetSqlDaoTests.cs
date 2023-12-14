using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeTimesheets.DAO;
using EmployeeTimesheets.Models;

namespace EmployeeTimesheets.Tests.DAO
{
    [TestClass]
    public class TimesheetSqlDaoTests : BaseDaoTests
    {
        private static readonly Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1, DateTime.Parse("2021-01-01"), 1.0M, true, "Timesheet 1");
        private static readonly Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-02"), 1.5M, true, "Timesheet 2");
        private static readonly Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1, DateTime.Parse("2021-01-01"), 0.25M, true, "Timesheet 3");
        private static readonly Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2, DateTime.Parse("2021-02-01"), 2.0M, false, "Timesheet 4");

        private TimesheetSqlDao dao;
        private Timesheet testTimesheet;


        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            testTimesheet = new Timesheet(0, 1, 1, DateTime.Parse("2020-03-13"), 7.5M, true, "Test timesheet");
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheetById_With_Valid_Id_Returns_Correct_Timesheet()
        {
            Timesheet result = dao.GetTimesheetById(1);
            AssertTimesheetsMatch(TIMESHEET_1, result);

            result = dao.GetTimesheetById(4);
            AssertTimesheetsMatch(TIMESHEET_4, result);
        }

        [TestMethod]
        public void GetTimesheetById_With_Invalid_Id_Returns_Null_Timesheet()
        {
            Timesheet result = dao.GetTimesheetById(500);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_With_Valid_Employee_Id_Returns_List_Of_Timesheets_For_Employee()
        {
            List<Timesheet> resultList = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(2, resultList.Count);

            AssertTimesheetsMatch(TIMESHEET_1, resultList[0]);
            AssertTimesheetsMatch(TIMESHEET_2, resultList[1]);

            resultList = dao.GetTimesheetsByEmployeeId(2);
            Assert.AreEqual(2, resultList.Count);

            AssertTimesheetsMatch(TIMESHEET_3, resultList[0]);
            AssertTimesheetsMatch(TIMESHEET_4, resultList[1]);
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_With_Valid_Project_Id_Returns_List_Of_Timesheets_For_Project()
        {
            List<Timesheet> resultList = dao.GetTimesheetsByProjectId(1);
            Assert.AreEqual(3, resultList.Count);
            AssertTimesheetsMatch(TIMESHEET_1, resultList[0]);
            AssertTimesheetsMatch(TIMESHEET_2, resultList[1]);
            AssertTimesheetsMatch(TIMESHEET_3, resultList[2]);

            resultList = dao.GetTimesheetsByProjectId(2);
            Assert.AreEqual(1, resultList.Count);
            AssertTimesheetsMatch(TIMESHEET_4, resultList[0]);
        }

        [TestMethod]
        public void CreateTimesheet_Creates_Timesheet()
        {
            Timesheet newTimesheet = dao.CreateTimesheet(testTimesheet);
            Assert.IsNotNull(newTimesheet); // Make sure a timesheet actually got created.
            
            int newTimesheetId = newTimesheet.TimesheetId;
            Assert.IsTrue(newTimesheetId > 0); // Make sure the timesheet_id was set automatically.

            Timesheet retrievedTimesheet = dao.GetTimesheetById(newTimesheetId);
            AssertTimesheetsMatch(newTimesheet, retrievedTimesheet); // How to decide which of these is the 'expected' and which is 'actual'...does it matter?
        }

        [TestMethod]
        public void UpdateTimesheet_Updates_Timesheet()
        {
            Timesheet timesheetToUpdate = dao.GetTimesheetById(4);
            timesheetToUpdate.ProjectId = 1;
            timesheetToUpdate.EmployeeId = 1;
            timesheetToUpdate.DateWorked = Convert.ToDateTime("3020-01-01");
            timesheetToUpdate.IsBillable = true;
            timesheetToUpdate.Description = "TIMESHEET FROM THE FUTURRRRRRRE!!";
            // At this point, the timesheetToUpdate OBJECT has been updated, but the corresponding database record has not been.
            Timesheet updatedTimesheet = dao.UpdateTimesheet(timesheetToUpdate); //This actually makes the changes in the DB.
            Assert.IsNotNull(updatedTimesheet); // Check if updated timesheet is null.

            Timesheet retrievedTimesheet = dao.GetTimesheetById(4); // This method must be used to GET the updated record from the DB.
            AssertTimesheetsMatch(timesheetToUpdate, retrievedTimesheet); // This checks if all values were updated in the database record.
        }

        [TestMethod]
        public void DeleteTimesheetById_Deletes_Timesheet()
        {
            int numRowsAffected = dao.DeleteTimesheetById(4);
            Assert.IsTrue(numRowsAffected > 0); // Make sure at least one row was deleted (really shouldn't be more than 1 either).

            Assert.IsNull(dao.GetTimesheetById(4)); // Check if the record was actually deleted.

        }

        [TestMethod]
        public void GetBillableHours_Returns_Correct_Total()
        {
            decimal actualBillableHours = dao.GetBillableHours(1, 1);
            Assert.AreEqual(2.50M, actualBillableHours);

            actualBillableHours = dao.GetBillableHours(2, 2);
            Assert.AreEqual(0.0M, actualBillableHours);
        }

        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
