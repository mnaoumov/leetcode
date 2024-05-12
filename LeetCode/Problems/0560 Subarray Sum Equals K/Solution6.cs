using JetBrains.Annotations;

namespace LeetCode.Problems._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/856487459/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var counts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var sum = 0;

        var result = 0;

        foreach (var num in nums)
        {
            sum += num;
            result += counts.GetValueOrDefault(sum - k);
            counts[sum] = counts.GetValueOrDefault(sum) + 1;
        }

        return result;
    }
}
