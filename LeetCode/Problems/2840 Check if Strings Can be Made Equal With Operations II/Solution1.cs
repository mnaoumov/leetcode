using JetBrains.Annotations;

namespace LeetCode._2840_Check_if_Strings_Can_be_Made_Equal_With_Operations_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-112/submissions/detail/1038512794/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckStrings(string s1, string s2)
    {
        var n = s1.Length;
        return ExtractLetters(s1, 0).SequenceEqual(ExtractLetters(s2, 0)) &&
               ExtractLetters(s1, 1).SequenceEqual(ExtractLetters(s2, 1));

        IEnumerable<char> ExtractLetters(string str, int remainder) => Enumerable.Range(0, n)
            .Where(i => i % 2 == remainder).Select(i => str[i]).OrderBy(letter => letter);
    }
}
