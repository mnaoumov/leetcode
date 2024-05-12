using JetBrains.Annotations;

namespace LeetCode.Problems._2540_Minimum_Common_Value;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-96/submissions/detail/882417317/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        var index1 = 0;
        var index2 = 0;

        while (index1 < nums1.Length && index2 < nums2.Length)
        {
            var num1 = nums1[index1];
            var num2 = nums2[index2];

            if (num1 == num2)
            {
                return num1;
            }

            if (num1 < num2)
            {
                index1++;
            }

            if (num1 > num2)
            {
                index2++;
            }
        }

        return -1;
    }
}
