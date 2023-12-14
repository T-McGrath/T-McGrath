
/// <summary>
/// Extension methods for helping test characters.
/// </summary>
public static class CharHelpers
{
    /// <summary>
    /// This is a convenience method to convert a char to an uppercase invariant
    /// string. This extension method simplifies the test code for grading.
    /// </summary>
    /// <param name="letter">The character to convert</param>
    /// <returns>An uppercase invariant version of <paramref name="letter"/></returns>
    public static string ToUpperString(this char letter)
    {
        return letter.ToString().ToUpperInvariant();
    }
}
