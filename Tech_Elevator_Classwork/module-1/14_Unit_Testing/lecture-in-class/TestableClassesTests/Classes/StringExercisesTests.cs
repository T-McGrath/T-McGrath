using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        private StringExercises _classUnderTest = new StringExercises();

        [TestMethod()]
        public void MakeABBAWorksCorrectly()
        {


            //Assert
            //.AreEqual() - compares expected and actual value for equality
            //.AreSame() - verifies two object variables refer to same object
            //.AreNotSame() - verifies two object variables refer to different objects
            //.Fail() - fails without checking conditions
            //.IsFalse()
            //.IsTrue()
            //.IsNotNull()
            //.IsNull()

            //Arrange
            StringExercises classUnderTest = new StringExercises();
            string testString1 = "Wow";
            string testString2 = "Cow";
            //Act
            string resulllt = classUnderTest.MakeAbba(testString1, testString2);
            string expected = "WowCowCowWow";
            //Assert
            Assert.AreEqual(expected, resulllt);
        }
        [TestMethod]
        public void FirstTwoTest()
        {
            //firstTwo("Hello") → "He"
            //firstTwo("abcdefg") → "ab"
            //firstTwo("ab") → "ab"

            //Arrange
            StringExercises stringExercises = new StringExercises();

            //Assert
            Assert.AreEqual("He", stringExercises.FirstTwo("Hello"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("abcdefg"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("ab"));

        }
        [TestMethod]
        public void FirstTwoTest_WithTinyStr()
        {
            //Arrange
            string test = "A";
            //Act
            string result = _classUnderTest.FirstTwo(test);
            //Assert
            Assert.AreEqual(test, result);
        }
    }
}
