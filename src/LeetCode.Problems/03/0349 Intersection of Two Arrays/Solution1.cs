namespace LeetCode.Problems._0349_Intersection_of_Two_Arrays;

/// <seealso href="https://leetcode.com/submissions/detail/926233414/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] Intersection(int[] nums1, int[] nums2) => nums1.Intersect(nums2).Distinct().ToArray();
}
