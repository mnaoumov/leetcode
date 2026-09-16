namespace LeetCode.Problems._0308_Range_Sum_Query_2D___Mutable;

/// <summary>
/// https://leetcode.com/problems/range-sum-query-2d-mutable/submissions/2108520580/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INumMatrix Create(int[][] matrix) => new NumMatrix(matrix);

    private sealed class NumMatrix : INumMatrix
    {
        private readonly int[][] _matrix;

        public NumMatrix(int[][] matrix)
        {
            this._matrix = matrix;
        }

        public void Update(int row, int col, int val)
        {
            _matrix[row][col] = val;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var ans = 0;

            for (var row = row1; row <= row2; row++)
            {
                for (var col = col1; col <= col2; col++)
                {
                    ans += _matrix[row][col];
                }
            }

            return ans;
        }
    }
}
