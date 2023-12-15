namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
        DoubleX("axxbb") → true
        DoubleX("axaxax") → false
        DoubleX("xxxxx") → true
        */
        public bool DoubleX(string str)
        {
            // Was stuck on this for a while because I forgot to account for
            // if the first occurence of "x" was the last character in str.
            int firstXIndex = str.IndexOf("x");
            if (str.Length > 1 && firstXIndex > -1 && firstXIndex < str.Length - 1)
            {
                return str.Substring(firstXIndex + 1, 1) == "x";
            }
            return false;
            //if (str.Length > 1 && firstXIndex > -1 && str.Substring(firstXIndex, 2) == "xx")
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
