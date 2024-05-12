namespace LeetCode.Problems._1428_Leftmost_Column_with_at_Least_a_One
{
    public class BinaryMatrix
    {
        private readonly int[][] _mat;

        public BinaryMatrix(int[][] mat) => _mat = mat;

        public int Get(int row, int col) => _mat[row][col];
        public IList<int> Dimensions() => new[] { _mat.Length, _mat[0].Length };
    }
}
