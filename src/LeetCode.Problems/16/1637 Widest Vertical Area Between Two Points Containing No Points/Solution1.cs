namespace LeetCode.Problems._1637_Widest_Vertical_Area_Between_Two_Points_Containing_No_Points;

/// <summary>
/// https://leetcode.com/submissions/detail/1124802013/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        var xs = points.Select(p => p[0]).Distinct().OrderBy(x => x).ToArray();
        return xs.Length == 1 ? 0 : Enumerable.Range(0, xs.Length - 1).Max(i => xs[i + 1] - xs[i]);
    }
}
