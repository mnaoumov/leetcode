using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0221_Maximal_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/198251366/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
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
                if (matrix[i, j] != squareSymbol)
                {
                    leftTopSquareSizes[i, j] = 0;
                    continue;
                }

                var previousSquareSize = leftTopSquareSizes[i + 1, j + 1];

                var areLeftTopSidesFull =
                    Enumerable.Range(i + 1, previousSquareSize).All(k => matrix[k, j] == squareSymbol) &&
                    Enumerable.Range(j + 1, previousSquareSize).All(k => matrix[i, k] == squareSymbol);

                leftTopSquareSizes[i, j] = previousSquareSize + (areLeftTopSidesFull ? 1 : 0);
                if (leftTopSquareSizes[i, j] > maxSize)
                {
                    maxSize = leftTopSquareSizes[i, j];
                }
            }
        }

        return maxSize * maxSize;
    }
}
