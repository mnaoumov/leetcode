using JetBrains.Annotations;

namespace LeetCode._0304_Range_Sum_Query_2D___Immutable;

/// <summary>
/// https://leetcode.com/submissions/detail/929988814/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INumMatrix Create(int[][] matrix) => new NumMatrix(matrix);

    private class NumMatrix : INumMatrix
    {
        private readonly int[,] _sums;

        public NumMatrix(IReadOnlyList<int[]> matrix)
        {
            var m = matrix.Count;
            var n = matrix[0].Length;
            _sums = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    _sums[i, j] =
                        matrix[i][j]
                        + (i > 0 ? _sums[i - 1, j] : 0)
                        + (j > 0 ? _sums[i, j - 1] : 0)
                        - (i * j > 0 ? _sums[i - 1, j - 1] : 0);
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2) =>
            _sums[row2, col2]
            - (row1 > 0 ? _sums[row1 - 1, col2] : 0)
            - (col1 > 0 ? _sums[row2, col1 - 1] : 0)
            + (row1 * col1 > 0 ? _sums[row1 - 1, col1 - 1] : 0);
    }
}
