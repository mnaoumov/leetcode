namespace LeetCode.Problems._0861_Score_After_Flipping_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/1257010013/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MatrixScore(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        for (var i = 0; i < m; i++)
        {
            if (grid[i][0] != 0)
            {
                continue;
            }

            for (var j = 0; j < n; j++)
            {
                grid[i][j] ^= 1;
            }
        }

        var ans = m * (1 << n - 1);

        for (var j = 1; j < n; j++)
        {
            var j1 = j;
            var count = Enumerable.Range(0, m).Count(i => grid[i][j1] == 1);
            count = Math.Max(count, m - count);
            ans += count * (1 << n - 1 - j);
        }

        return ans;
    }
}
