using JetBrains.Annotations;

namespace LeetCode._1572_Matrix_Diagonal_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/926924966/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DiagonalSum(int[][] mat)
    {
        var n = mat.Length;
        var sum = 0;

        for (var i = 0; i < n; i++)
        {
            sum += mat[i][i] + mat[i][n - 1 - i];

            if (i == n - 1 - i)
            {
                sum -= mat[i][i];
            }
        }

        return sum;
    }
}
