using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        DIFFICULTY: HARD
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            List<int> combinedList = new List<int>();
            // Ternary operator!
            List<int> shorterList = listOne.Count < listTwo.Count ? listOne : listTwo;
            //List<int> longerList = listOne.Count < listTwo.Count ? listTwo : listOne;
            
            // Add items from each list SHORTER LIST number of times.
            for (int i = 0; i < shorterList.Count; i++)
            {
                combinedList.Add(listOne[i]);
                combinedList.Add(listTwo[i]);
            }
            
            // Add any extra items from longer list (if necessary)...start at index AFTER 
            // the items that have already been added.
            if (listOne.Count < listTwo.Count)
            {
                for (int i = listOne.Count; i < listTwo.Count; i++)
                {
                    combinedList.Add(listTwo[i]);
                }
            }
            else
            {
                for (int i = listTwo.Count; i < listOne.Count; i++)
                {
                    combinedList.Add(listOne[i]);
                }
            }            
            return combinedList;
        }
    }
}
