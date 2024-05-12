using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/199933351/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        return MaxCoins(new List<int>(nums));
    }

    private int MaxCoins(List<int> nums)
    {
        if (nums.Count == 0)
        {
            return 0;
        }

        var max = int.MinValue;
        for (int i = 0; i < nums.Count; i++)
        {
            var current = nums[i];
            var left = i - 1 >= 0 ? nums[i - 1] : 1;
            var right = (i + 1 < nums.Count ? nums[i + 1] : 1);
            nums.RemoveAt(i);
            var candidate = left * current * right + MaxCoins(nums);
            if (candidate > max)
            {
                max = candidate;
            }
            nums.Insert(i, current);
        }

        return max;
    }
}
