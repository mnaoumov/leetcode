namespace LeetCode.Problems._3503_Longest_Palindrome_After_Substring_Concatenation_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-443/problems/longest-palindrome-after-substring-concatenation-i/submissions/1590633426/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int LongestPalindrome(string s, string t)
    {
        var n = s.Length;
        var ans = 1;

        for (var i = 0; i <= n - ans; i++)
        {
            for (var j = i + ans; j <= n; j++)
            {
                var subS = s[i..j];
                var reversedSubS = new string(subS.Reverse().ToArray());

                if (subS == reversedSubS)
                {
                    ans = Math.Max(ans, j - i);
                }

                var lastIndex = t.LastIndexOf(reversedSubS, StringComparison.Ordinal);

                if (lastIndex == -1)
                {
                    continue;
                }

                ans = Math.Max(ans, 2 * (j - i) + (lastIndex == 0 ? 0 : 1));
            }
        }

        var m = t.Length;

        for (var i = 0; i < m - ans; i++)
        {
            for (var j = i + ans + 1; j <= m; j++)
            {
                var subT = t[i..j];
                var reversedSubT = new string(subT.Reverse().ToArray());
                if (subT == reversedSubT)
                {
                    ans = Math.Max(ans, j - i);
                }
            }
        }

        return ans;
    }
}
