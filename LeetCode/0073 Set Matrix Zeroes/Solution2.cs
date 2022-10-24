using JetBrains.Annotations;

namespace LeetCode._0073_Set_Matrix_Zeroes;

/// <summary>
/// https://leetcode.com/submissions/detail/829031449/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public void SetZeroes(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var shouldFirstColumnBeZeroed = false;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (matrix[i][j] != 0)
                {
                    continue;
                }

                matrix[i][0] = 0;

                if (j > 0)
                {
                    matrix[0][j] = 0;
                }
                else
                {
                    shouldFirstColumnBeZeroed = true;
                }
            }
        }

        for (var i = 1; i < m; i++)
        {
            if (matrix[i][0] != 0)
            {
                continue;
            }

            for (var j = 1; j < n; j++)
            {
                matrix[i][j] = 0;
            }
        }

        for (var j = 1; j < n; j++)
        {
            if (matrix[0][j] != 0)
            {
                continue;
            }

            for (var i = 1; i < m; i++)
            {
                matrix[i][j] = 0;
            }
        }

        if (matrix[0][0] == 0)
        {
            for (var j = 1; j < n; j++)
            {
                matrix[0][j] = 0;
            }
        }

        if (!shouldFirstColumnBeZeroed)
        {
            return;
        }

        for (var i = 0; i < m; i++)
        {
            matrix[i][0] = 0;
        }
    }
}