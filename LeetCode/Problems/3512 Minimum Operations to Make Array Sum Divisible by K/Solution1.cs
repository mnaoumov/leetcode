namespace LeetCode.Problems._3512_Minimum_Operations_to_Make_Array_Sum_Divisible_by_K;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-154/problems/minimum-operations-to-make-array-sum-divisible-by-k/submissions/1604591679/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int k) => nums.Sum() % k;
}
