namespace LeetCode.Problems._0516_Longest_Palindromic_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/929999265/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestPalindromeSubseq(string s)
    {
        var dp = new Dictionary<(int start, int end), int>();
        var n = s.Length;

        return Dp(0, n - 1);

        int Dp(int start, int end)
        {
            if (start > end)
            {
                return 0;
            }

            if (start == end)
            {
                return 1;
            }

            var key = (start, end);
            if (dp.TryGetValue(key, out var result))
            {
                return result;
            }

            if (s[start] == s[end])
            {
                return dp[key] = 2 + Dp(start + 1, end - 1);
            }

            return dp[key] = Math.Max(Dp(start + 1, end), Dp(start, end - 1));
        }
    }
}
