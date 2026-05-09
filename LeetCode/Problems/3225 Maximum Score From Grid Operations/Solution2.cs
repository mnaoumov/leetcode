#pragma warning disable CA1814
namespace LeetCode.Problems._3225_Maximum_Score_From_Grid_Operations;

/// <summary>
/// https://leetcode.com/problems/maximum-score-from-grid-operations/submissions/1990705031/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaximumScore(int[][] grid)
    {
        var n = grid[0].Length;
        if (n == 1)
        {
            return 0;
        }

        var dp = new long[n, n + 1, n + 1];
        var previousMaxes = new long[n + 1, n + 1];
        var previousSuffixMaxes = new long[n + 1, n + 1];
        var columnPrefixSums = new long[n + 1, n];

        for (var column = 0; column < n; column++)
        {
            for (var row = 0; row < n; row++)
            {
                columnPrefixSums[row + 1, column] = columnPrefixSums[row, column] + grid[row][column];
            }
        }

        for (var column = 1; column < n; column++)
        {
            for (var currentBlackRowsCount = 0; currentBlackRowsCount <= n; currentBlackRowsCount++)
            {
                for (var previousBackRowsCount = 0; previousBackRowsCount <= n; previousBackRowsCount++)
                {
                    if (currentBlackRowsCount <= previousBackRowsCount)
                    {
                        var extraScore = columnPrefixSums[previousBackRowsCount, column] - columnPrefixSums[currentBlackRowsCount, column];
                        dp[column, currentBlackRowsCount, previousBackRowsCount] =
                            Math.Max(dp[column, currentBlackRowsCount, previousBackRowsCount],
                                     previousSuffixMaxes[previousBackRowsCount, 0] + extraScore);
                    }
                    else
                    {
                        var extraScore = columnPrefixSums[currentBlackRowsCount, column - 1] - columnPrefixSums[previousBackRowsCount, column - 1];
                        dp[column, currentBlackRowsCount, previousBackRowsCount] = Math.Max(
                            dp[column, currentBlackRowsCount, previousBackRowsCount],
                            Math.Max(previousSuffixMaxes[previousBackRowsCount, currentBlackRowsCount],
                                     previousMaxes[previousBackRowsCount, currentBlackRowsCount] + extraScore));
                    }
                }
            }

            for (var currentBlackRowsCount = 0; currentBlackRowsCount <= n; currentBlackRowsCount++)
            {
                previousMaxes[currentBlackRowsCount, 0] = dp[column, currentBlackRowsCount, 0];
                for (var previousBackRowsCount = 1; previousBackRowsCount <= n; previousBackRowsCount++)
                {
                    var penalty = previousBackRowsCount > currentBlackRowsCount
                        ? columnPrefixSums[previousBackRowsCount, column] -
                          columnPrefixSums[currentBlackRowsCount, column]
                        : 0;
                    previousMaxes[currentBlackRowsCount, previousBackRowsCount] =
                        Math.Max(previousMaxes[currentBlackRowsCount, previousBackRowsCount - 1],
                                 dp[column, currentBlackRowsCount, previousBackRowsCount] - penalty);
                }

                previousSuffixMaxes[currentBlackRowsCount, n] = dp[column, currentBlackRowsCount, n];
                for (var previousBackRowsCount = n - 1; previousBackRowsCount >= 0; previousBackRowsCount--)
                {
                    previousSuffixMaxes[currentBlackRowsCount, previousBackRowsCount] = Math.Max(
                        previousSuffixMaxes[currentBlackRowsCount, previousBackRowsCount + 1], dp[column, currentBlackRowsCount, previousBackRowsCount]);
                }
            }
        }

        var ans = 0L;
        for (var k = 0; k <= n; k++)
        {
            ans = Math.Max(ans, Math.Max(dp[n - 1, n, k], dp[n - 1, 0, k]));
        }

        return ans;
    }
}
