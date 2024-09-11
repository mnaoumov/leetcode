namespace LeetCode.Problems._0198_House_Robber;

/// <summary>
/// https://leetcode.com/submissions/detail/859419358/
/// </summary>
[UsedImplicitly]
public class Solution : ISolution
{
    public int Rob(int[] nums)
    {
        var n = nums.Length;
        var dp = new int?[n];

        return Get(0);

        int Get(int i)
        {
            if (i >= n)
            {
                return 0;
            }

            if (dp[i] is { } result)
            {
                return result;
            }

            var result2 = Math.Max(nums[i] + Get(i + 2), Get(i + 1));
            dp[i] = result2;
            return result2;
        }
    }
}
