using JetBrains.Annotations;

namespace LeetCode.Problems._2605_Form_Smallest_Number_From_Two_Digit_Arrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-101/submissions/detail/925951229/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinNumber(int[] nums1, int[] nums2)
    {
        var minCommon = nums1.Intersect(nums2).Append(10).Min();

        if (minCommon != 10)
        {
            return minCommon;
        }

        var min1 = nums1.Min();
        var min2 = nums2.Min();

        return Math.Min(min1, min2) * 10 + Math.Max(min1, min2);
    }
}
