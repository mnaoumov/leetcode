namespace LeetCode.Problems._2215_Find_the_Difference_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/943578304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) => new IList<int>[] { nums1.Except(nums2).ToArray(), nums2.Except(nums1).ToArray() };
}
