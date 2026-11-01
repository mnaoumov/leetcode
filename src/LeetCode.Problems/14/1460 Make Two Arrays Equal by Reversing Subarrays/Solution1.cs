namespace LeetCode.Problems._1460_Make_Two_Arrays_Equal_by_Reversing_Subarrays;

/// <seealso href="https://leetcode.com/submissions/detail/1342425048/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanBeEqual(int[] target, int[] arr) => target.OrderBy(x => x).SequenceEqual(arr.OrderBy(x => x));
}
