using JetBrains.Annotations;

namespace LeetCode.Problems._1512_Number_of_Good_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/898955623/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumIdenticalPairs(int[] nums) =>
        nums.GroupBy(num => num).Sum(g =>
        {
            var count = g.Count();
            return count * (count - 1) / 2;
        });
}
