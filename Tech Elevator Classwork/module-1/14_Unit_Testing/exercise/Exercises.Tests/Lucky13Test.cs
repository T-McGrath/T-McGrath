using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Test
    {
        private Lucky13 classBeingTested = new Lucky13();

        [TestMethod]
        public void GetLucky_HappyPath()
        {
            //Arrange
            int[] numsTest = { 2, 6, 15 };
            //Act
            bool result = classBeingTested.GetLucky(numsTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GetLucky_HasAOne()
        {
            //Arrange
            int[] numsTest = { 2, 1, 15 };
            //Act
            bool result = classBeingTested.GetLucky(numsTest);
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetLucky_HasA3()
        {
            //Arrange
            int[] numsTest = { 2, 500, 3 };
            //Act
            bool result = classBeingTested.GetLucky(numsTest);
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetLucky_UninitializedArray()
        {
            //Arrange
            int[] numsTest = new int[6];
            //Act
            bool result = classBeingTested.GetLucky(numsTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        // There's no check for a null array within the method :-(
        public void GetLucky_NullArray()
        {
            //Arrange
            int[] numsTest = null;
            //Act
            bool result = classBeingTested.GetLucky(numsTest); // This throws an exception if numsTest is null
            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
