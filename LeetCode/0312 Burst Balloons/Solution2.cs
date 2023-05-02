using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/199937476/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        return MaxCoins(new List<int>(nums), new Dictionary<string, int>());
    }

    private int MaxCoins(List<int> nums, Dictionary<string, int> cache)
    {
        if (nums.Count == 0)
        {
            return 0;
        }

        var key = string.Join(",", nums);

        if (cache.ContainsKey(key))
        {
            return cache[key];
        }

        var max = int.MinValue;
        for (int i = 0; i < nums.Count; i++)
        {
            var current = nums[i];
            var left = i - 1 >= 0 ? nums[i - 1] : 1;
            var right = (i + 1 < nums.Count ? nums[i + 1] : 1);
            nums.RemoveAt(i);
            var candidate = left * current * right + MaxCoins(nums, cache);
            if (candidate > max)
            {
                max = candidate;
            }
            nums.Insert(i, current);
        }

        cache[key] = max;

        return max;
    }
}
