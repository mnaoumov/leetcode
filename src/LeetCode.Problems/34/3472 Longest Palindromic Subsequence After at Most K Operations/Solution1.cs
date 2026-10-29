namespace LeetCode.Problems._3472_Longest_Palindromic_Subsequence_After_at_Most_K_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-439/problems/longest-palindromic-subsequence-after-at-most-k-operations/submissions/1559854144/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestPalindromicSubsequence(string s, int k)
    {
        var n = s.Length;

        for (var length = n; length >= 1; length--)
        {
            for (var j = 0; j <= n - length; j++)
            {
                var totalDist = 0;

                for (var m = 0; m < length / 2; m++)
                {
                    var dist = Math.Abs(s[j + m] - s[j + length - m - 1]);
                    dist = Math.Min(dist, 26 - dist);
                    totalDist += dist;

                    if (totalDist > k)
                    {
                        break;
                    }
                }

                if (totalDist <= k)
                {
                    return length;
                }
            }
        }

        return 1;
    }
}
