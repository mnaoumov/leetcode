using JetBrains.Annotations;

namespace LeetCode.Problems._0296_Best_Meeting_Point;

/// <summary>
/// https://leetcode.com/submissions/detail/1119985980/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTotalDistance(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rowCounts = new int[m];
        var columnCounts = new int[n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != 1)
                {
                    continue;
                }

                rowCounts[i]++;
                columnCounts[j]++;
            }
        }

        return MinWeighted(rowCounts) + MinWeighted(columnCounts);
    }

    private static int MinWeighted(IReadOnlyList<int> counts)
    {
        var n = counts.Count;
        var aggregatedCounts = new int[n];
        var aggregatedWeightedCounts = new int[n];

        for (var i = 0; i < n; i++)
        {
            aggregatedCounts[i] = (i > 0 ? aggregatedCounts[i - 1] : 0) + counts[i];
            aggregatedWeightedCounts[i] = (i > 0 ? aggregatedWeightedCounts[i - 1] : 0) + i * counts[i];
        }

        var middleCount = (aggregatedCounts[^1] + 1) / 2;

        var middleIndex = 0;

        while (true)
        {
            if (aggregatedCounts[middleIndex] >= middleCount)
            {
                break;
            }

            middleIndex++;
        }

        var ans = aggregatedWeightedCounts[^1] - 2 * aggregatedWeightedCounts[middleIndex] -
                  middleIndex * (aggregatedCounts[^1] - 2 * aggregatedCounts[middleIndex]);
        return ans;
    }
}
