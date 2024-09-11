using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1219_Path_with_Maximum_Gold;

/// <summary>
/// https://leetcode.com/submissions/detail/1257549109/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

        var dp = new Dictionary<string, int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                ans = Math.Max(ans, Dfs(new Cell(i, j), new HashSet<Cell>()));
            }
        }

        return ans;

        int Dfs(Cell cell, HashSet<Cell> visitedCells)
        {
            if (cell.Row < 0 || cell.Column < 0 || cell.Row >= m || cell.Column >= n || visitedCells.Contains(cell))
            {
                return 0;
            }

            var value = grid[cell.Row][cell.Column];

            if (value == 0)
            {
                return 0;
            }

            var key = string.Concat(visitedCells.OrderBy(visitedCell => visitedCell.Row)
                .ThenBy(visitedCell => visitedCell.Column).Prepend(cell));

            if (dp.TryGetValue(key, out var ans2))
            {
                return ans2;
            }

            var nextVisitedCells = visitedCells.ToHashSet();
            nextVisitedCells.Add(cell);

            ans2 = value;

            foreach (var (dRow, dColumn) in deltas)
            {
                ans2 = Math.Max(ans2, value + Dfs(new Cell(cell.Row + dRow, cell.Column + dColumn), nextVisitedCells));
            }

            return dp[key] = ans2;
        }
    }

    private record Cell(int Row, int Column);
}
