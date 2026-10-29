namespace LeetCode.Problems._3552_Grid_Teleportation_Traversal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-450/problems/grid-teleportation-traversal/submissions/1636900350/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinMoves(string[] matrix)
    {
        var pq = new PriorityQueue<(int steps, int row, int column, HashSet<char> usedTeleports, bool canUseTeleport), int>();
        pq.Enqueue((0, 0, 0, new HashSet<char>(), true), 0);
        var m = matrix.Length;
        var n = matrix[0].Length;
        const char obstacle = '#';
        var teleportCells = new Dictionary<char, List<(int row, int column)>>();

        var visited = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var cell = matrix[i][j];

                if (cell == obstacle)
                {
                    visited[i, j] = true;
                }
                else if (char.IsLetter(cell))
                {
                    teleportCells.TryAdd(cell, new List<(int row, int column)>());
                    teleportCells[cell].Add((i, j));
                }
            }
        }

        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        while (pq.Count > 0)
        {
            var (steps, row, column, usedTeleports, canUseTeleport) = pq.Dequeue();

            if (visited[row, column])
            {
                continue;
            }

            visited[row, column] = true;

            if (row == m - 1 && column == n - 1)
            {
                return steps;
            }

            var cell = matrix[row][column];

            if (usedTeleports.Contains(cell) && canUseTeleport)
            {
                continue;
            }

            if (char.IsLetter(cell) && canUseTeleport)
            {
                foreach (var (otherRow, otherColumn) in teleportCells[cell])
                {
                    if ((otherRow, otherColumn) == (row, column))
                    {
                        continue;
                    }

                    if (visited[otherRow, otherColumn])
                    {
                        continue;
                    }

                    var nextUsedTeleports = new HashSet<char>(usedTeleports) { cell };
                    pq.Enqueue((steps, otherRow, otherColumn, nextUsedTeleports, false), steps);
                }
            }

            foreach (var (dx, dy) in directions)
            {
                var newRow = row + dx;
                var newColumn = column + dy;
                if (newRow < 0 || newRow >= m || newColumn < 0 || newColumn >= n)
                {
                    continue;
                }
                if (visited[newRow, newColumn])
                {
                    continue;
                }
                pq.Enqueue((steps + 1, newRow, newColumn, usedTeleports, true), steps + 1);
            }
        }

        return -1;
    }
}
