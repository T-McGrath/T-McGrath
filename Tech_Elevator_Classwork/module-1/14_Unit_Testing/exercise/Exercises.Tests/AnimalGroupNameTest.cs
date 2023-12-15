using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
        private AnimalGroupName classBeingTested = new AnimalGroupName();
        [TestMethod()]
        public void GetHerd_HappyPath()
        {
            //Arrange
            string animalNameTest = "crow";
            //Act
            string result = classBeingTested.GetHerd(animalNameTest);
            //Assert
            Assert.AreEqual("Murder", result);
        }

        [TestMethod()]
        public void GetHerd_UnknownAnimal()
        {
            //Arrange
            string animalNameTest = "cat";
            //Act
            string result = classBeingTested.GetHerd(animalNameTest);
            //Assert
            Assert.AreEqual("unknown", result);
        }

        [TestMethod]
        public void GetHerd_SomeUppercaseLetters()
        {
            // Arrange
            string animalNameTest = "DeeR";
            // Act
            string result = classBeingTested.GetHerd(animalNameTest);
            // Assert
            Assert.AreEqual("Herd", result);
        }

        [TestMethod]
        public void GetHerd_EmptyString()
        {
            //Arrange
            string animalNameTest = "";
            //Act
            string result = classBeingTested.GetHerd(animalNameTest);
            //Assert
            Assert.AreEqual("unknown", result);
        }

        [TestMethod]
        public void GetHerd_NullInput()
        {
            //Arrange
            string animalNameTest = null;
            //Act
            string result = classBeingTested.GetHerd(animalNameTest);
            //Assert
            Assert.AreEqual("unknown", result);
        }
    }
}
