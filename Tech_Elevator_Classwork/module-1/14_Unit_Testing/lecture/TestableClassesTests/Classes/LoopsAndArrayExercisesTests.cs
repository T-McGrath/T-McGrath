using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        [TestMethod()]
        public void MiddleWayHappyPath()
        {
            // Arrange
            LoopsAndArrayExercises classBeingTested = new LoopsAndArrayExercises();
            int[] testArray1 = { 1, 2, 3 };
            int[] testArray2 = { 4, 5, 6 };
            // Act
            int[] result = classBeingTested.MiddleWay(testArray1, testArray2);
            // Assert
            Assert.AreEqual(2, result.Length); // Are the lengths the same?
            // Assert.AreEqual(new int[] {2, 5}, result)   WILL NOT WORK because this will only check the memory address for each array rather than the elements IN the arrays.
            CollectionAssert.AreEqual(new int[] { 2, 5 }, result);
        }
    }
}