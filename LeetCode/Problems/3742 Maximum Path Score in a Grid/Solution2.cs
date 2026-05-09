namespace LeetCode.Problems._3742_Maximum_Path_Score_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/maximum-path-score-in-a-grid/submissions/1993717775/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int impossible = -1;

        var dp = new Dictionary<Key, int>();

        for (var row = m - 1; row >= 0; row--)
        {
            for (var column = n - 1; column >= 0; column--)
            {
                var cost = Cost(row, column);
                var score = Score(row, column);

                for (var costLeft = 0; costLeft <= k; costLeft++)
                {
                    if (costLeft < cost)
                    {
                        dp[new Key(row, column, costLeft)] = impossible;
                        continue;
                    }

                    if (row == m - 1 && column == n - 1)
                    {
                        dp[new Key(row, column, costLeft)] = score;
                        continue;
                    }

                    var ans = impossible;

                    if (row < m - 1)
                    {
                        var nextTotalScore = dp[new Key(row + 1, column, costLeft - cost)];

                        if (nextTotalScore != impossible)
                        {
                            ans = Math.Max(ans, score + nextTotalScore);
                        }
                    }

                    if (column < n - 1)
                    {
                        var nextTotalScore = dp[new Key(row, column + 1, costLeft - cost)];

                        if (nextTotalScore != impossible)
                        {
                            ans = Math.Max(ans, score + nextTotalScore);
                        }
                    }

                    dp[new Key(row, column, costLeft)] = ans;
                }
            }
        }

        return dp[new Key(0, 0, k)];

        int Cost(int row, int column) => grid[row][column] == 0 ? 0 : 1;

        int Score(int row, int column) => grid[row][column];
    }

    private sealed record Key(int Row, int Column, int CostLeft);
}
