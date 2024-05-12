using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1704_Determine_if_String_Halves_Are_Alike;

/// <summary>
/// https://leetcode.com/submissions/detail/852572559/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HalvesAreAlike(string s)
    {
        return CountVowels(s, 0, s.Length / 2) == CountVowels(s, s.Length / 2, s.Length / 2);
    }

    private static int CountVowels(string s, int startIndex, int length)
    {
        return Enumerable.Range(startIndex, length).Count(index => _vowels.Contains(s[index]));
    }

    private static HashSet<char> _vowels = new(new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });
}
