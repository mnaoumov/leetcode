using JetBrains.Annotations;

namespace LeetCode.Problems._0766_Toeplitz_Matrix;

/// <summary>
/// https://leetcode.com/problems/toeplitz-matrix/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var diffDict = new Dictionary<int, int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var diff = i - j;

                if (!diffDict.TryGetValue(diff, out var value))
                {
                    diffDict[diff] = matrix[i][j];
                }
                else if (value != matrix[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
