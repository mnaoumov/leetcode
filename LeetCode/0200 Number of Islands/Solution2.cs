using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0200_Number_of_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/197104243/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumIslands(char[][] grid) => NumIslands(ArrayHelper.ArrayOfArraysTo2D(grid));

    /// <summary>
    /// Was different signature
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands(char[,] grid)
    {
        var result = 0;
        var m = grid.GetLength(0);
        var n = grid.GetLength(1);
        int[,] islandNumber = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                const char land = '1';
                if (grid[i, j] == land)
                {
                    var topIslandNumber = i > 0 ? islandNumber[i - 1, j] : 0;
                    var leftIslandNumber = j > 0 ? islandNumber[i, j - 1] : 0;

                    if (topIslandNumber == 0 && leftIslandNumber == 0)
                    {
                        result++;
                        islandNumber[i, j] = result;
                    }
                    else
                    {
                        islandNumber[i, j] = Math.Max(topIslandNumber, leftIslandNumber);
                    }

                    if (topIslandNumber != 0 && leftIslandNumber != 0 && topIslandNumber != leftIslandNumber)
                    {
                        result--;
                    }
                }
            }
        }

        return result;
    }
}
