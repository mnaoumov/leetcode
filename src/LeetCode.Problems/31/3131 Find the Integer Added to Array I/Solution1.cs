namespace LeetCode.Problems._3131_Find_the_Integer_Added_to_Array_I;

/// <seealso href="https://leetcode.com/contest/weekly-contest-395/submissions/detail/1243732099/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AddedInteger(int[] nums1, int[] nums2) => nums2.Min() - nums1.Min();
}
