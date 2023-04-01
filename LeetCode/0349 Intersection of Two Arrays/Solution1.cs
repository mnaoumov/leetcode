using JetBrains.Annotations;

namespace LeetCode._0349_Intersection_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/926233414/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] Intersection(int[] nums1, int[] nums2) => nums1.Intersect(nums2).Distinct().ToArray();
}
