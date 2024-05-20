using JetBrains.Annotations;

namespace LeetCode.Problems._1219_Path_with_Maximum_Gold;

/// <summary>
/// https://leetcode.com/submissions/detail/1258213941/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
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

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var visited = new HashSet<Cell>();
                ans = Math.Max(ans, Dfs(new Cell(row, column)));
                continue;

                int Dfs(Cell cell)
                {
                    var value = cell.GetValue(grid);

                    if (value == 0)
                    {
                        return 0;
                    }

                    if (!visited.Add(cell))
                    {
                        return 0;
                    }

                    return value + deltas.Select(delta => Dfs(cell.AddDelta(delta))).Prepend(0).Max();
                }
            }
        }

        return ans;
    }

    private record Cell(int Row, int Column)
    {
        public int GetValue(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            if (Row < 0 || Row >= m || Column < 0 || Column >= n)
            {
                return 0;
            }

            return grid[Row][Column];
        }

        public Cell AddDelta((int dRow, int dColumn) delta) => new(Row + delta.dRow, Column + delta.dColumn);
    }
}
