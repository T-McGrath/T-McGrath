using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        private WordCount classBeingTested = new WordCount();

        [TestMethod]
        public void GetCount_HappyPath()
        {
            //Arrange
            string[] wordsTest = { "ba", "ba", "black", "sheep" };
            //Act
            Dictionary<string, int> actual = classBeingTested.GetCount(wordsTest);
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"ba", 2 },
                {"black", 1 },
                {"sheep", 1 }
            };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCount_ThreeOfSameString()
        {
            //Arrange
            string[] wordsTest = { "ba", "ba", "black", "sheep", "ba" };
            //Act
            Dictionary<string, int> actual = classBeingTested.GetCount(wordsTest);
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"ba", 3 },
                {"black", 1 },
                {"sheep", 1 }
            };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCount_OnlyOneString()
        {
            //Arrange
            string[] wordsTest = { "sheep" };
            //Act
            Dictionary<string, int> actual = classBeingTested.GetCount(wordsTest);
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"sheep", 1 }
            };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCount_SomeEmptyStrings()
        {
            //Arrange
            string[] wordsTest = { "", "", "black", "sheep", "" };
            //Act
            Dictionary<string, int> actual = classBeingTested.GetCount(wordsTest);
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"", 3 },
                {"black", 1 },
                {"sheep", 1 }
            };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Once again, not code in the GetCount method to handle a null argument.
        public void GetCount_NullArray()
        {
            //Arrange
            string[] wordsTest = null;
            //Act
            Dictionary<string, int> actual = classBeingTested.GetCount(wordsTest);
            Dictionary<string, int> expected = new Dictionary<string, int>();            
            //Assert
            CollectionAssert.AreEqual(expected, actual); // Is there a better way to check if the method handles a null argument?
        }
    }
}
