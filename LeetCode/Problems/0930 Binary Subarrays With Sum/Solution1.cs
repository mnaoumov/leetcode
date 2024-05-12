using JetBrains.Annotations;

namespace LeetCode.Problems._0930_Binary_Subarrays_With_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/898963795/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        var n = nums.Length;
        var counts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var sum = 0;
        var result = 0;

        for (var i = 0; i < n; i++)
        {
            sum += nums[i];
            result += counts.GetValueOrDefault(sum - goal);
            counts[sum] = counts.GetValueOrDefault(sum) + 1;
        }

        return result;
    }
}
