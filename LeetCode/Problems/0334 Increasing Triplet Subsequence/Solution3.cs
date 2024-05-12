using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0334_Increasing_Triplet_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/820348412/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
        {
            return false;
        }

        int? minFirstValue = null;
        int? minSecondValue = null;

        foreach (var num in nums)
        {
            if (minSecondValue < num)
            {
                return true;
            }

            if (minFirstValue == null || num < minFirstValue)
            {
                minFirstValue = num;
            }

            if (minFirstValue < num)
            {
                if (minSecondValue == null || num < minSecondValue)
                {
                    minSecondValue = num;
                }
            }
        }

        return false;
    }
}
