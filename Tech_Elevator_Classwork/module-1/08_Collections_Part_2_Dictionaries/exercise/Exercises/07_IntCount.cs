using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of int values, return a Dictionary<int, int> with a key for each int, with the value the
         * number of times that int appears in the array.
         *
         * ** The lesser known cousin of the the classic WordCount **
         *
         * IntCount([1, 99, 63, 1, 55, 77, 63, 99, 63, 44]) → {1: 2, 44: 1, 55: 1, 63: 3, 77: 1, 99:2}
         * IntCount([107, 33, 107, 33, 33, 33, 106, 107]) → {33: 4, 106: 1, 107: 3}
         * IntCount([]) → {}
         *
         */
        public Dictionary<int, int> IntCount(int[] ints)
        {
            Dictionary<int, int> countOfInts = new Dictionary<int, int>();
            List<int> intList = ints.ToList();
            intList.Sort();
            int count = 0;
            foreach(int elem in intList)
            {
                if(countOfInts.ContainsKey(elem))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                countOfInts[elem] = count;
            }
            return countOfInts;
        }
    }
}
