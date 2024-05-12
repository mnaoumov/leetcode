using JetBrains.Annotations;

namespace LeetCode.Problems._0974_Subarray_Sums_Divisible_by_K;

/// <summary>
/// https://leetcode.com/submissions/detail/880926140/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var remainderCounts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var sum = 0;
        var result = 0;

        foreach (var num in nums)
        {
            sum += num;
            var remainder = (sum % k + k) % k;
            var remainderCount = remainderCounts.GetValueOrDefault(remainder);
            result += remainderCount;
            remainderCounts[remainder] = remainderCount + 1;
        }

        return result;
    }
}
