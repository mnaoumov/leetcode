namespace LeetCode.Problems._0136_Single_Number;

/// <seealso href="https://leetcode.com/problems/single-number/submissions/839785368/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SingleNumber(int[] nums) => nums.Aggregate(0, (current, num) => current ^ num);
}
