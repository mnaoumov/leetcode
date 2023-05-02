using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0334_Increasing_Triplet_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/820225745/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
        {
            return false;
        }

        for (var j = 1; j < nums.Length - 1; j++)
        {
            if (Enumerable.Range(0, j).Any(i => nums[i] < nums[j]) && Enumerable.Range(j + 1, nums.Length - j - 1).Any(k => nums[j] < nums[k]))
            {
                return true;
            }
        }

        return false;
    }
}
