namespace LeetCode.Problems._3724_Minimum_Operations_to_Transform_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-168/problems/minimum-operations-to-transform-array/submissions/1811364755/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinOperations(int[] nums1, int[] nums2)
    {
        var ans = 1L;
        var n = nums1.Length;
        var last = nums2[^1];
        var minDistanceToLast = Math.Abs(nums1[0] - last);

        for (var i = 0; i < n; i++)
        {
            ans += Math.Abs(nums1[i] - nums2[i]);

            var diff1 = nums1[i] - last;
            var diff2 = nums2[i] - last;

            if (Math.Sign(diff1) == Math.Sign(diff2))
            {
                minDistanceToLast = new[] { minDistanceToLast, Math.Abs(diff1), Math.Abs(diff2) }.Min();
            }
            else
            {
                minDistanceToLast = 0;
            }
        }

        ans += minDistanceToLast;
        return ans;
    }
}
