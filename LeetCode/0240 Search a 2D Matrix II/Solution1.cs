using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0240_Search_a_2D_Matrix_II;

/// <summary>
/// https://leetcode.com/submissions/detail/197018411/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool SearchMatrix(int[][] matrix, int target) => SearchMatrix(ArrayHelper.ArrayOfArraysTo2D(matrix), target);

    public bool SearchMatrix(int[,] matrix, int target)
    {
        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);
        return SearchMatrix(matrix, target, 0, 0, m - 1, n - 1);
    }

    private bool SearchMatrix(int[,] matrix, int target, int topLeftRow, int topLeftColumn, int bottomRightRow, int bottomRightColumn)
    {
        if (bottomRightRow < topLeftRow || bottomRightColumn < topLeftColumn)
        {
            return false;
        }

        if (matrix[topLeftRow, topLeftColumn] > target || matrix[bottomRightRow, bottomRightColumn] < target)
        {
            return false;
        }

        int middleRow = (topLeftRow + bottomRightRow) / 2;
        int middleColumn = (topLeftColumn + bottomRightColumn) / 2;

        var middleValue = matrix[middleRow, middleColumn];

        if (middleValue == target)
        {
            return true;
        }

        if (middleValue < target)
        {
            //    L   M     R
            // L: A A A B B B
            //    A A A B B B
            // M: A A A B B B
            //    C C C C C C
            //    C C C C C C
            // R: C C C C C C

            // L - top-left
            // M - middle
            // R - bottom-right

            // A values are too small. Skip them
            // A = (L, L) - (M, M)
            // B = (L, M + 1) - (M, R)
            // C = (M + 1, L) - (R, R)

            return SearchMatrix(matrix, target, topLeftRow, middleColumn + 1, middleRow, bottomRightColumn) // B
                   || SearchMatrix(matrix, target, middleRow + 1, topLeftColumn, bottomRightRow, bottomRightColumn); // C
        }

        //    L   M     R
        // L: C C C C C C
        //    C C C C C C
        // M: B B A A A A
        //    B B A A A A
        //    B B A A A A
        // R: B B A A A A

        // L - top-left
        // M - middle
        // R - bottom-right

        // A values are too large. Skip them
        // A = (M, M) - (R, R)
        // B = (M, L) - (R, M - 1)
        // C = (L, L) - (M - 1, R)

        return SearchMatrix(matrix, target, middleRow, topLeftColumn, bottomRightRow, middleColumn - 1) // B
               || SearchMatrix(matrix, target, topLeftRow, topLeftColumn, middleRow - 1, bottomRightColumn); // C
    }
}
