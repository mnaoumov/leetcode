using JetBrains.Annotations;

namespace LeetCode._3000_Maximum_Area_of_Longest_Diagonal_Rectangle;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-379/submissions/detail/1139058347/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AreaOfMaxDiagonal(int[][] dimensions) =>
        dimensions
            .Select(dimension => (diagonalSquared: dimension[0] * dimension[0] + dimension[1] * dimension[1],
                area: dimension[0] * dimension[1])).MaxBy(x => (x.diagonalSquared, x.area)).area;
}
