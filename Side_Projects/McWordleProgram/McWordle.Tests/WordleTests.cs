namespace McWordle.Tests
{
    [TestClass]
    public class WordleTests
    {
        private Wordle classBeingTested = new Wordle();

        [TestMethod]
        public void UpdateBoard_AllMisses()
        {
            //Arrange
            string expected = "_____";
            //Act
            string actual = classBeingTested.UpdateBoard("scary", "plume");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateBoard_CorrectWord()
        {
            //Arrange
            string expected = "*****";
            //Act
            string actual = classBeingTested.UpdateBoard("spook", "spook");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateBoard_DoubleLetters()
        {
            // Arrange
            string expected = "#*#__";
            // Act
            string actual = classBeingTested.UpdateBoard("DARDO", "RADAR");
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateBoard_AllInWordNotCorrectSpot()
        {
            string expected = "#####";
            string actual = classBeingTested.UpdateBoard("ABCDE", "EABCD");
            Assert.AreEqual(expected, actual);
        }


    }
}