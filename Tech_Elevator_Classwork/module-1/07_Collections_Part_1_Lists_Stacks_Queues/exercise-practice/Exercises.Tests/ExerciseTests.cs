using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    [TestClass]
    public class ExerciseTests
    {
        Exercises exercises = new Exercises();

        /*
         Array2List( {"Apple", "Orange", "Banana"} )  ->  ["Apple", "Orange", "Banana"]
         Array2List( {"Red", "Orange", "Yellow"} )  ->  ["Red", "Orange", "Yellow"]
         Array2List( {"Left", "Right", "Forward", "Back"} )  ->  ["Left", "Right", "Forward", "Back"]
         */
        [TestMethod]
        public void Exercise01_Array2List()
        {
            string failureMessage = CompareLists(new List<string>() { "Apple", "Orange", "Banana" },
                                    exercises.Array2List(new string[] { "Apple", "Orange", "Banana" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: Array2List(new string[] {\"Apple\", \"Orange\", \"Banana\"}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "Red", "Orange", "Yellow" },
                            exercises.Array2List(new string[] { "Red", "Orange", "Yellow" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: Array2List(new string[] {\"Red\", \"Orange\", \"Yellow\"}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "Left", "Right", "Forward", "Back" },
                            exercises.Array2List(new string[] { "Left", "Right", "Forward", "Back" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: Array2List(new string[] {\"Left\", \"Right\", \"Forward\", \"Back\"}) " + failureMessage);
            }
        }

        /*
         Given a list of Strings, return an array containing the same Strings in the same order
         List2Array( ["Apple", "Orange", "Banana"] )  ->  {"Apple", "Orange", "Banana"}
         List2Array( ["Red", "Orange", "Yellow"] )  ->  {"Red", "Orange", "Yellow"}
         List2Array( ["Left", "Right", "Forward", "Back"] )  ->  {"Left", "Right", "Forward", "Back"}
         */
        [TestMethod]
        public void Exercise02_List2Array()
        {
            string failureMessage = CompareArrays(new string[] { "Apple", "Orange", "Banana" },
                                    exercises.List2Array(new List<string> { "Apple", "Orange", "Banana" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: List2Array(new string[] {\"Apple\", \"Orange\", \"Banana\"}) " + failureMessage);
            }

            failureMessage = CompareArrays(new string[] { "Red", "Orange", "Yellow" },
                            exercises.List2Array(new List<string>() { "Red", "Orange", "Yellow" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: List2Array(new string[] {\"Red\", \"Orange\", \"Yellow\"}) " + failureMessage);
            }

            failureMessage = CompareArrays(new string[] { "Left", "Right", "Forward", "Back" },
                            exercises.List2Array(new List<string>() { "Left", "Right", "Forward", "Back" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: List2Array(new string[] {\"Left\", \"Right\", \"Forward\", \"Back\"}) " + failureMessage);
            }
        }

        /*
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        [TestMethod]
        public void Exercise03_No4LetterWords()
        {
            string failureMessage = CompareLists(new List<string>() { "Train", "Car" },
                                    exercises.No4LetterWords(new string[] { "Train", "Boat", "Car" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: No4LetterWords(new string[] {\"Train\", \"Boat\", \"Car\"}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "Red", "White" },
                            exercises.No4LetterWords(new string[] { "Red", "White", "Blue" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: No4LetterWords(new string[] {\"Red\", \"White\", \"Blue\"}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "Jim" },
                            exercises.No4LetterWords(new string[] { "Jack", "Jill", "Jane", "John", "Jim" }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: No4LetterWords(new string[] {\"Jack\", \"Jill\", \"Jane\", \"John\", \"Jim\"}) " + failureMessage);
            }
        }

        /*
         Given an array of ints, divide each int by 2, and return an List of Doubles.
         ArrayInt2ListDouble( {5, 8, 11, 200, 97} ) -> [2.5, 4.0, 5.5, 100, 48.5]
         ArrayInt2ListDouble( {745, 23, 44, 9017, 6} ) -> [372.5, 11.5, 22, 4508.5, 3]
         ArrayInt2ListDouble( {84, 99, 3285, 13, 877} ) -> [42, 49.5, 1642.5, 6.5, 438.5]
         */
        [TestMethod]
        public void Exercise04_ArrayInt2ListDouble()
        {
            string failureMessage = CompareLists(new List<double>() { 2.5d, 4.0d, 5.5d, 100.0d, 48.5d },
                                    exercises.ArrayInt2ListDouble(new int[] { 5, 8, 11, 200, 97 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: ArrayInt2ListDouble(new int[] {5, 8, 11, 200, 97}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<double>() { 372.5d, 11.5d, 22.0d, 4508.5d, 3.0d },
                            exercises.ArrayInt2ListDouble(new int[] { 745, 23, 44, 9017, 6 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: ArrayInt2ListDouble(new int[] {745, 23, 44, 9017, 6}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<double>() { 42.0d, 49.5d, 1642.5d, 6.5d, 438.5d },
                            exercises.ArrayInt2ListDouble(new int[] { 84, 99, 3285, 13, 877 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: ArrayInt2ListDouble(new int[] {84, 99, 3285, 13, 877}) " + failureMessage);
            }
        }

        /*
         Given a List of Integers, return the largest value.
         FindLargest( [11, 200, 43, 84, 9917, 4321, 1, 33333, 8997] ) -> 33333
         FindLargest( [987, 1234, 9381, 731, 43718, 8932] ) -> 43718
         FindLargest( [34070, 1380, 81238, 7782, 234, 64362, 627] ) -> 81238
         */
        [TestMethod]
        public void Exercise05_FindLargest()
        {
            Assert.AreEqual(33333, exercises.FindLargest(new List<int>() { 11, 200, 43, 84, 9917, 4321, 1, 33333, 8997 }), "Input: FindLargest(new List<int> { 11, 200, 43, 84, 9917, 4321, 1, 33333, 8997 })");
            Assert.AreEqual(43718, exercises.FindLargest(new List<int>() { 987, 1234, 9381, 731, 43718, 8932 }), "Input: FindLargest(new List<int> {  987, 1234, 9381, 731, 43718, 8932 })");
            Assert.AreEqual(81238, exercises.FindLargest(new List<int>() { 34070, 1380, 81238, 7782, 234, 64362, 627 }), "Input: FindLargest(new List<int> { 34070, 1380, 81238, 7782, 234, 64362, 627 })");
        }

        /*
         Given an array of Integers, return a List of Integers containing just the odd values.
         OddOnly( {112, 201, 774, 92, 9, 83, 41872} ) -> [201, 9, 83]
         OddOnly( {1143, 555, 7, 1772, 9953, 643} ) -> [1143, 555, 7, 9953, 643]
         OddOnly( {734, 233, 782, 811, 3, 9999} ) -> [233, 811, 3, 9999]
         */
        [TestMethod]
        public void Exercise06_OddOnly()
        {
            string failureMessage = CompareLists(new List<int>() { 201, 9, 83 },
                                    exercises.OddOnly(new int[] { 112, 201, 774, 92, 9, 83, 41872 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: OddOnly(new int[] {112, 201, 774, 92, 9, 83, 41872}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<int>() { 1143, 555, 7, 9953, 643 },
                            exercises.OddOnly(new int[] { 1143, 555, 7, 1772, 9953, 643 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: OddOnly(new int[] {1143, 555, 7, 1772, 9953, 643}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<int>() { 233, 811, 3, 9999 },
                            exercises.OddOnly(new int[] { 734, 233, 782, 811, 3, 9999 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: OddOnly(new int[] {734, 233, 782, 811, 3, 9999}) " + failureMessage);
            }
        }

        /*
         Given a List of Integers, and an int value, return true if the int value appears two or more times in
         the list.
	     FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
	     FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
	     FoundIntTwice( [9, 9, 44, 2, 88, 9], 9) -> true
         */
        [TestMethod]
        public void Exercise07_FoundIntTwice()
        {
            Assert.AreEqual(false, exercises.FoundIntTwice(new List<int>() { 55, 17, 3, 6, 12 }, 4), "Input: FoundIntTwice(new List<int> { 55, 17, 3, 6, 12 }, 4)");
            Assert.AreEqual(true, exercises.FoundIntTwice(new List<int>() { 5, 7, 9, 5, 11 }, 5), "Input: FoundIntTwice(new List<int> { 5, 7, 9, 5, 11 }, 5)");
            Assert.AreEqual(false, exercises.FoundIntTwice(new List<int>() { 6, 8, 10, 11, 13 }, 8), "Input: FoundIntTwice(new List<int> { 6, 8, 10, 11, 13 }, 8)");
            Assert.AreEqual(true, exercises.FoundIntTwice(new List<int>() { 9, 9, 44, 2, 88, 9 }, 9), "Input: FoundIntTwice(new List<int> { 9, 9, 44, 2, 88, 9 }, 9)");
        }

        /*
         Given an array of Integers, return a List that contains strings.  except any multiple of 3
         should be replaced by the String "Fizz", any multiple of 5 should be replaced by the String "Buzz",
         and any multiple of both 3 and 5 should be replaced by the String "FizzBuzz"
         FizzBuzzList( {1, 2, 3} )  ->  ["1", "2", "Fizz"]
         FizzBuzzList( {4, 5, 6} )  ->  ["4", "Buzz", "Fizz"]
         FizzBuzzList( {7, 8, 9, 10, 11, 12, 13, 14, 15} )  ->  ["7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]
         */
        [TestMethod]
        public void Exercise08_FizzBuzzList()
        {
            string failureMessage = CompareLists(new List<string>() { "1", "2", "Fizz" },
                                    exercises.FizzBuzzList(new int[] { 1, 2, 3 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: FizzBuzzList(new int[] {1, 2, 3}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "4", "Buzz", "Fizz" },
                            exercises.FizzBuzzList(new int[] { 4, 5, 6 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: FizzBuzzList(new int[] {4, 5, 6}) " + failureMessage);
            }

            failureMessage = CompareLists(new List<string>() { "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" },
                            exercises.FizzBuzzList(new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 }));
            if (failureMessage != null)
            {
                Assert.Fail("Input: FizzBuzzList(new int[] {7, 8, 9, 10, 11, 12, 13, 14, 15}) " + failureMessage);
            }
        }

        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        InterleaveLists( [7, 1, 3], [2, 5, 7, 9] )  ->  [7, 2, 1, 5, 3, 7, 9]
        InterleaveLists( [1, 2, 5, 8, 10], [4, 5, 6] )  ->  [1, 4, 2, 5, 5, 6, 8, 10]
        */
        [TestMethod]
        public void Exercise09_InterleaveLists()
        {
            List<int> trialList = exercises.InterleaveLists(new List<int>() { 1, 2, 3 },  new List<int>() { 4, 5, 6 });
            
            string failureMessage = CompareLists(new List<int>() { 1, 4, 2, 5, 3, 6 }, trialList);
            if (failureMessage != null)
            {
                Assert.Fail("Input: InterleaveLists([1, 2, 3], [4, 5, 6]) " + failureMessage);
            }

            trialList = exercises.InterleaveLists(new List<int>() { 7, 1, 3 }, new List<int>() { 2, 5, 7, 9 });
            failureMessage = CompareLists(new List<int>() { 7, 2, 1, 5, 3, 7, 9 }, trialList);
            if (failureMessage != null)
            {
                Assert.Fail("Input: InterleaveLists([7, 1, 3], [2, 5, 7, 9]) " + failureMessage);
            }

            trialList = exercises.InterleaveLists(new List<int>() { 1, 2, 5, 8, 10 }, new List<int>() { 4, 5, 6 });
            failureMessage = CompareLists(new List<int>() { 1, 4, 2, 5, 5, 6, 8, 10 }, trialList);
            if (failureMessage != null)
            {
                Assert.Fail("Input: InterleaveLists([1, 2, 5, 8, 10], [4, 5, 6]) " + failureMessage);
            }
        }

        private string CompareLists<T>(List<T> expectedList, List<T> actualList)
        {
            string failureMessage = null;
            if ((expectedList == null) || (actualList == null))
            {
                failureMessage = expectedList == null ? "expectedList is null " : "";
                failureMessage = actualList == null ? "actualList is null" : "";
                return failureMessage.Trim();
            }
            if (expectedList.Count != actualList.Count)
            {
                failureMessage = "List lengths differ, expected=" + expectedList.Count + " actual=" + actualList.Count;
                return failureMessage;
            }
            int i = 0;
            foreach (object expectedItem in expectedList)
            {
                if (!expectedItem.Equals(actualList[i]))
                {
                    failureMessage = "array elements at index " + i + " differ, expected:<" + expectedItem + "> but was:<" + actualList[i] + ">";
                    return failureMessage;
                }
                i++;
            }
            return failureMessage;
        }

        private string CompareArrays<T>(T[] expectedArray, T[] actualArray)
        {
            return CompareLists(expectedArray?.ToList(), actualArray?.ToList());
        }
    }
}
