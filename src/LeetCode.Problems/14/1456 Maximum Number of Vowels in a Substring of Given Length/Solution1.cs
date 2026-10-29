namespace LeetCode.Problems._1456_Maximum_Number_of_Vowels_in_a_Substring_of_Given_Length;

/// <summary>
/// https://leetcode.com/submissions/detail/898901402/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxVowels(string s, int k)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var result = 0;
        var count = 0;

        for (var i = 0; i < s.Length; i++)
        {
            count += (vowels.Contains(s[i]) ? 1 : 0) - (i >= k && vowels.Contains(s[i - k]) ? 1 : 0);
            result = Math.Max(result, count);
        }

        return result;
    }
}
