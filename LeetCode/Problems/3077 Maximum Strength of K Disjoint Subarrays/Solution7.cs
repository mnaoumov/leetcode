namespace LeetCode.Problems._3077_Maximum_Strength_of_K_Disjoint_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1199973829/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public long MaximumStrength(int[] nums, int k)
    {
        var n = nums.Length;
        var dp = new long[n + 1, k + 1, 2];
        const long impossible = long.MinValue;

        for (var i = n; i >= 0; i--)
        {
            for (var j = 0; j <= k ; j++)
            {
                if (n - i < j)
                {
                    dp[i, j, 1] = impossible;
                    dp[i, j, 0] = impossible;
                }
                else if (j == 0)
                {
                    dp[i, 0, 1] = impossible;
                    dp[i, 0, 0] = 0;
                }
                else
                {
                    var sum = 1L * nums[i] * j * (j % 2 == 1 ? 1 : -1);

                    var next = Math.Max(
                        dp[i + 1, j - 1, 0],
                        dp[i + 1, j, 1]
                    );

                    dp[i, j, 1] = next == impossible ? impossible : sum + next;

                    dp[i, j, 0] =
                        Math.Max(
                            dp[i + 1, j, 0],
                            dp[i, j, 1]
                        );
                }
            }
        }

        return dp[0, k, 0];
    }
}
