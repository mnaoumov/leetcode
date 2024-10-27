namespace LeetCode.Problems._1277_Count_Square_Submatrices_with_All_Ones;

/// <summary>
/// https://leetcode.com/submissions/detail/1434714335/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSquares(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var subMatrixSums = new int[m + 1, n + 1];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                subMatrixSums[i + 1, j + 1] =
                    matrix[i][j]
                    + subMatrixSums[i, j + 1]
                    + subMatrixSums[i + 1, j]
                    - subMatrixSums[i, j];
            }
        }

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                for (var k = 0; k < Math.Min(m - i, n - j); k++)
                {
                    var sum = subMatrixSums[i + k + 1, j + k + 1]
                              - subMatrixSums[i, j + k + 1]
                              - subMatrixSums[i + k + 1, j]
                              + subMatrixSums[i, j];

                    if (sum == (k + 1) * (k + 1))
                    {
                        ans++;
                    }
                }
            }
        }

        return ans;
    }
}
