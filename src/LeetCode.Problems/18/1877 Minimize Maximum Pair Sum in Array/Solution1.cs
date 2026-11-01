namespace LeetCode.Problems._1877_Minimize_Maximum_Pair_Sum_in_Array;

/// <seealso href="https://leetcode.com/submissions/detail/1100917095/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;
        return Enumerable.Range(0, n / 2).Max(i => nums[i] + nums[^(i + 1)]);
    }
}
