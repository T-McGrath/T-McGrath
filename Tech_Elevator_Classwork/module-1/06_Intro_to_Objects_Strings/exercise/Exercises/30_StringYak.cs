namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed.
        The "yak" strings will not overlap.
        StringYak("yakpak") → "pak"
        StringYak("pakyak") → "pak"
        StringYak("yak123ya") → "123ya"
        */
        public string StringYak(string str)
        {
            // This feels like cheating...so I tried a more complicated way.
            //return str.Replace("yak", "");
            string result = "";
            for(int i = 0; i < str.Length; i++)
            {
                if(i < str.Length - 2 && str.Substring(i, 1) == "y")
                {
                    if(str.Substring(i, 3) != "yak")
                    {
                        result += str[i]; // Same as str.Substring(i, 1);
                    }
                    else // Skip ahead so we don't check the subsequent "a" and "k" individually.
                    {
                        i += 2;
                    }
                }
                else
                {
                    result += str.Substring(i, 1);
                }
            }
            return result;
        }
    }
}
