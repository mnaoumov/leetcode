namespace LeetCode.Problems._2947_Count_Beautiful_Substrings_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-373/submissions/detail/1106465945/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BeautifulSubstrings(string s, int k)
    {
        var vowelLetters = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        var n = s.Length;
        var vowelPrefixCounts = new int[n];

        for (var i = 0; i < n; i++)
        {
            vowelPrefixCounts[i] = (i == 0 ? 0 : vowelPrefixCounts[i - 1]) + (vowelLetters.Contains(s[i]) ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j += 2)
            {
                var vowels = vowelPrefixCounts[j] - (i == 0 ? 0 : vowelPrefixCounts[i - 1]);
                var consonants = j - i + 1 - vowels;

                if (vowels != consonants)
                {
                    continue;
                }

                if (vowels * consonants % k == 0)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
