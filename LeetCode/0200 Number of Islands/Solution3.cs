using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0200_Number_of_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/197108988/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
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
        int[,] islandNumbers = new int[m, n];
        var islandNumberMappings = new Dictionary<int, int>
        {
            [0] = 0
        };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                const char land = '1';
                if (grid[i, j] == land)
                {
                    var topIslandNumber = GetIslandNumber(i - 1, j);
                    var leftIslandNumber = GetIslandNumber(i, j - 1);

                    if (topIslandNumber != 0)
                    {
                        islandNumbers[i, j] = topIslandNumber;
                    }
                    else if (leftIslandNumber != 0)
                    {
                        islandNumbers[i, j] = leftIslandNumber;
                    }
                    else
                    {
                        result++;
                        islandNumbers[i, j] = result;
                        islandNumberMappings[result] = result;
                    }

                    if (topIslandNumber != 0 && leftIslandNumber != 0 && topIslandNumber != leftIslandNumber)
                    {
                        result--;
                        islandNumberMappings[topIslandNumber] = leftIslandNumber;
                    }
                }
            }
        }

        return result;

        int GetIslandNumber(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            var islandNumber = islandNumbers[i, j];
            while (islandNumberMappings[islandNumber] != islandNumber)
            {
                islandNumber = islandNumberMappings[islandNumber];
            }

            return islandNumber;
        }
    }
}