using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTest
    {
        private StringBits classBeingTested = new StringBits();

        [TestMethod]
        public void GetBits_HappyPath()
        {
            //Arrange
            string strTest = "fqatrctzs";
            //Act
            string actual = classBeingTested.GetBits(strTest);
            string expected = "farts";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBits_EmptyString()
        {
            //Arrange
            string strTest = "";
            //Act
            string actual = classBeingTested.GetBits(strTest);
            string expected = "";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBits_OneCharString()
        {
            //Arrange
            string strTest = "Q";
            //Act
            string actual = classBeingTested.GetBits(strTest);
            string expected = "Q";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBits_OddLengthString()
        {
            //Arrange
            string strTest = "SMELLY";
            //Act
            string actual = classBeingTested.GetBits(strTest);
            string expected = "SEL";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBits_NullString()
        {
            //Arrange
            string strTest = null;
            //Act
            string actual = classBeingTested.GetBits(strTest);
            string expected = "";
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
