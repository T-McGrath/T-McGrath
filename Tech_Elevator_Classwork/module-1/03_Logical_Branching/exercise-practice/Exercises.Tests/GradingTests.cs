using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise01_GradingTests : TestBase
    {
        [TestMethod]
        public void ShouldReturnCorrectGrade1_PassFail()
        {
            // Arrange
            TestGrading grading = new TestGrading();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(grading.GradeTestPassFail(100), "A 100 should be a passing grade");
            Assert.IsTrue(grading.GradeTestPassFail(90), "A 90 should be a passing grade");
            Assert.IsTrue(grading.GradeTestPassFail(70), "A 70 should be a passing grade");
            Assert.IsFalse(grading.GradeTestPassFail(69), "A 69 should NOT be a passing grade");
            Assert.IsFalse(grading.GradeTestPassFail(60), "A 60 should NOT be a passing grade");
            Assert.IsFalse(grading.GradeTestPassFail(0), "A 0 should NOT be a passing grade");
        }

        [TestMethod]
        public void ShouldReturnCorrectGrade2_TechElevatorScale()
        {
            // Arrange
            TestGrading grading = new TestGrading();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(3, grading.GradeTestNumeric(100), "A 100 should score as a 3");
            Assert.AreEqual(3, grading.GradeTestNumeric(95), "A 95 should score as a 3");
            Assert.AreEqual(3, grading.GradeTestNumeric(90), "A 90 should score as a 3");
            Assert.AreEqual(2, grading.GradeTestNumeric(89), "A 89 should score as a 2");
            Assert.AreEqual(2, grading.GradeTestNumeric(70), "A 70 should score as a 2");
            Assert.AreEqual(2, grading.GradeTestNumeric(50), "A 50 should score as a 2");
            Assert.AreEqual(1, grading.GradeTestNumeric(49), "A 49 should score as a 1");
            Assert.AreEqual(1, grading.GradeTestNumeric(37), "A 37 should score as a 1");
            Assert.AreEqual(1, grading.GradeTestNumeric(25), "A 25 should score as a 1");
            Assert.AreEqual(0, grading.GradeTestNumeric(24), "A 24 should score as a 0");
            Assert.AreEqual(0, grading.GradeTestNumeric(12), "A 12 should score as a 0");
            Assert.AreEqual(0, grading.GradeTestNumeric(1), "A 1 should score as a 0");
            Assert.AreEqual(0, grading.GradeTestNumeric(0), "A 0 should score as a 0");
        }

        [TestMethod]
        public void ShouldReturnCorrectGrade3_LetterGrade()
        {
            // Arrange
            TestGrading grading = new TestGrading();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion

            // Note: Converting to uppercase string since students don't know about string equality yet
            // and char doesn't have an easy ToUpper method in .NET
            Assert.AreEqual("A", grading.GradeTestLetter(100).ToUpperString(), "A 100 should be an A");
            Assert.AreEqual("A", grading.GradeTestLetter(95).ToUpperString(), "A 95 should be an A");
            Assert.AreEqual("A", grading.GradeTestLetter(90).ToUpperString(), "A 90 should be an A");
            Assert.AreEqual("B", grading.GradeTestLetter(89).ToUpperString(), "An 89 should be a B");
            Assert.AreEqual("B", grading.GradeTestLetter(85).ToUpperString(), "An 85 should be a B");
            Assert.AreEqual("B", grading.GradeTestLetter(80).ToUpperString(), "An 80 should be a B");
            Assert.AreEqual("C", grading.GradeTestLetter(79).ToUpperString(), "A 79 should be a C");
            Assert.AreEqual("C", grading.GradeTestLetter(74).ToUpperString(), "A 74 should be a C");
            Assert.AreEqual("C", grading.GradeTestLetter(70).ToUpperString(), "A 70 should be a C");
            Assert.AreEqual("D", grading.GradeTestLetter(69).ToUpperString(), "A 69 should be a D");
            Assert.AreEqual("D", grading.GradeTestLetter(65).ToUpperString(), "A 65 should be a D");
            Assert.AreEqual("D", grading.GradeTestLetter(60).ToUpperString(), "A 60 should be a D");
            Assert.AreEqual("F", grading.GradeTestLetter(59).ToUpperString(), "A 59 should be an F");
            Assert.AreEqual("F", grading.GradeTestLetter(39).ToUpperString(), "A 39 should be an F");
            Assert.AreEqual("F", grading.GradeTestLetter(25).ToUpperString(), "A 25 should be an F");
            Assert.AreEqual("F", grading.GradeTestLetter(1).ToUpperString(), "A 1 should be an F");
            Assert.AreEqual("F", grading.GradeTestLetter(0).ToUpperString(), "A 0 should be an F");
        }
    }
}
