using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2444_Count_Subarrays_With_Fixed_Bounds;

/// <summary>
/// https://leetcode.com/submissions/detail/823471637/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        if (minK > maxK)
        {
            return 0;
        }

        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
            {
                continue;
            }

            for (var j = i; j < nums.Length; j++)
            {
                if (nums[j] < minK || nums[j] > maxK)
                {
                    break;
                }

                var subArray = nums[i..(j + 1)];
                if (subArray.Min() == minK && subArray.Max() == maxK)
                {
                    result++;
                }
            }

        }

        return result;
    }
}
