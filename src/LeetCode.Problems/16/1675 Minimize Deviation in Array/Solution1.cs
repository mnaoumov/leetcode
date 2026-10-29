namespace LeetCode.Problems._1675_Minimize_Deviation_in_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/903871143/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumDeviation(int[] nums)
    {
        var sortedSet = new SortedSet<int>(nums);

        while (sortedSet.Min % 2 == 1)
        {
            var min = sortedSet.Min;
            sortedSet.Remove(min);
            sortedSet.Add(min * 2);
        }

        while (sortedSet.Max % 2 == 0)
        {
            var max = sortedSet.Max;
            sortedSet.Remove(max);
            sortedSet.Add(max / 2);
        }

        return sortedSet.Max - sortedSet.Min;
    }
}
