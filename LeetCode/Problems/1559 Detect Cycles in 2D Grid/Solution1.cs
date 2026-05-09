namespace LeetCode.Problems._1559_Detect_Cycles_in_2D_Grid;

/// <summary>
/// https://leetcode.com/problems/detect-cycles-in-2d-grid/submissions/1988354975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ContainsCycle(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        const int noCell = -1;

#pragma warning disable CA1814
        var visited = new bool[m, n];
#pragma warning restore CA1814

        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (visited[i, j])
                {
                    continue;
                }

                if (Dfs(i, j, noCell, noCell))
                {
                    return true;
                }
            }
        }

        return false;

        bool Dfs(int row, int column, int previousRow, int previousColumn)
        {
            if (visited[row, column])
            {
                return true;
            }

            visited[row, column] = true;

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (0 > nextRow || nextRow >= m || 0 > nextColumn || nextColumn >= n ||
                    (nextRow == previousRow && nextColumn == previousColumn) ||
                    grid[nextRow][nextColumn] != grid[row][column])
                {
                    continue;
                }

                if (Dfs(nextRow, nextColumn, row, column))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
