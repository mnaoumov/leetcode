using JetBrains.Annotations;

namespace LeetCode.Problems._1662_Check_If_Two_String_Arrays_are_Equivalent;

/// <summary>
/// https://leetcode.com/submissions/detail/829651470/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) => GetLetters(word1).SequenceEqual(GetLetters(word2));

    private static IEnumerable<char> GetLetters(IEnumerable<string> word) => word.SelectMany(letter => letter);
}
