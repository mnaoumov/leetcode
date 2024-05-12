using JetBrains.Annotations;

namespace LeetCode.Problems._0200_Number_of_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/870017776/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int NumIslands(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const char land = '1';

        var visited = new bool[m, n];
        var result = 0;

        var deltas = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != land || visited[i, j])
                {
                    continue;
                }

                result++;
                var queue = new Queue<(int row, int column)>();
                queue.Enqueue((i, j));

                while (queue.Count > 0)
                {
                    var (row, column) = queue.Dequeue();

                    if (row < 0 || row >= m || column < 0 || column >= n)
                    {
                        continue;
                    }

                    if (grid[row][column] != land)
                    {
                        continue;
                    }

                    if (visited[row, column])
                    {
                        continue;
                    }

                    visited[row, column] = true;

                    foreach (var (dRow, dColumn) in deltas)
                    {
                        queue.Enqueue((row + dRow, column + dColumn));
                    }
                }
            }
        }

        return result;
    }
}
