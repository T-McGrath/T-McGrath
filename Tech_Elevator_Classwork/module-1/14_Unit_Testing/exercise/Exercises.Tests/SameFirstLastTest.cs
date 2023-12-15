using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {
        private SameFirstLast classBeingTested = new SameFirstLast();

        [TestMethod]
        public void IsItTheSame_HappyPath()
        {
            //Arrange
            int[] numsTest = { 1, 2, 1 };
            //Act
            bool actual = classBeingTested.IsItTheSame(numsTest);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsItTheSame_NullArray()
        {
            //Arrange
            int[] numsTest = null;
            //Act
            bool actual = classBeingTested.IsItTheSame(numsTest);
            //Assert
            Assert.IsFalse(actual); //Length is not > 0 (has not length), so should return false, in my opinion.
        }

        [TestMethod]
        public void IsItTheSame_FirstLastNotEqual()
        {
            //Arrange
            int[] numsTest = { 8, 2, 1 };
            //Act
            bool actual = classBeingTested.IsItTheSame(numsTest);
            //Assert
            Assert.IsFalse(actual);
        }
    }
}
