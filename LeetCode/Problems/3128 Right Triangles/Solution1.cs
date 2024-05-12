using JetBrains.Annotations;

namespace LeetCode._3128_Right_Triangles;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-129/submissions/detail/1243307174/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long NumberOfRightTriangles(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var onesPerRowCounts = new int[m];
        var onesPerColumnCounts = new int[n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != 1)
                {
                    continue;
                }

                onesPerRowCounts[i]++;
                onesPerColumnCounts[j]++;
            }
        }

        var ans = 0L;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    ans += 1L * (onesPerRowCounts[i] - 1) * (onesPerColumnCounts[j] - 1);
                }
            }
        }

        return ans;
    }
}
