namespace LeetCode.Problems._2656_Maximum_Sum_With_Exactly_K_Elements;

/// <seealso href="https://leetcode.com/contest/biweekly-contest-103/submissions/detail/941577257/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximizeSum(int[] nums, int k)
    {
        var max = nums.Max();
        return (2 * max + k - 1) * k / 2;
    }
}
