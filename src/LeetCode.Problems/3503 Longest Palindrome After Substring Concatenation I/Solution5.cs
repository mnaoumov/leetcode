namespace LeetCode.Problems._3503_Longest_Palindrome_After_Substring_Concatenation_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-443/problems/longest-palindrome-after-substring-concatenation-i/submissions/1590655649/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public int LongestPalindrome(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;

        var ans = 0;

        for (var i = 0; i < Math.Min(n, m + n - ans); i++)
        {
            for (var j = Math.Max(i, ans - m + i + 1); j <= n; j++)
            {
                var subS = s[i..j];

                for (var k = 0; k < m - ans - k - i + j; k++)
                {
                    for (var l = Math.Max(k, ans + k + i - j + 1); l <= m; l++)
                    {
                        var subT = t[k..l];
                        var candidate = subS + subT;
                        var reversedCandidate = new string(candidate.Reverse().ToArray());

                        if (candidate == reversedCandidate)
                        {
                            ans = Math.Max(ans, candidate.Length);
                        }
                    }
                }
            }

        }

        return ans;
    }
}
