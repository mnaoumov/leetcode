using JetBrains.Annotations;

namespace LeetCode.Problems._1219_Path_with_Maximum_Gold;

/// <summary>
/// https://leetcode.com/submissions/detail/1257538262/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int GetMaximumGold(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var ans = 0;

        var deltas = new (int dRow, int dColumn)[]
        {
            (1, 0), (0, 1), (-1, 0), (0, -1)
        };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                var queue = new Queue<(Cell cell, HashSet<Cell> visitedCells, int cost)>();
                queue.Enqueue((new Cell(i, j), new HashSet<Cell>(), 0));

                while (queue.Count > 0)
                {
                    var (cell, visitedCells, cost) = queue.Dequeue();

                    ans = Math.Max(ans, cost);

                    if (cell.Row < 0 || cell.Column < 0 || cell.Row >= m || cell.Column >= n || visitedCells.Contains(cell))
                    {
                        continue;
                    }

                    var value = grid[cell.Row][cell.Column];

                    if (value == 0)
                    {
                        continue;
                    }

                    var nextVisitedCells = visitedCells.ToHashSet();
                    nextVisitedCells.Add(cell);

                    foreach (var (dRow, dColumn) in deltas)
                    {
                        queue.Enqueue((new Cell(cell.Row + dRow, cell.Column+dColumn), nextVisitedCells, cost + value));
                    }
                }
            }
        }

        return ans;
    }

    private record Cell(int Row, int Column);
}
