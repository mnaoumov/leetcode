using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0200_Number_of_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/197101056/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
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
                    result++;

                    var isLandOnTop = i > 0 && grid[i - 1, j] == land;

                    if (isLandOnTop)
                    {
                        result--;
                    }

                    var isLandOnLeft = j > 0 && grid[i, j - 1] == land;

                    if (isLandOnLeft)
                    {
                        result--;
                    }

                    if (isLandOnLeft && isLandOnTop && islandNumber[i - 1, j] == islandNumber[i, j - 1])
                    {
                        result++;
                    }

                    islandNumber[i, j] = result;
                }
            }
        }

        return result;
    }
}
