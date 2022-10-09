// ReSharper disable All
namespace LeetCode._0085_Maximal_Rectangle;

/// <summary>
/// https://leetcode.com/submissions/detail/200371094/
/// </summary>
public class Solution1 : ISolution
{
    public int MaximalRectangle(char[][] matrix) => MaximalRectangle(ArrayHelper.ArrayOfArraysTo2D(matrix));

    /// <summary>
    /// Was different signature
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public int MaximalRectangle(char[,] matrix)
    {
        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);

        // dp[i,j][h] = w - means, that we have rectangle (i,j)->(i+w-1,j+h-1) and w is maximal for fixed (i,j,h)
        var dp = new int[m + 1, n + 1][];
        var result = 0;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                const char rectangleSymbol = '1';
                if (matrix[i, j] != rectangleSymbol)
                {
                    continue;
                }

                var height = dp[i + 1, j] == null ? 1 : dp[i + 1, j].Length;
                var widths = new int[height + 1];
                dp[i, j] = widths;
                for (int k = 1; k <= height; k++)
                {
                    widths[k] = k == 1
                        ? GetMaxWidth(dp, i, j + 1, 1) + 1
                        : Math.Min(GetMaxWidth(dp, i + 1, j + 1, k - 1) + 1, widths[1]);

                    result = Math.Max(result, k * widths[k]);
                }
            }
        }

        return result;
    }

    private static int GetMaxWidth(int[,][] dp, int i, int j, int height)
    {
        return dp[i, j] != null && dp[i, j].Length > height ? dp[i, j][height] : 0;
    }
}
