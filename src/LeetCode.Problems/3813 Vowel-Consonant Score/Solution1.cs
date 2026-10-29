namespace LeetCode.Problems._3813_Vowel_Consonant_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-485/problems/vowel-consonant-score/submissions/1888374208/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int VowelConsonantScore(string s)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var v = s.Count(symbol => vowels.Contains(symbol));
        var c = s.Count(symbol => char.IsLetter(symbol) && !vowels.Contains(symbol));

        return c == 0 ? 0 : v / c;
    }
}
