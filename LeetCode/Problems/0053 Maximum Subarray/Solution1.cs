using JetBrains.Annotations;

namespace LeetCode.Problems._0053_Maximum_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/819095461/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSubArray(int[] nums)
    {
        var cache = new int?[nums.Length];

        return Enumerable.Range(0, nums.Length).Select(GetMaxSumCachedOrCalculateStartingAt).Max();

        int GetMaxSumCachedOrCalculateStartingAt(int index)
        {
            if (cache[index] is not { } result)
            {
                cache[index] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                var maxSumStartingNext = index == nums.Length - 1 ? 0 : GetMaxSumCachedOrCalculateStartingAt(index + 1);
                return nums[index] + Math.Max(maxSumStartingNext, 0);
            }
        }
    }
}
