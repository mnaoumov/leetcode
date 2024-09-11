using JetBrains.Annotations;
using LeetCode.Helpers;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0240_Search_a_2D_Matrix_II;

/// <summary>
/// https://leetcode.com/submissions/detail/208244157/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool SearchMatrix(int[][] matrix, int target) => SearchMatrix(ArrayHelper.ArrayOfArraysTo2D(matrix), target);

    public bool SearchMatrix(int[,] matrix, int target)
    {
        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);
        return SearchMatrix(matrix, target, new MatrixIndex(0, 0, m - 1, n - 1));
    }

    private bool SearchMatrix(int[,] matrix, int target, MatrixIndex matrixIndex)
    {
        if (matrixIndex.BottomRightRow < matrixIndex.TopLeftRow || matrixIndex.BottomRightColumn < matrixIndex.TopLeftColumn)
        {
            return false;
        }

        if (matrix[matrixIndex.TopLeftRow, matrixIndex.TopLeftColumn] > target || matrix[matrixIndex.BottomRightRow, matrixIndex.BottomRightColumn] < target)
        {
            return false;
        }

        int middleRow = (matrixIndex.TopLeftRow + matrixIndex.BottomRightRow) / 2;
        int middleColumn = (matrixIndex.TopLeftColumn + matrixIndex.BottomRightColumn) / 2;

        var middleValue = matrix[middleRow, middleColumn];

        if (middleValue == target)
        {
            return true;
        }

        if (middleValue < target)
        {
            //    L   M   R
            // L: A A A B B
            //    A A A B B
            // M: A A A B B
            //    C C C C C
            // R: C C C C C

            // L - top-left
            // M - middle
            // R - bottom-right

            // A values are too small. Skip them
            // A = (L, L) - (M, M)
            // B = (L, M + 1) - (M, R)
            // C = (M + 1, L) - (R, R)

            var matrixIndexB = new MatrixIndex(matrixIndex.TopLeftRow, middleColumn + 1, middleRow, matrixIndex.BottomRightColumn);
            var matrixIndexC = new MatrixIndex(middleRow + 1, matrixIndex.TopLeftColumn, matrixIndex.BottomRightRow, matrixIndex.BottomRightColumn);

            return SearchMatrix(matrix, target, matrixIndexB) || SearchMatrix(matrix, target, matrixIndexC);
        }
        else
        {
            //    L   M   R
            // L: C C C C C
            //    C C C C C
            // M: B B A A A
            //    B B A A A
            // R: B B A A A

            // L - top-left
            // M - middle
            // R - bottom-right

            // A values are too large. Skip them
            // A = (M, M) - (R, R)
            // B = (M, L) - (R, M - 1)
            // C = (L, L) - (M - 1, R)

            var matrixIndexB = new MatrixIndex(middleRow, matrixIndex.TopLeftColumn, matrixIndex.BottomRightRow,
                middleColumn - 1);
            var matrixIndexC = new MatrixIndex(matrixIndex.TopLeftRow, matrixIndex.TopLeftColumn, middleRow - 1,
                matrixIndex.BottomRightColumn);

            return SearchMatrix(matrix, target, matrixIndexB) || SearchMatrix(matrix, target, matrixIndexC);
        }
    }

    private class MatrixIndex
    {
        public int TopLeftRow { get; }
        public int TopLeftColumn { get; }
        public int BottomRightRow { get; }
        public int BottomRightColumn { get; }

        public MatrixIndex(int topLeftRow, int topLeftColumn, int bottomRightRow, int bottomRightColumn)
        {
            TopLeftRow = topLeftRow;
            TopLeftColumn = topLeftColumn;
            BottomRightRow = bottomRightRow;
            BottomRightColumn = bottomRightColumn;
        }
    }
}
