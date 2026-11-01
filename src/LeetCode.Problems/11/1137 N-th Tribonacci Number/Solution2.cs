namespace LeetCode.Problems._1137_N_th_Tribonacci_Number;

/// <seealso href="https://leetcode.com/submissions/detail/887782753/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int Tribonacci(int n)
    {
        var dp = new int[Math.Max(3, n + 1)];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;

        for (var i = 0; i <= n - 3; i++)
        {
            dp[i + 3] = dp[i] + dp[i + 1] + dp[i + 2];
        }

        return dp[n];
    }
}
