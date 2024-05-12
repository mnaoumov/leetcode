using JetBrains.Annotations;

namespace LeetCode.Problems._1675_Minimize_Deviation_in_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/903872869/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumDeviation(int[] nums)
    {
        var sortedSet = new SortedSet<int>(nums);

        var result = sortedSet.Max - sortedSet.Min;

        while (sortedSet.Min % 2 == 1)
        {
            var min = sortedSet.Min;
            sortedSet.Remove(min);
            sortedSet.Add(min * 2);
            result = Math.Min(result, sortedSet.Max - sortedSet.Min);
        }

        while (sortedSet.Max % 2 == 0)
        {
            var max = sortedSet.Max;
            sortedSet.Remove(max);
            sortedSet.Add(max / 2);
            result = Math.Min(result, sortedSet.Max - sortedSet.Min);
        }

        return result;
    }
}
