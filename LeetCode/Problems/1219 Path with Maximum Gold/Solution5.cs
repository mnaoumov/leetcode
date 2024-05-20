using JetBrains.Annotations;

namespace LeetCode.Problems._1219_Path_with_Maximum_Gold;

/// <summary>
/// https://leetcode.com/submissions/detail/1258233226/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
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
                ans = Math.Max(ans, Dfs(new Cell(row, column)));
                continue;

                int Dfs(Cell cell)
                {
                    var value = cell.GetValue(grid);

                    if (value == 0)
                    {
                        return 0;
                    }

                    cell.SetValue(grid, 0);
                    var ans2 = value + deltas.Select(delta => Dfs(cell.AddDelta(delta))).Prepend(0).Max();
                    cell.SetValue(grid, value);
                    return ans2;
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

            return Validate(m, n) ? grid[Row][Column] : 0;
        }

        private bool Validate(int m, int n) => Row >= 0 && Row < m && Column >= 0 && Column < n;

        public Cell AddDelta((int dRow, int dColumn) delta) => new(Row + delta.dRow, Column + delta.dColumn);

        public void SetValue(int[][] grid, int value)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            if (!Validate(m, n))
            {
                return;
            }

            grid[Row][Column] = value;
        }
    }
}
