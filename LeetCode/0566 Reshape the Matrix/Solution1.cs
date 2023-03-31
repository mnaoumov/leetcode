using JetBrains.Annotations;

namespace LeetCode._0566_Reshape_the_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/925456509/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        if (m * n != r * c)
        {
            return mat;
        }

        var result = Enumerable.Range(0, r).Select(_ => new int[c]).ToArray();

        for (var i = 0; i < r; i++)
        {
            for (var j = 0; j < c; j++)
            {
                var flatIndex = i * c + j;
                result[i][j] = mat[flatIndex / n][flatIndex % n];
            }
        } 

        return result;
    }
}
