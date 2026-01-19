namespace LeetCode.Problems._3810_Minimum_Operations_to_Reach_Target_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-174/problems/minimum-operations-to-reach-target-array/submissions/1887860224/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int[] target) =>
        nums
            .Zip(target, (num, targetNum) => (num, targetNum))
            .Where(x => x.num != x.targetNum)
            .Select(x => x.num)
            .Distinct()
            .Count();
}
