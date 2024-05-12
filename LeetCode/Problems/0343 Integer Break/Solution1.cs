using JetBrains.Annotations;

namespace LeetCode._0343_Integer_Break;

/// <summary>
/// https://leetcode.com/submissions/detail/930021027/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IntegerBreak(int n)
    {
        var dp = new int[n + 1];
        dp[1] = 1;
        for (var i = 2; i <= n; i++)
        {
            dp[i] = 0;
            for (var j = 1; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], j * Math.Max(i - j, dp[i - j]));
            }
        }
        return dp[n];
    }
}
