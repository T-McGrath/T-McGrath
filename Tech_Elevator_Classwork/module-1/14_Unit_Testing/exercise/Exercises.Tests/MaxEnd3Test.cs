using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Test
    {
        private MaxEnd3 classBeingTested = new MaxEnd3();
        [TestMethod]
        public void MakeArray_HappyPath()
        {
            //Arrange
            int[] numsTest = { 1, 2, 3 };
            //Act
            int[] actual = classBeingTested.MakeArray(numsTest);
            int[] expected = { 3, 3, 3 };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MakeArray_FirstLastAreSame()
        {
            //Arrange
            int[] numsTest = { 9, 2, 9 };
            //Act
            int[] actual = classBeingTested.MakeArray(numsTest);
            int[] expected = { 9, 9, 9 };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MakeArray_ShortArray()
        {
            //Arrange
            int[] numsTest = { 1, 2 };
            //Act
            int[] actual = classBeingTested.MakeArray(numsTest);
            int[] expected = { 2, 2 };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
