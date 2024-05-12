using JetBrains.Annotations;

namespace LeetCode.Problems._3071_Minimum_Operations_to_Write_the_Letter_Y_on_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-387/submissions/detail/1192201474/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperationsToWriteY(int[][] grid)
    {
        var n = grid.Length;
        var middle = n / 2;

        var yCounts = new int[3];
        var nonYCounts = new int[3];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var isOnY = i < middle && (j == i || j == n - 1 - i) || i >= middle && j == middle;
                var counts = isOnY ? yCounts : nonYCounts;
                var num = grid[i][j];
                counts[num]++;
            }
        }

        var ans = int.MaxValue;

        for (var yNum = 0; yNum < 3; yNum++)
        {
            var operationsCount = yCounts.Sum() - yCounts[yNum] + nonYCounts.Sum();

            for (var nonYNum = 0; nonYNum < 3; nonYNum++)
            {
                if (nonYNum == yNum)
                {
                    continue;
                }

                ans = Math.Min(ans, operationsCount - nonYCounts[nonYNum]);
            }
        }

        return ans;
    }
}
