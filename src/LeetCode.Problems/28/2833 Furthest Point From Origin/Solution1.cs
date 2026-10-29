namespace LeetCode.Problems._2833_Furthest_Point_From_Origin;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-360/submissions/detail/1032727626/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        var counts = moves.GroupBy(move => move).ToDictionary(g => g.Key, g => g.Count());
        return Math.Abs(counts.GetValueOrDefault('L', 0) - counts.GetValueOrDefault('R', 0)) +
               counts.GetValueOrDefault('_', 0);
    }
}
