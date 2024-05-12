using JetBrains.Annotations;

namespace LeetCode.Problems._3026_Maximum_Good_Subarray_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-123/submissions/detail/1164882087/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var numToIndicesMap = Enumerable.Range(0, n).GroupBy(i => nums[i]).ToDictionary(g => g.Key, g => g.ToArray());

        var ans = long.MinValue;

        for (var i = 0; i < n; i++)
        {
            var starNum = nums[i];
            ans = new[] { starNum - k, starNum + k }
                .Aggregate(ans, (current, endNum) =>
                    numToIndicesMap.GetValueOrDefault(endNum, Array.Empty<int>())
                        .Where(j => j > i)
                        .Select(j => prefixSums[j + 1] - prefixSums[i])
                        .Prepend(current)
                        .Max()
                );
        }

        return ans == long.MinValue ? 0 : ans;
    }
}
