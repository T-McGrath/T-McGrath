using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class LoopsAndArrayExercisesTests
    {

        [TestMethod()]
        public void MiddleWayTest()
        {
            //Arrange
            LoopsAndArrayExercises classUnderTest = new LoopsAndArrayExercises();
            //setup some parameters
            int[] testArray1 = { 1, 2, 3 };
            int[] testArray2 = { 4, 5, 6 };
            // I can arrange some expected results
            int[] expectedArray = new int[] { 2, 5 };
            //LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises()
            //Act
            int[] result = classUnderTest.MiddleWay(testArray1, testArray2);
            //Assert
            Assert.AreEqual(2, result.Length);
            // this doesn't work becuase they are different places in memory: Assert.AreEqual(new int[] { 2, 5 }, result);
            //this also doesn't work: Assert.AreEqual(expectedArray, result);
            CollectionAssert.AreEqual(expectedArray, result); //this one works!

        }
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object


    }
}
