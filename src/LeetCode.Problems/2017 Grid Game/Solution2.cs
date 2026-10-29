namespace LeetCode.Problems._2017_Grid_Game;

/// <summary>
/// https://leetcode.com/problems/grid-game/submissions/1515213336/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long GridGame(int[][] grid)
    {
        var n = grid[0].Length;
        if (n == 1)
        {
            return 0;
        }

        var line0SuffixSums = new long[n];
        var line1PrefixSums = new long[n];

        for (var i = 0; i < n; i++)
        {
            line1PrefixSums[i] = (i == 0 ? 0 : line1PrefixSums[i - 1]) + grid[1][i];
        }

        for (var i = n - 1; i >= 0; i--)
        {
            line0SuffixSums[i] = (i == n - 1 ? 0 : line0SuffixSums[i + 1]) + grid[0][i];
        }

        var ans = long.MaxValue;

        for (var robot1ColumnDown = 0; robot1ColumnDown < n; robot1ColumnDown++)
        {
            var robot2MaxScore = long.MinValue;

            if (robot1ColumnDown + 1 < n)
            {
                robot2MaxScore = Math.Max(robot2MaxScore, line0SuffixSums[robot1ColumnDown + 1]);
            }

            if (robot1ColumnDown > 0)
            {
                robot2MaxScore = Math.Max(robot2MaxScore, line1PrefixSums[robot1ColumnDown - 1]);
            }

            ans = Math.Min(ans, robot2MaxScore);
        }

        return ans;
    }
}
