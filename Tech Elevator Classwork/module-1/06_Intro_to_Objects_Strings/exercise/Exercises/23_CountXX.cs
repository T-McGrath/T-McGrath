namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Count the number of "xx" in the given string. Overlapping is allowed, so "xxx" contains 2 "xx".
        CountXX("abcxx") → 1
        CountXX("xxx") → 2
        CountXX("xxxx") → 3
        */
        public int CountXX(string str)
        {
            bool wasPrevCharX = false;
            string curChar;
            int doubleXCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                curChar = str.Substring(i, 1);
                if (curChar == "x" && wasPrevCharX)
                {
                    doubleXCount++;
                }
                else if(curChar == "x")
                {
                    wasPrevCharX = true;
                }
                else
                {
                    wasPrevCharX = false;
                }
            }
            return doubleXCount;
        }
    }
}
