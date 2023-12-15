using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise05_PackageTests : TestBase
    {
        [TestMethod]
        public void ShouldAcceptOrRejectPackage1_Weight()
        {
            // Arrange
            PackageAcceptance packages = new PackageAcceptance();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(packages.AcceptPackage(23), "A 23 lb package should be accepted since it is not over the weight limit");
            Assert.IsTrue(packages.AcceptPackage(40), "A 40 lb package should be accepted since it is not over the weight limit");
            Assert.IsFalse(packages.AcceptPackage(41), "A 41 lb package should be rejected since it is over the weight limit");
            Assert.IsFalse(packages.AcceptPackage(400), "A 400 lb package should be rejected since it is over the weight limit");
        }        
        
        [TestMethod]
        public void ShouldAcceptOrRejectPackage2_Dimensions()
        {
            // Arrange
            PackageAcceptance packages = new PackageAcceptance();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(packages.AcceptPackage(23, 4, 4, 4), "A 4x4x4 package weighing 23 lbs should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(23, 19, 19, 19), "A 19x19x19 package weighing 23 lbs should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(23, 2, 2, 194), "A 2x2x194 package weighing 23 lbs should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(40, 4, 4, 4), "A 4x4x4 package weighing 40 lbs should be accepted since it is within the weight and dimension limits");
            Assert.IsFalse(packages.AcceptPackage(23, 20, 20, 20), "A 20x20x20 package weighing 23 lbs should be rejected since its cubic size is larger than the maximum allowed");
            Assert.IsFalse(packages.AcceptPackage(41, 4, 4, 4), "A 4x4x4 package weighing 41 lbs should be rejected since its over the weight limit");
            Assert.IsFalse(packages.AcceptPackage(400, 4, 2, 1), "A 4x2x1 package weighing 400 lbs should be rejected since its over the weight limit");
        }   
        
        [TestMethod]
        public void ShouldAcceptOrRejectPackage3_Surcharge()
        {
            // Arrange
            PackageAcceptance packages = new PackageAcceptance();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(packages.AcceptPackage(23, 4, 4, 4, false), "A 4x4x4 package weighing 23 lbs without paid surcharge should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(23, 19, 19, 19, false), "A 19x19x19 package weighing 23 lbs without paid surcharge should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(23, 2, 2, 194, true), "A 2x2x194 package weighing 23 lbs with paid surcharge should be accepted since it is within the weight and dimension limits");
            Assert.IsTrue(packages.AcceptPackage(40, 4, 4, 4, false), "A 4x4x4 package weighing 40 lbs without paid surcharge should be accepted since it is within the weight and dimension limits");
            Assert.IsFalse(packages.AcceptPackage(23, 20, 20, 20, true), "A 20x20x20 package weighing 23 lbs with paid surcharge should be rejected since its cubic size is larger than the maximum allowed and the surcharge doesn't apply to cubic size");
            Assert.IsFalse(packages.AcceptPackage(23, 20, 20, 20, false), "A 20x20x20 package weighing 23 lbs without paid surcharge should be rejected since its cubic size is larger than the maximum allowed");
            Assert.IsFalse(packages.AcceptPackage(41, 4, 4, 4, true), "A 4x4x4 package weighing 41 lbs with paid surcharge should be rejected since its over the weight limit and surcharge doesn't apply to weight");
            Assert.IsFalse(packages.AcceptPackage(400, 4, 2, 1, true), "A 4x2x1 package weighing 400 lbs with paid surcharge should be rejected since its over the weight limit and surcharge doesn't apply to weight");
        }
    }
}
