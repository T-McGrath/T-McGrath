﻿namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return the count of the number of times that a substring length 2 appears in the string and
        also as the last 2 chars of the string.

        We don't count the end subString, so "hixxxhi" yields 1, but the subString may overlap a prior position by one.
        For instance, "xxxx" has a count of 2: one pair at position 0, and the second at position 1. The third pair at
        position 2 is the end subString, which we don't count

        Last2("hixxhi") → 1
        Last2("xaxxaxaxx") → 1
        Last2("axxxaaxx") → 2
        Last2("xxxx") -> 2
        */
        public int Last2(string str)
        {
            string desiredString;
            if (str.Length > 1) // Account for if they give us a string shorter than 2 chars.
            {
                desiredString = str.Substring(str.Length - 2);
            }
            else
            {
                return 0;
            }

            int countOfDesiredString = 0;
            for (int i = 0; i < str.Length - 2; i++)
            {
                if(str.Substring(i, 2) == desiredString)
                {
                    countOfDesiredString++;
                }
            }
            return countOfDesiredString;
        }
    }
}
