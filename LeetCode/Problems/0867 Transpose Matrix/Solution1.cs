using JetBrains.Annotations;

namespace LeetCode._0867_Transpose_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/1116493981/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] Transpose(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var ans = Enumerable.Range(0, n).Select(_ => new int[m]).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                ans[j][i] = matrix[i][j];
            }
        }

        return ans;
    }
}
