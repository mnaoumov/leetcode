using JetBrains.Annotations;

namespace LeetCode.Problems._3070_Count_Submatrices_with_Top_Left_Element_and_Sum_Less_Than_k;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-387/submissions/detail/1192177931/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var previousColumnSums = new long[n];
        var maxColumn = n - 1;

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            var columnSums = new long[maxColumn + 1];

            for (var j = 0; j <= maxColumn; j++)
            {
                columnSums[j] = previousColumnSums[j] + (j > 0 ? columnSums[j - 1] - previousColumnSums[j - 1] : 0) +
                                grid[i][j];

                if (columnSums[j] <= k)
                {
                    continue;
                }

                maxColumn = j - 1;
                break;
            }

            ans += maxColumn + 1;
            previousColumnSums = columnSums;
        }

        return ans;
    }
}
