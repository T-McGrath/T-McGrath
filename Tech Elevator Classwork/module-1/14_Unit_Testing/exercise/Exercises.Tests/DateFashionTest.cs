using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        private DateFashion classBeingTested = new DateFashion();

        [TestMethod]
        public void GetATable_HappyPath_MaybeTable()
        {
            //Arrange
            int yourStyleTest = 6;
            int dateStyleTest = 3;
            //Act
            int result = classBeingTested.GetATable(yourStyleTest, dateStyleTest);
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetATable_DoGetTable_Edge()
        {
            //Arrange
            int yourStyleTest = 8;
            int dateStyleTest = 8;
            //Act
            int result = classBeingTested.GetATable(yourStyleTest, dateStyleTest);
            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetATable_DoNotGetTableBecauseYou_Edge()
        {
            //Arrange
            int yourStyleTest = 2;
            int dateStyleTest = 8;
            //Act
            int result = classBeingTested.GetATable(yourStyleTest, dateStyleTest);
            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetATable_DoNotGetTableBecauseDate_Edge()
        {
            //Arrange
            int yourStyleTest = 9;
            int dateStyleTest = 2;
            //Act
            int result = classBeingTested.GetATable(yourStyleTest, dateStyleTest);
            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetATable_StyleScoresAbove10()
        {
            //Arrange
            int yourStyleTest = 500;
            int dateStyleTest = 73;
            //Act
            int result = classBeingTested.GetATable(yourStyleTest, dateStyleTest);
            //Assert
            Assert.AreEqual(2, result);
        }
    }
}
