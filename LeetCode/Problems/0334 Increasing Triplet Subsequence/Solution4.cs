using JetBrains.Annotations;

namespace LeetCode.Problems._0334_Increasing_Triplet_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/829093640/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

            if (minFirstValue >= num)
            {
                continue;
            }

            if (minSecondValue == null || num < minSecondValue)
            {
                minSecondValue = num;
            }
        }

        return false;
    }
}
