using JetBrains.Annotations;

namespace LeetCode.Problems._1568_Minimum_Number_of_Days_to_Disconnect_Island;

/// <summary>
/// https://leetcode.com/submissions/detail/1351507634/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDays(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var directions = new (int dRow, int dColumn)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        const int land = 1;

        var landCells = new List<(int row, int column)>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == land)
                {
                    landCells.Add((i, j));
                }
            }
        }

        if (landCells.Count == 0)
        {
            return 0;
        }

        if (IsDisconnected(-1))
        {
            return 0;
        }

        for (var i = 0; i < landCells.Count; i++)
        {
            if (IsDisconnected(i))
            {
                return 1;
            }
        }

        return 2;

        bool IsDisconnected(int landIndexToSkip)
        {
            if (landIndexToSkip == 0 && landCells.Count == 1)
            {
                return true;
            }

            var visited = new HashSet<(int row, int column)>();

            var queue = new Queue<(int row, int column)>();
            queue.Enqueue(landIndexToSkip == 0 ? landCells[1] : landCells[0]);

            while (queue.Count > 0)
            {
                var (row, column) = queue.Dequeue();

                if (!visited.Add((row, column)))
                {
                    continue;
                }

                foreach (var (dRow, dColumn) in directions)
                {
                    var nextRow = row + dRow;
                    var nextColumn = column + dColumn;
                    if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                    {
                        continue;
                    }

                    if (visited.Contains((nextRow, nextColumn)))
                    {
                        continue;
                    }

                    if (grid[nextRow][nextColumn] != land)
                    {
                        continue;
                    }

                    if (landIndexToSkip != -1 && (nextRow, nextColumn) == landCells[landIndexToSkip])
                    {
                        continue;
                    }

                    queue.Enqueue((nextRow, nextColumn));
                }
            }

            return visited.Count < landCells.Count - (landIndexToSkip == -1 ? 0 : 1);
        }
    }
}
