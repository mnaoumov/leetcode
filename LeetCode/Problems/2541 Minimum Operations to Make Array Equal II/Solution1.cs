using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2541_Minimum_Operations_to_Make_Array_Equal_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-96/submissions/detail/882427768/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long MinOperations(int[] nums1, int[] nums2, int k)
    {
        var n = nums1.Length;

        var result = 0L;
        var diffSum = 0L;

        for (var i = 0; i < n; i++)
        {
            var diff = nums2[i] - nums1[i];

            if (diff % k != 0)
            {
                return -1;
            }

            diffSum += diff;

            if (diff > 0)
            {
                result += diff / k;
            }
        }

        if (diffSum != 0)
        {
            return -1;
        }

        return result;
    }
}
