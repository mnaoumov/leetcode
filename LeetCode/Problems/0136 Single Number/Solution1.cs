using JetBrains.Annotations;

namespace LeetCode.Problems._0136_Single_Number;

/// <summary>
/// https://leetcode.com/problems/single-number/submissions/839785368/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SingleNumber(int[] nums) => nums.Aggregate(0, (current, num) => current ^ num);
}
