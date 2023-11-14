using JetBrains.Annotations;

namespace LeetCode._2934_Minimum_Operations_to_Maximize_Last_Elements_in_Arrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-371/submissions/detail/1096976759/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var countWithoutLastSwap = 0;
        var countWithLastSwap = 1;

        for (var i = 0; i < n - 1; i++)
        {
            var num1 = nums1[i];
            var num2 = nums2[i];

            var isDirectAligned = num1 <= nums1[^1] && num2 <= nums2[^1];
            var isSwappedAligned = num1 <= nums2[^1] && num2 <= nums1[^1];

            if (isDirectAligned)
            {
                if (!isSwappedAligned)
                {
                    countWithLastSwap++;
                }
            }
            else
            {
                if (isSwappedAligned)
                {
                    countWithoutLastSwap++;
                }
                else
                {
                    return -1;
                }
            }
        }

        return Math.Min(countWithoutLastSwap, countWithLastSwap);
    }
}
