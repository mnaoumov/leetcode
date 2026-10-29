namespace LeetCode.Problems._3742_Maximum_Path_Score_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/maximum-path-score-in-a-grid/submissions/1993729458/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;

#pragma warning disable CA1814
        var dp = new int[m, n, k + 1];
#pragma warning restore CA1814

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                for (var c = 0; c <= k; c++)
                {
                    Set(i, j, c, int.MinValue);
                }
            }
        }

        Set(0, 0, 0, 0);

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                for (var costLeft = 0; costLeft <= k; costLeft++)
                {
                    if (Get(row, column, costLeft) == int.MinValue)
                    {
                        continue;
                    }

                    if (row + 1 < m)
                    {
                        var val = grid[row + 1][column];
                        var cost = val == 0 ? 0 : 1;
                        if (costLeft + cost <= k)
                        {
                            var max = Math.Max(
                                Get(row + 1, column, costLeft + cost),
                                Get(row, column, costLeft) + val
                            );
                            Set(row + 1, column, costLeft + cost, max);
                        }
                    }

                    // ReSharper disable once InvertIf
                    if (column + 1 < n)
                    {
                        var val = grid[row][column + 1];
                        var cost = val == 0 ? 0 : 1;
                        // ReSharper disable once InvertIf
                        if (costLeft + cost <= k)
                        {
                            var max = Math.Max(
                                Get(row, column + 1, costLeft + cost),
                                Get(row, column, costLeft) + val
                            );
                            Set(row, column + 1, costLeft + cost, max);
                        }
                    }
                }
            }
        }

        var ans = int.MinValue;
        for (var costLeft = 0; costLeft <= k; costLeft++)
        {
            ans = Math.Max(ans, Get(m - 1, n - 1, costLeft));
        }

        return ans < 0 ? -1 : ans;

        void Set(int row, int column, int costLeft, int value) => dp[row, column, costLeft] = value;

        int Get(int row, int column, int costLeft) => dp[row, column, costLeft];
    }
}
