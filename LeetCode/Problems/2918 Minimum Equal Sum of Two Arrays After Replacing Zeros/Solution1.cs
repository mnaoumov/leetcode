using JetBrains.Annotations;

namespace LeetCode._2918_Minimum_Equal_Sum_of_Two_Arrays_After_Replacing_Zeros;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-369/submissions/detail/1086473425/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        var sum1 = nums1.Select(num => (long) num).Sum();
        var sum2 = nums2.Select(num => (long) num).Sum();
        var zeroCount1 = nums1.Count(num => num == 0);
        var zeroCount2 = nums2.Count(num => num == 0);

        var min1 = sum1 + zeroCount1;
        var min2 = sum2 + zeroCount2;

        if (zeroCount2 == 0 && min1 > sum2 || zeroCount1 == 0 && min2 > sum1)
        {
            return -1;
        }

        return Math.Max(min1, min2);
    }
}
