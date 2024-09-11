namespace LeetCode.Problems._1704_Determine_if_String_Halves_Are_Alike;

/// <summary>
/// https://leetcode.com/submissions/detail/852632401/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    private static readonly HashSet<char> Vowels = new(new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

    public bool HalvesAreAlike(string s) => CountVowels(s, 0, s.Length / 2) == CountVowels(s, s.Length / 2, s.Length / 2);

    private static int CountVowels(string s, int startIndex, int length) => Enumerable.Range(startIndex, length).Count(index => Vowels.Contains(s[index]));
}
