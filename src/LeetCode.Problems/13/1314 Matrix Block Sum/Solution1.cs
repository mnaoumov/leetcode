namespace LeetCode.Problems._1314_Matrix_Block_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/929951244/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var dp = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                dp[i, j] =
                    mat[i][j]
                    + (i > 0 ? dp[i - 1, j] : 0)
                    + (j > 0 ? dp[i, j - 1] : 0)
                    - (i * j > 0 ? dp[i - 1, j - 1] : 0);
            }
        }

        var result = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result[i][j] =
                    Sum(i + k, j + k)
                    - Sum(i - k - 1, j + k)
                    - Sum(i + k, j - k - 1)
                    + Sum(i - k - 1, j - k - 1);
            }
        }

        return result;

        int Sum(int i, int j) => i < 0 || j < 0 ? 0 : dp[Math.Min(i, m - 1), Math.Min(j, n - 1)];
    }
}
