namespace LeetCode.Problems._3651_Minimum_Cost_Path_with_Teleportations;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-path-with-teleportations/submissions/1899318981/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MinCost(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var cells = new List<(int row, int column)>();
        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                cells.Add((row, column));
            }
        }

        cells = cells.OrderBy(cell => grid[cell.row][cell.column]).ToList();

        var costs = new int[m, n];
        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                costs[row, column] = int.MaxValue;
            }
        }

        for (var teleportsLeft = 0; teleportsLeft <= k; teleportsLeft++)
        {
            var minCost = int.MaxValue;
            var j = 0;
            for (var i = 0; i < cells.Count; i++)
            {
                minCost = Math.Min(minCost, costs[cells[i].row, cells[i].column]);
                if (i + 1 < cells.Count && grid[cells[i].row][cells[i].column] == grid[cells[i + 1].row][cells[i + 1].column])
                {
                    continue;
                }
                for (var r = j; r <= i; r++)
                {
                    costs[cells[r].row, cells[r].column] = minCost;
                }
                j = i + 1;
            }
            for (var row = m - 1; row >= 0; row--)
            {
                for (var column = n - 1; column >= 0; column--)
                {
                    if (row == m - 1 && column == n - 1)
                    {
                        costs[row, column] = 0;
                        continue;
                    }
                    if (row != m - 1)
                    {
                        costs[row, column] = Math.Min(costs[row, column], costs[row + 1, column] + grid[row + 1][column]);
                    }
                    if (column != n - 1)
                    {
                        costs[row, column] = Math.Min(costs[row, column], costs[row, column + 1] + grid[row][column + 1]);
                    }
                }
            }
        }
        return costs[0, 0];
    }
}
