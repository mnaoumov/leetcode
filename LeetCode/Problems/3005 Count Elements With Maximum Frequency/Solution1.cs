using JetBrains.Annotations;

namespace LeetCode.Problems._3005_Count_Elements_With_Maximum_Frequency;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-380/submissions/detail/1145531857/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxFrequencyElements(int[] nums)
    {
        var counts = nums.GroupBy(num => num).Select(g => g.Count()).OrderByDescending(x => x).ToArray();
        return counts.TakeWhile(c => c == counts[0]).Sum();
    }
}
