using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        private FrontTimes classBeingTested = new FrontTimes();

        [TestMethod]
        public void GenerateString_HappyPath()
        {
            //Arrange
            string strTest = "stuff";
            int timesToRepeatTest = 5;
            //Act
            string result = classBeingTested.GenerateString(strTest, timesToRepeatTest);
            //Assert
            Assert.AreEqual("stustustustustu", result);
        }

        [TestMethod]
        public void GenerateString_SmallLength()
        {
            //Arrange
            string strTest = "s";
            int timesToRepeatTest = 2;
            //Act
            string result = classBeingTested.GenerateString(strTest, timesToRepeatTest);
            //Assert
            Assert.AreEqual("ss", result);
        }

        [TestMethod]
        public void GenerateString_EmptyString()
        {
            //Arrange
            string strTest = "";
            int timesToRepeatTest = 2;
            //Act
            string result = classBeingTested.GenerateString(strTest, timesToRepeatTest);
            //Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void GenerateString_NullString()
        {
            //Arrange
            string strTest = null;
            int timesToRepeatTest = 2;
            //Act
            string result = classBeingTested.GenerateString(strTest, timesToRepeatTest);
            //Assert
            Assert.AreEqual("", result);
        }
    }
}
