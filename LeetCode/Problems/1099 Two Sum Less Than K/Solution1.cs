using JetBrains.Annotations;

namespace LeetCode._1099_Two_Sum_Less_Than_K;

/// <summary>
/// https://leetcode.com/submissions/detail/1109865607/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TwoSumLessThanK(int[] nums, int k)
    {
        var n = nums.Length;

        var ans = -1;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var sum = nums[i] + nums[j];

                if (sum < k)
                {
                    ans = Math.Max(ans, sum);
                }
            }
        }

        return ans;
    }
}
