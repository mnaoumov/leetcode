using JetBrains.Annotations;

namespace LeetCode._2875_Minimum_Size_Subarray_in_Infinite_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1063692877/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinSizeSubarray(int[] nums, int target)
    {
        var n = nums.Length;

        var prefixes = new long[n + 1];

        for (var i = 1; i <= n; i++)
        {
            prefixes[i] = prefixes[i - 1] + nums[i - 1];
        }

        var sum = prefixes[n];

        var diffSizeMap = new Dictionary<long, int>();

        for (var i = 0; i <= n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                var diff = prefixes[j] - prefixes[i];
                diffSizeMap.TryAdd(diff, int.MaxValue);
                diffSizeMap[diff] = Math.Min(diffSizeMap[diff], j - i);
                var cyclicDiff = sum - diff;
                diffSizeMap.TryAdd(cyclicDiff, int.MaxValue);
                diffSizeMap[cyclicDiff] = Math.Min(diffSizeMap[cyclicDiff], n - j + i);
            }
        }

        var minDiff = diffSizeMap.Keys.Min();
        var maxDiff = diffSizeMap.Keys.Max();

        int minCycleCount;
        int maxCycleCount;

        switch (sum)
        {
            case 0:
                minCycleCount = 0;
                maxCycleCount = 0;
                break;
            case > 0:
                minCycleCount = Math.Max(0, (int) Math.Ceiling(1d * (target - maxDiff) / sum));
                maxCycleCount = (int) Math.Floor(1d * (target - minDiff) / sum);
                break;
            default:
                minCycleCount = Math.Max(0, (int) Math.Ceiling(1d * (target - minDiff) / sum));
                maxCycleCount = (int) Math.Floor(1d * (target - maxDiff) / sum);
                break;
        }

        for (var cycleCount = minCycleCount; cycleCount <= maxCycleCount; cycleCount++)
        {
            var newTarget = target - sum * cycleCount;

            if (diffSizeMap.TryGetValue(newTarget, out var size))
            {
                return size + n * cycleCount;
            }
        }

        return -1;
    }
}
