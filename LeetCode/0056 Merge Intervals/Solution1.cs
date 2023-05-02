using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0056_Merge_Intervals;

/// <summary>
/// https://leetcode.com/submissions/detail/197151975/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] Merge(int[][] intervals) => Interval.ToArrays(Merge(Interval.FromArrays(intervals)));

    /// <summary>
    /// Was different signature
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public IList<Interval> Merge(IList<Interval> intervals)
    {
        var results = intervals.OrderBy(x => x.start).ThenBy(x => x.end).ToList();

        for (int i = 1; i < results.Count; i++)
        {
            var previous = results[i - 1];
            var current = results[i];
            if (current.start <= previous.end)
            {
                results[i - 1] = new Interval(previous.start, current.end);
                results.RemoveAt(i);
                i--;
            }
        }

        return results;
    }
}
