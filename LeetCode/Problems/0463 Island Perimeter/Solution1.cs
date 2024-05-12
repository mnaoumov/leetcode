using JetBrains.Annotations;

namespace LeetCode.Problems._0463_Island_Perimeter;

/// <summary>
/// https://leetcode.com/submissions/detail/906256990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IslandPerimeter(int[][] grid)
    {
        var row = grid.Length;
        var col = grid[0].Length;

        var deltas = new (int di, int dj)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var result = 0;

        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < col; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                result += 4;

                foreach (var (di, dj) in deltas)
                {
                    var nextI = i + di;
                    var nextJ = j + dj;

                    if (nextI >= 0 && nextI < row && nextJ >= 0 && nextJ < col && grid[nextI][nextJ] == 1)
                    {
                        result--;
                    }
                }

            }
        }

        return result;
    }
}
