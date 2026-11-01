namespace LeetCode.Problems._3151_Special_Array_I;

/// <seealso href="https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261743124/">Submission</seealso>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsArraySpecial(int[] nums) => Enumerable.Range(0, nums.Length - 1).All(i => (nums[i + 1] - nums[i]) % 2 == 1);
}
