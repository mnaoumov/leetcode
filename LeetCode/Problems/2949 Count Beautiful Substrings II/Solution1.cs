namespace LeetCode.Problems._2949_Count_Beautiful_Substrings_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-373/submissions/detail/1106516711/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long BeautifulSubstrings(string s, int k)
    {
        var vowelLetters = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        var n = s.Length;
        var vowelPrefixCounts = new int[n];

        for (var i = 0; i < n; i++)
        {
            vowelPrefixCounts[i] = (i == 0 ? 0 : vowelPrefixCounts[i - 1]) + (vowelLetters.Contains(s[i]) ? 1 : 0);
        }

        var possibleVowelCounts = new List<int>();

        for (var vowelCount = 1; vowelCount <= n / 2; vowelCount++)
        {
            if (vowelCount * vowelCount % k == 0)
            {
                possibleVowelCounts.Add(vowelCount);
            }
        }

        var ans = 0L;

        foreach (var vowelCount in possibleVowelCounts)
        {
            for (var i = 0; i <= n - 2 * vowelCount; i++)
            {
                var j = 2 * vowelCount + i - 1;

                var actualVowelCount = vowelPrefixCounts[j] - (i == 0 ? 0 : vowelPrefixCounts[i - 1]);

                if (actualVowelCount == vowelCount)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
