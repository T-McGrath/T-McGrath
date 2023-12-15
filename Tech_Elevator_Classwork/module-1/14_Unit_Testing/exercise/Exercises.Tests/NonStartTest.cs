using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        private NonStart classBeingTested = new NonStart();
        [TestMethod]
        public void GetPartialString_HappyPath()
        {
            //Arrange
            string str1Test = "stuff";
            string str2Test = "things";
            //Act
            string actual = classBeingTested.GetPartialString(str1Test, str2Test);
            string expected = "tuffhings";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPartialString_NullFirstInput()
        {
            //Arrange
            string str1Test = null;
            string str2Test = "things";
            //Act
            string actual = classBeingTested.GetPartialString(str1Test, str2Test);
            string expected = "hings";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPartialString_NullSecondInput()
        {
            //Arrange
            string str1Test = "stuff";
            string str2Test = null;
            //Act
            string actual = classBeingTested.GetPartialString(str1Test, str2Test);
            string expected = "tuff";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPartialString_BothInputsLengthZero()
        {
            //Arrange
            string str1Test = "";
            string str2Test = "";
            //Act
            string actual = classBeingTested.GetPartialString(str1Test, str2Test);
            string expected = "";
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
