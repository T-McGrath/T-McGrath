using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the
         * number of times that string appears in the array.
         *
         * ** A CLASSIC **
         *
         * WordCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * WordCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
         * WordCount([]) → {}
         * WordCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
         *
         */
        public Dictionary<string, int> WordCount(string[] words)
        {
            // Turn the array into a list so I can sort it alphabetically.
            List<string> wordList = words.ToList();
            wordList.Sort();
            Dictionary<string, int> countOfWords = new Dictionary<string, int>();
            
            // Keep count of each of the same, subsequent words.
            int count = 1;
            foreach(string elem in wordList)
            {
                if(countOfWords.ContainsKey(elem))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                countOfWords[elem] = count;
            }
            return countOfWords;
        }
    }
}
