using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        private Less20 classBeingTested = new Less20();

        [TestMethod]
        public void IsLessThanMultipleOf20_HappyPathTwoLess()
        {
            //Arrange
            int numTest = 58;
            //Act
            bool result = classBeingTested.IsLessThanMultipleOf20(numTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsLessThanMultipleOf20_HappyPathOneLess()
        {
            //Arrange
            int numTest = 99;
            //Act
            bool result = classBeingTested.IsLessThanMultipleOf20(numTest);
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsLessThanMultipleOf20_IsMultipleOf20()
        {
            //Arrange
            int numTest = 2000;
            //Act
            bool result = classBeingTested.IsLessThanMultipleOf20(numTest);
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        // There's no code in the given method to see if it's a negative number.
        public void IsLessThanMultipleOf20_NegativeNum()
        {
            //Arrange
            int numTest = -61;
            //Act
            bool result = classBeingTested.IsLessThanMultipleOf20(numTest);
            //Assert
            Assert.AreEqual(true, result); // -61 % 20 is actually 19
        }
    }
}
