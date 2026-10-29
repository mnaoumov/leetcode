namespace LeetCode.Problems._1636_Sort_Array_by_Increasing_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/1331193866/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FrequencySort(int[] nums) => nums
        .GroupBy(num => num)
        .Select(g => (num: g.Key, count: g.Count()))
        .OrderBy(x => x.count)
        .ThenByDescending(x => x.num)
        .SelectMany(x => Enumerable.Repeat(x.num, x.count))
        .ToArray();
}
