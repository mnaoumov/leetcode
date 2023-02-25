using JetBrains.Annotations;

namespace LeetCode._1091_Shortest_Path_in_Binary_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/904476731/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        var n = grid.Length;
        const int impossible = -1;

        if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
        {
            return impossible;
        }

        var seen = new HashSet<(int row, int column)>();
        var deltas = new (int dRow, int dColumn)[]
        {
            (-1, -1), (0, -1), (1, -1),
            (-1, 0), (1, 0),
            (-1, 1), (0, 1), (1, 1)
        };

        var queue = new Queue<((int row, int column) cell, int pathLength)>();
        queue.Enqueue(((0, 0), 1));

        while (queue.Count > 0)
        {
            var (cell, pathLength) = queue.Dequeue();

            if (cell == (n - 1, n - 1))
            {
                return pathLength;
            }

            if (cell.row < 0 || cell.row >= n || cell.column < 0 || cell.column >= n)
            {
                continue;
            }

            if (grid[cell.row][cell.column] != 0)
            {
                continue;
            }

            if (!seen.Add(cell))
            {
                continue;
            }

            foreach (var (dRow, dColumn) in deltas)
            {
                queue.Enqueue(((cell.row + dRow, cell.column + dColumn), pathLength + 1));
            }
        }

        return impossible;
    }
}
