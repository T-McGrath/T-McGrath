using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        private CigarParty classBeingTested = new CigarParty();
        [TestMethod]
        public void HaveParty_HappyPathIsWeekend()
        {
            //Arrange
            int numCigarsTest = 500;
            bool isWeekendTest = true;
            //Act
            bool result = classBeingTested.HaveParty(numCigarsTest, isWeekendTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void HaveParty_NotWeekend_CigarsInRange_UpperEdge()
        {
            //Arrange
            int numCigarsTest = 60;
            bool isWeekendTest = false;
            //Act
            bool result = classBeingTested.HaveParty(numCigarsTest, isWeekendTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void HaveParty_NotWeekend_CigarsInRange_LowerEdge()
        {
            //Arrange
            int numCigarsTest = 40;
            bool isWeekendTest = false;
            //Act
            bool result = classBeingTested.HaveParty(numCigarsTest, isWeekendTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void HaveParty_NotWeekend_NegativeCigars()
        {
            //Arrange
            int numCigarsTest = -50;
            bool isWeekendTest = false;
            //Act
            bool result = classBeingTested.HaveParty(numCigarsTest, isWeekendTest);
            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
