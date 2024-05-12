using JetBrains.Annotations;

namespace LeetCode.Problems._0910_Smallest_Range_II;

/// <summary>
/// https://leetcode.com/submissions/detail/950973744/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestRangeII(int[] nums, int k)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        Array.Sort(nums);

        var ans = nums[^1] - nums[0];

        for (var i = 0; i < nums.Length - 1; i++)
        {
            var min = Math.Min(nums[0] + k, nums[i + 1] - k);
            var max = Math.Max(nums[^1] - k, nums[i] + k);
            ans = Math.Min(ans, max - min);
        }

        return ans;
    }
}
