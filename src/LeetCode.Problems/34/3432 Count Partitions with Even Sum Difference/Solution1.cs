namespace LeetCode.Problems._3432_Count_Partitions_with_Even_Sum_Difference;

/// <summary>
/// https://leetcode.com/problems/count-partitions-with-even-sum-difference/submissions/1847191352/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPartitions(int[] nums) => nums.Sum() % 2 == 0 ? nums.Length - 1 : 0;
}
