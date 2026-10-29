namespace LeetCode.Problems._3503_Longest_Palindrome_After_Substring_Concatenation_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-443/problems/longest-palindrome-after-substring-concatenation-i/submissions/1590643693/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int LongestPalindrome(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;

        var ans = 0;

        for (var i = 0; i <= n; i++)
        {
            for (var j = i; j <= n; j++)
            {
                var subS = s[i..j];

                for (var k = 0; k < m; k++)
                {
                    for (var l = k; l <= m; l++)
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
