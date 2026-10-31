// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class PrefixSumTemplate
{
    // Sums over half-open ranges: Sum(from, to) covers [from, to).
    public sealed class PrefixSum
    {
        private readonly long[] _sums;

        public PrefixSum(IReadOnlyList<int> values)
        {
            _sums = new long[values.Count + 1];

            for (var i = 0; i < values.Count; i++)
            {
                _sums[i + 1] = _sums[i] + values[i];
            }
        }

        public long Sum(int from, int to) => _sums[to] - _sums[from];

        public long Total => _sums[^1];
    }

    // Sums over half-open rectangles: RectangleSum(row1, column1, row2, column2) covers [row1, row2) x [column1, column2).
    public sealed class PrefixSum2D
    {
        private readonly long[][] _sums;

        public PrefixSum2D(int[][] matrix)
        {
            var m = matrix.Length;
            var n = m == 0 ? 0 : matrix[0].Length;
            _sums = Enumerable.Range(0, m + 1).Select(_ => new long[n + 1]).ToArray();

            for (var row = 0; row < m; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    _sums[row + 1][column + 1] = _sums[row][column + 1] + _sums[row + 1][column] - _sums[row][column] + matrix[row][column];
                }
            }
        }

        public long RectangleSum(int row1, int column1, int row2, int column2) =>
            _sums[row2][column2] - _sums[row1][column2] - _sums[row2][column1] + _sums[row1][column1];
    }
}
