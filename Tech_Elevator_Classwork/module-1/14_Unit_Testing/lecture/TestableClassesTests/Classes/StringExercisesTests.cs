using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
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

        [TestMethod()]
        public void MakeAbbaHappyPath()
        {
            // Arrange
            StringExercises classBeingTested = new StringExercises();
            string testStr1 = "Hello";
            string testStr2 = "Goodbye";
            // Act
            string result = classBeingTested.MakeAbba(testStr1, testStr2);
            // Assert
            Assert.AreEqual("HellooodbyeGoodbyeHello", result);
        }


    }
}