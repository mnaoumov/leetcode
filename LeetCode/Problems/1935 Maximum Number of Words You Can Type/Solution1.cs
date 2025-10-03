namespace LeetCode.Problems._1935_Maximum_Number_of_Words_You_Can_Type;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-words-you-can-type/submissions/1771139791/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var set = brokenLetters.ToHashSet();
        return text.Split(' ').Count(word => !word.ToCharArray().Any(set.Contains));
    }
}
