using JetBrains.Annotations;

namespace LeetCode._2849_Determine_if_a_Cell_Is_Reachable_at_a_Given_Time;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-362/submissions/detail/1045201834/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
    {
        var dx = Math.Abs(fx - sx);
        var dy = Math.Abs(fy - sy);
        var min = Math.Max(dx, dy);
        return t >= min && (min > 0 || t == 0);
    }
}
