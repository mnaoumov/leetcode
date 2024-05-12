using JetBrains.Annotations;

namespace LeetCode._3046_Split_the_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-386/submissions/detail/1185321359/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPossibleToSplit(int[] nums) =>
        nums.GroupBy(num => num).Select(g => g.Count()).All(count => count <= 2);
}
