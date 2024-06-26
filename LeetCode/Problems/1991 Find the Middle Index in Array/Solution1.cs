using JetBrains.Annotations;

namespace LeetCode.Problems._1991_Find_the_Middle_Index_in_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1299463633/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMiddleIndex(int[] nums)
    {
        var n = nums.Length;
        var sums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            sums[i + 1] = sums[i] + nums[i];
        }

        for (var i = 0; i < n; i++)
        {
            var sumLeft = sums[i];
            var sumRight = sums[^1] - sums[i + 1];

            if (sumLeft == sumRight)
            {
                return i;
            }
        }

        return -1;
    }
}
