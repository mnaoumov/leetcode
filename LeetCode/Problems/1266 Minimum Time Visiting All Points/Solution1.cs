namespace LeetCode.Problems._1266_Minimum_Time_Visiting_All_Points;

/// <summary>
/// https://leetcode.com/submissions/detail/1111139530/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTimeToVisitAllPoints(int[][] points) => Enumerable.Range(1, points.Length - 1).Sum(i =>
        Math.Max(Math.Abs(points[i][0] - points[i - 1][0]), Math.Abs(points[i][1] - points[i - 1][1])));
}
