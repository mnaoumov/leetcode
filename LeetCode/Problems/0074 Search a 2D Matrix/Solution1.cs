using JetBrains.Annotations;

namespace LeetCode._0074_Search_a_2D_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/820837695/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        if (target < matrix[0][0] || matrix[m - 1][n - 1] < target)
        {
            return false;
        }

        var left = 0;
        var right = m - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            var value = matrix[mid][0];

            if (value < target)
            {
                left = mid + 1;
            }
            else if (value > target)
            {
                right = mid - 1;
            }
            else
            {
                return true;
            }
        }

        var rowId = left - 1;

        left = 0;
        right = n - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            var value = matrix[rowId][mid];

            if (value < target)
            {
                left = mid + 1;
            }
            else if (value > target)
            {
                right = mid - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
