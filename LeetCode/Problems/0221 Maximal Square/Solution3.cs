using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0221_Maximal_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/198267243/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaximalSquare(char[][] matrix) => MaximalSquare(ArrayHelper.ArrayOfArraysTo2D(matrix));

    public int MaximalSquare(char[,] matrix)
    {
        const char squareSymbol = '1';

        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);

        int[,] leftTopSquareSizes = new int[m + 1, n + 1];
        var maxSize = 0;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                var previousSquareSize = leftTopSquareSizes[i + 1, j + 1];
                var currentSquareSize = 0;

                while (currentSquareSize < previousSquareSize + 1
                       && matrix[i + currentSquareSize, j] == squareSymbol
                       && matrix[i, currentSquareSize + j] == squareSymbol)
                {
                    currentSquareSize++;
                }

                leftTopSquareSizes[i, j] = currentSquareSize;
                if (currentSquareSize > maxSize)
                {
                    maxSize = currentSquareSize;
                }
            }
        }

        return maxSize * maxSize;
    }
}
